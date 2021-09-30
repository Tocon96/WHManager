using System;
using System.Collections.Generic;
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
using WHManager.DesktopUI.Views.ContractorsViews;

namespace WHManager.DesktopUI.Views.FormViews
{
    /// <summary>
    /// Interaction logic for ManageProviderFormView.xaml
    /// </summary>
    public partial class ManageProviderFormView : Window
    {
        private IProviderService providerService = new ProviderService();
        private ProviderView ProviderView { get; set; }
        private Provider Provider { get; set; }
        public ManageProviderFormView(ProviderView providerView)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            ProviderView = providerView;
        }

        public ManageProviderFormView(ProviderView providerView, Provider provider)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            ProviderView = providerView;
            Provider = provider;
            textBoxName.Text = Provider.Name;
            textBoxNip.Text = Provider.Nip.ToString();
            textBoxPhoneNumber.Text = Provider.PhoneNumber;
            textBlockManageProvider.Text = "Edytuj dostawcę o ID: " + Provider.Id;
        }

        private void buttonConfirmClick(object sender, RoutedEventArgs e)
        {
            if (Provider == null)
            {
                try
                {
                    AddProvider();
                    DialogResult = true;
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
                    UpdateProvider();
                    DialogResult = true;
                    this.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Błąd aktualizacji: " + x);
                }
            }
        }

        private void AddProvider()
        {
            try
            {
                Provider provider = new Provider
                {
                    Name = textBoxName.Text,
                    Nip = double.Parse(textBoxNip.Text),
                    PhoneNumber = textBoxPhoneNumber.Text
                };
                providerService.CreateProvider(provider);
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd dodawania: " + e);
            }
        }

        private void UpdateProvider()
        {
            try
            {
                Provider provider = new Provider
                {
                    Id = Provider.Id,
                    Name = textBoxName.Text,
                    Nip = double.Parse(textBoxNip.Text),
                    PhoneNumber = textBoxPhoneNumber.Text
                };
                providerService.CreateProvider(provider);
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd dodawania: " + e);
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        public void OnDialogClose()
        {
            ProviderView.gridProviders.Items.Refresh();
        }

        private void textBoxName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (textBoxName.Text == "Nazwa")
            {
                textBoxName.Clear();
            }
        }

        private void textBoxNip_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (textBoxNip.Text == "Nip")
            {
                textBoxNip.Clear();
            }
        }

        private void textBoxPhoneNumber_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (textBoxPhoneNumber.Text == "Numer telefonu")
            {
                textBoxPhoneNumber.Clear();
            }
        }
    }
}
