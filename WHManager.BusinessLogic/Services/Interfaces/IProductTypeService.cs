using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IProductTypeService
    {
        void CreateNewProductType(ProductType productType);
        IList<ProductType> GetProductTypes();
        ProductType GetProductType(int id);
        void UpdateProductType(ProductType productType);
        void DeleteProductType(int id);
        IList<ProductType> GetProductTypesByName(string name);
    }
}