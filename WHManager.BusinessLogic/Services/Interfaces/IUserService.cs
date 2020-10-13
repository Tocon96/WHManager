using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUser(User user);
        Task DeleteUser(int id);
        Task UpdateUser(User user);
        IList<User> GetUsers();
        IList<User> GetUsersByName(string name);
        IList<User> GetUserById(int id);
        IList<User> GetUsersByRole(int roleId);
        User GetUserByName(string name);
    }
}
