using System;
using System.Collections.Generic;
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
            int id = manufacturer.Id;
            string name = manufacturer.Name;
            int nip = manufacturer.Nip;
            await _manufacturerRepository.AddManufacturerAsync(id, name, nip);
        }

        public List<Manufacturer> GetManufacturers()
        {
            List<Manufacturer> manufacturersList = new List<Manufacturer>();
            var manufacturers = _manufacturerRepository.GetManufacturers();
            foreach(var manufacturer in manufacturers)
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
		
		public async Task<Manufacturer> GetManufacturer(int id)
		{
			var manufacturer = await _manufacturerRepository.GetManufacturerAsync(id);
            Manufacturer currentManufacturer = new Manufacturer
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name,
                Nip = manufacturer.Nip
            };
			return currentManufacturer;
		}
		
		public async Task UpdateManufacturer(Manufacturer manufacturer)
		{
			int id = manufacturer.Id;
            string name = manufacturer.Name;
            int nip = manufacturer.Nip;
            await _manufacturerRepository.UpdateManufacturerAsync(id, name, nip);
		}
		
		public async Task DeleteManufacturer(int id)
		{
			await _manufacturerRepository.DeleteManufacturerAsync(id);
		}
		
    }
}