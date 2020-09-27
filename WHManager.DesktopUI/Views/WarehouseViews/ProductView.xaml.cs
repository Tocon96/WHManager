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
            gridProduct.ItemsSource = LoadData();
        }

        private void AddProductClick(object sender, RoutedEventArgs e)
        {
            ManageProductFormView manageProductForm = new ManageProductFormView();
            manageProductForm.Show();
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

        private void AdvancedSearchClick(object sender, RoutedEventArgs e)
        {
            AdvancedSearchProductFormView advancedSearchProductFormView = new AdvancedSearchProductFormView();
            advancedSearchProductFormView.Show();
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            if (IdRadioButton.IsChecked == true)
            {
                IList<Product> products = GetProductById(int.Parse(textBoxProductSearch.Text));
                Products = new ObservableCollection<Product>(products);
                gridProduct.ItemsSource = Products;
            }
            else if(NameRadioButton.IsChecked == true)
            {
                IList<Product> products = GetProductsByName(textBoxProductSearch.Text);
                Products = new ObservableCollection<Product>(products);
                gridProduct.ItemsSource = Products;
            }
        }

        private void ClearSearchClick(object sender, RoutedEventArgs e)
        {
            try
            {
                textBoxProductSearch.Text = null;
                gridProduct.ItemsSource = LoadData();
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void UpdateProductClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = gridProduct.SelectedItem as Product;
                ManageProductFormView manageProductForm = new ManageProductFormView(product);
                manageProductForm.Show();
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void DeleteProductClick(object sender, RoutedEventArgs e)
        {
            try
            {
                IProductService productService = new ProductService();
                Product product = gridProduct.SelectedItem as Product;
                productService.DeleteProduct(product.Id);
            }
            catch(Exception)
            {
                throw;
            }
        }

        private IList<Product> GetProductById(int id)
        {
            try
            {
                IProductService productService = new ProductService();
                IList<Product> products = new List<Product>();
                Product product = productService.GetProduct(id);
                products.Add(product);
                return products;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private IList<Product> GetProductsByName(string name)
        {
            try
            {
                IProductService productService = new ProductService();
                IList<Product> products = productService.GetProductsByName(name);
                return products;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void gridProductOpenItemView(object sender, RoutedEventArgs e)
        {
            if (gridProduct.SelectedItem != null)
            {
                ItemView itemView = new ItemView(gridProduct.SelectedItem as Product);
                itemView.Show();
                gridProduct.SelectedItem = null;
            }    
        }
        private void gridProductOpenEmittedItemView(object sender, RoutedEventArgs e)
        {
            if (gridProduct.SelectedItem != null)
            {
                EmittedItemsView itemView = new EmittedItemsView(gridProduct.SelectedItem as Product);
                itemView.Show();
                gridProduct.SelectedItem = null;
            }
        }
    }
}
