using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class ManufacturerReportsRepository : IManufacturerReportsRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public ManufacturerReportsRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public int CreateReport(string name, int manufacturerId, DateTime? dateRealizedFrom, DateTime? dateRealizedTo)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                ManufacturerReports report = new ManufacturerReports
                {
                    Name = name,
                    Manufacturer = context.Manufacturers.FirstOrDefault(x => x.Id == manufacturerId),
                    DateRealizedFrom = dateRealizedFrom,
                    DateRealizedTo = dateRealizedTo
                };
                context.ManufacturerReports.Add(report);
                context.SaveChanges();
                return report.Id;
            }

        }

        public void DeleteReport(int reportId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                context.ManufacturerReports.Remove(context.ManufacturerReports.Include(x => x.Manufacturer).FirstOrDefault(x => x.Id == reportId));
                context.SaveChanges();
            }

        }

        public void DeleteReportsByManufacturer(int manufacturerId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                context.ManufacturerReports.RemoveRange(context.ManufacturerReports.Include(x => x.Manufacturer).Where(x => x.Manufacturer.Id == manufacturerId));
                context.SaveChanges();
            }
        }

        public ManufacturerReports GetReport(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                ManufacturerReports report = context.ManufacturerReports.Include(x => x.Manufacturer).FirstOrDefault(x => x.Id == id);
                return report;
            }
        }

        public IEnumerable<ManufacturerReports> GetReports()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<ManufacturerReports> reports = context.ManufacturerReports.Include(x => x.Manufacturer).ToList();
                return reports;
            }
        }

        public IEnumerable<ManufacturerReports> SearchReports(List<string> criteria)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IQueryable<ManufacturerReports> reports = context.ManufacturerReports.Include(x => x.Manufacturer).AsQueryable();
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
                if (!string.IsNullOrEmpty(criteria[1]) && string.IsNullOrEmpty(criteria[2]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[1]);
                    reports = reports.Where(x => x.DateRealizedFrom >= earlierDate);
                }

                if (string.IsNullOrEmpty(criteria[1]) && !string.IsNullOrEmpty(criteria[2]))
                {
                    DateTime laterDate = Convert.ToDateTime(criteria[2]);
                    reports = reports.Where(x => x.DateRealizedTo <= laterDate);
                }

                if (!string.IsNullOrEmpty(criteria[1]) && !string.IsNullOrEmpty(criteria[2]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[1]);
                    DateTime laterDate = Convert.ToDateTime(criteria[2]);
                    reports = reports.Where(x => x.DateRealizedFrom >= earlierDate && x.DateRealizedTo <= laterDate);
                }

                IEnumerable<ManufacturerReports> reportList = reports.ToList();
                return reportList;
            }
        }
    }
}
