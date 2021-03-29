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

		public void AddManufacturer(string name, double nip)
		{
			Manufacturer newManufacturer = new Manufacturer
			{
				Name = name,
				Nip = nip
			};
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					context.Manufacturers.Add(newManufacturer);
					context.SaveChanges();
				}
                catch
                {
					throw new Exception("B��d dodawania nowego producenta: ");
                }
			}
		}
		
		public IEnumerable<Manufacturer> GetManufacturers()
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					IEnumerable<Manufacturer> manufacturers = context.Manufacturers.ToList();
					return manufacturers;
				}
                catch
                {
					throw new Exception("B��d pobierania producent�w: ");
				}
			}
		}
		public Manufacturer GetManufacturer(int id)
		{
			using(WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				try
				{
					return context.Manufacturers.SingleOrDefault(x => x.Id == id);
				}
				catch
				{
					throw new Exception("B��d pobierania producent�w: ");
				}
			}
		}

		
		public void DeleteManufacturer(int id)
		{
			using(WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					context.Remove(context.Manufacturers.SingleOrDefault(x => x.Id == id));
					context.SaveChanges();
				}
				catch
				{
					throw new Exception("B��d usuwania producenta o ID "+id+" : ");
				}

			}
		}
		public void UpdateManufacturer(int id, string name, double nip)
		{
			using(WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					Manufacturer updatedManufacturer = context.Manufacturers.SingleOrDefault(x => x.Id == id);
					updatedManufacturer.Name = name;
					updatedManufacturer.Nip = nip;
					context.SaveChanges();
				}
				catch
				{
					throw new Exception("B��d aktualizowania producenta o ID: " + id + " : ");
				}
			}
		}

        public Manufacturer GetManufacturerByNip(double nip)
        {
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				try
				{
					return context.Manufacturers.SingleOrDefault(x => x.Nip == nip);
				}
				catch
				{
					throw new Exception("B��d pobierania producenta: ");
				}
			}
        }

        public IEnumerable<Manufacturer> GetManufacturersByName(string name)
        {
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				try
				{
					IEnumerable<Manufacturer> manufacturers = context.Manufacturers.ToList().FindAll(x => x.Name.StartsWith(name));
					return manufacturers;
				}
				catch (Exception)
				{
					throw new Exception("B��d pobierania producent�w: ");
				}
			}
		}
    }	
}