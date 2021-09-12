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
using WHManager.DesktopUI.Views.ContractorsView;

namespace WHManager.DesktopUI.Views.FormViews
{
    /// <summary>
    /// Interaction logic for ManageManufacturerFormView.xaml
    /// </summary>
    public partial class ManageManufacturerFormView : Window
    {
        IManufacturerService manufacturerService = new ManufacturerService();

        private ManufacturerView ManufacturerGridView
        {
            get;
            set;
        }

        private Manufacturer Manufacturer
        {
            get;
            set;
        }

        public ManageManufacturerFormView(ManufacturerView manufacturerView)
        {
            InitializeComponent();
            ManufacturerGridView = manufacturerView;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }

        public ManageManufacturerFormView(ManufacturerView manufacturerView, Manufacturer manufacturer)
        {
            InitializeComponent();
            ManufacturerGridView = manufacturerView;
            Manufacturer = manufacturer;
            textBoxName.Text = manufacturer.Name;
            textBoxNip.Text = manufacturer.Nip.ToString();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            textBlockManageManufacturer.Text = "Edytuj Producenta o ID: " + manufacturer.Id;

        }

        private void AddManufacturer()
        {
            try
            {
                Manufacturer manufacturer = new Manufacturer
                {
                    Name = textBoxName.Text,
                    Nip = double.Parse(textBoxNip.Text)
                };
                manufacturerService.CreateNewManufacturer(manufacturer);
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd dodawania: " + e);
            }
        }

        private void UpdateManufacturer()
        {
            try
            {
                Manufacturer manufacturer = new Manufacturer
                {
                    Id = Manufacturer.Id,
                    Name = textBoxName.Text,
                    Nip = double.Parse(textBoxNip.Text)
                };
                manufacturerService.UpdateManufacturer(manufacturer);
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd aktualizacji: " + e);
            }
        }

        private void buttonConfirmClick(object sender, RoutedEventArgs e)
        {
            if(Manufacturer == null)
            {
                try
                {
                    AddManufacturer();
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
                    UpdateManufacturer();
                    DialogResult = true;
                    this.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Błąd aktualizacji: " + x);
                }
            }
        }
        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        public void OnDialogClose()
        {
            ManufacturerGridView.gridManufacturers.Items.Refresh();
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

    }
}
