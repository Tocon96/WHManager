using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.BusinessLogic.Services.ReportsServices;
using WHManager.BusinessLogic.Services.ReportsServices.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository = new ManufacturerRepository(new DataAccess.WHManagerDBContextFactory());
        IProductReportsService reportService = new ProductReportsService();

        public void CreateNewManufacturer(Manufacturer manufacturer)
        {
            try
            {
                int id = manufacturer.Id;
                string name = manufacturer.Name;
                double nip = manufacturer.Nip;
                _manufacturerRepository.AddManufacturer(name, nip);
            }
            catch
            {
                throw new Exception("Błąd dodawania producenta: ");
            }
            
        }

        public IList<Manufacturer> GetManufacturers()
        {
            try
            {
                IList<Manufacturer> manufacturersList = new List<Manufacturer>();
                var manufacturers = _manufacturerRepository.GetManufacturers().ToList();
                foreach (var manufacturer in manufacturers)
                {
                    Manufacturer currentManufacturer = new Manufacturer
                    {
                        Id = manufacturer.Id,
                        Name = manufacturer.Name,
                        Nip = manufacturer.Nip
                    };
                    manufacturersList.Add(currentManufacturer);
                }
                return manufacturersList;
            }
            catch
            {
                throw new Exception("Błąd pobierania producentów: ");
            }
            
        }
		
		public Manufacturer GetManufacturer(int id)
		{
            try
            {
                var manufacturer = _manufacturerRepository.GetManufacturer(id);
                Manufacturer currentManufacturer = new Manufacturer
                {
                    Id = manufacturer.Id,
                    Name = manufacturer.Name,
                    Nip = manufacturer.Nip
                };
                return currentManufacturer;
            }
            catch
            {
                throw new Exception("Błąd pobierania producenta: ");
            }
		}
		
		public void UpdateManufacturer(Manufacturer manufacturer)
		{
            try
            {
                int id = manufacturer.Id;
                string name = manufacturer.Name;
                double nip = manufacturer.Nip;
                _manufacturerRepository.UpdateManufacturer(id, name, nip);
            }
            catch(Exception)
            {
                throw new Exception("Błąd aktualizacji producenta: ");
            }
			
		}
		
		public void DeleteManufacturer(int id)
		{
            try
            {
                _manufacturerRepository.DeleteManufacturer(id);
            }
            catch(Exception)
            {
                throw new Exception("Błąd usuwania producenta: ");
            }
			
		}

        public IList<Manufacturer> GetManufacturersByName(string name)
        {
            try
            {
                IList<Manufacturer> manufacturersList = new List<Manufacturer>();
                var manufacturers = _manufacturerRepository.GetManufacturersByName(name);
                foreach (var manufacturer in manufacturers)
                {
                    Manufacturer currentManufacturer = new Manufacturer
                    {
                        Id = manufacturer.Id,
                        Name = manufacturer.Name,
                        Nip = manufacturer.Nip
                    };
                    manufacturersList.Add(currentManufacturer);
                }
                return manufacturersList;
            }
            catch
            {
                throw new Exception("Błąd pobierania producenta: ");
            }
        }

        public Manufacturer GetManufacturerByNip(double nip)
        {
            try
            {
                var manufacturer = _manufacturerRepository.GetManufacturerByNip(nip);
                Manufacturer currentManufacturer = new Manufacturer
                {
                    Id = manufacturer.Id,
                    Name = manufacturer.Name,
                    Nip = manufacturer.Nip
                };
                return currentManufacturer;

            }
            catch
            {
                throw new Exception("Błąd pobierania producenta: ");
            }
        }

        public IList<Manufacturer> SearchManufacturers(List<string> criteria)
        {
            var manufacturersList = _manufacturerRepository.SearchManufacturers(criteria);
            IList<Manufacturer> manufacturers = new List<Manufacturer>();
            foreach(var manufacturer in manufacturersList)
            {
                Manufacturer newManufacturer = new Manufacturer
                {
                    Id = manufacturer.Id,
                    Name = manufacturer.Name,
                    Nip = manufacturer.Nip
                };
                manufacturers.Add(newManufacturer);
            }
            return manufacturers;
        }
    }
}