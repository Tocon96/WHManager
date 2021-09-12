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
                string name = role.Name;
                bool isadmin = role.IsAdmin;
                roleRepository.CreateNewRole(name, isadmin);
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
                        IsAdmin = role.IsAdmin
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
                        IsAdmin = role.IsAdmin
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
                        IsAdmin = role.IsAdmin
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
                int id = role.Id;
                string name = role.Name;
                bool isadmin = role.IsAdmin;
                roleRepository.UpdateRole(id, name, isadmin);
            }
            catch
            {
                throw new Exception("Błąd aktualizacji ról: ");
            }
        }
    }
}
