using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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
using System.ComponentModel;
using WHManager.BusinessLogic.Services.DocumentServices;
using WHManager.BusinessLogic.Services.DocumentServices.Interfaces;
using WHManager.DesktopUI.Views.BusinessViews.BusinessFormViews;

namespace WHManager.DesktopUI.Views.BusinessViews
{
    /// <summary>
    /// Interaction logic for InvoiceView.xaml
    /// </summary>
    public partial class InvoiceView : UserControl
    {
        public ObservableCollection<Invoice> Invoices
        {
            get;
            set;
        }

        public Invoice Invoice
        {
            get;
            set;
        }

        public InvoiceView()
        {
            InitializeComponent();
            gridInvoices.ItemsSource = LoadData();
        }

        private IList<Invoice> GetAll()
        {
            try
            {
                IInvoiceService invoiceService = new InvoiceService();
                IList<Invoice> invoices = invoiceService.GetInvoices();
                return invoices;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyświetlania: " + e);
                return null;
            }

        }

        private ObservableCollection<Invoice> LoadData()
        {
            try
            {
                IList<Invoice> invoices = GetAll();
                Invoices = new ObservableCollection<Invoice>(invoices);
                return Invoices;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyświetlania: " + e);
                return null;
            }
        }

        private void buttonSearchClick(object sender, RoutedEventArgs e)
        {
            if (radioButtonId.IsChecked == true)
            {
                try
                {
                    List<Invoice> invoices = GetInvoicesById(int.Parse(textBoxInvoicesSearch.Text));
                    Invoices = new ObservableCollection<Invoice>(invoices);
                    gridInvoices.ItemsSource = Invoices;
                }
                catch (Exception x)
                {
                    MessageBox.Show("Błąd wyszukiwania: " + x);
                }
            }
            else if (radioButtonClient.IsChecked == true)
            {
                try
                {
                    List<Invoice> invoices = GetInvoicesByClient(int.Parse(textBoxInvoicesSearch.Text));
                    Invoices = new ObservableCollection<Invoice>(invoices);
                    gridInvoices.ItemsSource = Invoices;
                }
                catch (Exception x)
                {
                    MessageBox.Show("Błąd wyszukiwania: " + x);
                }
            }
            else if (radioButtonDate.IsChecked == true)
            {
                try
                {
                    List<Invoice> invoices = GetInvoicesByDate(datePickerEarlierDate.SelectedDate, datePickerLaterDate.SelectedDate);
                    Invoices = new ObservableCollection<Invoice>(invoices);
                    gridInvoices.ItemsSource = Invoices;
                }
                catch (Exception x)
                {
                    MessageBox.Show("Błąd wyszukiwania: " + x);
                }
            }

        }

        private void buttonClearClick(object sender, RoutedEventArgs e)
        {
            try
            {
                textBoxInvoicesSearch.Text = null;
                gridInvoices.ItemsSource = LoadData();
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd czyszczenia: " + x);
            }
        }

        private void buttonAddInvoiceClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ManageInvoiceFormView manageInvoiceFormView = new ManageInvoiceFormView();
                manageInvoiceFormView.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd dodawania: " + x);
            }
        }

        private void buttonUpdateInvoiceClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (gridInvoices.SelectedItem != null)
                {
                    Invoice invoice = gridInvoices.SelectedItem as Invoice;
                    ManageInvoiceFormView manageInvoiceFormView = new ManageInvoiceFormView(invoice);
                    manageInvoiceFormView.Show();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd aktualizacji: " + x);
            }
        }

        private void buttonDeleteInvoiceClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (gridInvoices.SelectedItem != null)
                {
                    IInvoiceService invoiceService = new InvoiceService();
                    Invoice invoice = gridInvoices.SelectedItem as Invoice;
                    invoiceService.DeleteInvoice(invoice.Id);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd usuwania: " + x);
            }
        }

        private List<Invoice> GetInvoicesByDate(DateTime? earlierDate, DateTime? laterDate)
        {
            IInvoiceService invoiceService = new InvoiceService();
            List<Invoice> invoicesList = new List<Invoice>();
            if (datePickerEarlierDate.SelectedDate != null && datePickerLaterDate.SelectedDate != null)
            {
                invoicesList = invoiceService.GetInvoicesByDate(earlierDate, laterDate).ToList();
                return invoicesList;
            }
            else if (datePickerEarlierDate.SelectedDate != null && datePickerLaterDate.SelectedDate == null)
            {
                invoicesList = invoiceService.GetInvoicesByDate(earlierDate, null).ToList();
                return invoicesList;
            }
            else if (datePickerEarlierDate.SelectedDate == null && datePickerLaterDate.SelectedDate != null)
            {
                invoicesList = invoiceService.GetInvoicesByDate(null, laterDate).ToList();
                return invoicesList;
            }
            else
            {
                invoicesList = invoiceService.GetInvoicesByDate(null, null).ToList();
                return invoicesList;
            }
        }
        private List<Invoice> GetInvoicesById(int id)
        {
            IInvoiceService invoiceService = new InvoiceService();
            List<Invoice> invoicesList = new List<Invoice>();
            Invoice invoice = invoiceService.GetInvoiceById(id);
            invoicesList.Add(invoice);
            return invoicesList;
        }

        private List<Invoice> GetInvoicesByClient(int clientId)
        {
            IInvoiceService invoiceService = new InvoiceService();
            List<Invoice> invoicesList = invoiceService.GetInvoicesByClient(clientId).ToList();
            return invoicesList;
        }

        private void radioButtonIdClick(object sender, RoutedEventArgs e)
        {
            if (radioButtonId.IsChecked == true)
            {
                textBoxInvoicesSearch.Visibility = Visibility.Visible;
                datePickerEarlierDate.Visibility = Visibility.Hidden;
                datePickerLaterDate.Visibility = Visibility.Hidden;
            }
        }

        private void radioButtonClientClick(object sender, RoutedEventArgs e)
        {
            if (radioButtonClient.IsChecked == true)
            {
                textBoxInvoicesSearch.Visibility = Visibility.Visible;
                datePickerEarlierDate.Visibility = Visibility.Hidden;
                datePickerLaterDate.Visibility = Visibility.Hidden;
            }
        }

        private void radioButtonDateClick(object sender, RoutedEventArgs e)
        {
            if (radioButtonDate.IsChecked == true)
            {
                textBoxInvoicesSearch.Visibility = Visibility.Hidden;
                datePickerEarlierDate.Visibility = Visibility.Visible;
                datePickerLaterDate.Visibility = Visibility.Visible;
            }
        }
        private void gridProductGeneratePdf(object sender, RoutedEventArgs e)
        {
            GeneratePdf();
        }

        private void GeneratePdf()
        {
            if(gridInvoices.SelectedItem != null)
            {
                Invoice = gridInvoices.SelectedItem as Invoice;
            }
            InvoiceFormView invoice = new InvoiceFormView(Invoice);
            invoice.Show();
        }
    }
}
