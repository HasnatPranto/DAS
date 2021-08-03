using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.DTO;
using api.Repository;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly DocDBContext _context;
        private AuthRepository _authRepo = new AuthRepository();
        private readonly IConfiguration _config;
        public AdminsController(DocDBContext context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
        }

        [Authorize]
        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            return await _context.Admins.ToListAsync();
        }

        [Authorize]
        // GET: api/Admins/root
        [HttpGet("{name}")]
        public async Task<ActionResult<Admin>> GetAdmin(string name)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(x=>x.Username==name);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        [Authorize]
        // PUT: api/Admins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(string id, adminDTO adto)
        {
            //if (id != admin.Id)
            if(!AdminExists(id))
            {
                return BadRequest();
            }

            Admin admin = new Admin();
            admin.Id = id;
            admin.Username = adto.Username;
            string pass = adto.Password;
            _ = _authRepo.Register(admin, pass);

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Admins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
       /* [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = admin.Id }, admin);
        }
       */
        
        [HttpPost]
        public async Task<ActionResult<Admin>> Register(adminDTO adto)
        {
          adto.Username = adto.Username.ToLower();

          Admin admin = new Admin();
          admin.Username = adto.Username;
          string pass = adto.Password;
          _ = _authRepo.Register(admin, pass);

          _context.Admins.Add(admin);

          await _context.SaveChangesAsync();

          return Ok(admin);
        }
      
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] adminDTO adto) {

          var admin = _context.Admins.FirstOrDefault(x => x.Username.ToLower() == adto.Username);
      // var admin = await _authRepo.LogIn(adto.Username.ToLower(), adto.Password);
         

         if (admin == null)
            return null;

        // Console.WriteLine(admin.PasswordHash[0] + ", ");

       using (var hmac = new System.Security.Cryptography.HMACSHA512(admin.PasswordSalt))
          {

            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(adto.Password));
            var computedString = Encoding.Unicode.GetString(computedHash, 0, computedHash.Length);
            var storedString = Encoding.Unicode.GetString(admin.PasswordHash, 0, admin.PasswordHash.Length);

            if (!computedString.Equals(storedString))
              return Unauthorized();
            
          }
         

         
         // if (!_authRepo.verifyPassword(adto.Password, admin.PasswordHash, admin.PasswordSalt))
           // return BadRequest(admin.PasswordSalt);

          var claims = new[] {

            new Claim(ClaimTypes.Name,admin.Username),
            new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString())

          };

          var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:token").Value));

          var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

          var tokenDetails = new SecurityTokenDescriptor {

            Subject = new ClaimsIdentity(claims),
            SigningCredentials = credentials,
            IssuedAt = DateTime.Now,
            Expires = DateTime.Now.AddDays(1)

          };

          var tokenHandler = new JwtSecurityTokenHandler();

          var token = tokenHandler.CreateToken(tokenDetails);

          return Ok( new {
            token = tokenHandler.WriteToken(token) 
          });
      }
    [Authorize]
    // DELETE: api/Admins/5
    [HttpDelete("{id}")]
        public async Task<ActionResult<Admin>> DeleteAdmin(string id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();

            return admin;
        }

 
        private bool AdminExists(string id)
        {
            return _context.Admins.Any(e => e.Id == id);
        }
    }
}
