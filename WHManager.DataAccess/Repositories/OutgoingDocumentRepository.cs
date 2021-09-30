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
        public int AddDocument(int clientId, int orderId, int invoiceId, DateTime dateSent)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                OutgoingDocument outgoingDocument = new OutgoingDocument()
                {
                    Contrahent = context.Clients.SingleOrDefault(x => x.Id == clientId),
                    Order = context.Orders.SingleOrDefault(x => x.Id == orderId),
                    Invoice = context.Invoices.SingleOrDefault(x => x.Id == invoiceId),
                    DateSent = dateSent,
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
                    return context.OutgoingDocuments.Include(x => x.Invoice)
                                                    .Include(x => x.Order)
                                                    .Include(x => x.Contrahent)
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
                    IEnumerable<OutgoingDocument> documents = context.OutgoingDocuments.Include(x => x.Invoice)
                                                                                       .Include(x => x.Order)
                                                                                       .Include(x => x.Contrahent)
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
            throw new NotImplementedException();
        }

        public int UpdateDocument(int id, int clientId, int orderId, int invoiceId, DateTime dateSent)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    OutgoingDocument document = context.OutgoingDocuments.SingleOrDefault(x => x.Id == id);
                    document.Contrahent = context.Clients.SingleOrDefault(x => x.Id == clientId);
                    document.Order = context.Orders.SingleOrDefault(x => x.Id == orderId);
                    document.Invoice = context.Invoices.SingleOrDefault(x => x.Id == invoiceId);
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
