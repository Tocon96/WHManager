﻿using System;
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

namespace WHManager.DesktopUI.Views.FormViews.SearchFormViews
{
    /// <summary>
    /// Interaction logic for SearchProductByManufacturerFormView.xaml
    /// </summary>
    public partial class SearchProductByManufacturerFormView : UserControl
    {
        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public SearchProductByManufacturerFormView()
        {
            InitializeComponent();
            gridProduct.ItemsSource = LoadData();
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Search();
            }
            catch(Exception x)
            {
                MessageBox.Show("Błąd wyszukiwania" + x);
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
            catch (Exception x)
            {
                MessageBox.Show("Błąd edycji" + x);
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
            catch (Exception x)
            {
                MessageBox.Show("Błąd usuwania" + x);
            }
        }

        private IList<Product> GetProducts()
        {
            IProductService productService = new ProductService();
            List<Product> products = productService.GetProducts().ToList();
            return products;
        }

        private ObservableCollection<Product> LoadData()
        {
            IList<Product> productsList = GetProducts();
            Products = new ObservableCollection<Product>(productsList);
            return Products;
        }

        private void Search()
        {
            if (radioButtonID.IsChecked == true)
            {
                try
                {
                    IProductService productService = new ProductService();
                    IList<Product> products = productService.GetProductsByManufacturer(null, int.Parse(textBoxSearch.Text), null);
                    Products = new ObservableCollection<Product>(products);
                    gridProduct.ItemsSource = Products;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Błąd wyszukiwania: " + e);
                }
            }
            else if (radioButtonName.IsChecked == true)
            {
                try
                {
                    IProductService productService = new ProductService();
                    IList<Product> products = productService.GetProductsByManufacturer(textBoxSearch.Text, null, null);
                    Products = new ObservableCollection<Product>(products);
                    gridProduct.ItemsSource = Products;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Błąd wyszukiwania: " + e);
                }
            }
            else if (radioButtonNip.IsChecked == true)
            {
                try
                {
                    IProductService productService = new ProductService();
                    IList<Product> products = productService.GetProductsByManufacturer(null, null, double.Parse(textBoxSearch.Text));
                    Products = new ObservableCollection<Product>(products);
                    gridProduct.ItemsSource = Products;
                }   
                catch(Exception e)
                {
                    MessageBox.Show("Błąd wyszukiwania: " + e);
                }
            }
        }
    }
}