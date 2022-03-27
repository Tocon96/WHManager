using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class TypeReportsRepository : ITypeReportsRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public TypeReportsRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public int CreateReport(string name, int typeId, DateTime? dateRealizedFrom, DateTime? dateRealizedTo)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                TypeReports report = new TypeReports
                {
                    Name = name,
                    Type = context.ProductTypes.FirstOrDefault(x => x.Id == typeId),
                    DateRealizedFrom = dateRealizedFrom,
                    DateRealizedTo = dateRealizedTo
                };
                context.TypeReports.Add(report);
                context.SaveChanges();
                return report.Id;
            }

        }

        public void DeleteReport(int reportId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                context.TypeReports.Remove(context.TypeReports.Include(x => x.Type).FirstOrDefault(x => x.Id == reportId));
                context.SaveChanges();
            }

        }

        public void DeleteReportsByType(int typeId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                context.TypeReports.RemoveRange(context.TypeReports.Include(x => x.Type).Where(x => x.Type.Id == typeId));
                context.SaveChanges();
            }
        }

        public TypeReports GetReport(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                TypeReports report = context.TypeReports.Include(x => x.Type).FirstOrDefault(x => x.Id == id);
                return report;
            }

        }

        public IEnumerable<TypeReports> GetReports()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<TypeReports> reports = context.TypeReports.Include(x => x.Type).ToList();
                return reports;
            }
        }

        public IEnumerable<TypeReports> SearchReports(List<string> criteria)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IQueryable<TypeReports> reports = context.TypeReports.Include(x => x.Type).AsQueryable();
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

                IEnumerable<TypeReports> reportList = reports.ToList();
                return reportList;
            }
        }
    }
}
