using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.BusinessLogic.Services.ReportsServices.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services.ReportsServices
{
    public class TypeReportsService : ITypeReportsService
    {
        ITypeReportsRepository reportRepository = new TypeReportsRepository(new DataAccess.WHManagerDBContextFactory());
        IProductTypeService typeService = new ProductTypeService();
        public int CreateReport(TypeReports productReport)
        {
            return reportRepository.CreateReport(productReport.Name,
                                     productReport.Type.Id,
                                     productReport.DateRealizedFrom,
                                     productReport.DateRealizedTo);

        }

        public void DeleteReport(int reportId)
        {
            reportRepository.DeleteReport(reportId);
        }

        public void DeleteReportsByType(int typeId)
        {
            reportRepository.DeleteReportsByType(typeId);
        }

        public TypeReports GetReport(int id)
        {
            var report = reportRepository.GetReport(id);
            TypeReports newReport = new TypeReports
            {
                Id = report.Id,
                Name = report.Name,
                Type = typeService.GetProductType(report.Type.Id),
                DateRealizedFrom = report.DateRealizedFrom,
                DateRealizedTo = report.DateRealizedTo
            };
            return newReport;

        }

        public IList<TypeReports> GetReports()
        {
            var productReports = reportRepository.GetReports();
            IList<TypeReports> reports = new List<TypeReports>();
            foreach (var report in productReports)
            {
                TypeReports newReport = new TypeReports
                {
                    Id = report.Id,
                    Name = report.Name,
                    Type = typeService.GetProductType(report.Type.Id),
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


        public IList<TypeReports> SearchReports(List<string> criteria)
        {
            var productReports = reportRepository.SearchReports(criteria);
            IList<TypeReports> reports = new List<TypeReports>();
            foreach (var report in productReports)
            {
                TypeReports newReport = new TypeReports
                {
                    Id = report.Id,
                    Name = report.Name,
                    Type = typeService.GetProductType(report.Type.Id),
                    DateRealizedFrom = report.DateRealizedFrom,
                    DateRealizedTo = report.DateRealizedTo
                };
                reports.Add(newReport);
            }
            return reports;


        }
    }
}
