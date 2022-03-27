using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.BusinessLogic.Services.ReportsServices;
using WHManager.BusinessLogic.Services.ReportsServices.Interfaces;
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
        private IProductReportsService reportService = new ProductReportsService();

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
                        InStock = product.InStock,
                        ItemInWarehouseCount = product.Items.Count(x => !x.OrderId.HasValue)
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
        public IList<Product> GetProduct(int id)
        {
            try
            {
                var products = _productRepository.GetProduct(id);
                IList<Product> currentProducts = new List<Product>();
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
                        InStock = product.InStock,
                        ItemInWarehouseCount = product.Items.Count(x => !x.OrderId.HasValue)
                    };
                    currentProducts.Add(currentProduct);
                }


                return currentProducts;
            }
            catch (Exception)
            {
                throw new Exception("Błąd pobierania produktu.");
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
                reportService.DeleteReportsByProduct(id);
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
                            PriceSell = product.PriceSell,
                            ItemInWarehouseCount = product.Items.Count(x => !x.OrderId.HasValue)
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

        public IList<Product> GetProductsByManufacturerId(IList<Delivery> deliveries, IList<Order> orders, int manufacturerId)
        {
            try
            {
                IList<Item> items = new List<Item>();
                foreach(Delivery delivery in deliveries)
                {
                    foreach(Item item in delivery.Items)
                    {
                        items.Add(item);
                    }
                }

                HashSet<int> orderIds = new HashSet<int>();
                foreach (Order order in orders)
                {
                    orderIds.Add(order.Id);
                }

                var grouped = items.Where(x => x.Product.Manufacturer.Id == manufacturerId).OrderBy(x => x.Product.Id).GroupBy(x => x.Product.Id);
                IList <Product> products = new List<Product>();
                foreach (var group in grouped)
                {
                    Product product = GetProduct(group.Key)[0];
                    product.ItemsDeliveredCount = GetCountOfItemsDelivered(items, group.Key);
                    product.ItemsOrderedCount = GetCountOfItemsOrdered(items, orderIds, group.Key);
                    product.Balance = GetBalanceForProductList(items, orderIds, group.Key);
                    products.Add(product);

                }
                return products;
            }
            catch (Exception)
            {
                throw new Exception("Błąd producenta produktu.");
            }
        }

        private decimal GetBalanceForProductList(IList<Item> itemsDelivered, HashSet<int> orders, int productId)
        {
            decimal totalBuy = itemsDelivered.Where(x => x.Product.Id == productId).Sum(x => x.Product.PriceBuy + ((x.Product.Tax.Value / 100) * x.Product.PriceBuy));
            decimal totalSell = itemsDelivered.Where(x => x.OrderId.HasValue && orders.Contains(x.OrderId.Value) && x.Product.Id == productId).Sum(x => x.Product.PriceSell + ((x.Product.Tax.Value / 100) * x.Product.PriceSell));
            decimal balance = totalSell - totalBuy;

            return balance;
        }

        private int GetCountOfItemsDelivered(IList<Item> items, int productId)
        {
            return items.Count(x => x.Product.Id == productId);
        }

        private int GetCountOfItemsOrdered(IList<Item> items, HashSet<int> orders, int productId)
        {

            items = items.Where(x => x.OrderId.HasValue && orders.Contains(x.OrderId.Value) && x.Product.Id == productId).ToList();
            return items.Count();
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
            if (name != null)
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
            var productsList = _productRepository.SearchProducts(criteria);
            foreach(var product in productsList)
            {
                Product newProduct = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Type = productTypeService.GetProductType(product.Type.Id),
                    Tax = taxService.GetTax(product.Tax.Id),
                    Manufacturer = manufacturerService.GetManufacturer(product.Manufacturer.Id),
                    PriceBuy = product.PriceBuy,
                    PriceSell = product.PriceSell,
                    InStock = product.InStock,
                    ItemInWarehouseCount = product.Items.Count(x => !x.OrderId.HasValue)
                };
                products.Add(newProduct);
            }
            return products;
        }
        public decimal CalculatePrice(Product product)
        {
            decimal tax = (Convert.ToDecimal(product.Tax.Value) / 100);
            decimal finalPrice = Math.Round(product.PriceSell + (product.PriceSell * tax), 2);
            return finalPrice;
        }

        public IList<Product> GetProductsByTypeId(IList<Delivery> deliveries, IList<Order> orders, int typeId)
        {
            IList<Item> items = new List<Item>();
            foreach (Delivery delivery in deliveries)
            {
                foreach (Item item in delivery.Items)
                {
                    items.Add(item);
                }
            }

            HashSet<int> orderIds = new HashSet<int>();
            foreach (Order order in orders)
            {
                orderIds.Add(order.Id);
            }

            var grouped = items.Where(x => x.Product.Type.Id == typeId).OrderBy(x => x.Product.Id).GroupBy(x => x.Product.Id);
            IList<Product> products = new List<Product>();
            foreach (var group in grouped)
            {
                Product product = GetProduct(group.Key)[0];
                product.ItemsDeliveredCount = GetCountOfItemsDelivered(items, group.Key);
                product.ItemsOrderedCount = GetCountOfItemsOrdered(items, orderIds, group.Key);
                product.Balance = GetBalanceForProductList(items, orderIds, group.Key);
                products.Add(product);

            }
            return products;

        }
    }
}