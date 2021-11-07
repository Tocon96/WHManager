using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class OutgoingDocumentRepository : IOutgoingDocumentRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public OutgoingDocumentRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public int AddDocument(int clientId, int orderId, DateTime dateSent)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                OutgoingDocument outgoingDocument = new OutgoingDocument()
                {
                    Contrahent = context.Clients.SingleOrDefault(x => x.Id == clientId),
                    OrderId = orderId,
                    DateSent = dateSent
                };
                try
                {
                    context.OutgoingDocuments.Add(outgoingDocument);
                    context.SaveChanges();
                    return outgoingDocument.Id;
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
                    context.OutgoingDocuments.Remove(context.OutgoingDocuments.SingleOrDefault(x => x.Id == id));
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd usuwania dokumentu.");
                }
            }

        }

        public OutgoingDocument GetDocumentById(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    return context.OutgoingDocuments.Include(x => x.Contrahent)
                                                    .SingleOrDefault(x => x.Id == id);
                }
                catch
                {
                    throw new Exception("Błąd wyszukiwania dokumentu.");
                }
            }

        }

        public IEnumerable<OutgoingDocument> GetDocuments()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<OutgoingDocument> documents = context.OutgoingDocuments.Include(x => x.Contrahent)
                                                                                       .ToList();
                    return documents;
                }
                catch
                {
                    throw new Exception("Błąd wyszukiwania dokumentu.");
                }
            }

        }

        public IEnumerable<OutgoingDocument> SearchDocuments(IList<string> criteria)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IQueryable<OutgoingDocument> documents = context.OutgoingDocuments.AsQueryable();
                if (!string.IsNullOrEmpty(criteria[0]))
                {
                    int.TryParse(criteria[0], out int result);
                    documents = documents.Include(x => x.Contrahent).Where(x => x.Id == result);
                }
                if (!string.IsNullOrEmpty(criteria[1]))
                {
                    int.TryParse(criteria[1], out int result);
                    documents = documents.Include(x => x.Contrahent).Where(x => x.OrderId == result);
                }
                if (!string.IsNullOrEmpty(criteria[2]))
                {
                    documents = documents.Include(x => x.Contrahent).Where(x => x.Contrahent.Name.StartsWith(criteria[2]));
                }
                if (!string.IsNullOrEmpty(criteria[3]) && string.IsNullOrEmpty(criteria[4]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[3]);
                    documents = documents.Include(x => x.Contrahent).Where(x => x.DateSent >= earlierDate);
                }

                if (string.IsNullOrEmpty(criteria[3]) && !string.IsNullOrEmpty(criteria[4]))
                {
                    DateTime laterDate = Convert.ToDateTime(criteria[4]);
                    documents = documents.Include(x => x.Contrahent).Where(x => x.DateSent <= laterDate);
                }

                if (!string.IsNullOrEmpty(criteria[3]) && !string.IsNullOrEmpty(criteria[4]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[3]);
                    DateTime laterDate = Convert.ToDateTime(criteria[4]);
                    documents = documents.Include(x => x.Contrahent).Where(x => x.DateSent >= earlierDate && x.DateSent <= laterDate);
                }
                IEnumerable<OutgoingDocument> documentsList = documents.ToList();
                return documentsList;
            }            
        }

        public int UpdateDocument(int id, int clientId, int orderId, DateTime dateSent)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    OutgoingDocument document = context.OutgoingDocuments.SingleOrDefault(x => x.Id == id);
                    document.Contrahent = context.Clients.SingleOrDefault(x => x.Id == clientId);
                    document.OrderId = orderId;
                    document.DateSent = dateSent;
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
