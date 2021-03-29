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
        IProductTypeService productTypeService = new ProductTypeService();
        ITaxService taxService = new TaxService();
        IManufacturerService manufacturerService = new ManufacturerService();
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        private ObservableCollection<string> _taxes;
        public ObservableCollection<string> Taxes
        {
            get { return _taxes; }
            set { _taxes = value; }
        }
        private ObservableCollection<string> _productTypes;
        public ObservableCollection<string> ProductTypes
        {
            get { return _productTypes; }
            set { _productTypes = value; }
        }
        private ObservableCollection<string> _manufacturers;
        public ObservableCollection<string> Manufacturers
        {
            get { return _manufacturers; }
            set { _manufacturers = value; }
        }
        public ProductView()
        {
            InitializeComponent();
            FillComboBoxes();
            gridProduct.ItemsSource = LoadData();
        }
        private void AddProductClick(object sender, RoutedEventArgs e)
        {
            ManageProductFormView manageProductForm = new ManageProductFormView(this);
            manageProductForm.ShowDialog();

            if(manageProductForm.DialogResult.Value == true)
            {
                gridProduct.ItemsSource = LoadData();
            }
        }
        private List<Product> GetAllProducts()
        {
            List<Product> products = productService.GetProducts().ToList();
            return products;
        }
        private List<string> GetAllProductTypes()
        {
            List<string> productTypes = new List<string>();
            List<ProductType> productTypesList = productTypeService.GetProductTypes().ToList();
            productTypes.Add("Wszystkie");
            foreach (ProductType productType in productTypesList)
            {
                productTypes.Add(productType.Name);
            }
            return productTypes;
        }
        private List<string> GetAllManufacturers()
        {
            List<string> manufacturers = new List<string>();
            List<Manufacturer> manufacturersList = manufacturerService.GetManufacturers().ToList();
            manufacturers.Add("Wszystkie");
            foreach(Manufacturer manufacturer in manufacturersList)
            {
                manufacturers.Add(manufacturer.Name);
            }
            return manufacturers;
        }
        private List<string> GetAllTaxes()
        {
            List<string> taxes = new List<string>();
            List<Tax> taxesList = taxService.GetTaxes().ToList();
            taxes.Add("Wszystkie");
            foreach (Tax tax in taxesList)
            {
                taxes.Add(tax.Value.ToString());
            }
            return taxes;
        }
        private ObservableCollection<Product> LoadData()
        {
            List<Product> productsList = GetAllProducts();
            Products = new ObservableCollection<Product>(productsList);
            return Products;
        }
        private void FillComboBoxes()
        {
            try
            {
                List<string> manufacturers = GetAllManufacturers();
                List<string> taxes = GetAllTaxes();
                List<string> productTypes = GetAllProductTypes();
                Manufacturers = new ObservableCollection<string>(manufacturers);
                Taxes = new ObservableCollection<string>(taxes);
                ProductTypes = new ObservableCollection<string>(productTypes);

                manufacturerComboBox.ItemsSource = Manufacturers;
                taxComboBox.ItemsSource = Taxes;
                productTypeComboBox.ItemsSource = ProductTypes;

                manufacturerComboBox.SelectedItem = Manufacturers[0];
                taxComboBox.SelectedItem = Taxes[0];
                productTypeComboBox.SelectedItem = ProductTypes[0];
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyświetlania: " + e);

            }
        }
        private void SearchClick(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Product> productsList = SearchProducts();
                Products = new ObservableCollection<Product>(productsList);
                gridProduct.ItemsSource = Products;
            }
            catch(Exception x)
            {
                MessageBox.Show("Błąd wyszukiwania: " + x);
            }
        }
        private void ClearSearchClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //FillComboBoxes();
                gridProduct.ItemsSource = LoadData();
            }
            catch(Exception x)
            {
                MessageBox.Show("Błąd czyszczenia: " + x);
            }
        }
        private void UpdateProductClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = gridProduct.SelectedItem as Product;
                ManageProductFormView manageProductForm = new ManageProductFormView(this, product);
                manageProductForm.ShowDialog();
                if (manageProductForm.DialogResult.Value == true)
                {
                    gridProduct.ItemsSource = LoadData();
                }
            }
            catch(Exception x)
            {
                MessageBox.Show("Błąd odświeżania: " + x);
            }
        }
        private void DeleteProductClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrane produkty?", "Potwierdź usunięcie.", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        Product product = gridProduct.SelectedItem as Product;
                        productService.DeleteProduct(product.Id);
                        gridProduct.ItemsSource = LoadData();
                    }
                }
            }
            catch(Exception x)
            {
                MessageBox.Show("Błąd usuwania: " + x);
            }
        }
        private void DeleteMultipleProductsClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrane produkty?", "Potwierdź usunięcie.", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        foreach (Product product in gridProduct.SelectedItems as List<Product>)
                        {
                            productService.DeleteProduct(product.Id);
                        }
                        gridProduct.ItemsSource = LoadData();
                    }
                }
                
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd usuwania: " + x);
            }
        }
        private void DeleteAllProductsClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wszystkie produkty?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                {
                    if(messageBoxResult == MessageBoxResult.Yes)
                    {
                        foreach (Product product in Products)
                        {
                            productService.DeleteProduct(product.Id);
                        }
                        gridProduct.ItemsSource = LoadData();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd usuwania: " + x);
            }
        }
        private void gridProductOpenItemView(object sender, RoutedEventArgs e)
        {
            if (gridProduct.SelectedItem != null)
            {
                ItemView itemView = new ItemView(gridProduct.SelectedItem as Product);
                itemView.ShowDialog();
                gridProduct.SelectedItem = null;
            }    
        }
        private void gridProductOpenEmittedItemView(object sender, RoutedEventArgs e)
        {
            if (gridProduct.SelectedItem != null)
            {
                EmittedItemsView itemView = new EmittedItemsView(gridProduct.SelectedItem as Product);
                itemView.ShowDialog();
                gridProduct.SelectedItem = null;
            }
        }
        private List<Product> SearchProducts()
        {
            try
            {
                List<string> criteria = new List<string>();
                criteria.Add(idNameTextBox.Text.ToString());
                criteria.Add(productTypeComboBox.SelectedItem.ToString());  //ProductType   - criteria[1]
                criteria.Add(manufacturerComboBox.SelectedItem.ToString()); //Manufacturer  - criteria[2]
                criteria.Add(taxComboBox.SelectedItem.ToString());          // Tax          - criteria[3]
                criteria.Add(priceBuyMinTextBox.Text.ToString());           // priceBuyMin  - criteria[4]
                criteria.Add(priceBuyMaxTextBox.Text.ToString());           // priceBuyMax  - criteria[5]
                criteria.Add(priceSellMinTextBox.Text.ToString());          // priceSellMin - criteria[6]
                criteria.Add(priceSellMaxTextBox.Text.ToString());          // priceSellMax - criteria[7]
                List<Product> products = productService.SearchProducts(criteria).ToList();
                return products;
            }
            catch (Exception)
            {
                throw new Exception("Błąd wyszukiwania");
            }
        }
    }
}