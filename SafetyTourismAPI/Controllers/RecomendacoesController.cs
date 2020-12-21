﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafetyTourismAPI.Models;

namespace SafetyTourismAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecomendacoesController : ControllerBase
    {
        private readonly Context _context;

        public RecomendacoesController(Context context)
        {
            _context = context;
        }

        // GET: api/Recomendacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recomendacoe>>> GetRecomendacoe()
        {
            return await _context.Recomendacoe.ToListAsync();
        }

        // GET: api/Recomendacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recomendacoe>> GetRecomendacoe(long id)
        {
            var recomendacoe = await _context.Recomendacoe.FindAsync(id);

            if (recomendacoe == null)
            {
                return NotFound();
            }

            return recomendacoe;
        }

        // PUT: api/Recomendacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecomendacoe(long id, Recomendacoe recomendacoe)
        {
            if (id != recomendacoe.Id)
            {
                return BadRequest();
            }

            _context.Entry(recomendacoe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecomendacoeExists(id))
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

        // POST: api/Recomendacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recomendacoe>> PostRecomendacoe(Recomendacoe recomendacoe)
        {
            _context.Recomendacoe.Add(recomendacoe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecomendacoe", new { id = recomendacoe.Id }, recomendacoe);
        }

        // DELETE: api/Recomendacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecomendacoe(long id)
        {
            var recomendacoe = await _context.Recomendacoe.FindAsync(id);
            if (recomendacoe == null)
            {
                return NotFound();
            }

            _context.Recomendacoe.Remove(recomendacoe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecomendacoeExists(long id)
        {
            return _context.Recomendacoe.Any(e => e.Id == id);
        }
    }
}