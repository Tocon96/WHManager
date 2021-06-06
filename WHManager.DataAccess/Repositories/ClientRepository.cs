using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public ClientRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void AddNewClient(int id, string name, double? nip, string phonenumber)
        {
            using(WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Client client = new Client
                    {
                        Name = name,
                        Nip = nip,
                        PhoneNumber = phonenumber
                    };
                    context.Clients.Add(client);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd dodawania nowego klienta: ");
                }
            }
        }

        public void UpdateClient(int id, string name, double? nip, string phonenumber)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Client updatedClient = context.Clients.SingleOrDefault(x => x.Id == id);
                    updatedClient.Name = name;
                    updatedClient.Nip = nip;
                    updatedClient.PhoneNumber = phonenumber;
                    context.SaveChanges();

                }
                catch
                {
                    throw new Exception("Błąd aktualizacji klienta: ");
                }
            }
        }

        public void DeleteClient(int id)
        {
            using(WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.Remove(context.Clients.SingleOrDefault(x => x.Id == id));
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new Exception("Błąd usuwania klienta: ");
                }
            }
        }

        public IEnumerable<Client> GetClient(int? id = null, string name = null, double? nip = null)
        {
            if (id != null)
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    try
                    {
                        IEnumerable<Client> clients = context.Clients.ToList().FindAll(x => x.Id == id);
                        return clients;
                    }
                    catch
                    {
                        throw new Exception("Błąd pobierania klientów");
                    }
                }
            }
            else if(name != null)
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    try
                    {
                        IEnumerable<Client> clients = context.Clients.ToList().FindAll(x => x.Name.StartsWith(name));
                        return clients;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Błąd pobierania klientów");
                    }
                }
            }
            else if(nip != null)
            {
                using(WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    try
                    {
                        IEnumerable<Client> clients = context.Clients.ToList().FindAll(x => x.Nip == nip);
                        return clients;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Błąd pobierania klientów");
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Client> GetClients()
        {
            using(WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<Client> clients = context.Clients.ToList();
                    return clients;
                }
                catch (Exception)
                {
                    throw new Exception("Błąd pobierania klientów");
                }
            }
        }

        public IEnumerable<Client> SearchClients(List<string> criteria)
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    IQueryable<Client> clients = context.Clients.AsQueryable();
                    if (!string.IsNullOrEmpty(criteria[0]))
                    {
                        if(int.TryParse(criteria[0], out int result))
                        {
                            clients = clients.Where(x => x.Id == result);
                        }
                        else
                        {
                            clients = clients.Where(x => x.Name.StartsWith(criteria[0]));
                        }
                    }
                    if (!string.IsNullOrEmpty(criteria[1]))
                    {
                        clients = clients.Where(x => x.Nip == int.Parse(criteria[1]));
                    }
                    if (!string.IsNullOrEmpty(criteria[2]))
                    {
                        clients = clients.Where(x => x.PhoneNumber.StartsWith(criteria[2]));
                    }
                    IEnumerable<Client> clientList = clients.ToList();
                    return clientList;
                }
            }
            catch
            {
                throw new Exception("Błąd wyszukiwania: ");
            }
        }
    }
}