using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.ReportsServices.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services.ReportsServices
{
    public class ManufacturerReportsService : IManufacturerReportsService
    {
        IManufacturerReportsRepository reportRepository = new ManufacturerReportsRepository(new DataAccess.WHManagerDBContextFactory());
        IManufacturerService manufacturerService = new ManufacturerService();
        public int CreateReport(ManufacturerReports productReport)
        {
            return reportRepository.CreateReport(productReport.Name,
                                     productReport.Manufacturer.Id,
                                     productReport.DateRealizedFrom,
                                     productReport.DateRealizedTo);

        }

        public void DeleteReport(int reportId)
        {
            reportRepository.DeleteReport(reportId);
        }

        public void DeleteReportsByManufacturer(int manufacturerId)
        {
            reportRepository.DeleteReportsByManufacturer(manufacturerId);
        }

        public ManufacturerReports GetReport(int id)
        {
            var report = reportRepository.GetReport(id);
            ManufacturerReports newReport = new ManufacturerReports
            {
                Id = report.Id,
                Name = report.Name,
                Manufacturer = manufacturerService.GetManufacturer(report.Manufacturer.Id),
                DateRealizedFrom = report.DateRealizedFrom,
                DateRealizedTo = report.DateRealizedTo
            };
            return newReport;

        }

        public IList<ManufacturerReports> GetReports()
        {
            var productReports = reportRepository.GetReports();
            IList<ManufacturerReports> reports = new List<ManufacturerReports>();
            foreach (var report in productReports)
            {
                ManufacturerReports newReport = new ManufacturerReports
                {
                    Id = report.Id,
                    Name = report.Name,
                    Manufacturer = manufacturerService.GetManufacturer(report.Manufacturer.Id),
                    DateRealizedFrom = report.DateRealizedFrom,
                    DateRealizedTo = report.DateRealizedTo
                };
                reports.Add(newReport);
            }
            return reports;

        }

        public IDictionary<string, decimal> ParseLists(IList<Delivery> deliveries, IList<Order> orders, IList<Product> products)
        {
            IDictionary<string, decimal> parsedList = new Dictionary<string, decimal>();
            parsedList["itemCount"] = products.Count;
            parsedList["orderElementCount"] = orders.Count;
            parsedList["deliveryElementCount"] = deliveries.Count;
            parsedList["totalValue"] = CalculateTotalPrice(deliveries, orders);
            return parsedList;

        }

        private decimal CalculateTotalPrice(IList<Delivery> deliveries, IList<Order> orders)
        {
            decimal result = orders.Sum(x => x.Price) - deliveries.Sum(x => x.TotalPrice);
            return result;
        }


        public IList<ManufacturerReports> SearchReports(List<string> criteria)
        {
            var productReports = reportRepository.SearchReports(criteria);
            IList<ManufacturerReports> reports = new List<ManufacturerReports>();
            foreach (var report in productReports)
            {
                ManufacturerReports newReport = new ManufacturerReports
                {
                    Id = report.Id,
                    Name = report.Name,
                    Manufacturer = manufacturerService.GetManufacturer(report.Manufacturer.Id),
                    DateRealizedFrom = report.DateRealizedFrom,
                    DateRealizedTo = report.DateRealizedTo
                };
                reports.Add(newReport);
            }
            return reports;


        }
    }
}
