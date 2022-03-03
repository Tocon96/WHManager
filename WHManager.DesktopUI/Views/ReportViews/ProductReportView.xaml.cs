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

namespace WHManager.DesktopUI.Views.ReportViews
{
    /// <summary>
    /// Interaction logic for ProductReportView.xaml
    /// </summary>
    public partial class ProductReportView : UserControl
    {
        private ObservableCollection<ProductReports> Reports { get; set; }

        IProductReportsService reportsService = new ProductReportsService();

        public ProductReportView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            IList<ProductReports> reports = reportsService.GetReports();
            Reports = new ObservableCollection<ProductReports>(reports);
            gridReports.ItemsSource = Reports;
        }

        private void SearchClearClick(object sender, RoutedEventArgs e)
        {
            textBoxReportId.Text = "";
            datePickerEarlierDateDelivered.SelectedDate = null;
            datePickerEarlierDateOrdered.SelectedDate = null;
            datePickerLaterDateOrdered.SelectedDate = null;
            datePickerLaterDateDelivered.SelectedDate = null;
            LoadData();
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
            if (datePickerEarlierDateOrdered.SelectedDate.HasValue)
            {
                criteria.Add(datePickerEarlierDateOrdered.SelectedDate.Value.ToShortDateString());
            }
            else
            {
                criteria.Add(null);
            }
            if (datePickerLaterDateOrdered.SelectedDate.HasValue)
            {
                criteria.Add(datePickerLaterDateOrdered.SelectedDate.Value.ToShortDateString());
            }
            else
            {
                criteria.Add(null);
            }

            IList<ProductReports> reports = reportsService.SearchReports(criteria.ToList());
            Reports = new ObservableCollection<ProductReports>(reports);
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
                        ProductReports report = gridReports.SelectedItem as ProductReports;
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
                List<ProductReports> reports = gridReports.SelectedItems.Cast<ProductReports>().ToList();
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrane raporty?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        foreach (ProductReports report in reports)
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
            ManageProductFormPhaseIView manageProductFormPhaseIView = new ManageProductFormPhaseIView(this);
            manageProductFormPhaseIView.ShowDialog();

            if (manageProductFormPhaseIView.DialogResult.Value == true)
            {
                LoadData();
            }

        }
    }
}
