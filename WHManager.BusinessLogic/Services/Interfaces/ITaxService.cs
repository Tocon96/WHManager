using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface ITaxService
    {
        void CreateNewTax(Tax tax);
        IList<Tax> GetTaxes();
        Tax GetTax(int id);
        void DeleteTax(int id);
        void UpdateTax(Tax tax);
        IList<Tax> GetTaxesByName(string name);
        IList<Tax> GetTaxesByValue(int value);
        IList<Tax> SearchTaxes(List<string> criteria);
        bool CheckIfTaxIsUsed(int id);
    }
}
