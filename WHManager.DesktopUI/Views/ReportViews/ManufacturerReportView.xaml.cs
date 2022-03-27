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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WHManager.BusinessLogic.Models;
using WHManager.DesktopUI.Views.ReportViews.ReportDisplayViews;

namespace WHManager.DesktopUI.Views.ReportViews
{
    /// <summary>
    /// Interaction logic for ManufacturerReportView.xaml
    /// </summary>
    public partial class ManufacturerReportView : UserControl
    {
        public ManufacturerReportView()
        {
            InitializeComponent();
        }
        private void gridReportsGenerateRaport(object sender, RoutedEventArgs e)
        {
            if (gridReports.SelectedItem != null)
            {
                ManufacturerReports report = gridReports.SelectedItem as ManufacturerReports;
                foreach (System.Windows.Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).mainContent.Navigate(new ManufacturerReportDisplayView(report));
                    }
                }
            }
        }

    }
}
