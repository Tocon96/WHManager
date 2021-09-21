using System;
using System.Collections.Generic;
using System.Text;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IProviderRepository
    {
        public int AddProvider(string name, double? nip, string phonenumber);
        public int UpdateProvider(int id, string name, double? nip, string phonenumber);
        public IEnumerable<Provider> GetAllProviders();
        public Provider GetProviderById(int id);
        public IEnumerable<Provider> SearchProviders(IList<string> criteria);
        public void DeleteProvider(int id);
    }
}
