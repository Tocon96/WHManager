using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            catch(Exception)
            {
                throw;
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
            catch(Exception)
            {
                throw;
            }
        }

        public ProductType GetProductType(int id)
		{
            try
            {
                var productType =  _productTypeRepository.GetProductType(id);
                if(productType != null)
                {
                    ProductType currentProductType = new ProductType
                    {
                        Id = productType.Id,
                        Name = productType.Name,
                    };
                    return currentProductType;
                }
                else
                {
                    return null;
                }
            }   
            catch(Exception)
            {
                throw;
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
			catch(Exception)
            {
                throw;
            }
		}
		
		public async Task DeleteProductType(int id)
		{
            try
            {
                await _productTypeRepository.DeleteProductTypeAsync(id);
            }
			catch(Exception)
            {
                throw;
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
            catch(Exception)
            {
                throw;
            }
        }
    }
}