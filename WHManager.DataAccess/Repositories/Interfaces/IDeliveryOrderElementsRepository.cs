using System;
using System.Collections.Generic;
using System.Text;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IDeliveryOrderElementsRepository
    {
        public int CreateElement(string origin, int productId, int productCount, int deliveryId);
        public void UpdateElement(int id, string origin, int productId, int productCount, int? deliveryId);
        public void DeleteElement(int id);
        public void DeleteElementsByDeliveryId(string origin, int deliveryId);
        public DeliveryOrderElements GetElement(int id);
        public IEnumerable<DeliveryOrderElements> GetElementsByDeliveryId(string origin, int deliveryId);
    }
}
