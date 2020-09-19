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

        public async Task CreateNewItem(Item item)
        {
            try
            {
                int id = item.Id;
                int product = item.Product.Id;
                DateTime dateofpurchase = item.DateOfPurchase;
                DateTime dateofsale = item.DateOfSale;
                await _itemRepository.AddItemAsync(id, product, dateofpurchase, dateofsale);
            }
            catch(Exception e)
            {
                throw e;
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
                        DateOfPurchase = item.DateOfPurchase,
                        DateOfSale = item.DateOfSale
                    };
                    currentItem.Product.Id = item.Product.Id;
                    itemsList.Add(currentItem);
                }
                return itemsList;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
		
		public async Task<Item> GetItem(int id)
		{
            try
            {
                var item = await _itemRepository.GetItemAsync(id);
                Item currentItem = new Item
                {
                    Id = item.Id,

                    DateOfPurchase = item.DateOfPurchase,
                    DateOfSale = item.DateOfSale
                };
                currentItem.Product.Id = item.Product.Id;
                return currentItem;
            }
			catch(Exception e)
            {
                throw e;
            }
		}
		
		public async Task UpdateItem(Item item)
		{
            try
            {
                int id = item.Id;
                int product = item.Product.Id;
                DateTime dateofpurchase = item.DateOfPurchase;
                DateTime dateofsale = item.DateOfSale;
                await _itemRepository.UpdateItemAsync(id, product, dateofpurchase, dateofsale);
            }
            catch(Exception e)
            {
                throw e;
            }
			
		}
		public async Task DeleteItem(int id)
		{
            try
            {
                await _itemRepository.DeleteItemAsync(id);
            }
			catch(Exception e)
            {
                throw e;
            }
		}
		
    }
}