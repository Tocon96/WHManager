using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository = new ManufacturerRepository(new DataAccess.WHManagerDBContextFactory());

        public async Task CreateNewManufacturer(Manufacturer manufacturer)
        {
            try
            {
                int id = manufacturer.Id;
                string name = manufacturer.Name;
                double nip = manufacturer.Nip;
                await _manufacturerRepository.AddManufacturerAsync(id, name, nip);
            }
            catch(Exception e)
            {
                throw e;
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
            catch(Exception e)
            {
                throw e;
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
            catch (Exception e)
            {
                throw e;
            }
			
		}
		
		public async Task UpdateManufacturer(Manufacturer manufacturer)
		{
            try
            {
                int id = manufacturer.Id;
                string name = manufacturer.Name;
                double nip = manufacturer.Nip;
                await _manufacturerRepository.UpdateManufacturerAsync(id, name, nip);
            }
            catch(Exception e)
            {
                throw e;
            }
			
		}
		
		public async Task DeleteManufacturer(int id)
		{
            try
            {
                await _manufacturerRepository.DeleteManufacturerAsync(id);
            }
            catch(Exception e)
            {
                throw e;
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
            catch(Exception e)
            {
                throw e;
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
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}