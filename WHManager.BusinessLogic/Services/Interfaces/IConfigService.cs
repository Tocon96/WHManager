using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IConfigService
    {
        void InitializeConfig();
        bool CheckIfConfigIsInitialized();
        void AddCompanyData(List<string> data);
        void UpdateCompanyData(List<string> data);
        IList<Config> GetCompanyData();

    }
}
