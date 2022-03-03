using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using WHManager.BusinessLogic.Services.ReportsServices;
using WHManager.BusinessLogic.Services.ReportsServices.Interfaces;

namespace WHManager.DesktopUI.Views.ReportViews.ReportDisplayViews
{
    /// <summary>
    /// Interaction logic for ReportDisplayView.xaml
    /// </summary>
    public partial class ContrahentReportDisplayView : UserControl
    {
        IOrderService orderService = new OrderService();
        IDeliveryService deliveryService = new DeliveryService();
        IContrahentReportsService reportService = new ContrahentReportService();
        private ContrahentReports Report { get; set; }
        private ObservableCollection<Order> Orders { get; set; }
        private ObservableCollection<Delivery> Deliveries { get; set; }
        private ObservableCollection<Item> Items { get; set; }
        public ContrahentReportDisplayView(ContrahentReports report)
        {
            InitializeComponent();
            Report = report;
            if (Report.ReportOrigin == "Clients")
            {
                IList<Order> orders = orderService.GetRealizedOrdersByClient(report.ContrahentId);
                Orders = new ObservableCollection<Order>(orders);
                gridOrders.ItemsSource = Orders;
                gridOrders.Visibility = Visibility.Visible;
                AssignValuesToLabels(reportService.ParseOrderList(orders.ToList()));
            }

            if (Report.ReportOrigin == "Providers")
            {
                IList<Delivery> deliveries = deliveryService.GetRealizedDeliveriesByProvider(report.ContrahentId);
                Deliveries = new ObservableCollection<Delivery>(deliveries);
                gridOrders.ItemsSource = Deliveries;
                gridOrders.Visibility = Visibility.Visible;
                AssignValuesToLabels(reportService.ParseDeliveryList(deliveries.ToList()));
            }
            
        }

        private void AssignValuesToLabels(IDictionary<string, double> dictionary)
        {
            labelItemCount.Content = dictionary["itemCount"];
            labelOrderCount.Content = dictionary["elementCount"];
            labelTotalValue.Content = dictionary["totalValue"];
        }

        private void DisplayElementsClick(object sender, RoutedEventArgs e)
        {

            gridOrders.Visibility = Visibility.Hidden;
            gridElements.Visibility = Visibility.Visible;
        }

        private void DisplayOrdersClick(object sender, RoutedEventArgs e)
        {
            gridOrders.Visibility = Visibility.Visible;
            gridElements.Visibility = Visibility.Hidden;    

        }
    }
}