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

		public void AddProductType(string name)
		{
			ProductType newProductType = new ProductType
			{
				Name = name,
			};
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					context.ProductTypes.Add(newProductType);
					context.SaveChanges();
				}
                catch
                {
					throw new Exception("B³¹d dodawania typu produktu: ");
                }
			}
		}

		public IEnumerable<ProductType> GetAllProductTypes()
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					IEnumerable<ProductType> productTypes = context.ProductTypes.ToList();
					return productTypes;
				}
                catch
                {
					throw new Exception("B³¹d pobierania typów produktów: ");
                }
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
			catch
            {
				throw new Exception("B³¹d pobierania typów produktów: ");
			}
			
		}
		public void DeleteProductType(int id)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					context.Remove(context.ProductTypes.SingleOrDefault(x => x.Id == id));
					context.SaveChanges();
				}
                catch
                {
					throw new Exception("B³¹d usuwania typu produktu: ");
                }
				
			}
		}
		public void UpdateProductType(int id, string name)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					ProductType updatedProductType = context.ProductTypes.SingleOrDefault(x => x.Id == id);
					updatedProductType.Name = name;
					context.SaveChanges();
				}
                catch
                {
					throw new Exception("B³¹d aktualizacji typu produktu");
                }
			}
		}

		public IEnumerable<ProductType> GetProductTypesByName(string name)
        {
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				try
				{
					IEnumerable<ProductType> productTypes = context.ProductTypes.ToList().FindAll(x => x.Name.StartsWith(name));
					return productTypes;
				}
				catch
				{
					throw new Exception("B³¹d pobierania typów produktu");
				}
			}
			
		}
	}
}