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

        private decimal CalculateTotalPrice(Order order = null, Delivery delivery = null)
        {
            IList<decimal> priceList = new List<decimal>();
            if (order != null)
            {
                foreach (Item item in order.Items)
                {
                    priceList.Add(item.Product.PriceSell);
                }
                return priceList.Sum();
            }
            else
            {
                foreach (Item item in delivery.Items)
                {
                    priceList.Add(item.Product.PriceBuy);
                }
                return priceList.Sum();
            }
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

        public IDictionary<string, double> ParseDeliveryList(List<Delivery> deliveries)
        {
            IDictionary<string, double> providerDeliveryDetails = new Dictionary<string, double>();

            providerDeliveryDetails["elementCount"] = deliveries.Count();
            providerDeliveryDetails["itemCount"] = 0;
            providerDeliveryDetails["totalValue"] = 0;

            foreach(Delivery delivery in deliveries)
            {
                if(delivery.Realized == true)
                {
                    providerDeliveryDetails["itemCount"] += delivery.Items.Count;
                    foreach (Item item in delivery.Items)
                    {
                        providerDeliveryDetails["totalValue"] += (double)item.Product.PriceBuy;
                    }
                }
            }

            return providerDeliveryDetails;
        }

        public IDictionary<string, double> ParseOrderList(List<Order> orders)
        {
            IDictionary<string, double> clientOrdersDetails = new Dictionary<string, double>();

            clientOrdersDetails["elementCount"] = orders.Count();
            clientOrdersDetails["itemCount"] = 0;
            clientOrdersDetails["totalValue"] = 0;

            foreach (Order order in orders)
            {
                if(order.IsRealized == true)
                {
                    clientOrdersDetails["itemCount"] += order.Items.Count;
                    foreach (Item item in order.Items)
                    {
                        clientOrdersDetails["totalValue"] += (double)item.Product.PriceBuy;
                    }
                }
            }

            return clientOrdersDetails;

        }
    }
}
