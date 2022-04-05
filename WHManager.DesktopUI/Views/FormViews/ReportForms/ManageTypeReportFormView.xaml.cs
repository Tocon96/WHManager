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
using WHManager.BusinessLogic.Services.ReportsServices;
using WHManager.BusinessLogic.Services.ReportsServices.Interfaces;
using WHManager.DesktopUI.Views.ReportViews;

namespace WHManager.DesktopUI.Views.FormViews.ReportForms
{
    /// <summary>
    /// Interaction logic for ManageTypeReportFormView.xaml
    /// </summary>
    public partial class ManageTypeReportFormView : Window
    {
        private ProductTypeReportView ReportView { get; set; }

        IProductService productService = new ProductService();
        IManufacturerService manufacturerService = new ManufacturerService();
        IProductTypeService typeService = new ProductTypeService();
        ITypeReportsService reportService = new TypeReportsService();

        public ManageTypeReportFormView(ProductTypeReportView reportView)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            ReportView = reportView;
            CreateComboBoxData();
        }

        private void CreateComboBoxData()
        {
            IList<ProductType> products = typeService.GetProductTypes();
            comboBoxProduct.ItemsSource = products;
            comboBoxProduct.SelectedIndex = 0;
        }

        private void buttonConfirmClick(object sender, RoutedEventArgs e)
        {
            TypeReports report = new TypeReports();
            if (textBoxName.Text == "")
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
                report.Type = comboBoxProduct.SelectedItem as ProductType;
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
