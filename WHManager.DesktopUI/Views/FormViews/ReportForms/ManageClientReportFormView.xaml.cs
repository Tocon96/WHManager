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
    /// Interaction logic for ManageClientReportFormView.xaml
    /// </summary>
    public partial class ManageClientReportFormView : Window
    {
        private ClientReportView ReportView { get; set; }
        IContrahentReportsService reportService = new ContrahentReportService();
        IClientService clientService = new ClientService();
        public ManageClientReportFormView(ClientReportView reportView)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            ReportView = reportView;
            LoadData();
        }


        private void LoadData()
        {
            ObservableCollection<Client> clients= new ObservableCollection<Client>(clientService.GetAllClients());
            comboBoxClient.ItemsSource = clients;
            comboBoxClient.SelectedIndex = 0;
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

        private void buttonConfirmClick(object sender, RoutedEventArgs e)
        {
            ContrahentReports report = new ContrahentReports();
            Client client = comboBoxClient.SelectedItem as Client;
            report.ContrahentId = client.Id;
            report.ContrahentName = client.Name;
            report.ReportOrigin = "Clients";
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

            if(datePickerDateFrom.SelectedDate.HasValue && datePickerDateTo.SelectedDate.HasValue)
            {
                if (datePickerDateFrom.SelectedDate.Value.Date <= datePickerDateTo.SelectedDate.Value.Date)
                {
                    reportService.CreateReport(report);
                    DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Data \"Od\" nie może być mniejsza od daty \"Do\"");
                }
            }
            else
            {
                reportService.CreateReport(report);
                DialogResult = true;
                this.Close();
            }
        }

    }
}
