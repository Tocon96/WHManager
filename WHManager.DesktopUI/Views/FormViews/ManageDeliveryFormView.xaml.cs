﻿using System;
using System.Collections;
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
    /// Interaction logic for ManageDelivery.xaml
    /// </summary>
    public partial class ManageDeliveryFormView : Window
    {
        IList<DeliveryOrderTableContent> ElementsList { get; set; }

        IProductService productService = new ProductService();
        IProviderService providerService = new ProviderService();
        IDeliveryService deliveryService = new DeliveryService();

        private IList<Product> Products { get; set; }
        private IList<Provider> Providers { get; set; }

        private DeliveryView DeliveryView {get; set;}

        public ManageDeliveryFormView(DeliveryView deliveryView)
        {
            InitializeComponent();
            DeliveryView = deliveryView;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            SelectItems();
        }


        private void SelectItems()
        {
            ElementsList = new List<DeliveryOrderTableContent>();

            Products = productService.GetProducts();
            Providers = providerService.GetAllProviders();

            comboBoxDeliveriesProducts.ItemsSource = Products.ToList();
            comboBoxDeliveriesProviders.ItemsSource = Providers.ToList();

            if(Products != null)
            {
                comboBoxDeliveriesProducts.SelectedItem = Products[0];
            }
            if(Providers != null)
            {
                comboBoxDeliveriesProviders.SelectedItem = Providers[0];
            }
        }

        public ManageDeliveryFormView(DeliveryView deliveryView, Delivery delivery)
        {
            InitializeComponent();
        }

        private void buttonDeliveriesCancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        public void OnDialogClose()
        {
            DeliveryView.gridDeliveries.Items.Refresh();
        }

        private void buttonDeliveriesConfirm(object sender, RoutedEventArgs e)
        {
            if (!ElementsList.Any())
            {
                MessageBox.Show("Dodaj elementy do dostawy.");
            }
            else if (datepickerDeliveryDate.SelectedDate == null)
            {
                MessageBox.Show("Wybierz datę");
            }
            else
            {
                AddDelivery();
                DialogResult = true;
                this.Close();
            }
        }

        private void buttonAddItemsToDelivery(object sender, RoutedEventArgs e)
        {
            AddElementToTable();
            gridItems.ItemsSource = new ObservableCollection<DeliveryOrderTableContent>(ElementsList);
        }

        private bool AddElementToTable()
        {
            Product product = comboBoxDeliveriesProducts.SelectedItem as Product;
            if (ElementsList.Count == 0)
            {
                CreateNewTableContent(product);
                return true;
            }
            foreach (DeliveryOrderTableContent existingContent in ElementsList)
            {
                if (product.Id == existingContent.Id)
                {
                    existingContent.Count = double.Parse(textBoxDeliveryProductCount.Text);
                    return true;
                }
            }
            CreateNewTableContent(product);
            return true;
        }

        private void CreateNewTableContent(Product product)
        {
            if(double.TryParse(textBoxDeliveryProductCount.Text, out double result))
            {
                DeliveryOrderTableContent content = new DeliveryOrderTableContent(product.Id, product.Name, result);
                ElementsList.Add(content);
            }
            else
            {
                MessageBox.Show("Podaj poprawną ilość elementów");
            }
            
        }

        private void DeleteItemsClick(object sender, RoutedEventArgs e)
        {
            DeliveryOrderTableContent content = gridItems.SelectedItem as DeliveryOrderTableContent;
            ElementsList.Remove(content);
            gridItems.ItemsSource = new ObservableCollection<DeliveryOrderTableContent>(ElementsList);
        }

        private void AddDelivery()
        {
            Delivery delivery = new Delivery
            {
                DateOfArrival = (DateTime)datepickerDeliveryDate.SelectedDate,
                Provider = comboBoxDeliveriesProviders.SelectedItem as Provider
            };
            deliveryService.AddDelivery(delivery, ElementsList.ToList());
        }
    }
}
