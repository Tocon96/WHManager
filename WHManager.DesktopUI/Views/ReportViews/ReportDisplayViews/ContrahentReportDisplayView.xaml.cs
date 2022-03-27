using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for ReportDisplayView.xaml
    /// </summary>
    public partial class ContrahentReportDisplayView : UserControl
    {
        IContrahentReportsService reportService = new ContrahentReportService();
        IOrderService orderService = new OrderService();
        IOutgoingDocumentService outgoingDocumentService = new OutgoingDocumentService();
        IInvoiceService invoiceService = new InvoiceService();
        IDocumentDataService documentDataService = new DocumentDataService();
        IClientReportRecordService recordService = new ClientReportRecordService();

        private ContrahentReports Report { get; set; }
        private ObservableCollection<ClientReportRecord> ReportRecords { get; set; }
        public ContrahentReportDisplayView(ContrahentReports report)
        {
            InitializeComponent();
            Report = report;
            IList<OutgoingDocument> outgoingDocuments = outgoingDocumentService.GetDocumentsByClient(report.ContrahentId, report.DateFrom, report.DateTo);
            IList<DocumentData> data = documentDataService.GetOutgoingDocumentData(outgoingDocuments);
            IList<ClientReportRecord> records = recordService.CreateRecords(data, outgoingDocuments);

            ReportRecords = new ObservableCollection<ClientReportRecord>(records);
            gridOrders.ItemsSource = ReportRecords;

            AssignValuesToLabels(reportService.ParseOrderList(records.ToList()));
        }

        private void AssignValuesToLabels(IDictionary<string, decimal> dictionary)
        {
            labelClientName.Content = Report.ContrahentName;
            labelItemCount.Content = dictionary["itemCount"];
            labelOrderCount.Content = dictionary["elementCount"];
            labelTotalValueNet.Content = dictionary["totalValueNet"];
            labelTotalValueGross.Content = dictionary["totalValueGross"];
        }

        private void gridOrderGenerateWz(object sender, RoutedEventArgs e)
        {
            if (gridOrders.SelectedItem != null)
            {
                Order order = gridOrders.SelectedItem as Order;
                SaveFileDialog svg = new SaveFileDialog();
                svg.Filter = "Documents (*.pdf)|*.pdf|All files (*.*)|*.*";
                Nullable<bool> result = svg.ShowDialog();
                if (result == true)
                {
                    outgoingDocumentService.GeneratePdf(svg.FileName, order);
                }
            }

        }

        private void gridOrderGenerateInvoice(object sender, RoutedEventArgs e)
        {
            if (gridOrders.SelectedItem != null)
            {
                Order order = gridOrders.SelectedItem as Order;
                SaveFileDialog svg = new SaveFileDialog();
                svg.Filter = "Documents (*.pdf)|*.pdf|All files (*.*)|*.*";
                Nullable<bool> result = svg.ShowDialog();
                if (result == true)
                {
                    invoiceService.GeneratePdf(svg.FileName, order);
                }
            }
        }
    }
}