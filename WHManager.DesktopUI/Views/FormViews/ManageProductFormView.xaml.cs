using MvvmCross.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DesktopUI.Views.WarehouseViews;
using WHManager.DesktopUI.WindowSetting;
using WHManager.DesktopUI.WindowSetting.Interfaces;

namespace WHManager.DesktopUI.Views.FormViews
{
    /// <summary>
    /// Interaction logic for AddProductFormView.xaml
    /// </summary>
    public partial class ManageProductFormView : Window
    {
        private ObservableCollection<Manufacturer> _manufacturers;
        public ObservableCollection<Manufacturer> Manufacturers
        {
            get { return _manufacturers; }
            set { _manufacturers = value; }
        }

        private ObservableCollection<ProductType> _productTypes;

        public ObservableCollection<ProductType> ProductTypes
        {
            get { return _productTypes; }
            set { _productTypes = value; }
        }

        private ObservableCollection<Tax> _taxes;
        public ObservableCollection<Tax> Taxes
        {
            get { return _taxes; }
            set { _taxes = value; }
        }

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        private ProductView _productView;
        public ProductView ProductGridView
        {
            get { return _productView; }
            set { _productView = value; }
        }

        private Product _product;
        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        private readonly IManufacturerService manufacturerService = new ManufacturerService();
        private readonly IProductTypeService productTypeService = new ProductTypeService();
        private readonly IProductService productService = new ProductService();
        public ManageProductFormView(ProductView productView)
        {
            InitializeComponent();
            ProductGridView = productView;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            FillComboBoxes();
        }
        public ManageProductFormView(ProductView productView, Product product)
        {
            InitializeComponent();
            Product = product;
            ProductGridView = productView;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            FillComboBoxes();
            SelectItems(product);
            textBlockManageProduct.Text = "Edytuj Produkt: "+product.Id;
        }

        private void SelectItems(Product product)
        {
            try
            {
                textBoxProductName.Text = product.Name;
                textBoxProductPriceBuy.Text = product.PriceBuy.ToString();
                textBoxProductPriceSell.Text = product.PriceSell.ToString();
                foreach (Manufacturer manufacturer in comboBoxManufacturer.Items)
                {
                    if (manufacturer.Id == product.Manufacturer.Id)
                    {
                        comboBoxManufacturer.SelectedItem = manufacturer;
                    }
                }
                foreach (Tax tax in comboBoxProductTax.Items)
                {
                    if (tax.Id == product.Tax.Id)
                    {
                        comboBoxProductTax.SelectedItem = tax;
                    }
                }
                foreach (ProductType type in comboBoxProductType.Items)
                {
                    if (type.Id == product.Type.Id)
                    {
                        comboBoxProductType.SelectedItem = type;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd ComboBoxów: " + e);
            }
        }

        private List<Manufacturer> GetManufacturers()
        {
            try
            {
                List<Manufacturer> manufacturers = manufacturerService.GetManufacturers().ToList();
                return manufacturers;
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd wyświetlani: " + e);
                return null;
            }
        }
        private List<Tax> GetTaxes()
        {
            try
            {
                ITaxService taxService = new TaxService();
                List<Tax> taxes = taxService.GetTaxes().ToList();
                return taxes;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyświetlania: " + e);
                return null;
            }
        }
        private List<ProductType> GetProductTypes()
        {
            try
            {
                List<ProductType> productTypes = productTypeService.GetProductTypes().ToList();
                return productTypes;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyświetlania: " + e);
                return null;
            }
        }
        private void FillComboBoxes()
        {
            try
            {
                List<Manufacturer> manufacturers = GetManufacturers();
                List<Tax> taxes = GetTaxes();
                List<ProductType> productTypes = GetProductTypes();
                Manufacturers = new ObservableCollection<Manufacturer>(manufacturers);
                Taxes = new ObservableCollection<Tax>(taxes);
                ProductTypes = new ObservableCollection<ProductType>(productTypes);

                comboBoxManufacturer.ItemsSource = Manufacturers;
                comboBoxProductTax.ItemsSource = Taxes;
                comboBoxProductType.ItemsSource = ProductTypes;

                comboBoxManufacturer.SelectedItem = Manufacturers[0];
                comboBoxProductTax.SelectedItem = Taxes[0];
                comboBoxProductType.SelectedItem = ProductTypes[0];
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyświetlania: " + e);
                
            }

        }

        private List<Product> GetAllProducts()
        {
            List<Product> products = productService.GetProducts().ToList();
            return products;
        }


        private ObservableCollection<Product> LoadData()
        {
            List<Product> productsList = GetAllProducts();
            Products = new ObservableCollection<Product>(productsList);
            return Products;
        }

        private void AddProduct()
        {
            try
            {
                IProductService productService = new ProductService();
                Product product = new Product
                {
                    Name = textBoxProductName.Text,
                    Type = comboBoxProductType.SelectedItem as ProductType,
                    Tax = comboBoxProductTax.SelectedItem as Tax,
                    Manufacturer = comboBoxManufacturer.SelectedItem as Manufacturer,
                    PriceBuy = int.Parse(textBoxProductPriceBuy.Text),
                    PriceSell = int.Parse(textBoxProductPriceSell.Text)
                };
                productService.CreateNewProduct(product);
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd dodawania: " + e);

            }

        }
        private void UpdateProduct()
        {
            {
                try
                {
                    IProductService productService = new ProductService();
                    Product product = new Product
                    {
                        Id = Product.Id,
                        Name = textBoxProductName.Text,
                        Type = comboBoxProductType.SelectedItem as ProductType,
                        Tax = comboBoxProductTax.SelectedItem as Tax,
                        Manufacturer = comboBoxManufacturer.SelectedItem as Manufacturer,
                        PriceBuy = decimal.Parse(textBoxProductPriceBuy.Text),
                        PriceSell = decimal.Parse(textBoxProductPriceSell.Text)
                    };
                    productService.UpdateProduct(product);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Błąd wyświetlania: " + e);

                }
            }
        }
        private void AddProductClick(object sender, RoutedEventArgs e)
        {

            if(Product != null)
            {
                try
                {
                    UpdateProduct();
                    DialogResult = true;
                    this.Close();
                }
                catch(Exception x)
                {
                    MessageBox.Show("Błąd aktualizacji: " + x);
                }
            }
            else
            {
                try
                {
                    AddProduct();
                    DialogResult = true;
                    this.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Błąd dodawania: " + x);
                }
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        public void OnDialogClose()
        {
            ProductGridView.gridProduct.Items.Refresh();
        }

        private void textBoxProductName_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(textBoxProductName.Text == "Nazwa")
            {
                textBoxProductName.Clear();
            }
        }

        private void textBoxProductPriceBuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(textBoxProductPriceBuy.Text == "Cena kupna")
            {
                textBoxProductPriceBuy.Clear();
            }
        }

        private void textBoxProductPriceSell_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(textBoxProductPriceSell.Text == "Cena sprzedaży")
            {
                textBoxProductPriceSell.Clear();
            }
        }
    }
}
