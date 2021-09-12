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
using WHManager.DesktopUI.Views.FormViews;

namespace WHManager.DesktopUI.Views.WarehouseViews
{
    /// <summary>
    /// Interaction logic for ItemView.xaml
    /// </summary>
    public partial class ItemView : Window
    {
        private Product _product;
        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }
        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public ItemView(Product product)
        {
            InitializeComponent();
            Product = product;
            gridItems.ItemsSource = LoadData();
        }
        private IList<Item> GetAll()
        {
            try
            {
                IItemService itemService = new ItemService();
                IList<Item> items = itemService.GetItemsByProduct(Product.Id, null);
                return items;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wczytywania: " + e);
                return null;
            }
        }
        private ObservableCollection<Item> LoadData()
        {
            try
            {
                List<Item> items = GetAll().ToList();
                Items = new ObservableCollection<Item>(items);
                return Items;

            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wczytywania: " + e);
                return null;
            }
        }
        private void SearchItemClick(object sender, RoutedEventArgs e)
        {

        }
        private void ClearSearchClick(object sender, RoutedEventArgs e)
        {
            gridItems.ItemsSource = LoadData();
        }
        private void AddItemClick(object sender, RoutedEventArgs e)
        {
            ManageItemFormView manageItemFormView = new ManageItemFormView(Product);
            manageItemFormView.Show();
        }
        private void UpdateItemClick(object sender, RoutedEventArgs e)
        {
            Item item = gridItems.SelectedItem as Item;
            ManageItemFormView manageItemFormView = new ManageItemFormView(Product, item);
            manageItemFormView.Show();
        }
        private void DeleteItemClick(object sender, RoutedEventArgs e)
        {
            IItemService itemService = new ItemService();
            Item item = gridItems.SelectedItem as Item;
            itemService.DeleteItem(item.Id);
        }

        private void DeleteMultipleItemsClick(object sender, RoutedEventArgs e)
        {
            IItemService itemService = new ItemService();
            Item item = gridItems.SelectedItem as Item;
            itemService.DeleteItem(item.Id);
        }

        private void DeleteAllItemsClick(object sender, RoutedEventArgs e)
        {
            IItemService itemService = new ItemService();
            Item item = gridItems.SelectedItem as Item;
            itemService.DeleteItem(item.Id);
        }

        private List<Item> GetItemById(int id)
        {
            IItemService itemService = new ItemService();
            List<Item> items = new List<Item>();
            Item item = itemService.GetItem(id);
            items.Add(item);
            return items;
        }
    }
}