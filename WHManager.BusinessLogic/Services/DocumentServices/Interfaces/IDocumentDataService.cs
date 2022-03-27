using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.DocumentServices.Interfaces
{
    public interface IDocumentDataService
    {
        void CreateNewDataRecord(DocumentData record);
        void UpdateDateRecord(DocumentData record);
        DocumentData GetRecord(int id);
        void DeleteRecords(int documentId, string documentType);
        void DeleteRecord(int id);
        IList<DocumentData> GetRecordsByDocument(int documentId, string documentType);
        bool CheckIfDocumentRecordsExist(int documentId, string documentType);
        bool CheckIfRecordExist(int id);
        IList<DocumentData> GetDocumentData(IList<IncomingDocument>incomingDocuments);
        IList<DocumentData> GetOutgoingDocumentData(IList<OutgoingDocument> outgoingDocuments);

    }
}
