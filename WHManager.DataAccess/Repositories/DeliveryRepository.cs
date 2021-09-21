using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public DeliveryRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public int AddDelivery(int providerId, DateTime date, IList<int> items)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                ICollection<Item> itemCollection = new ObservableCollection<Item>();
                foreach(int id in items)
                {
                    try
                    {
                        Item item = context.Items.SingleOrDefault(x => x.Id == id);
                        itemCollection.Add(item);
                    }
                    catch
                    {
                        throw new Exception("Błąd wyszukiwania przedmiotów w dostawach.");
                    }
                }
                Delivery delivery = new Delivery
                {
                    Provider = context.Provider.SingleOrDefault(x => x.Id == providerId),
                    DateOfArrival = date,
                    Items = itemCollection
                };
                try
                {
                    context.Deliveries.Add(delivery);
                    context.SaveChanges();
                    return delivery.Id;
                }
                catch
                {
                    throw new Exception("Błąd dodawania");
                }
            }
        }

        public void DeleteDelivery(int id)
        {
            using(WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.Deliveries.Remove(context.Deliveries.SingleOrDefault(x => x.Id == id));
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd usuwania");
                }
            }
        }

        public IEnumerable<Delivery> GetAllDeliveries()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.Include(x => x.Provider)
                                                                         .Include(x => x.Items)                                              
                                                                         .ToList();
                    return deliveries;
                }
                catch (Exception)
                {
                    throw new Exception("Błąd pobierania dostaw");
                }
            }

        }

        public Delivery GetDelivery(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Delivery delivery = context.Deliveries.Include(x => x.Provider)
                                                          .Include(x => x.Items)
                                                          .SingleOrDefault(x => x.Id == id);
                                                                         
                    return delivery;
                }
                catch (Exception)
                {
                    throw new Exception("Błąd pobierania dostaw");
                }

            }

        }

        public IEnumerable<Delivery> SearchDeliveries(IList<string> criteria)
        {
            throw new NotImplementedException();
        }

        public int UpdateDelivery(int id, int providerId, DateTime date, IList<int> items)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                Delivery delivery = context.Deliveries.Include(x => x.Provider)
                                                        .Include(x => x.Items)
                                                        .SingleOrDefault(x => x.Id == id);
                ICollection<Item> itemCollection = new ObservableCollection<Item>();
                foreach (int i in items)
                {
                    try
                    {
                        Item item = context.Items.SingleOrDefault(x => x.Id == i);
                        itemCollection.Add(item);
                    }
                    catch
                    {
                        throw new Exception("Błąd wyszukiwania przedmiotów w dostawach.");
                    }
                }

                try
                {
                    delivery.Provider = context.Provider.SingleOrDefault(x => x.Id == providerId);
                    delivery.DateOfArrival = date;
                    delivery.Items = itemCollection;
                    context.Deliveries.Update(delivery);
                    context.SaveChanges();
                    return delivery.Id;
                }
                catch (Exception)
                {
                    throw new Exception("Błąd pobierania dostaw");
                }
            }
                
        }
    }
}
