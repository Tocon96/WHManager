using System;
using System.Collections.Generic;
using System.Text;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IIncomingDocumentRepository
    {
        public int AddDocument(bool source, int providerId, DateTime dateSent, DateTime dateReceived, int deliveryId);
        public int UpdateDocument(int id, bool source, int providerId, DateTime dateSent, DateTime dateReceived, int deliveryId);
        public void DeleteDocument(int id);
        public IncomingDocument GetDocumentById(int id);
        public IEnumerable<IncomingDocument> GetDocuments();
        public IEnumerable<IncomingDocument> SearchDocuments(IList<string> criteria);
    }
}
