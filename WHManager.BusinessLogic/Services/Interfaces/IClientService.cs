using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IClientService
    {
        void CreateNewClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);
        IList<Client> GetClient(int? id = null, string name = null, double? nip = null);
        IList<Client> GetAllClients();
        List<Client> SearchClients(List<string> criteria);
    }
}
