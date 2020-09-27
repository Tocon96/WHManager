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
        public async Task CreateNewItem(Item item)
        {
            try
            {
                int id = item.Id;
                int product = item.Product.Id;
                DateTime dateofadmission = item.DateOfAdmission;
                DateTime? dateofemission = item.DateOfEmission;
                bool isinstock = item.IsInStock;
                await _itemRepository.AddItemAsync(id, product, dateofadmission, dateofemission, isinstock);
            }
            catch(Exception)
            {
                throw;
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
            catch(Exception)
            {
                throw;
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
			catch(Exception)
            {
                throw;
            }
		}
		
		public async Task UpdateItem(Item item)
		{
            try
            {
                int id = item.Id;
                int product = item.Product.Id;
                DateTime dateofadmission = item.DateOfAdmission;
                DateTime? dateofemission = item.DateOfEmission;
                bool isinstock = item.IsInStock;
                await _itemRepository.UpdateItemAsync(id, product, dateofadmission, dateofemission, isinstock);
            }
            catch(Exception)
            {
                throw;
            }
			
		}
		public async Task DeleteItem(int id)
		{
            try
            {
                await _itemRepository.DeleteItemAsync(id);
            }
			catch(Exception)
            {
                throw;
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
                catch (Exception)
                {
                    throw;
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
                catch (Exception)
                {
                    throw;
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
                catch (Exception)
                {
                    throw;
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
                catch (Exception)
                {
                    throw;
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
                catch (Exception)
                {
                    throw;
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
                    catch (Exception)
                    {
                        throw;
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
                    catch (Exception)
                    {
                        throw;
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
                    catch (Exception)
                    {
                        throw;
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
                    catch (Exception)
                    {
                        throw;
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
                catch (Exception)
                {
                    throw;
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
    }
}