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
        private List<DeliveryOrderTableContent> Elements { get; set; }
        private List<DeliveryOrderTableContent> ExistingElements { get; set; }
        IItemService itemService = new ItemService();
        IOrderService orderService = new OrderService();
        IProductService productService = new ProductService();
        public ManageOrderFormView(OrderView orderView)
        {
            InitializeComponent();
            OrderView = orderView;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            GetAllAvailableItems();
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
            GetAllAvailableItems();
            FillData();
        }

        private void GetAllAvailableItems()
        {
            ExistingElements = itemService.GroupItems().ToList();
            Elements = new List<DeliveryOrderTableContent>();
            gridExistingItems.ItemsSource = ExistingElements;
            if(Order != null)
            {
                Elements = orderService.GetElements(Order.Id).ToList();
                gridItems.ItemsSource = Elements;
            }
        }

        private void buttonOrdersConfirm(object sender, RoutedEventArgs e)
        {
            if(Order == null)
            {
                if (!Elements.Any())
                {
                    MessageBox.Show("Dodaj elementy do dostawy.");
                }
                else if (datepickerOrdersDate.SelectedDate == null)
                {
                    MessageBox.Show("Wybierz datę");
                }
                else
                {
                    AddOrder();
                    DialogResult = true;
                    this.Close();
                }
            }
            else
            {
                if (!Elements.Any())
                {
                    MessageBox.Show("Dodaj elementy do dostawy.");
                }
                else if (datepickerOrdersDate.SelectedDate == null)
                {
                    MessageBox.Show("Wybierz datę");
                }
                else
                {
                    UpdateOrder();
                    DialogResult = true;
                    this.Close();
                }
            }
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
        }

        private List<Item> GetItems(int id)
        {
            List<Item> items = itemService.GetItemsByProduct(id).ToList();
            return items;
        }
        private List<Product> GetProducts()
        {
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
            Order order = new Order
            {
                DateOrdered = datepickerOrdersDate.SelectedDate.Value.Date,
                Client = comboBoxOrdersClients.SelectedItem as Client
            };
            orderService.AddOrder(order, Elements);
        }
        private void buttonAddItemsToDelivery(object sender, RoutedEventArgs e)
        {
            AddElementToTable();
            gridItems.ItemsSource = new ObservableCollection<DeliveryOrderTableContent>(Elements);
            gridExistingItems.ItemsSource = new ObservableCollection<DeliveryOrderTableContent>(ExistingElements);
        }

        private bool AddElementToTable()
        {
            Product product = comboBoxOrdersProducts.SelectedItem as Product;
            if (Elements.Count == 0)
            {
                CreateNewTableContent(product);
                EmptyInputs();
                return true;
            }
            if (Elements.Any(x => x.ProductId == product.Id))
            {
                UpdateElements(product);
                EmptyInputs();
                return true;
            }
            CreateNewTableContent(product);
            EmptyInputs();
            return true;
        }

        private void CreateNewTableContent(Product product)
        {
            if (double.TryParse(textBoxDeliveryProductCount.Text, out double result) && result >= 1)
            {
                DeliveryOrderTableContent content = new DeliveryOrderTableContent(null, product.Id, product.Name, result);
                var existingElement = ExistingElements.SingleOrDefault(x => x.ProductId == product.Id);
                if(existingElement != null)
                {
                    if (result <= existingElement.Count)
                    {
                        existingElement.Count = existingElement.Count - result;
                        Elements.Add(content);
                    }
                    else
                    {
                        MessageBox.Show("Ilość produktów w zamówieniu nie może byc wieksza od ilości egzemplarzy w magazynie.");
                    }
                }
                else
                {
                    MessageBox.Show("Brak egzemplarzy w magazynie.");
                }
            }
            else
            {
                MessageBox.Show("Podaj poprawną ilość elementów");
            }
        }

        private void UpdateElements(Product product)
        {
            var element = Elements.SingleOrDefault(x => x.ProductId == product.Id);
            double previousCount = element.Count;
            double newCount = double.Parse(textBoxDeliveryProductCount.Text);
            if(newCount >= 1)
            {
                var existingElement = ExistingElements.SingleOrDefault(x => x.ProductId == product.Id);
                if (existingElement.Count + previousCount >= newCount)
                {
                    element.Count = newCount;
                    existingElement.Count = existingElement.Count + previousCount - element.Count;
                }
                else
                {
                    MessageBox.Show("Ilość produktów w zamówieniu nie może byc wieksza od ilości egzemplarzy w magazynie.");
                }
            }
            else
            {
                MessageBox.Show("Podaj poprawną ilość elementów.");
            }
        }

        private void EmptyInputs()
        {
            comboBoxOrdersProducts.SelectedItem = Products[0];
            textBoxDeliveryProductCount.Text = "";
        }

        private void UpdateOrder()
        {
            orderService.UpdateOrder(Order, Elements.ToList());
        }

        private void DeleteItemsClick(object sender, RoutedEventArgs e)
        {
            DeliveryOrderTableContent content = gridItems.SelectedItem as DeliveryOrderTableContent;
            Elements.Remove(content);
            var element = ExistingElements.SingleOrDefault(x => x.ProductId == content.ProductId);
            element.Count = element.Count + content.Count;
            gridItems.ItemsSource = new ObservableCollection<DeliveryOrderTableContent>(Elements);
            gridExistingItems.Items.Refresh();
        }
    }
}