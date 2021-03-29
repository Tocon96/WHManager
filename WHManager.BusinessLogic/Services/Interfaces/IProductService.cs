using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IProductService
    {
        void CreateNewProduct(Product product);
        IList<Product> GetProducts();
        Product GetProduct(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        IList<Product> GetProductsByManufacturer(string manufacturerName = null);
        IList<Product> GetProductsByTax(int? taxValue = null);
        IList<Product> GetProductsByName(string name);
        IList<Product> GetProductsByType(string productTypeName);
        IList<Product> GetProductsByPriceSell(decimal? priceMin = null, decimal? priceMax = null);
        IList<Product> GetProductsByPriceBuy(decimal? priceMin = null, decimal? priceMax = null);
        IList<Product> GetProductsInStock();
        IList<Product> SearchProducts(List<string> criteria);
        decimal CalculatePrice(Product product);
    }
}
