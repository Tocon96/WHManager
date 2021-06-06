using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services
{
    public class GoodsDocumentService : IGoodsDocumentService
    {
        private readonly IItemService itemService = new ItemService();
        private readonly IGoodsDocumentsRepository _goodsDocumentRepository = new GoodsDocumentRepository(new DataAccess.WHManagerDBContextFactory());
        public void CreateNewDocument(GoodsDocument goodsDocument)
        {
            try
            {
                DateTime dateCreated = goodsDocument.DateIssued;
                int source = goodsDocument.Source;
                int destination = goodsDocument.Destination;
                List<Item> items = new List<Item>();
                List<int> itemIds = new List<int>();
                foreach (ProductItem productItem in goodsDocument.productItems)
                {
                    Item item = new Item
                    {
                        Product = productItem.Product,
                        DateOfAdmission = goodsDocument.DateIssued,
                        IsInStock = true
                    };
                    items.Add(item);
                }
                itemIds = itemService.CreateNewItems(items);
                _goodsDocumentRepository.CreateNewDocument(dateCreated, source, destination, itemIds);
            }
            catch
            {
                throw new Exception("Błąd tworzenia dokumentu: ");            
            }
        }

        public void DeleteDocument(int id)
        {
            try
            {
                _goodsDocumentRepository.DeleteDocument(id);
            }
            catch
            {
                throw new Exception("Błąd usuwania dokumentu: ");
            }
        }

        public IList<GoodsDocument> GetAllDocuments()
        {
            try
            {
                IList<GoodsDocument> documents = new List<GoodsDocument>();
                var documentCollection = _goodsDocumentRepository.GetAllDocuments();
                IList<Item> itemsList = new List<Item>();
                foreach (var document in documentCollection)
                {
                    foreach(var item in document.Items)
                    {
                        itemsList.Add(itemService.GetItem(item.Id));
                    }
                    GoodsDocument newDocument = new GoodsDocument
                    {
                        Id = document.Id,
                        Source = document.Source,
                        Destination = document.Destination,
                        DateIssued = document.DateIssued,
                        items = itemsList
                    };
                    documents.Add(newDocument);
                }
                return documents;
            }
            catch
            {
                throw new Exception("Błąd pobierania dokumentów: ");
            }
        }

        public IList<GoodsDocument> GetDocument(int documentId)
        {
            try
            {
                IList<GoodsDocument> documents = new List<GoodsDocument>();
                var documentCollection = _goodsDocumentRepository.GetDocument(documentId);
                IList<Item> itemsList = new List<Item>();
                foreach (var document in documentCollection)
                {
                    foreach (var item in document.Items)
                    {
                        itemsList.Add(itemService.GetItem(item.Id));
                    }
                    GoodsDocument newDocument = new GoodsDocument
                    {
                        Id = document.Id,
                        Source = document.Source,
                        Destination = document.Destination,
                        DateIssued = document.DateIssued,
                        items = itemsList
                    };
                    documents.Add(newDocument);
                }
                return documents;
            }
            catch
            {
                throw new Exception("Błąd pobierania dokumentu po ID: ");
            }
        }

        public IList<GoodsDocument> GetDocumentsByDestination(int destination)
        {
            try
            {
                IList<GoodsDocument> documents = new List<GoodsDocument>();
                var documentCollection = _goodsDocumentRepository.GetDocumentsByDestination(destination);
                IList<Item> itemsList = new List<Item>();
                foreach (var document in documentCollection)
                {
                    foreach (var item in document.Items)
                    {
                        itemsList.Add(itemService.GetItem(item.Id));
                    }
                    GoodsDocument newDocument = new GoodsDocument
                    {
                        Id = document.Id,
                        Source = document.Source,
                        Destination = document.Destination,
                        DateIssued = document.DateIssued,
                        items = itemsList
                    };
                    documents.Add(newDocument);
                }
                return documents;
            }
            catch
            {
                throw new Exception("Błąd pobierania dokumentu po pochodzeniu: ");
            }
        }

        public IList<GoodsDocument> GetDocumentsByProduct(int productId)
        {
            try
            {
                IList<GoodsDocument> documents = new List<GoodsDocument>();
                var documentCollection = _goodsDocumentRepository.GetDocumentsByProduct(productId);
                IList<Item> itemsList = new List<Item>();
                foreach (var document in documentCollection)
                {
                    foreach (var item in document.Items)
                    {
                        itemsList.Add(itemService.GetItem(item.Id));
                    }
                    GoodsDocument newDocument = new GoodsDocument
                    {
                        Id = document.Id,
                        Source = document.Source,
                        Destination = document.Destination,
                        DateIssued = document.DateIssued,
                        items = itemsList
                    };
                    documents.Add(newDocument);
                }
                return documents;
            }
            catch
            {
                throw new Exception("Błąd pobierania dokumentu po ID produktu: ");
            }
        }

        public IList<GoodsDocument> GetDocumentsBySource(int source)
        {
            try
            {
                IList<GoodsDocument> documents = new List<GoodsDocument>();
                var documentCollection = _goodsDocumentRepository.GetDocumentsBySource(source);
                IList<Item> itemsList = new List<Item>();
                foreach (var document in documentCollection)
                {
                    foreach (var item in document.Items)
                    {
                        itemsList.Add(itemService.GetItem(item.Id));
                    }
                    GoodsDocument newDocument = new GoodsDocument
                    {
                        Id = document.Id,
                        Source = document.Source,
                        Destination = document.Destination,
                        DateIssued = document.DateIssued,
                        items = itemsList
                    };
                    documents.Add(newDocument);
                }
                return documents;
            }
            catch
            {
                throw new Exception("Błąd pobierania dokumentu po źródle: ");
            }
        }

        public void UpdateDocument(GoodsDocument goodsDocument)
        {
            try
            {
                int id = goodsDocument.Id;
                DateTime dateCreated = goodsDocument.DateIssued;
                int source = goodsDocument.Source;
                int destination = goodsDocument.Destination;
                List<Item> items = new List<Item>();
                List<int> itemIds = new List<int>();
                foreach (ProductItem productItem in goodsDocument.productItems)
                {
                    Item item = new Item
                    {
                        Product = productItem.Product,
                        DateOfAdmission = goodsDocument.DateIssued,
                        IsInStock = true
                    };
                    items.Add(item);
                }
                itemIds = itemService.CreateNewItems(items);
                _goodsDocumentRepository.UpdateDocument(id, dateCreated, source, destination, itemIds);
            }
            catch
            {
                throw new Exception("Błąd aktualizacji dokumentu: ");
            }

        }
    }
}
