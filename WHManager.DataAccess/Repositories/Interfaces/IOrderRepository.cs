using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(int id, DateTime dateOrdered, ICollection<Item> items);
        Task UpdateOrderAsync(int id, DateTime dateOrdered, ICollection<Item> items, decimal price, Invoice involce = null);
        Task DeleteOrderAsync(int id);
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        Order GetOrderByInvoice(int invoiceId);
        Order GetOrderByClient(int? cliendId = null, string clientName = null, double? clientNip = null);
    }
}
