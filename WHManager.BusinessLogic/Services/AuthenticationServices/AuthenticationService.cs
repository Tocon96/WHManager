using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.AuthenticationServices.Interfaces;
using WHManager.BusinessLogic.Services.Interfaces;

namespace WHManager.BusinessLogic.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IPasswordHasher hasher = new PasswordHasher();
        private readonly IUserService userService = new UserService();

        public User Login(string username, string password)
        {
            User user = userService.GetUserByName(username);
            PasswordVerificationResult passwordResult = hasher.VerifyHashedPassword(user.PasswordHash, password);
            if(passwordResult == PasswordVerificationResult.Success)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}