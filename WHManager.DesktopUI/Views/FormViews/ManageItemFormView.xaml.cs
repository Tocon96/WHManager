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
using System.Windows.Shapes;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;

namespace WHManager.DesktopUI.Views.FormViews
{
    /// <summary>
    /// Interaction logic for ManageItemFormView.xaml
    /// </summary>
    public partial class ManageItemFormView : Window
    {
        IItemService itemService = new ItemService();
        private Product _product;
        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }
        private Item _item;
        public Item Item
        {
            get { return _item; }
            set { _item = value; }
        }
        public ManageItemFormView(Product product)
        {
            InitializeComponent();
            Product = product;
        }
        public ManageItemFormView(Product product, Item item)
        {
            InitializeComponent();
            Product = product;
            Item = item;
            UpdateWindow();
        }

        private void buttonAddItems(object sender, RoutedEventArgs e)
        {
            if(labelId.Visibility == Visibility.Hidden)
            {
                try
                {
                    AddItems();
                    this.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Błąd dodawania: " + x);
                }

            }
            else
            {
                try
                {
                    UpdateItems();
                    this.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Błąd aktualizacji: " + x);
                }
            }
        }

        private void AddItems()
        {
            try
            {
                int a = int.Parse(textboxNumberOfItems.Text);
                List<Item> items = new List<Item>();
                for (int i = 1; i <= a; i++)
                {
                    Item item = new Item
                    {
                        DateOfAdmission = (DateTime)datepickerDateOfAdmission.SelectedDate,
                        IsInStock = true,
                        Product = Product
                    };
                    items.Add(item);
                }
                itemService.CreateNewItems(items);
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd dodawania: " + e);
            }
            
        }

        private void UpdateItems()
        {
            try
            {
                Item updatedItem = new Item
                {
                    Id = Item.Id,
                    DateOfAdmission = (DateTime)datepickerDateOfAdmission.SelectedDate,
                    DateOfEmission = datepickerDateOfEmission.SelectedDate,
                    IsInStock = (bool)checkboxAvalaibility.IsChecked,
                    Product = Item.Product
                };
                itemService.UpdateItem(updatedItem);
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd aktualizacji: " + e);
            }
        }
        private void UpdateWindow()
        {
            try
            {
                labelId.Visibility = Visibility.Visible;
                datepickerDateOfEmission.Visibility = Visibility.Visible;
                textBlockDateOfEmission.Visibility = Visibility.Visible;
                checkboxAvalaibility.Visibility = Visibility.Visible;

                datepickerDateOfAdmission.SelectedDate = Item.DateOfAdmission;
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd wyświetlania: " + e);
            }
        }
    }
}
