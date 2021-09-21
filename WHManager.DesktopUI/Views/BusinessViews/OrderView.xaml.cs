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

namespace WHManager.DesktopUI.Views.BusinessViews
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        private IInvoiceService invoiceService = new InvoiceService();
        private IOrderService orderService = new OrderService();
        private IPdfService pdfService = new PdfService();
        private IClientService clientService = new ClientService();
        public ObservableCollection<Order> Orders
        {
            get;
            set;
        }

        public OrderView()
        {
            InitializeComponent();
            gridOrders.ItemsSource = LoadData();
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
            textBoxClientName.Text = null;
            gridOrders.ItemsSource = LoadData();
        }

        private void AddOrderClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ManageOrderFormView manageOrderFormView = new ManageOrderFormView(this);
                manageOrderFormView.ShowDialog();
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
                    IOrderService orderService = new OrderService();
                    Order order = gridOrders.SelectedItem as Order;
                    orderService.DeleteOrder(order.Id);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd usuwania: " + x);
            }
        }

        private void DeleteMultipleOrdersClick(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Order> selectedOrders = gridOrders.SelectedItems.Cast<Order>().ToList();
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrane zamówienia?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        foreach (Order order in selectedOrders)
                        {
                            orderService.DeleteOrder(order.Id);
                        }
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

                pdfService.GeneratePdf(svg.FileName, invoiceIdNotNullabe);
            }
        }

        private void gridProductGenerateWz(object sender, RoutedEventArgs e)
        {

        }

        private IList<Order> SearchOrders()
        {
            IList<string> criteria = new List<string>();
            criteria.Add(textBoxOrderId.Text.ToString());
            criteria.Add(textBoxClientName.Text.ToString());
            criteria.Add(datePickerEarlierDate.SelectedDate.Value.ToShortDateString());
            criteria.Add(datePickerLaterDate.SelectedDate.Value.ToShortDateString());
            IList<Order> orders = orderService.SearchOrders(criteria.ToList());
            return orders;
        }

        private int? GenerateInvoice()
        {
            return AddInvoice();
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
                    Order = order
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