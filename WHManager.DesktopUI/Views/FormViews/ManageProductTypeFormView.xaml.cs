using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddProductTypeFormView.xaml
    /// </summary>
    public partial class ManageProductTypeFormView : Window
    {
        IProductTypeService productTypeService = new ProductTypeService();
        private ProductType ProductType
        {
            get;
            set;
        }
        
        private ProductTypeView ProductTypeGridView
        {
            get;
            set;
        }

        public ManageProductTypeFormView(ProductTypeView productTypeView)
        {
            InitializeComponent();
            ProductTypeGridView = productTypeView;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        public ManageProductTypeFormView(ProductTypeView productTypeView, ProductType productType)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            ProductTypeGridView = productTypeView;
            ProductType = productType;
            textBoxProductTypeName.Text = productType.Name;
            textBlockManageProductType.Text = "Edytuj typ produktu o ID: " + ProductType.Id;

        }
        private void AddProductTypeButton(object sender, RoutedEventArgs e)
        {
            if (ProductType == null)
            {
                AddProductType();
                DialogResult = true;
                this.Close();
            }
            else
            {
                UpdateProductType();
                DialogResult = true;
                this.Close();
            }
           
        }

        public void AddProductType()
        {
            ProductType productType = new ProductType
            {
                Name = textBoxProductTypeName.Text
            };
            productTypeService.CreateNewProductType(productType);
        }

        public void UpdateProductType()
        {
            ProductType productType = new ProductType
            {
                Id = ProductType.Id,
                Name = textBoxProductTypeName.Text
            };
            productTypeService.UpdateProductType(productType);
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        public void OnDialogClose()
        {
            ProductTypeGridView.gridProductTypes.Items.Refresh();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            textBoxProductTypeName.Clear();
        }
    }
}
