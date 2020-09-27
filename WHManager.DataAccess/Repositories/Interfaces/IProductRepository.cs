using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddProductAsync(string name, int producttype, int tax, int manufacturer, decimal pricebuy, decimal pricesell);
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(int id, string name, int producttype, int tax, int manufacturer, decimal pricesell, decimal pricebuy);
        IEnumerable<Product> GetProductsByManufacturer(string manufacturerName = null, int? manufacturerId = null, double? manufacturerNip = null);
        IEnumerable<Product> GetProductsByTax(int? taxValue = null, string taxName = null, int? taxId = null);
        IEnumerable<Product> GetProductsByName(string name);
        IEnumerable<Product> GetProductsByType(string productTypeName = null, int? productTypeId = null);
        IEnumerable<Product> GetProductsByPriceSell(decimal? priceMin = null, decimal? priceMax = null);
        IEnumerable<Product> GetProductsByPriceBuy(decimal? priceMin = null, decimal? priceMax = null);
        IEnumerable<Product> GetProductsInStock();

    }
}
