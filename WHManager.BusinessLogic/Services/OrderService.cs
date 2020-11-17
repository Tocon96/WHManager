using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        private readonly IProductService productService = new ProductService();

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
                decimal price = CalculateFinalPrice(order);
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
                decimal price = CalculateFinalPrice(order);
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
                    Price = order.Price
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
                Client = client,
                Price = order.Price
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
        }
        public decimal CalculateFinalPrice(Order order)
        {
            decimal finalPrice = 0;
            foreach(var item in order.Items)
            {
                decimal price = productService.CalculatePrice(item.Product);
                finalPrice = finalPrice + price;
            }
            return finalPrice;
        }

        public IList<Product> GetSortedProducts(Order order)
        {
            IList<Product> products = new List<Product>();
            IList<Product> sortedProducts = new List<Product>();
            IList<int> counts = new List<int>();
            foreach(var item in order.Items)
            {
                products.Add(item.Product);
            }
            products = products.OrderBy(p => p.Id).ToList();
            for (int i = 0, j = 0, count = 0; i < products.Count; i++)
            {
                if (i == 0)
                {
                    sortedProducts.Add(products[i]);
                    count++;
                }
                else
                {
                    if (products[i].Id != products[i - 1].Id)
                    {
                        sortedProducts[j].CountOf = count;
                        j++;
                        count = 1;
                        sortedProducts.Add(products[i]);
                    }
                    else
                    {
                        count++;
                    }
                }
                if(i+1 == products.Count)
                {
                    sortedProducts[j].CountOf = count;
                }
            }
            foreach(var product in sortedProducts)
            {
                product.PriceBrutto = productService.CalculatePrice(product);
            }
            return sortedProducts;
            
        }
    }
}