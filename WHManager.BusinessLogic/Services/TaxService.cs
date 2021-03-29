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

        public void CreateNewTax(Tax tax)
        {
            try
            {
                int id = tax.Id;
                string name = tax.Name;
                int value = tax.Value;
                _taxRepository.AddTax(name, value);
            }
            catch
            {
                throw new Exception("Błąd dodawania podatków: ");
            }
        }

        public void DeleteTax(int id)
        {
            try
            {
                _taxRepository.DeleteTax(id);
            }
            catch
            {
                throw new Exception("Błąd usuwania podatków: ");
            }
        }

        public Tax GetTax(int id)
        {
            try
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
            catch
            {
                throw new Exception("Błąd pobierania podatków: ");
            }
        }

        public IList<Tax> GetTaxes()
        {
            try
            {
                IList<Tax> taxesList = new List<Tax>();
                var taxes = _taxRepository.GetAllTaxes();
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
            catch
            {
                throw new Exception("Błąd pobierania podatków: ");
            }
        }

        public void UpdateTax(Tax tax)
        {
            try
            {
                int id = tax.Id;
                string name = tax.Name;
                int value = tax.Value;
                _taxRepository.UpdateTax(id, name, value);
            }
            catch
            {
                throw new Exception("Błąd aktualizacji podatku: ");
            }
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
            catch
            {
                throw new Exception("Błąd pobierania podatków: ");
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
            catch
            {
                throw new Exception("Błąd pobierania podatków: ");
            }
        }
    }
}