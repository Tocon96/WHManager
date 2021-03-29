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
        public void CreateNewItems(List<Item> items)
        {
            try
            {
                foreach (Item item in items)
                {
                    int id = item.Id;
                    int productId = item.Product.Id;
                    DateTime dateofadmission = item.DateOfAdmission;
                    DateTime? dateofemission = item.DateOfEmission;
                    bool isinstock = item.IsInStock;
                    _itemRepository.AddItem(id, productId, dateofadmission, dateofemission, isinstock);
                }
                Product product = productService.GetProduct(items[0].Product.Id);
                if(product.InStock == false)
                {
                    product.InStock = true;
                    productService.UpdateProduct(product);
                }
            }
            catch
            {
                throw new Exception("B³¹d dodawania przedmiotu: ");
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
                    Item currentItem = new Item
                    {
                        Id = item.Id,
                        DateOfAdmission = item.DateOfAdmission,
                        DateOfEmission = item.DateOfEmission,
                        Product = productService.GetProduct(item.Product.Id),
                        IsInStock = item.IsInStock
                        
                    };
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
            try
            {
                var item = _itemRepository.GetItem(id);
                Item currentItem = new Item
                {
                    Id = item.Id,
                    DateOfAdmission = item.DateOfAdmission,
                    DateOfEmission = item.DateOfEmission,
                    Product = productService.GetProduct(item.Product.Id),
                    IsInStock = item.IsInStock
                };
                return currentItem;
            }
			catch
            {
                throw new Exception("B³¹d pobierania przedmiotu: ");
            }
		}
		
		public void UpdateItem(Item item)
		{
            try
            {
                int id = item.Id;
                int product = item.Product.Id;
                DateTime dateofadmission = item.DateOfAdmission;
                DateTime? dateofemission = item.DateOfEmission;
                bool isinstock = item.IsInStock;
                _itemRepository.UpdateItem(id, product, dateofadmission, dateofemission, isinstock);
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
                        Item currentItem = new Item()
                        {
                            Id = item.Id,
                            Product = productService.GetProduct(item.Product.Id),
                            DateOfAdmission = item.DateOfAdmission,
                            DateOfEmission = item.DateOfEmission,
                            IsInStock = item.IsInStock
                           
                        };
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
                        Item currentItem = new Item()
                        {
                            Id = item.Id,
                            Product = productService.GetProduct(item.Product.Id),
                            DateOfAdmission = item.DateOfAdmission,
                            DateOfEmission = item.DateOfEmission,
                            IsInStock = item.IsInStock
                        };
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

        public IList<Item> GetItemsByDate(DateTime? earlierDate, DateTime? laterDate)
        {
            if (earlierDate != null && laterDate != null)
            {
                try
                {
                    IList<Item> itemsList = new List<Item>();
                    var items = _itemRepository.GetItemsByDate(earlierDate, laterDate);
                    foreach(var item in items)
                    {
                        Item currentItem = new Item()
                        {
                            Id = item.Id,
                            Product = productService.GetProduct(item.Product.Id),
                            DateOfAdmission = item.DateOfAdmission,
                            DateOfEmission = item.DateOfEmission,
                            IsInStock = item.IsInStock
                        };
                        itemsList.Add(currentItem);
                    }
                    return itemsList;
                }
                catch
                {
                    throw new Exception("B³¹d pobierania przedmiotów: ");
                }
            }
            else if (earlierDate != null && laterDate == null)
            {
                try
                {
                    IList<Item> itemsList = new List<Item>();
                    var items = _itemRepository.GetItemsByDate(earlierDate, null);
                    foreach (var item in items)
                    {
                        Item currentItem = new Item()
                        {
                            Id = item.Id,
                            Product = productService.GetProduct(item.Product.Id),
                            DateOfAdmission = item.DateOfAdmission,
                            DateOfEmission = item.DateOfEmission,
                            IsInStock = item.IsInStock
                        };
                        itemsList.Add(currentItem);
                    }
                    return itemsList;
                }
                catch
                {
                    throw new Exception("B³¹d pobierania przedmiotów: ");
                }
            }
            else if(earlierDate == null && laterDate != null)
            {
                try
                {
                    IList<Item> itemsList = new List<Item>();
                    var items = _itemRepository.GetItemsByDate(null, laterDate);
                    foreach (var item in items)
                    {
                        Item currentItem = new Item()
                        {
                            Id = item.Id,
                            Product = productService.GetProduct(item.Product.Id),
                            DateOfAdmission = item.DateOfAdmission,
                            DateOfEmission = item.DateOfEmission,
                            IsInStock = item.IsInStock
                        };
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
                try
                {
                    IList<Item> itemsList = new List<Item>();
                    var items = _itemRepository.GetItems();
                    foreach (var item in items)
                    {
                        Item currentItem = new Item()
                        {
                            Id = item.Id,
                            Product = productService.GetProduct(item.Product.Id),
                            DateOfAdmission = item.DateOfAdmission,
                            DateOfEmission = item.DateOfEmission,
                            IsInStock = item.IsInStock
                        };
                        itemsList.Add(currentItem);
                    }
                    return itemsList;
                }
                catch
                {
                    throw new Exception("B³¹d pobierania przedmiotów: ");
                }
            }
        }

        public IList<Item> GetEmittedItemsByDate(DateTime? earlierDate, DateTime? laterDate)
        {
            {
                if (earlierDate != null && laterDate != null)
                {
                    try
                    {
                        IList<Item> itemsList = new List<Item>();
                        var items = _itemRepository.GetEmittedItemsByDate(earlierDate, laterDate);
                        foreach (var item in items)
                        {
                            Item currentItem = new Item()
                            {
                                Id = item.Id,
                                Product = productService.GetProduct(item.Product.Id),
                                DateOfAdmission = item.DateOfAdmission,
                                DateOfEmission = item.DateOfEmission,
                                IsInStock = item.IsInStock
                            };
                            itemsList.Add(currentItem);
                        }
                        return itemsList;
                    }
                    catch
                    {
                        throw new Exception("B³¹d pobierania przedmiotów: ");
                    }
                }
                else if (earlierDate != null && laterDate == null)
                {
                    try
                    {
                        IList<Item> itemsList = new List<Item>();
                        var items = _itemRepository.GetEmittedItemsByDate(earlierDate, null);
                        foreach (var item in items)
                        {
                            Item currentItem = new Item()
                            {
                                Id = item.Id,
                                Product = productService.GetProduct(item.Product.Id),
                                DateOfAdmission = item.DateOfAdmission,
                                DateOfEmission = item.DateOfEmission,
                                IsInStock = item.IsInStock
                            };
                            itemsList.Add(currentItem);
                        }
                        return itemsList;
                    }
                    catch
                    {
                        throw new Exception("B³¹d pobierania przedmiotów: ");
                    }
                }
                else if (earlierDate == null && laterDate != null)
                {
                    try
                    {
                        IList<Item> itemsList = new List<Item>();
                        var items = _itemRepository.GetEmittedItemsByDate(null, laterDate);
                        foreach (var item in items)
                        {
                            Item currentItem = new Item()
                            {
                                Id = item.Id,
                                Product = productService.GetProduct(item.Product.Id),
                                DateOfAdmission = item.DateOfAdmission,
                                DateOfEmission = item.DateOfEmission,
                                IsInStock = item.IsInStock
                            };
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
                    try
                    {
                        IList<Item> itemsList = new List<Item>();
                        var items = _itemRepository.GetItems();
                        foreach (var item in items)
                        {
                            Item currentItem = new Item()
                            {
                                Id = item.Id,
                                Product = productService.GetProduct(item.Product.Id),
                                DateOfAdmission = item.DateOfAdmission,
                                DateOfEmission = item.DateOfEmission,
                                IsInStock = item.IsInStock
                            };
                            itemsList.Add(currentItem);
                        }
                        return itemsList;
                    }
                    catch
                    {
                        throw new Exception("B³¹d pobierania przedmiotów: ");
                    }
                }
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
                        Item currentItem = new Item()
                        {
                            Id = item.Id,
                            Product = productService.GetProduct(item.Product.Id),
                            DateOfAdmission = item.DateOfAdmission,
                            DateOfEmission = item.DateOfEmission,
                            IsInStock = item.IsInStock

                        };
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
                        Item currentItem = new Item()
                        {
                            Id = item.Id,
                            Product = productService.GetProduct(item.Product.Id),
                            DateOfAdmission = item.DateOfAdmission,
                            DateOfEmission = item.DateOfEmission,
                            IsInStock = item.IsInStock
                        };
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
    }
}