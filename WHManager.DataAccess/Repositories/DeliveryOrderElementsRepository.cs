using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class DeliveryOrderElementsRepository : IDeliveryOrderElementsRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public DeliveryOrderElementsRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public int CreateElement(string origin, int productId, int productCount, int deliveryId)
        {
            using(WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    DeliveryOrderElements deliveryOrderElements = new DeliveryOrderElements
                    {
                        Origin = origin,
                        ProductId = productId,
                        ProductCount = productCount,
                        DeliveryId = deliveryId
                    };
                    context.DeliveryElements.Add(deliveryOrderElements);
                    context.SaveChanges();
                    return deliveryOrderElements.Id;
                }
                catch (Exception e) 
                {
                    throw new Exception("Błąd dodawania: " + e);
                }
            }
        }

        public void DeleteElement(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.DeliveryElements.Remove(context.DeliveryElements.SingleOrDefault(x=> x.Id == id));
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Błąd usuwania: " + e);
                }
            }

        }

        public void DeleteElementsByDeliveryId(string origin, int deliveryId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.DeliveryElements.Remove(context.DeliveryElements.SingleOrDefault(x => x.DeliveryId == deliveryId && x.Origin.StartsWith(origin)));
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Błąd usuwania: " + e);
                }
            }
        }

        public DeliveryOrderElements GetElement(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    DeliveryOrderElements element = context.DeliveryElements.SingleOrDefault(x => x.Id == id);
                    return element;
                }
                catch (Exception e)
                {
                    throw new Exception("Błąd pobierania: " + e);
                }
            }
        }

        public IEnumerable<DeliveryOrderElements> GetElementsByDeliveryId(string origin, int deliveryId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<DeliveryOrderElements> elements = context.DeliveryElements.ToList().FindAll(x => x.DeliveryId == deliveryId && x.Origin.StartsWith(origin));
                    return elements;
                }
                catch (Exception e)
                {
                    throw new Exception("Błąd pobierania: " + e);
                }
            }

        }

        public void UpdateElement(int id, string origin, int productId, int productCount, int? deliveryId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    DeliveryOrderElements element = context.DeliveryElements.SingleOrDefault(x => x.Id == id);
                    element.Origin = origin;
                    element.ProductId = productId;
                    element.ProductCount = productCount;
                    if(deliveryId != null)
                    {
                        element.DeliveryId = (int)deliveryId;
                    }
                    context.DeliveryElements.Update(element);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Błąd aktualizacji: " + e);
                }
            }

        }
    }
}
