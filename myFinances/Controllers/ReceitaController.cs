using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myFinances.Data;
using myFinances.models;

namespace myFinances.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly myFinancesContext _context;

        public ReceitaController(myFinancesContext context)
        {
            _context = context;
        }

        // GET: api/Receita
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receita>>> GetReceita()
        {
            return await _context.Receita.ToListAsync();
        }

        // GET: api/Receita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receita>> GetReceita(int id)
        {
            var receita = await _context.Receita.FindAsync(id);

            if (receita == null)
            {
                return NotFound();
            }

            return receita;
        }

        // PUT: api/Receita/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceita(int id, Receita receita)
        {
            if (id != receita.Id)
            {
                return BadRequest();
            }

            _context.Entry(receita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceitaExists(id))
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

        // POST: api/Receita
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Receita>> PostReceita(Receita receita)
        {
            _context.Receita.Add(receita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceita", new { id = receita.Id }, receita);
        }

        // DELETE: api/Receita/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceita(int id)
        {
            var receita = await _context.Receita.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }

            _context.Receita.Remove(receita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReceitaExists(int id)
        {
            return _context.Receita.Any(e => e.Id == id);
        }
    }
}
