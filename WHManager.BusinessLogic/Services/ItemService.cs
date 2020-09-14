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
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository = new ItemRepository(new DataAccess.WHManagerDBContextFactory());

        public async Task CreateNewItem(Item item)
        {
            int id = item.Id;
            int product = item.Product.Id;
			DateTime dateofpurchase = item.DateOfPurchase;
            DateTime dateofsale = item.DateOfSale;
            await _itemRepository.AddItemAsync(id, product, dateofpurchase, dateofsale);
        }

        public List<Item> GetItems()
        {
            List<Item> itemsList = new List<Item>();
            var items = _itemRepository.GetItems();
            foreach(var item in items)
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
		
		public async Task<Item> GetItem(int id)
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
		
		public async Task UpdateItem(Item item)
		{
			int id = item.Id;
            int product = item.Product.Id;
			DateTime dateofpurchase = item.DateOfPurchase;
            DateTime dateofsale = item.DateOfSale;
            await _itemRepository.UpdateItemAsync(id, product, dateofpurchase, dateofsale);
		}
		public async Task DeleteItem(int id)
		{
			await _itemRepository.DeleteItemAsync(id);
		}
		
    }
}