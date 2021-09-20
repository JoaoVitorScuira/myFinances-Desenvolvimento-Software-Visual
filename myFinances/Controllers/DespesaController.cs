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
    public class DespesaController : ControllerBase
    {
        private readonly myFinancesContext _context;

        public DespesaController(myFinancesContext context)
        {
            _context = context;
        }

        // GET: api/Despesa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Despesa>>> GetDespesa()
        {
            return await _context.Despesa.ToListAsync();
        }

        // GET: api/Despesa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Despesa>> GetDespesa(int id)
        {
            var despesa = await _context.Despesa.FindAsync(id);

            if (despesa == null)
            {
                return NotFound();
            }

            return despesa;
        }

        // PUT: api/Despesa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDespesa(int id, Despesa despesa)
        {
            if (id != despesa.Id)
            {
                return BadRequest();
            }

            _context.Entry(despesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DespesaExists(id))
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

        // POST: api/Despesa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Despesa>> PostDespesa(Despesa despesa)
        {
            _context.Despesa.Add(despesa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDespesa", new { id = despesa.Id }, despesa);
        }

        // DELETE: api/Despesa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDespesa(int id)
        {
            var despesa = await _context.Despesa.FindAsync(id);
            if (despesa == null)
            {
                return NotFound();
            }

            _context.Despesa.Remove(despesa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DespesaExists(int id)
        {
            return _context.Despesa.Any(e => e.Id == id);
        }
    }
}
