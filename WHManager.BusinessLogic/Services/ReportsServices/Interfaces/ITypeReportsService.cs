using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.ReportsServices.Interfaces
{
    public interface ITypeReportsService
    {
        public int CreateReport(TypeReports productReport);
        public void DeleteReport(int reportId);
        public TypeReports GetReport(int id);
        public IList<TypeReports> GetReports();
        public IList<TypeReports> SearchReports(List<string> criteria);
        public IDictionary<string, decimal> ParseLists(IList<Delivery> deliveries, IList<Order> orders, IList<Product> products);
        public void DeleteReportsByType(int typeId);

    }
}
