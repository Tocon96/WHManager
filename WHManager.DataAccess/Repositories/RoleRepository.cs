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

        public void CreateNewRole(string name, bool isadmin, bool business, bool contractors, bool documents, bool warehouse, bool reports)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Role role = new Role
                    {
                        Name = name,
                        Admin = isadmin,
                        Business = business,
                        Contractors = contractors,
                        Documents = documents,
                        Warehouse = warehouse,
                        Report = reports
                    };
                    context.Roles.Add(role);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd dodawania roli: ");
                }
            }
        }

        public void DeleteRole(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.Remove(context.Roles.SingleOrDefault(x => x.Id == id));
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd usuwania roli: ");
                }
            }
        }

        public IEnumerable<Role> GetRole(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<Role> roles = context.Roles.ToList().FindAll(x => x.Id == id);
                    return roles;
                }
                catch
                {
                    throw new Exception("Błąd pobierania roli: ");
                }
            }
        }

        public IEnumerable<Role> GetRoles()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<Role> roles = context.Roles.ToList();
                    return roles;
                }
                catch
                {
                    throw new Exception("Błąd pobierania roli: ");
                }
            }
        }

        public IEnumerable<Role> GetRoleByName(string name)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<Role> roles = context.Roles.ToList().FindAll(x => x.Name.StartsWith(name));
                    return roles;
                }
                catch
                {
                    throw new Exception("Błąd pobierania roli: ");
                }
            }
            
        }

        public void UpdateRole(int id, string name, bool isadmin, bool business, bool contractors, bool documents, bool warehouse, bool reports)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Role updatedRole = context.Roles.SingleOrDefault(x => x.Id == id);
                    updatedRole.Name = name;
                    updatedRole.Admin = isadmin;
                    updatedRole.Business = business;
                    updatedRole.Contractors = contractors;
                    updatedRole.Documents = documents;
                    updatedRole.Warehouse = warehouse;
                    updatedRole.Report = reports;

                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd aktualizacji roli: ");
                }
            }
        }

        public IEnumerable<Role> SearchRoles(List<string> criteria)
        {
            using(WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IQueryable<Role> roles = context.Roles.AsQueryable();

                if (!string.IsNullOrEmpty(criteria[0]))
                {
                    if (int.TryParse(criteria[0], out int result))
                    {
                        roles = roles.Where(p => p.Id == result);
                    }
                    else
                    {
                        roles = roles.Where(p => p.Name.StartsWith(criteria[0]));
                    }
                }
                IEnumerable<Role> rolesList = roles.ToList();
                return rolesList;
            }
        }

        public void CreateAdminRole()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    Role role = new Role
                    {
                        Name = "Administracja",
                        Admin = true,
                        Business = true,
                        Contractors = true,
                        Documents = true,
                        Warehouse = true,
                        Report = true
                    };
                    context.Roles.Add(role);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd dodawania roli: ");
                }
            }

        }

        public bool CheckIfAdminRoleExists()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                if(context.Roles.Any(x=>x.Id == 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}