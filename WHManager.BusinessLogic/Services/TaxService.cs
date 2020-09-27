using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxRepository _taxRepository = new TaxRepository(new DataAccess.WHManagerDBContextFactory());

        public async Task CreateNewTax(Tax tax)
        {
            int id = tax.Id;
            string name = tax.Name;
            int value = tax.Value;
            await _taxRepository.AddTaxAsync(id, name, value);
        }

        public async Task DeleteTax(int id)
        {
            await _taxRepository.DeleteTaxAsync(id);
        }

        public Tax GetTax(int id)
        {
            var tax = _taxRepository.GetTax(id);
            Tax currentTax = new Tax
            {
                Id = tax.Id,
                Name = tax.Name,
                Value = tax.Value
            };
            return currentTax;

        }

        public IList<Tax> GetTaxes()
        {
            IList<Tax> taxesList = new List<Tax>();
            var taxes = _taxRepository.GetAllTaxes();
            foreach(var tax in taxes)
            {
                Tax currentTax = new Tax
                {
                    Id = tax.Id,
                    Name = tax.Name,
                    Value = tax.Value
                };
                taxesList.Add(currentTax);
            }
            return taxesList;
        }

        public async Task UpdateTax(Tax tax)
        {
            int id = tax.Id;
            string name = tax.Name;
            int value = tax.Value;
            await _taxRepository.UpdateTaxAsync(id, name, value);
        }

        public IList<Tax> GetTaxesByName(string name)
        {
            try
            {
                IList<Tax> taxesList = new List<Tax>();
                var taxes = _taxRepository.GetTaxesByName(name);
                foreach (var tax in taxes)
                {
                    Tax currentTax = new Tax
                    {
                        Id = tax.Id,
                        Name = tax.Name,
                        Value = tax.Value
                    };
                    taxesList.Add(currentTax);
                }
                return taxesList;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public IList<Tax> GetTaxesByValue(int value)
        {
            try
            {
                IList<Tax> taxesList = new List<Tax>();
                var taxes = _taxRepository.GetTaxesByValue(value);
                foreach(var tax in taxes)
                {
                    Tax currentTax = new Tax
                    {
                        Id = tax.Id,
                        Name = tax.Name,
                        Value = tax.Value
                    };
                    taxesList.Add(currentTax);
                }
                return taxesList;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}