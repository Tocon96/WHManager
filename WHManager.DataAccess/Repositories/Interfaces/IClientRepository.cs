using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> AddNewClientAsync(int id, string name, double? nip, string phonenumber);
        Task UpdateClientAsync(int id, string name, double? nip, string phonenumber);
        Task DeleteClientAsync(int id);
        Client GetClient(int? id = null, string name = null, double? nip = null);
        IEnumerable<Client> GetClients();
    }
}
