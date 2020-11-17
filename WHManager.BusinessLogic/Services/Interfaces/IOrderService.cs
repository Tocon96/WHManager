using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IOrderService
    {
        Task AddOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int id);
        IList<Order> GetAllOrders();
        Order GetOrderById(int id);
        Order GetOrderByInvoice(int invoiceId);
        IList<Order> GetOrdersByClient(int? clientId = null, string clientName = null, double? clientNip = null);
        IList<Order> GetOrdersByDate(DateTime? earlierDate, DateTime? laterDate);
        decimal CalculateFinalPrice(Order order);
        IList<Product> GetSortedProducts(Order order);
    }
}
