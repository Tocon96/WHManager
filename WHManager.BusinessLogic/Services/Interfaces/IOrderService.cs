using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(Order order, List<DeliveryOrderTableContent> elements);
        void UpdateOrder(Order order, List<DeliveryOrderTableContent> elements);
        void DeleteOrder(int id);
        IList<Order> GetAllOrders();
        Order GetOrderById(int id);
        Order GetOrderByInvoice(int invoiceId);
        decimal CalculateFinalPrice(Order order);
        IList<Order> SearchOrders(List<string> criteria);
        bool RealizeOrder(Order order);
        void EmptyOrderFromItems(Order order);
        public IList<DeliveryOrderTableContent> GetElements(int orderId);
        IList<Order> GetRealizedOrdersByClient(int clientId);
    }
}
