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

        private bool ManufacturerCheck { get; set; }
        private bool TypeCheck { get; set; }
        private bool TaxCheck { get; set; }

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
            ManufacturerCheck = false;
            TypeCheck = false;
            TaxCheck = false;
            FillComboBoxes();
            gridProduct.ItemsSource = LoadData();
        }
        private void AddProductClick(object sender, RoutedEventArgs e)
        {
            if (ManufacturerCheck == true && TypeCheck == true && TaxCheck == true)
            {
                ManageProductFormView manageProductForm = new ManageProductFormView(this);
                manageProductForm.ShowDialog();

                if (manageProductForm.DialogResult.Value == true)
                {
                    gridProduct.ItemsSource = LoadData();
                }
            }
            else 
            {
                MessageBox.Show("Brakuje elementów niezbędnych do utworzenia produktu.");
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
            if (productTypes.Count > 1)
            {
                TypeCheck = true;
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
            if(manufacturers.Count > 1)
            {
                ManufacturerCheck = true;
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
            if (taxes.Count > 1)
            {
                TaxCheck = true;
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
        private void SearchClick(object sender, RoutedEventArgs e)
        {
            List<Product> productsList = SearchProducts();
            Products = new ObservableCollection<Product>(productsList);
            gridProduct.ItemsSource = Products;
        }

        private void ClearSearchClick(object sender, RoutedEventArgs e)
        {
            ClearFilters();
            gridProduct.ItemsSource = LoadData();
        }
        private void UpdateProductClick(object sender, RoutedEventArgs e)
        {
            Product product = gridProduct.SelectedItem as Product;
            ManageProductFormView manageProductForm = new ManageProductFormView(this, product);
            manageProductForm.ShowDialog();
            if (manageProductForm.DialogResult.Value == true)
            {
                gridProduct.ItemsSource = LoadData();
            }
        }
        private void DeleteProductClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Usunięcie tego produktu spowoduje usunięcie wszystkich przypisanych egzemplarzy i raportów. \nCzy na pewno chcesz usunąć wybrany produkt?", "Potwierdź usunięcie.", MessageBoxButton.YesNo);
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Product product = gridProduct.SelectedItem as Product;
                    productService.DeleteProduct(product.Id);
                    gridProduct.ItemsSource = LoadData();
                }
            }
        }
        private void DeleteMultipleProductsClick(object sender, RoutedEventArgs e)
        {
            List<Product> selectedProducts = gridProduct.SelectedItems.Cast<Product>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show("Usunięcie tych produktów spowoduje usunięcie wszystkich przypisanych egzemplarzy i raportów. \nCzy na pewno chcesz usunąć wybrane produkty?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                { 
                    foreach (Product product in selectedProducts)
                    {
                        productService.DeleteProduct(product.Id);
                    }
                    gridProduct.ItemsSource = LoadData();
                }
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
            List<string> criteria = new List<string>();
            criteria.Add(idNameTextBox.Text.ToString());
            criteria.Add(productTypeComboBox.SelectedItem.ToString());  //ProductType   - criteria[1]
            if(criteria[1] == "Wszystkie")
            {
                criteria[1] = "";
            }
            criteria.Add(manufacturerComboBox.SelectedItem.ToString()); //Manufacturer  - criteria[2]
            if (criteria[2] == "Wszystkie")
            {
                criteria[2] = "";
            }
            criteria.Add(taxComboBox.SelectedItem.ToString());          // Tax          - criteria[3]
            if (criteria[3] == "Wszystkie")
            {
                criteria[3] = "";
            }
            if (!string.IsNullOrEmpty(priceBuyMinTextBox.Text))
            {
                if (decimal.TryParse(priceBuyMinTextBox.Text, out decimal result))
                {
                    criteria.Add(result.ToString());           // priceBuyMin  - criteria[4]
                }
                else
                {
                    criteria.Add("");
                    MessageBox.Show("Proszę podać poprawną cenę");
                }
            }
            else
            {
                criteria.Add("");
            }

            if (!string.IsNullOrEmpty(priceBuyMaxTextBox.Text))
            {
                if (decimal.TryParse(priceBuyMaxTextBox.Text, out decimal result))
                {
                    criteria.Add(result.ToString());           // priceBuyMin  - criteria[4]
                }
                else
                {
                    criteria.Add("");
                    MessageBox.Show("Proszę podać poprawną cenę");
                }
            }
            else
            {
                criteria.Add("");
            }

            if (!string.IsNullOrEmpty(priceSellMinTextBox.Text))
            {
                if (decimal.TryParse(priceSellMinTextBox.Text, out decimal result))
                {
                    criteria.Add(result.ToString());          // priceSellMin - criteria[6]
                }
                else
                {
                    criteria.Add("");
                    MessageBox.Show("Proszę podać poprawną cenę");
                }
            }
            else
            {
                criteria.Add("");
            }

            if (!string.IsNullOrEmpty(priceSellMaxTextBox.Text))
            {
                if (decimal.TryParse(priceSellMaxTextBox.Text, out decimal result))
                {
                    criteria.Add(priceSellMaxTextBox.Text.ToString());          // priceSellMax - criteria[7]
                }
                else
                {
                    criteria.Add("");
                    MessageBox.Show("Proszę podać poprawną cenę");
                }
            }
            else
            {
                criteria.Add("");
            }
            List<Product> products = productService.SearchProducts(criteria).ToList();
            return products;
        }
        private void ClearFilters()
        {
            manufacturerComboBox.SelectedItem = Manufacturers[0];
            taxComboBox.SelectedItem = Taxes[0];
            productTypeComboBox.SelectedItem = ProductTypes[0];

            priceBuyMaxTextBox.Text = null;
            priceBuyMinTextBox.Text = null;
            priceSellMaxTextBox.Text = null;
            priceSellMinTextBox.Text = null;

            idNameTextBox.Text = null;
        }
    }
}