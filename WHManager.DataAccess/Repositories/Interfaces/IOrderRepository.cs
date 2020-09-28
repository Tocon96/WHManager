using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(int id, decimal price, DateTime dateOrdered, IList<int> items, int clientId);
        Task UpdateOrderAsync(int id, DateTime dateOrdered, IList<int> items, decimal price, int clientId, int? invoiceId = null);
        Task DeleteOrderAsync(int id);
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        Order GetOrderByInvoice(int invoiceId);
        IEnumerable<Order> GetOrdersByClient(int? clientId = null, string clientName = null, double? clientNip = null);
        IEnumerable<Order> GetInvoicesByDate(DateTime? earlierDate, DateTime? laterDate);
    }
}