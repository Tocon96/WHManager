using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DesktopUI.Views.FormViews;

namespace WHManager.DesktopUI.Views.WarehouseViews
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        IProductService productService = new ProductService();

        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public ProductView()
        {
            InitializeComponent();
            ProductGrid.ItemsSource = LoadData();
        }

        private void AddProductClick(object sender, RoutedEventArgs e)
        {
            AddProductFormView addProductForm = new AddProductFormView();
            addProductForm.Show();
        }

        private List<Product> GetAll()
        {
            IProductService productService = new ProductService();
            List<Product> products = productService.GetProducts().ToList();
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
