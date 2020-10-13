using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task CreateNewRole(string name, bool isadmin);
        Task UpdateRole(int id, string name, bool isadmin);
        Task DeleteRole(int id);
        IEnumerable<Role> GetRoles();
        IEnumerable<Role> GetRole(int id);
        IEnumerable<Role> GetRoleByName(string name);
    }
}
