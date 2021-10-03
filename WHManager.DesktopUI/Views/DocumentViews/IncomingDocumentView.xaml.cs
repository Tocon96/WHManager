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
using WHManager.BusinessLogic.Services.Interfaces;

namespace WHManager.DesktopUI.Views.DocumentViews
{
    /// <summary>
    /// Interaction logic for IncomingDocumentView.xaml
    /// </summary>
    public partial class IncomingDocumentView : UserControl
    {
        private ObservableCollection<IncomingDocument> Documents { get; set; }
        IIncomingDocumentService documentService = new IncomingDocumentService();
        IDeliveryService deliveryService = new DeliveryService();
        public IncomingDocumentView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            Documents = new ObservableCollection<IncomingDocument>(GetDocuments());
            gridDocuments.ItemsSource = Documents;
        }

        private IList<IncomingDocument> GetDocuments()
        {
            IList<IncomingDocument> documents = documentService.GetDocuments();
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
            Documents = new ObservableCollection<IncomingDocument>(SearchDocuments());
            gridDocuments.ItemsSource = Documents;
        }

        private IList<IncomingDocument> SearchDocuments()
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
            IList<IncomingDocument> documents = documentService.SearchDocuments(criteria);
            return documents;
        }

        private void DownloadDocumentClick(object sender, RoutedEventArgs e)
        {
            if (gridDocuments.SelectedItem != null)
            {
                IncomingDocument incomingDocument = gridDocuments.SelectedItem as IncomingDocument;
                Delivery delivery = deliveryService.GetDelivery(incomingDocument.DeliveryId);
                SaveFileDialog svg = new SaveFileDialog();
                svg.Filter = "Documents (*.pdf)|*.pdf|All files (*.*)|*.*";
                Nullable<bool> result = svg.ShowDialog();
                if (result == true)
                {
                    documentService.GeneratePdf(svg.FileName, delivery);
                }
            }
        }
    } 
}
