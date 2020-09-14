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
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository = new ProductTypeRepository(new DataAccess.WHManagerDBContextFactory());

        public async Task CreateNewProductType(ProductType productType)
        {
            int id = productType.Id;
            string name = productType.Name;
            await _productTypeRepository.AddProductTypeAsync(id, name);
        }

        public List<ProductType> GetProductTypes()
        {
            List<ProductType> productTypesList = new List<ProductType>();
            var productTypes = _productTypeRepository.GetAllProductTypes();
            foreach(var productType in productTypes)
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
		
		public async Task<ProductType> GetProductType(int id)
		{
			var productType = await _productTypeRepository.GetProductTypeAsync(id);
            ProductType currentProductType = new ProductType
            {
                Id = productType.Id,
                Name = productType.Name,
            };
			return currentProductType;
		}
		
		public async Task UpdateProductType(ProductType productType)
		{
			int id = productType.Id;
            string name = productType.Name;
            await _productTypeRepository.UpdateProductTypeAsync(id, name);
		}
		
		public async Task DeleteManufacturer(int id)
		{
			await _productTypeRepository.DeleteProductTypeAsync(id);
		}
		
    }
}