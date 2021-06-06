using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IGoodsDocumentService
    {
        void CreateNewDocument(GoodsDocument goodsDocument);
        void UpdateDocument(GoodsDocument goodsDocument);
        void DeleteDocument(int id);
        IList<GoodsDocument> GetAllDocuments();
        IList<GoodsDocument> GetDocument(int documentId);
        IList<GoodsDocument> GetDocumentsBySource(int source);
        IList<GoodsDocument> GetDocumentsByDestination(int destination);
        IList<GoodsDocument> GetDocumentsByProduct(int productId);
    }
}
