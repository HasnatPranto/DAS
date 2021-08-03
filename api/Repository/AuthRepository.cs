using api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Repository
{
    public class AuthRepository : IAuthentication
    {
        private DocDBContext _context;
     
        public AuthRepository(DocDBContext dbContext) {
            _context = dbContext;
        }

        public AuthRepository()
        {
        }

        public async Task<Admin> LogIn(string username, string password)
        {
          var admin = _context.Admins.FirstOrDefault(x => x.Username.ToLower() == username);

            if (admin == null)
                return null;

            if (!verifyPassword(password, admin.PasswordHash, admin.PasswordSalt))
                return null;

            return admin;
        }

        public bool verifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) {

                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                
        if (computedHash.Equals(passwordHash))
                    return true;
                else
                    return false;
            }
        }

        public async Task<Admin> Register(Admin admin, string password)
        {
            byte[] passwordHash, passwordSalt;
            createPasswordHash(password, out passwordHash, out passwordSalt);
           
            admin.PasswordHash = passwordHash;
            admin.PasswordSalt = passwordSalt;
           
      
            return admin;

        }

        private void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {

                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }
        }

        public async Task<bool> UserExists(string username)
        {
            return _context.Admins.Any(x=> x.Username == username);
        }
    }
}
