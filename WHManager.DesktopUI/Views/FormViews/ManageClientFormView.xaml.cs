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
using WHManager.DesktopUI.WindowSetting;
using WHManager.DesktopUI.WindowSetting.Interfaces;

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
        private readonly IDisplaySetting displaySetting = new DisplaySetting();
        public ManageClientFormView()
        {
            InitializeComponent();
            displaySetting.CenterWindowOnScreen(this);
        }
        public ManageClientFormView(Client client)
        {
            InitializeComponent();
            displaySetting.CenterWindowOnScreen(this);
            Client = client;
            wrpPanelId.Visibility = Visibility.Visible;
            labelId.Content = Client.Id;
            textBoxName.Text = Client.Name;
            textBoxNip.Text = Client.Nip.ToString();
            textBoxPhoneNumber.Text = Client.PhoneNumber;
        }

        private void buttonConfirmClick(object sender, RoutedEventArgs e)
        {
            if(labelId.Visibility == Visibility.Hidden)
            {
                try
                {
                    AddClient();
                    this.Close();
                }
                catch(Exception x)
                {
                    MessageBox.Show("Błąd dodawania: " + x);
                }
            }
            else if(labelId.Visibility == Visibility.Visible)
            {
                try
                {
                    UpdateClient();
                    this.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Błąd aktualizacji: " + x);
                }
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
                    Id = (int)labelId.Content,
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
    }
}
