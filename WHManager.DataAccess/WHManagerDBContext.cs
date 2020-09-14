using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess
{
    public class WHManagerDBContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Tax> Taxes { get; set; }

        public WHManagerDBContext(DbContextOptions options) : base(options) { }
    }
}
