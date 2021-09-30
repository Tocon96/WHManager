using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        void CreateNewRole(string name, bool isadmin, bool business, bool contractors, bool documents, bool warehouse, bool reports);
        void UpdateRole(int id, string name, bool isadmin, bool business, bool contractors, bool documents, bool warehouse, bool reports);
        void DeleteRole(int id);
        IEnumerable<Role> GetRoles();
        IEnumerable<Role> GetRole(int id);
        IEnumerable<Role> GetRoleByName(string name);
        IEnumerable<Role> SearchRoles(List<string> criteria);
    }
}
