using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public OrderRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Order> AddOrderAsync(int id, decimal price, DateTime dateOrdered, IList<int> items, int clientId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    ICollection<Item> itemCollection = new ObservableCollection<Item>();
                    foreach(int i in items)
                    {
                        Item item = context.Items.SingleOrDefault(x => x.Id == i);
                        itemCollection.Add(item);
                    };
                    Order order = new Order
                    {
                        Items = itemCollection,
                        Price = price,
                        DateOrdered = dateOrdered,
                        Client = context.Clients.SingleOrDefault(x => x.Id == clientId),
                    };
                    await context.Orders.AddAsync(order);
                    await context.SaveChangesAsync();
                    return order;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task UpdateOrderAsync(int id, DateTime dateOrdered, IList<int> items, decimal price, int clientId, int? invoiceId = null)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    ICollection<Item> itemCollection = new ObservableCollection<Item>();
                    foreach (int i in items)
                    {
                        Item item = context.Items.SingleOrDefault(x => x.Id == i);
                        itemCollection.Add(item);
                    };
                    Order updatedOrder = context.Orders.SingleOrDefault(x => x.Id == id);
                    updatedOrder.Client = context.Clients.SingleOrDefault(x => x.Id == clientId);
                    updatedOrder.DateOrdered = dateOrdered;
                    updatedOrder.Items = itemCollection;
                    updatedOrder.Price = price;
                    if(invoiceId != null)
                    {
                        updatedOrder.Invoice = context.Invoices.SingleOrDefault(x => x.Id == invoiceId);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task DeleteOrderAsync(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.Remove(await context.Orders.SingleOrDefaultAsync(x => x.Id == id));
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<Order> orders = context.Orders
                                                            .Include(c => c.Client)
                                                            .ToList();
                    return orders;
                }
                catch(Exception)
                {
                    throw;
                }
            } 
        }

        public IEnumerable<Order> GetOrdersByClient(int? clientId = null, string clientName = null, double? clientNip = null)
        {
            if (clientId != null)
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    try
                    {
                        IEnumerable<Order> orders = context.Orders.Include(c => c.Client)
                                                                    .ToList()
                                                                    .FindAll(c => c.Client.Id == clientId);
                        return orders;
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
                        IEnumerable<Order> orders = context.Orders.Include(c => c.Client)
                                                                    .ToList()
                                                                    .FindAll(c => c.Client.Name.StartsWith(clientName));
                        return orders;
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
                        IEnumerable<Order> orders = context.Orders.Include(c => c.Client)
                                                                    .ToList()
                                                                    .FindAll(c => c.Client.Nip == clientNip);
                        return orders;
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

        public Order GetOrderById(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Order order = context.Orders.Include(c => c.Client)
                                                                .ToList()
                                                                .SingleOrDefault(c => c.Id == id);
                    return order;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public Order GetOrderByInvoice(int invoiceId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Order order = context.Orders.Include(c => c.Client)
                                                                .ToList()
                                                                .SingleOrDefault(c => c.Invoice.Id == invoiceId);
                    return order;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
