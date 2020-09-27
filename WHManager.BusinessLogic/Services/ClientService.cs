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
        private IOrderService orderService = new OrderService();
        private IInvoiceService invoiceService = new InvoiceService();

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

        public Client GetClient(int? id = null, string name = null, double? nip = null)
        {
            if(id != null)
            {
                try
                {
                    var client = _clientRepository.GetClient(id, null, null);
                    Client currentClient = new Client
                    {
                        Id = client.Id,
                        Name = client.Name,
                        Nip = client.Nip,
                        PhoneNumber = client.PhoneNumber,
                        Orders = orderService.GetOrdersByClient(id, null, null),
                        Invoices = invoiceService.GetInvoicesByClient(id)
                    };
                    return currentClient;
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
                    var client = _clientRepository.GetClient(null, name, null);
                    Client currentClient = new Client
                    {
                        Id = client.Id,
                        Name = client.Name,
                        Nip = client.Nip,
                        PhoneNumber = client.PhoneNumber,
                        Orders = orderService.GetOrdersByClient(id),
                        Invoices = invoiceService.GetInvoicesByClient(id)
                    };
                    return currentClient;
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
                    var client = _clientRepository.GetClient(null, null, nip);
                    Client currentClient = new Client
                    {
                        Id = client.Id,
                        Name = client.Name,
                        Nip = client.Nip,
                        PhoneNumber = client.PhoneNumber,
                        Orders = orderService.GetOrdersByClient(id),
                        Invoices = invoiceService.GetInvoicesByClient(id)
                    };
                    return currentClient;
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
