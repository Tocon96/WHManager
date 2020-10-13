using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IRoleService
    {
        Task AddRole(Role role);
        Task DeleteRole(int id);
        Task UpdateRole(Role role);
        IList<Role> GetRoles();
        IList<Role> GetRoleById(int id);
        IList<Role> GetRoleByName(string name);
    }
}
