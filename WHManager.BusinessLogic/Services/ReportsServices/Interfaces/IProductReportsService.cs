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
        public IDictionary<string, decimal> ParseLists(IList<Delivery> deliveries, IList<Order> orders, IList<Product> products);
        public IDictionary<string, decimal> ParseListsForProductReports(IList<Delivery> deliveries, IList<Order> orders, IList<Item> items);
        public void DeleteReportsByProduct(int productId);
    }
}
