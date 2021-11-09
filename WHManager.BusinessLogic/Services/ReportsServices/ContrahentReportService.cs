using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.ReportsServices.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services.ReportsServices
{
    public class ContrahentReportService : IContrahentReportsService
    {
        IContrahentReportRepository reportRepository = new ContrahentReportRepository(new DataAccess.WHManagerDBContextFactory());
        public int CreateReport(ContrahentReports report)
        {
            return reportRepository.CreateReport(report.ReportOrigin, report.ContrahentId, report.DateFrom, report.DateTo);
        }

        public void DeleteReport(int reportId)
        {
            reportRepository.DeleteReport(reportId);
        }

        public IList<ContrahentReports> GetClientReports()
        {
            var clientReports = reportRepository.GetClientReports();
            IList<ContrahentReports> reports = new List<ContrahentReports>();
            foreach (var report in clientReports)
            {
                ContrahentReports newReport = new ContrahentReports
                {
                    Id = report.Id,
                    ContrahentId = report.ContrahentId,
                    DateFrom = report.DateFrom,
                    DateTo = report.DateTo,
                    ReportOrigin = report.ReportOrigin
                };
                reports.Add(newReport);
            }
            return reports;
        }

        public IList<ContrahentReports> GetProviderReports()
        {
            var clientReports = reportRepository.GetProviderReports();
            IList<ContrahentReports> reports = new List<ContrahentReports>();
            foreach (var report in clientReports)
            {
                ContrahentReports newReport = new ContrahentReports
                {
                    Id = report.Id,
                    ContrahentId = report.ContrahentId,
                    DateFrom = report.DateFrom,
                    DateTo = report.DateTo,
                    ReportOrigin = report.ReportOrigin
                };
                reports.Add(newReport);
            }
            return reports;
        }

        public ContrahentReports GetReport(int id)
        {
            var clientReport = reportRepository.GetReport(id);
            ContrahentReports newReport = new ContrahentReports
            {
                Id = clientReport.Id,
                ContrahentId = clientReport.ContrahentId,
                DateFrom = clientReport.DateFrom,
                DateTo = clientReport.DateTo,
                ReportOrigin = clientReport.ReportOrigin
            };
            return newReport;
        }

        public IList<ContrahentReports> SearchReports(List<string> criteria)
        {
            var clientReports = reportRepository.SearchReports(criteria);
            IList<ContrahentReports> reports = new List<ContrahentReports>();
            foreach (var report in clientReports)
            {
                ContrahentReports newReport = new ContrahentReports
                {
                    Id = report.Id,
                    ContrahentId = report.ContrahentId,
                    DateFrom = report.DateFrom,
                    DateTo = report.DateTo,
                    ReportOrigin = report.ReportOrigin
                };
                reports.Add(newReport);
            }
            return reports;

        }
    }
}
