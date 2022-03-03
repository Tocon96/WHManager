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
    /// Interaction logic for ManageProviderReportFormView.xaml
    /// </summary>
    public partial class ManageProviderReportFormView : Window
    {
        IContrahentReportsService reportService = new ContrahentReportService();
        IProviderService providerService = new ProviderService();

        private ProviderReportView ReportView { get; set; }

        public ManageProviderReportFormView(ProviderReportView reportView)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            ReportView = reportView;
            LoadData();
        }

        private void LoadData()
        {
            ObservableCollection<Provider> providers = new ObservableCollection<Provider>(providerService.GetAllProviders());
            comboBoxProvider.ItemsSource = providers;
            comboBoxProvider.SelectedIndex = 0;
        }


        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        public void OnDialogClose()
        {
            ReportView.gridProviders.Items.Refresh();
        }

        private void buttonConfirmClick(object sender, RoutedEventArgs e)
        {
            ContrahentReports report = new ContrahentReports();
            Provider provider = comboBoxProvider.SelectedItem as Provider;
            report.ContrahentId = provider.Id;
            report.ContrahentName = provider.Name;
            report.ReportOrigin = "Providers";
            if (datePickerDateFrom.SelectedDate.HasValue)
            {
                report.DateFrom = datePickerDateFrom.SelectedDate.Value.Date;
            }
            else
            {
                report.DateFrom = null;
            }

            if (datePickerDateTo.SelectedDate.HasValue)
            {
                report.DateTo = datePickerDateTo.SelectedDate.Value.Date;
            }
            else
            {
                report.DateTo = null;
            }

            reportService.CreateReport(report);
            DialogResult = true;
            this.Close();

        }
    }
}
