﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafetyTourismAPI.Models;
using SafetyTourismAPI.Data;
using Microsoft.AspNetCore.Cors;

namespace SafetyTourismAPI.Controllers
{
    [EnableCors("MyAllowSpecificOrigins")]
    [Route("api/Recomendacoes")]
    [ApiController]
    public class RecomendacoesController : ControllerBase
    {
        private readonly SafetyTourismAPIContext _context;

        public RecomendacoesController(SafetyTourismAPIContext context)
        {
            _context = context;
        }

        // GET: api/Recomendacoes
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recomendacoe>>> GetRecomendacoe()
        {
            return await _context.Recomendacoes.Include(p => p.Zona).ToListAsync();
        }

        // GET: api/Recomendacoes/5
        [EnableCors]
        [HttpGet("{id}")]
        public async Task<ActionResult<Recomendacoe>> GetRecomendacoe(long id)
        {
            var recomendacoe = await _context.Recomendacoes.FindAsync(id);

            if (recomendacoe == null)
            {
                return NotFound();
            }

            return recomendacoe;
        }
        // PUT: Editar a nota de recomendação    
        // PUT: api/Recomendacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecomendacoe(long id, Recomendacoe recomendacoe)
        {
            if (id != recomendacoe.RecomendacoeId)
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
        // GET: Obter as recomendações válidas para o país referido
        [EnableCors]
        [Route("~/api/paises/{paisId}/recomendacoes")]
        public async Task<IQueryable<Recomendacoe>> GetRecomendacaoByPaisAsync(long paisId)
        {
            Pais pais = await _context.Pais.FindAsync(paisId);
            return _context.Recomendacoes.Include(r => r.Zona).Where(c => c.IdZona == pais.IdZona);
        }

        //public IQueryable<Recomendacoe> GetRecomendacoesByPais(long paisId)
        //{
        //    return _context.Recomendacoe.Include(c => c.Zona).Include(c => c.Pais).Where(c => c.IdPais == paisId);
        //}


        // POST: api/Recomendacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors]
        [HttpPost]
        public async Task<ActionResult<Recomendacoe>> PostRecomendacoe(Recomendacoe recomendacoe)
        {
            Recomendacoe r = await _context.Recomendacoes.SingleOrDefaultAsync(r => r.IdZona == recomendacoe.IdZona);
            if (r == null)
            {
                _context.Recomendacoes.Add(recomendacoe);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetRecomendacoe), new { id = recomendacoe.RecomendacoeId }, recomendacoe);
            }
            else
            {
                return Conflict();
            }
        }

        // DELETE: api/Recomendacoes/5
        [EnableCors]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecomendacoe(long id)
        {
            var recomendacoe = await _context.Recomendacoes.FindAsync(id);
            if (recomendacoe == null)
            {
                return NotFound();
            }

            _context.Recomendacoes.Remove(recomendacoe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecomendacoeExists(long id)
        {
            return _context.Recomendacoes.Any(e => e.RecomendacoeId == id);
        }
    }
}
