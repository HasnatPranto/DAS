using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using api.DTO;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DocDBContext _context;

        public DoctorsController(DocDBContext context)
        {
            _context = context;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(string id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Doctor>> GetDoctor_name(string name)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(x=>x.Name == name);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }



        [Authorize]
        // PUT: api/Doctors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(string id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        [Authorize]
        // POST: api/Doctors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor([FromBody] docDTO doctor)
        {
            Doctor doc = new Doctor();
            doc.Name = doctor.Name;
            doc.MedicalDegree = doctor.MedicalDegree;
            doc.Speciality = doctor.Speciality;
            doc.Schedule = doctor.Schedule;
            _context.Doctors.Add(doc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = doc.Id }, doc);
        }

    [Authorize]
    // DELETE: api/Doctors/5
    [HttpDelete("{id}")]
        public async Task<ActionResult<Doctor>> DeleteDoctor(string id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return doctor;
        }

        private bool DoctorExists(string id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
