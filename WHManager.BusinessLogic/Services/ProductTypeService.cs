using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository = new ProductTypeRepository(new DataAccess.WHManagerDBContextFactory());

        public async Task CreateNewProductType(ProductType productType)
        {
            try
            {
                string name = productType.Name;
                await _productTypeRepository.AddProductTypeAsync(name);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IList<ProductType> GetProductTypes()
        {
            try
            {
                IList<ProductType> productTypesList = new List<ProductType>();
                var productTypes = _productTypeRepository.GetAllProductTypes().ToList();
                foreach (var productType in productTypes)
                {
                    ProductType currentProductType = new ProductType
                    {
                        Id = productType.Id,
                        Name = productType.Name,
                    };
                    productTypesList.Add(currentProductType);
                }
                return productTypesList;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
		
		public async Task<ProductType> GetProductType(int id)
		{
            try
            {
                var productType = await _productTypeRepository.GetProductTypeAsync(id);
                ProductType currentProductType = new ProductType
                {
                    Id = productType.Id,
                    Name = productType.Name,
                };
                return currentProductType;
            }   
            catch(Exception e)
            {
                throw e;
            }
		}
		
		public async Task UpdateProductType(ProductType productType)
		{
            try
            {
                int id = productType.Id;
                string name = productType.Name;
                await _productTypeRepository.UpdateProductTypeAsync(id, name);
            }
			catch(Exception e)
            {
                throw e;
            }
		}
		
		public async Task DeleteProductType(int id)
		{
            try
            {
                await _productTypeRepository.DeleteProductTypeAsync(id);
            }
			catch(Exception e)
            {
                throw e;
            }
		}
		
        public IList<ProductType> GetProductTypesByName(string name)
        {
            try
            {
                IList<ProductType> productTypesList = new List<ProductType>();
                var productTypes = _productTypeRepository.GetProductTypesByName(name);
                foreach (var productType in productTypes)
                {
                    ProductType currentProductType = new ProductType
                    {
                        Id = productType.Id,
                        Name = productType.Name,
                    };
                    productTypesList.Add(currentProductType);
                }
                return productTypesList;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}