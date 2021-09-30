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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DesktopUI.Views.FormViews;

namespace WHManager.DesktopUI.Views.ContractorsViews
{
    /// <summary>
    /// Interaction logic for ProviderView.xaml
    /// </summary>
    public partial class ProviderView : UserControl
    {
        private ObservableCollection<Provider> Providers { get; set; }
        IProviderService providerService = new ProviderService();
        public ProviderView()
        {
            InitializeComponent();
            gridProviders.ItemsSource = LoadData();
        }
        private void UpdateProviderClick(object sender, RoutedEventArgs e)
        {
            Provider provider = gridProviders.SelectedItem as Provider;
            ManageProviderFormView manageProviderFormView = new ManageProviderFormView(this, provider);
            manageProviderFormView.ShowDialog();

            if (manageProviderFormView.DialogResult.Value == true)
            {
                gridProviders.ItemsSource = LoadData();
            }
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            IList<Provider> providers = SearchProviders();
            Providers = new ObservableCollection<Provider>(providers);
            gridProviders.ItemsSource = Providers;
            ClearFilters();
        }

        private void SearchClearClick(object sender, RoutedEventArgs e)
        {
            ClearFilters();
        }

        private void DeleteProviderClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybranego dostawcę?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    DeleteProvider();
                }
            }
            
        }

        private void DeleteMultipleProvidersClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybranych dostawców?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    DeleteProviders();
                }
            }
        }

        private void AddProviderClick(object sender, RoutedEventArgs e)
        {
            ManageProviderFormView manageProviderFormView = new ManageProviderFormView(this);
            manageProviderFormView.ShowDialog();

            if(manageProviderFormView.DialogResult.Value == true)
            {
                gridProviders.ItemsSource = LoadData();
            }
        }

        private ObservableCollection<Provider> LoadData()
        {
            IList<Provider> providerList = GetProviders();
            Providers = new ObservableCollection<Provider>(providerList);
            return Providers;
        }

        private IList<Provider> GetProviders()
        {
            IList<Provider> providers = providerService.GetAllProviders();
            return providers;
        }

        private IList<Provider> SearchProviders()
        {
            IList<string> criteria = new List<string>();
            criteria.Add(textBoxIdName.Text.ToString());      // criteria[0] = Id/Name
            criteria.Add(textBoxNip.Text.ToString());         // criteria[1] = Nip
            criteria.Add(textBoxPhoneNumber.Text.ToString()); // criteria[2] = Phone Number
            IList<Provider> providers = providerService.SearchProviders(criteria.ToList());
            return providers;
        }

        private void DeleteProvider()
        {
            Provider provider = gridProviders.SelectedItem as Provider;
            providerService.DeleteProvider(provider.Id);
            gridProviders.ItemsSource = LoadData();
        }

        private void DeleteProviders()
        {
            List<Provider> selectedProviders = gridProviders.SelectedItems.Cast<Provider>().ToList();
            foreach (Provider provider in selectedProviders)
            {
                providerService.DeleteProvider(provider.Id);
            }
            gridProviders.ItemsSource = LoadData();
        }

        private void ClearFilters()
        {
            textBoxIdName.Text = "";
            textBoxNip.Text = "";
            textBoxPhoneNumber.Text = "";
        }
    }
}
