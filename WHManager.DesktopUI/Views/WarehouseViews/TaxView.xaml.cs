using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace WHManager.DesktopUI.Views.WarehouseViews
{
    /// <summary>
    /// Interaction logic for TaxView.xaml
    /// </summary>
    public partial class TaxView : UserControl
    {

        private ObservableCollection<Tax> _taxes;

        public ObservableCollection<Tax> Taxes
        {
            get { return _taxes; }
            set { _taxes = value; }
        }


        public TaxView()
        {
            InitializeComponent();
            gridTaxes.ItemsSource = LoadData();
        }

        private void DeleteTaxClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ITaxService taxService = new TaxService();
                Tax tax = gridTaxes.SelectedItem as Tax;
                taxService.DeleteTax(tax.Id);
            }
            catch(Exception x)
            {
                throw x;
            }
        }

        private void UpdateTaxClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Tax tax = gridTaxes.SelectedItem as Tax;
                ManageTaxFormView manageTaxFormView = new ManageTaxFormView(tax);
                manageTaxFormView.Show();
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private void AddTaxClick(object sender, RoutedEventArgs e)
        {
            ManageTaxFormView manageTaxFormView = new ManageTaxFormView();
            manageTaxFormView.Show();
        }

        private void SearchClearClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchTextBox.Text = null;
                gridTaxes.ItemsSource = LoadData();
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            if (IdRadioButton.IsChecked == true)
            {
                try
                {
                    List<Tax> taxes = GetTaxesById(int.Parse(SearchTextBox.Text)).ToList();
                    Taxes = new ObservableCollection<Tax>(taxes);
                    gridTaxes.ItemsSource = Taxes;
                }
                catch (Exception x)
                {
                    throw x;
                }
            }
            else if(NameRadioButton.IsChecked == true)
            {
                try
                {
                    List<Tax> taxes = GetTaxesByName(SearchTextBox.Text).ToList();
                    Taxes = new ObservableCollection<Tax>(taxes);
                    gridTaxes.ItemsSource = Taxes;
                }
                catch (Exception x)
                {
                    throw x;
                }
            }
            else if(ValueRadioButton.IsChecked == true)
            {
                try
                {
                    List<Tax> taxes = GetTaxesByValue(int.Parse(SearchTextBox.Text)).ToList();
                    Taxes = new ObservableCollection<Tax>(taxes);
                    gridTaxes.ItemsSource = Taxes;
                }
                catch( Exception x)
                {
                    throw x;
                }
            }
        }

        private ObservableCollection<Tax> LoadData()
        {
            try
            {
                IList<Tax> taxes = GetAll();
                Taxes = new ObservableCollection<Tax>(taxes.ToList());
                return Taxes;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private IList<Tax> GetAll()
        {
            try
            {
                ITaxService taxService = new TaxService();
                IList<Tax> taxes = taxService.GetTaxes();
                return taxes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private IList<Tax> GetTaxesByName(string name)
        {
            try
            {
                ITaxService taxService = new TaxService();
                IList<Tax> taxes = taxService.GetTaxesByName(name).ToList();
                return taxes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private IList<Tax> GetTaxesByValue(int value)
        {
            try
            {
                ITaxService taxService = new TaxService();
                IList<Tax> taxes = taxService.GetTaxesByValue(value).ToList();
                return taxes;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private IList<Tax> GetTaxesById(int id)
        {
            try
            {
                ITaxService taxService = new TaxService();
                IList<Tax> taxes = new List<Tax>();
                Tax tax = taxService.GetTax(id);
                taxes.Add(tax);
                return taxes;

            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
