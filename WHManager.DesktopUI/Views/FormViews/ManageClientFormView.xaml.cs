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
    /// Interaction logic for ManageClientFormView.xaml
    /// </summary>
    public partial class ManageClientFormView : Window
    {
        private IClientService clientService = new ClientService();

        private Client _client;
        public Client Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public ClientView ClientGridView
        {
            get;
            set;
        }
        public ManageClientFormView(ClientView clientView)
        {
            InitializeComponent();
            ClientGridView = clientView;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }
        public ManageClientFormView(ClientView clientView, Client client)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Client = client;
            ClientGridView = clientView;
            textBoxName.Text = Client.Name;
            textBoxNip.Text = Client.Nip.ToString();
            textBoxPhoneNumber.Text = Client.PhoneNumber;
            textBlockManageClient.Text = "Edytuj klienta o ID: " + Client.Id;
        }

        private void buttonConfirmClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(textBoxNip.Text, out double result))
            {
                if (Client == null)
                {
                    try
                    {
                        AddClient();
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
                        UpdateClient();
                        DialogResult = true;
                        this.Close();
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show("Błąd aktualizacji: " + x);
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszę podać poprawny NIP");
            }
        }


        private void AddClient()
        {
            try
            {
                Client client = new Client
                {
                    Name = textBoxName.Text,
                    Nip = double.Parse(textBoxNip.Text),
                    PhoneNumber = textBoxPhoneNumber.Text
                };
                clientService.CreateNewClient(client);
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd dodawania: " + e);
            }
        }

        private void UpdateClient()
        {
            try
            {
                Client client = new Client
                {
                    Id = Client.Id,
                    Name = textBoxName.Text,
                    Nip = double.Parse(textBoxNip.Text),
                    PhoneNumber = textBoxPhoneNumber.Text
                };
                clientService.UpdateClient(client);
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
            ClientGridView.gridClients.Items.Refresh();
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
            if(textBoxNip.Text == "Nip")
            {
                textBoxNip.Clear();
            }
        }

        private void textBoxPhoneNumber_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(textBoxPhoneNumber.Text == "Numer telefonu")
            {
                textBoxPhoneNumber.Clear();
            }
        }
    }
}
