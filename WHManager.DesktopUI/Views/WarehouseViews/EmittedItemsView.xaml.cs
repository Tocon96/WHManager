﻿using System;
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
        private void SearchItemsClick(object sender, RoutedEventArgs e)
        {
            if (radioButtonId.IsChecked == true)
            {
                try
                {
                    if(SearchTextBox.Text != "")
                    {
                        List<Item> items = GetItemById(int.Parse(SearchTextBox.Text));
                        Items = new ObservableCollection<Item>(items);
                        gridItems.ItemsSource = Items;
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show("Błąd wyszukiwania: " + x);
                }
            }
            else if (radioButtonDateOfPurchase.IsChecked == true)
            {
                try
                {
                    List<Item> items = GetItemByDate(datePickerEarlierDate.SelectedDate, datePickerLaterDate.SelectedDate);
                    Items = new ObservableCollection<Item>(items);
                    gridItems.ItemsSource = Items;
                }
                catch (Exception x)
                {
                    MessageBox.Show("Błąd wyszukiwania: " + x);
                }
            }
        }
        private void ClearSearchClick(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = null;
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
        private List<Item> GetItemById(int id)
        {
            IItemService itemService = new ItemService();
            List<Item> items = new List<Item>();
            Item item = itemService.GetItem(id);
            items.Add(item);
            return items;
        }
        private void radioButtonIdClick(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Visibility = Visibility.Visible;
            datePickerEarlierDate.Visibility = Visibility.Hidden;
            datePickerLaterDate.Visibility = Visibility.Hidden;
        }

        private void radioButtonDateOfPurchaseClick(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Visibility = Visibility.Hidden;
            datePickerEarlierDate.Visibility = Visibility.Visible;
            datePickerLaterDate.Visibility = Visibility.Visible;
        }

        private List<Item> GetItemByDate(DateTime? earlierDate, DateTime? laterDate)
        {
            IItemService itemService = new ItemService();
            List<Item> itemsList = new List<Item>();
            if(datePickerEarlierDate.SelectedDate != null && datePickerLaterDate.SelectedDate != null)
            {
                itemsList = itemService.GetEmittedItemsByDate(earlierDate, laterDate).ToList();
                return itemsList;
            }
            else if(datePickerEarlierDate.SelectedDate != null && datePickerLaterDate.SelectedDate == null)
            {
                itemsList = itemService.GetEmittedItemsByDate(earlierDate, null).ToList();
                return itemsList;
            }
            else if(datePickerEarlierDate.SelectedDate == null && datePickerLaterDate.SelectedDate != null)
            {
                itemsList = itemService.GetEmittedItemsByDate(null, laterDate).ToList();
                return itemsList;
            }
            else
            {
                itemsList = itemService.GetEmittedItemsByDate(null, null).ToList();
                return itemsList;
            }
        }
    }
}