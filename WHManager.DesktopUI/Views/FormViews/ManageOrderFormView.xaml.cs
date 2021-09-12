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
using System.Windows.Shapes;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DesktopUI.Views.BusinessViews;
namespace WHManager.DesktopUI.Views.FormViews
{
    /// <summary>
    /// Interaction logic for ManageOrderFormView.xaml
    /// </summary>
    public partial class ManageOrderFormView : Window
    {
        public ObservableCollection<Product> Products
        {
            get;
            set;
        }

        public ObservableCollection<Item> Items
        {
            get;
            set;
        }

        public List<Item> ItemsList
        {
            get;
            set;
        }

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

        public OrderView OrderView
        {
            get;
            set;
        }

        public ManageOrderFormView(OrderView orderView)
        {
            InitializeComponent();
            OrderView = orderView;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            FillData();
        }

        public ManageOrderFormView(OrderView orderView, Order order)
        {
            InitializeComponent();
            Order = order;
            OrderView = orderView;
            datepickerOrdersDate.SelectedDate = Order.DateOrdered;
            comboBoxOrdersClients.SelectedIndex = Order.Client.Id;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            textBlockManageOrder.Text = "Edytuj zamówienie o ID: " + Order.Id;
            FillData();
        }

        private void buttonOrdersConfirm(object sender, RoutedEventArgs e)
        {
            if(Order == null)
            {
                AddOrder();
            }
            else
            {
                UpdateOrder();
            }
            DialogResult = true;
            this.Close();
        }

        private void buttonOrdersCancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        public void OnDialogClose()
        {
            OrderView.gridOrders.Items.Refresh();
        }

        private void comboBoxOrdersProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product product = comboBoxOrdersProducts.SelectedItem as Product;

            List<Item> items = GetItems(product.Id);
            Items = new ObservableCollection<Item>(items);
            gridItems.ItemsSource = Items;
        }

        private void FillData()
        {
            List<Product> products = GetProducts();
            List<Client> clients = GetClients();
            

            Products = new ObservableCollection<Product>(products);
            Clients = new ObservableCollection<Client>(clients);
            

            comboBoxOrdersClients.ItemsSource = Clients;
            comboBoxOrdersClients.SelectedIndex = 0;
            comboBoxOrdersProducts.ItemsSource = Products;
            comboBoxOrdersProducts.SelectedIndex = 0;

            Product product = comboBoxOrdersProducts.SelectedItem as Product;

            List<Item> items = GetItems(product.Id);
            Items = new ObservableCollection<Item>(items);
            gridItems.ItemsSource = Items;

            ItemsList = new List<Item>();
        }

        private List<Item> GetItems(int id)
        {
            IItemService itemService = new ItemService();
            List<Item> items = itemService.GetItemsByProduct(id).ToList();
            return items;
        }
        private List<Product> GetProducts()
        {
            IProductService productService = new ProductService();
            List<Product> products = productService.GetProducts().ToList();
            return products;
        }
        private List<Client> GetClients()
        {
            IClientService clientService = new ClientService();
            List<Client> clients = clientService.GetAllClients().ToList();
            return clients;
        }

        private void AddOrder()
        {
            if (gridItems.SelectedItems != null)
            {
                IOrderService orderService = new OrderService();
                IItemService itemService = new ItemService();
                decimal price = 0;
                foreach(var item in ItemsList)
                {
                    price = price+item.Product.PriceSell;
                    item.IsInStock = false;
                    itemService.UpdateItem(item);
                }

                Order order = new Order
                {
                    Client = comboBoxOrdersClients.SelectedItem as Client,
                    Items = ItemsList,
                    DateOrdered = (DateTime)datepickerOrdersDate.SelectedDate,
                    Price = price,
                };
                orderService.AddOrder(order);
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć przedmioty do zamówienia.");
            }
        }
        private void UpdateOrder()
        {

            if (gridItems.SelectedItems != null)
            {
                IOrderService orderService = new OrderService();
                IItemService itemService = new ItemService();
                decimal price = 0;
                foreach (var item in ItemsList)
                {
                    price = price+ item.Product.PriceSell;
                    item.IsInStock = false;
                    itemService.UpdateItem(item);
                }

                Order order = new Order
                {
                    Id = Order.Id,
                    Client = comboBoxOrdersClients.SelectedItem as Client,
                    Items = ItemsList,
                    DateOrdered = (DateTime)datepickerOrdersDate.SelectedDate,
                    Price = price,
                };
                orderService.UpdateOrder(order);
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć przedmioty do zamówienia.");
            }
        }

        private void gridItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (gridItems.SelectedItem != null)
            {
                Item item = gridItems.SelectedItem as Item;
                var index = gridItems.SelectedIndex;
                ItemsList.Add(item);
                DataGridRow row = (DataGridRow)((DataGrid)sender).ItemContainerGenerator.ContainerFromIndex(index);
                row.Background = new SolidColorBrush(Colors.Aquamarine);
                MessageBox.Show("Przedmiot został dodany do listy");
            }
        }
    }
}