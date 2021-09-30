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
using System.Windows.Shapes;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;

namespace WHManager.DesktopUI.Views.WarehouseViews
{
    /// <summary>
    /// Interaction logic for DeliveryItemsView.xaml
    /// </summary>
    public partial class DeliveryItemsView : Window
    {
        private Delivery Delivery { get; set; }
        public DeliveryItemsView(Delivery delivery)
        {
            InitializeComponent();
            Delivery = delivery;
            FillGrid();
        }

        private void FillGrid()
        {
            //gridItems.ItemsSource = new ObservableCollection<Item>(Delivery.Items);
        }
    }
}
