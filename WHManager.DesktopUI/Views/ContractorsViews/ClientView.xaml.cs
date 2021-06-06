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
        IClientService clientService = new ClientService();

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
                textBoxIdName.Text = "";
                textBoxNip.Text = "";
                textBoxPhoneNumber.Text = "";
                gridClients.ItemsSource = LoadData();
            }
            catch(Exception x)
            {
                MessageBox.Show("Błąd wyświetlania: " + x);
            }
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Client> clients = SearchClients();
                Clients = new ObservableCollection<Client>(clients);
                gridClients.ItemsSource = Clients;
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd wyświetlania: " + x);
            }
        }

        private void DeleteMultipleClientClick(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Client> selectedClients = gridClients.SelectedItems.Cast<Client>().ToList();
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybranych klientów?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        foreach (Client client in selectedClients)
                        {
                            clientService.DeleteClient(client.Id);
                        }
                        gridClients.ItemsSource = LoadData();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd usuwania: " + x);
            }

        }

        private void DeleteAllClientClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wszystkich klientów?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        foreach (Client client in Clients)
                        {
                            clientService.DeleteClient(client.Id);
                        }
                        gridClients.ItemsSource = LoadData();
                    }
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
                ManageClientFormView manageClientFormView = new ManageClientFormView(this);
                manageClientFormView.ShowDialog();
                if (manageClientFormView.DialogResult.Value == true)
                {
                    gridClients.ItemsSource = LoadData();
                }
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
                ManageClientFormView manageClientFormView = new ManageClientFormView(this, client);
                manageClientFormView.ShowDialog();
                if (manageClientFormView.DialogResult.Value == true)
                {
                    gridClients.ItemsSource = LoadData();
                }
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

        private List<Client> SearchClients()
        {
            List<string> criteria = new List<string>();
            criteria.Add(textBoxIdName.Text.ToString());      // criteria[0] = Id/Name
            criteria.Add(textBoxNip.Text.ToString());         // criteria[1] = Nip
            criteria.Add(textBoxPhoneNumber.Text.ToString()); // criteria[2] = Phone Number
            List<Client> clients = clientService.SearchClients(criteria);
            return clients;
        }
    }
}
