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
            Invoice invoice = GetInvoiceById(order.Id);
            FontProgram fontProgram = FontProgramFactory.CreateFont();
            PdfFont font = PdfFontFactory.CreateFont(fontProgram, "CP1257");
            PdfWriter writer = new PdfWriter(filename);
            PdfDocument pdf = new PdfDocument(writer);
            pdf.SetDefaultPageSize(PageSize.A4.Rotate());
            Document document = new Document(pdf);
            document.SetFont(font);
            Table initialTable = GenerateInitialTable(invoice);
            Table providerTable = GenerateProviderTable(order.Client);
            Table itemTable = GenerateItemTable(order);
            document.Add(initialTable);
            document.Add(providerTable);
            document.Add(itemTable);
            document.Close();
        }

        Table GenerateInitialTable(Invoice invoice)
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
                                            .AddCell(new Paragraph(invoice.Id.ToString()))
                                            .AddCell(new Paragraph("Data realizacji"))
                                            .AddCell(new Paragraph(invoice.DateIssued.ToShortDateString())))
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