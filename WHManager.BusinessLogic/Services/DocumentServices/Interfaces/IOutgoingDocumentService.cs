using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.DocumentServices.Interfaces
{
    public interface IOutgoingDocumentService
    {
        public int AddDocument(OutgoingDocument document);
        public int UpdateDocument(OutgoingDocument document);
        public void DeleteDocument(int id);
        public OutgoingDocument GetDocument(int id);
        public IList<OutgoingDocument> GetDocuments();
        public IList<OutgoingDocument> SearchDocuments(IList<string>criteria);
        public OutgoingDocument GetDocumentByOrderId(int orderId);
        public void GeneratePdf(string filename, Order order);
        public IList<OutgoingDocument>GetDocumentsByClient(int contrahentId, DateTime? dateFrom, DateTime? dateTo);
    }
}
