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
using WHManager.DesktopUI.Views.WarehouseViews;

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
            FillComboBox();
        }

        private ObservableCollection<Delivery> LoadData()
        {
            IList<Delivery> deliveries = GetDeliveries();
            Deliveries = new ObservableCollection<Delivery>(deliveries);
            return Deliveries;
        }

        private void FillComboBox()
        {
            IList<string> comboBox = new List<string>();
            comboBox.Add("Wszystkie");
            comboBox.Add("Zrealizowane");
            comboBox.Add("Niezrealizowane");
            comboBoxRealized.ItemsSource = comboBox;
            comboBoxRealized.SelectedIndex = 0;
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
            if (datePickerEarlierDateOrdered.SelectedDate.HasValue)
            {
                criteria.Add(datePickerEarlierDateOrdered.SelectedDate.Value.ToShortDateString());
            }
            else
            {
                criteria.Add(null);
            }
            if (datePickerLaterDateOrdered.SelectedDate.HasValue)
            {
                criteria.Add(datePickerLaterDateOrdered.SelectedDate.Value.ToShortDateString());
            }
            else
            {
                criteria.Add(null);
            }
            if (datePickerEarlierDateRealized.SelectedDate.HasValue)
            {
                criteria.Add(datePickerEarlierDateRealized.SelectedDate.Value.ToShortDateString());
            }
            else
            {
                criteria.Add(null);
            }
            if (datePickerLaterDateRealized.SelectedDate.HasValue)
            {
                criteria.Add(datePickerLaterDateRealized.SelectedDate.Value.ToShortDateString());
            }
            else
            {
                criteria.Add(null);
            }
            if(comboBoxRealized.SelectedIndex == 0)
            {
                criteria.Add(null);
            }
            else if(comboBoxRealized.SelectedIndex == 1)
            {
                criteria.Add("1");
            }else if(comboBoxRealized.SelectedIndex == 2)
            {
                criteria.Add("0");
            }
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
            datePickerEarlierDateOrdered.SelectedDate = null;
            datePickerLaterDateOrdered.SelectedDate = null;
            datePickerEarlierDateRealized.SelectedDate = null;
            datePickerLaterDateRealized.SelectedDate = null;
            comboBoxRealized.SelectedIndex = 0;
        }

        private void DeleteDeliveryClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybraną dostawę?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
            if(messageBoxResult == MessageBoxResult.Yes)
            {
                Delivery delivery = gridDeliveries.SelectedItem as Delivery;
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

        private void gridDeliveryDisplayItems(object sender, RoutedEventArgs e)
        {
            if(gridDeliveries.SelectedItem != null)
            {
                Delivery delivery = gridDeliveries.SelectedItem as Delivery;
                if (delivery.Realized == false)
                {
                    MessageBox.Show("Zamówienie musi zostać zrealizowane przed wyświetleniem elementów.");
                }
                else
                {
                    DeliveryItemsView itemsView = new DeliveryItemsView(delivery);
                    itemsView.Show();
                }
            }
        }

        private void gridDeliveryGeneratePz(object sender, RoutedEventArgs e)
        {
            if(gridDeliveries.SelectedItem != null)
            {
                Delivery delivery = gridDeliveries.SelectedItem as Delivery;
                if(delivery.Realized == false)
                {
                    MessageBox.Show("Zamówienie musi zostać zrealizowane przed wygenerowaniem dokumentu.");
                }
                else
                {
                    SaveFileDialog svg = new SaveFileDialog();
                    svg.Filter = "Documents (*.pdf)|*.pdf|All files (*.*)|*.*";
                    Nullable<bool> result = svg.ShowDialog();
                    if (result == true)
                    {
                        incomingDocumentService.GeneratePdf(svg.FileName, delivery);
                    }
                }
            }
        }

        private void gridDeliveryRealizeDelivery(object sender, RoutedEventArgs e)
        {
            if (gridDeliveries.SelectedItem != null)
            { 
                Delivery delivery = gridDeliveries.SelectedItem as Delivery;
                if(delivery.Realized == true)
                {
                    MessageBox.Show("Zamówienie nie może zostać powtórnie zrealizowane");
                }
                else
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Zatwierdzenie dostawy zablokuje możliwość edycji i usunięcia zamówienia oraz umożliwi wygenerowanie dokumentu przyjęcia zewnętrznego.", "Potwierdź zatwierdzenie", MessageBoxButton.YesNo);
                    {
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            deliveryService.RealizeDelivery(delivery);
                            gridDeliveries.ItemsSource = LoadData();
                        }
                    }

                }
            }
        }
    }
}
