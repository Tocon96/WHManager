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

        private bool AddManufacturer()
        {
            Manufacturer manufacturer = new Manufacturer
            {
                Name = textBoxName.Text,
            };

            if(manufacturer.Name.Length < 1)
            {
                return false;
            } 

            if (double.TryParse(textBoxNip.Text, out double result) == true || result == 0)
            {
                manufacturer.Nip = result;
                manufacturerService.CreateNewManufacturer(manufacturer);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool UpdateManufacturer()
        {
            Manufacturer manufacturer = new Manufacturer
            {
                Id = Manufacturer.Id,
                Name = textBoxName.Text,
            };
            if (manufacturer.Name.Length < 1)
            {
                return false;
            }

            if (double.TryParse(textBoxNip.Text, out double result) == true || result == 0)
            {
                manufacturer.Nip = result;
                manufacturerService.UpdateManufacturer(manufacturer);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void buttonConfirmClick(object sender, RoutedEventArgs e)
        {
            if (Manufacturer == null)
            {
                if(AddManufacturer() == true)
                {
                    DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Podaj poprawne wartości");
                }
            }
            else
            {
                if (UpdateManufacturer() == true)
                {
                    DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Podaj poprawne wartości");
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
