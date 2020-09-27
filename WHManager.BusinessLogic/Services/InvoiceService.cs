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
        private IOrderService _orderService = new OrderService();
        private IClientService _clientService = new ClientService();
        public async Task CreateNewInvoice(Invoice invoice)
        {
            try
            {
                int id = invoice.Id;
                DateTime dateTime = invoice.DateIssued;
                int clientId = invoice.Client.Id;
                int orderId = invoice.Order.Id;
                await _invoiceRepository.CreateNewInvoiceAsync(id, dateTime, clientId, orderId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteInvoice(int id)
        {
            try
            {
                await _invoiceRepository.DeleteInvoiceAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Invoice GetInvoiceById(int id)
        {
            try
            {
                var invoice = _invoiceRepository.GetInvoice(id);
                Invoice currentInvoice = new Invoice
                {
                    Id = invoice.Id,
                    DateIssued = invoice.DateIssued,
                    Client = _clientService.GetClient(invoice.Client.Id),
                    Order = _orderService.GetOrderById(invoice.Order.Id)
                };
                return currentInvoice;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Invoice GetInvoiceByOrder(int orderId)
        {
            try
            {
                var invoice = _invoiceRepository.GetInvoiceByOrder(orderId);
                Invoice currentInvoice = new Invoice
                {
                    Id = invoice.Id,
                    DateIssued = invoice.DateIssued,
                    Client = _clientService.GetClient(invoice.Client.Id),
                    Order = _orderService.GetOrderById(invoice.Order.Id)
                };
                return currentInvoice;
            }
            catch (Exception)
            {
                throw;
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
                    Invoice currentInvoice = new Invoice
                    {
                        Id = invoice.Id,
                        DateIssued = invoice.DateIssued,
                        Client = _clientService.GetClient(invoice.Client.Id),
                        Order = _orderService.GetOrderById(invoice.Order.Id)
                    };
                    invoicesList.Add(currentInvoice);
                }
                return invoicesList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Invoice> GetInvoicesByClient(int? clientId = null, string clientName = null, double? clientNip = null)
        {
            if (clientId != null)
            {
                IList<Invoice> invoicesList = new List<Invoice>();
                var invoices = _invoiceRepository.GetInvoicesByClient(clientId);
                foreach (var invoice in invoices)
                {
                    Invoice currentInvoice = new Invoice
                    {
                        Id = invoice.Id,
                        DateIssued = invoice.DateIssued,
                        Client = _clientService.GetClient(invoice.Client.Id),
                        Order = _orderService.GetOrderById(invoice.Order.Id)
                    };
                    invoicesList.Add(currentInvoice);
                }
                return invoicesList;
            }
            else if (clientName != null)
            {
                IList<Invoice> invoicesList = new List<Invoice>();
                var invoices = _invoiceRepository.GetInvoicesByClient(null, clientName, null);
                foreach (var invoice in invoices)
                {
                    Invoice currentInvoice = new Invoice
                    {
                        Id = invoice.Id,
                        DateIssued = invoice.DateIssued,
                        Client = _clientService.GetClient(invoice.Client.Id),
                        Order = _orderService.GetOrderById(invoice.Order.Id)
                    };
                    invoicesList.Add(currentInvoice);
                }
                return invoicesList;
            }
            else if (clientNip != null)
            {
                IList<Invoice> invoicesList = new List<Invoice>();
                var invoices = _invoiceRepository.GetInvoicesByClient(null, null, clientNip);
                foreach (var invoice in invoices)
                {
                    Invoice currentInvoice = new Invoice
                    {
                        Id = invoice.Id,
                        DateIssued = invoice.DateIssued,
                        Client = _clientService.GetClient(invoice.Client.Id),
                        Order = _orderService.GetOrderById(invoice.Order.Id)
                    };
                    invoicesList.Add(currentInvoice);
                }
                return invoicesList;
            }

            else
            {
                return null;
            }
        }

        public async Task UpdateInvoice(Invoice invoice)
        {
            try
            {
                int id = invoice.Id;
                DateTime dateTime = invoice.DateIssued;
                int clientId = invoice.Client.Id;
                int orderId = invoice.Order.Id;
                await _invoiceRepository.UpdateInvoiceAsync(id, dateTime, clientId, orderId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
