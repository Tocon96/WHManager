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
        public async Task<Invoice> CreateNewInvoiceAsync(int id, DateTime dateIssued, int clientId, int orderId)
        {
            using(WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Invoice invoice = new Invoice
                    {
                        DateIssued = dateIssued,
                        Client = context.Clients.SingleOrDefault(x => x.Id == clientId),
                        Order = context.Orders.SingleOrDefault(x => x.Id == orderId)
                    };
                    await context.Invoices.AddAsync(invoice);
                    await context.SaveChangesAsync();
                    return invoice;
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }
        public async Task UpdateInvoiceAsync(int id, DateTime dateIssued, int clientId, int orderId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Invoice updatedInvoice = context.Invoices.SingleOrDefault(x => x.Id == id);
                    updatedInvoice.DateIssued = dateIssued;
                    updatedInvoice.Client = context.Clients.SingleOrDefault(x => x.Id == clientId);
                    updatedInvoice.Order = context.Orders.SingleOrDefault(x => x.Id == orderId);
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.Remove(await context.Invoices.SingleOrDefaultAsync(x => x.Id == id));
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
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
                    throw;
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
                    throw;
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
                    throw;
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
                        throw;
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
                        throw;
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
                        throw;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        
    }
}
