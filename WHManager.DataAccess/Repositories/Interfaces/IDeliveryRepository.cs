﻿using System;
using System.Collections.Generic;
using System.Text;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IDeliveryRepository
    {
        public int AddDelivery(int providerId, DateTime date);
        public int UpdateDelivery(int id, int providerId, DateTime dateCreated, DateTime? dateRealized, bool realized);
        public void DeleteDelivery(int id);
        public Delivery GetDelivery(int id);
        public IEnumerable<Delivery> GetAllDeliveries();
        public IEnumerable<Delivery> SearchDeliveries(IList<string> criteria);
        public IEnumerable<Delivery> GetDeliveriesByClient(int providerId);
        public IEnumerable<Delivery> GetRealizedDeliveriesByProviderWithinDateRanges(int contrahentId, DateTime? dateFrom, DateTime? dateTo);
        public IEnumerable<Delivery> GetDeliveriesByManufacturer(int manufacturerId, DateTime? datefrom, DateTime? dateTo);
        public IEnumerable<Delivery> GetDeliveriesByProductType(int productTypeId, DateTime? datefrom, DateTime? dateTo);
        public IEnumerable<Delivery> GetDeliveriesByProduct(int productId, DateTime? datefrom, DateTime? dateTo);

    }
}
