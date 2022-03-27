using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.ReportsServices.Interfaces;

namespace WHManager.BusinessLogic.Services.ReportsServices
{
    public class ProviderReportRecordService : IProviderReportRecordService
    {
        public IList<ProviderReportRecord> CreateRecords(IList<DocumentData> documentData, IList<IncomingDocument> documents)
        {
            IList<ProviderReportRecord> records = new List<ProviderReportRecord>();
            foreach(IncomingDocument document in documents)
            {
                ProviderReportRecord record = new ProviderReportRecord
                {
                    DeliveryId = document.DeliveryId,
                    ItemCount = documentData.Where(x => x.DocumentId == document.Id).Sum(x => x.ProductCount),
                    PriceNet = documentData.Where(x => x.DocumentId == document.Id).Sum(x => x.NetValue),
                    PriceGross = documentData.Where(x => x.DocumentId == document.Id).Sum(x => x.GrossValue),
                    DateRealized = document.DateReceived
                };
                records.Add(record);
            }
            return records;
        }
    }
}
