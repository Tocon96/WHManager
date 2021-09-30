using System;
using System.Collections.Generic;
using System.Text;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IOutgoingDocumentRepository
    {
        public int AddDocument(int clientId, int orderId, int invoiceId, DateTime dateSent);
        public int UpdateDocument(int id, int clientId, int orderId, int invoiceId, DateTime dateSent);
        public void DeleteDocument(int id);
        public OutgoingDocument GetDocumentById(int id);
        public IEnumerable<OutgoingDocument> GetDocuments();
        public IEnumerable<OutgoingDocument> SearchDocuments(IList<string> criteria);
    }
}
