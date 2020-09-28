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
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
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

        private void buttonSearchClick(object sender, RoutedEventArgs e)
        {
            if(radioButtonId.IsChecked == true)
            {
                try
                {
                    IList<Order> orders = GetOrderById(int.Parse(textBoxOrdersSearch.Text));
                    Orders = new ObservableCollection<Order>(orders);
                    gridOrders.ItemsSource = Orders;
                }
                catch(Exception x)
                {
                    MessageBox.Show("Błąd szukania: " + x);
                }
            }
            else if(radioButtonClient.IsChecked == true)
            {
                try
                {
                    IList<Order> orders = GetOrdersByClient(int.Parse(textBoxOrdersSearch.Text));
                    Orders = new ObservableCollection<Order>(orders);
                    gridOrders.ItemsSource = Orders;
                }
                catch (Exception x)
                {
                    MessageBox.Show("Błąd szukania: " + x);
                }
            }
            else if(radioButtonDate.IsChecked == true)
            {
                try
                {
                    IList<Order> orders = GetOrdersByDate(datePickerEarlierDate.SelectedDate, datePickerLaterDate.SelectedDate);
                    Orders = new ObservableCollection<Order>(orders);
                    gridOrders.ItemsSource = Orders;
                }
                catch (Exception x)
                {
                    MessageBox.Show("Błąd szukania: " + x);
                }
            }
        }

        private void buttonClearClick(object sender, RoutedEventArgs e)
        {
            textBoxOrdersSearch.Text = null;
            gridOrders.ItemsSource = LoadData();
        }

        private void buttonAddOrderClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ManageOrderFormView manageOrderFormView = new ManageOrderFormView();
                manageOrderFormView.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd dodawania: " + x);
            }
        }

        private void buttonUpdateOrderClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (gridOrders.SelectedItem != null)
                {
                    Order order = gridOrders.SelectedItem as Order;
                    ManageOrderFormView manageOrderFormView = new ManageOrderFormView(order);
                    manageOrderFormView.Show();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd aktualizacji: " + x);
            }
        }

        private void buttonDeleteOrderClick(object sender, RoutedEventArgs e)
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

        private void radioButtonIdClick(object sender, RoutedEventArgs e)
        {
            if (radioButtonId.IsChecked == true)
            {
                textBoxOrdersSearch.Visibility = Visibility.Visible;
                datePickerEarlierDate.Visibility = Visibility.Hidden;
                datePickerLaterDate.Visibility = Visibility.Hidden;
            }
        }

        private void radioButtonClientClick(object sender, RoutedEventArgs e)
        {
            if (radioButtonClient.IsChecked == true)
            {
                textBoxOrdersSearch.Visibility = Visibility.Visible;
                datePickerEarlierDate.Visibility = Visibility.Hidden;
                datePickerLaterDate.Visibility = Visibility.Hidden;
            }
        }

        private void radioButtonDateClick(object sender, RoutedEventArgs e)
        {
            if (radioButtonDate.IsChecked == true)
            {
                textBoxOrdersSearch.Visibility = Visibility.Hidden;
                datePickerEarlierDate.Visibility = Visibility.Visible;
                datePickerLaterDate.Visibility = Visibility.Visible;
            }
        }
        private List<Order> GetOrderById(int id)
        {
            IOrderService orderService = new OrderService();
            List<Order> ordersList = new List<Order>();
            Order order = orderService.GetOrderById(id);
            ordersList.Add(order);
            return ordersList;
        }
        private List<Order> GetOrdersByClient(int clientId)
        {
            IOrderService orderService = new OrderService();
            List<Order> ordersList = orderService.GetOrdersByClient(clientId).ToList();
            return ordersList;
        }
        private List<Order> GetOrdersByDate(DateTime? earlierDate, DateTime? laterDate)
        {
            IOrderService orderService = new OrderService();
            List<Order> ordersList = new List<Order>();
            if (datePickerEarlierDate.SelectedDate != null && datePickerLaterDate.SelectedDate != null)
            {
                ordersList = orderService.GetOrdersByDate(earlierDate, laterDate).ToList();
                return ordersList;
            }
            else if (datePickerEarlierDate.SelectedDate != null && datePickerLaterDate.SelectedDate == null)
            {
                ordersList = orderService.GetOrdersByDate(earlierDate, null).ToList();
                return ordersList;
            }
            else if (datePickerEarlierDate.SelectedDate == null && datePickerLaterDate.SelectedDate != null)
            {
                ordersList = orderService.GetOrdersByDate(null, laterDate).ToList();
                return ordersList;
            }
            else
            {
                ordersList = orderService.GetOrdersByDate(null, null).ToList();
                return ordersList;
            }
        }
    }
}
