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

namespace WHManager.DesktopUI.Views.FormViews.SearchFormViews
{
    /// <summary>
    /// Interaction logic for SearchProductsByPricesFormView.xaml
    /// </summary>
    public partial class SearchProductsByPricesFormView : UserControl
    {
        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public SearchProductsByPricesFormView()
        {
            InitializeComponent();
            gridProduct.ItemsSource = LoadData();
            textBoxPriceMin.Text = "";
            textBoxPriceMax.Text = "";
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            Search();
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
            try
            {
                IProductService productService = new ProductService();
                List<Product> products = productService.GetProducts().ToList();
                return products;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyszukiwania: " + e);
                return null;
            }

        }

        private ObservableCollection<Product> LoadData()
        {
            try
            {
                IList<Product> productsList = GetProducts();
                Products = new ObservableCollection<Product>(productsList);
                return Products;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyszukiwania: " + e);
                return null;
            }
        }

        private void Search()
        {
            IProductService productService = new ProductService();
            if (radioButtonPriceBuy.IsChecked == true)
            {
                if (textBoxPriceMin.Text == "" && textBoxPriceMax.Text != "")
                {
                    try
                    {
                        IList<Product> products = productService.GetProductsByPriceBuy(null, decimal.Parse(textBoxPriceMax.Text));
                        Products = new ObservableCollection<Product>(products);
                        gridProduct.ItemsSource = Products;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Błąd wyszkiwania: " + e);
                    }
                }
                else if (textBoxPriceMin.Text != "" && textBoxPriceMax.Text == "")
                {
                    try
                    {
                        IList<Product> products = productService.GetProductsByPriceBuy(decimal.Parse(textBoxPriceMin.Text), null);
                        Products = new ObservableCollection<Product>(products);
                        gridProduct.ItemsSource = Products;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Błąd wyszkiwania: " + e);
                    }
                }
                else if(textBoxPriceMin.Text != "" && textBoxPriceMax.Text != "")
                {
                    try
                    {
                        IList<Product> products = productService.GetProductsByPriceBuy(decimal.Parse(textBoxPriceMin.Text), decimal.Parse(textBoxPriceMax.Text));
                        Products = new ObservableCollection<Product>(products);
                        gridProduct.ItemsSource = Products;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Błąd wyszkiwania: " + e);
                    }
                }
                else if(textBoxPriceMin.Text == "" && textBoxPriceMax.Text == "")
                {
                    try
                    {
                        gridProduct.ItemsSource = LoadData();
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("Błąd wyszkiwania" + e);
                    }
                }
            }
            else if(radioButtonPriceSell.IsChecked == true)
            {
                if (textBoxPriceMin.Text == "" && textBoxPriceMax.Text != "")
                {
                    try
                    {
                        IList<Product> products = productService.GetProductsByPriceSell(null, decimal.Parse(textBoxPriceMax.Text));
                        Products = new ObservableCollection<Product>(products);
                        gridProduct.ItemsSource = Products;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Błąd wyszkiwania: " + e);
                    }
                }
                else if (textBoxPriceMax.Text == "" && textBoxPriceMin.Text != "")
                {
                    try
                    {
                        IList<Product> products = productService.GetProductsByPriceSell(decimal.Parse(textBoxPriceMin.Text), null);
                        Products = new ObservableCollection<Product>(products);
                        gridProduct.ItemsSource = Products;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Błąd wyszkiwania: " + e);
                    }
                }
                else if (textBoxPriceMax.Text != "" && textBoxPriceMin.Text != "")
                {
                    try
                    {
                        IList<Product> products = productService.GetProductsByPriceSell(decimal.Parse(textBoxPriceMin.Text), decimal.Parse(textBoxPriceMax.Text));
                        Products = new ObservableCollection<Product>(products);
                        gridProduct.ItemsSource = Products;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Błąd wyszkiwania: " + e);
                    }
                }
            }
        }

    }
}
