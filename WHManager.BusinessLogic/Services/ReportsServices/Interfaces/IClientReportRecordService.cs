using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.ReportsServices.Interfaces
{
    public interface IClientReportRecordService
    {
        public IList<ClientReportRecord> CreateRecords(IList<DocumentData> documentData, IList<OutgoingDocument> documents);
    }
}
