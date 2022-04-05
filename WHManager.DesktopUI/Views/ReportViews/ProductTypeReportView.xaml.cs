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
    /// Interaction logic for ProductTypeReportView.xaml
    /// </summary>
    public partial class ProductTypeReportView : UserControl
    {
        private ObservableCollection<TypeReports> Reports { get; set; }

        ITypeReportsService reportsService = new TypeReportsService();

        public ProductTypeReportView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            IList<TypeReports> reports = reportsService.GetReports();
            Reports = new ObservableCollection<TypeReports>(reports);
            gridReports.ItemsSource = Reports;
        }

        private void SearchClearClick(object sender, RoutedEventArgs e)
        {
            textBoxReportId.Text = "";
            datePickerEarlierDateDelivered.SelectedDate = null;
            datePickerLaterDateDelivered.SelectedDate = null;
            LoadData();
        }
        private void gridReportsGenerateRaport(object sender, RoutedEventArgs e)
        {
            if (gridReports.SelectedItem != null)
            {
                TypeReports report = gridReports.SelectedItem as TypeReports;
                foreach (System.Windows.Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).mainContent.Navigate(new ProductTypeReportDisplayView(report));
                    }
                }
            }
        }

        private void AddReportClick(object sender, RoutedEventArgs e)
        {
            ManageTypeReportFormView manageTypeReportFormView = new ManageTypeReportFormView(this);
            manageTypeReportFormView.ShowDialog();

            if (manageTypeReportFormView.DialogResult.Value == true)
            {
                LoadData();
            }

        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            IList<string> criteria = new List<string>();
            if (!string.IsNullOrEmpty(textBoxReportId.Text))
            {
                criteria.Add(textBoxReportId.Text);
            }
            else
            {
                criteria.Add("");
            }
            if (!string.IsNullOrEmpty(textBoxTypeId.Text))
            {
                criteria.Add(textBoxTypeId.Text);
            }
            else
            {
                criteria.Add("");
            }
            if (datePickerEarlierDateDelivered.SelectedDate.HasValue)
            {
                criteria.Add(datePickerEarlierDateDelivered.SelectedDate.Value.ToShortDateString());
            }
            else
            {
                criteria.Add(null);
            }
            if (datePickerLaterDateDelivered.SelectedDate.HasValue)
            {
                criteria.Add(datePickerLaterDateDelivered.SelectedDate.Value.ToShortDateString());
            }
            else
            {
                criteria.Add(null);
            }

            IList<TypeReports> reports = reportsService.SearchReports(criteria.ToList());
            Reports = new ObservableCollection<TypeReports>(reports);
            gridReports.ItemsSource = Reports;

        }


        private void DeleteReportClick(object sender, RoutedEventArgs e)
        {
            if (gridReports.SelectedItem != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrany raport?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        TypeReports report = gridReports.SelectedItem as TypeReports;
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
                List<TypeReports> reports = gridReports.SelectedItems.Cast<TypeReports>().ToList();
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrane raporty?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        foreach (TypeReports report in reports)
                        {
                            reportsService.DeleteReport(report.Id);
                        }
                        LoadData();
                    }
                }
            }

        }

    }

}
