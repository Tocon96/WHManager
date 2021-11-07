using System;
using System.Collections.Generic;
using System.Text;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IConfigRepository
    {
        void InitializeConfig();
        bool CheckIfConfigIsInitialized();
        void AddCompanyData(List<string>data);
        void UpdateCompanyData(List<string> data);
        IEnumerable<Config> GetCompanyData();
    }
}
