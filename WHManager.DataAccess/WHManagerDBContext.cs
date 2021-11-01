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
        public DbSet<Provider> Provider { get; set; }
        public DbSet<IncomingDocument> IncomingDocuments { get; set; }
        public DbSet<OutgoingDocument> OutgoingDocuments { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryOrderElements> DeliveryElements { get; set; }
        public WHManagerDBContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(m => m.Manufacturer).WithMany(p => p.Products).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>().HasOne(p => p.Type).WithMany(p => p.Products).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>().HasOne(t => t.Tax).WithMany(p => p.Products).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Item>().HasOne(p => p.Product).WithMany(i => i.Items).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Invoice>().HasOne(c => c.Client).WithMany(i => i.Invoices).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>().HasOne(c => c.Client).WithMany(o => o.Orders).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasOne(r => r.Role).WithMany(u => u.Users).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Provider>().HasMany(i => i.Items).WithOne(p => p.Provider).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<IncomingDocument>().HasOne(p => p.Provider).WithMany(i => i.IncomingDocuments).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OutgoingDocument>().HasOne(c => c.Contrahent).WithMany(i => i.OutgoingDocuments).OnDelete(DeleteBehavior.NoAction);
        }
    }
}