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
    public partial class ProductTypeView : UserControl
    {
        private ObservableCollection<ProductType> _productTypes;

        public ObservableCollection<ProductType> ProductTypes
        {
            get { return _productTypes; }
            set { _productTypes = value; }
        }

        IProductTypeService productTypeService = new ProductTypeService();

        public ProductTypeView()
        {
            InitializeComponent();
            gridProductTypes.ItemsSource = LoadData();
        }

        private void AddProductTypeClick(object sender, RoutedEventArgs e)
        {
            ManageProductTypeFormView manageProductTypeFormView = new ManageProductTypeFormView(this);
            manageProductTypeFormView.ShowDialog();
            if (manageProductTypeFormView.DialogResult.Value == true)
            {
                gridProductTypes.ItemsSource = LoadData();
            }
        }

        private void DeleteProductTypeClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Usunięcie typu produktu spowoduje usunięcie wszystkich produktów i raportów należących do tego typu. \nCzy na pewno chcesz usunąć wybrany typ produktów?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    ProductType productType = gridProductTypes.SelectedItem as ProductType;
                    productTypeService.DeleteProductType(productType.Id);
                    gridProductTypes.ItemsSource = LoadData();
                }
            }
        }

        private List<ProductType> GetAll()
        {
            IProductTypeService productTypeService = new ProductTypeService();
            List<ProductType> productTypes = productTypeService.GetProductTypes().ToList();
            return productTypes;
        }

        private ObservableCollection<ProductType> LoadData()
        {
            List<ProductType> productTypesList = GetAll();
            ProductTypes = new ObservableCollection<ProductType>(productTypesList);
            return ProductTypes;
        }

        private void UpdateProductTypeClick(object sender, RoutedEventArgs e)
        {
            ProductType productType = gridProductTypes.SelectedItem as ProductType;
            ManageProductTypeFormView manageProductTypeFormView = new ManageProductTypeFormView(this, productType);
            manageProductTypeFormView.ShowDialog();
            if (manageProductTypeFormView.DialogResult.Value == true)
            {
                gridProductTypes.ItemsSource = LoadData();
            }
        }

        private void SearchProductTypeClick(object sender, RoutedEventArgs e)
        {
            
            if (int.TryParse(idNameTextBox.Text, out int result))
            {
                List<ProductType> productTypes = GetProductById(result);
                ProductTypes = new ObservableCollection<ProductType>(productTypes);
                gridProductTypes.ItemsSource = ProductTypes;
            }
            else
            {
                List<ProductType> productTypes = GetProductsByName(idNameTextBox.Text);
                ProductTypes = new ObservableCollection<ProductType>(productTypes);
                gridProductTypes.ItemsSource = ProductTypes;
            }
        }

        private void ClearSearchClick(object sender, RoutedEventArgs e)
        {
            idNameTextBox.Text = null;
            gridProductTypes.ItemsSource = LoadData();
        }

        private List<ProductType> GetProductsByName(string name)
        {
            IProductTypeService productTypeService = new ProductTypeService();
            List<ProductType> productTypes = productTypeService.GetProductTypesByName(name).ToList();
            return productTypes;
        }

        private List<ProductType> GetProductById(int id)
        {
            IProductTypeService productTypeService = new ProductTypeService();
            List<ProductType> productTypes = new List<ProductType>();
            ProductType productType = productTypeService.GetProductType(id);
            if(productType != null)
            {
                productTypes.Add(productType);
                return productTypes;
            }
            else
            {
                return null;
            }
        }
        private void DeleteMultipleProductTypesClick(object sender, RoutedEventArgs e)
        {
            List<ProductType> selectedProductTypes = gridProductTypes.SelectedItems.Cast<ProductType>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show("Usunięcie typów produktów spowoduje usunięcie wszystkich produktów i raportów należących do tego typu. \nCzy na pewno chcesz usunąć wybrane typy produktów?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    foreach (ProductType productType in selectedProductTypes)
                    {
                        productTypeService.DeleteProductType(productType.Id);
                    }
                    gridProductTypes.ItemsSource = LoadData();
                }
            }
        }
    }
}