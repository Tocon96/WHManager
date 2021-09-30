using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;
using iText.Kernel.Geom;
using iText.Kernel.Font;
using iText.IO.Font;
using iText.Layout.Borders;
using System.Linq;

namespace WHManager.BusinessLogic.Services
{
    public class IncomingDocumentService : IIncomingDocumentService
    {
        IIncomingDocumentRepository incomingDocumentRepository = new IncomingDocumentRepository(new DataAccess.WHManagerDBContextFactory());
        IProviderService providerService = new ProviderService();
        IProductService productService = new ProductService();

        public int AddDocument(IncomingDocument document)
        {
            return incomingDocumentRepository.AddDocument(document.Provider.Id, document.DateReceived, document.DeliveryId);
        }

        public void DeleteDocument(int id)
        {
            incomingDocumentRepository.DeleteDocument(id);
        }

        public IncomingDocument GetDocument(int id)
        {
            var document = incomingDocumentRepository.GetDocumentById(id);
            IncomingDocument incomingDocument = new IncomingDocument()
            {
                Id = document.Id,
                Provider = providerService.GetProvider(document.Provider.Id),
                DateReceived = document.DateReceived,
            };
            return incomingDocument;
        }

        public IList<IncomingDocument> GetDocuments()
        {
            IList<IncomingDocument> documentsList = new List<IncomingDocument>();
            var documents = incomingDocumentRepository.GetDocuments();
            foreach(var document in documents)
            {
                IncomingDocument newDocument = new IncomingDocument
                {
                    Id = document.Id,
                    Provider = providerService.GetProvider(document.Provider.Id),
                    DateReceived = document.DateReceived,
                };
                documentsList.Add(newDocument);
            }
            return documentsList;
        }

        public IList<IncomingDocument> SearchDocuments(IList<string> criteria)
        {
            throw new NotImplementedException();
        }

        public IncomingDocument GetDocumentByDeliveryId(int deliveryId)
        {
            var document = incomingDocumentRepository.GetDocumentByDeliveryId(deliveryId);
            IncomingDocument incomingDocument = new IncomingDocument()
            {
                Id = document.Id,
                Provider = providerService.GetProvider(document.Provider.Id),
                DateReceived = document.DateReceived,
            };
            return incomingDocument;
        }

        public int UpdateDocumnet(IncomingDocument document)
        {
            return incomingDocumentRepository.UpdateDocument(document.Id, document.Provider.Id, document.DateReceived, document.DeliveryId);
        }

        public void GeneratePdf(string fileName, Delivery delivery)
        {
            IncomingDocument incomingDocument = this.GetDocumentByDeliveryId(delivery.Id);
            FontProgram fontProgram = FontProgramFactory.CreateFont();
            PdfFont font = PdfFontFactory.CreateFont(fontProgram, "CP1257");
            PdfWriter writer = new PdfWriter(fileName);
            PdfDocument pdf = new PdfDocument(writer);
            pdf.SetDefaultPageSize(PageSize.A4.Rotate());
            Document document = new Document(pdf);
            document.SetFont(font);
            Table initialTable = GenerateInitialTable(incomingDocument);
            Table providerTable = GenerateProviderTable(delivery.Provider);
            Table itemTable = GenerateItemTable(delivery);
            document.Add(initialTable);
            document.Add(providerTable);
            document.Add(itemTable);
            document.Close();

        }

        Table GenerateInitialTable(IncomingDocument document)
        {
            
            Table table = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth().SetHeight(100);
            table.AddCell(new Cell());
            table.AddCell(new Cell()
                              .Add(new Paragraph("Przyjęcie zewnętrzne")
                                       .SetTextAlignment(TextAlignment.CENTER)
                                       .SetFontSize(20)
                                       .SetBold())
                              .SetVerticalAlignment(VerticalAlignment.MIDDLE));
            table.AddCell(new Cell()
                                .Add(new Table(2)
                                            .AddCell(new Paragraph("Numer dokumentu: "))
                                            .AddCell(new Paragraph(document.Id.ToString()))
                                            .AddCell(new Paragraph("Data wystawienia"))
                                            .AddCell(new Paragraph(document.DateReceived.ToShortDateString())))
                                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                                .SetHorizontalAlignment(HorizontalAlignment.CENTER));
            return table;
        }

        Table GenerateProviderTable(Provider provider)
        {
            
            Table table = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();
            table.AddHeaderCell(new Cell(1, 2).Add(new Paragraph("Dostawca").SetTextAlignment(TextAlignment.CENTER).SetBold().SetFontSize(14)));
            table.AddCell(new Cell().Add(new Paragraph("Nazwa: ")));
            table.AddCell(new Cell().Add(new Paragraph(provider.Name)));
            table.AddCell(new Cell().Add(new Paragraph("NIP: ")));
            table.AddCell(new Cell().Add(new Paragraph(provider.Nip.ToString())));
            table.AddCell(new Cell().Add(new Paragraph("Numer telefonu: ")));
            table.AddCell(new Cell().Add(new Paragraph(provider.PhoneNumber)));
            return table;
        }

        Table GenerateItemTable(Delivery delivery)   
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

            var grouped = delivery.Items.OrderBy(x => x.Product.Id).GroupBy(x => x.Product.Id);
            int enumerator = 1;
            IList<decimal> totalNettoDelivery = new List<decimal>();
            IList<decimal> totalTaxDelivery = new List<decimal>();
            IList<decimal> totalBruttoDelivery = new List<decimal>();

            foreach (var group in grouped)
            {
                Product product = productService.GetProduct(group.Key)[0];
                table.AddCell(new Cell().Add(new Paragraph(enumerator.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(product.Name)));
                int itemCount = delivery.Items.Count(x => x.Product.Id == group.Key);
                table.AddCell(new Cell().Add(new Paragraph(itemCount.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(product.PriceBuy.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(product.Tax.Value.ToString())));
                decimal totalNetto = Math.Round(itemCount * product.PriceBuy, 2);
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