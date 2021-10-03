using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services.DocumentServices.Interfaces
{
    public class OutgoingDocumentService : IOutgoingDocumentService
    {
        IOutgoingDocumentRepository outgoingDocumentRepository = new OutgoingDocumentRepository(new DataAccess.WHManagerDBContextFactory());
        IClientService clientService = new ClientService();
        IOrderService orderService = new OrderService();
        IInvoiceService invoiceService = new InvoiceService();

        public int AddDocument(OutgoingDocument document)
        {
            return outgoingDocumentRepository.AddDocument(document.Contrahent.Id, document.Order.Id, document.Invoice.Id, document.DateSent);
        }

        public void DeleteDocument(int id)
        {
            outgoingDocumentRepository.DeleteDocument(id);
        }

        public OutgoingDocument GetDocument(int id)
        {
            var document = outgoingDocumentRepository.GetDocumentById(id);
            OutgoingDocument outgoingDocument = new OutgoingDocument()
            {
                Id = document.Id,
                Contrahent = clientService.GetClient(document.Contrahent.Id)[0],
                Order = orderService.GetOrderById(document.Order.Id),
                Invoice = invoiceService.GetInvoiceById(document.Invoice.Id),
            };
            return outgoingDocument;

        }

        public IList<OutgoingDocument> GetDocuments()
        {
            IList<OutgoingDocument> documentsList = new List<OutgoingDocument>();
            var documents = outgoingDocumentRepository.GetDocuments();
            foreach (var document in documents)
            {
                OutgoingDocument newDocument = new OutgoingDocument
                {
                    Id = document.Id,
                    Contrahent = clientService.GetClient(document.Contrahent.Id)[0],
                    Order = orderService.GetOrderById(document.Order.Id),
                    Invoice = invoiceService.GetInvoiceById(document.Invoice.Id),
                };
                documentsList.Add(newDocument);
            }
            return documentsList;

        }

        public IList<OutgoingDocument> SearchDocuments(IList<string> criteria)
        {
            throw new NotImplementedException();
        }

        public int UpdateDocumnet(OutgoingDocument document)
        {
            return outgoingDocumentRepository.UpdateDocument(document.Id, document.Contrahent.Id, document.Order.Id, document.Invoice.Id, document.DateSent);
        }

        public void GeneratePdf(string filename, Order order)
        {
            throw new NotImplementedException();
        }
    }
}
