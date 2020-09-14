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
	public class ProductRepository: IProductRepository
	{
		private readonly WHManagerDBContextFactory _contextFactory;
		
		public ProductRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
		
		public async Task<Product> AddProductAsync(int id, string name, int producttype, int tax, int manufacturer)
		{
            Product newProduct = new Product
            {
                Id = id,
                Name = name
            };
            newProduct.Type.Id = producttype;
			newProduct.Tax.Id = tax;
			newProduct.Manufacturer.Id = manufacturer;
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				await context.Products.AddAsync(newProduct);
				await context.SaveChangesAsync();
			}
			return newProduct;
		}
		public IEnumerable<Product> GetAllProducts()
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				IEnumerable<Product> products = context.Products.ToList();
				return products;	
			}
		}
		
		public async Task<Product> GetProductAsync(int id)
		{
			using(WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				return await context.Products.SingleOrDefaultAsync(x => x.Id == id);	
			}
		}
		
		public async Task DeleteProductAsync(int id)
		{
			using(WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				context.Remove(await context.Products.SingleOrDefaultAsync(x => x.Id == id));
				await context.SaveChangesAsync();
			}
		}
		public async Task UpdateProductAsync(int id, string name, int producttype, int tax, int manufacturer)
		{
			using(WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				Product updatedProduct = context.Products.SingleOrDefault(x => x.Id == id);
				updatedProduct.Name = name;
				updatedProduct.Type.Id = producttype;
				updatedProduct.Tax.Id = tax;
				updatedProduct.Manufacturer.Id = manufacturer;
				await context.SaveChangesAsync();
			}
		}
		
	}	
}