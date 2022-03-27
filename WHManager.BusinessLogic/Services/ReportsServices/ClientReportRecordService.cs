using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.ReportsServices.Interfaces;

namespace WHManager.BusinessLogic.Services.ReportsServices
{
    public class ClientReportRecordService : IClientReportRecordService
    {
        public IList<ClientReportRecord> CreateRecords(IList<DocumentData> documentData, IList<OutgoingDocument> documents)
        {
            IList<ClientReportRecord> records = new List<ClientReportRecord>();
            foreach(OutgoingDocument document in documents)
            {
                ClientReportRecord record = new ClientReportRecord
                {
                    OrderId = document.OrderId,
                    ItemCount = documentData.Where(x => x.DocumentId == document.Id).Sum(x => x.ProductCount),
                    PriceNet = documentData.Where(x => x.DocumentId == document.Id).Sum(x => x.NetValue),
                    PriceGross = documentData.Where(x => x.DocumentId == document.Id).Sum(x => x.GrossValue),
                    DateRealized = document.DateSent
                };
                records.Add(record);
            }
            return records;
        }
    }
}
