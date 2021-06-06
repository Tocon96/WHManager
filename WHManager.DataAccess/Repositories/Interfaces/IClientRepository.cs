using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IClientRepository
    {
        void AddNewClient(int id, string name, double? nip, string phonenumber);
        void UpdateClient(int id, string name, double? nip, string phonenumber);
        void DeleteClient(int id);
        IEnumerable<Client> GetClient(int? id = null, string name = null, double? nip = null);
        IEnumerable<Client> GetClients();
        IEnumerable<Client> SearchClients(List<string> criteria);
    }
}
