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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository = new OrderRepository(new DataAccess.WHManagerDBContextFactory());
        private IItemService itemService = new ItemService();
        private IClientService clientService = new ClientService();

        public async Task AddOrder(Order order)
        {
            try
            {
                IList<int> items = new List<int>();
                int id = order.Id;
                foreach(var item in order.Items)
                {
                    int itemId = item.Id;
                    items.Add(itemId);
                }
                decimal price = order.Price;
                DateTime dateTime = order.DateOrdered;
                int client = order.Client.Id;
                await _orderRepository.AddOrderAsync(id, price, dateTime, items, client);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateOrder(Order order)
        {
            try
            {
                IList<int> items = new List<int>();
                int id = order.Id;
                foreach (var item in order.Items)
                {
                    int itemId = item.Id;
                    items.Add(itemId);
                }
                decimal price = order.Price;
                DateTime dateTime = order.DateOrdered;
                int client = order.Client.Id;
                if(order.Invoice != null)
                {
                    int invoice = order.Invoice.Id;
                    await _orderRepository.UpdateOrderAsync(id, dateTime, items, price, client, invoice);
                }
                else
                {
                    await _orderRepository.UpdateOrderAsync(id, dateTime, items, price, client);
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteOrder(int id)
        {
            try
            {
                await _orderRepository.DeleteOrderAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Order> GetAllOrders()
        {
            try
            {
                IList<Order> ordersList = new List<Order>();
                var orders = _orderRepository.GetAllOrders();
                foreach(var order in orders)
                {
                    IList<Client> clients = clientService.GetClient(order.Client.Id);
                    Client client = clients[0];
                    IList<Item> itemsList = new List<Item>();
                    foreach (var item in order.Items)
                    {
                        itemsList.Add(itemService.GetItem(item.Id));
                    }
                    Order currentOrder = new Order
                    {
                        Id = order.Id,
                        Items = itemsList,
                        DateOrdered = order.DateOrdered,
                        Client = client,
                        Price = order.Price
                    };
                    ordersList.Add(currentOrder);
                }
                return ordersList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Order GetOrderById(int id)
        {
            try
            {
                var order = _orderRepository.GetOrderById(id);
                IList<Item> itemsList = new List<Item>();
                IList<Client> clients = clientService.GetClient(order.Client.Id);
                Client client = clients[0];
                foreach (var item in order.Items)
                {
                    itemsList.Add(itemService.GetItem(item.Id));
                }
                Order currentOrder = new Order
                {
                    Id = order.Id,
                    Items = itemsList,
                    DateOrdered = order.DateOrdered,
                    Client = client,
                };
                return currentOrder;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Order GetOrderByInvoice(int invoiceId)
        {
            var order = _orderRepository.GetOrderByInvoice(invoiceId);
            IList<Item> itemsList = new List<Item>();
            IList<Client> clients = clientService.GetClient(order.Client.Id);
            Client client = clients[0];
            foreach (var item in order.Items)
            {
                itemsList.Add(itemService.GetItem(item.Id));
            }
            Order currentOrder = new Order
            {
                Id = order.Id,
                Items = itemsList,
                DateOrdered = order.DateOrdered,
                Client = client
            };
            return currentOrder;
        }

        public IList<Order> GetOrdersByClient(int? clientId = null, string clientName = null, double? clientNip = null)
        {
            if(clientId != null)
            {
                try
                {
                    IList<Order> ordersList = new List<Order>();
                    var orders = _orderRepository.GetOrdersByClient(clientId);
                    foreach (var order in orders)
                    {
                        IList<Client> clients = clientService.GetClient(order.Client.Id);
                        Client client = clients[0];
                        IList<Item> itemsList = new List<Item>();
                        foreach (var item in order.Items)
                        {
                            itemsList.Add(itemService.GetItem(item.Id));
                        }
                        Order currentOrder = new Order
                        {
                            Id = order.Id,
                            Items = itemsList,
                            DateOrdered = order.DateOrdered,
                            Client = client
                        };
                        ordersList.Add(currentOrder);
                    }
                    return ordersList;
                }
                catch (Exception)
                {
                    throw;
                }   
            }
            else if(clientName != null)
            {
                try
                {
                    IList<Order> ordersList = new List<Order>();
                    var orders = _orderRepository.GetOrdersByClient(null, clientName);
                    foreach (var order in orders)
                    {
                        IList<Client> clients = clientService.GetClient(order.Client.Id);
                        Client client = clients[0];
                        IList<Item> itemsList = new List<Item>();
                        foreach (var item in order.Items)
                        {
                            itemsList.Add(itemService.GetItem(item.Id));
                        }
                        Order currentOrder = new Order
                        {
                            Id = order.Id,
                            Items = itemsList,
                            DateOrdered = order.DateOrdered,
                            Client = client,
                        };
                        ordersList.Add(currentOrder);
                    }
                    return ordersList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if(clientNip != null)
            {
                try
                {
                    IList<Order> ordersList = new List<Order>();
                    var orders = _orderRepository.GetOrdersByClient(null, null, clientNip);
                    foreach (var order in orders)
                    {
                        IList<Client> clients = clientService.GetClient(order.Client.Id);
                        Client client = clients[0];
                        IList<Item> itemsList = new List<Item>();
                        foreach (var item in order.Items)
                        {
                            itemsList.Add(itemService.GetItem(item.Id));
                        }
                        Order currentOrder = new Order
                        {
                            Id = order.Id,
                            Items = itemsList,
                            DateOrdered = order.DateOrdered,
                            Client = client,
                        };
                        ordersList.Add(currentOrder);
                    }
                    return ordersList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public IList<Order> GetOrdersByDate(DateTime? earlierDate, DateTime? laterDate)
        {
            if (earlierDate != null && laterDate != null)
            {
                try
                {
                    IList<Order> ordersList = new List<Order>();
                    var orders = _orderRepository.GetInvoicesByDate(earlierDate, laterDate);
                    foreach (var order in orders)
                    {
                        IList<Client> clients = clientService.GetClient(order.Client.Id);
                        Client client = clients[0];
                        IList<Item> itemsList = new List<Item>();
                        foreach (var item in order.Items)
                        {
                            itemsList.Add(itemService.GetItem(item.Id));
                        }
                        Order currentOrder = new Order
                        {
                            Id = order.Id,
                            Items = itemsList,
                            DateOrdered = order.DateOrdered,
                            Client = client,
                        };
                        ordersList.Add(currentOrder);
                    }
                    return ordersList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (earlierDate != null && laterDate == null)
            {
                try
                {
                    IList<Order> ordersList = new List<Order>();
                    var orders = _orderRepository.GetInvoicesByDate(earlierDate, null);
                    foreach (var order in orders)
                    {
                        IList<Client> clients = clientService.GetClient(order.Client.Id);
                        Client client = clients[0];
                        IList<Item> itemsList = new List<Item>();
                        foreach (var item in order.Items)
                        {
                            itemsList.Add(itemService.GetItem(item.Id));
                        }
                        Order currentOrder = new Order
                        {
                            Id = order.Id,
                            Items = itemsList,
                            DateOrdered = order.DateOrdered,
                            Client = client,
                        };
                        ordersList.Add(currentOrder);
                    }
                    return ordersList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (earlierDate == null && laterDate != null)
            {
                try
                {
                    IList<Order> ordersList = new List<Order>();
                    var orders = _orderRepository.GetInvoicesByDate(null, laterDate);
                    foreach (var order in orders)
                    {
                        IList<Client> clients = clientService.GetClient(order.Client.Id);
                        Client client = clients[0];
                        IList<Item> itemsList = new List<Item>();
                        foreach (var item in order.Items)
                        {
                            itemsList.Add(itemService.GetItem(item.Id));
                        }
                        Order currentOrder = new Order
                        {
                            Id = order.Id,
                            Items = itemsList,
                            DateOrdered = order.DateOrdered,
                            Client = client,
                        };
                        ordersList.Add(currentOrder);
                    }
                    return ordersList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                try
                {
                    IList<Order> ordersList = new List<Order>();
                    var orders = _orderRepository.GetInvoicesByDate(null, null);
                    foreach (var order in orders)
                    {
                        IList<Client> clients = clientService.GetClient(order.Client.Id);
                        Client client = clients[0];
                        IList<Item> itemsList = new List<Item>();
                        foreach (var item in order.Items)
                        {
                            itemsList.Add(itemService.GetItem(item.Id));
                        }
                        Order currentOrder = new Order
                        {
                            Id = order.Id,
                            Items = itemsList,
                            DateOrdered = order.DateOrdered,
                            Client = client,
                        };
                        ordersList.Add(currentOrder);
                    }
                    return ordersList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}