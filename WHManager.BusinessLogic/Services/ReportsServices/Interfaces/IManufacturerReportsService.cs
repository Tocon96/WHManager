using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.ReportsServices.Interfaces
{
    public interface IManufacturerReportsService
    {
        public int CreateReport(ManufacturerReports productReport);
        public void DeleteReport(int reportId);
        public ManufacturerReports GetReport(int id);
        public IList<ManufacturerReports> GetReports();
        public IList<ManufacturerReports> SearchReports(List<string> criteria);
        public IDictionary<string, decimal> ParseLists(IList<Delivery> deliveries, IList<Order> orders, IList<Product> products);
        public void DeleteReportsByManufacturer(int manufacturerId);
    }
}
