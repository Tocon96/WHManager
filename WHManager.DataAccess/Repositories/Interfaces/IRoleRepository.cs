﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        void CreateNewRole(string name, bool isadmin);
        void UpdateRole(int id, string name, bool isadmin);
        void DeleteRole(int id);
        IEnumerable<Role> GetRoles();
        IEnumerable<Role> GetRole(int id);
        IEnumerable<Role> GetRoleByName(string name);
    }
}
