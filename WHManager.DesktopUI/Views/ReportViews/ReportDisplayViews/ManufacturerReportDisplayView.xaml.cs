using Microsoft.Win32;
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
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.DocumentServices.Interfaces;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.BusinessLogic.Services.ReportsServices;
using WHManager.BusinessLogic.Services.ReportsServices.Interfaces;
using WHManager.DesktopUI.Views.WarehouseViews;

namespace WHManager.DesktopUI.Views.ReportViews.ReportDisplayViews
{
    /// <summary>
    /// Interaction logic for ManufacturerReportDisplayView.xaml
    /// </summary>
    public partial class ManufacturerReportDisplayView : UserControl
    {
        IDeliveryService deliveryService = new DeliveryService();
        IOrderService orderService = new OrderService();
        IProductReportsService reportService = new ProductReportsService();
        IOutgoingDocumentService outgoingDocumentService = new OutgoingDocumentService();
        IIncomingDocumentService incomingDocumentService = new IncomingDocumentService();
        IInvoiceService invoiceService = new InvoiceService();
        IProductService productService = new ProductService();
        IManufacturerService manufacturerService = new ManufacturerService();

        private ManufacturerReports Report { get; set; }
        private ObservableCollection<Order> Orders { get; set; }
        private ObservableCollection<Delivery> Deliveries { get; set; }
        private ObservableCollection<Product> Products { get; set; } 

        public ManufacturerReportDisplayView(ManufacturerReports reports)
        {
            InitializeComponent();
            Report = reports;
            gridDeliveries.Visibility = Visibility.Visible;
            FillCollections();
        }

        private void FillCollections()
        {
            IList<Delivery> deliveries = deliveryService.GetDeliveriesByManufacturer(Report);
            Deliveries = new ObservableCollection<Delivery>(deliveries);
            gridDeliveries.ItemsSource = Deliveries;

            IList<Order> orders = orderService.GetOrdersByManufacturer(Report);
            Orders = new ObservableCollection<Order>(orders);
            gridOrders.ItemsSource = Orders;

            IList<Product> products = productService.GetProductsByManufacturerId(deliveries, orders, Report.Manufacturer.Id);
            Products = new ObservableCollection<Product>(products);
            gridElements.ItemsSource = Products;

            AssignValuesToLabels(reportService.ParseLists(deliveries, orders, products));
        }

        private void AssignValuesToLabels(IDictionary<string, decimal> dictionary)
        {
            labelManufacturterName.Content = manufacturerService.GetManufacturer(Report.Manufacturer.Id).Name;
            labelItemCount.Content = dictionary["itemCount"];
            labelOrderCount.Content = dictionary["orderElementCount"];
            labelDeliveryCount.Content = dictionary["deliveryElementCount"];
            labelTotalValue.Content = dictionary["totalValue"];
        }

        private void DisplayElementsClick(object sender, RoutedEventArgs e)
        {
            gridOrders.Visibility = Visibility.Hidden;
            gridElements.Visibility = Visibility.Visible;
            gridDeliveries.Visibility = Visibility.Hidden;
        }

        private void DisplayOrdersClick(object sender, RoutedEventArgs e)
        {
            gridOrders.Visibility = Visibility.Visible;
            gridElements.Visibility = Visibility.Hidden;
            gridDeliveries.Visibility = Visibility.Hidden;
        }

        private void DisplayDeliveriesClick(object sender, RoutedEventArgs e)
        {
            gridOrders.Visibility = Visibility.Hidden;
            gridElements.Visibility = Visibility.Hidden;
            gridDeliveries.Visibility = Visibility.Visible;
        }

        private void gridDeliveriesDisplayItems(object sender, RoutedEventArgs e)
        {
            if (gridDeliveries.SelectedItem != null)
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
        private void gridDeliveriesGenerateWz(object sender, RoutedEventArgs e)
        {
            Delivery delivery = gridDeliveries.SelectedItem as Delivery;
            if (delivery.Realized == false)
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
        private void gridOrderDisplayItems(object sender, RoutedEventArgs e)
        {
            if (gridOrders.SelectedItem != null)
            {
                Order order = gridOrders.SelectedItem as Order;
                OrderItemsView itemsView = new OrderItemsView(order);
                itemsView.Show();
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
                        outgoingDocumentService.GeneratePdf(svg.FileName, order);
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
    }
}
