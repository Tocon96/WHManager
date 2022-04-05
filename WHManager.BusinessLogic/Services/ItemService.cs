using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.DocumentServices.Interfaces;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository = new ItemRepository(new DataAccess.WHManagerDBContextFactory());
        private IProductService productService = new ProductService();

        public IList<int> CreateNewItems(List<Item> items)
        {
            try
            {
                IList<int> itemIds = new List<int>();
                foreach (Item item in items)
                {
                    int productId = item.Product.Id;
                    DateTime dateofadmission = item.DateOfAdmission.Date;
                    DateTime? dateofemission = null;
                    if (item.DateOfEmission != null)
                    {
                        dateofemission = item.DateOfEmission.Value.Date;
                    }
                    bool isinstock = item.IsInStock;
                    int id = _itemRepository.AddItem(productId, dateofadmission, dateofemission, isinstock, item.IncomingDocumentId, item.DeliveryId, item.ProviderId);
                    itemIds.Add(id);
                }
                IList<Product> prodList = productService.GetProduct(items[0].Product.Id);
                Product product = prodList[0];
                if(product.InStock == false)
                {
                    product.InStock = true;
                    productService.UpdateProduct(product);
                    return null;
                }
                return itemIds;
            }
            catch(Exception e)
            {
                throw new Exception("B³¹d dodawania przedmiotu: " + e);
            }      
        }

        public IList<Item> GetItems()
        {
            try
            {
                IList<Item> itemsList = new List<Item>();
                var items = _itemRepository.GetItems().ToList();
                foreach (var item in items)
                {
                    IList<Product> prodList = productService.GetProduct(item.Product.Id);
                    Product product = prodList[0];
                    Item currentItem = new Item
                    {
                        Id = item.Id,
                        DateOfAdmission = item.DateOfAdmission.Date,
                        Product = product,
                        IsInStock = item.IsInStock,
                        IsInOrder = item.IsInOrder
                        
                    };
                    if (item.DateOfEmission.HasValue)
                    {
                        currentItem.DateOfEmission = item.DateOfEmission.Value.Date;
                    }
                    itemsList.Add(currentItem);
                }
                return itemsList;
            }
            catch
            {
                throw new Exception("B³¹d pobierania przedmiotów: ");
            }
        }
		
		public Item GetItem(int id)
		{
            var item = _itemRepository.GetItem(id);
            IList<Product> prodList = productService.GetProduct(item.Product.Id);
            Product product = prodList[0];
            Item currentItem = new Item
            {
                Id = item.Id,
                DateOfAdmission = item.DateOfAdmission.Date,
                Product = product,
                IsInStock = item.IsInStock,
                IsInOrder = item.IsInOrder,
                DeliveryId = item.DeliveryId,
                IncomingDocumentId = item.IncomingDocument.Id,
                ProviderId = item.Provider.Id,
            };

            if (item.OrderId.HasValue)
            {
                currentItem.OrderId = item.OrderId;
            }

            if (item.DateOfEmission.HasValue)
            {
                currentItem.DateOfEmission = item.DateOfEmission.Value.Date;
                currentItem.OutgoingDocumentId = item.OutgoingDocument.Id;
                currentItem.InvoiceId = item.Invoice.Id;
            }

            return currentItem;
		}
		
		public void UpdateItem(Item item)
		{
            try
            {
                int id = item.Id;
                int product = item.Product.Id;
                DateTime dateofadmission = item.DateOfAdmission.Date;
                bool isinstock = item.IsInStock;
                DateTime? dateofemission = null;
                int providerId = item.ProviderId;
                int deliveryId = item.DeliveryId;
                int incomingDocumentId = item.IncomingDocumentId;
                int? orderId = null;
                int? outgoingDocumentId = null;
                if (item.DateOfEmission.HasValue)
                {
                    dateofemission = item.DateOfEmission.Value.Date;

                }
                if (item.OrderId != null)
                {
                    orderId = item.OrderId;
                }
                if(item.OutgoingDocumentId != null)
                {
                    outgoingDocumentId = item.OutgoingDocumentId;
                }
                _itemRepository.UpdateItem(id, product, dateofadmission, dateofemission, isinstock, incomingDocumentId, outgoingDocumentId, deliveryId, providerId, orderId);
            }
            catch
            {
                throw new Exception("B³¹d aktualizowania przedmiotu: ");
            }
			
		}
		public void DeleteItem(int id)
		{
            try
            {
                _itemRepository.DeleteItem(id);
            }
			catch
            {
                throw new Exception("B³¹d usuwania przedmiotu: ");
            }
		}

        public IList<Item> GetItemsByProduct(int? productId = null, string productName = null)
        {
            if(productId != null)
            {
                try
                {
                    IList<Item> itemsList = new List<Item>();
                    var items = _itemRepository.GetItemsByProducts(productId, null);
                    foreach(var item in items)
                    {
                        IList<Product> prodList = productService.GetProduct(item.Product.Id);
                        Product product = prodList[0];
                        Item currentItem = new Item()
                        {
                            Id = item.Id,
                            Product = product,
                            DateOfAdmission = item.DateOfAdmission,
                            IsInStock = item.IsInStock,
                            IsInOrder = item.IsInOrder,
                            DeliveryId = item.DeliveryId,
                            IncomingDocumentId = item.IncomingDocument.Id,
                            ProviderId = item.Provider.Id
                        };
                        if (item.OrderId.HasValue)
                        {
                            currentItem.OrderId = item.OrderId;
                        }

                        if (item.DateOfEmission.HasValue)
                        {
                            currentItem.DateOfEmission = item.DateOfEmission.Value.Date;
                            currentItem.OutgoingDocumentId = item.OutgoingDocument.Id;
                            currentItem.InvoiceId = item.Invoice.Id;
                        }
                        itemsList.Add(currentItem);
                    }
                    return itemsList;
                }
                catch
                {
                    throw new Exception("B³¹d pobierania przedmiotów: ");
                }
            }
            else if(productName != null)
            {
                try
                {
                    IList<Item> itemsList = new List<Item>();
                    var items = _itemRepository.GetItemsByProducts(null, productName);
                    foreach (var item in items)
                    {
                        IList<Product> prodList = productService.GetProduct(item.Product.Id);
                        Product product = prodList[0];
                        Item currentItem = new Item()
                        {
                            Id = item.Id,
                            Product = product,
                            DateOfAdmission = item.DateOfAdmission,
                            IsInStock = item.IsInStock,
                            IsInOrder = item.IsInOrder,
                            DeliveryId = item.DeliveryId,
                            IncomingDocumentId = item.IncomingDocument.Id,
                            ProviderId = item.Provider.Id,
                            OrderId = item.OrderId,
                            InvoiceId = item.Invoice.Id,
                            DateOfEmission = item.DateOfEmission,
                            OutgoingDocumentId = item.OutgoingDocument.Id
                        };
                        if (item.DateOfEmission.HasValue)
                        {
                            currentItem.DateOfEmission = item.DateOfEmission.Value.Date;
                        }
                        itemsList.Add(currentItem);
                    }
                    return itemsList;
                }
                catch
                {
                    throw new Exception("B³¹d pobierania przedmiotów: ");
                }
            }
            else
            {
                throw new Exception("B³¹d pobierania przedmiotów: ");
            }
        }
        public IList<Item> GetEmittedItemsByProducts(int? productId = null, string productName = null)
        {
            if (productId != null)
            {
                try
                {
                    IList<Item> itemsList = new List<Item>();
                    var items = _itemRepository.GetEmittedItemsByProducts(productId, null);
                    foreach (var item in items)
                    {
                        IList<Product> prodList = productService.GetProduct(item.Product.Id);
                        Product product = prodList[0];
                        Item currentItem = new Item()
                        {
                            Id = item.Id,
                            Product = product,
                            DateOfAdmission = item.DateOfAdmission.Date,
                            IsInStock = item.IsInStock,
                            IsInOrder = item.IsInOrder

                        };
                        if (item.DateOfEmission.HasValue)
                        {
                            currentItem.DateOfEmission = item.DateOfEmission.Value.Date;
                        }
                        itemsList.Add(currentItem);
                    }
                    return itemsList;
                }
                catch
                {
                    throw new Exception("B³¹d pobierania przedmiotów: ");
                }
            }
            else if (productName != null)
            {
                try
                {
                    IList<Item> itemsList = new List<Item>();
                    var items = _itemRepository.GetEmittedItemsByProducts(null, productName);
                    foreach (var item in items)
                    {
                        IList<Product> prodList = productService.GetProduct(item.Product.Id);
                        Product product = prodList[0];
                        Item currentItem = new Item()
                        {
                            Id = item.Id,
                            Product = product,
                            DateOfAdmission = item.DateOfAdmission.Date,
                            IsInStock = item.IsInStock,
                            IsInOrder = item.IsInOrder
                        };
                        if (item.DateOfEmission.HasValue)
                        {
                            currentItem.DateOfEmission = item.DateOfEmission.Value.Date;
                        }
                        itemsList.Add(currentItem);
                    }
                    return itemsList;
                }
                catch
                {
                    throw new Exception("B³¹d pobierania przedmiotów: ");
                }
            }
            else
            {
                throw new Exception("B³¹d pobierania przedmiotów: ");
            }
        }

        public IList<Item> GetAllAvailableItems()
        {
            IList<Item> itemsList = new List<Item>();
            var items = _itemRepository.GetAllAvailableItems().ToList();
            foreach (var item in items)
            {
                IList<Product> prodList = productService.GetProduct(item.Product.Id);
                Product product = prodList[0];
                Item currentItem = new Item
                {
                    Id = item.Id,
                    DateOfAdmission = item.DateOfAdmission.Date,
                    Product = product,
                    IsInStock = item.IsInStock,
                    IsInOrder = item.IsInOrder

                };
                itemsList.Add(currentItem);
            }
            return itemsList;
        }

        public IList<DeliveryOrderTableContent> GroupItems()
        {
            IList<Item> availableItems = GetAllAvailableItems();
            IList<DeliveryOrderTableContent> contents = new List<DeliveryOrderTableContent>();
            var grouped = availableItems.OrderBy(x => x.Product.Id).GroupBy(x => x.Product.Id);
            foreach (var group in grouped)
            {
                Product product = productService.GetProduct(group.Key)[0];
                int itemCount = availableItems.Count(x => x.Product.Id == group.Key);
                DeliveryOrderTableContent content = new DeliveryOrderTableContent(null, product.Id, product.Name, (double)itemCount);
                contents.Add(content);
            }
            return contents;
        }

        public void SetItemInOrder(Item item, int orderId, int count)
        {
            try
            {
                for(int i = 0; i<count; i++)
                {
                    _itemRepository.SetItemInOrder(item.Product.Id, orderId);
                }
            }
            catch
            {
                throw new Exception("B³¹d aktualizowania przedmiotu: ");
            }
        }
        public void RemoveItemsFromOrderByProduct(int orderId, int productId)
        {
            try
            {
                _itemRepository.RemoveItemsFromOrderByProduct(orderId, productId);
            }
            catch
            {
                throw new Exception("B³¹d aktualizowania przedmiotu: ");
            }
        }

        public void AddItemsToOrderByProduct(int orderId, int productId)
        {
            try
            {
                _itemRepository.AddItemsToOrderByProduct(orderId, productId);
            }
            catch
            {
                throw new Exception("B³¹d aktualizowania przedmiotu: ");
            }
        }

        public bool CheckCountOfAvailableItems(int count)
        {
            return _itemRepository.CheckCountOfAvailableItems(count);
        }

        public bool CheckCountOfAvailableItemsPerProduct(int count, int productId)
        {
            return _itemRepository.CheckCountOfAvailableItemsPerProduct(count, productId);
        }


        public void SetItemsToOrder(int orderId, List<DeliveryOrderTableContent> elements)
        {
            foreach(var element in elements)
            {
                for(int i = 0; i < element.Count; i++)
                {
                    _itemRepository.SetItemInOrder(element.ProductId, orderId);
                }
            }
        }

        public void RemoveItemsFromOrder(int orderId)
        {
            var items = _itemRepository.GetItemsByOrder(orderId);
            foreach(var item in items)
            {
                _itemRepository.RemoveItemFromOrder(item.Id);
            }
        }

        public void EmitItemsInOrder(int orderId, DateTime dateTime, int documentId, int invoiceId)
        {
            var items = _itemRepository.GetItemsByOrder(orderId);
            foreach (var item in items)
            {
                _itemRepository.EmitItem(item.Id, dateTime, documentId, invoiceId);
            }
        }

        public IList<Item> GetAllItemsByProduct(int productId)
        {
            IList<Item> itemsList = new List<Item>();
            var items = _itemRepository.GetAllItemsByProduct(productId);
            foreach (var item in items)
            {
                IList<Product> prodList = productService.GetProduct(item.Product.Id);
                Product product = prodList[0];
                Item currentItem = new Item
                {
                    Id = item.Id,
                    Product = product,
                    DateOfAdmission = item.DateOfAdmission,
                    IsInStock = item.IsInStock,
                    IsInOrder = item.IsInOrder,
                    DeliveryId = item.DeliveryId,
                    IncomingDocumentId = item.IncomingDocument.Id,
                    ProviderId = item.Provider.Id,
                };
                if (item.OrderId.HasValue)
                {
                    currentItem.OrderId = item.OrderId;
                }

                if (item.DateOfEmission.HasValue)
                {
                    currentItem.DateOfEmission = item.DateOfEmission.Value.Date;
                    currentItem.OutgoingDocumentId = item.OutgoingDocument.Id;
                    currentItem.InvoiceId = item.Invoice.Id;
                }
                itemsList.Add(currentItem);
            }
            return itemsList;

        }
    }
}