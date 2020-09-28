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

		public async Task<Item> AddItemAsync(int id, int product, DateTime dateofadmission, DateTime? dateofemission, bool isinstock)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				Item newItem = new Item
				{
					Id = id,
					DateOfAdmission = dateofadmission,
					DateOfEmission = dateofemission,
					Product = context.Products.SingleOrDefault(x => x.Id == product),
					IsInStock = isinstock
				};
				await context.Items.AddAsync(newItem);
				await context.SaveChangesAsync();

				return newItem;
			}
		}

		public IEnumerable<Item> GetItems()
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				IEnumerable<Item> items = context.Items.Include(p => p.Product).ToList();
				return items;
			}
		}
		public Item GetItem(int id)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				return context.Items.Include(p => p.Product).SingleOrDefault(x => x.Id == id);
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
		public async Task UpdateItemAsync(int id, int product, DateTime dateofadmission, DateTime? dateofemission, bool isinstock)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				Item updatedItem = context.Items.SingleOrDefault(x => x.Id == id);
				updatedItem.Product = context.Products.SingleOrDefault(x => x.Id == product);
				updatedItem.DateOfAdmission = dateofadmission;
				updatedItem.DateOfEmission = dateofemission;
				updatedItem.IsInStock = isinstock;
				await context.SaveChangesAsync();
			}
		}

		public IEnumerable<Item> GetEmittedItemsByProducts(int? productId = null, string productName = null)
		{
			if (productId != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product).ToList().FindAll(p => p.Product.Id == productId && p.IsInStock==false);
						return items;
					}
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
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product).ToList().FindAll(p => p.Product.Name.StartsWith(productName) && p.IsInStock == false);
						return items;
					}
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
		public IEnumerable<Item> GetItemsByProducts(int? productId = null, string productName = null)
		{
			if (productId != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product).ToList().FindAll(p => p.Product.Id == productId && p.IsInStock == true);
						return items;
					}
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
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product).ToList().FindAll(p => p.Product.Name.StartsWith(productName) && p.IsInStock == true);
						return items;
					}
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
		public IEnumerable<Item> GetItemsByDate(DateTime? earlierDate, DateTime? laterDate)
		{
			if (earlierDate != null && laterDate != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product).ToList().FindAll(x => x.DateOfAdmission >= earlierDate && x.DateOfAdmission <= laterDate && x.IsInStock == true);
						return items;
					}
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
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product).ToList().FindAll(x => x.DateOfAdmission >= earlierDate && x.IsInStock == true);
						return items;
					}
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
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product).ToList().FindAll(x => x.DateOfAdmission <= laterDate && x.IsInStock == true);
						return items;
					}
				}
				catch (Exception)
				{
					throw;
				}
			}
			else if (earlierDate == null && laterDate == null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product).ToList();
						return items;
					}
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
		public IEnumerable<Item> GetEmittedItemsByDate(DateTime? earlierDate, DateTime? laterDate)
		{
			if (earlierDate != null && laterDate != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product).ToList().FindAll(x => x.DateOfEmission >= earlierDate && x.DateOfEmission <= laterDate && x.IsInStock == false);
						return items;
					}
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
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product).ToList().FindAll(x => x.DateOfEmission >= earlierDate && x.IsInStock == false);
						return items;
					}
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
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product).ToList().FindAll(x => x.DateOfEmission <= laterDate && x.IsInStock == false);
						return items;
					}
				}
				catch (Exception)
				{
					throw;
				}
			}
			else if (earlierDate == null && laterDate == null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product).ToList();
						return items;
					}
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