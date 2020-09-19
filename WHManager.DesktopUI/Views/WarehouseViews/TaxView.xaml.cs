using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WHManager.DesktopUI.Views.WarehouseViews
{
    /// <summary>
    /// Interaction logic for TaxView.xaml
    /// </summary>
    public partial class TaxView : UserControl
    {

        private ObservableCollection<Tax> _taxes;

        public ObservableCollection<Tax> Taxes
        {
            get { return Taxes; }
            set { Taxes = value; }
        }


        public TaxView()
        {
            InitializeComponent();
        }

        private void DeleteTaxClick(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateTaxClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
