using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services
{
    public interface IIncomingDocumentService
    {
        public int AddDocument(IncomingDocument document);
        public int UpdateDocumnet(IncomingDocument document);
        public void DeleteDocument(int id);
        public IncomingDocument GetDocument(int id);
        public IList<IncomingDocument> GetDocuments();
        public IList<IncomingDocument> SearchDocuments(IList<string> criteria);

    }
}