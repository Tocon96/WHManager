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

        public async Task CreateNewUser(string name, string password, int roleId)
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    User user = new User
                    {
                        UserName = name,
                        PasswordHash = password,
                        Role = context.Roles.SingleOrDefault(x => x.Id == roleId)
                    };
                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    context.Remove(await context.Users.SingleOrDefaultAsync(x => x.Id == id));
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetUserById(int id)
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    IEnumerable<User> users = context.Users.Include(r => r.Role).ToList().FindAll(x => x.Id == id);
                    return users;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User GetUserByName(string name)
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    User user = context.Users.Include(r => r.Role).FirstOrDefault(x => x.UserName.StartsWith(name));
                    return user;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    IEnumerable<User> users = context.Users.Include(r => r.Role).ToList();
                    return users;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetUsersByName(string name)
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    IEnumerable<User> users = context.Users.Include(r => r.Role).ToList().FindAll(x => x.UserName.StartsWith(name));
                    return users;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetUsersByRole(int roleId)
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    IEnumerable<User> users = context.Users.Include(r => r.Role).ToList().FindAll(x => x.Role.Id == roleId);
                    return users;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateUser(int id, string name, string password, int roleId)
        {
            try
            {
                using (WHManagerDBContext context = _contextFactory.CreateDbContext())
                {
                    User user = context.Users.SingleOrDefault(x => x.Id == id);
                    user.UserName = name;
                    user.PasswordHash = password;
                    user.Role = context.Roles.SingleOrDefault(x => x.Id == roleId);
                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
