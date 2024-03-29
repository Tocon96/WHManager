﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        void CreateAdminUser(string password);
        void DeleteUser(int id);
        void UpdateUser(User user);
        IList<User> GetUsers();
        IList<User> GetUsersByName(string name);
        IList<User> GetUserById(int id);
        IList<User> GetUsersByRole(int roleId);
        IList<User> SearchUsers(List<string> criteria);
        User GetUserByName(string name);
        bool CheckIfAdminExists();
    }
}
