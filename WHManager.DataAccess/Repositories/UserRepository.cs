using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WHManagerDBContextFactory _contextFactory;

        public UserRepository(WHManagerDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void CreateNewUser(string name, string password, int roleId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    User user = new User
                    {
                        UserName = name,
                        PasswordHash = password,
                        Role = context.Roles.SingleOrDefault(x => x.Id == roleId)
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd dodawania użytkownika: ");
                }
            }   
        }

        public void DeleteUser(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.Remove(context.Users.SingleOrDefault(x => x.Id == id));
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd usuwania użytkownika: ");
                }
            }
        }

        public IEnumerable<User> GetUserById(int id)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<User> users = context.Users.Include(r => r.Role).ToList().FindAll(x => x.Id == id);
                    return users;
                }
                catch
                {
                    throw new Exception("Błąd pobierania użytkowników: ");
                }
            }
        }

        public User GetUserByName(string name)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    User user = context.Users.Include(r => r.Role).FirstOrDefault(x => x.UserName.StartsWith(name));
                    return user;
                }
                catch
                {
                    throw new Exception("Błąd pobierania użytkowników: ");
                }
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<User> users = context.Users.Include(r => r.Role).ToList();
                    return users;
                }
                catch
                {
                    throw new Exception("Błąd pobierania użytkowników: ");
                }
            }
        }

        public IEnumerable<User> GetUsersByName(string name)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<User> users = context.Users.Include(r => r.Role).ToList().FindAll(x => x.UserName.StartsWith(name));
                    return users;
                }
                catch
                {
                    throw new Exception("Błąd pobierania użytkowników: ");
                }
            }
        }

        public IEnumerable<User> GetUsersByRole(int roleId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<User> users = context.Users.Include(r => r.Role).ToList().FindAll(x => x.Role.Id == roleId);
                    return users;
                }
                catch
                {
                    throw new Exception("Błąd pobierania użytkowników: ");
                }
            }
            
        }

        public IEnumerable<User> SearchUsers(List<string> criteria)
        {
            using(WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IQueryable<User> users = context.Users.AsQueryable()
                                                                   .Include(x => x.Role);
                if (!string.IsNullOrEmpty(criteria[0]))
                {
                    if (int.TryParse(criteria[0], out int result))
                    {
                        users = users.Where(p => p.Id == result);
                    }
                    else
                    {
                        users = users.Where(p => p.UserName.StartsWith(criteria[0]));
                    }
                }
                if (!string.IsNullOrEmpty(criteria[1]))
                {
                    users = users.Where(p => p.Role.Name.StartsWith(criteria[1]));
                }
                IEnumerable<User> usersList = users.ToList();
                return usersList;
            }
        }

        public void UpdateUser(int id, string name, string password, int roleId)
        {
            using (WHManagerDBContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    User user = context.Users.SingleOrDefault(x => x.Id == id);
                    user.UserName = name;
                    user.PasswordHash = password;
                    user.Role = context.Roles.SingleOrDefault(x => x.Id == roleId);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Błąd aktualizacji użytkownik: ");
                }
            }
        }
    }
}
