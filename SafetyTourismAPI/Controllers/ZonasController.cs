using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafetyTourismAPI.Data;
using SafetyTourismAPI.Models;

namespace SafetyTourismAPI.Controllers
{
    [Route("api/Zonas")]
    [ApiController]
    public class ZonasController : ControllerBase
    {
        private readonly SafetyTourismAPIContext _context;

        public ZonasController(SafetyTourismAPIContext context)
        {
            _context = context;
        }

        // GET: api/Zonas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zona>>> GetZona()
        {
            return await _context.Zonas.ToListAsync();
        }

        // GET: api/Zonas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zona>> GetZona(long id)
        {
            var zona = await _context.Zonas.FindAsync(id);

            if (zona == null)
            {
                return NotFound();
            }

            return zona;
        }

        // PUT: api/Zonas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZona(long id, Zona zona)
        {
            if (id != zona.Id)
            {
                return BadRequest();
            }

            _context.Entry(zona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZonaExists(id))
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

        // POST: api/Zonas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Zona>> PostZona(Zona zona)
        {
            Zona z = await _context.Zonas.SingleOrDefaultAsync(z => z.Name == zona.Name );
            if (z == null)
            {
                _context.Zonas.Add(zona);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetZona), new { id = zona.Name}, zona);
            }
            else
            {
                return Conflict();
            }
        }

        // DELETE: api/Zonas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZona(long id)
        {
            var zona = await _context.Zonas.FindAsync(id);
            if (zona == null)
            {
                return NotFound();
            }

            _context.Zonas.Remove(zona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZonaExists(long id)
        {
            return _context.Zonas.Any(e => e.Id == id);
        }
    }
}
