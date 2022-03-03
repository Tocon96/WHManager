using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WHManager.BusinessLogic.Services.ReportsServices;
using WHManager.BusinessLogic.Services.ReportsServices.Interfaces;
using WHManager.DesktopUI.Views.FormViews.ReportForms;
using WHManager.DesktopUI.Views.ReportViews.ReportDisplayViews;

namespace WHManager.DesktopUI.Views.ReportViews
{
    /// <summary>
    /// Interaction logic for ClientReport.xaml
    /// </summary>
    public partial class ClientReportView : UserControl
    {
        private ObservableCollection<ContrahentReports> Reports { get; set; }

        IContrahentReportsService reportsService = new ContrahentReportService();

        public ClientReportView()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {
            IList<ContrahentReports> reports = reportsService.GetClientReports();
            Reports = new ObservableCollection<ContrahentReports>(reports);
            gridReports.ItemsSource = Reports;
        }

        private void SearchClearClick(object sender, RoutedEventArgs e)
        {
            textBoxClientName.Text = "";
            textBoxReportId.Text = "";
            datePickerEarlierDate.SelectedDate = null;
            datePickerLaterDate.SelectedDate = null;
            LoadData();
        }

        private void gridReportGenerateRaport(object sender, RoutedEventArgs e)
        {
            if(gridReports.SelectedItem != null)
            {
                ContrahentReports report = gridReports.SelectedItem as ContrahentReports;
                foreach (System.Windows.Window window in Application.Current.Windows)
                    {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).mainContent.Navigate(new ContrahentReportDisplayView(report));
                    }
                }
            }
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            IList<string> criteria = new List<string>();
            if (!string.IsNullOrEmpty(textBoxReportId.Text))
            {
                if (int.TryParse(textBoxReportId.Text, out int result))
                {
                    criteria.Add(result.ToString());
                }
                else
                {
                    MessageBox.Show("ID Raportu nie może zawierać znaków tekstowych.");
                    criteria.Add("");
                }
            }
            else
            {
                criteria.Add("");
            }
            criteria.Add(textBoxClientName.Text);
            criteria.Add("Clients");
            if (datePickerEarlierDate.SelectedDate.HasValue)
            {
                criteria.Add(datePickerEarlierDate.SelectedDate.Value.ToShortDateString());
            }
            else
            {
                criteria.Add(null);
            }
            if (datePickerLaterDate.SelectedDate.HasValue)
            {
                criteria.Add(datePickerLaterDate.SelectedDate.Value.ToShortDateString());
            }
            else
            {
                criteria.Add(null);
            }
            IList<ContrahentReports> reports = reportsService.SearchReports(criteria.ToList());
            Reports = new ObservableCollection<ContrahentReports>(reports);
            gridReports.ItemsSource = Reports;
        }

        private void DeleteReportClick(object sender, RoutedEventArgs e)
        {
            if(gridReports.SelectedItem != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrany raport?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        ContrahentReports report = gridReports.SelectedItem as ContrahentReports;
                        reportsService.DeleteReport(report.Id);
                        LoadData();
                    }
                }
            }
        }

        private void DeleteMultipleReportsClick(object sender, RoutedEventArgs e)
        {
            if (gridReports.SelectedItems != null)
            {
                List<ContrahentReports> contrahentReports = gridReports.SelectedItems.Cast<ContrahentReports>().ToList();
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrane raporty?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        foreach (ContrahentReports report in contrahentReports)
                        {
                            reportsService.DeleteReport(report.Id);
                        }
                        LoadData();
                    }
                }
            }
        }

        private void AddReportClick(object sender, RoutedEventArgs e)
        {
            ManageClientReportFormView formView = new ManageClientReportFormView(this);
            formView.ShowDialog();

            if (formView.DialogResult.Value == true)
            {
                LoadData();
            }
        }
    }
}
