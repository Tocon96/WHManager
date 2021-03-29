using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public InvoiceRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void CreateNewInvoice(int id, DateTime dateIssued, int clientId, int orderId)
        {
            using(WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Order order = context.Orders.SingleOrDefault(x => x.Id == orderId);
                    Invoice invoice = new Invoice
                    {
                        DateIssued = dateIssued,
                        Client = context.Clients.SingleOrDefault(x => x.Id == clientId),
                        Order = context.Orders.SingleOrDefault(x => x.Id == orderId),
                        OrderId = order.Id
                    };
                    context.Invoices.Add(invoice);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd dodawania faktury: ");
                }
            }
        }
        public void UpdateInvoice(int id, DateTime dateIssued, int clientId, int orderId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Order order = context.Orders.SingleOrDefault(x => x.Id == orderId);
                    Invoice updatedInvoice = context.Invoices.SingleOrDefault(x => x.Id == id);
                    updatedInvoice.DateIssued = dateIssued;
                    updatedInvoice.Client = context.Clients.SingleOrDefault(x => x.Id == clientId);
                    updatedInvoice.Order = context.Orders.SingleOrDefault(x => x.Id == orderId);
                    updatedInvoice.OrderId = order.Id;
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new Exception("Błąd aktualizacji faktury: ");
                }
            }
        }

        public void DeleteInvoice(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.Remove(context.Invoices.SingleOrDefault(x => x.Id == id));
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new Exception("Błąd usuwania faktury: ");
                }
            }
        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<Invoice> invoices = context.Invoices.Include(o => o.Order)
                                                                    .Include(c => c.Client)
                                                                    .ToList();
                    return invoices;
                }
                catch (Exception)
                {
                    throw new Exception("Błąd pobierania faktur: ");
                }
            }
        }

        public Invoice GetInvoice(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Invoice invoice = context.Invoices.Include(o => o.Order)
                                                      .Include(c => c.Client)
                                                      .SingleOrDefault(x => x.Id == id);
                    return invoice;
                }
                catch (Exception)
                {
                    throw new Exception("Błąd pobierania faktury: ");
                }
            }
        }

        public Invoice GetInvoiceByOrder(int orderId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Invoice invoice = context.Invoices.Include(o => o.Order)
                                              .Include(c => c.Client)
                                              .SingleOrDefault(x => x.Order.Id == orderId);
                    return invoice;
                }
                catch (Exception)
                {
                    throw new Exception("Błąd pobierania faktur: ");
                }
            }  
        }

        public IEnumerable<Invoice> GetInvoicesByClient(int? clientId = null, string clientName = null, double? clientNip = null)
        {
            if(clientId != null)
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    try
                    {
                        IEnumerable<Invoice> invoices = context.Invoices.Include(o => o.Order)
                                                                        .Include(c => c.Client)
                                                                        .ToList()
                                                                        .FindAll(x => x.Client.Id == clientId);
                        return invoices;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Błąd pobierania faktur: ");
                    }
                }
            }
            else if(clientName != null)
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    try
                    {
                        IEnumerable<Invoice> invoices = context.Invoices.Include(o => o.Order)
                                                                        .Include(c => c.Client)
                                                                        .ToList()
                                                                        .FindAll(x => x.Client.Name.StartsWith(clientName));
                        return invoices;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Błąd pobierania faktur: ");
                    }
                }
            }
            else if(clientNip != null)
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    try
                    {
                        IEnumerable<Invoice> invoices = context.Invoices.Include(o => o.Order)
                                                                        .Include(c => c.Client)
                                                                        .ToList()
                                                                        .FindAll(x => x.Client.Nip == clientNip);
                        return invoices;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Błąd pobierania faktur: ");
                    }
                }
            }
            else
            {
                throw new Exception("Błąd pobierania faktur: ");
            }
        }

        public IEnumerable<Invoice> GetInvoicesByDate(DateTime? earlierDate, DateTime? laterDate)
        {
            if (earlierDate != null && laterDate != null)
            {
                try
                {
                    using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                    {
                        IEnumerable<Invoice> invoices = context.Invoices.Include(o => o.Order)
                                                                        .Include(c => c.Client)
                                                                        .ToList().FindAll(x => x.DateIssued >= earlierDate && x.DateIssued <= laterDate);
                        return invoices;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Błąd pobierania faktur: ");
                }
            }
            else if (earlierDate != null && laterDate == null)
            {
                try
                {
                    using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                    {
                        IEnumerable<Invoice> invoices = context.Invoices.Include(o => o.Order)
                                                                        .Include(c => c.Client)
                                                                        .ToList()
                                                                        .FindAll(x => x.DateIssued >= earlierDate);
                        return invoices;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Błąd pobierania faktur: ");
                }
            }
            else if (earlierDate == null && laterDate != null)
            {
                try
                {
                    using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                    {
                        IEnumerable<Invoice> invoices = context.Invoices.Include(c => c.Client)
                                                                        .Include(o => o.Order)
                                                                        .ToList()
                                                                        .FindAll(x => x.DateIssued <= laterDate);
                        return invoices;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Błąd pobierania faktur: ");
                }
            }
            else if (earlierDate == null && laterDate == null)
            {
                try
                {
                    using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                    {
                        IEnumerable<Invoice> invoices = context.Invoices.Include(c => c.Client)
                                                                        .Include(o => o.Order)
                                                                        .ToList()
                                                                        .FindAll(x => x.DateIssued <= laterDate);
                        return invoices;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Błąd pobierania faktur: ");
                }
            }
            else
            {
                throw new Exception("Błąd pobierania faktur: ");
            }
        }
    }
}
