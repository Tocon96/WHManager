using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.DataAccess
{
    public class WHManagerDBContextFactory : IDesignTimeDbContextFactory<WHManagerDBContext>
    {
        public WHManagerDBContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<WHManagerDBContext>();
            options.UseSqlServer("Server=TOCON-KOMPUTER\\SQLEXPRESS;Database=WHManager;Trusted_Connection=True;");

            return new WHManagerDBContext(options.Options);
        }
    }
}
