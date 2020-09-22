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
		
		public Product GetProduct(int id)
		{
			using(WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				return context.Products.SingleOrDefault(x => x.Id == id);	
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

        public IEnumerable<Product> GetProductsByManufacturer(string manufacturerName = null, int? manufacturerId = null, double? manufacturerNip = null)
        {
            if(manufacturerName != null)
            {
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.Manufacturer.Name.StartsWith(manufacturerName));
						return products;
					}
				}
				catch (Exception e)
				{
					throw e;
				}
			}
			else if(manufacturerId != null)
            {
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.Manufacturer.Id == manufacturerId);
						return products;
					}
				}
				catch (Exception e)
				{
					throw e;
				}
			}
			else if(manufacturerNip != null)
            {
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.Manufacturer.Nip == manufacturerNip);
						return products;
					}
				}
				catch (Exception e)
				{
					throw e;
				}
			}
            else
            {
				return null;
            }
        }

        public IEnumerable<Product> GetProductsByTax(int? taxValue = null, string taxName = null, int? taxId = null)
        {
            if(taxValue != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.Tax.Value == taxValue);
						return products;
					}
				}
				catch (Exception e)
				{
					throw e;
				}
			}
			else if(taxName != null)
            {
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.Tax.Name.StartsWith(taxName));
						return products;
					}
				}
				catch (Exception e)
				{
					throw e;
				}
			}
			else if(taxId != null)
            {
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.Tax.Id == taxId);
						return products;
					}
				}
				catch (Exception e)
				{
					throw e;
				}
			}
            else
            {
				return null;
            }

			
		}

        public IEnumerable<Product> GetProductsByName(string name)
        {
			try
			{
				using (WHManagerDBContext context = _contextFactory.CreateDbContext())
				{
					IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.Name.StartsWith(name));
					return products;
				}
			}
			catch (Exception e)
			{
				throw e;
			}
		}

        public IEnumerable<Product> GetProductsByType(string productTypeName = null, int? productTypeId = null)
        {
            if(productTypeName != null)
            {
                try
                {
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                    {
						IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.Type.Name.StartsWith(productTypeName));
						return products;
					}
						
                }
				catch(Exception e)
                {
					throw e;
                }
            }
			else if(productTypeId != null)
            {
                try
                {
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                    {
						IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.Type.Id == productTypeId);
						return products;
					}

				}
				catch(Exception e)
                {
					throw e;
                }
            }
            else
            {
				return null;
            }
        }

        public IEnumerable<Product> GetProductsByPriceSell(decimal? priceMin = null, decimal? priceMax = null)
        {
            if(priceMin != null && priceMax != null)
            {
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.PriceSell >= priceMin && x.PriceSell <= priceMin);
						return products;
					}

				}
				catch (Exception e)
				{
					throw e;
				}
			}
			else if(priceMin != null && priceMax == null)
            {
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.PriceSell >= priceMin);
						return products;
					}

				}
				catch (Exception e)
				{
					throw e;
				}
			}
			else if(priceMin == null && priceMax != null)
            {
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.PriceSell <= priceMin);
						return products;
					}

				}
				catch (Exception e)
				{
					throw e;
				}
			}
            else
            {
				return null;
            }
        }

        public IEnumerable<Product> GetProductsByPriceBuy(decimal? priceMin = null, decimal? priceMax = null)
        {
			if (priceMin != null && priceMax != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.PriceBuy >= priceMin && x.PriceBuy <= priceMin);
						return products;
					}

				}
				catch (Exception e)
				{
					throw e;
				}
			}
			else if (priceMin != null && priceMax == null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.PriceBuy >= priceMin);
						return products;
					}

				}
				catch (Exception e)
				{
					throw e;
				}
			}
			else if (priceMin == null && priceMax != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.PriceBuy <= priceMin);
						return products;
					}

				}
				catch (Exception e)
				{
					throw e;
				}
			}
			else
			{
				return null;
			}
		}

        public IEnumerable<Product> GetProductsInStock()
        {
            try
            {
				using(WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
					IEnumerable<Product> products = context.Products.ToList().FindAll(x => x.InStock == true);
					return products;
                }
            }
			catch(Exception e)
            {
				throw e;
            }
        }
    }	
}