using System;
using System.Collections.Generic;
using System.Text;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IDeliveryRepository
    {
        public int AddDelivery(int providerId, DateTime date);
        public int UpdateDelivery(int id, int providerId, DateTime date, IList<int> items);
        public void DeleteDelivery(int id);
        public Delivery GetDelivery(int id);
        public IEnumerable<Delivery> GetAllDeliveries();
        public IEnumerable<Delivery> SearchDeliveries(IList<string> criteria);

    }
}
