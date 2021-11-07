﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.AuthenticationServices;
using WHManager.BusinessLogic.Services.AuthenticationServices.Interfaces;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository = new UserRepository(new DataAccess.WHManagerDBContextFactory());
        private readonly IRoleService roleService = new RoleService();
        private readonly IPasswordHasher hasher = new PasswordHasher();

        public void AddUser(User user)
        {
            try
            {
                string name = user.UserName;
                string password = hasher.HashPassword(user.PasswordHash);
                int role = user.Role.Id;
                userRepository.CreateNewUser(name, password, role);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                 userRepository.DeleteUser(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                int id = user.Id;
                string name = user.UserName;
                string password = hasher.HashPassword(user.PasswordHash);
                int role = user.Role.Id;
                userRepository.UpdateUser(id, name, password, role);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<User> GetUserById(int id)
        {
            IList<User> users = new List<User>();
            var userList = userRepository.GetUserById(id);
            foreach(var user in userList)
            {
                IList<Role> roleList = roleService.GetRoleById(user.Role.Id);
                Role role = roleList[0];
                User newUser = new User
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    PasswordHash = user.PasswordHash,
                    Role = role
                };
                users.Add(newUser);
            }
            return users;
        }

        public IList<User> GetUsers()
        {
            IList<User> users = new List<User>();
            var userList = userRepository.GetUsers();
            foreach (var user in userList)
            {
                IList<Role> roleList = roleService.GetRoleById(user.Role.Id);
                Role role = roleList[0];
                User newUser = new User
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    PasswordHash = user.PasswordHash,
                    Role = role
                };
                users.Add(newUser);
            }
            return users;
        }

        public IList<User> GetUsersByName(string name)
        {
            IList<User> users = new List<User>();
            var userList = userRepository.GetUsersByName(name);
            foreach (var user in userList)
            {
                IList<Role> roleList = roleService.GetRoleById(user.Role.Id);
                Role role = roleList[0];
                User newUser = new User
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    PasswordHash = user.PasswordHash,
                    Role = role
                };
                users.Add(newUser);
            }
            return users;
        }

        public IList<User> GetUsersByRole(int roleId)
        {
            IList<User> users = new List<User>();
            var userList = userRepository.GetUsersByRole(roleId);
            foreach (var user in userList)
            {
                IList<Role> roleList = roleService.GetRoleById(user.Role.Id);
                Role role = roleList[0];
                User newUser = new User
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    PasswordHash = user.PasswordHash,
                    Role = role
                };
                users.Add(newUser);
            }
            return users;
        }

        public User GetUserByName(string name)
        {
            var user = userRepository.GetUserByName(name);
            if(user != null)
            {
                IList<Role> roles = roleService.GetRoleById(user.Role.Id);
                Role role = roles[0];
                User newUser = new User
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    PasswordHash = user.PasswordHash,
                    Role = role
                };
                return newUser;
            }
            else
            {
                return null;
            }
        }

        public IList<User> SearchUsers(List<string> criteria)
        {
            IList<User> users = new List<User>();
            var usersList = userRepository.SearchUsers(criteria);
            foreach(var currentUser in usersList)
            {
                IList<Role> roles = roleService.GetRoleById(currentUser.Role.Id);
                Role role = roles[0];
                User user = new User
                {
                    Id = currentUser.Id,
                    UserName = currentUser.UserName,
                    PasswordHash = currentUser.PasswordHash,
                    Role = role
                };
                users.Add(user);
            }
            return users;
        }

        public void CreateAdminUser(string password)
        {
            userRepository.CreateAdminUser(hasher.HashPassword(password));
        }

        public bool CheckIfAdminExists()
        {
            return userRepository.CheckIfAdminExists();
        }
    }
}
