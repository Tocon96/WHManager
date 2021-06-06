using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void CreateNewUser(string name, string password, int roleId);
        void UpdateUser(int id, string name, string password, int roleId);
        void DeleteUser(int id);
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsersByName(string name);
        IEnumerable<User> GetUserById(int id);
        IEnumerable<User> GetUsersByRole(int roleId);
        IEnumerable<User> SearchUsers(List<string> criteria);
        User GetUserByName(string name);
    }
}
