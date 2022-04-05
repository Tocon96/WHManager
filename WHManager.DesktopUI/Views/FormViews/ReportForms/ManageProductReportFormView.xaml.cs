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
    public partial class ManageProductReportFormView : Window
    {

        private ProductReportView ReportView { get; set; }

        IProductService productService = new ProductService();
        IManufacturerService manufacturerService = new ManufacturerService();
        IProductTypeService typeService = new ProductTypeService();
        IProductReportsService reportService = new ProductReportsService();
        
        public ManageProductReportFormView(ProductReportView reportView)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            ReportView = reportView;
            CreateComboBoxData();
        }

        private void CreateComboBoxData()
        {
            IList<Product> products = productService.GetProducts();
            comboBoxProduct.ItemsSource = products;
            comboBoxProduct.SelectedIndex = 0;
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
                if (datePickerDateFrom.SelectedDate.HasValue)
                {
                    report.DateRealizedFrom = datePickerDateFrom.SelectedDate.Value.Date;
                }
                else
                {
                    report.DateRealizedFrom = null;
                }

                if (datePickerDateTo.SelectedDate.HasValue)
                {
                    report.DateRealizedTo = datePickerDateTo.SelectedDate.Value.Date;
                }
                else
                {
                    report.DateRealizedTo = null;
                }
                report.Product = comboBoxProduct.SelectedItem as Product;
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
