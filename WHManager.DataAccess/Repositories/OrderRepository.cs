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

        public int AddOrder(decimal price, DateTime dateOrdered, int clientId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Order order = new Order
                    {
                        Price = price,
                        DateOrdered = dateOrdered,
                        Client = context.Clients.SingleOrDefault(x => x.Id == clientId),
                    };
                    context.Orders.Add(order);
                    context.SaveChanges();
                    return order.Id;
                }
                catch
                {
                    throw new Exception("Błąd dodawania zamówienia: ");
                }
            }
        }

        public void UpdateOrder(int id, DateTime dateOrdered, decimal price, int clientId, int? invoiceId = null)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Order updatedOrder = context.Orders.SingleOrDefault(x => x.Id == id);
                    updatedOrder.Client = context.Clients.SingleOrDefault(x => x.Id == clientId);
                    updatedOrder.DateOrdered = dateOrdered;
                    updatedOrder.Price = price;
                    if(invoiceId != null)
                    {
                        updatedOrder.Invoice = context.Invoices.SingleOrDefault(x => x.Id == invoiceId);
                        context.SaveChanges();
                    }
                    else
                    {
                        context.SaveChanges();
                    }
                }
                catch
                {
                    throw new Exception("Błąd aktualizacji zamówienia o ID: "+id+" : ");
                }
            }
        }

        public void DeleteOrder(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.Remove(context.Orders.SingleOrDefault(x => x.Id == id));
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd usuwania zamówienia o ID: " + id + " : ");
                }
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<Order> orders = context.Orders.Include(c => c.Client)
                                                              .Include(i => i.Items)
                                                              .ToList();

                    return orders;
                }
                catch
                {
                    throw new Exception("Błąd pobierania zamówień: ");
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
                                                                    .Include(i => i.Items)
                                                                    .ToList()
                                                                    .FindAll(c => c.Client.Id == clientId);
                        return orders;
                    }
                    catch
                    {
                        throw new Exception("Błąd pobierania zamówień: ");
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
                                                                  .Include(i => i.Items)
                                                                  .ToList()
                                                                  .FindAll(c => c.Client.Name.StartsWith(clientName));
                        return orders;
                    }
                    catch
                    {
                        throw new Exception("Błąd pobierania zamówień: ");
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
                                                                  .Include(i => i.Items)
                                                                  .ToList()
                                                                  .FindAll(c => c.Client.Nip == clientNip);
                        return orders;
                    }
                    catch
                    {
                        throw new Exception("Błąd pobierania zamówień: ");
                    }
                }
            }
            else
            {
                throw new Exception("Błąd pobierania zamówień: ");
            }
        }

        public Order GetOrderById(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Order order = context.Orders.Include(c => c.Client)
                                                .Include(i => i.Items)  
                                                .ToList()
                                                .SingleOrDefault(c => c.Id == id);
                    return order;
                }
                catch
                {
                    throw new Exception("Błąd pobierania zamówień: ");
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
                                                .Include(i => i.Items)
                                                .ToList()
                                                .SingleOrDefault(c => c.Invoice.Id == invoiceId);
                    return order;
                }
                catch 
                {
                    throw new Exception("Błąd pobierania zamówień: ");
                }
            }
        }

        public IEnumerable<Order> SearchOrders(List<string> criteria)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Order> orders = context.Orders.AsQueryable()
                                                          .Include(i => i.Items)
                                                          .Include(c => c.Client);

                if (!string.IsNullOrEmpty(criteria[0]))
                {
                    if(int.TryParse(criteria[0], out int result))
                    {
                        orders = orders.Where(x => x.Id == result);
                    }
                }

                if (!string.IsNullOrEmpty(criteria[1]))
                {
                    orders = orders.Where(x => x.Client.Name.StartsWith(criteria[1]));
                }

                if (!string.IsNullOrEmpty(criteria[2]) && string.IsNullOrEmpty(criteria[3]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[2]);
                    orders = orders.Where(x => x.DateOrdered >= earlierDate);
                }

                if (string.IsNullOrEmpty(criteria[2]) && !string.IsNullOrEmpty(criteria[3]))
                {
                    DateTime laterDate = Convert.ToDateTime(criteria[3]);
                    orders = orders.Where(x => x.DateOrdered <= laterDate);
                }

                if (!string.IsNullOrEmpty(criteria[2]) && !string.IsNullOrEmpty(criteria[3]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[2]);
                    DateTime laterDate = Convert.ToDateTime(criteria[3]);
                    orders = orders.Where(x => x.DateOrdered >= earlierDate && x.DateOrdered <= laterDate);
                }
                if (!string.IsNullOrEmpty(criteria[4]) && string.IsNullOrEmpty(criteria[5]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[4]);
                    orders = orders.Where(x => x.DateRealized >= earlierDate);
                }
                if (string.IsNullOrEmpty(criteria[4]) && !string.IsNullOrEmpty(criteria[5]))
                {
                    DateTime laterDate = Convert.ToDateTime(criteria[5]);
                    orders = orders.Where(x => x.DateRealized <= laterDate);
                }

                if (!string.IsNullOrEmpty(criteria[4]) && !string.IsNullOrEmpty(criteria[5]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[4]);
                    DateTime laterDate = Convert.ToDateTime(criteria[5]);
                    orders = orders.Where(x => x.DateRealized >= earlierDate && x.DateRealized <= laterDate);
                }

                IEnumerable<Order> ordersList = orders.ToList();

                return ordersList;
            }

        }

        public void RealizeOrder(int orderId, DateTime dateRealized)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                Order order = context.Orders.Include(c => c.Client)
                                            .Include(i => i.Items)
                                            .FirstOrDefault(x => x.Id == orderId);
                order.DateRealized = dateRealized;
                order.IsRealized = true;
                context.SaveChanges();
            }            
        }
    }
}
