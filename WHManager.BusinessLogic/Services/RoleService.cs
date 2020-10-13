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

        public async Task AddRole(Role role)
        {
            try
            {
                string name = role.Name;
                bool isadmin = role.IsAdmin;
                await roleRepository.CreateNewRole(name, isadmin);
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
                await roleRepository.DeleteRole(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Role> GetRoleById(int id)
        {
            IList<Role> roles = new List<Role>();
            var roleList = roleRepository.GetRole(id);
            foreach(var role in roleList)
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

        public IList<Role> GetRoleByName(string name)
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
            catch (Exception)
            {
                throw;
            }

        }

        public async Task UpdateRole(Role role)
        {
            try
            {
                int id = role.Id;
                string name = role.Name;
                bool isadmin = role.IsAdmin;
                await roleRepository.UpdateRole(id, name, isadmin);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
