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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository = new RoleRepository(new DataAccess.WHManagerDBContextFactory());

        public void AddRole(Role role)
        {
            try
            { 
                roleRepository.CreateNewRole(role.Name, role.Admin, role.Business, role.Contractors, role.Documents, role.Warehouse);
            }
            catch
            {
                throw new Exception("Błąd dodawania roli: ");
            }
            
        }

        public void DeleteRole(int id)
        {
            try
            {
                roleRepository.DeleteRole(id);
            }
            catch
            {
                throw new Exception("Błąd usuwania roli: ");
            }
        }

        public IList<Role> GetRoleById(int id)
        {
            try
            {
                IList<Role> roles = new List<Role>();
                var roleList = roleRepository.GetRole(id);
                foreach (var role in roleList)
                {
                    Role newRole = new Role
                    {
                        Id = role.Id,
                        Name = role.Name,
                        Admin = role.Admin,
                        Business = role.Business,
                        Warehouse = role.Warehouse,
                        Contractors = role.Contractors,
                        Documents = role.Documents
                    };
                    roles.Add(newRole);
                }
                return roles;
            }
            catch
            {
                throw new Exception("Błąd pobierania ról: ");
            }
        }

        public IList<Role> GetRoleByName(string name)
        {
            try
            {
                IList<Role> roles = new List<Role>();
                var roleList = roleRepository.GetRoleByName(name);
                foreach (var role in roleList)
                {
                    Role newRole = new Role
                    {
                        Id = role.Id,
                        Name = role.Name,
                        Admin = role.Admin,
                        Business = role.Business,
                        Warehouse = role.Warehouse,
                        Contractors = role.Contractors,
                        Documents = role.Documents
                    };
                    roles.Add(newRole);
                }
                return roles;
            }
            catch
            {
                throw new Exception("Błąd pobierania ról: ");
            }
        }

        public IList<Role> GetRoles()
        {
            try
            {
                IList<Role> roles = new List<Role>();
                var roleList = roleRepository.GetRoles();
                foreach (var role in roleList)
                {
                    Role newRole = new Role
                    {
                        Id = role.Id,
                        Name = role.Name,
                        Admin = role.Admin,
                        Business = role.Business,
                        Warehouse = role.Warehouse,
                        Contractors = role.Contractors,
                        Documents = role.Documents
                    };
                    roles.Add(newRole);
                }
                return roles;
            }
            catch
            {
                throw new Exception("Błąd pobierania ról: ");
            }

        }

        public IList<Role> SearchRoles(List<string> criteria)
        {
            IList<Role> roles = new List<Role>();
            var rolesList = roleRepository.SearchRoles(criteria);
            foreach (var currentRole in rolesList)
            {
                Role role = new Role
                {
                    Id = currentRole.Id,
                    Name = currentRole.Name,
                };
                roles.Add(role);
            }
            return roles;

        }

        public void UpdateRole(Role role)
        {
            try
            {
                roleRepository.UpdateRole(role.Id, role.Name, role.Admin, role.Business, role.Contractors, role.Documents, role.Warehouse);
            }
            catch
            {
                throw new Exception("Błąd aktualizacji ról: ");
            }
        }
    }
}
