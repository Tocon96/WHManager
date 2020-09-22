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
        IList<Product> GetProducts();
        Product GetProduct(int id);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
        IList<Product> GetProductsByManufacturer(string manufacturerName = null, int? manufacturerId = null, double? manufacturerNip = null);
        IList<Product> GetProductsByTax(int? taxValue = null, string taxName = null, int? taxId = null);
        IList<Product> GetProductsByName(string name);
        IList<Product> GetProductsByType(string productTypeName = null, int? productTypeId = null);
        IList<Product> GetProductsByPriceSell(decimal? priceMin = null, decimal? priceMax = null);
        IList<Product> GetProductsByPriceBuy(decimal? priceMin = null, decimal? priceMax = null);
        IList<Product> GetProductsInStock();
    }
}
