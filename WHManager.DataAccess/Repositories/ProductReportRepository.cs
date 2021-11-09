using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class ProductReportRepository : IProductReportRepository
    {

        private readonly WHManagerDBContextFactory _contextFactory;

        public ProductReportRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public int CreateReport(string name, int? productId, int? manufacturerId, int? typeId, DateTime? dateFrom, DateTime? dateTo)
        {
            using(WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                ProductReports report = new ProductReports
                {
                    Name = name,
                    ProductId = productId,
                    ManufacturerId = manufacturerId,
                    TypeId = typeId,
                    DateFrom = dateFrom,
                    DateTo = dateTo
                };
                context.ProductReports.Add(report);
                context.SaveChanges();
                return report.Id;
            }
        }

        public void DeleteReport(int reportId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                context.ProductReports.Remove(context.ProductReports.FirstOrDefault(x => x.Id == reportId));
                context.SaveChanges();
            }
        }

        public ProductReports GetReport(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                ProductReports report = context.ProductReports.FirstOrDefault(x => x.Id == id);
                return report;
            }
        }

        public IEnumerable<ProductReports> GetReports()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<ProductReports> reports = context.ProductReports.ToList();
                return reports;
            }
            
        }

        public IEnumerable<ProductReports> SearchReports(List<string> criteria)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IQueryable<ProductReports> reports = context.ProductReports.AsQueryable();
                if (!string.IsNullOrEmpty(criteria[0]))
                {
                    if (int.TryParse(criteria[0], out int result))
                    {
                        reports = reports.Where(x => x.Id == result);
                    }
                    else
                    {
                        reports = reports.Where(x => x.Name.StartsWith(criteria[0]));
                    }
                }
                if (!string.IsNullOrEmpty(criteria[2]) && string.IsNullOrEmpty(criteria[3]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[2]);
                    reports = reports.Where(x => x.DateFrom >= earlierDate);
                }

                if (string.IsNullOrEmpty(criteria[2]) && !string.IsNullOrEmpty(criteria[3]))
                {
                    DateTime laterDate = Convert.ToDateTime(criteria[3]);
                    reports = reports.Where(x => x.DateTo <= laterDate);
                }

                if (!string.IsNullOrEmpty(criteria[2]) && !string.IsNullOrEmpty(criteria[3]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[2]);
                    DateTime laterDate = Convert.ToDateTime(criteria[3]);
                    reports = reports.Where(x => x.DateFrom >= earlierDate && x.DateTo <= laterDate);
                }

                IEnumerable<ProductReports> reportList = reports.ToList();
                return reportList;
            }
        }
    }
}
