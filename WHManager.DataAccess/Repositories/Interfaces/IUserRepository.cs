using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateNewUser(string name, string password, int roleId);
        Task UpdateUser(int id, string name, string password, int roleId);
        Task DeleteUser(int id);
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsersByName(string name);
        IEnumerable<User> GetUserById(int id);
        IEnumerable<User> GetUsersByRole(int roleId);
        User GetUserByName(string name);
    }
}
