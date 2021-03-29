using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IProductTypeRepository
    {
        void AddProductType(string name);
        IEnumerable<ProductType> GetAllProductTypes();
        ProductType GetProductType(int id);
        void DeleteProductType(int id);
        void UpdateProductType(int id, string name);
        IEnumerable<ProductType> GetProductTypesByName(string name);

    }
}
