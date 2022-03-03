using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class ContrahentReportRepository : IContrahentReportRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public ContrahentReportRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public int CreateReport(string reportOrigin, int contrahentId, string contrahentName, DateTime? dateFrom, DateTime? dateTo)
        {
            using(WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                ContrahentReports report = new ContrahentReports
                {
                    ReportOrigin = reportOrigin,
                    ContrahentId = contrahentId,
                    ContrahentName = contrahentName,
                    DateFrom = dateFrom,
                    DateTo = dateTo
                };
                context.ContrahentReports.Add(report);
                context.SaveChanges();
                return report.Id;
            }
        }

        public void DeleteReport(int reportId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                context.ContrahentReports.Remove(context.ContrahentReports.FirstOrDefault(x=>x.Id == reportId));
                context.SaveChanges();
            }
        }

        public IEnumerable<ContrahentReports> GetClientReports()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<ContrahentReports> reports = context.ContrahentReports.ToList().FindAll(x=>x.ReportOrigin.StartsWith("Clients"));
                return reports;
            }
        }

        public IEnumerable<ContrahentReports> GetProviderReports()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<ContrahentReports> reports = context.ContrahentReports.ToList().FindAll(x => x.ReportOrigin.StartsWith("Providers"));
                return reports;
            }
        }

        public ContrahentReports GetReport(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                ContrahentReports report = context.ContrahentReports.FirstOrDefault(x => x.Id == id);
                return report;
            }
            
        }

        public IEnumerable<ContrahentReports> SearchReports(List<string> criteria)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IQueryable<ContrahentReports> reports = context.ContrahentReports.AsQueryable();
                if (!string.IsNullOrEmpty(criteria[0]))
                {
                    reports = reports.Where(x => x.Id == int.Parse(criteria[0]));
                }
                if (!string.IsNullOrEmpty(criteria[1]))
                {
                    reports = reports.Where(x => x.ContrahentName.StartsWith(criteria[1]));
                }
                reports = reports.Where(x => x.ReportOrigin.StartsWith(criteria[2]));
                if (!string.IsNullOrEmpty(criteria[3]) && string.IsNullOrEmpty(criteria[4]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[3]);
                    reports = reports.Where(x => x.DateFrom >= earlierDate);
                }

                if (string.IsNullOrEmpty(criteria[3]) && !string.IsNullOrEmpty(criteria[4]))
                {
                    DateTime laterDate = Convert.ToDateTime(criteria[4]);
                    reports = reports.Where(x => x.DateTo <= laterDate);
                }

                if (!string.IsNullOrEmpty(criteria[3]) && !string.IsNullOrEmpty(criteria[4]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[3]);
                    DateTime laterDate = Convert.ToDateTime(criteria[4]);
                    reports = reports.Where(x => x.DateFrom >= earlierDate && x.DateTo <= laterDate);
                }

                IEnumerable<ContrahentReports> reportList = reports.ToList();
                return reportList;

            }
        }
    }
}
