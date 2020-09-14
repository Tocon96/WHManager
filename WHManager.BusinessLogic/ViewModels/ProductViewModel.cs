using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;

namespace WHManager.BusinessLogic.ViewModels
{
    public class ProductViewModel
    {
        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public ProductViewModel()
        {
            LoadData();
        }

        private List<Product> GetAll()
        {
            IProductService productService = new ProductService();
            List<Product> products = productService.GetProducts();
            return products;
        }

        private ObservableCollection<Product> LoadData()
        {
            List<Product> productsList = GetAll();
            Products = new ObservableCollection<Product>(productsList);
            return Products;
        }
    }
}