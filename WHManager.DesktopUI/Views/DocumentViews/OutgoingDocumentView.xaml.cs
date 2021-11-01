using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.DocumentServices.Interfaces;
using WHManager.BusinessLogic.Services.Interfaces;

namespace WHManager.DesktopUI.Views.DocumentViews
{
    /// <summary>
    /// Interaction logic for OutgoingDocumentView.xaml
    /// </summary>
    public partial class OutgoingDocumentView : UserControl
    {
        private ObservableCollection<OutgoingDocument> Documents { get; set; }
        IOutgoingDocumentService documentService = new OutgoingDocumentService();
        IOrderService orderService = new OrderService();
        public OutgoingDocumentView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            Documents = new ObservableCollection<OutgoingDocument>(GetDocuments());
            gridDocuments.ItemsSource = Documents;
        }

        private IList<OutgoingDocument> GetDocuments()
        {
            IList<OutgoingDocument> documents = documentService.GetDocuments();
            return documents;
        }

        private void SearchClearClick(object sender, RoutedEventArgs e)
        {
            textBoxDeliveryId.Text = "";
            textBoxDocumentId.Text = "";
            textBoxProviderName.Text = "";
            datePickerEarlierDate.SelectedDate = null;
            datePickerLaterDate.SelectedDate = null;
            LoadData();
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            Documents = new ObservableCollection<OutgoingDocument>(SearchDocuments());
            gridDocuments.ItemsSource = Documents;
        }

        private IList<OutgoingDocument> SearchDocuments()
        {
            IList<string> criteria = new List<string>();
            criteria.Add(textBoxDeliveryId.Text);
            criteria.Add(textBoxDocumentId.Text);
            criteria.Add(textBoxProviderName.Text);
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
            IList<OutgoingDocument> documents = documentService.SearchDocuments(criteria);
            return documents;
        }
        private void DownloadDocumentClick(object sender, RoutedEventArgs e)
        {
            if (gridDocuments.SelectedItem != null)
            {
                OutgoingDocument document = gridDocuments.SelectedItem as OutgoingDocument;
                Order order = orderService.GetOrderById(document.Id);
                SaveFileDialog svg = new SaveFileDialog();
                svg.Filter = "Documents (*.pdf)|*.pdf|All files (*.*)|*.*";
                Nullable<bool> result = svg.ShowDialog();
                if (result == true)
                {
                    documentService.GeneratePdf(svg.FileName, order);
                }
            }
        }
    }
}
