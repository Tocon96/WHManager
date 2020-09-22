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

namespace WHManager.DesktopUI.Views.FormViews
{
    /// <summary>
    /// Interaction logic for ManageManufacturerFormView.xaml
    /// </summary>
    public partial class ManageManufacturerFormView : Window
    {
        public ManageManufacturerFormView()
        {
            InitializeComponent();
        }

        public ManageManufacturerFormView(Manufacturer manufacturer)
        {
            InitializeComponent();
            Id.Visibility = Visibility.Visible;
            Id.Content = manufacturer.Id;
            textManufacturerName.Text = manufacturer.Name;
            textManufacturerNip.Text = manufacturer.Nip.ToString();
        }

        private void AddManufacturer()
        {
            try
            {
                IManufacturerService manufacturerService = new ManufacturerService();
                Manufacturer manufacturer = new Manufacturer
                {
                    Name = textManufacturerName.Text,
                    Nip = double.Parse(textManufacturerNip.Text)
                };
                manufacturerService.CreateNewManufacturer(manufacturer);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void UpdateManufacturer()
        {
            try
            {
                IManufacturerService manufacturerService = new ManufacturerService();
                Manufacturer manufacturer = new Manufacturer
                {
                    Id = (int)Id.Content,
                    Name = textManufacturerName.Text,
                    Nip = double.Parse(textManufacturerNip.Text)
                };
                manufacturerService.UpdateManufacturer(manufacturer);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private void AddManufacturerClick(object sender, RoutedEventArgs e)
        {
            if(Id.Visibility == Visibility.Hidden)
            {
                try
                {
                    AddManufacturer();
                    this.Close();
                }
                catch(Exception x)
                {
                    throw x;
                }
            }
            else if(Id.Visibility == Visibility.Visible)
            {
                try
                {
                    UpdateManufacturer();
                    this.Close();
                }
                catch(Exception x)
                {
                    throw x;
                }
            }
        }
    }
}
