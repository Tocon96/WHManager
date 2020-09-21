﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Tax> AddTaxAsync(int id, string name, int value)
        {
            Tax newTax = new Tax
            {
                Id = id,
                Name = name,
                Value = value
            };
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                await context.Taxes.AddAsync(newTax);
                await context.SaveChangesAsync();
            }
            return newTax;
        }

        public async Task DeleteTaxAsync(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                context.Remove(await context.Taxes.SingleOrDefaultAsync(x => x.Id == id));
                await context.SaveChangesAsync();
            }
        }

        public IEnumerable<Tax> GetAllTaxes()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Tax> taxes = context.Taxes.ToList();
                return taxes;
            } 
        }

        public Tax GetTax(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                return context.Taxes.SingleOrDefault(x => x.Id == id);
            }
        }

        public async Task UpdateTaxAsync(int id, string name, int value)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                Tax updatedTax = await context.Taxes.SingleOrDefaultAsync(x => x.Id == id);
                updatedTax.Name = name;
                updatedTax.Value = value;
                await context.SaveChangesAsync();
            }
        }

        public IEnumerable<Tax> GetTaxesByName(string name)
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    IEnumerable<Tax> taxes = context.Taxes.ToList().FindAll(x => x.Name.StartsWith(name));
                    return taxes;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Tax> GetTaxesByValue(int value)
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    IEnumerable<Tax> taxes = context.Taxes.ToList().FindAll(x => x.Value == value);
                    return taxes;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}