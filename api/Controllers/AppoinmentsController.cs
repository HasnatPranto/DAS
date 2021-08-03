using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.DTO;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppoinmentsController : ControllerBase
    {
        private readonly DocDBContext _context;

        public AppoinmentsController(DocDBContext context)
        {
            _context = context;
        }

        // GET: api/Appoinments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appoinment>>> GetAppoinments()
        {
            return await _context.Appoinments.ToListAsync();
        }

        // GET: api/Appoinments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appoinment>> GetAppoinment(string id)
        {
            var appoinment = await _context.Appoinments.FindAsync(id);

            if (appoinment == null)
            {
                return NotFound();
            }

            return appoinment;
        }

        // PUT: api/Appoinments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppoinment(string id, Appoinment appoinment)
        {
            if (id != appoinment.Id)
            {
                return BadRequest();
            }

            _context.Entry(appoinment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppoinmentExists(id))
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

        // POST: api/Appoinments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Appoinment>> PostAppoinment([FromBody] newAppoinmentDTO appoDTO)
        {
           
            var appoinment = new Appoinment();
            appoinment.PatientName = appoDTO.PatientName;
            appoinment.DoctorName = appoDTO.DoctorName;
            appoinment.AppoinmentDate = appoDTO.AppoinmentDate;
            appoinment.PatientPhoneNumber = appoDTO.PatientPhoneNumber;

            var serial = _context.Appoinments.Count(x => x.DoctorName == appoinment.DoctorName &&
            x.AppoinmentDate == appoinment.AppoinmentDate);

            appoinment.SerialNumber = serial + 1;
     
            _context.Appoinments.Add(appoinment);
            await _context.SaveChangesAsync();

            return Ok(appoinment);

     
        }

        // DELETE: api/Appoinments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Appoinment>> DeleteAppoinment(string id)
        {
            var appoinment = await _context.Appoinments.FindAsync(id);
            if (appoinment == null)
            {
                return NotFound();
            }

            _context.Appoinments.Remove(appoinment);
            await _context.SaveChangesAsync();

            return appoinment;
        }

        private bool AppoinmentExists(string id)
        {
            return _context.Appoinments.Any(e => e.Id == id);
        }
    }
}
