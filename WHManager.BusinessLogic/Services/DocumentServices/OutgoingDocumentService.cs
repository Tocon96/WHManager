using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services.DocumentServices.Interfaces
{
    public class OutgoingDocumentService : IOutgoingDocumentService
    {
        IOutgoingDocumentRepository outgoingDocumentRepository = new OutgoingDocumentRepository(new DataAccess.WHManagerDBContextFactory());
        IClientService clientService = new ClientService();
        IProductService productService = new ProductService();
        
        public int AddDocument(OutgoingDocument document)
        {
            return outgoingDocumentRepository.AddDocument(document.Contrahent.Id, document.OrderId, document.DateSent);
        }

        public void DeleteDocument(int id)
        {
            outgoingDocumentRepository.DeleteDocument(id);
        }

        public OutgoingDocument GetDocument(int id)
        {
            var document = outgoingDocumentRepository.GetDocumentById(id);
            OutgoingDocument outgoingDocument = new OutgoingDocument()
            {
                Id = document.Id,
                Contrahent = clientService.GetClient(document.Contrahent.Id)[0],
                OrderId = document.OrderId,
            };
            return outgoingDocument;

        }

        public IList<OutgoingDocument> GetDocuments()
        {
            IList<OutgoingDocument> documentsList = new List<OutgoingDocument>();
            var documents = outgoingDocumentRepository.GetDocuments();
            foreach (var document in documents)
            {
                OutgoingDocument newDocument = new OutgoingDocument
                {
                    Id = document.Id,
                    Contrahent = clientService.GetClient(document.Contrahent.Id)[0],
                    OrderId = document.OrderId,
                    DateSent = document.DateSent
                };
                documentsList.Add(newDocument);
            }
            return documentsList;

        }

        public IList<OutgoingDocument> SearchDocuments(IList<string> criteria)
        {
            IList<OutgoingDocument> documentsList = new List<OutgoingDocument>();
            var documents = outgoingDocumentRepository.SearchDocuments(criteria);
            foreach (var document in documents)
            {
                OutgoingDocument newDocument = new OutgoingDocument
                {
                    Id = document.Id,
                    Contrahent = clientService.GetClient(document.Contrahent.Id)[0],
                    DateSent = document.DateSent,
                    OrderId = document.OrderId
                };
                documentsList.Add(newDocument);
            }
            return documentsList;
        }

        public int UpdateDocument(OutgoingDocument document)
        {
            return outgoingDocumentRepository.UpdateDocument(document.Id, document.Contrahent.Id, document.OrderId, document.DateSent);
        }

        public OutgoingDocument GetDocumentByOrderId(int orderId)
        {
            var document = outgoingDocumentRepository.GetDocumentById(orderId);
            OutgoingDocument outgoingDocument = new OutgoingDocument()
            {
                Id = document.Id,
                Contrahent = clientService.GetClient(document.Contrahent.Id)[0],
                DateSent = document.DateSent,
                OrderId = document.OrderId
            };
            return outgoingDocument;
        }

        public void GeneratePdf(string filename, Order order)
        {
            OutgoingDocument outgoingDocument = GetDocumentByOrderId(order.Id);
            FontProgram fontProgram = FontProgramFactory.CreateFont();
            PdfFont font = PdfFontFactory.CreateFont(fontProgram, "CP1257");
            PdfWriter writer = new PdfWriter(filename);
            PdfDocument pdf = new PdfDocument(writer);
            pdf.SetDefaultPageSize(PageSize.A4.Rotate());
            Document document = new Document(pdf);
            document.SetFont(font);
            Table initialTable = GenerateInitialTable(outgoingDocument);
            Table providerTable = GenerateProviderTable(order.Client);
            Table itemTable = GenerateItemTable(order);
            document.Add(initialTable);
            document.Add(providerTable);
            document.Add(itemTable);
            document.Close();

        }

        Table GenerateInitialTable(OutgoingDocument document)
        {

            Table table = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth().SetHeight(100);
            table.AddCell(new Cell());
            table.AddCell(new Cell()
                              .Add(new Paragraph("Rozchód Zewnętrzny")
                                       .SetTextAlignment(TextAlignment.CENTER)
                                       .SetFontSize(20)
                                       .SetBold())
                              .SetVerticalAlignment(VerticalAlignment.MIDDLE));
            table.AddCell(new Cell()
                                .Add(new Table(2)
                                            .AddCell(new Paragraph("Numer dokumentu: "))
                                            .AddCell(new Paragraph(document.Id.ToString()))
                                            .AddCell(new Paragraph("Data realizacji"))
                                            .AddCell(new Paragraph(document.DateSent.ToShortDateString())))
                                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                                .SetHorizontalAlignment(HorizontalAlignment.CENTER));
            return table;
        }

        Table GenerateProviderTable(Client client)
        {

            Table table = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();
            table.AddHeaderCell(new Cell(1, 2).Add(new Paragraph("Klient").SetTextAlignment(TextAlignment.CENTER).SetBold().SetFontSize(14)));
            table.AddCell(new Cell().Add(new Paragraph("Nazwa: ")));
            table.AddCell(new Cell().Add(new Paragraph(client.Name)));
            table.AddCell(new Cell().Add(new Paragraph("NIP: ")));
            table.AddCell(new Cell().Add(new Paragraph(client.Nip.ToString())));
            table.AddCell(new Cell().Add(new Paragraph("Numer telefonu: ")));
            table.AddCell(new Cell().Add(new Paragraph(client.PhoneNumber)));
            return table;
        }

        Table GenerateItemTable(Order order)
        {
            Table table = new Table(UnitValue.CreatePercentArray(8)).UseAllAvailableWidth();
            table.AddHeaderCell(new Cell(1, 8).Add(new Paragraph("Elementy").SetTextAlignment(TextAlignment.CENTER).SetBold().SetFontSize(14)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Nr")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Nazwa Produktu")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Ilość(szt)")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Cena jednostkowa(PLN)")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Stawka VAT(%)")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Kwota Netto(PLN)")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Kwota VAT(PLN)")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Kwota Brutto(PLN)")));

            var grouped = order.Items.OrderBy(x => x.Product.Id).GroupBy(x => x.Product.Id);
            int enumerator = 1;
            IList<decimal> totalNettoDelivery = new List<decimal>();
            IList<decimal> totalTaxDelivery = new List<decimal>();
            IList<decimal> totalBruttoDelivery = new List<decimal>();

            foreach (var group in grouped)
            {
                Product product = productService.GetProduct(group.Key)[0];
                table.AddCell(new Cell().Add(new Paragraph(enumerator.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(product.Name)));
                int itemCount = order.Items.Count(x => x.Product.Id == group.Key);
                table.AddCell(new Cell().Add(new Paragraph(itemCount.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(product.PriceSell.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(product.Tax.Value.ToString())));
                decimal totalNetto = Math.Round(itemCount * product.PriceSell, 2);
                totalNettoDelivery.Add(totalNetto);
                table.AddCell(new Cell().Add(new Paragraph(totalNetto.ToString())));
                decimal vatValue = Math.Round((decimal)product.Tax.Value / 100 * totalNetto, 2);
                totalTaxDelivery.Add(vatValue);
                table.AddCell(new Cell().Add(new Paragraph(vatValue.ToString())));
                decimal totalBrutto = Math.Round(vatValue + totalNetto, 2);
                totalBruttoDelivery.Add(totalBrutto);
                table.AddCell(new Cell().Add(new Paragraph(totalBrutto.ToString())));
                enumerator++;
            }

            table.AddCell(new Cell(1, 5).Add(new Paragraph("Suma: ").SetTextAlignment(TextAlignment.CENTER)));
            table.AddCell(new Cell().Add(new Paragraph(totalNettoDelivery.Sum().ToString())));
            table.AddCell(new Cell().Add(new Paragraph(totalTaxDelivery.Sum().ToString())));
            table.AddCell(new Cell().Add(new Paragraph(totalBruttoDelivery.Sum().ToString())));

            return table;
        }
    }
}
