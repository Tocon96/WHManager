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
namespace WHManager.DesktopUI.Views.FormViews
{
    /// <summary>
    /// Interaction logic for ManageInvoiceFormView.xaml
    /// </summary>
    public partial class ManageInvoiceFormView : Window
    {
        public ObservableCollection<Client> Clients
        {
            get;
            set;
        }

        public Order Order
        {
            get;
            set;
        }

        public Invoice Invoice
        {
            get;
            set;
        }
        public ManageInvoiceFormView()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            FillComboBox();
        }

        public ManageInvoiceFormView(Invoice invoice)
        {
            InitializeComponent();
            FillComboBox();
            Invoice = invoice;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            datepickerInvoicesDateIssued.SelectedDate = Invoice.DateIssued;
            textBoxInvoicesOrderId.Text = Invoice.Order.Id.ToString();
        }

        private void buttonConfirmClick(object sender, RoutedEventArgs e)
        {
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {

        }

        private void FillComboBox()
        {
            try
            {
                IList<Client> clients = GetClients();
                Clients = new ObservableCollection<Client>(clients);
                comboBoxInvoicesClients.ItemsSource = Clients;
                comboBoxInvoicesClients.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyświetlania: " + e);
            }
            
        }
        private IList<Client> GetClients()
        {
            try
            {
                IClientService clientService = new ClientService();
                IList<Client> clients = clientService.GetAllClients();
                return clients;
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd wyświetlania: " + e);
                return null;
            }
        }
        private Order GetOrder()
        {
            try
            {
                IOrderService orderService = new OrderService();
                Order = orderService.GetOrderById(int.Parse(textBoxInvoicesOrderId.Text));
                return Order;
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd pobierania zamówienia: " + e);
                return null;
            }
        }

        private void AddInvoice()
        {
            try
            {
                IInvoiceService invoiceService = new InvoiceService();
                Invoice invoice = new Invoice
                {
                    DateIssued = (DateTime)datepickerInvoicesDateIssued.SelectedDate,
                    Client = comboBoxInvoicesClients.SelectedItem as Client,
                    Order = GetOrder()
                };
                invoiceService.CreateNewInvoice(invoice);
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd dodawania faktury: " + e);
            }
            
        }
        private void UpdateInvoice()
        {
            try
            {
                IInvoiceService invoiceService = new InvoiceService();
                Invoice invoice = new Invoice
                {
                    DateIssued = (DateTime)datepickerInvoicesDateIssued.SelectedDate,
                    Client = comboBoxInvoicesClients.SelectedItem as Client,
                    Order = GetOrder()
                };
                invoiceService.UpdateInvoice(invoice);
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd dodawania faktury: " + e);
            }
        }
    }
}