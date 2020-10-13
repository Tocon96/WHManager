using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.AuthenticationServices.Interfaces
{
    public interface IAuthenticationService
    {
        User Login(string username, string password);
    }
}
