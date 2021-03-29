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

        public void CreateNewProductType(ProductType productType)
        {
            try
            {
                string name = productType.Name;
                _productTypeRepository.AddProductType(name);
            }
            catch
            {
                throw new Exception("Błąd dodawania typu produktu: ");
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
            catch
            {
                throw new Exception("Błąd pobierania typu produktu: ");
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
            catch
            {
                throw new Exception("Błąd pobierania typu produktu: ");
            }
        }
		
		public void UpdateProductType(ProductType productType)
		{
            try
            {
                int id = productType.Id;
                string name = productType.Name;
                _productTypeRepository.UpdateProductType(id, name);
            }
            catch
            {
                throw new Exception("Błąd aktualizacji typu produktu: ");
            }
        }
		
		public void DeleteProductType(int id)
		{
            try
            {
                _productTypeRepository.DeleteProductType(id);
            }
            catch
            {
                throw new Exception("Błąd usuwania typu produktu: ");
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
            catch
            {
                throw new Exception("Błąd pobierania typu produktu: ");
            }
        }
    }
}