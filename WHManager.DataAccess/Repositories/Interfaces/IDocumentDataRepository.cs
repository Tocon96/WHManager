using System;
using System.Collections.Generic;
using System.Text;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IDocumentDataRepository
    {
        void CreateNewDataRecord(int documentId, DateTime documentDate, string documentType, string contrahentName, string contrahentNip, string contrahentPhoneNumber, int taxType, int productNumber, string productName, int productCount, decimal productPrice, decimal taxValue, decimal grossValue, decimal netValue);
        void UpdateDateRecord(int id, int documentId, DateTime documentDate, string documentType, string contrahentName, string contrahentNip, string contrahentPhoneNumber, int taxType, int productNumber, string productName, int productCount, decimal productPrice, decimal taxValue, decimal grossValue, decimal netValue);
        DocumentData GetRecord(int id);
        void DeleteRecords(int documentId, string documentType);
        void DeleteRecord(int id);
        IEnumerable<DocumentData> GetRecordsByDocument(int documentId, string documentType);
        bool CheckIfDocumentRecordsExist(int documentId, string documentType);
        bool CheckIfRecordExist(int id);
    }
}
