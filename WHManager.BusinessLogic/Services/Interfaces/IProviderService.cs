using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IProviderService
    {
        int CreateProvider(Provider provider);
        int UpdateProvider(Provider client);
        void DeleteProvider(int id);
        Provider GetProvider(int id);
        IList<Provider> GetAllProviders();
        IList<Provider> SearchProviders(List<string> criteria);
    }
}
