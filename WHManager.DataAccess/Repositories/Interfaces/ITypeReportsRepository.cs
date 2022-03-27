using System;
using System.Collections.Generic;
using System.Text;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface ITypeReportsRepository
    {
        public int CreateReport(string name, int typeId, DateTime? dateRealizedFrom, DateTime? dateRealizedTo);
        public void DeleteReport(int reportId);
        public TypeReports GetReport(int id);
        public IEnumerable<TypeReports> GetReports();
        public IEnumerable<TypeReports> SearchReports(List<string> criteria);
        public void DeleteReportsByType(int typeId);
    }
}
