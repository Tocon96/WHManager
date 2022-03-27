using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.DocumentServices.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services.DocumentServices
{
    public class DocumentDataService : IDocumentDataService
    {
        IDocumentDataRepository dataRepository = new DocumentDataRepository(new DataAccess.WHManagerDBContextFactory());
        public bool CheckIfDocumentRecordsExist(int documentId, string documentType)
        {
            return dataRepository.CheckIfDocumentRecordsExist(documentId, documentType);
        }

        public bool CheckIfRecordExist(int id)
        {
            return dataRepository.CheckIfRecordExist(id);
        }

        public void CreateNewDataRecord(DocumentData record)
        {
            dataRepository.CreateNewDataRecord(record.DocumentId, record.DocumentDate, record.DocumentType, record.ContrahentName, record.ContrahentNip, record.ContrahentPhoneNumber, record.TaxType, record.ProductNumber, record.ProductName, record.ProductCount, record.ProductPrice, record.TaxValue, record.GrossValue, record.NetValue);
        }

        public void DeleteRecord(int id)
        {
            dataRepository.DeleteRecord(id);
        }

        public void DeleteRecords(int documentId, string documentType)
        {
            dataRepository.DeleteRecords(documentId, documentType);
        }

        public IList<DocumentData> GetDocumentData(IList<IncomingDocument> incomingDocuments)
        {
            IList<DocumentData> documentDataList = new List<DocumentData>();
            foreach(IncomingDocument document in incomingDocuments)
            {
                IList <DocumentData> data = GetRecordsByDocument(document.Id, "IncomingDocument");
                foreach(DocumentData record in data)
                {
                    documentDataList.Add(record);
                }
            }
            return documentDataList;
        }

        public IList<DocumentData> GetOutgoingDocumentData(IList<OutgoingDocument> outgoingDocuments)
        {
            IList<DocumentData> documentDataList = new List<DocumentData>();
            foreach (OutgoingDocument document in outgoingDocuments)
            {
                IList<DocumentData> data = GetRecordsByDocument(document.Id, "OutgoingDocument");
                foreach (DocumentData record in data)
                {
                    documentDataList.Add(record);
                }
            }
            return documentDataList;
        }


        public DocumentData GetRecord(int id)
        {
            var record = dataRepository.GetRecord(id);
            DocumentData data = new DocumentData
            {
                Id = record.Id,
                DocumentId = record.DocumentId,
                DocumentDate = record.DocumentDate,
                DocumentType = record.DocumentType,
                ContrahentName = record.ContrahentName,
                ContrahentNip = record.ContrahentNip,
                ContrahentPhoneNumber = record.ContrahentPhoneNumber,
                TaxType = record.TaxType,
                ProductNumber = record.ProductNumber,
                ProductName = record.ProductName,
                ProductCount = record.ProductCount,
                ProductPrice = record.ProductPrice,
                TaxValue = record.TaxValue,
                GrossValue = record.GrossValue,
                NetValue = record.NetValue
            };
            return data;
        }

        public IList<DocumentData> GetRecordsByDocument(int documentId, string documentType)
        {
            var records = dataRepository.GetRecordsByDocument(documentId, documentType);
            IList<DocumentData> dataRecords = new List<DocumentData>();
            foreach(var record in records)
            {
                DocumentData data = new DocumentData
                {
                    Id = record.Id,
                    DocumentId = record.DocumentId,
                    DocumentDate = record.DocumentDate,
                    DocumentType = record.DocumentType,
                    ContrahentName = record.ContrahentName,
                    ContrahentNip = record.ContrahentNip,
                    ContrahentPhoneNumber = record.ContrahentPhoneNumber,
                    TaxType = record.TaxType,
                    ProductNumber = record.ProductNumber,
                    ProductName = record.ProductName,
                    ProductCount = record.ProductCount,
                    ProductPrice = record.ProductPrice,
                    TaxValue = record.TaxValue,
                    GrossValue = record.GrossValue,
                    NetValue = record.NetValue
                };
                dataRecords.Add(data);
            }
            return dataRecords;
        }

        public void UpdateDateRecord(DocumentData record)
        {
            dataRepository.UpdateDateRecord(record.Id, record.DocumentId, record.DocumentDate, record.DocumentType, record.ContrahentName, record.ContrahentNip, record.ContrahentPhoneNumber, record.TaxType, record.ProductNumber, record.ProductName, record.ProductCount, record.ProductPrice, record.TaxValue, record.GrossValue, record.NetValue);
        }
    }
}
