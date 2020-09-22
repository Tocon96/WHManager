using System;
using System.Collections.Generic;
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

        public async Task CreateNewProduct(Product product)
        {
            try
            {
                int id = product.Id;
                string name = product.Name;
                int productType = product.Type.Id;
                int tax = product.Tax.Id;
                int manufacturer = product.Manufacturer.Id;
                await _productRepository.AddProductAsync(id, name, productType, tax, manufacturer);
            }
            catch (Exception e)
            {
                throw e;
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
                    };
                    currentProduct.Type.Id = product.Type.Id;
                    currentProduct.Tax.Id = product.Tax.Id;
                    currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                    productsList.Add(currentProduct);
                }
                return productsList;
            }
            catch (Exception e)
            {
                throw e;
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
                };
                currentProduct.Type.Id = product.Type.Id;
                currentProduct.Tax.Id = product.Tax.Id;
                currentProduct.Manufacturer.Id = product.Manufacturer.Id;

                return currentProduct;
            }
            catch (Exception e)
            {
                throw e;
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
                await _productRepository.UpdateProductAsync(id, name, productType, tax, manufacturer);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public async Task DeleteProduct(int id)
        {
            try
            {
                await _productRepository.DeleteProductAsync(id);
            }
            catch (Exception e)
            {
                throw e;
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
                        };
                        currentProduct.Type.Id = product.Type.Id;
                        currentProduct.Tax.Id = product.Tax.Id;
                        currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception e)
                {
                    throw e;
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
                        };
                        currentProduct.Type.Id = product.Type.Id;
                        currentProduct.Tax.Id = product.Tax.Id;
                        currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception e)
                {
                    throw e;
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
                        };
                        currentProduct.Type.Id = product.Type.Id;
                        currentProduct.Tax.Id = product.Tax.Id;
                        currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception e)
                {
                    throw e;
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
                        };
                        currentProduct.Type.Id = product.Type.Id;
                        currentProduct.Tax.Id = product.Tax.Id;
                        currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception e)
                {
                    throw e;
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
                        };
                        currentProduct.Type.Id = product.Type.Id;
                        currentProduct.Tax.Id = product.Tax.Id;
                        currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception e)
                {
                    throw e;
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
                        };
                        currentProduct.Type.Id = product.Type.Id;
                        currentProduct.Tax.Id = product.Tax.Id;
                        currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception e)
                {
                    throw e;
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
                    };
                    currentProduct.Type.Id = product.Type.Id;
                    currentProduct.Tax.Id = product.Tax.Id;
                    currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                    productsList.Add(currentProduct);
                }
                return productsList;
            }
            catch (Exception e)
            {
                throw e;
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
                        };
                        currentProduct.Type.Id = product.Type.Id;
                        currentProduct.Tax.Id = product.Tax.Id;
                        currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception e)
                {
                    throw e;
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
                        };
                        currentProduct.Type.Id = product.Type.Id;
                        currentProduct.Tax.Id = product.Tax.Id;
                        currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception e)
                {
                    throw e;
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
                        };
                        currentProduct.Type.Id = product.Type.Id;
                        currentProduct.Tax.Id = product.Tax.Id;
                        currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception e)
                {
                    throw e;
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
                        };
                        currentProduct.Type.Id = product.Type.Id;
                        currentProduct.Tax.Id = product.Tax.Id;
                        currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                        productsList.Add(currentProduct);
                    }
                    return productsList;

                }
                catch (Exception e)
                {
                    throw e;
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
                        };
                        currentProduct.Type.Id = product.Type.Id;
                        currentProduct.Tax.Id = product.Tax.Id;
                        currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception e)
                {
                    throw e;
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
                        };
                        currentProduct.Type.Id = product.Type.Id;
                        currentProduct.Tax.Id = product.Tax.Id;
                        currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception e)
                {
                    throw e;
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
                        };
                        currentProduct.Type.Id = product.Type.Id;
                        currentProduct.Tax.Id = product.Tax.Id;
                        currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                        productsList.Add(currentProduct);
                    }
                    return productsList;

                }
                catch (Exception e)
                {
                    throw e;
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
                        };
                        currentProduct.Type.Id = product.Type.Id;
                        currentProduct.Tax.Id = product.Tax.Id;
                        currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                        productsList.Add(currentProduct);
                    }
                    return productsList;
                }
                catch (Exception e)
                {
                    throw e;
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
                    };
                    currentProduct.Type.Id = product.Type.Id;
                    currentProduct.Tax.Id = product.Tax.Id;
                    currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                    productsList.Add(currentProduct);
                }
                return productsList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}   