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
        private readonly IDisplaySetting displaySetting = new DisplaySetting();
        public ManageProductTypeFormView()
        {
            InitializeComponent();
            displaySetting.CenterWindowOnScreen(this);
        }

        public ManageProductTypeFormView(ProductType productType)
        {
            InitializeComponent();
            displaySetting.CenterWindowOnScreen(this);
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
                    MessageBox.Show("Błąd dodawania: AddProductTypeButton" + x);
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
                    MessageBox.Show("Błąd aktualizacji: AddProductTypeButton" + x);
                }
            }
           
        }

        public void AddProductType()
        {
            try
            {
                ProductType productType = new ProductType
                {
                    Name = textBoxProductTypeName.Text
                };
                productTypeService.CreateNewProductType(productType);
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd dodawania: AddProductType" + x);
            }
        }

        public void UpdateProductType()
        {
            try
            {
                ProductType productType = new ProductType
                {
                    Id = (int)Id.Content,
                    Name = textBoxProductTypeName.Text
                };
                productTypeService.UpdateProductType(productType);
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd dodawania: UpdateProductType" + x);
            }
        }
    }
}
