using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IProductService
    {
        Task CreateNewProduct(Product product);
        List<Product> GetProducts();
        Task<Product> GetProduct(int id);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
