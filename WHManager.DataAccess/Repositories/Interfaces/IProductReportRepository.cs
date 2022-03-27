using System;
using System.Collections.Generic;
using System.Text;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IProductReportRepository
    {
        public int CreateReport(string name, int productId,  DateTime? dateRealizedFrom, DateTime? dateRealizedTo);
        public void DeleteReport(int reportId);
        public ProductReports GetReport(int id);
        public IEnumerable<ProductReports> GetReports();
        public IEnumerable<ProductReports> SearchReports(List<string> criteria);
        public void DeleteReportsByProduct(int productId);
    }
}
