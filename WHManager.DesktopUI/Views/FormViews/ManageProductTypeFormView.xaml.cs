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

namespace WHManager.DesktopUI.Views.FormViews
{
    /// <summary>
    /// Interaction logic for AddProductTypeFormView.xaml
    /// </summary>
    public partial class ManageProductTypeFormView : Window
    {
        IProductTypeService productTypeService = new ProductTypeService();

        public ManageProductTypeFormView()
        {
            InitializeComponent();
        }

        public ManageProductTypeFormView(ProductType productType)
        {
            InitializeComponent();
            Id.Visibility = Visibility.Visible;
            Id.Content = productType.Id;
            textBoxProductTypeName.Text = productType.Name;

        }
        private void AddProductTypeButton(object sender, RoutedEventArgs e)
        {
            if (Id.Visibility == Visibility.Hidden)
            {
                try
                {
                    AddProductType();
                    this.Close();
                }
                catch (Exception x)
                {
                    throw x;
                }
            }
            else
            {
                try
                {
                    UpdateProductType();
                    this.Close();
                }
                catch (Exception x)
                {
                    throw x;
                }
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
                Id = (int)Id.Content,
                Name = textBoxProductTypeName.Text
            };
            productTypeService.UpdateProductType(productType);
        }
    }
}
