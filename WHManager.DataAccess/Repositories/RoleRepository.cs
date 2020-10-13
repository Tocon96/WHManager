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
    public class RoleRepository : IRoleRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public RoleRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreateNewRole(string name, bool isadmin)
        {
            try
            {
                using(WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    Role role = new Role
                    {
                        Name = name,
                        IsAdmin = isadmin
                    };
                    await context.Roles.AddAsync(role);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteRole(int id)
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    context.Remove(await context.Roles.SingleOrDefaultAsync(x => x.Id == id));
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Role> GetRole(int id)
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    IEnumerable<Role> roles = context.Roles.ToList().FindAll(x => x.Id == id);
                    return roles;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Role> GetRoles()
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    IEnumerable<Role> roles = context.Roles.ToList();
                    return roles;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Role> GetRoleByName(string name)
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    IEnumerable<Role> roles = context.Roles.ToList().FindAll(x => x.Name.StartsWith(name));
                    return roles;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateRole(int id, string name, bool isadmin)
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    Role updatedRole = context.Roles.SingleOrDefault(x => x.Id == id);
                    updatedRole.Name = name;
                    updatedRole.IsAdmin = isadmin;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
