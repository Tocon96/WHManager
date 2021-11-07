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
        private ITaxService taxService = new TaxService();
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
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz ten typ podatku?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        ITaxService taxService = new TaxService();
                        Tax tax = gridTaxes.SelectedItem as Tax;
                        taxService.DeleteTax(tax.Id);
                    }
                }
            }
            catch(Exception x)
            {
                MessageBox.Show("Błąd usuwania: " + x);
            }
        }
        private void DeleteAllTaxClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wszystkie typy podatków?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    foreach (Tax tax in Taxes)
                    {
                        try
                        {
                            taxService.DeleteTax(tax.Id);
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show("" + x);
                        }
                    }
                    gridTaxes.ItemsSource = LoadData();
                }
            }
        }
        private void DeleteMultipleTaxClick(object sender, RoutedEventArgs e)
        {
            List<Tax> selectedTaxes = gridTaxes.SelectedItems.Cast<Tax>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz ten wybrane typy podatków?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    foreach (Tax tax in selectedTaxes)
                    {
                        try
                        {
                            taxService.DeleteTax(tax.Id);
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show("" + x);
                        }

                    }
                    gridTaxes.ItemsSource = LoadData();
                }
            }
        }
        private void UpdateTaxClick(object sender, RoutedEventArgs e)
        {
            Tax tax = gridTaxes.SelectedItem as Tax;
            ManageTaxFormView manageTaxFormView = new ManageTaxFormView(this, tax);
            manageTaxFormView.ShowDialog();
            if(manageTaxFormView.DialogResult.Value == true)
            {
                gridTaxes.ItemsSource = LoadData();
            }
        }
        private void AddTaxClick(object sender, RoutedEventArgs e)
        {
            ManageTaxFormView manageTaxFormView = new ManageTaxFormView(this);
            manageTaxFormView.ShowDialog();
            if (manageTaxFormView.DialogResult.Value == true)
            {
                gridTaxes.ItemsSource = LoadData();
            }
        }
        private void SearchClearClick(object sender, RoutedEventArgs e)
        {
            ClearFilters();
            gridTaxes.ItemsSource = LoadData();
        }
        private void SearchClick(object sender, RoutedEventArgs e)
        {
            List<Tax> taxList = SearchTaxes();
            Taxes = new ObservableCollection<Tax>(taxList);
            gridTaxes.ItemsSource = Taxes;
        }
        private List<Tax> SearchTaxes()
        {
            List<string> criteria = new List<string>();
            criteria.Add(textBoxIdName.Text.ToString());   // criteria[0] - Id/Name;
            if (int.TryParse(textBoxMinValue.Text, out int result))
            {
                criteria.Add(result.ToString());
            }
            else
            {
                if (textBoxMinValue.Text != "")
                {
                    MessageBox.Show("Wartość podatku nie może zawierać znaków tekstowych.");
                }
                criteria.Add("");
            }

            if (int.TryParse(textBoxMaxValue.Text, out int maxResult))
            {
                criteria.Add(result.ToString());
            }
            else
            {
                if (textBoxMaxValue.Text != "")
                {
                    MessageBox.Show("Wartość podatku nie może zawierać znaków tekstowych.");
                }
                criteria.Add("");
            }

            List<Tax> taxes = taxService.SearchTaxes(criteria).ToList();
            return taxes;
        }
        private ObservableCollection<Tax> LoadData()
        {
            IList<Tax> taxes = GetAll();
            Taxes = new ObservableCollection<Tax>(taxes.ToList());
            return Taxes;
        }
        private IList<Tax> GetAll()
        {
            ITaxService taxService = new TaxService();
            IList<Tax> taxes = taxService.GetTaxes();
            return taxes;
        }
        private void ClearFilters()
        {
            textBoxIdName.Text = null;
            textBoxMinValue.Text = null;
            textBoxMaxValue.Text = null;
        }
    }
}