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

namespace WHManager.DesktopUI.Views.WarehouseViews
{
    /// <summary>
    /// Interaction logic for OrderItemsView.xaml
    /// </summary>
    public partial class OrderItemsView : Window
    {
        private Order Order { get; set; }
        public OrderItemsView(Order order)
        {
            InitializeComponent();
            Order = order;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            FillGrid();
        }

        private void FillGrid()
        {
            gridItems.ItemsSource = new ObservableCollection<Item>(Order.Items);
        }

        private void ClearSearchClick(object sender, RoutedEventArgs e)
        {
            idTextBox.Text = "";
            textBoxProduct.Text = "";
            FillGrid();
        }

        private void SearchItemClick(object sender, RoutedEventArgs e)
        {
            IList<string> criteria = CreateCriteriaList();
            IList<Item> items = BrowseItems(criteria);
            gridItems.ItemsSource = new ObservableCollection<Item>(items);
        }

        private IList<string> CreateCriteriaList()
        {
            IList<string> criteria = new List<string>();
            criteria.Add(idTextBox.Text);
            criteria.Add(textBoxProduct.Text);
            return criteria;
        }

        private IList<Item> BrowseItems(IList<string> criteria)
        {
            IList<Item> items = new List<Item>();
            foreach (Item item in Order.Items)
            {
                if (criteria[0] != "")
                {
                    if (item.Id == int.Parse(criteria[0]))
                    {
                        items.Add(item);
                    }
                }

                if (criteria[1] != "")
                {
                    if (item.Product.Name == criteria[1])
                    {
                        items.Add(item);
                    }
                }
            }
            return items;
        }
    }
}
