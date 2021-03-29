using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class GoodsDocumentRepository : IGoodsDocumentsRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public GoodsDocumentRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void CreateNewDocument(DateTime dateIssued, int source, int destination, List<int> items)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    ICollection<Item> itemCollection = new ObservableCollection<Item>();
                    foreach (int i in items)
                    {
                        Item item = context.Items.SingleOrDefault(x => x.Id == i);
                        itemCollection.Add(item);
                    };
                    GoodsDocument goodsDocument = new GoodsDocument
                    {
                        DateIssued = dateIssued,
                        Source = source,
                        Destination = destination,
                        Items = itemCollection
                    };
                    context.GoodsDocuments.Add(goodsDocument);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd dodawania dokumentu: ");
                }
            }
        }

        public void DeleteDocument(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.Remove(context.GoodsDocuments.SingleOrDefault(x => x.Id == id));
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd usuwania dokumentu: ");
                }
            }
        }

        public IEnumerable<GoodsDocument> GetAllDocuments()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<GoodsDocument> goodsDocuments = context.GoodsDocuments.ToList();
                    return goodsDocuments;
                }
                catch
                {
                    throw new Exception("Błąd pobierania: ");
                }
            }
        }

        public IEnumerable<GoodsDocument> GetDocument(int id)
        {

            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<GoodsDocument> goodsDocument = context.GoodsDocuments.Include(i => i.Items)
                                                                                     .ToList()
                                                                                     .FindAll(x => x.Id == id);
                    return goodsDocument;
                }
                catch
                {
                    throw new Exception("Błąd pobierania: ");
                }
            }
        }

        public IEnumerable<GoodsDocument> GetDocumentsByDate(DateTime? earlierDate = null, DateTime? laterDate = null)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                if (earlierDate != null && laterDate != null)
                {
                    try
                    {
                        IEnumerable<GoodsDocument> goodsDocuments = context.GoodsDocuments.Include(i => i.Items)
                                                                                     .ToList()
                                                                                     .FindAll(x => x.DateIssued >= earlierDate && x.DateIssued <= laterDate);
                        return goodsDocuments;
                    }
                    catch
                    {
                        throw new Exception("Błąd pobierania: ");
                    }
                }
                else if (earlierDate != null && laterDate == null)
                {
                    try
                    {
                        IEnumerable<GoodsDocument> goodsDocuments = context.GoodsDocuments.Include(i => i.Items)
                                                                                     .ToList()
                                                                                     .FindAll(x => x.DateIssued >= earlierDate);
                        return goodsDocuments;
                    }
                    catch
                    {
                        throw new Exception("Błąd pobierania: ");
                    }
                }
                else if (earlierDate == null && laterDate != null)
                {
                    try
                    {
                        IEnumerable<GoodsDocument> goodsDocuments = context.GoodsDocuments.Include(i => i.Items)
                                                                                     .ToList()
                                                                                     .FindAll(x => x.DateIssued <= laterDate);
                        return goodsDocuments;
                    }
                    catch
                    {
                        throw new Exception("Błąd pobierania: ");
                    }
                }
                else
                {
                    throw new Exception("Proszę podać właściwe daty.");
                }
            }
        }

        public IEnumerable<GoodsDocument> GetDocumentsByProduct(int productId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<GoodsDocument> goodsDocuments = context.GoodsDocuments.Include(i => i.Items)
                                                                                      .ToList()
                                                                                      .FindAll(x => x.Items.Any(i => i.Product.Id == productId));
                    return goodsDocuments;
                }
                catch
                {
                    throw new Exception("Błąd pobierania: ");
                }
            }
        }

        public IEnumerable<GoodsDocument> GetDocumentsBySource(int source)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<GoodsDocument> goodsDocuments = context.GoodsDocuments.Include(i => i.Items)
                                                                                      .ToList()
                                                                                      .FindAll(x => x.Source == source);
                    return goodsDocuments;
                }
                catch
                {
                    throw new Exception("Błąd pobierania: ");
                }
            }
        }

        public IEnumerable<GoodsDocument> GetDocumentsByDestination(int destination)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<GoodsDocument> goodsDocuments = context.GoodsDocuments.Include(i => i.Items)
                                                                                      .ToList()
                                                                                      .FindAll(x => x.Destination == destination);
                    return goodsDocuments;
                }
                catch
                {
                    throw new Exception("Błąd pobierania: ");
                }
            }
        }

        public void UpdateDocument(int id, DateTime dateIssued, int source, int destination, List<int> items)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    ICollection<Item> itemCollection = new ObservableCollection<Item>();
                    foreach (int i in items)
                    {
                        Item item = context.Items.SingleOrDefault(x => x.Id == i);
                        itemCollection.Add(item);
                    };
                    GoodsDocument goodsDocument = context.GoodsDocuments.SingleOrDefault(x => x.Id == id);
                    goodsDocument.DateIssued = dateIssued;
                    goodsDocument.Source = source;
                    goodsDocument.Destination = destination;
                    goodsDocument.Items = itemCollection;
                    context.GoodsDocuments.Add(goodsDocument);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd aktualizacji: ");
                }
            }
        }
    }
}
