﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository = new OrderRepository(new DataAccess.WHManagerDBContextFactory());
        private readonly IDeliveryOrderElementsRepository elementsRepository = new DeliveryOrderElementsRepository(new DataAccess.WHManagerDBContextFactory());
        private IItemService itemService = new ItemService();
        private IClientService clientService = new ClientService();
        private readonly IProductService productService = new ProductService();
        IDocumentDataService dataService = new DocumentDataService();

        public void AddOrder(Order order, List<DeliveryOrderTableContent> elements)
        {
            try
            {
                decimal price = ManageElements(order.Id, elements);
                int orderId = _orderRepository.AddOrder(price, order.DateOrdered, order.Client.Id);
                itemService.SetItemsToOrder(orderId, elements);
                foreach(DeliveryOrderTableContent element in elements)
                {
                    Product product = productService.GetProduct(element.ProductId)[0];
                    elementsRepository.CreateElement("Order", product.Id, (int)element.Count, orderId);
                }
            }
            catch  
            {
                throw new Exception("Błąd dodawania zamówienia: ");
            }
        }

        private decimal ManageElements(int orderId, List<DeliveryOrderTableContent> elements)
        {
            decimal price = 0;
            foreach (DeliveryOrderTableContent element in elements)
            {
                Product product = productService.GetProduct(element.ProductId)[0];
                if (itemService.CheckCountOfAvailableItemsPerProduct((int)element.Count, product.Id))
                {
                    for (int i = 0; i < element.Count; i++)
                    {
                        price += product.PriceSell + (product.Tax.Value / 100 * product.PriceSell);
                    }
                }
                else
                {
                    throw new Exception("Brak wystarczającej ilości egzemplarzy. Otwórz ponownie okno tworzenia zamówień.");
                }
                
            }
            return price;
        }

        public void UpdateOrder(Order order, List<DeliveryOrderTableContent> elements)
        {
            try
            {
                var existingElements = elementsRepository.GetElementsByDeliveryId("Order", order.Id).ToList();
                decimal price = ManageElements(order.Id, elements);
                IList<DeliveryOrderTableContent> existingContent = new List<DeliveryOrderTableContent>();
                foreach (var element in existingElements)
                {
                    DeliveryOrderTableContent content = new DeliveryOrderTableContent(element.Id, element.ProductId, "", (int)element.ProductCount);
                    existingContent.Add(content);
                }

                foreach (DeliveryOrderTableContent element in elements)
                {
                    if (existingContent.Any(x => x.ProductId == element.ProductId))
                    {
                        DeliveryOrderTableContent content = existingContent.SingleOrDefault(x => x.ProductId == element.ProductId);
                        if (content.Count != element.Count)
                        {
                            elementsRepository.UpdateElement((int)content.Id, "Order", content.ProductId, (int)element.Count, null);
                            if (content.Count > element.Count)
                            {
                                double difference = content.Count - element.Count;
                                for (int i=0; i < difference; i++)
                                {
                                    itemService.RemoveItemsFromOrderByProduct(order.Id, content.ProductId);
                                }
                            }
                            else
                            {
                                double difference = element.Count - content.Count;
                                for (int i = 0; i < difference; i++)
                                {
                                    itemService.AddItemsToOrderByProduct(order.Id, content.ProductId);
                                }
                            }
                        }
                    }
                    else
                    {
                        elementsRepository.CreateElement("Order", element.ProductId, (int)element.Count, order.Id);
                        for(int i=0; i<element.Count; i++)
                        {
                            itemService.AddItemsToOrderByProduct(order.Id, element.ProductId);
                        }
                    }
                }

                foreach (DeliveryOrderTableContent content in existingContent)
                {
                    if (elements.All(x => x.ProductId != content.ProductId))
                    {
                        elementsRepository.DeleteElement((int)content.Id);
                        for (int i = 0; i < content.Count; i++)
                        {
                            itemService.RemoveItemsFromOrderByProduct(order.Id, content.ProductId);
                        }
                    }
                }

                _orderRepository.UpdateOrder(order.Id, order.DateOrdered, price, order.Client.Id);

            }
            catch  
            {
                throw new Exception("Błąd aktualizacji zamówienia: ");
            }
        }

        public void DeleteOrder(int id)
        {
            try
            {
                _orderRepository.DeleteOrder(id);
            }
            catch  
            {
                throw new Exception("Błąd usuwania zamówienia: ");
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
                        DateRealized = order.DateRealized,
                        IsRealized = order.IsRealized,
                        Client = client,
                        Price = order.Price
                    };
                    ordersList.Add(currentOrder);
                }
                return ordersList;
            }
            catch  
            {
                throw new Exception("Błąd pobierania zamówień: ");
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
                    DateRealized = order.DateRealized,
                    IsRealized = order.IsRealized,
                    Client = client,
                    Price = order.Price
                };
                return currentOrder;
            }
            catch  
            {
                throw new Exception("Błąd pobierania zamówień: ");
            }
        }
        public Order GetOrderByInvoice(int invoiceId)
        {
            try
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
                    DateRealized = order.DateRealized,
                    IsRealized = order.IsRealized,
                    Price = order.Price
                };
                return currentOrder;
            }
            catch
            {
                throw new Exception("Błąd pobierania zamówień: ");
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
        public IList<Order> SearchOrders(List<string> criteria)
        {
            IList<Order> orders = new List<Order>();
            var ordersList = _orderRepository.SearchOrders(criteria);
            foreach (var order in ordersList)
            {
                IList<Item> itemsList = new List<Item>();
                foreach (var item in order.Items)
                {
                    itemsList.Add(itemService.GetItem(item.Id));
                }
                Order newOrder = new Order
                {
                    Id = order.Id,
                    Client = clientService.GetClient(order.Client.Id)[0],
                    Items = itemsList,
                    IsRealized = order.IsRealized,
                    DateOrdered = order.DateOrdered.Date,
                    DateRealized = order.DateRealized,
                    Price = order.Price
                };
                orders.Add(newOrder);
            }
            return orders;
        }

        public void EmptyOrderFromItems(Order order)
        {
            itemService.RemoveItemsFromOrder(order.Id);
        }

        public bool RealizeOrder(Order order)
        {
            IOutgoingDocumentService documentService = new OutgoingDocumentService();
            IInvoiceService invoiceService = new InvoiceService();
            DateTime dateTime = DateTime.Now;
            OutgoingDocument outgoingDocument = new OutgoingDocument
            {
                Contrahent = order.Client,
                OrderId = order.Id,
                DateSent = dateTime
            };
            int documentId = documentService.AddDocument(outgoingDocument);
            Invoice invoice = new Invoice
            {
                Client = order.Client,
                OrderId = order.Id,
                DateIssued = dateTime
            };
            int invoiceId = invoiceService.CreateNewInvoice(invoice);
            var grouped = order.Items.OrderBy(x => x.Product.Id).GroupBy(x => x.Product.Id);

            foreach(var group in grouped)
            {
                Product product = productService.GetProduct(group.Key)[0];
                int itemCount = order.Items.Count(x => x.Product.Id == group.Key);
                decimal totalNetto = Math.Round(itemCount * product.PriceSell, 2);
                double vatValue = Math.Round((double)product.Tax.Value / 100 * (double)totalNetto, 2);
                decimal totalBrutto = Math.Round((decimal)vatValue + totalNetto, 2);
                DocumentData data = new DocumentData
                {
                    DocumentId = documentId,
                    DocumentDate = dateTime,
                    DocumentType = "OutgoingDocument",
                    ContrahentName = order.Client.Name,
                    ContrahentNip = order.Client.Nip.ToString(),
                    ContrahentPhoneNumber = order.Client.PhoneNumber,
                    ProductName = product.Name,
                    ProductCount = itemCount,
                    ProductNumber = product.Id,
                    ProductPrice = product.PriceSell,
                    TaxType = product.Tax.Value,
                    TaxValue = (decimal)vatValue,
                    NetValue = totalNetto,
                    GrossValue = totalBrutto
                };
                dataService.CreateNewDataRecord(data);

                DocumentData dataInvoice = new DocumentData
                {
                    DocumentId = documentId,
                    DocumentDate = dateTime,
                    DocumentType = "Invoice",
                    ContrahentName = order.Client.Name,
                    ContrahentNip = order.Client.Nip.ToString(),
                    ContrahentPhoneNumber = order.Client.PhoneNumber,
                    ProductName = product.Name,
                    ProductCount = itemCount,
                    ProductNumber = product.Id,
                    ProductPrice = product.PriceSell,
                    TaxType = product.Tax.Value,
                    TaxValue = (decimal)vatValue,
                    NetValue = totalNetto,
                    GrossValue = totalBrutto
                };
                dataService.CreateNewDataRecord(dataInvoice);
            }
            

            _orderRepository.RealizeOrder(order.Id, dateTime);
            itemService.EmitItemsInOrder(order.Id, dateTime, documentId, invoiceId);
            return true;

        }

        public IList<DeliveryOrderTableContent> GetElements(int orderId)
        {
            var contents = elementsRepository.GetElementsByDeliveryId("Order", orderId);
            IList<DeliveryOrderTableContent> elements = new List<DeliveryOrderTableContent>();
            foreach (var content in contents)
            {
                Product product = productService.GetProduct(content.ProductId)[0];
                DeliveryOrderTableContent element = new DeliveryOrderTableContent(null, content.ProductId, product.Name, (double)content.ProductCount);
                elements.Add(element);
            }
            return elements;
        }

        public IList<Order> GetRealizedOrdersByClient(int clientId, DateTime? dateFrom, DateTime? dateTo)
        {
            var orders = _orderRepository.GetRealizedOrdersByClientWithinDateRanges(clientId, dateFrom, dateTo);
            IList<Order> ordersList = new List<Order>();
            foreach (var order in orders)
            {
                IList<Item> itemsList = new List<Item>();
                foreach (var item in order.Items)
                {
                    itemsList.Add(itemService.GetItem(item.Id));
                }
                Order newOrder = new Order
                {
                    Id = order.Id,
                    Client = clientService.GetClient(order.Client.Id)[0],
                    Items = itemsList,
                    IsRealized = order.IsRealized,
                    DateOrdered = order.DateOrdered.Date,
                    DateRealized = order.DateRealized,
                    Price = order.Price,
                    ItemCount = itemsList.Count
                };
                ordersList.Add(newOrder);
            }
            return ordersList;
        }

        public IList<Item> GetAllItemsFromOrders(List<Order> orders)
        {
            IList<Item> items = new List<Item>();
            foreach (Order order in orders)
            {
                foreach (Item item in order.Items)
                {
                    items.Add(item);
                }
            }

            return items;
        }

        public IList<Order> GetOrdersByManufacturer(ManufacturerReports report)
        {
            var orders = _orderRepository.GetOrdersByManufacturer(report.Manufacturer.Id, report.DateRealizedFrom, report.DateRealizedTo);
            IList<Order> ordersList = new List<Order>();
            foreach (var order in orders)
            {
                IList<Item> itemsList = new List<Item>();
                foreach (var item in order.Items)
                {
                    itemsList.Add(itemService.GetItem(item.Id));
                }
                decimal price = itemsList.Where(x => x.Product.Manufacturer.Id == report.Manufacturer.Id).Sum(item => item.Product.PriceSell);
                Order newOrder = new Order
                {
                    Id = order.Id,
                    Client = clientService.GetClient(order.Client.Id)[0],
                    Items = itemsList,
                    IsRealized = order.IsRealized,
                    DateOrdered = order.DateOrdered.Date,
                    DateRealized = order.DateRealized,
                    Price = price,
                    ItemCount = itemsList.Count(x => x.Product.Manufacturer.Id == report.Manufacturer.Id)
                };
                ordersList.Add(newOrder);
            }
            return ordersList;

        }

        public IList<Order> GetOrdersByProductType(TypeReports report)
        {
            var orders = _orderRepository.GetOrdersByProductType(report.Type.Id, report.DateRealizedFrom, report.DateRealizedTo);
            IList<Order> ordersList = new List<Order>();
            foreach (var order in orders)
            {
                IList<Item> itemsList = new List<Item>();
                foreach (var item in order.Items)
                {
                    itemsList.Add(itemService.GetItem(item.Id));
                }
                decimal price = itemsList.Where(x => x.Product.Manufacturer.Id == report.Type.Id).Sum(item => item.Product.PriceSell);
                Order newOrder = new Order
                {
                    Id = order.Id,
                    Client = clientService.GetClient(order.Client.Id)[0],
                    Items = itemsList,
                    IsRealized = order.IsRealized,
                    DateOrdered = order.DateOrdered.Date,
                    DateRealized = order.DateRealized,
                    Price = price,
                    ItemCount = itemsList.Count(x => x.Product.Manufacturer.Id == report.Type.Id)
                };
                ordersList.Add(newOrder);
            }
            return ordersList;

        }

        public IList<Order> GetOrdersByProduct(ProductReports report)
        {
            var orders = _orderRepository.GetOrdersByProduct(report.Product.Id, report.DateRealizedFrom, report.DateRealizedTo);
            IList<Order> ordersList = new List<Order>();
            foreach (var order in orders)
            {
                IList<Item> itemsList = new List<Item>();
                foreach (var item in order.Items)
                {
                    itemsList.Add(itemService.GetItem(item.Id));
                }
                decimal price = itemsList.Where(x => x.Product.Id == report.Product.Id).Sum(item => item.Product.PriceSell);
                Order newOrder = new Order
                {
                    Id = order.Id,
                    Client = clientService.GetClient(order.Client.Id)[0],
                    Items = itemsList,
                    IsRealized = order.IsRealized,
                    DateOrdered = order.DateOrdered.Date,
                    DateRealized = order.DateRealized,
                    Price = price,
                    ItemCount = itemsList.Count(x => x.Product.Id == report.Product.Id)
                };
                ordersList.Add(newOrder);
            }
            return ordersList;

        }
    }
}