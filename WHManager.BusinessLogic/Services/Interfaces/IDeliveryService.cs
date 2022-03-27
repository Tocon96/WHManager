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
        public IList<Item> GetAllItemsFromDeliveries(List<Delivery> deliveries);
        public IList<Delivery> GetRealizedDeliveriesByProvider(int contrahentId, DateTime? dateFrom, DateTime? dateTo);
        public IList<Delivery> GetDeliveriesByManufacturer(ManufacturerReports report);
        public IList<Delivery> GetDeliveriesByProductType(TypeReports report);
        public IList<Delivery> GetDeliveriesByProduct(ProductReports report);
    }
}
