using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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
using WHManager.DesktopUI.Views.FormViews;

namespace WHManager.DesktopUI.Views.ContractorsView
{
    /// <summary>
    /// Interaction logic for ManufacturerView.xaml
    /// </summary>
    public partial class ManufacturerView : UserControl
    {
        private ObservableCollection<Manufacturer> _manufacturers;

        public ObservableCollection<Manufacturer> Manufacturers
        {
            get { return _manufacturers; }
            set { _manufacturers = value; }
        }

        IManufacturerService manufacturerService = new ManufacturerService();

        public ManufacturerView()
        {
            InitializeComponent();
            gridManufacturers.ItemsSource = LoadData();
        }

        private IList<Manufacturer> GetAll()
        {
            IList<Manufacturer> manufacturers = manufacturerService.GetManufacturers().ToList();
            return manufacturers;
        }

        private ObservableCollection<Manufacturer> LoadData()
        {
            IList<Manufacturer> manufacturers = GetAll();
            Manufacturers = new ObservableCollection<Manufacturer>(manufacturers);
            return Manufacturers;
        }

        private void SearchClearClick(object sender, RoutedEventArgs e)
        {
            textBoxIdName.Text = null;
            textBoxNip.Text = null;
            gridManufacturers.ItemsSource = LoadData();

        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            IList<Manufacturer> manufacturers = manufacturerService.SearchManufacturers(SearchManufacturers());
            Manufacturers = new ObservableCollection<Manufacturer>(manufacturers);
            gridManufacturers.ItemsSource = Manufacturers;
        }

        private void AddManufacturerClick(object sender, RoutedEventArgs e)
        {
            ManageManufacturerFormView manageManufacturerFormView = new ManageManufacturerFormView(this);
            manageManufacturerFormView.ShowDialog();
            if(manageManufacturerFormView.DialogResult.Value == true)
            {
                gridManufacturers.ItemsSource = LoadData();
            }
        }

        private void UpdateManufacturerClick(object sender, RoutedEventArgs e)
        {
            Manufacturer manufacturer = gridManufacturers.SelectedItem as Manufacturer;
            ManageManufacturerFormView manageManufacturerFormView = new ManageManufacturerFormView(this, manufacturer);
            manageManufacturerFormView.ShowDialog();
            if (manageManufacturerFormView.DialogResult.Value == true)
            {
                gridManufacturers.ItemsSource = LoadData();
            }
        }

        private void DeleteManufacturerClick(object sender, RoutedEventArgs e)
        {
            Manufacturer manufacturer = gridManufacturers.SelectedItem as Manufacturer;
            manufacturerService.DeleteManufacturer(manufacturer.Id);
            gridManufacturers.ItemsSource = LoadData();
        }

        private void DeleteMultipleManufacturerClick(object sender, RoutedEventArgs e)
        {
            List<Manufacturer> manufacturers = gridManufacturers.SelectedItems.Cast<Manufacturer>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show("Usunięcie producenta spowoduje usunięcie wszystkich produktów przypisanych do niego. \nCzy na pewno chcesz usunąć wybranych producentów?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    foreach (Manufacturer manufacturer in manufacturers)
                    {
                        manufacturerService.DeleteManufacturer(manufacturer.Id);
                    }
                    gridManufacturers.ItemsSource = LoadData();
                }
            }

        }

        private void DeleteAllManufacturerClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Usunięcie producenta spowoduje usunięcie wszystkich produktów przypisanych do niego. \nCzy na pewno chcesz usunąć wszystkich producentów?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    foreach (Manufacturer manufacturer in Manufacturers)
                    {
                        manufacturerService.DeleteManufacturer(manufacturer.Id);
                    }
                    gridManufacturers.ItemsSource = LoadData();
                }
            }
        }


        private List<string> SearchManufacturers()
        {
            List<string> criteria = new List<string>();
            criteria.Add(textBoxIdName.Text.ToString());
            criteria.Add(textBoxNip.Text.ToString());
            return criteria;
        }
    }
}
