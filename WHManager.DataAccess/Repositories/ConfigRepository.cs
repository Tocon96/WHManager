using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public ConfigRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void AddCompanyData(List<string> data)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IList<string> fields = new List<string>();
                fields.Add("CompanyName");
                fields.Add("CompanyPhoneNumber");
                fields.Add("CompanyNip");
                int enumerator = 0;
                foreach(string field in fields)
                {
                    Config configValue = new Config
                    {
                        Field = field,
                        Value = data[enumerator]
                    };
                    enumerator++;
                    context.Config.Add(configValue);
                }
                context.SaveChanges();
            }
        }

        public bool CheckIfConfigIsInitialized()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                if (context.Config.Any(x => x.Field.StartsWith("Initialized")))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IEnumerable<Config> GetCompanyData()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Config> data = context.Config.ToList().FindAll(x => x.Field.StartsWith("Company"));
                return data;
            }
        }

        public void InitializeConfig()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                Config configValue = new Config
                {
                    Field = "Initialized",
                    Value = "1"
                };
                context.Config.Add(configValue);
                context.SaveChanges();
            }
        }

        public void UpdateCompanyData(List<string> data)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IList<Config> fields = context.Config.ToList().FindAll(x => x.Field.StartsWith("Company"));
                int enumerator = 0;
                foreach (Config field in fields)
                {
                    field.Value = data[enumerator];
                    enumerator++;
                    context.Config.Update(field);
                }
                context.SaveChanges();
            }

        }
    }
}
