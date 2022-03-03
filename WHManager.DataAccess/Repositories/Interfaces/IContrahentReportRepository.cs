using System;
using System.Collections.Generic;
using System.Text;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IContrahentReportRepository
    {
        public int CreateReport(string reportOrigin, int contrahentId, string contrahentName, DateTime? dateFrom, DateTime? dateTo);
        public void DeleteReport(int reportId);
        public ContrahentReports GetReport(int id);
        public IEnumerable<ContrahentReports> GetClientReports();
        public IEnumerable<ContrahentReports> GetProviderReports();
        public IEnumerable<ContrahentReports> SearchReports(List<string>criteria);
    }
}
