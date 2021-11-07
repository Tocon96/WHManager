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
using WHManager.DesktopUI.Views.WarehouseViews;

namespace WHManager.DesktopUI.Views.FormViews
{
    /// <summary>
    /// Interaction logic for AddTaxFormView.xaml
    /// </summary>
    public partial class ManageTaxFormView : Window
    {
        private Tax Tax
        {
            get;
            set;
        }

        private TaxView TaxGridView
        {
            get; 
            set;
        } 
        public ManageTaxFormView(TaxView taxView)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            TaxGridView = taxView;
        }

        public ManageTaxFormView(TaxView taxView, Tax tax)
        {
            InitializeComponent();
            Tax = tax;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            TaxGridView = taxView;
            textBoxTaxName.Text = tax.Name;
            textBoxTaxValue.Text = tax.Value.ToString();
            textBlockManageTax.Text = "Edytuj typ podatku o ID: " + Tax.Id;
        }

        private void AddTaxClick(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textBoxTaxValue.Text, out int result))
            {
                if (Tax == null)
                {
                    AddTax();
                    DialogResult = true;
                    this.Close();

                }
                else
                {
                    UpdateTax();
                    DialogResult = true;
                    this.Close();
                }
            }
            else 
            {
                MessageBox.Show("Proszę podać poprawną wartość podatku.");
            }
        }

        private void AddTax()
        {
            ITaxService taxService = new TaxService();
            Tax tax = new Tax
            {
                Name = textBoxTaxName.Text,
                Value = int.Parse(textBoxTaxValue.Text)
            };
            taxService.CreateNewTax(tax);
        }

        private void UpdateTax()
        {
            ITaxService taxService = new TaxService();
            Tax tax = new Tax
            {
                Id = Tax.Id,
                Name = textBoxTaxName.Text,
                Value = int.Parse(textBoxTaxValue.Text)
            };
            taxService.UpdateTax(tax);
        }
        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
        public void OnDialogClose()
        {
            TaxGridView.gridTaxes.Items.Refresh();
        }

        private void textBoxTaxName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBoxTaxName.Clear();
        }

        private void textBoxTaxValue_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBoxTaxValue.Clear();
        }
    }
}
