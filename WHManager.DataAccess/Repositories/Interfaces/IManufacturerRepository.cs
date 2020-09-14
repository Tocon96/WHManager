using System.Collections.Generic;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories
{
    public interface IManufacturerRepository
    {
        Task<Manufacturer> AddManufacturerAsync(int id, string name, int nip);
        IEnumerable<Manufacturer> GetManufacturers();
        Task<Manufacturer> GetManufacturerAsync(int id);
        Task DeleteManufacturerAsync(int id);
        Task UpdateManufacturerAsync(int id, string name, int nip);
    }
}