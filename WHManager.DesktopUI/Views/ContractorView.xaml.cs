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
using WHManager.DesktopUI.Views.ContractorsView;
using WHManager.DesktopUI.Views.ContractorsViews;

namespace WHManager.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for ContractorView.xaml
    /// </summary>
    public partial class ContractorView : UserControl
    {
        public ContractorView()
        {
            InitializeComponent();
            contractorsContent.Content = new ManufacturerView();
        }

        private void ManufacturersViewClick(object sender, RoutedEventArgs e)
        {
            contractorsContent.Content = new ManufacturerView();
        }

        private void ClientsTypeViewClick(object sender, RoutedEventArgs e)
        {
            contractorsContent.Content = new ClientView();
        }
    }
}
