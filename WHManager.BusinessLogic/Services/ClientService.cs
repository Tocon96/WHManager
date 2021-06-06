﻿using System;
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

        public void CreateNewClient(Client client)
        {
            try
            {
                int id = client.Id;
                string name = client.Name;
                string phoneNumber = client.PhoneNumber;
                double? nip = client.Nip;
                _clientRepository.AddNewClient(id, name, nip, phoneNumber);
            }
            catch
            {
                throw new Exception("Błąd dodawania klienta: ");
            }
        }

        public void DeleteClient(int id)
        {
            try
            {
                _clientRepository.DeleteClient(id);
            }
            catch
            {
                throw new Exception("Błąd usuwania klienta: ");
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
            catch
            {
                throw new Exception("Błąd pobierania klientów: ");
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
                catch
                {
                    throw new Exception("Błąd pobierania klientów: ");
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
                catch
                {
                    throw new Exception("Błąd pobierania klientów: ");
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
                catch
                {
                    throw new Exception("Błąd pobierania klientów: ");
                }
            }
            else
            {
                throw new Exception("Błąd pobierania klientów: ");
            }
        }

        public List<Client> SearchClients(List<string> criteria)
        {
            try
            {
                List<Client> clients = new List<Client>();
                var clientsList = _clientRepository.SearchClients(criteria);
                foreach (var client in clientsList)
                {
                    Client currentClient = new Client
                    {
                        Id = client.Id,
                        Name = client.Name,
                        Nip = client.Nip,
                        PhoneNumber = client.PhoneNumber,
                    };
                    clients.Add(currentClient);
                }
                return clients;
            }
            catch
            {
                throw new Exception("Błąd wyszukiwania typu podatków: ");
            }
        }

        public void UpdateClient(Client client)
        {
            try
            {
                int id = client.Id;
                string name = client.Name;
                string phoneNumber = client.PhoneNumber;
                double? nip = client.Nip;
                _clientRepository.UpdateClient(id, name, nip, phoneNumber);
            }
            catch
            {
                throw new Exception("Błąd pobierania klientów: ");
            }
        }
    }
}
