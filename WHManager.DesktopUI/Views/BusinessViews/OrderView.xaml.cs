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
using WHManager.BusinessLogic.Services.DocumentServices;
using WHManager.BusinessLogic.Services.DocumentServices.Interfaces;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DesktopUI.Views.FormViews;
using WHManager.DesktopUI.Views.WarehouseViews;

namespace WHManager.DesktopUI.Views.BusinessViews
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        private IInvoiceService invoiceService = new InvoiceService();
        private IOrderService orderService = new OrderService();
        private IClientService clientService = new ClientService();
        private IOutgoingDocumentService documentService = new OutgoingDocumentService();
        public ObservableCollection<Order> Orders
        {
            get;
            set;
        }

        public OrderView()
        {
            InitializeComponent();
            gridOrders.ItemsSource = LoadData();
            FillComboBox();
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


        private IList<Order> GetAll()
        {
            try
            {
                IOrderService orderService = new OrderService();
                IList<Order> orders = orderService.GetAllOrders();
                return orders;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyświetlania: " + e);
                return null;
            }

        }

        private ObservableCollection<Order> LoadData()
        {
            try
            {
                IList<Order> orders = GetAll();
                Orders = new ObservableCollection<Order>(orders);
                return Orders;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyświetlania: " + e);
                return null;
            }
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            IList<Order> orders = SearchOrders();
            Orders = new ObservableCollection<Order>(orders);
            gridOrders.ItemsSource = Orders;
        }

        private void SearchClearClick(object sender, RoutedEventArgs e)
        {
            textBoxClientName.Text = "";
            textBoxOrderId.Text = "";
            datePickerEarlierDateOrdered.SelectedDate = null;
            datePickerLaterDateOrdered.SelectedDate = null;
            datePickerEarlierDateRealized.SelectedDate = null;
            datePickerLaterDateRealized.SelectedDate = null;
            comboBoxRealized.SelectedIndex = 0;
            gridOrders.ItemsSource = LoadData();
        }

        private void AddOrderClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ManageOrderFormView manageOrderFormView = new ManageOrderFormView(this);
                manageOrderFormView.ShowDialog();
                if (manageOrderFormView.DialogResult.Value == true)
                {
                    gridOrders.ItemsSource = LoadData();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd dodawania: " + x);
            }
        }

        private void UpdateOrderClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (gridOrders.SelectedItem != null)
                {
                    Order order = gridOrders.SelectedItem as Order;
                    ManageOrderFormView manageOrderFormView = new ManageOrderFormView(this, order);
                    manageOrderFormView.ShowDialog();
                    if (manageOrderFormView.DialogResult.Value == true)
                    {
                        gridOrders.ItemsSource = LoadData();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd aktualizacji: " + x);
            }
        }

        private void DeleteOrderClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (gridOrders.SelectedItem != null)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrane zamówienia?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        IOrderService orderService = new OrderService();
                        Order order = gridOrders.SelectedItem as Order;
                        orderService.EmptyOrderFromItems(order);
                        orderService.DeleteOrder(order.Id);
                        gridOrders.ItemsSource = LoadData();
                    }
                    
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd usuwania: " + x);
            }
        }

        private void gridProductGeneratePdf(object sender, RoutedEventArgs e)
        {
            int? invoiceId = GenerateInvoice();
            if(invoiceId != null)
            {
                SaveFileDialog svg = new SaveFileDialog();
                svg.Filter = "Documents (*.pdf)|*.pdf|All files (*.*)|*.*";
                svg.ShowDialog();
                int invoiceIdNotNullabe = invoiceId.Value;

            }
        }

        private IList<Order> SearchOrders()
        {
            IList<string> criteria = new List<string>();
            criteria.Add(textBoxOrderId.Text.ToString());
            criteria.Add(textBoxClientName.Text.ToString());
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
            if (comboBoxRealized.SelectedIndex == 0)
            {
                criteria.Add(null);
            }
            else if (comboBoxRealized.SelectedIndex == 1)
            {
                criteria.Add("true");
            }
            else if (comboBoxRealized.SelectedIndex == 2)
            {
                criteria.Add("false");
            }
            IList<Order> orders = orderService.SearchOrders(criteria.ToList());
            return orders;
        }

        private int? GenerateInvoice()
        {
            return AddInvoice();
        }

        private void gridOrderRealizeOrder(object sender, RoutedEventArgs e)
        {
            if(gridOrders.SelectedItem != null)
            {
                Order order = gridOrders.SelectedItem as Order;
                if (order.IsRealized == true)
                {
                    MessageBox.Show("Zamówienie nie może zostać powtórnie zrealizowane");
                }
                else
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Realizacja zamówienia zablokuje możliwość edycji oraz wygeneruje fakturę oraz dokument WZ", "Czy chcesz kontynuować", MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {

                        bool result = orderService.RealizeOrder(order);
                        if (result == true)
                        {
                            gridOrders.ItemsSource = LoadData();
                            MessageBox.Show("Zamówienie zostało zrealizowane.");
                        }
                        else
                        {
                            MessageBox.Show("Błąd realizacji zamówienia.");
                        }
                    }
                }
            }
        }

        private void gridOrderGenerateWz(object sender, RoutedEventArgs e)
        {
            if (gridOrders.SelectedItem != null)
            {
                Order order = gridOrders.SelectedItem as Order;
                if (order.IsRealized == false)
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
                        documentService.GeneratePdf(svg.FileName, order);
                    }
                }
            }
        }

        private void gridOrderGenerateInvoice(object sender, RoutedEventArgs e)
        {
            if (gridOrders.SelectedItem != null)
            {
                Order order = gridOrders.SelectedItem as Order;
                if (order.IsRealized == false)
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
                        invoiceService.GeneratePdf(svg.FileName, order);
                    }
                }
            }

        }

        private void gridOrderDisplayItems(object sender, RoutedEventArgs e)
        {
            if (gridOrders.SelectedItem != null)
            {
                Order order = gridOrders.SelectedItem as Order;
                OrderItemsView itemsView = new OrderItemsView(order);
                itemsView.Show();
            }
        }

        private void gridOrderPrepareReturn(object sender, RoutedEventArgs e)
        {
            if (gridOrders.SelectedItem != null)
            {
                Order order = gridOrders.SelectedItem as Order;
                OrderItemsView itemsView = new OrderItemsView(order);
                itemsView.Show();
            }
        }

        private int? AddInvoice()
        {
            try
            {
                Order order = gridOrders.SelectedItem as Order;
                Invoice invoice = new Invoice
                {
                    DateIssued = DateTime.Now,
                    Client = clientService.GetClient(order.Client.Id)[0],
                    OrderId = order.Id
                };
                return invoiceService.CreateNewInvoice(invoice);
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd dodawania faktury: " + e);
                return null;
            }
        }
    }
}