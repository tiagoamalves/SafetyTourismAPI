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
    [Route("api/Zonas")]
    [ApiController]
    public class ZonasController : ControllerBase
    {
        private readonly Context _context;

        public ZonasController(Context context)
        {
            _context = context;
        }

        // GET: api/Zonas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zona>>> GetZona()
        {
            return await _context.Zona.ToListAsync();
        }

        // GET: api/Zonas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zona>> GetZona(long id)
        {
            var zona = await _context.Zona.FindAsync(id);

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
            _context.Zona.Add(zona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZona", new { id = zona.Id }, zona);
        }

        // DELETE: api/Zonas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZona(long id)
        {
            var zona = await _context.Zona.FindAsync(id);
            if (zona == null)
            {
                return NotFound();
            }

            _context.Zona.Remove(zona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZonaExists(long id)
        {
            return _context.Zona.Any(e => e.Id == id);
        }
    }
}
