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
    /// Interaction logic for EmittedItemsView.xaml
    /// </summary>
    public partial class EmittedItemsView : Window
    {
        IItemService itemService = new ItemService();
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
        
        public EmittedItemsView(Product product)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Product = product;
            gridItems.ItemsSource = LoadData();
        }

        private IList<Item> GetAll()
        {
            try
            {
                IList<Item> items = itemService.GetEmittedItemsByProducts(Product.Id, null);
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
        
        private void ClearSearchClick(object sender, RoutedEventArgs e)
        {
            try
            {
                gridItems.ItemsSource = LoadData();
            }
            catch(Exception x)
            {
                MessageBox.Show("Błąd wyczyszczenia: " + x);
            }
        }

        private void SearchItemClick(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteMultipleItemsClick(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteAllItemsClick(object sender, RoutedEventArgs e)
        {

        }

        private void AddItemClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ManageItemFormView manageItemFormView = new ManageItemFormView(Product);
                manageItemFormView.Show();
            }
            catch(Exception x)
            {
                MessageBox.Show("Błąd dodawania: " + x);
            }
        }
        private void UpdateItemClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Item item = gridItems.SelectedItem as Item;
                ManageItemFormView manageItemFormView = new ManageItemFormView(Product, item);
                manageItemFormView.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd aktualizacji: " + x);
            }
        }
        private void DeleteItemClick(object sender, RoutedEventArgs e)
        {
            try
            {
                IItemService itemService = new ItemService();
                Item item = gridItems.SelectedItem as Item;
                itemService.DeleteItem(item.Id);
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd usuwania: " + x);
            }
        }
        private List<Item> GetItemById(int id)
        {
            try
            {
                IItemService itemService = new ItemService();
                List<Item> items = new List<Item>();
                Item item = itemService.GetItem(id);
                items.Add(item);
                return items;
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd wyświetlania: " + x);
                return null;
            }
        }
    }
}
