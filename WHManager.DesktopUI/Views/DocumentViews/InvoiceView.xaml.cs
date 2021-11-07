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
using Microsoft.Win32;

namespace WHManager.DesktopUI.Views.BusinessViews
{
    /// <summary>
    /// Interaction logic for InvoiceView.xaml
    /// </summary>
    public partial class InvoiceView : UserControl
    {
        IInvoiceService invoiceService = new InvoiceService();
        IOrderService orderService = new OrderService();
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

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Invoice> invoices = SearchInvoices().ToList();
                Invoices = new ObservableCollection<Invoice>(invoices);
                gridInvoices.ItemsSource = Invoices;
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd wyszukiwania: " + x);
            }
        }

        private void SearchClearClick(object sender, RoutedEventArgs e)
        {
            try
            {
                textBoxInvoiceId.Text = null;
                textBoxClientName.Text = null;
                datePickerEarlierDate.SelectedDate = null;
                datePickerLaterDate.SelectedDate = null;
                gridInvoices.ItemsSource = LoadData();
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd czyszczenia: " + x);
            }
        }

        private void DownloadDocumentClick(object sender, RoutedEventArgs e)
        {
            GeneratePdf();
        }

        private void GeneratePdf()
        {
            if (gridInvoices.SelectedItem != null)
            {
                Invoice invoice = gridInvoices.SelectedItem as Invoice;
                Order order = orderService.GetOrderById(invoice.Id);
                SaveFileDialog svg = new SaveFileDialog();
                svg.Filter = "Documents (*.pdf)|*.pdf|All files (*.*)|*.*";
                Nullable<bool> result = svg.ShowDialog();
                if (result == true)
                {
                    invoiceService.GeneratePdf(svg.FileName, order);
                }
            }
        }

        private IList<Invoice> SearchInvoices()
        {
            List<string> criteria = new List<string>();
            criteria.Add(textBoxInvoiceId.Text.ToString());
            criteria.Add(textBoxClientName.Text.ToString());
            if (datePickerEarlierDate.SelectedDate.HasValue == true)
            {
                criteria.Add(datePickerEarlierDate.SelectedDate.Value.Date.ToShortDateString());
            }
            else
            {
                criteria.Add("");
            }

            if (datePickerLaterDate.SelectedDate.HasValue == true)
            {
                criteria.Add(datePickerLaterDate.SelectedDate.Value.Date.ToShortDateString());
            }
            else
            {
                criteria.Add("");
            }
            IList<Invoice> invoices = invoiceService.SearchInvoices(criteria);
            return invoices;
        }
    }
}
