using System.Collections.Generic;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories
{
    public interface IManufacturerRepository
    {
        void AddManufacturer(string name, double nip);
        IEnumerable<Manufacturer> GetManufacturers();
        Manufacturer GetManufacturer(int id);
        void DeleteManufacturer(int id);
        void UpdateManufacturer(int id, string name, double nip);
        Manufacturer GetManufacturerByNip(double nip);
        IEnumerable<Manufacturer> GetManufacturersByName(string name);
    }
}