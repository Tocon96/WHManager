using System.Collections.Generic;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories
{
    public interface IManufacturerRepository
    {
        Task<Manufacturer> AddManufacturerAsync(int id, string name, double nip);
        IEnumerable<Manufacturer> GetManufacturers();
        Manufacturer GetManufacturer(int id);
        Task DeleteManufacturerAsync(int id);
        Task UpdateManufacturerAsync(int id, string name, double nip);
        Manufacturer GetManufacturerByNip(double nip);
        IEnumerable<Manufacturer> GetManufacturersByName(string name);
    }
}