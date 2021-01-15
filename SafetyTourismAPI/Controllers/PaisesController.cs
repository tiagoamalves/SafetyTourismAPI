using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafetyTourismAPI.Data;
using SafetyTourismAPI.Models;

namespace SafetyTourismAPI.Controllers
{
    [EnableCors("MyAllowSpecificOrigins")]
    [Route("api/Paises")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly SafetyTourismAPIContext _context;

        public PaisesController(SafetyTourismAPIContext context)
        {
            _context = context;
        }

        // GET: api/Paises
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPais()
        {
            return await _context.Pais.Include(p => p.Zona).ToListAsync();
        }

        // GET: api/Paises/5
        [EnableCors]
        [HttpGet("{id}")]
        //public IQueryable<Pais> GetPaisById(long id)
        //{
        //    return _context.Pais.Include(p => p.IdZona).Where(p => p.Id == id);
        //}

        public async Task<ActionResult<Pais>> GetPais(long id)
        {
            var pais = await _context.Pais.FindAsync(id);

            if (pais == null)
            {
                return NotFound();
            }

            return pais;
        }

        // PUT: api/Paises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPais(long id, Pais pais)
        {
            if (id != pais.Id)
            {
                return BadRequest();
            }

            _context.Entry(pais).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisExists(id))
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

        // POST: api/Paises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors]
        [HttpPost]
        public async Task<ActionResult<Pais>> PostPais(Pais pais)
        {
            Pais p = await _context.Pais.SingleOrDefaultAsync(p => p.IdZona == pais.IdZona);
            if (p == null)
            {
                _context.Pais.Add(pais);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPais), new { id = pais.Id }, pais);
            }
            else
            {
                return Conflict();
            }

            //_context.Pais.Add(pais);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction(nameof(GetPais), new { id = pais.Id }, pais);
        }



        // DELETE: api/Paises/5
        [EnableCors]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePais(long id)
        {
            var pais = await _context.Pais.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }

            _context.Pais.Remove(pais);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaisExists(long id)
        {
            return _context.Pais.Any(e => e.Id == id);
        }
    }
}
