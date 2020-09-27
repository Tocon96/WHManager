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


        public ManufacturerView()
        {
            InitializeComponent();
            gridManufacturers.ItemsSource = LoadData();
        }

        private IList<Manufacturer> GetAll()
        {
            try
            {
                IManufacturerService manufacturerService = new ManufacturerService();
                IList<Manufacturer> manufacturers = manufacturerService.GetManufacturers().ToList();
                return manufacturers;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private ObservableCollection<Manufacturer> LoadData()
        {
            try
            {
                IList<Manufacturer> manufacturers = GetAll();
                Manufacturers = new ObservableCollection<Manufacturer>(manufacturers);
                return Manufacturers;
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        private IList<Manufacturer> GetManufacturersByName(string name)
        {
            try
            {
                IManufacturerService manufacturerService = new ManufacturerService();
                IList<Manufacturer> manufacturers = manufacturerService.GetManufacturersByName(name).ToList();
                return manufacturers;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private IList<Manufacturer> GetManufacturerByNip(int nip)
        {
            try
            {
                IManufacturerService manufacturerService = new ManufacturerService();
                IList<Manufacturer> manufacturers = new List<Manufacturer>();
                Manufacturer manufacturer = manufacturerService.GetManufacturerByNip(nip);
                manufacturers.Add(manufacturer);
                return manufacturers;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private IList<Manufacturer> GetManufacturerById(int id)
        {
            try
            {
                IManufacturerService manufacturerService = new ManufacturerService();
                IList<Manufacturer> manufacturers = new List<Manufacturer>();
                Manufacturer manufacturer = manufacturerService.GetManufacturer(id);
                manufacturers.Add(manufacturer);
                return manufacturers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SearchClearClick(object sender, RoutedEventArgs e)
        {
            try
            {
                textSearchManufacturer.Text = null;
                gridManufacturers.ItemsSource = Manufacturers;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void SearchManufacturerClick(object sender, RoutedEventArgs e)
        {
            if (IdRadioButton.IsChecked == true)
            {
                try
                {
                    IList<Manufacturer> manufacturers = GetManufacturerById(int.Parse(textSearchManufacturer.Text));
                    Manufacturers = new ObservableCollection<Manufacturer>(manufacturers);
                    gridManufacturers.ItemsSource = Manufacturers;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if(NameRadioButton.IsChecked == true)
            {
                try
                {
                    IList<Manufacturer> manufacturers = GetManufacturersByName(textSearchManufacturer.Text);
                    Manufacturers = new ObservableCollection<Manufacturer>(manufacturers);
                    gridManufacturers.ItemsSource = Manufacturers;
                }
                catch( Exception)
                {
                    throw;
                }
            }
            else if(NipRadioButton.IsChecked == true)
            {
                IList<Manufacturer> manufacturers = GetManufacturerByNip(int.Parse(textSearchManufacturer.Text));
                Manufacturers = new ObservableCollection<Manufacturer>(manufacturers);
                gridManufacturers.ItemsSource = Manufacturers;
            }
        }

        private void AddManufacturerClick(object sender, RoutedEventArgs e)
        {
            ManageManufacturerFormView manageManufacturerFormView = new ManageManufacturerFormView();
            manageManufacturerFormView.Show();
        }

        private void UpdateManufacturerClick(object sender, RoutedEventArgs e)
        {
            Manufacturer manufacturer = gridManufacturers.SelectedItem as Manufacturer;
            ManageManufacturerFormView manageManufacturerFormView = new ManageManufacturerFormView(manufacturer);
            manageManufacturerFormView.Show();
        }

        private void DeleteManufacturerClick(object sender, RoutedEventArgs e)
        {
            IManufacturerService manufacturerService = new ManufacturerService();
            Manufacturer manufacturer = gridManufacturers.SelectedItem as Manufacturer;
            manufacturerService.DeleteManufacturer(manufacturer.Id);
        }
    }
}
