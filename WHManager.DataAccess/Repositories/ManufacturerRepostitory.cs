using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
	public class ManufacturerRepository : IManufacturerRepository
	{
		private readonly WHManagerDBContextFactory _contextFactory;

		public ManufacturerRepository(WHManagerDBContextFactory contextFactory)
		{
			_contextFactory = contextFactory;
		}

		public async Task<Manufacturer> AddManufacturerAsync(int id, string name, double nip)
		{
			Manufacturer newManufacturer = new Manufacturer
			{
				Id = id,
				Name = name,
				Nip = nip
			};
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				await context.Manufacturers.AddAsync(newManufacturer);
				await context.SaveChangesAsync();
			}
			return newManufacturer;
		}
		
		public IEnumerable<Manufacturer> GetManufacturers()
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				IEnumerable<Manufacturer> manufacturers = context.Manufacturers.ToList();
				return manufacturers;	
			}
		}
		public Manufacturer GetManufacturer(int id)
		{
			using(WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				return context.Manufacturers.SingleOrDefault(x => x.Id == id);	
			}
		}

		
		public async Task DeleteManufacturerAsync(int id)
		{
			using(WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				context.Remove(await context.Manufacturers.SingleOrDefaultAsync(x => x.Id == id));
				await context.SaveChangesAsync();
			}
		}
		public async Task UpdateManufacturerAsync(int id, string name, double nip)
		{
			using(WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				Manufacturer updatedManufacturer = context.Manufacturers.SingleOrDefault(x => x.Id == id);
				updatedManufacturer.Name = name;
				updatedManufacturer.Nip = nip;
				await context.SaveChangesAsync();
			}
		}

        public Manufacturer GetManufacturerByNip(double nip)
        {
            try
            {
				using(WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
					return context.Manufacturers.SingleOrDefault(x => x.Nip == nip);
                }
            }
			catch(Exception e)
            {
				throw e;
            }
        }

        public IEnumerable<Manufacturer> GetManufacturersByName(string name)
        {
            try
            {
				using(WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
					IEnumerable<Manufacturer> manufacturers = context.Manufacturers.ToList().FindAll(x => x.Name.StartsWith(name));
					return manufacturers;
				}
            }
			catch(Exception e)
            {
				throw e;
            }
        }
    }	
}