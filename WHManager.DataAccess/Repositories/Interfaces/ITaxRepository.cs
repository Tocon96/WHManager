using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface ITaxRepository
    {
        void AddTax(string name, int value);
        IEnumerable<Tax> GetAllTaxes();
        Tax GetTax(int id);
        void UpdateTax(int id, string name, int value);
        void DeleteTax(int id);
        IEnumerable<Tax> GetTaxesByName(string name);
        IEnumerable<Tax> GetTaxesByValue(int value);
        IEnumerable<Tax> SearchTaxes(List<string> criteria);
        bool CheckIfTaxIsUsed(int taxId);
    }
}
