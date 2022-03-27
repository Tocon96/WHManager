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
    /// Interaction logic for ProviderReportView.xaml
    /// </summary>
    public partial class ProviderReportView : UserControl
    {

        private ObservableCollection<ContrahentReports> Reports { get; set; }

        IContrahentReportsService reportsService = new ContrahentReportService();


        public ProviderReportView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            IList<ContrahentReports> reports = reportsService.GetProviderReports();
            Reports = new ObservableCollection<ContrahentReports>(reports);
            gridProviders.ItemsSource = Reports;
        }

        private void SearchClearClick(object sender, RoutedEventArgs e)
        {
            textProviderName.Text = "";
            textBoxReportId.Text = "";
            datePickerEarlierDate.SelectedDate = null;
            datePickerLaterDate.SelectedDate = null;
            LoadData();
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
            criteria.Add(textProviderName.Text);
            criteria.Add("Providers");
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
            gridProviders.ItemsSource = Reports;
        }

        private void DeleteReportClick(object sender, RoutedEventArgs e)
        {
            if (gridProviders.SelectedItem != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrany raport?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        ContrahentReports report = gridProviders.SelectedItem as ContrahentReports;
                        reportsService.DeleteReport(report.Id);
                        LoadData();
                    }
                }
            }

        }

        private void DeleteMultipleReportsClick(object sender, RoutedEventArgs e)
        {
            if (gridProviders.SelectedItems != null)
            {
                List<ContrahentReports> contrahentReports = gridProviders.SelectedItems.Cast<ContrahentReports>().ToList();
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
            ManageProviderReportFormView formView = new ManageProviderReportFormView(this);
            formView.ShowDialog();

            if (formView.DialogResult.Value == true)
            {
                LoadData();
            }
        }

        private void gridReportGenerateRaport(object sender, RoutedEventArgs e)
        {
            if (gridProviders.SelectedItem != null)
            {
                ContrahentReports report = gridProviders.SelectedItem as ContrahentReports;
                foreach (System.Windows.Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).mainContent.Navigate(new ProviderReportDisplayView(report));
                    }
                }
            }
        }

    }
}
