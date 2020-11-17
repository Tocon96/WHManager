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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WHManager.DesktopUI.Views.WarehouseViews;

namespace WHManager.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for WarehouseView.xaml
    /// </summary>
    public partial class WarehouseView : UserControl
    {
        public WarehouseView()
        {
            InitializeComponent();
            warehouseContent.Content = new ProductView();
        }

        private void ProductViewClick(object sender, RoutedEventArgs e)
        {
            warehouseContent.Content = new ProductView();
        }

        private void ProductTypeViewClick(object sender, RoutedEventArgs e)
        {
            warehouseContent.Content = new ProductTypeView();
        }

        private void TaxViewClick(object sender, RoutedEventArgs e)
        {
            warehouseContent.Content = new TaxView();
        }
    }
}
