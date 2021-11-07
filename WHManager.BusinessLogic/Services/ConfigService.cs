using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services
{
    public class ConfigService : IConfigService
    {
        IConfigRepository configRepository = new ConfigRepository(new DataAccess.WHManagerDBContextFactory());
        public void AddCompanyData(List<string> data)
        {
            configRepository.AddCompanyData(data);
        }

        public bool CheckIfConfigIsInitialized()
        {
            return configRepository.CheckIfConfigIsInitialized();
        }

        public IList<Config> GetCompanyData()
        {
            var configs = configRepository.GetCompanyData();
            IList<Config> configList = new List<Config>();
            foreach(var config in configs)
            {
                Config newConfig = new Config
                {
                    Id = config.Id,
                    Value = config.Value,
                    Field = config.Field
                };
                configList.Add(newConfig);
            }

            IList<Config> sortedData = new List<Config>();
            sortedData.Add(configList.First(x => x.Field.StartsWith("CompanyName")));
            sortedData.Add(configList.First(x => x.Field.StartsWith("CompanyPhoneNumber")));
            sortedData.Add(configList.First(x => x.Field.StartsWith("CompanyNip")));

            return sortedData;
        }

        public void InitializeConfig()
        {
            configRepository.InitializeConfig();
        }

        public void UpdateCompanyData(List<string> data)
        {
            configRepository.UpdateCompanyData(data);
        }
    }
}
