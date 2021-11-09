using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.ReportsServices.Interfaces
{
    public interface IProductReportsService
    {
        public int CreateReport(ProductReports productReport);
        public void DeleteReport(int reportId);
        public ProductReports GetReport(int id);
        public IList<ProductReports> GetReports();
        public IList<ProductReports> SearchReports(List<string> criteria);

    }
}
