using MvvmCross.Base;
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
using System.Windows.Shapes;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;

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

        public ManageProductFormView()
        {
            InitializeComponent();
            FillComboBoxes();
        }
        public ManageProductFormView(Product product)
        {
            InitializeComponent();
            FillComboBoxes();
            IdLabel.Visibility = Visibility.Visible;
            IdLabel.Content = product.Id;
            textBoxProductName.Text = product.Name;
            textBoxProductPriceBuy.Text = product.PriceBuy.ToString();
            textBoxProductPriceSell.Text = product.PriceSell.ToString();
            comboBoxProductManufacturer.SelectedItem = product.Manufacturer;
            comboBoxProductTax.SelectedItem = product.Tax;
            comboBoxProductType.SelectedItem = product.Type;
            
        }

        private List<Manufacturer> GetManufacturers()
        {
            IManufacturerService manufacturerService = new ManufacturerService();
            List<Manufacturer> manufacturers = manufacturerService.GetManufacturers().ToList();
            return manufacturers;
        }
        private List<Tax> GetTaxes()
        {
            ITaxService taxService = new TaxService();
            List<Tax> taxes = taxService.GetTaxes().ToList();
            return taxes;
        }
        private List<ProductType> GetProductTypes()
        {
            IProductTypeService productTypeService = new ProductTypeService();
            List<ProductType> productTypes = productTypeService.GetProductTypes().ToList();
            return productTypes;
        }
        private void FillComboBoxes()
        {
            List<Manufacturer> manufacturers = GetManufacturers();
            List<Tax> taxes = GetTaxes();
            List<ProductType> productTypes = GetProductTypes();
            Manufacturers = new ObservableCollection<Manufacturer>(manufacturers);
            Taxes = new ObservableCollection<Tax>(taxes);
            ProductTypes = new ObservableCollection<ProductType>(productTypes);

            comboBoxProductManufacturer.ItemsSource = Manufacturers;
            comboBoxProductTax.ItemsSource = Taxes;
            comboBoxProductType.ItemsSource = ProductTypes;
            
        }
        private void AddProduct()
        {
            IProductService productService = new ProductService();
            Product product = new Product
            {
                Name = textBoxProductName.Text,
                Type = comboBoxProductType.SelectedItem as ProductType,
                Tax = comboBoxProductTax.SelectedItem as Tax,
                Manufacturer = comboBoxProductManufacturer.SelectedItem as Manufacturer,
                PriceBuy = int.Parse(textBoxProductPriceBuy.Text),
                PriceSell = int.Parse(textBoxProductPriceSell.Text)
            };
            test.Content = product.Type.Id;
            productService.CreateNewProduct(product);
        }
        private void UpdateProduct()
        {
            {
                IProductService productService = new ProductService();
                Product product = new Product
                {
                    Id = (int)IdLabel.Content,
                    Name = textBoxProductName.Text,
                    Type = comboBoxProductType.SelectedItem as ProductType,
                    Tax = comboBoxProductTax.SelectedItem as Tax,
                    Manufacturer = comboBoxProductManufacturer.SelectedItem as Manufacturer,
                    PriceBuy = decimal.Parse(textBoxProductPriceBuy.Text),
                    PriceSell = decimal.Parse(textBoxProductPriceSell.Text)
                };
                productService.UpdateProduct(product);
            }
        }
        private void AddProductClick(object sender, RoutedEventArgs e)
        {
            if(IdLabel.Visibility == Visibility.Visible)
            {
                UpdateProduct();
                this.Close();
            }
            else if(IdLabel.Visibility == Visibility.Hidden)
            {
                AddProduct();
                this.Close();
            }
        }
    }
}
