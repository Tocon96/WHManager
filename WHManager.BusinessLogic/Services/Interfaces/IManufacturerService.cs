using System.Collections.Generic;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services
{
    public interface IManufacturerService
    {
        Task CreateNewManufacturer(Manufacturer manufacturer);
        IList<Manufacturer> GetManufacturers();
        Manufacturer GetManufacturer(int id);
        Task UpdateManufacturer(Manufacturer manufacturer);
        Task DeleteManufacturer(int id);
        IList<Manufacturer> GetManufacturersByName(string name);
        Manufacturer GetManufacturerByNip(double nip);

    }
}