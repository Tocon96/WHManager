using System.Collections.Generic;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services
{
    public interface IManufacturerService
    {
        Task CreateNewManufacturer(Manufacturer manufacturer);
        List<Manufacturer> GetManufacturers();
        Task<Manufacturer> GetManufacturer(int id);
        Task UpdateManufacturer(Manufacturer manufacturer);
        Task DeleteManufacturer(int id);
    }
}