using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WHManager.DesktopUI.Views.BusinessViews.BusinessFormViews
{
    /// <summary>
    /// Interaction logic for InvoiceFormView.xaml
    /// </summary>
    public partial class InvoiceFormView : Window
    {
        IOrderService orderService = new OrderService();
        IProductService productService = new ProductService();
        public Invoice Invoice
        {
            get;
            set;
        }

        public ObservableCollection<Product> Products
        {
            get;
            set;
        }

        public InvoiceFormView(Invoice invoice)
        {
            InitializeComponent();
            Invoice = invoice;
            FillInvoice();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
        private void FillInvoice()
        {
            var dateOrder = Invoice.Order.DateOrdered.ToShortDateString();
            var dateInvoice = Invoice.DateIssued.Date.ToShortDateString();
            Products = new ObservableCollection<Product>(orderService.GetSortedProducts(Invoice.Order));
            textBlockCustomerName.Text = Invoice.Order.Client.Name;
            textBoxDateIssued.Text = dateInvoice;
            textBoxPriceTotal.Text = ("PLN "+ orderService.CalculateFinalPrice(Invoice.Order).ToString("#.##"));
            textboxCustomerNip.Text = Invoice.Order.Client.Nip.ToString();
            textboxCustomerPhoneNumber.Text = Invoice.Order.Client.PhoneNumber;
            textboxIssuedDate.Text = dateOrder;
            textboxInvoiceId.Text = Invoice.Id.ToString();
            listViewItems.ItemsSource = Products;
        }
    }
}
