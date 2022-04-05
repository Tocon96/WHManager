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
    /// Interaction logic for ManageManufacturerReportFormView.xaml
    /// </summary>
    public partial class ManageManufacturerReportFormView : Window
    {
        private ManufacturerReportView ReportView { get; set; }

        IProductService productService = new ProductService();
        IManufacturerService manufacturerService = new ManufacturerService();
        IProductTypeService typeService = new ProductTypeService();
        IManufacturerReportsService reportService = new ManufacturerReportsService();

        public ManageManufacturerReportFormView(ManufacturerReportView reportView)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            ReportView = reportView;
            CreateComboBoxData();
        }

        private void CreateComboBoxData()
        {
            IList<Manufacturer> manufacturers = manufacturerService.GetManufacturers();
            comboBoxProduct.ItemsSource = manufacturers;
            comboBoxProduct.SelectedIndex = 0;
        }

        private void buttonConfirmClick(object sender, RoutedEventArgs e)
        {
            ManufacturerReports report = new ManufacturerReports();
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
                report.Manufacturer = comboBoxProduct.SelectedItem as Manufacturer;
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
