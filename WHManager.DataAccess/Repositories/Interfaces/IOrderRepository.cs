using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        int AddOrder(decimal price, DateTime dateOrdered, int clientId);
        void UpdateOrder(int id, DateTime dateOrdered, decimal price, int clientId, int? invoiceId = null);
        void DeleteOrder(int id);
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        Order GetOrderByInvoice(int invoiceId);
        IEnumerable<Order> GetOrdersByClient(int clientId);
        IEnumerable<Order> SearchOrders(List<string> criteria);
        void RealizeOrder(int orderId, DateTime dateRealized);
        IEnumerable<Order> GetRealizedOrdersByClientWithinDateRanges(int clientId, DateTime? dateFrom, DateTime? dateTo);
        IEnumerable<Order> GetOrdersByManufacturer(int manufacturerId, DateTime? dateRealizedFrom, DateTime? dateRealizedTo);
        IEnumerable<Order> GetOrdersByProductType(int typeId, DateTime? dateRealizedFrom, DateTime? dateRealizedTo);
        IEnumerable<Order> GetOrdersByProduct(int productId, DateTime? dateRealizedFrom, DateTime? dateRealizedTo);
    }
}