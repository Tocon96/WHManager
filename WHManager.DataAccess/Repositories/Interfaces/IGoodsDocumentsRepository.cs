using System;
using System.Collections.Generic;
using System.Text;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IGoodsDocumentsRepository
    {
        void CreateNewDocument(DateTime dateIssued, int source, int destination, List<int> items);
        void UpdateDocument(int id, DateTime dateIssued, int source, int destination, List<int> items);
        void DeleteDocument(int id);
        IEnumerable<GoodsDocument> GetDocument(int id);
        IEnumerable<GoodsDocument> GetAllDocuments();
        IEnumerable<GoodsDocument> GetDocumentsByDate(DateTime? earlierDate = null, DateTime? laterDate = null);
        IEnumerable<GoodsDocument> GetDocumentsBySource(int source);
        IEnumerable<GoodsDocument> GetDocumentsByProduct(int productId);
        IEnumerable<GoodsDocument> GetDocumentsByDestination(int destination);
    }
}
