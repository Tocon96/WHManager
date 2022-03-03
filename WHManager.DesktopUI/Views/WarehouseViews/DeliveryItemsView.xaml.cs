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

namespace WHManager.DesktopUI.Views.WarehouseViews
{
    /// <summary>
    /// Interaction logic for DeliveryItemsView.xaml
    /// </summary>
    public partial class DeliveryItemsView : Window
    {
        private Delivery Delivery { get; set; }
        private IList<string> AvailabilityOptions { get; set; }
        public DeliveryItemsView(Delivery delivery)
        {
            InitializeComponent();
            Delivery = delivery;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            FillGrid();
            FillComboBox();
        }

        private void FillGrid()
        {
            gridItems.ItemsSource = new ObservableCollection<Item>(Delivery.Items);
        }


        private void ClearSearchClick(object sender, RoutedEventArgs e)
        {
            idTextBox.Text = "";
            textBoxProduct.Text = "";
            comboBoxAvailability.SelectedItem = AvailabilityOptions[0];
            FillGrid();
        }

        private void SearchItemClick(object sender, RoutedEventArgs e)
        {
            IList<string> criteria = CreateCriteriaList();
            IList<Item> items = BrowseItems(criteria);
            gridItems.ItemsSource = new ObservableCollection<Item>(items);
        }

        private void FillComboBox()
        {
            IList<string> availabilityOptions = new List<string>();
            availabilityOptions.Add("Wszystkie");
            availabilityOptions.Add("Dostępne");
            availabilityOptions.Add("Niedostępne");
            AvailabilityOptions = availabilityOptions;
            comboBoxAvailability.ItemsSource = AvailabilityOptions;
            comboBoxAvailability.SelectedItem = AvailabilityOptions[0];
        }

        private IList<string> CreateCriteriaList()
        {
            IList<string> criteria = new List<string>();
            criteria.Add(idTextBox.Text);
            criteria.Add(textBoxProduct.Text);
            if(comboBoxAvailability.SelectedIndex == 0)
            {
                criteria.Add("0");
            }
            if(comboBoxAvailability.SelectedIndex == 1)
            {
                criteria.Add("1");
            }
            if(comboBoxAvailability.SelectedIndex == 2)
            {
                criteria.Add("2");
            }
            return criteria;
        }

        private IList<Item> BrowseItems(IList<string>criteria)
        {
            IList<Item> items = new List<Item>();
            foreach(Item item in Delivery.Items)
            {
                if(criteria[0] != "")
                {
                    if(item.Id == int.Parse(criteria[0]))
                    {
                        items.Add(item);
                    }
                }

                if(criteria[1] != "")
                {
                    if(item.Product.Name == criteria[1])
                    {
                        items.Add(item);
                    }
                }

                if(criteria[2] == "1")
                {
                    if (item.IsInStock)
                    {
                        items.Add(item);
                    }
                }else if(criteria[2] == "2")
                {
                    if (!item.IsInStock)
                    {
                        items.Add(item);
                    }
                }
                else if(criteria[2] == "0")
                {
                    items.Add(item);
                }
            }
            return items;
        }
    }
}
