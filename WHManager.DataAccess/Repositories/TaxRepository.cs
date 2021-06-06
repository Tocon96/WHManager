using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class TaxRepository : ITaxRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public TaxRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void AddTax(string name, int value)
        {
            Tax newTax = new Tax
            {
                Name = name,
                Value = value
            };
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.Taxes.Add(newTax);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd dodawania podatku: ");
                }

            }
        }

        public void DeleteTax(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.Remove(context.Taxes.SingleOrDefault(x => x.Id == id));
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd usuwania podatku: ");
                }
            }
        }

        public IEnumerable<Tax> GetAllTaxes()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<Tax> taxes = context.Taxes.ToList();
                    return taxes;
                }
                catch
                {
                    throw new Exception("Błąd pobierania podatków: ");
                }
            } 
        }

        public Tax GetTax(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    return context.Taxes.SingleOrDefault(x => x.Id == id);
                }
                catch
                {
                    throw new Exception("Błąd pobierania podatków: ");
                }
            }
        }

        public void UpdateTax(int id, string name, int value)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Tax updatedTax = context.Taxes.SingleOrDefault(x => x.Id == id);
                    updatedTax.Name = name;
                    updatedTax.Value = value;
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd aktualizacji podatku: ");
                }
            }
        }

        public IEnumerable<Tax> GetTaxesByName(string name)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<Tax> taxes = context.Taxes.ToList().FindAll(x => x.Name.StartsWith(name));
                    return taxes;
                }
                catch
                {
                    throw new Exception("Błąd pobierania podatku: ");
                }
            }
        }

        public IEnumerable<Tax> GetTaxesByValue(int value)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<Tax> taxes = context.Taxes.ToList().FindAll(x => x.Value == value);
                    return taxes;
                }
                catch
                {
                    throw new Exception("Błąd pobierania podatku: ");
                }
            }
            
        }

        public IEnumerable<Tax> SearchTaxes(List<string> criteria)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IQueryable<Tax> taxes = context.Taxes.AsQueryable();
                    if(!string.IsNullOrEmpty(criteria[0]))
                    {
                        if (int.TryParse(criteria[0], out int result))
                        {
                            taxes = taxes.Where(x => x.Id == result);
                        }
                        else
                        {
                            taxes = taxes.Where(x => x.Name.StartsWith(criteria[0]));
                        }
                    }
                    if(!string.IsNullOrEmpty(criteria[1]) && decimal.TryParse(criteria[1], out decimal minimalValue))
                    {
                        taxes = taxes.Where(x => x.Value >= minimalValue);
                    }
                    if(!string.IsNullOrEmpty(criteria[2]) && decimal.TryParse(criteria[2], out decimal maximumValue))
                    {
                        taxes = taxes.Where(x => x.Value <= maximumValue);
                    }
                    IEnumerable<Tax> taxList = taxes.ToList();
                    return taxList;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}