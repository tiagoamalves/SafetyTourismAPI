using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafetyTourismAPI.Models;

namespace SafetyTourismAPI.Controllers
{
    [Route("api/Virus")]
    [ApiController]
    public class VirusController : ControllerBase
    {
        private readonly Context _context;

        public VirusController(Context context)
        {
            _context = context;
        }

        // GET: api/Virus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Virus>>> GetVirus()
        {
            return await _context.Virus.ToListAsync();
        }

        // GET: api/Virus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Virus>> GetVirus(long id)
        {
            var virus = await _context.Virus.FindAsync(id);

            if (virus == null)
            {
                return NotFound();
            }

            return virus;
        }

        // PUT: api/Virus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVirus(long id, Virus virus)
        {
            if (id != virus.virusID)
            {
                return BadRequest();
            }

            _context.Entry(virus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VirusExists(id))
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

        // POST: api/Virus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Virus>> PostVirus(Virus virus)
        {
            Virus v = await _context.Virus.SingleOrDefaultAsync(v => v.NomeVirus == virus.NomeVirus);
            if (v == null)
            {
                _context.Virus.Add(virus);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetVirus), new { id = virus.virusID }, virus);
            }
            else
            {
                return Conflict();
            }
        }

        // DELETE: api/Virus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVirus(long id)
        {
            var virus = await _context.Virus.FindAsync(id);
            if (virus == null)
            {
                return NotFound();
            }

            _context.Virus.Remove(virus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VirusExists(long id)
        {
            return _context.Virus.Any(e => e.virusID == id);
        }
    }
}
