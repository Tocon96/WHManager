using System;
using System.Collections.Generic;
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
        private IOrderService orderService = new OrderService();
        private IClientService clientService = new ClientService();
        public void CreateNewInvoice(Invoice invoice)
        {
            try
            {
                int id = invoice.Id;
                DateTime dateTime = invoice.DateIssued;
                int clientId = invoice.Client.Id;
                int orderId = invoice.Order.Id;
                _invoiceRepository.CreateNewInvoice(id, dateTime, clientId, orderId);
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
                    Order = orderService.GetOrderById(invoice.Order.Id)
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
                    Order = orderService.GetOrderById(invoice.Order.Id)
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
                        Order = orderService.GetOrderById(invoice.Order.Id)
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

        public IList<Invoice> GetInvoicesByClient(int? clientId = null, string clientName = null, double? clientNip = null)
        {
            if (clientId != null)
            {
                try
                {
                    IList<Invoice> invoicesList = new List<Invoice>();
                    var invoices = _invoiceRepository.GetInvoicesByClient(clientId);
                    foreach (var invoice in invoices)
                    {
                        IList<Client> clients = clientService.GetClient(invoice.Client.Id);
                        Client client = clients[0];
                        Invoice currentInvoice = new Invoice
                        {
                            Id = invoice.Id,
                            DateIssued = invoice.DateIssued,
                            Client = client,
                            Order = orderService.GetOrderById(invoice.Order.Id)
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
            else if (clientName != null)
            {
                try
                {
                    IList<Invoice> invoicesList = new List<Invoice>();
                    var invoices = _invoiceRepository.GetInvoicesByClient(null, clientName, null);
                    foreach (var invoice in invoices)
                    {
                        IList<Client> clients = clientService.GetClient(invoice.Client.Id);
                        Client client = clients[0];
                        Invoice currentInvoice = new Invoice
                        {
                            Id = invoice.Id,
                            DateIssued = invoice.DateIssued,
                            Client = client,
                            Order = orderService.GetOrderById(invoice.Order.Id)
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
            else if (clientNip != null)
            {
                try
                {
                    IList<Invoice> invoicesList = new List<Invoice>();
                    var invoices = _invoiceRepository.GetInvoicesByClient(null, null, clientNip);
                    foreach (var invoice in invoices)
                    {
                        IList<Client> clients = clientService.GetClient(invoice.Client.Id);
                        Client client = clients[0];
                        Invoice currentInvoice = new Invoice
                        {
                            Id = invoice.Id,
                            DateIssued = invoice.DateIssued,
                            Client = client,
                            Order = orderService.GetOrderById(invoice.Order.Id)
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
            else
            {
                throw new Exception("Błąd pobierania faktur: ");
            }
        }

        public IList<Invoice> GetInvoicesByDate(DateTime? earlierDate, DateTime? laterDate)
        {
            if (earlierDate != null && laterDate != null)
            {
                try
                {
                    IList<Invoice> invoicesList = new List<Invoice>();
                    var invoices = _invoiceRepository.GetInvoicesByDate(earlierDate, laterDate);

                    foreach (var invoice in invoices)
                    {
                        IList<Client> clients = clientService.GetClient(invoice.Client.Id);
                        Client client = clients[0];
                        Invoice currentInvoice = new Invoice
                        {
                            Id = invoice.Id,
                            DateIssued = invoice.DateIssued,
                            Client = client,
                            Order = orderService.GetOrderById(invoice.Order.Id)
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
            else if(earlierDate != null && laterDate == null)
            {
                try
                {
                    IList<Invoice> invoicesList = new List<Invoice>();
                    var invoices = _invoiceRepository.GetInvoicesByDate(earlierDate, null);
                    foreach (var invoice in invoices)
                    {
                        IList<Client> clients = clientService.GetClient(invoice.Client.Id);
                        Client client = clients[0];
                        Invoice currentInvoice = new Invoice
                        {
                            Id = invoice.Id,
                            DateIssued = invoice.DateIssued,
                            Client = client,
                            Order = orderService.GetOrderById(invoice.Order.Id)
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
            else if(earlierDate == null && laterDate != null)
            {
                try
                {
                    IList<Invoice> invoicesList = new List<Invoice>();
                    var invoices = _invoiceRepository.GetInvoicesByDate(null, laterDate);
                    foreach (var invoice in invoices)
                    {
                        IList<Client> clients = clientService.GetClient(invoice.Client.Id);
                        Client client = clients[0];
                        Invoice currentInvoice = new Invoice
                        {
                            Id = invoice.Id,
                            DateIssued = invoice.DateIssued,
                            Client = client,
                            Order = orderService.GetOrderById(invoice.Order.Id)
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
            else
            {
                try
                {
                    IList<Invoice> invoicesList = new List<Invoice>();
                    var invoices = _invoiceRepository.GetInvoicesByDate(null, null);
                    foreach (var invoice in invoices)
                    {
                        IList<Client> clients = clientService.GetClient(invoice.Client.Id);
                        Client client = clients[0];
                        Invoice currentInvoice = new Invoice
                        {
                            Id = invoice.Id,
                            DateIssued = invoice.DateIssued,
                            Client = client,
                            Order = orderService.GetOrderById(invoice.Order.Id)
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
        }

        public void UpdateInvoice(Invoice invoice)
        {
            try
            {
                int id = invoice.Id;
                DateTime dateTime = invoice.DateIssued;
                int clientId = invoice.Client.Id;
                int orderId = invoice.Order.Id;
                _invoiceRepository.UpdateInvoice(id, dateTime, clientId, orderId);
            }
            catch (Exception)
            {
                throw new Exception("Błąd aktualizacji faktury: ");
            }
        }
    }
}
