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
        public async Task<Client> AddNewClientAsync(int id, string name, double? nip, string phonenumber)
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
                    await context.Clients.AddAsync(client);
                    await context.SaveChangesAsync();
                    return client;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task UpdateClientAsync(int id, string name, double? nip, string phonenumber)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Client updatedClient = await context.Clients.SingleOrDefaultAsync(x => x.Id == id);
                    updatedClient.Name = name;
                    updatedClient.Nip = nip;
                    updatedClient.PhoneNumber = phonenumber;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task DeleteClientAsync(int id)
        {
            using(WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.Remove(await context.Clients.SingleOrDefaultAsync(x => x.Id == id));
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public Client GetClient(int? id = null, string name = null, double? nip = null)
        {
            if (id != null)
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    try
                    {
                        Client client = context.Clients.SingleOrDefault(x => x.Id == id);
                        return client;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else if(name != null)
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    try
                    {
                        Client client = context.Clients.SingleOrDefault(x => x.Name.StartsWith(name));
                        return client;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else if(nip != null)
            {
                using(WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    try
                    {
                        Client client = context.Clients.SingleOrDefault(x => x.Nip == nip);
                        return client;
                    }
                    catch (Exception)
                    {
                        throw;
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
                    throw;
                }
            }
        }
    }
}
