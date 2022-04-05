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
                
                if(AddProductType() == true)
                {
                    DialogResult = true;
                    this.Close();
                }
            }
            else
            {
                if(UpdateProductType() == true)
                {
                    DialogResult = true;
                    this.Close();
                }
            }
           
        }

        public bool AddProductType()
        {
            ProductType productType = new ProductType
            {
                Name = textBoxProductTypeName.Text
            };
            if(productType.Name.Length > 0)
            {
                productTypeService.CreateNewProductType(productType);
                return true;
            }
            else
            {
                MessageBox.Show("Podaj poprawną nazwę typu.");
                return false;
            }
            
        }

        public bool UpdateProductType()
        {
            ProductType productType = new ProductType
            {
                Id = ProductType.Id,
                Name = textBoxProductTypeName.Text
            };
            if (productType.Name.Length > 0)
            {
                productTypeService.CreateNewProductType(productType);
                return true;
            }
            else
            {
                MessageBox.Show("Podaj poprawną nazwę typu.");
                return false;
            }

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
