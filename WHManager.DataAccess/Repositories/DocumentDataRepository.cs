using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class DocumentDataRepository : IDocumentDataRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;
        public DocumentDataRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public bool CheckIfDocumentRecordsExist(int documentId, string documentType)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                if (context.DocumentData.Any(x => x.DocumentId == documentId && x.DocumentType.StartsWith(documentType)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool CheckIfRecordExist(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                if (context.DocumentData.Any(x => x.Id == id))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void CreateNewDataRecord(int documentId, DateTime documentDate, string documentType, string contrahentName, string contrahentNip, string contrahentPhoneNumber, int taxType, int productNumber, string productName, int productCount, decimal productPrice, decimal taxValue, decimal grossValue, decimal netValue)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                DocumentData dataRecord = new DocumentData
                {
                    DocumentId = documentId,
                    DocumentType = documentType,
                    DocumentDate = documentDate,
                    ContrahentName = contrahentName,
                    ContrahentNip = contrahentNip,
                    ContrahentPhoneNumber = contrahentPhoneNumber,
                    TaxType = taxType,
                    ProductNumber = productNumber,
                    ProductName = productName,
                    ProductCount = productCount,
                    ProductPrice = productPrice,
                    TaxValue = taxValue,
                    GrossValue = grossValue,
                    NetValue = netValue

                };
                context.DocumentData.Add(dataRecord);
                context.SaveChanges();
            }
        }

        public void DeleteRecord(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                context.DocumentData.Remove(context.DocumentData.SingleOrDefault(x => x.Id == id));
            }
        }

        public void DeleteRecords(int documentId, string documentType)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<DocumentData> dataSet = context.DocumentData.ToList().FindAll(x => x.DocumentId == documentId && x.DocumentType.StartsWith(documentType));
                foreach(DocumentData data in dataSet)
                {
                    context.DocumentData.Remove(data);
                }
                context.SaveChanges();
            }
            
        }

        public DocumentData GetRecord(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                DocumentData data  = context.DocumentData.SingleOrDefault(x => x.Id == id);
                return data;
            }
        }

        public IEnumerable<DocumentData> GetRecordsByDocument(int documentId, string documentType)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                return context.DocumentData.ToList().FindAll(x => x.DocumentId == documentId && x.DocumentType.StartsWith(documentType));
            }
        }

        public void UpdateDateRecord(int id, int documentId, DateTime documentDate, string documentType, string contrahentName, string contrahentNip, string contrahentPhoneNumber, int taxType, int productNumber, string productName, int productCount, decimal productPrice, decimal taxValue, decimal grossValue, decimal netValue)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                DocumentData data = context.DocumentData.SingleOrDefault(x => x.Id == id);
                data.DocumentId = documentId;
                data.DocumentType = documentType;
                data.DocumentDate = documentDate;
                data.ContrahentName = contrahentName;
                data.ContrahentNip = contrahentNip;
                data.ContrahentPhoneNumber = contrahentPhoneNumber;
                data.TaxType = taxType;
                data.ProductNumber = productNumber;
                data.ProductName = productName;
                data.ProductCount = productCount;
                data.ProductPrice = productPrice;
                data.TaxValue = taxValue;
                data.GrossValue = grossValue;
                data.NetValue = netValue;
                context.DocumentData.Update(data);
                context.SaveChanges();
            }
        }
    }
}
