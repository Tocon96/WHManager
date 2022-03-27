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
    public class ProductReportsService : IProductReportsService
    {
        IProductReportRepository reportRepository = new ProductReportRepository(new DataAccess.WHManagerDBContextFactory());
        IProductService productService = new ProductService();

        public int CreateReport(ProductReports productReport)
        {
            return reportRepository.CreateReport(productReport.Name,
                                                 productReport.Product.Id, 
                                                 productReport.DateRealizedFrom, 
                                                 productReport.DateRealizedTo);
        }

        public void DeleteReport(int reportId)
        {
            reportRepository.DeleteReport(reportId);
        }

        public ProductReports GetReport(int id)
        {
            var report = reportRepository.GetReport(id);
            ProductReports newReport = new ProductReports
            {
                Id = report.Id,
                Name = report.Name,
                Product = productService.GetProduct(report.Product.Id)[0],
                DateRealizedFrom = report.DateRealizedFrom,
                DateRealizedTo = report.DateRealizedTo
            };
            return newReport;

        }

        public IList<ProductReports> GetReports()
        {
            var productReports = reportRepository.GetReports();
            IList<ProductReports> reports = new List<ProductReports>();
            foreach (var report in productReports)
            {
                ProductReports newReport = new ProductReports
                {
                    Id = report.Id,
                    Name = report.Name,
                    Product = productService.GetProduct(report.Product.Id)[0],
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

        public IList<ProductReports> SearchReports(List<string> criteria)
        {
            var productReports = reportRepository.SearchReports(criteria);
            IList<ProductReports> reports = new List<ProductReports>();
            foreach (var report in productReports)
            {
                ProductReports newReport = new ProductReports
                {
                    Id = report.Id,
                    Name = report.Name,
                    Product = productService.GetProduct(report.Product.Id)[0],
                    DateRealizedFrom = report.DateRealizedFrom,
                    DateRealizedTo = report.DateRealizedTo
                };
                reports.Add(newReport);
            }
            return reports;

        }

        public void DeleteReportsByProduct(int productId)
        {
            reportRepository.DeleteReportsByProduct(productId);
        }

        public IDictionary<string, decimal> ParseListsForProductReports(IList<Delivery> deliveries, IList<Order> orders, IList<Item> items)
        {
            IDictionary<string, decimal> parsedList = new Dictionary<string, decimal>();
            parsedList["itemCount"] = items.Count;
            parsedList["orderElementCount"] = orders.Count;
            parsedList["deliveryElementCount"] = deliveries.Count;
            parsedList["totalValue"] = CalculateTotalPrice(deliveries, orders);
            return parsedList;

        }
    }
}
