using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
	public class ItemRepository : IItemRepository
	{
		private readonly WHManagerDBContextFactory _contextFactory;

		public ItemRepository(WHManagerDBContextFactory contextFactory)
		{
			_contextFactory = contextFactory;
		}

		public async Task<Item> AddItemAsync(int id, int product, DateTime dateofpurchase, DateTime dateofsale)
		{
			Item newItem = new Item
			{
				Id = id,
				DateOfPurchase = dateofpurchase,
				DateOfSale = dateofsale
			};
			newItem.Product.Id = product;
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				await context.Items.AddAsync(newItem);
				await context.SaveChangesAsync();
			}
			return newItem;
		}

		public IEnumerable<Item> GetItems()
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				IEnumerable<Item> items = context.Items.ToList();
				return items;
			}
		}
		public async Task<Item> GetItemAsync(int id)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				return await context.Items.SingleOrDefaultAsync(x => x.Id == id);
			}
		}

		public async Task DeleteItemAsync(int id)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                context.Items.Remove(await context.Items.SingleOrDefaultAsync(x => x.Id == id));
				await context.SaveChangesAsync();
			}
		}
		public async Task UpdateItemAsync(int id, int product, DateTime dateofpurchase, DateTime dateofsale)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				Item updatedItem = context.Items.SingleOrDefault(x => x.Id == id);
				updatedItem.Product.Id = product;
				updatedItem.DateOfPurchase = dateofpurchase;
				updatedItem.DateOfSale = dateofsale;
				await context.SaveChangesAsync();
			}
		}
	}
}