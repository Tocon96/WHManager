using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository = new ProductRepository(new DataAccess.WHManagerDBContextFactory());
        private IProductTypeService productTypeService = new ProductTypeService();
        private IManufacturerService manufacturerService = new ManufacturerService();
        private ITaxService taxService = new TaxService();

        public async Task CreateNewProduct(Product product)
        {
            try
            {
                string name = product.Name;
                int productType = product.Type.Id;
                int tax = product.Tax.Id;
                int manufacturer = product.Manufacturer.Id;
                decimal pricebuy = product.PriceBuy;
                decimal pricesell = product.PriceSell;
                await _productRepository.AddProductAsync(name, productType, tax, manufacturer, pricebuy, pricesell);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IList<Product> GetProducts()
        {
            try
            {
                IList<Product> productsList = new List<Product>();
                var products = _productRepository.GetAllProducts();
                foreach (var product in products)
                {
                    Product currentProduct = new Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Type = productTypeService.GetProductType(product.Type.Id),
                        Tax = taxService.GetTax(product.Tax.Id),
                        Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                        PriceBuy = product.PriceBuy,
                        PriceSell = product.PriceSell
                    };
                    productsList.Add(currentProduct);
                }
                return productsList;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public Product GetProduct(int id)
        {
            try
            {
                var product = _productRepository.GetProduct(id);
                Product currentProduct = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Type = productTypeService.GetProductType(product.Type.Id),
                    Tax = taxService.GetTax(product.Tax.Id),
                    Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                    PriceBuy = product.PriceBuy,
                    PriceSell = product.PriceSell
                };

                return currentProduct;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateProduct(Product product)
        {
            try
            {
                int id = product.Id;
                string name = product.Name;
                int productType = product.Type.Id;
                int tax = product.Tax.Id;
                int manufacturer = product.Manufacturer.Id;
                decimal pricesell = product.PriceSell;
                decimal pricebuy = product.PriceBuy;
                await _productRepository.UpdateProductAsync(id, name, productType, tax, manufacturer, pricesell, pricebuy);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task DeleteProduct(int id)
        {
            try
            {
                await _productRepository.DeleteProductAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IList<Product> GetProductsByManufacturer(string manufacturerName = null, int? manufacturerId = null, double? manufacturerNip = null)
        {
            if (manufacturerName != null)
            {
                try
                {
                    IList<Product> productsList = new List<Product>();
                    var products = _productRepository.GetProductsByManufacturer(manufacturerName, null, null);
                    foreach (var product in products)
                    {
                        Product currentProduct = new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Type = productTypeService.GetProductType(product.Type.Id),
                            Tax = taxService.GetTax(product.Tax.Id),
                            Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                            PriceBuy = product.PriceBuy,
                            PriceSell = product.PriceSell
                        };
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (manufacturerId != null)
            {
                try
                {
                    IList<Product> productsList = new List<Product>();
                    var products = _productRepository.GetProductsByManufacturer(null, manufacturerId, null);
                    foreach (var product in products)
                    {
                        Product currentProduct = new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Type = productTypeService.GetProductType(product.Type.Id),
                            Tax = taxService.GetTax(product.Tax.Id),
                            Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                            PriceBuy = product.PriceBuy,
                            PriceSell = product.PriceSell
                        };
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (manufacturerNip != null)
            {
                try
                {
                    IList<Product> productsList = new List<Product>();
                    var products = _productRepository.GetProductsByManufacturer(null, null, manufacturerNip);
                    foreach (var product in products)
                    {
                        Product currentProduct = new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Type = productTypeService.GetProductType(product.Type.Id),
                            Tax = taxService.GetTax(product.Tax.Id),
                            Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                            PriceBuy = product.PriceBuy,
                            PriceSell = product.PriceSell
                        };
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }

        }
        public IList<Product> GetProductsByTax(int? taxValue = null, string taxName = null, int? taxId = null)
        {
            if (taxValue != null)
            {
                try
                {
                    IList<Product> productsList = new List<Product>();
                    var products = _productRepository.GetProductsByTax(taxValue, null, null);
                    foreach (var product in products)
                    {
                        Product currentProduct = new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Type = productTypeService.GetProductType(product.Type.Id),
                            Tax = taxService.GetTax(product.Tax.Id),
                            Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                            PriceBuy = product.PriceBuy,
                            PriceSell = product.PriceSell
                        };
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (taxName != null)
            {
                try
                {
                    IList<Product> productsList = new List<Product>();
                    var products = _productRepository.GetProductsByTax(null, taxName, null);
                    foreach (var product in products)
                    {
                        Product currentProduct = new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Type = productTypeService.GetProductType(product.Type.Id),
                            Tax = taxService.GetTax(product.Tax.Id),
                            Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                            PriceBuy = product.PriceBuy,
                            PriceSell = product.PriceSell
                        };
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (taxId != null)
            {
                try
                {
                    IList<Product> productsList = new List<Product>();
                    var products = _productRepository.GetProductsByTax(null, null, taxId);
                    foreach (var product in products)
                    {
                        Product currentProduct = new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Type = productTypeService.GetProductType(product.Type.Id),
                            Tax = taxService.GetTax(product.Tax.Id),
                            Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                            PriceBuy = product.PriceBuy,
                            PriceSell = product.PriceSell
                        };
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public IList<Product> GetProductsByName(string name)
        {
            try
            {
                IList<Product> productsList = new List<Product>();
                var products = _productRepository.GetProductsByName(name);
                foreach (var product in products)
                {
                    Product currentProduct = new Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Type = productTypeService.GetProductType(product.Type.Id),
                        Tax = taxService.GetTax(product.Tax.Id),
                        Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                        PriceBuy = product.PriceBuy,
                        PriceSell = product.PriceSell
                    };
                    productsList.Add(currentProduct);
                }
                return productsList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IList<Product> GetProductsByType(string productTypeName = null, int? productTypeId = null)
        {
            if (productTypeName != null)
            {
                try
                {
                    IList<Product> productsList = new List<Product>();
                    var products = _productRepository.GetProductsByType(productTypeName, null);
                    foreach (var product in products)
                    {
                        Product currentProduct = new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Type = productTypeService.GetProductType(product.Type.Id),
                            Tax = taxService.GetTax(product.Tax.Id),
                            Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                            PriceBuy = product.PriceBuy,
                            PriceSell = product.PriceSell
                        };
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (productTypeId != null)
            {
                try
                {
                    IList<Product> productsList = new List<Product>();
                    var products = _productRepository.GetProductsByType(null, productTypeId);
                    foreach (var product in products)
                    {
                        Product currentProduct = new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Type = productTypeService.GetProductType(product.Type.Id),
                            Tax = taxService.GetTax(product.Tax.Id),
                            Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                            PriceBuy = product.PriceBuy,
                            PriceSell = product.PriceSell
                        };
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public IList<Product> GetProductsByPriceSell(decimal? priceMin = null, decimal? priceMax = null)
        {
            if (priceMin != null && priceMax != null)
            {
                try
                {
                    IList<Product> productsList = new List<Product>();
                    var products = _productRepository.GetProductsByPriceSell(priceMin, priceMax);
                    foreach (var product in products)
                    {
                        Product currentProduct = new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Type = productTypeService.GetProductType(product.Type.Id),
                            Tax = taxService.GetTax(product.Tax.Id),
                            Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                            PriceBuy = product.PriceBuy,
                            PriceSell = product.PriceSell
                        };
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (priceMin != null && priceMax == null)
            {
                try
                {
                    IList<Product> productsList = new List<Product>();
                    var products = _productRepository.GetProductsByPriceSell(priceMin, null);
                    foreach (var product in products)
                    {
                        Product currentProduct = new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Type = productTypeService.GetProductType(product.Type.Id),
                            Tax = taxService.GetTax(product.Tax.Id),
                            Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                            PriceBuy = product.PriceBuy,
                            PriceSell = product.PriceSell
                        };
                        productsList.Add(currentProduct);
                    }
                    return productsList;

                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (priceMin == null && priceMax != null)
            {
                try
                {
                    IList<Product> productsList = new List<Product>();
                    var products = _productRepository.GetProductsByPriceSell(null, priceMax);
                    foreach (var product in products)
                    {
                        Product currentProduct = new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Type = productTypeService.GetProductType(product.Type.Id),
                            Tax = taxService.GetTax(product.Tax.Id),
                            Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                            PriceBuy = product.PriceBuy,
                            PriceSell = product.PriceSell
                        };
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public IList<Product> GetProductsByPriceBuy(decimal? priceMin = null, decimal? priceMax = null)
        {
            if (priceMin != null && priceMax != null)
            {
                try
                {
                    IList<Product> productsList = new List<Product>();
                    var products = _productRepository.GetProductsByPriceBuy(priceMin, priceMax);
                    foreach (var product in products)
                    {
                        Product currentProduct = new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Type = productTypeService.GetProductType(product.Type.Id),
                            Tax = taxService.GetTax(product.Tax.Id),
                            Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                            PriceBuy = product.PriceBuy,
                            PriceSell = product.PriceSell
                        };
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (priceMin != null && priceMax == null)
            {
                try
                {
                    IList<Product> productsList = new List<Product>();
                    var products = _productRepository.GetProductsByPriceBuy(priceMin, null);
                    foreach (var product in products)
                    {
                        Product currentProduct = new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Type = productTypeService.GetProductType(product.Type.Id),
                            Tax = taxService.GetTax(product.Tax.Id),
                            Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                            PriceBuy = product.PriceBuy,
                            PriceSell = product.PriceSell
                        };
                        productsList.Add(currentProduct);
                    }
                    return productsList;

                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (priceMin == null && priceMax != null)
            {
                try
                {
                    IList<Product> productsList = new List<Product>();
                    var products = _productRepository.GetProductsByPriceBuy(null, priceMax);
                    foreach (var product in products)
                    {
                        Product currentProduct = new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Type = productTypeService.GetProductType(product.Type.Id),
                            Tax = taxService.GetTax(product.Tax.Id),
                            Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                            PriceBuy = product.PriceBuy,
                            PriceSell = product.PriceSell
                        };
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public IList<Product> GetProductsInStock()
        {
            try
            {
                IList<Product> productsList = new List<Product>();
                var products = _productRepository.GetProductsInStock();
                foreach (var product in products)
                {
                    Product currentProduct = new Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Type = productTypeService.GetProductType(product.Type.Id),
                        Tax = taxService.GetTax(product.Tax.Id),
                        Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                        PriceBuy = product.PriceBuy,
                        PriceSell = product.PriceSell
                    };
                    productsList.Add(currentProduct);
                }
                return productsList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal CalculatePrice(Product product)
        {

            decimal tax = (Convert.ToDecimal(product.Tax.Value) / 100);
            decimal finalPrice = Math.Round(product.PriceSell + (product.PriceSell * tax), 2);
            return finalPrice;
        }
    }
}