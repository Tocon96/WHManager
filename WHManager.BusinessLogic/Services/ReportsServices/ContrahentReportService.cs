using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.DocumentServices;
using WHManager.BusinessLogic.Services.DocumentServices.Interfaces;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.BusinessLogic.Services.ReportsServices.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services.ReportsServices
{
    public class ContrahentReportService : IContrahentReportsService
    {
        IContrahentReportRepository reportRepository = new ContrahentReportRepository(new DataAccess.WHManagerDBContextFactory());
        IOrderService orderService = new OrderService();
        IClientService clientService = new ClientService();
        IProviderService providerService = new ProviderService();
        public int CreateReport(ContrahentReports report)
        {
            return reportRepository.CreateReport(report.ReportOrigin, report.ContrahentId, report.ContrahentName, report.DateFrom, report.DateTo);
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
                Client client = clientService.GetClient(report.ContrahentId)[0];
                ContrahentReports newReport = new ContrahentReports
                {
                    Id = report.Id,
                    ContrahentId = report.ContrahentId,
                    ContrahentName = client.Name,
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
                Provider provider = providerService.GetProvider(report.ContrahentId);
                ContrahentReports newReport = new ContrahentReports
                {
                    Id = report.Id,
                    ContrahentId = report.ContrahentId,
                    ContrahentName = provider.Name,
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
                ContrahentName = clientReport.ContrahentName,
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
                    ContrahentName = report.ContrahentName,
                    DateFrom = report.DateFrom,
                    DateTo = report.DateTo,
                    ReportOrigin = report.ReportOrigin
                };

                reports.Add(newReport);
            }
            return reports;

        }

        public IDictionary<string, decimal> ParseDeliveryList(List<ProviderReportRecord> records)
        {
            IDictionary<string, decimal> providerDeliveryDetails = new Dictionary<string, decimal>();

            providerDeliveryDetails["elementCount"] = records.Count();
            providerDeliveryDetails["itemCount"] = records.Sum(x => x.ItemCount);
            providerDeliveryDetails["totalValueNet"] = records.Sum(x => x.PriceNet);
            providerDeliveryDetails["totalValueGross"] = records.Sum(x => x.PriceGross);

            return providerDeliveryDetails;
        }

        public IDictionary<string, decimal> ParseOrderList(List<ClientReportRecord> records)
        {
            IDictionary<string, decimal> clientOrderDetails = new Dictionary<string, decimal>();

            clientOrderDetails["elementCount"] = records.Count();
            clientOrderDetails["itemCount"] = records.Sum(x => x.ItemCount);
            clientOrderDetails["totalValueNet"] = records.Sum(x => x.PriceNet);
            clientOrderDetails["totalValueGross"] = records.Sum(x => x.PriceGross);

            return clientOrderDetails;
        }
    }
}
