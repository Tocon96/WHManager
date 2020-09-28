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
using WHManager.DesktopUI.Views.BusinessViews;

namespace WHManager.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for BusinessView.xaml
    /// </summary>
    public partial class BusinessView : UserControl
    {
        public BusinessView()
        {
            InitializeComponent();
            businessContent.Content = new OrderView();
        }
        private void OrdersViewClick(object sender, RoutedEventArgs e)
        {
            businessContent.Content = new OrderView();
        }
        private void InvoicesViewClick(object sender, RoutedEventArgs e)
        {
            businessContent.Content = new InvoiceView();
        }
    }
}
