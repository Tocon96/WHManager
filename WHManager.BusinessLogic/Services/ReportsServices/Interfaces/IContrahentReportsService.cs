using LiveCharts;
using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.ReportsServices.Interfaces
{
    public interface IContrahentReportsService
    {
        public int CreateReport(ContrahentReports report);
        public void DeleteReport(int reportId);
        public ContrahentReports GetReport(int id);
        public IList<ContrahentReports> GetClientReports();
        public IList<ContrahentReports> GetProviderReports();
        public IDictionary<string, decimal> ParseDeliveryList(List<ProviderReportRecord> records);
        public IDictionary<string, decimal> ParseOrderList(List<ClientReportRecord> records);
        public IList<ContrahentReports> SearchReports(List<string> criteria);
    }
}
