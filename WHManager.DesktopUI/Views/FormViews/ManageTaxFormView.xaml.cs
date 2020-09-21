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

namespace WHManager.DesktopUI.Views.FormViews
{
    /// <summary>
    /// Interaction logic for AddTaxFormView.xaml
    /// </summary>
    public partial class ManageTaxFormView : Window
    {
        public ManageTaxFormView()
        {
            InitializeComponent();
        }

        public ManageTaxFormView(Tax tax)
        {
            InitializeComponent();
            Id.Visibility = Visibility.Visible;
            Id.Content = tax.Id;
            textBoxTaxName.Text = tax.Name;
            textBoxTaxValue.Text = tax.Value.ToString();
        }

        private void AddTaxClick(object sender, RoutedEventArgs e)
        {
            if(Id.Visibility == Visibility.Hidden)
            {
                try
                {
                    AddTax();
                    this.Close();
                }
                catch(Exception x)
                {
                    throw x;
                }
                    
            }
            else
            {
                try
                {
                    UpdateTax();
                    this.Close();
                }
                catch(Exception x)
                {
                    throw x;
                }    
            }
        }

        private void AddTax()
        {
            try
            {
                ITaxService taxService = new TaxService();
                Tax tax = new Tax
                {
                    Name = textBoxTaxName.Text,
                    Value = int.Parse(textBoxTaxValue.Text)
                };
                taxService.CreateNewTax(tax);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private void UpdateTax()
        {
            try
            {
                ITaxService taxService = new TaxService();
                Tax tax = new Tax
                {
                    Id = (int)Id.Content,
                    Name = textBoxTaxName.Text,
                    Value = int.Parse(textBoxTaxValue.Text)
                };
                taxService.UpdateTax(tax);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
