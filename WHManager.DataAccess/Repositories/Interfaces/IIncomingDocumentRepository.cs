using System;
using System.Collections.Generic;
using System.Text;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IIncomingDocumentRepository
    {
        public int AddDocument(int providerId, DateTime dateReceived, int deliveryId);
        public int UpdateDocument(int id, int providerId, DateTime dateReceived, int deliveryId);
        public void DeleteDocument(int id);
        public IncomingDocument GetDocumentById(int id);
        public IncomingDocument GetDocumentByDeliveryId(int deliveryId);
        public IEnumerable<IncomingDocument> GetDocuments();
        public IEnumerable<IncomingDocument> SearchDocuments(IList<string> criteria);
        public IEnumerable<IncomingDocument> GetDocumentsByProvider(int contrahentId, DateTime? dateFrom, DateTime? dateTo);
    }
}
