using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CreateNewProduct(Product product)
        { 
            try
            {
                string name = product.Name;
                int productType = product.Type.Id;
                int tax = product.Tax.Id;
                int manufacturer = product.Manufacturer.Id;
                decimal pricebuy = product.PriceBuy;
                decimal pricesell = product.PriceSell;
                _productRepository.AddProduct(name, productType, tax, manufacturer, pricebuy, pricesell);
            }
            catch (Exception)
            {
                throw new Exception("Błąd dodawania");
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
                        PriceSell = product.PriceSell,
                        InStock = product.InStock
                    };
                    productsList.Add(currentProduct);
                }
                return productsList;
            }
            catch (Exception)
            {
                throw new Exception("Błąd pobierania produktów.");
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
                    PriceSell = product.PriceSell,
                    InStock = product.InStock
                };

                return currentProduct;
            }
            catch (Exception)
            {
                throw new Exception ("Błąd pobierania produktu.");
            }
        }
        public void UpdateProduct(Product product)
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
                bool inStock = product.InStock;
                _productRepository.UpdateProduct(id, name, productType, tax, manufacturer, pricesell, pricebuy, inStock);
            }
            catch (Exception)
            {
                throw new Exception("Błąd aktualizacji produktu.");
            }

        }
        public void DeleteProduct(int id)
        {
            try
            {
                _productRepository.DeleteProduct(id);
            }
            catch (Exception)
            {
                throw new Exception("Błąd usuwania produktu.");
            }
        }
        public IList<Product> GetProductsByManufacturer(string manufacturerName = null)
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
                    throw new Exception("Błąd producenta produktu.");
                }
            }
            else
            {
                throw new Exception("Nazwa producenta nie może być pusta.");
            }
        }
        public IList<Product> GetProductsByTax(int? taxValue = null)
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
                    throw new Exception("Błąd podatku produktu.");
                }
            }
            else
            {
                throw new Exception("Wartość podatku nie może być pusta.");
            }
        }
        public IList<Product> GetProductsByName(string name)
        {
            if(name != null)
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
            else
            {
                throw new Exception("Nazwa produktu nie może być pusta.");
            }
        }
        public IList<Product> GetProductsByType(string productTypeName)
        {
            if(productTypeName != null)
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
                    throw new Exception("Błąd typu produktu.");
                }
            }
            throw new Exception("Typ produktu nie może być pusty.");
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
        public IList<Product> SearchProducts(List<string> criteria)
        {
            IList<Product> products = new List<Product>();
            if (criteria[0] != "")
            {
                if (int.TryParse(criteria[0], out int id))
                {
                    products.Add(GetProduct(id));
                }
                else
                {
                    IList<Product> productsList = new List<Product>();
                    productsList = GetProductsByName(criteria[0]);
                    foreach (var product in productsList)
                    {
                        products.Add(product);
                    }
                    productsList = null;
                }
            }

            if (criteria[1] != "Wszystkie")
            {
                IList<Product> productsList = new List<Product>();
                productsList = GetProductsByType(criteria[1]);
                foreach (var product in productsList)
                {
                    products.Add(product);
                }
                productsList = null;
            }

            if (criteria[2] != "Wszystkie")
            {
                IList<Product> productsList = new List<Product>();
                productsList = GetProductsByManufacturer(criteria[2]);
                foreach (var product in productsList)
                {
                    products.Add(product);
                }
                productsList = null;
            }

            if (criteria[3] != "Wszystkie")
            {
                IList<Product> productsList = new List<Product>();
                productsList = GetProductsByTax(int.Parse(criteria[3]));
                foreach (var product in productsList)
                {
                    products.Add(product);
                }
                productsList = null;
            }

            if (criteria[4] != "" || criteria[5] != "")
            {
                IList<Product> productsList = new List<Product>();
                if(criteria[4] != "" && criteria[5] == "")
                {
                    if(decimal.TryParse(criteria[4], out decimal result))
                    {
                        productsList = GetProductsByPriceBuy(result);
                        foreach (var product in productsList)
                        {
                            products.Add(product);
                        }
                        productsList = null;
                    }
                    else
                    {
                        throw new Exception("Wstaw poprawną cenę minimalną");
                    }
                }
                else if(criteria[4] == "" && criteria[5] != "")
                {
                    if (decimal.TryParse(criteria[5], out decimal result))
                    {
                        productsList = GetProductsByPriceBuy(null, result);
                        foreach (var product in productsList)
                        {
                            products.Add(product);
                        }
                        productsList = null;
                    }
                    else
                    {
                        throw new Exception("Wstaw poprawną cenę maksymalną");
                    }
                }
                else if (criteria[4] != "" && criteria[5] != "")
                {
                    if (decimal.TryParse(criteria[4], out decimal minResult))
                    {
                        if (decimal.TryParse(criteria[5], out decimal maxResult))
                        {
                            productsList = GetProductsByPriceBuy(minResult, maxResult);
                            foreach (var product in productsList)
                            {
                                products.Add(product);
                            }
                            productsList = null;
                        }
                        else
                        {
                            throw new Exception("Wstaw poprawną cenę maksymalną");
                        }
                    }
                    else
                    {
                        throw new Exception("Wstaw poprawną cenę minimalną");
                    }
                }
            }

            if (criteria[6] != "" || criteria[7] != "")
            {
                IList<Product> productsList = new List<Product>();
                if (criteria[6] != "" && criteria[7] == "")
                {
                    if (decimal.TryParse(criteria[6], out decimal result))
                    {
                        productsList = GetProductsByPriceBuy(result);
                        foreach (var product in productsList)
                        {
                            products.Add(product);
                        }
                        productsList = null;
                    }
                    else
                    {
                        throw new Exception("Wstaw poprawną cenę minimalną");
                    }
                }
                else if (criteria[6] == "" && criteria[7] != "")
                {
                    if (decimal.TryParse(criteria[7], out decimal result))
                    {
                        productsList = GetProductsByPriceBuy(null, result);
                        foreach (var product in productsList)
                        {
                            products.Add(product);
                        }
                        productsList = null;
                    }
                    else
                    {
                        throw new Exception("Wstaw poprawną cenę maksymalną");
                    }
                }
                else if (criteria[6] != "" && criteria[7] != "")
                {
                    if (decimal.TryParse(criteria[6], out decimal minResult))
                    {
                        if (decimal.TryParse(criteria[7], out decimal maxResult))
                        {
                            productsList = GetProductsByPriceBuy(minResult, maxResult);
                            foreach (var product in productsList)
                            {
                                products.Add(product);
                            }
                            productsList = null;
                        }
                        else
                        {
                            throw new Exception("Wstaw poprawną cenę maksymalną");
                        }
                    }
                    else
                    {
                        throw new Exception("Wstaw poprawną cenę minimalną");
                    }
                }
            }
            products = sortProducts(products);
            products = checkProducts(products, criteria);
            return products;
        }
        public decimal CalculatePrice(Product product)
        {

            decimal tax = (Convert.ToDecimal(product.Tax.Value) / 100);
            decimal finalPrice = Math.Round(product.PriceSell + (product.PriceSell * tax), 2);
            return finalPrice;
        }
        public IList<Product> sortProducts(IList<Product> unsortedProductList)
        {
            IList<Product> sortedProductList = unsortedProductList.OrderBy(i => i.Id).ToList();
            IList<Product> products = new List<Product>();
            Product previousProduct = new Product{ Id = 0 };
            foreach(Product product in sortedProductList)
            {
                if(product.Id != previousProduct.Id)
                {
                    products.Add(product);
                }
                previousProduct = product;
            }
            return products;
        }
        public IList<Product> checkProducts(IList<Product> uncheckedProducts, List<string> criteria)
        {
            IList<Product> products = new List<Product>();
            foreach(Product product in uncheckedProducts)
            {
                if(int.TryParse(criteria[0], out int result))
                {
                    if(criteria[0] != "")
                    {
                        if (product.Id != result)
                        {
                            continue;
                        }
                    }

                    if(criteria[1] != "Wszystkie")
                    {
                        if (product.Type.Name != criteria[1])
                        {
                            continue;
                        }
                    }

                    if(criteria[2] != "Wszystkie")
                    {
                        if (product.Manufacturer.Name != criteria[2])
                        {
                            continue;
                        }
                    }
                    
                    if(criteria[3] != "Wszystkie")
                    {
                        if (product.Tax.Value != int.Parse(criteria[3]))
                        {
                            continue;
                        }
                    }
                    
                    if(criteria[4] != "" || criteria[5] != "")
                    {
                        if (decimal.Parse(criteria[4]) > product.PriceBuy || product.PriceBuy > decimal.Parse(criteria[5]))
                        {
                            continue;
                        }
                    }

                    if(criteria[6] != "" || criteria[7] != "")
                    {
                        if (decimal.Parse(criteria[6]) > product.PriceBuy || product.PriceBuy > decimal.Parse(criteria[7]))
                        {
                            continue;
                        }
                    }
                    products.Add(product);
                }
                else
                {
                    if (criteria[0] != "")
                    {
                        if (product.Name != criteria[0])
                        {
                            continue;
                        }
                    }

                    if (criteria[1] != "Wszystkie")
                    {
                        if (product.Type.Name != criteria[1])
                        {
                            continue;
                        }
                    }

                    if (criteria[2] != "Wszystkie")
                    {
                        if (product.Manufacturer.Name != criteria[2])
                        {
                            continue;
                        }
                    }

                    if (criteria[3] != "Wszystkie")
                    {
                        if (product.Tax.Value != int.Parse(criteria[3]))
                        {
                            continue;
                        }
                    }

                    if (criteria[4] != "" || criteria[5] != "")
                    {
                        if (decimal.Parse(criteria[4]) > product.PriceBuy || product.PriceBuy > decimal.Parse(criteria[5]))
                        {
                            continue;
                        }
                    }

                    if (criteria[6] != "" || criteria[7] != "")
                    {
                        if (decimal.Parse(criteria[6]) > product.PriceBuy || product.PriceBuy > decimal.Parse(criteria[7]))
                        {
                            continue;
                        }
                    }
                    products.Add(product);
                }
            }
            return products;
        }
    }
}