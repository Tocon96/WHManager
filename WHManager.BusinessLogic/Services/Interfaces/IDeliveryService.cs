using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IDeliveryService
    {
        public int AddDelivery(Delivery delivery);
        public int UpdateDelivery(Delivery delivery);
        public void DeleteDelivery(int id);
        public Delivery GetDelivery(int id);
        public IList<Delivery> GetDeliveries();
        public IList<Delivery> SearchDeliveries(IList<string> criteria);
    }
}
