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
        IDocumentDataService dataService = new DocumentDataService();


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
            var document = outgoingDocumentRepository.GetDocumentByOrderId(orderId);
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
            IList<DocumentData> documentData = dataService.GetRecordsByDocument(outgoingDocument.Id, "OutgoingDocument");
            Table initialTable = GenerateInitialTable(documentData[0]);
            Table providerTable = GenerateProviderTable(documentData[0]);
            Table itemTable = GenerateItemTable(documentData);
            document.Add(initialTable);
            document.Add(providerTable);
            document.Add(itemTable);
            document.Close();

        }

        Table GenerateInitialTable(DocumentData documentData)
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
                                            .AddCell(new Paragraph(documentData.DocumentId.ToString()))
                                            .AddCell(new Paragraph("Data realizacji"))
                                            .AddCell(new Paragraph(documentData.DocumentDate.ToShortDateString())))
                                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                                .SetHorizontalAlignment(HorizontalAlignment.CENTER));
            return table;
        }

        Table GenerateProviderTable(DocumentData documentData)
        {

            Table table = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();
            table.AddHeaderCell(new Cell(1, 2).Add(new Paragraph("Klient").SetTextAlignment(TextAlignment.CENTER).SetBold().SetFontSize(14)));
            table.AddCell(new Cell().Add(new Paragraph("Nazwa: ")));
            table.AddCell(new Cell().Add(new Paragraph(documentData.ContrahentName)));
            table.AddCell(new Cell().Add(new Paragraph("NIP: ")));
            table.AddCell(new Cell().Add(new Paragraph(documentData.ContrahentNip.ToString())));
            table.AddCell(new Cell().Add(new Paragraph("Numer telefonu: ")));
            table.AddCell(new Cell().Add(new Paragraph(documentData.ContrahentPhoneNumber)));
            return table;
        }

        Table GenerateItemTable(IList<DocumentData> documentData)
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

            int enumerator = 1;
            IList<decimal> totalNettoDelivery = new List<decimal>();
            IList<decimal> totalTaxDelivery = new List<decimal>();
            IList<decimal> totalBruttoDelivery = new List<decimal>();

            foreach (DocumentData data in documentData)
            {
                totalNettoDelivery.Add(data.NetValue);
                totalTaxDelivery.Add(data.TaxValue);
                totalBruttoDelivery.Add(data.GrossValue);

                table.AddCell(new Cell().Add(new Paragraph(enumerator.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(data.ProductName)));
                table.AddCell(new Cell().Add(new Paragraph(data.ProductCount.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(data.ProductPrice.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(data.TaxType.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(data.NetValue.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(data.TaxValue.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(data.GrossValue.ToString())));
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