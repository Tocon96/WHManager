using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WHManager.DesktopUI.Views.FormViews.SearchFormViews;

namespace WHManager.DesktopUI.Views.FormViews
{
    /// <summary>
    /// Interaction logic for AdvancedSearchProductFormView.xaml
    /// </summary>
    public partial class AdvancedSearchProductFormView : Window
    {
        private ObservableCollection<string> _categories; 

        public ObservableCollection<string> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }


        public AdvancedSearchProductFormView()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void changeSearchType(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if((string)comboboxSearchContent.SelectedItem == "Producenci")
            {
                contentSearch.Content = new SearchProductByManufacturerFormView();
            }
            else if((string)comboboxSearchContent.SelectedItem == "Typy produktów")
            {
                contentSearch.Content = new SearchProductsByTypeFormView();
            }
            else if((string)comboboxSearchContent.SelectedItem == "Typ podatku")
            {
                contentSearch.Content = new SearchProductsByTaxFormView();
            }
            else if((string)comboboxSearchContent.SelectedItem == "Ceny")
            {
                contentSearch.Content = new SearchProductsByPricesFormView();
            }
        }

        private void FillComboBox()
        {
            IList<string> categories = new List<string>();
            categories.Add("Producenci");
            categories.Add("Typy produktów");
            categories.Add("Ceny");
            categories.Add("Typ podatku");

            Categories = new ObservableCollection<string>(categories);
            comboboxSearchContent.ItemsSource = Categories;
            comboboxSearchContent.SelectedItem = "Producenci";
            contentSearch.Content = new SearchProductByManufacturerFormView();
        }
    }
}