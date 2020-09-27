using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public OrderRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Task<Order> AddOrderAsync(int id, DateTime dateOrdered, ICollection<Item> items)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderAsync(int id, DateTime dateOrdered, ICollection<Item> items, decimal price, Invoice involce = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByClient(int? cliendId = null, string clientName = null, double? clientNip = null)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByInvoice(int invoiceId)
        {
            throw new NotImplementedException();
        }
    }
}
