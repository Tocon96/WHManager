using System;
using System.Collections.Generic;
using System.Text;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IManufacturerReportsRepository
    {
        public int CreateReport(string name, int manufacturerId, DateTime? dateRealizedFrom, DateTime? dateRealizedTo);
        public void DeleteReport(int reportId);
        public ManufacturerReports GetReport(int id);
        public IEnumerable<ManufacturerReports> GetReports();
        public IEnumerable<ManufacturerReports> SearchReports(List<string> criteria);
        public void DeleteReportsByManufacturer(int manufacturerId);
    }
}
