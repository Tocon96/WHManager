using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IProductTypeService
    {
        Task CreateNewProductType(ProductType productType);
        List<ProductType> GetProductTypes();
        Task<ProductType> GetProductType(int id);
        Task UpdateProductType(ProductType productType);
        Task DeleteManufacturer(int id);
    }
}
