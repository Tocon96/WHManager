using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;
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
                    int id = _itemRepository.AddItem(productId, dateofadmission, dateofemission, isinstock, item.IncomingDocument.Id, item.DeliveryId, item.Provider.Id);
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
                throw new Exception("B��d dodawania przedmiotu: " + e);
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
                        IsInStock = item.IsInStock
                        
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
                throw new Exception("B��d pobierania przedmiot�w: ");
            }
        }
		
		public Item GetItem(int id)
		{
            try
            {
                var item = _itemRepository.GetItem(id);
                IList<Product> prodList = productService.GetProduct(item.Product.Id);
                Product product = prodList[0];
                Item currentItem = new Item
                {
                    Id = item.Id,
                    DateOfAdmission = item.DateOfAdmission.Date,
                    Product = product,
                    IsInStock = item.IsInStock
                };

                if (item.DateOfEmission.HasValue)
                {
                    currentItem.DateOfEmission = item.DateOfEmission.Value.Date;
                }

                return currentItem;
            }
			catch
            {
                throw new Exception("B��d pobierania przedmiotu: ");
            }
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
                int providerId = item.Provider.Id;
                int deliveryId = item.DeliveryId;
                int incomingDocumentId = item.IncomingDocument.Id;
                int? orderId = null;
                int? outgoingDocumentId = null;
                if (item.DateOfEmission.HasValue)
                {
                    dateofemission = item.DateOfEmission.Value.Date;

                }
                if (item.Order != null)
                {
                    orderId = item.Order.Id;
                }
                if(item.OutgoingDocument != null)
                {
                    outgoingDocumentId = item.OutgoingDocument.Id;
                }
                _itemRepository.UpdateItem(id, product, dateofadmission, dateofemission, isinstock, incomingDocumentId, outgoingDocumentId, deliveryId, providerId, orderId);
            }
            catch
            {
                throw new Exception("B��d aktualizowania przedmiotu: ");
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
                throw new Exception("B��d usuwania przedmiotu: ");
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
                            IsInStock = item.IsInStock
                           
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
                    throw new Exception("B��d pobierania przedmiot�w: ");
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
                            DateOfAdmission = item.DateOfAdmission.Date,
                            IsInStock = item.IsInStock
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
                    throw new Exception("B��d pobierania przedmiot�w: ");
                }
            }
            else
            {
                throw new Exception("B��d pobierania przedmiot�w: ");
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
                            IsInStock = item.IsInStock

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
                    throw new Exception("B��d pobierania przedmiot�w: ");
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
                            IsInStock = item.IsInStock
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
                    throw new Exception("B��d pobierania przedmiot�w: ");
                }
            }
            else
            {
                throw new Exception("B��d pobierania przedmiot�w: ");
            }
        }
    }
}