using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WHManager.BusinessLogic.Services.ReportsServices;
using WHManager.BusinessLogic.Services.ReportsServices.Interfaces;
using WHManager.DesktopUI.Views.ReportViews;

namespace WHManager.DesktopUI.Views.FormViews.ReportForms
{
    /// <summary>
    /// Interaction logic for ManageProductFormPhaseIView.xaml
    /// </summary>
    public partial class ManageProductFormPhaseIView : Window
    {

        private ProductReportView ReportView { get; set; }

        IProductService productService = new ProductService();
        IManufacturerService manufacturerService = new ManufacturerService();
        IProductTypeService typeService = new ProductTypeService();
        IProductReportsService reportService = new ProductReportsService();
        
        public ManageProductFormPhaseIView(ProductReportView reportView)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            CreateComboBoxData();
        }

        private void CreateComboBoxData()
        {
            ObservableCollection<string> data = new ObservableCollection<string>();
            data.Add("Produkt");
            data.Add("Typ");
            data.Add("Producent");
            comboBoxType.ItemsSource = data;
            comboBoxType.SelectedIndex = 0;

            ObservableCollection<string> dataDate = new ObservableCollection<string>();
            dataDate.Add("Dostawa");
            dataDate.Add("Realizacji zamówienia");
            comboBoxDateType.ItemsSource = dataDate;
            comboBoxDateType.SelectedIndex = 0;
        }

        private void comboBoxTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                IList<Product> products = productService.GetProducts();
                comboBoxElementType.ItemsSource = products;
                comboBoxElementType.SelectedIndex = 0;
                textBlockElementType.Text = "Produkty";
            }

            if (comboBoxType.SelectedIndex == 1)
            {
                IList<ProductType> types = typeService.GetProductTypes();
                comboBoxElementType.ItemsSource = types;
                comboBoxElementType.SelectedIndex = 0;
                textBlockElementType.Text = "Typy";
            }

            if (comboBoxType.SelectedIndex == 2)
            {
                IList<Manufacturer> manufacturers = manufacturerService.GetManufacturers();
                comboBoxElementType.ItemsSource = manufacturers;
                comboBoxElementType.SelectedIndex = 0;
                textBlockElementType.Text = "Producenci";
            }
        }

        private void comboBoxDateTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxDateType.SelectedIndex == 0)
            {
                textBlockDateFrom.Text = "Od: (Data dostawy)";
                textBlockDateTo.Text = "Do: (Data dostawy)";
            }

            if(comboBoxDateType.SelectedIndex == 1)
            {
                textBlockDateFrom.Text = "Od: (Data realizacji zamówienia)";
                textBlockDateTo.Text = "Do: (Data realizacji zamówienia)";
            }
        }


        private void buttonConfirmClick(object sender, RoutedEventArgs e)
        {
            ProductReports report = new ProductReports();
            if(textBoxName.Text == "")
            {
                MessageBox.Show("Proszę podać nazwę.");
            }
            else
            {
                report.Name = textBoxName.Text;
                if(comboBoxDateType.SelectedIndex == 0)
                {
                    if (datePickerDateFrom.SelectedDate.HasValue)
                    {
                        report.DateDeliveredFrom = datePickerDateFrom.SelectedDate.Value.Date;
                    }
                    else
                    {
                        report.DateDeliveredFrom = null;
                    }

                    if (datePickerDateTo.SelectedDate.HasValue)
                    {
                        report.DateDeliveredTo = datePickerDateTo.SelectedDate.Value.Date;
                    }
                    else
                    {
                        report.DateDeliveredTo = null;
                    }
                }
                else
                {
                    if (datePickerDateFrom.SelectedDate.HasValue)
                    {
                        report.DateOrderedFrom = datePickerDateFrom.SelectedDate.Value.Date;
                    }
                    else
                    {
                        report.DateOrderedFrom = null;
                    }

                    if (datePickerDateTo.SelectedDate.HasValue)
                    {
                        report.DateOrderedTo = datePickerDateTo.SelectedDate.Value.Date;
                    }
                    else
                    {
                        report.DateOrderedTo = null;
                    }
                }

                report.ProductId = null;
                report.ManufacturerId = null;
                report.TypeId = null;
                Type type = comboBoxElementType.SelectedItem.GetType();
                if (type == typeof(Product))
                {
                    Product product = comboBoxElementType.SelectedItem as Product;
                    report.ProductId = product.Id;
                }

                if (type == typeof(Manufacturer))
                {
                    Manufacturer manufacturer = comboBoxElementType.SelectedItem as Manufacturer;
                    report.ManufacturerId = manufacturer.Id;
                }

                if (type == typeof(ProductType))
                {
                    ProductType productType = comboBoxElementType.SelectedItem as ProductType;
                    report.TypeId = productType.Id;
                }

                reportService.CreateReport(report);
                DialogResult = true;
                this.Close();
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        public void OnDialogClose()
        {
            ReportView.gridReports.Items.Refresh();
        }
    }
}
