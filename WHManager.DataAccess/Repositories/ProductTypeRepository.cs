using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
	public class ProductTypeRepository : IProductTypeRepository
	{
		private readonly WHManagerDBContextFactory _contextFactory;

		public ProductTypeRepository(WHManagerDBContextFactory contextFactory)
		{
			_contextFactory = contextFactory;
		}

		public async Task<ProductType> AddProductTypeAsync(string name)
		{
			ProductType newProductType = new ProductType
			{
				Name = name,
			};
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				await context.ProductTypes.AddAsync(newProductType);
				await context.SaveChangesAsync();
			}
			return newProductType;
		}

		public IEnumerable<ProductType> GetAllProductTypes()
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				IEnumerable<ProductType> productTypes = context.ProductTypes.ToList();
				return productTypes;
			}
		}
		public ProductType GetProductType(int id)
		{
            try
            {
				using (WHManagerDBContext context = _contextFactory.CreateDbContext())
				{
					return context.ProductTypes.SingleOrDefault(x => x.Id == id);
				}
			}
			catch(Exception)
            {
				throw;
            }
			
		}
		public async Task DeleteProductTypeAsync(int id)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				context.Remove(await context.ProductTypes.SingleOrDefaultAsync(x => x.Id == id));
				await context.SaveChangesAsync();
			}
		}
		public async Task UpdateProductTypeAsync(int id, string name)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				ProductType updatedProductType = await context.ProductTypes.SingleOrDefaultAsync(x => x.Id == id);
				updatedProductType.Name = name;
				await context.SaveChangesAsync();
			}
		}

		public IEnumerable<ProductType> GetProductTypesByName(string name)
        {
            try
            {
				using (WHManagerDBContext context = _contextFactory.CreateDbContext())
				{
					IEnumerable<ProductType> productTypes = context.ProductTypes.ToList().FindAll(x => x.Name.StartsWith(name));
					return productTypes;
				}
			}
			catch(Exception)
            {
				throw;
            }
		}
	}
}