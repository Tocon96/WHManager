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
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.DocumentServices;
using WHManager.BusinessLogic.Services.DocumentServices.Interfaces;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository = new InvoiceRepository(new DataAccess.WHManagerDBContextFactory());
        private IClientService clientService = new ClientService();
        private IProductService productService = new ProductService();
        IDocumentDataService dataService = new DocumentDataService();
        public int CreateNewInvoice(Invoice invoice)
        {
            try
            {
                DateTime dateTime = invoice.DateIssued;
                int clientId = invoice.Client.Id;
                int orderId = invoice.OrderId;
                int invoiceId = _invoiceRepository.CreateNewInvoice(dateTime, clientId, orderId);
                return invoiceId;
            }
            catch
            {
                throw new Exception("Błąd dodawania faktury: ");
            }
        }

        public void DeleteInvoice(int id)
        {
            try
            {
                _invoiceRepository.DeleteInvoice(id);
            }
            catch
            {
                throw new Exception("Błąd usuwania faktury: ");
            }
        }

        public Invoice GetInvoiceById(int id)
        {
            try
            {
                
                var invoice = _invoiceRepository.GetInvoice(id);
                IList<Client> clients = clientService.GetClient(invoice.Client.Id);
                Client client = clients[0]; 
                Invoice currentInvoice = new Invoice
                {
                    Id = invoice.Id,
                    DateIssued = invoice.DateIssued,
                    Client = client,
                    OrderId = invoice.OrderId
                };
                return currentInvoice;
            }
            catch
            {
                throw new Exception("Błąd pobierania faktury: ");
            }
        }

        public Invoice GetInvoiceByOrder(int orderId)
        {
            try
            {
                var invoice = _invoiceRepository.GetInvoiceByOrder(orderId);
                IList<Client> clients = clientService.GetClient(invoice.Client.Id);
                Client client = clients[0];
                Invoice currentInvoice = new Invoice
                {
                    Id = invoice.Id,
                    DateIssued = invoice.DateIssued,
                    Client = client,
                    OrderId = invoice.OrderId
                };
                return currentInvoice;
            }
            catch
            {
                throw new Exception("Błąd pobierania faktur: ");
            }
            
        }

        public IList<Invoice> GetInvoices()
        {
            try
            {
                IList<Invoice> invoicesList = new List<Invoice>();
                var invoices = _invoiceRepository.GetAllInvoices();
                foreach (var invoice in invoices)
                {
                    IList<Client> clients = clientService.GetClient(invoice.Client.Id);
                    Client client = clients[0];
                    Invoice currentInvoice = new Invoice
                    {
                        Id = invoice.Id,
                        DateIssued = invoice.DateIssued,
                        Client = client,
                        OrderId = invoice.OrderId
                    };
                    invoicesList.Add(currentInvoice);
                }
                return invoicesList;
            }
            catch
            {
                throw new Exception("Błąd pobierania faktur: ");
            }
        }

        public void UpdateInvoice(Invoice invoice)
        {
            try
            {
                int id = invoice.Id;
                DateTime dateTime = invoice.DateIssued;
                int clientId = invoice.Client.Id;
                int orderId = invoice.OrderId;
                _invoiceRepository.UpdateInvoice(id, dateTime, clientId, orderId);
            }
            catch (Exception)
            {
                throw new Exception("Błąd aktualizacji faktury: ");
            }
        }

        public IList<Invoice>SearchInvoices(List<string> criteria)
        {
            try
            {
                IList<Invoice> invoices = new List<Invoice>();
                var invoiceList = _invoiceRepository.SearchInvoices(criteria);
                foreach(var invoice in invoiceList)
                {
                    Invoice newInvoice = new Invoice
                    {
                        Id = invoice.Id,
                        Client = clientService.GetClient(invoice.Client.Id)[0],
                        DateIssued = invoice.DateIssued,
                        OrderId = invoice.OrderId
                    };
                    invoices.Add(newInvoice);
                }
                return invoices;
            }
            catch
            {
                throw new Exception();
            }
        }

        public void GeneratePdf(string filename, Order order)
        {
            Invoice invoice = GetInvoiceByOrder(order.Id);
            FontProgram fontProgram = FontProgramFactory.CreateFont();
            PdfFont font = PdfFontFactory.CreateFont(fontProgram, "CP1257");
            PdfWriter writer = new PdfWriter(filename);
            PdfDocument pdf = new PdfDocument(writer);
            pdf.SetDefaultPageSize(PageSize.A4);
            Document document = new Document(pdf);
            document.SetFont(font);
            IList<DocumentData> documentData = dataService.GetRecordsByDocument(invoice.Id, "Invoice");
            if(documentData.Count > 0)
            {
                Table initialTable = GenerateInitialTable(documentData[0]);
                Table clientTable = GenerateClientTable(documentData[0]);
                Table itemTable = GenerateItemTable(documentData);
                Table signatureTable = GenerateSignatureTable();
                document.Add(initialTable);
                document.Add(clientTable);
                document.Add(itemTable);
                document.Add(new Paragraph("").SetHeight(50));
                document.Add(signatureTable);
                document.Close();
            }
        }

        Table GenerateInitialTable(DocumentData documentData)
        {

            Table table = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth().SetHeight(100);
            table.AddCell(new Cell());
            table.AddCell(new Cell()
                              .Add(new Paragraph("Faktura")
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

        Table GenerateClientTable(DocumentData documentData)
        {

            IConfigService configService = new ConfigService();
            IList<Config> companyData = configService.GetCompanyData();

            Table table = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();
            table.AddCell(new Cell().SetBorder(iText.Layout.Borders.Border.NO_BORDER).Add(new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth()
                                                .AddHeaderCell(new Cell(1, 2).Add(new Paragraph("Sprzedający").SetTextAlignment(TextAlignment.CENTER).SetBold().SetFontSize(14)))
                                                .AddCell(new Cell().Add(new Paragraph("Nazwa: ")))
                                                .AddCell(new Cell().Add(new Paragraph(companyData.First(x => x.Field.StartsWith("CompanyName")).Value)))
                                                .AddCell(new Cell().Add(new Paragraph("NIP: ")))
                                                .AddCell(new Cell().Add(new Paragraph(companyData.First(x => x.Field.StartsWith("CompanyNip")).Value)))
                                                .AddCell(new Cell().Add(new Paragraph("Numer telefonu: ")))
                                                .AddCell(new Cell().Add(new Paragraph(companyData.First(x => x.Field.StartsWith("CompanyPhoneNumber")).Value)))));
            table.AddCell(new Cell().SetBorder(iText.Layout.Borders.Border.NO_BORDER).Add(new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth()
                                                .AddHeaderCell(new Cell(1, 2).Add(new Paragraph("Kupujący").SetTextAlignment(TextAlignment.CENTER).SetBold().SetFontSize(14)))
                                                .AddCell(new Cell().Add(new Paragraph("Nazwa: ")))
                                                .AddCell(new Cell().Add(new Paragraph(documentData.ContrahentName)))
                                                .AddCell(new Cell().Add(new Paragraph("NIP: ")))
                                                .AddCell(new Cell().Add(new Paragraph(documentData.ContrahentNip.ToString())))
                                                .AddCell(new Cell().Add(new Paragraph("Numer telefonu: ")))
                                                .AddCell(new Cell().Add(new Paragraph(documentData.ContrahentPhoneNumber)))));
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


        Table GenerateSignatureTable()
        {
            Table table = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();
            table.AddCell(new Cell().SetBorder(iText.Layout.Borders.Border.NO_BORDER).Add(new Paragraph("............................................................................").SetTextAlignment(TextAlignment.CENTER)));
            table.AddCell(new Cell().SetBorder(iText.Layout.Borders.Border.NO_BORDER).Add(new Paragraph("............................................................................").SetTextAlignment(TextAlignment.CENTER)));
            table.AddCell(new Cell().SetBorder(iText.Layout.Borders.Border.NO_BORDER).Add(new Paragraph("Podpis osoby wystawiającej").SetTextAlignment(TextAlignment.CENTER)));
            table.AddCell(new Cell().SetBorder(iText.Layout.Borders.Border.NO_BORDER).Add(new Paragraph("Podpis osoby odbierającej").SetTextAlignment(TextAlignment.CENTER)));
            return table;
        }

    }
}