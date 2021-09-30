using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace WHManager.DesktopUI.Views.BusinessViews
{
    /// <summary>
    /// Interaction logic for DeliveryView.xaml
    /// </summary>
    public partial class DeliveryView : UserControl
    {
        IDeliveryService deliveryService = new DeliveryService();
        IProviderService providerService = new ProviderService();
        IIncomingDocumentService incomingDocumentService = new IncomingDocumentService();

        private ObservableCollection<Delivery> Deliveries { get; set; }

        public DeliveryView()
        {
            InitializeComponent();
            gridDeliveries.ItemsSource = LoadData();
        }

        private ObservableCollection<Delivery> LoadData()
        {
            IList<Delivery> deliveries = GetDeliveries();
            Deliveries = new ObservableCollection<Delivery>(deliveries);
            return Deliveries;
        }

        private IList<Delivery> GetDeliveries()
        {
            IList<Delivery> deliveries = deliveryService.GetDeliveries();
            return deliveries;
        }

        private void UpdateDeliveryClick(object sender, RoutedEventArgs e)
        {
            Delivery delivery = gridDeliveries.SelectedItem as Delivery;
            ManageDeliveryFormView form = new ManageDeliveryFormView(this, delivery);
            form.ShowDialog();

            if(form.DialogResult.Value == true)
            {
                gridDeliveries.ItemsSource = LoadData();
            }
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            IList<Delivery> deliveries = SearchDeliveries();
            Deliveries = new ObservableCollection<Delivery>();
            gridDeliveries.ItemsSource = Deliveries;
        }
        
        private IList<Delivery> SearchDeliveries()
        {
            IList<string> criteria = new List<string>();
            criteria.Add(textBoxDeliveryId.Text.ToString());
            criteria.Add(textBoxProviderName.Text.ToString());
            criteria.Add(datePickerEarlierDate.SelectedDate.Value.ToShortDateString());
            criteria.Add(datePickerLaterDate.SelectedDate.Value.ToShortDateString());
            IList<Delivery> deliveries = deliveryService.SearchDeliveries(criteria);
            return deliveries;
        }

        private void SearchClearClick(object sender, RoutedEventArgs e)
        {
            ClearFilters();
        }

        private void ClearFilters()
        {
            textBoxDeliveryId.Text = "";
            textBoxProviderName.Text = "";
            datePickerEarlierDate.SelectedDate = null;
            datePickerLaterDate.SelectedDate = null;
        }

        private void DeleteDeliveryClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybraną dostawę?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
            Delivery delivery = gridDeliveries.SelectedItem as Delivery;
            if(messageBoxResult == MessageBoxResult.Yes)
            {
                deliveryService.DeleteDelivery(delivery.Id);
                gridDeliveries.ItemsSource = LoadData();
            }
        }

        private void DeleteMultipleDeliveriesClick(object sender, RoutedEventArgs e)
        {
            IList<Delivery> deliveries = gridDeliveries.SelectedItems.Cast<Delivery>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybraną dostawę?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
            Delivery delivery = gridDeliveries.SelectedItem as Delivery;
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                deliveryService.DeleteDelivery(delivery.Id);
                gridDeliveries.ItemsSource = LoadData();
            }
        }

        private void AddDeliveryClick(object sender, RoutedEventArgs e)
        {
            ManageDeliveryFormView form = new ManageDeliveryFormView(this);
            form.ShowDialog();

            if (form.DialogResult.Value == true)
            {
                gridDeliveries.ItemsSource = LoadData();
            }
        }

        private void gridProductDisplayItems(object sender, RoutedEventArgs e)
        {

        }

        private void gridProductGeneratePz(object sender, RoutedEventArgs e)
        {
            if(gridDeliveries.SelectedItem != null)
            {
                Delivery delivery = gridDeliveries.SelectedItem as Delivery;
                SaveFileDialog svg = new SaveFileDialog();
                svg.Filter = "Documents (*.pdf)|*.pdf|All files (*.*)|*.*";
                svg.ShowDialog();
                incomingDocumentService.GeneratePdf(svg.FileName, delivery);
            }
        }
    }
}
