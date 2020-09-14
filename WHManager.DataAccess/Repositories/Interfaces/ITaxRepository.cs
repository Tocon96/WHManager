using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface ITaxRepository
    {
        Task<Tax> AddTaxAsync(int id, string name, int value);
        IEnumerable<Tax> GetAllTaxes();
        Task<Tax> GetTaxAsync(int id);
        Task UpdateTaxAsync(int id, string name, int value);
        Task DeleteTaxAsync(int id);
    }
}
