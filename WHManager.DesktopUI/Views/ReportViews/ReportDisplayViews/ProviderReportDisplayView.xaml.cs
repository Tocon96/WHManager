using Microsoft.Win32;
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
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.DocumentServices;
using WHManager.BusinessLogic.Services.DocumentServices.Interfaces;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.BusinessLogic.Services.ReportsServices;
using WHManager.BusinessLogic.Services.ReportsServices.Interfaces;
using WHManager.DesktopUI.Views.WarehouseViews;

namespace WHManager.DesktopUI.Views.ReportViews.ReportDisplayViews
{
    /// <summary>
    /// Interaction logic for ProviderReportDisplayView.xaml
    /// </summary>
    public partial class ProviderReportDisplayView : UserControl
    {
        IContrahentReportsService reportService = new ContrahentReportService();
        IDeliveryService deliveryService = new DeliveryService();
        IIncomingDocumentService incomingDocumentService = new IncomingDocumentService();
        IDocumentDataService documentDataService = new DocumentDataService();
        IProviderReportRecordService recordService = new ProviderReportRecordService();

        private ContrahentReports Report { get; set; }
        private ObservableCollection<ProviderReportRecord> ReportRecords { get; set; }

        public ProviderReportDisplayView(ContrahentReports report)
        {
            InitializeComponent();
            Report = report;

            IList<IncomingDocument> incomingDocuments = incomingDocumentService.GetDocumentsByProvider(report.ContrahentId, report.DateFrom, report.DateTo);
            IList<DocumentData> data = documentDataService.GetDocumentData(incomingDocuments);
            IList<ProviderReportRecord> records = recordService.CreateRecords(data, incomingDocuments);

            ReportRecords = new ObservableCollection<ProviderReportRecord>(records);
            gridDeliveries.ItemsSource = ReportRecords;

            AssignValuesToLabels(reportService.ParseDeliveryList(records.ToList()));
        }
        private void AssignValuesToLabels(IDictionary<string, decimal> dictionary)
        {
            labelProviderName.Content = Report.ContrahentName;
            labelItemCount.Content = dictionary["itemCount"];
            labelDeliveryCount.Content = dictionary["elementCount"];
            labelTotalValueNet.Content = dictionary["totalValueNet"];
            labelTotalValueGross.Content = dictionary["totalValueGross"];
        }
        private void gridDeliveriesGenerateWz(object sender, RoutedEventArgs e)
        {
            if (gridDeliveries.SelectedItem != null)
            {
                ProviderReportRecord deliveryRecord = gridDeliveries.SelectedItem as ProviderReportRecord;
                Delivery delivery = deliveryService.GetDelivery(deliveryRecord.DeliveryId);
                SaveFileDialog svg = new SaveFileDialog();
                svg.Filter = "Documents (*.pdf)|*.pdf|All files (*.*)|*.*";
                Nullable<bool> result = svg.ShowDialog();
                if (result == true)
                {
                    incomingDocumentService.GeneratePdf(svg.FileName, delivery);
                }
            }

        }
    }
}
