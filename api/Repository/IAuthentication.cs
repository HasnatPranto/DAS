using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository
{
    public interface IAuthentication
    {
        Task<Admin> Register(Admin admin, String password);

        Task<Admin> LogIn(string username, string password);

        Task<bool> UserExists(string username);
    }
}
