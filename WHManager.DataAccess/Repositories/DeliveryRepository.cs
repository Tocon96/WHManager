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

        public int AddDelivery(int providerId, DateTime date)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                Delivery delivery = new Delivery
                {
                    Provider = context.Provider.SingleOrDefault(x => x.Id == providerId),
                    DateCreated = date,
                    DateRealized = null,
                    Realized = false
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

        public IEnumerable<Delivery> GetDeliveriesByClient(int providerId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.Include(x => x.Provider)
                                                                         .Include(x => x.Items)
                                                                         .ToList()
                                                                         .FindAll(x => x.Provider.Id == providerId);

                    return deliveries;
                }
                catch (Exception)
                {
                    throw new Exception("Błąd pobierania dostaw");
                }

            }
        }

        public IEnumerable<Delivery> GetDeliveriesByManufacturer(int manufacturerId, DateTime? datefrom, DateTime? dateTo)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                if (!datefrom.HasValue && !dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.AsQueryable()
                                                              .Include(x => x.Provider)
                                                              .Include(x => x.Items)
                                                              .Where(i => i.Items.Any(x => x.Product.Manufacturer.Id == manufacturerId));

                    IEnumerable<Delivery> deliveryList = deliveries.ToList();
                    return deliveryList;


                }

                if (datefrom.HasValue && !dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.AsQueryable()
                                                              .Include(x => x.Provider)
                                                              .Include(x => x.Items)
                                                              .Where(i => i.Items.Any(x => x.Product.Manufacturer.Id == manufacturerId) && i.DateRealized >= datefrom);

                    IEnumerable<Delivery> deliveryList = deliveries.ToList();
                    return deliveryList;
                }

                if (!datefrom.HasValue && dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.AsQueryable()
                                                              .Include(x => x.Provider)
                                                              .Include(x => x.Items)
                                                              .Where(i => i.Items.Any(x => x.Product.Manufacturer.Id == manufacturerId) && i.DateRealized <= dateTo);

                    IEnumerable<Delivery> deliveryList = deliveries.ToList();
                    return deliveryList;
                }

                if (datefrom.HasValue && dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.AsQueryable()
                                                              .Include(x => x.Provider)
                                                              .Include(x => x.Items)
                                                              .Where(i => i.Items.Any(x => x.Product.Manufacturer.Id == manufacturerId) && i.DateRealized >= datefrom && i.DateRealized <= dateTo);

                    IEnumerable<Delivery> deliveryList = deliveries.ToList();
                    return deliveryList;
                }
                return null;
            }
        }

        public IEnumerable<Delivery> GetDeliveriesByProduct(int productId, DateTime? datefrom, DateTime? dateTo)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                if (!datefrom.HasValue && !dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.AsQueryable()
                                                              .Include(x => x.Provider)
                                                              .Include(x => x.Items)
                                                              .Where(i => i.Items.Any(x => x.Product.Id == productId));

                    IEnumerable<Delivery> deliveryList = deliveries.ToList();
                    return deliveryList;


                }

                if (datefrom.HasValue && !dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.AsQueryable()
                                                              .Include(x => x.Provider)
                                                              .Include(x => x.Items)
                                                              .Where(i => i.Items.Any(x => x.Product.Id == productId) && i.DateRealized >= datefrom);

                    IEnumerable<Delivery> deliveryList = deliveries.ToList();
                    return deliveryList;
                }

                if (!datefrom.HasValue && dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.AsQueryable()
                                                              .Include(x => x.Provider)
                                                              .Include(x => x.Items)
                                                              .Where(i => i.Items.Any(x => x.Product.Id == productId) && i.DateRealized <= dateTo);

                    IEnumerable<Delivery> deliveryList = deliveries.ToList();
                    return deliveryList;
                }

                if (datefrom.HasValue && dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.AsQueryable()
                                                              .Include(x => x.Provider)
                                                              .Include(x => x.Items)
                                                              .Where(i => i.Items.Any(x => x.Product.Id == productId) && i.DateRealized >= datefrom && i.DateRealized <= dateTo);

                    IEnumerable<Delivery> deliveryList = deliveries.ToList();
                    return deliveryList;
                }
                return null;
            }

        }

        public IEnumerable<Delivery> GetDeliveriesByProductType(int productTypeId, DateTime? datefrom, DateTime? dateTo)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                if (!datefrom.HasValue && !dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.AsQueryable()
                                                              .Include(x => x.Provider)
                                                              .Include(x => x.Items)
                                                              .Where(i => i.Items.Any(x => x.Product.Type.Id == productTypeId));

                    IEnumerable<Delivery> deliveryList = deliveries.ToList();
                    return deliveryList;


                }

                if (datefrom.HasValue && !dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.AsQueryable()
                                                              .Include(x => x.Provider)
                                                              .Include(x => x.Items)
                                                              .Where(i => i.Items.Any(x => x.Product.Type.Id == productTypeId) && i.DateRealized >= datefrom);

                    IEnumerable<Delivery> deliveryList = deliveries.ToList();
                    return deliveryList;
                }

                if (!datefrom.HasValue && dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.AsQueryable()
                                                              .Include(x => x.Provider)
                                                              .Include(x => x.Items)
                                                              .Where(i => i.Items.Any(x => x.Product.Type.Id == productTypeId) && i.DateRealized <= dateTo);

                    IEnumerable<Delivery> deliveryList = deliveries.ToList();
                    return deliveryList;
                }

                if (datefrom.HasValue && dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.AsQueryable()
                                                              .Include(x => x.Provider)
                                                              .Include(x => x.Items)
                                                              .Where(i => i.Items.Any(x => x.Product.Type.Id == productTypeId) && i.DateRealized >= datefrom && i.DateRealized <= dateTo);

                    IEnumerable<Delivery> deliveryList = deliveries.ToList();
                    return deliveryList;
                }
                return null;
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

        public IEnumerable<Delivery> GetRealizedDeliveriesByProviderWithinDateRanges(int contrahentId, DateTime? dateFrom, DateTime? dateTo)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                if (!dateFrom.HasValue && !dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.Include(x => x.Provider)
                                                                         .Include(x => x.Items)
                                                                         .ToList()
                                                                         .FindAll(x => x.Provider.Id == contrahentId);
                    return deliveries;
                }

                if (dateFrom.HasValue && !dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.Include(x => x.Provider)
                                                                         .Include(x => x.Items)
                                                                         .ToList()
                                                                         .FindAll(x => x.Provider.Id == contrahentId && x.DateRealized >= dateFrom.Value);
                    return deliveries;
                }

                if (!dateFrom.HasValue && dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.Include(x => x.Provider)
                                                                         .Include(x => x.Items)
                                                                         .ToList()
                                                                         .FindAll(x => x.Provider.Id == contrahentId && x.DateRealized <= dateTo.Value);
                    return deliveries;
                }

                if (dateFrom.HasValue && dateTo.HasValue)
                {
                    IEnumerable<Delivery> deliveries = context.Deliveries.Include(x => x.Provider)
                                                                         .Include(x => x.Items)
                                                                         .ToList()
                                                                         .FindAll(x => x.Provider.Id == contrahentId && x.DateRealized >= dateFrom.Value && x.DateRealized <= dateTo.Value);
                    return deliveries;
                }
                return null;
            }
        }

        public IEnumerable<Delivery> SearchDeliveries(IList<string> criteria)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IQueryable<Delivery> deliveries = context.Deliveries.Include(x=>x.Provider).Include(x=>x.Items).AsQueryable();
                if (!string.IsNullOrEmpty(criteria[0]))
                {
                    int.TryParse(criteria[0], out int result);
                    deliveries = deliveries.Where(x => x.Id == result);
                }
                if (!string.IsNullOrEmpty(criteria[1]))
                {
                    deliveries = deliveries.Where(x => x.Provider.Name.StartsWith(criteria[1]));
                }
                if (!string.IsNullOrEmpty(criteria[2]) && string.IsNullOrEmpty(criteria[3]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[2]);
                    deliveries = deliveries.Where(x => x.DateCreated >= earlierDate);
                }

                if (string.IsNullOrEmpty(criteria[2]) && !string.IsNullOrEmpty(criteria[3]))
                {
                    DateTime laterDate = Convert.ToDateTime(criteria[3]);
                    deliveries = deliveries.Where(x => x.DateCreated <= laterDate);
                }

                if (!string.IsNullOrEmpty(criteria[2]) && !string.IsNullOrEmpty(criteria[3]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[2]);
                    DateTime laterDate = Convert.ToDateTime(criteria[3]);
                    deliveries = deliveries.Where(x => x.DateCreated >= earlierDate && x.DateCreated <= laterDate);
                }
                if (!string.IsNullOrEmpty(criteria[4]) && string.IsNullOrEmpty(criteria[5]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[4]);
                    deliveries = deliveries.Where(x => x.DateRealized >= earlierDate);
                }

                if (string.IsNullOrEmpty(criteria[4]) && !string.IsNullOrEmpty(criteria[5]))
                {
                    DateTime laterDate = Convert.ToDateTime(criteria[5]);
                    deliveries = deliveries.Where(x => x.DateRealized <= laterDate);
                }

                if (!string.IsNullOrEmpty(criteria[4]) && !string.IsNullOrEmpty(criteria[5]))
                {
                    DateTime earlierDate = Convert.ToDateTime(criteria[4]);
                    DateTime laterDate = Convert.ToDateTime(criteria[5]);
                    deliveries = deliveries.Where(x => x.DateRealized >= earlierDate && x.DateRealized <= laterDate);
                }

                if (!string.IsNullOrEmpty(criteria[6]))
                {
                    deliveries = deliveries.Where(x => x.Realized == bool.Parse(criteria[6]));
                }

                IEnumerable<Delivery> deliveryList = deliveries.ToList();

                return deliveryList;

            }
        }

        public int UpdateDelivery(int id, int providerId, DateTime dateCreated, DateTime? dateRealized, bool realized)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                Delivery delivery = context.Deliveries.Include(x => x.Provider)
                                                        .Include(x => x.Items)
                                                        .SingleOrDefault(x => x.Id == id);
                try
                {
                    delivery.Provider = context.Provider.SingleOrDefault(x => x.Id == providerId);
                    delivery.DateCreated = dateCreated;
                    delivery.DateRealized = dateRealized;
                    delivery.Realized = realized;
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
