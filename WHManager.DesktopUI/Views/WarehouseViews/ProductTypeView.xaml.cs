using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
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
    /// Interaction logic for ProductTypeView.xaml
    /// </summary>
    public partial class ProductTypeView : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private ObservableCollection<ProductType> _productTypes;

        public ObservableCollection<ProductType> ProductTypes
        {
            get { return this._productTypes; }
            set 
            { 
                if(this._productTypes != value)
                {
                    this._productTypes = value;
                    this.NotifyPropertyChanged(nameof(this._productTypes));
                }
            }
        }

        public ProductTypeView()
        {
            InitializeComponent();
            gridProductTypes.ItemsSource = LoadData();
        }

        private void AddProductTypeClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ManageProductTypeFormView manageProductTypeFormView = new ManageProductTypeFormView();
                manageProductTypeFormView.Show();
                gridProductTypes.ItemsSource = LoadData();
            }
            catch(Exception x)
            {
                throw x;
            }
        }

        private void DeleteProductTypeClick(object sender, RoutedEventArgs e)
        {
            try
            {
                IProductTypeService productTypeService = new ProductTypeService();
                ProductType productType = gridProductTypes.SelectedItem as ProductType;
                productTypeService.DeleteProductType(productType.Id);
                gridProductTypes.ItemsSource = LoadData();
            }
            catch(Exception x)
            {
                throw x;
            }
        }

        private List<ProductType> GetAll()
        {
            try
            {
                IProductTypeService productTypeService = new ProductTypeService();
                List<ProductType> productTypes = productTypeService.GetProductTypes().ToList();
                return productTypes;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private ObservableCollection<ProductType> LoadData()
        {
            try
            {
                List<ProductType> productTypesList = GetAll();
                ProductTypes = new ObservableCollection<ProductType>(productTypesList);
                return ProductTypes;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private void UpdateProductTypeClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductType productType = gridProductTypes.SelectedItem as ProductType;
                ManageProductTypeFormView manageProductTypeFormView = new ManageProductTypeFormView(productType);
                manageProductTypeFormView.Show();
                gridProductTypes.ItemsSource = LoadData();
            }
            catch(Exception x)
            {
                throw x;
            }
        }

        private void SearchProductTypeClick(object sender, RoutedEventArgs e)
        {
            if (NameRadioButton.IsChecked == true)
            {
                try
                {
                    List<ProductType> productTypes = GetProductsByName(SearchTextBox.Text);
                    ProductTypes = new ObservableCollection<ProductType>(productTypes);
                    gridProductTypes.ItemsSource = ProductTypes;
                }
                catch(Exception x)
                {
                    throw x;
                }
            }
            else if (IdRadioButton.IsChecked == true)
            {
                try
                {
                    List<ProductType> productTypes = GetProductById(int.Parse(SearchTextBox.Text));
                    ProductTypes = new ObservableCollection<ProductType>(productTypes);
                    gridProductTypes.ItemsSource = ProductTypes;
                }
                catch (Exception x)
                {
                    throw x;
                }
            }
        }

        private void ClearSearchClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchTextBox.Text = null;
                gridProductTypes.ItemsSource = LoadData();
            }
            catch(Exception x)
            {
                throw x;
            }
        }

        private List<ProductType> GetProductsByName(string name)
        {
            try
            {
                IProductTypeService productTypeService = new ProductTypeService();
                List<ProductType> productTypes = productTypeService.GetProductTypesByName(name).ToList();
                return productTypes;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private List<ProductType> GetProductById(int id)
        {
            try
            {
                IProductTypeService productTypeService = new ProductTypeService();
                List<ProductType> productTypes = new List<ProductType>();
                ProductType productType = productTypeService.GetProductType(id).Result;
                productTypes.Add(productType);
                return productTypes;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}