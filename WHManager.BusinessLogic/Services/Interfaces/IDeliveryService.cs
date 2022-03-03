using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IDeliveryService
    {
        public int AddDelivery(Delivery delivery, List<DeliveryOrderTableContent> elements);
        public int UpdateDelivery(Delivery delivery, List<DeliveryOrderTableContent> elements);
        public void DeleteDelivery(int id);
        public Delivery GetDelivery(int id);
        public IList<Delivery> GetDeliveries();
        public IList<Delivery> SearchDeliveries(IList<string> criteria);
        public void RealizeDelivery(Delivery delivery);
        public IList<DeliveryOrderTableContent> GetElements(int deliveryId);
        public IList<Delivery> GetRealizedDeliveriesByProvider(int contrahentId);
    }
}
