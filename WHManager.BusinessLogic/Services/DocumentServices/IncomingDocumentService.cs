using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services
{
    public class IncomingDocumentService : IIncomingDocumentService
    {
        IIncomingDocumentRepository incomingDocumentRepository = new IncomingDocumentRepository(new DataAccess.WHManagerDBContextFactory());
        IProviderService providerService = new ProviderService();

        public int AddDocument(IncomingDocument document)
        {
            return incomingDocumentRepository.AddDocument(document.Source, document.Provider.Id, document.DateSent, document.DateReceived, document.DeliveryId);
        }

        public void DeleteDocument(int id)
        {
            incomingDocumentRepository.DeleteDocument(id);
        }

        public IncomingDocument GetDocument(int id)
        {
            var document = incomingDocumentRepository.GetDocumentById(id);
            IncomingDocument incomingDocument = new IncomingDocument()
            {
                Id = document.Id,
                Source = document.Source,
                Provider = providerService.GetProvider(document.Provider.Id),
                DateReceived = document.DateReceived,
                DateSent = document.DateSent
            };
            return incomingDocument;
        }

        public IList<IncomingDocument> GetDocuments()
        {
            IList<IncomingDocument> documentsList = new List<IncomingDocument>();
            var documents = incomingDocumentRepository.GetDocuments();
            foreach(var document in documents)
            {
                IncomingDocument newDocument = new IncomingDocument
                {
                    Id = document.Id,
                    Source = document.Source,
                    Provider = providerService.GetProvider(document.Provider.Id),
                    DateReceived = document.DateReceived,
                    DateSent = document.DateSent
                };
                documentsList.Add(newDocument);
            }
            return documentsList;
        }

        public IList<IncomingDocument> SearchDocuments(IList<string> criteria)
        {
            throw new NotImplementedException();
        }

        public int UpdateDocumnet(IncomingDocument document)
        {
            return incomingDocumentRepository.UpdateDocument(document.Id, document.Source, document.Provider.Id, document.DateSent, document.DateReceived, document.DeliveryId);
        }
    }
}