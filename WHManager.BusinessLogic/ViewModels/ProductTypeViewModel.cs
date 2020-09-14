using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;

namespace WHManager.BusinessLogic.ViewModels
{
    public class ProductTypeViewModel
    {
        private ObservableCollection<ProductType> _productTypes;

        public ObservableCollection<ProductType> ProductTypes
        {
            get { return _productTypes; }
            set { _productTypes = value; }
        }

        public ProductTypeViewModel()
        {
            LoadData();
        }

        private List<ProductType> GetAll()
        {
            IProductTypeService productTypeService = new ProductTypeService();
            List<ProductType> productTypes = productTypeService.GetProductTypes();
            return productTypes;
        }

        private ObservableCollection<ProductType> LoadData()
        {
            List<ProductType> productTypesList = GetAll();
            ProductTypes = new ObservableCollection<ProductType>(productTypesList);
            return ProductTypes;
        }
    }
}