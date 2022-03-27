using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.ReportsServices.Interfaces
{
    public interface IProviderReportRecordService
    {
        public IList<ProviderReportRecord> CreateRecords(IList<DocumentData> documentData, IList<IncomingDocument> documents);
    }
}
