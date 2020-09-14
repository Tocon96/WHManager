using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddProductAsync(int id, string name, int producttype, int tax, int manufacturer);
        IEnumerable<Product> GetAllProducts();
        Task<Product> GetProductAsync(int id);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(int id, string name, int producttype, int tax, int manufacturer);
    }
}
