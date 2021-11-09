using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.ReportsServices.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services.ReportsServices
{
    public class ProductReportsService : IProductReportsService
    {
        IProductReportRepository reportRepository = new ProductReportRepository(new DataAccess.WHManagerDBContextFactory());
        public int CreateReport(ProductReports productReport)
        {
            return reportRepository.CreateReport(productReport.Name, productReport.ProductId, productReport.ManufacturerId, productReport.TypeId, productReport.DateFrom, productReport.DateTo);
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
                ProductId = report.ProductId,
                ManufacturerId = report.ManufacturerId,
                TypeId = report.TypeId,
                DateFrom = report.DateFrom,
                DateTo = report.DateTo
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
                    ProductId = report.ProductId,
                    ManufacturerId = report.ManufacturerId,
                    TypeId = report.TypeId,
                    DateFrom = report.DateFrom,
                    DateTo = report.DateTo
                };
                reports.Add(newReport);
            }
            return reports;
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
                    ProductId = report.ProductId,
                    ManufacturerId = report.ManufacturerId,
                    TypeId = report.TypeId,
                    DateFrom = report.DateFrom,
                    DateTo = report.DateTo
                };
                reports.Add(newReport);
            }
            return reports;

        }
    }
}
