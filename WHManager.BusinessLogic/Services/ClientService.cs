using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository = new ClientRepository(new DataAccess.WHManagerDBContextFactory());

        public async Task CreateNewClient(Client client)
        {
            try
            {
                int id = client.Id;
                string name = client.Name;
                string phoneNumber = client.PhoneNumber;
                double? nip = client.Nip;
                await _clientRepository.AddNewClientAsync(id, name, nip, phoneNumber);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteClient(int id)
        {
            try
            {
                await _clientRepository.DeleteClientAsync(id);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public IList<Client> GetAllClients()
        {
            try
            {
                IList<Client> clientsList = new List<Client>();
                var clients = _clientRepository.GetClients();
                foreach(var client in clients)
                {
                    Client newClient = new Client
                    {
                        Id = client.Id,
                        Name = client.Name,
                        Nip = client.Nip,
                        PhoneNumber = client.PhoneNumber
                    };
                    clientsList.Add(newClient);
                }
                return clientsList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Client> GetClient(int? id = null, string name = null, double? nip = null)
        {
            if(id != null)
            {
                try
                {
                    IList<Client> clientsList = new List<Client>();
                    var clients = _clientRepository.GetClient(id, null, null);
                    foreach(var client in clients)
                    {
                        Client currentClient = new Client
                        {
                            Id = client.Id,
                            Name = client.Name,
                            Nip = client.Nip,
                            PhoneNumber = client.PhoneNumber,
                        };
                        clientsList.Add(currentClient);
                    }
                    return clientsList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if(name != null)
            {
                try
                {
                    IList<Client> clientsList = new List<Client>();
                    var clients = _clientRepository.GetClient(null, name, null);
                    foreach(var client in clients)
                    {
                        Client currentClient = new Client
                        {
                            Id = client.Id,
                            Name = client.Name,
                            Nip = client.Nip,
                            PhoneNumber = client.PhoneNumber,
                        };
                        clientsList.Add(currentClient);
                    }

                    return clientsList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if(nip != null)
            {
                try
                {
                    IList<Client> clientsList = new List<Client>();
                    var clients = _clientRepository.GetClient(null, null, nip);
                    foreach(var client in clients)
                    {
                        Client currentClient = new Client
                        {
                            Id = client.Id,
                            Name = client.Name,
                            Nip = client.Nip,
                            PhoneNumber = client.PhoneNumber,
                        };
                        clientsList.Add(currentClient);
                    }
                    return clientsList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task UpdateClient(Client client)
        {
            try
            {
                int id = client.Id;
                string name = client.Name;
                string phoneNumber = client.PhoneNumber;
                double? nip = client.Nip;
                await _clientRepository.UpdateClientAsync(id, name, nip, phoneNumber);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
