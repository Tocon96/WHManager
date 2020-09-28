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
    /// Interaction logic for ClientView.xaml
    /// </summary>
    public partial class ClientView : UserControl
    {
        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set { _clients = value; }
        }

        public ClientView()
        {
            InitializeComponent();
            gridClients.ItemsSource = LoadData();
        }
        private IList<Client> GetAll()
        {
            try
            {
                IClientService clientService = new ClientService();
                IList<Client> clients = clientService.GetAllClients().ToList();
                return clients;
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd wyświetlania: " + e);
                return null;
            }
            
        }
        private ObservableCollection<Client> LoadData()
        {
            try
            {
                IList<Client> clients = GetAll();
                Clients = new ObservableCollection<Client>(clients);
                return Clients;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyświetlania: " + e);
                return null;
            }
        }

        private void SearchClearClick(object sender, RoutedEventArgs e)
        {
            try
            {
                textSearchClient.Text = "";
                gridClients.ItemsSource = LoadData();
            }
            catch(Exception x)
            {
                MessageBox.Show("Błąd wyświetlania: " + x);
            }
        }

        private void SearchClientClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if(IdRadioButton.IsChecked == true)
                {
                    List<Client> clients = GetClientById(int.Parse(textSearchClient.Text)).ToList();
                    Clients = new ObservableCollection<Client>(clients);
                    gridClients.ItemsSource = Clients;
                }
                else if(NameRadioButton.IsChecked == true)
                {
                    List<Client> clients = GetClientByName(textSearchClient.Text).ToList();
                    Clients = new ObservableCollection<Client>(clients);
                    gridClients.ItemsSource = Clients;
                }
                else if(NipRadioButton.IsChecked == true)
                {
                    List<Client> clients = GetClientByNip(double.Parse(textSearchClient.Text)).ToList();
                    Clients = new ObservableCollection<Client>(clients);
                    gridClients.ItemsSource = Clients;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd wyświetlania: " + x);
            }
        }

        private void AddClientClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ManageClientFormView manageClientFormView = new ManageClientFormView();
                manageClientFormView.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd wyświetlania: " + x);
            }
        }

        private void UpdateClientClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = gridClients.SelectedItem as Client;
                ManageClientFormView manageClientFormView = new ManageClientFormView(client);
                manageClientFormView.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd aktualizacji: " + x);
            }
        }

        private void DeleteClientClick(object sender, RoutedEventArgs e)
        {
            try
            {
                IClientService clientService = new ClientService();
                Client client = gridClients.SelectedItem as Client;
                clientService.DeleteClient(client.Id);
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd usuwania: " + x);
            }
        }

        private IList<Client> GetClientById(int id)
        {
            try
            {
                IClientService clientService = new ClientService();
                IList<Client> clients = clientService.GetClient(id);
                return clients;
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd usuwania: " + x);
                return null;
            }
        }
        private IList<Client> GetClientByName(string name)
        {
            try
            {
                IClientService clientService = new ClientService();
                IList<Client> clients = clientService.GetClient(null, name);
                return clients;
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd usuwania: " + x);
                return null;
            }
        }
        private IList<Client> GetClientByNip(double nip)
        {
            try
            {
                IClientService clientService = new ClientService();
                IList<Client> clients = clientService.GetClient(null, null, nip);
                return clients;
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd usuwania: " + x);
                return null;
            }
        }
    }
}
