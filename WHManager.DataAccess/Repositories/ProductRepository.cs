using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
		
		public Product AddProduct(string name, int producttype, int tax, int manufacturer, decimal pricebuy, decimal pricesell)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				Product newProduct = new Product
				{
					Name = name,
					PriceBuy = pricebuy,
					PriceSell = pricesell,
					InStock = false,
					Type = context.ProductTypes.SingleOrDefault(x => x.Id == producttype),
					Tax = context.Taxes.SingleOrDefault(x => x.Id == tax),
					Manufacturer = context.Manufacturers.SingleOrDefault(x => x.Id == manufacturer)
				};
			
                try
                {
					context.Products.Add(newProduct);
					context.SaveChanges();
				}
				catch
                {
					throw new Exception("B³¹d dodawania produktu");
                }
				return newProduct;
			}
			
		}
		public IEnumerable<Product> GetAllProducts()
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					IEnumerable<Product> products = context.Products
														.Include(x => x.Manufacturer)
														.Include(x => x.Tax)
														.Include(x => x.Type)
														.ToList();
					return products;
				}
                catch
                {
					throw new Exception("B³¹d pobierania produktów: ");
                }	
			}
		}
		
		public IEnumerable<Product> GetProduct(int id)
		{
			using(WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					IEnumerable<Product> products = context.Products
								.Include(x => x.Manufacturer)
								.Include(x => x.Tax)
								.Include(x => x.Type)
								.ToList()
								.FindAll(x => x.Id == id);
					return products;
				}
                catch
                {
					throw new Exception("B³¹d pobierania produktów: ");
				}
					
			}
		}
		
		public void DeleteProduct(int id)
		{
			using(WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					context.Remove(context.Products.SingleOrDefault(x => x.Id == id));
					context.SaveChanges();
				}
				catch
				{
					throw new Exception("B³¹d usuwania produktu o ID: "+id+" : ");
				}
			}
		}
		public void UpdateProduct(int id, string name, int producttype, int tax, int manufacturer, decimal pricesell, decimal pricebuy, bool instock)
		{
			using(WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					Product updatedProduct = context.Products.SingleOrDefault(x => x.Id == id);
					updatedProduct.Name = name;
					updatedProduct.Type = context.ProductTypes.SingleOrDefault(x => x.Id == producttype);
					updatedProduct.Tax = context.Taxes.SingleOrDefault(x => x.Id == tax);
					updatedProduct.Manufacturer = context.Manufacturers.SingleOrDefault(x => x.Id == manufacturer);
					updatedProduct.PriceBuy = pricebuy;
					updatedProduct.PriceSell = pricesell;
					updatedProduct.InStock = instock;
					context.SaveChanges();
				}
                catch
                {
					throw new Exception("B³¹d aktualizacji produktu: ");
                }
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
						IEnumerable<Product> products = context.Products
																.Include(x => x.Manufacturer)
																.Include(x => x.Tax)
																.Include(x => x.Type)
																.ToList()
																.FindAll(x => x.Manufacturer.Name.StartsWith(manufacturerName));
						return products;
					}
				}
				catch
				{
					throw new Exception("B³¹d pobierania produktów");
				}
			}
			else if(manufacturerId != null)
            {
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products
																.Include(x => x.Manufacturer)
																.Include(x => x.Tax)
																.Include(x => x.Type)
																.ToList()
																.FindAll(x => x.Manufacturer.Id == manufacturerId);
						return products;
					}
				}
				catch
				{
					throw new Exception("B³¹d pobierania produktów");
				}
			}
			else if(manufacturerNip != null)
            {
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products
																.Include(x => x.Manufacturer)
																.Include(x => x.Tax)
																.Include(x => x.Type)
																.ToList()
																.FindAll(x => x.Manufacturer.Nip == manufacturerNip);
						return products;
					}
				}
				catch
				{
					throw new Exception("B³¹d pobierania produktów");
				}
			}
            else
            {
				throw new Exception("B³¹d pobierania produktów");
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
						IEnumerable<Product> products = context.Products
																.Include(x => x.Manufacturer)
																.Include(x => x.Tax)
																.Include(x => x.Type)
																.ToList()
																.FindAll(x => x.Tax.Value == taxValue);
						return products;
					}
				}
				catch
				{
					throw new Exception("B³¹d pobierania produktów");
				}
			}
			else if(taxName != null)
            {
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products
																.Include(x => x.Manufacturer)
																.Include(x => x.Tax)
																.Include(x => x.Type)
																.ToList()
																.FindAll(x => x.Tax.Name.StartsWith(taxName));
						return products;
					}
				}
				catch
				{
					throw new Exception("B³¹d pobierania produktów");
				}
			}
			else if(taxId != null)
            {
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products
																.Include(x => x.Manufacturer)
																.Include(x => x.Tax)
																.Include(x => x.Type)
																.ToList()
																.FindAll(x => x.Tax.Id == taxId);
						return products;
					}
				}
				catch 
				{
					throw new Exception("B³¹d pobierania produktów");
				}
			}
            else
            {
				throw new Exception("B³¹d pobierania produktów");
			}

			
		}

        public IEnumerable<Product> GetProductsByName(string name)
        {
			try
			{
				using (WHManagerDBContext context = _contextFactory.CreateDbContext())
				{
					IEnumerable<Product> products = context.Products
																.Include(x => x.Manufacturer)
																.Include(x => x.Tax)
																.Include(x => x.Type)
																.ToList()
																.FindAll(x => x.Name.StartsWith(name));
					return products;
				}
			}
			catch
			{
				throw new Exception("B³¹d pobierania produktów");
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
						IEnumerable<Product> products = context.Products
																.Include(x => x.Manufacturer)
																.Include(x => x.Tax)
																.Include(x => x.Type)
																.ToList()
																.FindAll(x => x.Type.Name.StartsWith(productTypeName));
						return products;
					}
						
                }
				catch
                {
					throw new Exception("B³¹d pobierania produktów");
				}
            }
			else if(productTypeId != null)
            {
                try
                {
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                    {
						IEnumerable<Product> products = context.Products
																.Include(x => x.Manufacturer)
																.Include(x => x.Tax)
																.Include(x => x.Type)
																.ToList()
																.FindAll(x => x.Type.Id == productTypeId);
						return products;
					}

				}
				catch
                {
					throw new Exception("B³¹d pobierania produktów");
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
						IEnumerable<Product> products = context.Products
																	.Include(x => x.Manufacturer)
																	.Include(x => x.Tax)
																	.Include(x => x.Type)
																	.ToList()
																	.FindAll(x => x.PriceSell >= priceMin && x.PriceSell <= priceMax);
						return products;
					}

				}
				catch
				{
					throw new Exception("B³¹d pobierania produktów");
				}
			}
			else if(priceMin != null && priceMax == null)
            {
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products
																.Include(x => x.Manufacturer)
																.Include(x => x.Tax)
																.Include(x => x.Type)
																.ToList()
																.FindAll(x => x.PriceSell >= priceMin);
						return products;
					}

				}
				catch
				{
					throw new Exception("B³¹d pobierania produktów");
				}
			}
			else if(priceMin == null && priceMax != null)
            {
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products
																.Include(x => x.Manufacturer)
																.Include(x => x.Tax)
																.Include(x => x.Type)
																.ToList()
																.FindAll(x => x.PriceSell <= priceMax);
						return products;
					}

				}
				catch
				{
					throw new Exception("B³¹d pobierania produktów");
				}
			}
            else
            {
				throw new Exception("B³¹d pobierania produktów");
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
						IEnumerable<Product> products = context.Products
																.Include(x => x.Manufacturer)
																.Include(x => x.Tax)
																.Include(x => x.Type)
																.ToList()
																.FindAll(x => x.PriceBuy >= priceMin && x.PriceBuy <= priceMax);
						return products;
					}

				}
				catch
				{
					throw new Exception("B³¹d pobierania produktów");
				}
			}
			else if (priceMin != null && priceMax == null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products
																.Include(x => x.Manufacturer)
																.Include(x => x.Tax)
																.Include(x => x.Type)
																.ToList()
																.FindAll(x => x.PriceBuy >= priceMin);
						return products;
					}

				}
				catch
				{
					throw new Exception("B³¹d pobierania produktów");
				}
			}
			else if (priceMin == null && priceMax != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Product> products = context.Products
																.Include(x => x.Manufacturer)
																.Include(x => x.Tax)
																.Include(x => x.Type)
																.ToList()
																.FindAll(x => x.PriceBuy <= priceMax);
						return products;
					}

				}
				catch
				{
					throw new Exception("B³¹d pobierania produktów");
				}
			}
			else
			{
				throw new Exception("B³¹d pobierania produktów");
			}
		}

        public IEnumerable<Product> GetProductsInStock()
        {
            try
            {
				using(WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
					IEnumerable<Product> products = context.Products
																.Include(x => x.Manufacturer)
																.Include(x => x.Tax)
																.Include(x => x.Type)
																.ToList()
																.FindAll(x => x.InStock == true);
					return products;
                }
            }
			catch
            {
				throw new Exception("B³¹d pobierania produktów");
			}
        }

		public IEnumerable<Product> SearchProducts(List<string> criteria)
        {
			try
			{
				using (WHManagerDBContext context = _contextFactory.CreateDbContext())
				{
					IQueryable<Product> products = context.Products.AsQueryable()
																   .Include(x => x.Manufacturer)
																   .Include(x => x.Tax)
																   .Include(x => x.Type);
                    if (!string.IsNullOrEmpty(criteria[0]))
                    {
						if(int.TryParse(criteria[0], out int result))
                        {
							products = products.Where(p => p.Id == result);
                        }
                        else
                        {
							products = products.Where(p => p.Name.StartsWith(criteria[0]));
                        }
                    }
                    if (!string.IsNullOrEmpty(criteria[1]))
                    {
						products = products.Where(p => p.Type.Name.StartsWith(criteria[1]));
                    }
                    if (!string.IsNullOrEmpty(criteria[2]))
                    {
						products = products.Where(p => p.Manufacturer.Name.StartsWith(criteria[2]));
					}
					if (!string.IsNullOrEmpty(criteria[3]))
					{
						products = products.Where(p => p.Tax.Value == int.Parse(criteria[3]));
					}
					if (!string.IsNullOrEmpty(criteria[4]))
					{
						products = products.Where(p => p.PriceBuy >= decimal.Parse(criteria[4]));
					}
					if (!string.IsNullOrEmpty(criteria[5]))
					{
						products = products.Where(p => p.PriceBuy <= decimal.Parse(criteria[5]));
					}
					if (!string.IsNullOrEmpty(criteria[6]))
					{
						products = products.Where(p => p.PriceSell >= decimal.Parse(criteria[6]));
					}
					if (!string.IsNullOrEmpty(criteria[7]))
					{
						products = products.Where(p => p.PriceSell <= decimal.Parse(criteria[7]));
					}
					IEnumerable<Product> productsList = products.ToList();
					return productsList;
				}
			}
			catch
			{
				throw new Exception("B³¹d wyszukiwania produktów: ");
			}
		}

		public bool CheckIfProductInStock(int productId)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				if (context.Items.Any(x => x.Product.Id == productId))
				{
					return true;
				}
				return false;
			}
		}
    }	
}