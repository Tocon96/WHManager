using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IRoleService
    {
        void AddRole(Role role);
        void CreateAdminRole();
        void DeleteRole(int id);
        void UpdateRole(Role role);
        IList<Role> GetRoles();
        IList<Role> GetRoleById(int id);
        IList<Role> GetRoleByName(string name);
        IList<Role> SearchRoles(List<string> criteria);
        bool CheckIfAdminRoleExists();
    }
}
