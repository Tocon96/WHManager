using System.Collections.Generic;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services
{
    public interface IManufacturerService
    {
        void CreateNewManufacturer(Manufacturer manufacturer);
        IList<Manufacturer> GetManufacturers();
        Manufacturer GetManufacturer(int id);
        void UpdateManufacturer(Manufacturer manufacturer);
        void DeleteManufacturer(int id);
        IList<Manufacturer> GetManufacturersByName(string name);
        Manufacturer GetManufacturerByNip(double nip);
        IList<Manufacturer> SearchManufacturers(List<string> criteria);
    }
}