using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafetyTourismAPI.Data;
using SafetyTourismAPI.Models;

namespace SafetyTourismAPI.Controllers
{
    [Route("api/Surtos")]
    [ApiController]
    public class SurtosController : ControllerBase
    {
        private readonly SafetyTourismAPIContext _context;

        public SurtosController(SafetyTourismAPIContext context)
        {
            _context = context;
        }

        // GET: api/Surtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Surtos>>> GetSurtos()
        {
            return await _context.Surtos.ToListAsync();
        }

        [Route("~/api/Virus/{virus}/Surtos")]
        public IQueryable<Surtos> GetSurtosByVirus(long virus)
        {
            return _context.Surtos.Include(c => c.Virus).Where(c => c.VirusID == virus);
        }

        // GET: api/Surtos/5

        [Route("~/api/Pais/{pais}/Surtos")]
        public IQueryable<Surtos> GetSurtosByPais(long pais)
        {
            return _context.Surtos.Include(c => c.Zona).Include(c => c.Pais)
                .Where(c => c.Id == pais);
        }

        // NEW GET: Obter informação sobre todos os surtos ativos associados ao vírus referido
        [Route("~/api/Surtos/Virus/{Id}")]
        public IQueryable<Surtos> GetVirusById(long Id)
        {
            return _context.Surtos.Include(s => s.Virus).Include(s => s.Zona).Where(s => s.VirusID == Id && s.DataFim == null);
        }

        // PUT: api/Surtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurtos(long id, Surtos surtos)
        {
            if (id != surtos.Id)
            {
                return BadRequest();
            }

            _context.Entry(surtos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurtosExists(id))
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
        
        /* PATCH: Alterar a data de fim do surto
        [Route("~/api/surtos/{zonaId}/virusId")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Surtos> patchEntity)
        {
           var entity = _context.Surtos.Find(id);

           if (entity == null)
           {
               return NotFound();
           }

           patchEntity.ApplyTo(entity, ModelState); // Must have Microsoft.AspNetCore.Mvc.NewtonsoftJson installed

           return Ok(entity);
        }
        */

        // POST: api/Surtos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Surtos>> PostSurtos(Surtos surtos)
        {
            Surtos c = await _context.Surtos.SingleOrDefaultAsync(c => c.VirusID == surtos.VirusID && c.Id == surtos.VirusID);
            if (c == null)
            {
                _context.Surtos.Add(surtos);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetSurtos), new { id = surtos.Id }, surtos);
            }
            else
            {
                return Conflict();
            }
        }

        // DELETE: api/Surtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurtos(long id)
        {
            var surtos = await _context.Surtos.FindAsync(id);
            if (surtos == null)
            {
                return NotFound();
            }

            _context.Surtos.Remove(surtos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SurtosExists(long id)
        {
            return _context.Surtos.Any(e => e.Id == id);
        }
    }
}
