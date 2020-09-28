using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IClientService
    {
        Task CreateNewClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(int id);
        IList<Client> GetClient(int? id = null, string name = null, double? nip = null);
        IList<Client> GetAllClients();
    }
}
