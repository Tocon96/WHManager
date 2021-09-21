using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public ProviderRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public int AddProvider(string name, double? nip, string phonenumber)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                Provider provider = new Provider
                {
                    Name = name,
                    Nip = nip,
                    PhoneNumber = phonenumber
                };
                try
                {
                    context.Provider.Add(provider);
                    context.SaveChanges();
                    return provider.Id;
                }
                catch
                {
                    throw new Exception("Błąd dodawania nowego dostawcy: ");
                }
            }

        }

        public void DeleteProvider(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.Provider.Remove(context.Provider.SingleOrDefault(x => x.Id == id));
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd usuwania dostawcy: ");
                }
            }
        }

        public IEnumerable<Provider> GetAllProviders()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<Provider> providers = context.Provider.ToList();
                    return providers;
                }
                catch (Exception)
                {
                    throw new Exception("Błąd pobierania dostawców");
                }
            }

            
        }

        public Provider GetProviderById(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                return context.Provider.SingleOrDefault(x => x.Id == id);
            }
                
        }

        public IEnumerable<Provider> SearchProviders(IList<string>criteria)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IQueryable<Provider> providers = context.Provider.AsQueryable();
                if (!string.IsNullOrEmpty(criteria[0]))
                {
                    if (int.TryParse(criteria[0], out int result))
                    {
                        providers = providers.Where(x => x.Id == result);
                    }
                    else
                    {
                        providers = providers.Where(x => x.Name.StartsWith(criteria[0]));
                    }
                }
                if (!string.IsNullOrEmpty(criteria[1]))
                {
                    providers = providers.Where(x => x.Nip == double.Parse(criteria[1]));
                }
                if (!string.IsNullOrEmpty(criteria[2]))
                {
                    providers = providers.Where(x => x.PhoneNumber.StartsWith(criteria[2]));
                }
                IEnumerable<Provider> providerList = providers.ToList();
                return providerList;
            }

        }

        public int UpdateProvider(int id, string name, double? nip, string phonenumber)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                Provider provider = context.Provider.SingleOrDefault(x => x.Id == id);
                provider.Name = name;
                provider.Nip = nip;
                provider.PhoneNumber = phonenumber;
                context.Provider.Update(provider);
                context.SaveChanges();
            }
            throw new NotImplementedException();
        }
    }
}
