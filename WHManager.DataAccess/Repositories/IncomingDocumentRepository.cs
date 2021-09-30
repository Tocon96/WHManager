using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class IncomingDocumentRepository : IIncomingDocumentRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public IncomingDocumentRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public int AddDocument(int providerId, DateTime dateReceived, int deliveryId)
        {
            using(WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IncomingDocument incomingDocument = new IncomingDocument()
                {
                    Provider = context.Provider.SingleOrDefault(x => x.Id == providerId),
                    DateReceived = dateReceived,
                    DeliveryId = deliveryId
                };
                try
                {
                    context.IncomingDocuments.Add(incomingDocument);
                    context.SaveChanges();
                    return incomingDocument.Id;
                }
                catch
                {
                    throw new Exception("Błąd tworzenia dokumentu.");
                }
            }
        }

        public void DeleteDocument(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.IncomingDocuments.Remove(context.IncomingDocuments.SingleOrDefault(x => x.Id == id));
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd usuwania dokumentu.");
                }
            }
        }

        public IncomingDocument GetDocumentByDeliveryId(int deliveryId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    return context.IncomingDocuments.Include(x => x.Provider).SingleOrDefault(x => x.DeliveryId == deliveryId);
                }
                catch
                {
                    throw new Exception("Błąd wyszukiwania dokumentu.");
                }
            }
        }

        public IncomingDocument GetDocumentById(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    return context.IncomingDocuments.Include(x => x.Provider).SingleOrDefault(x => x.Id == id);
                }
                catch
                {
                    throw new Exception("Błąd wyszukiwania dokumentu.");
                }
            }
        }

        public IEnumerable<IncomingDocument> GetDocuments()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<IncomingDocument> documents = context.IncomingDocuments.Include(x => x.Provider).ToList();
                    return documents;
                }
                catch
                {
                    throw new Exception("Błąd wyszukiwania dokumentu.");
                }
            }
            
        }

        public IEnumerable<IncomingDocument> SearchDocuments(IList<string> criteria)
        {
            throw new NotImplementedException();
        }

        public int UpdateDocument(int id, int providerId, DateTime dateReceived, int deliveryId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IncomingDocument document = context.IncomingDocuments.SingleOrDefault(x => x.Id == id);
                    document.Provider = context.Provider.SingleOrDefault(x => x.Id == providerId);
                    document.DateReceived = dateReceived;
                    document.DeliveryId = deliveryId;
                    return document.Id;
                }
                catch
                {
                    throw new Exception("Błąd wyszukiwania dokumentu.");
                }
            }
        }
    }
}
