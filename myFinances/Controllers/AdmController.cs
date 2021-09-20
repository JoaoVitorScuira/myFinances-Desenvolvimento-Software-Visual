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
    public class AdmController : ControllerBase
    {
        private readonly myFinancesContext _context;

        public AdmController(myFinancesContext context)
        {
            _context = context;
        }

        // GET: api/Adm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adm>>> GetAdm()
        {
            return await _context.Adm.ToListAsync();
        }

        // GET: api/Adm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adm>> GetAdm(int id)
        {
            var adm = await _context.Adm.FindAsync(id);

            if (adm == null)
            {
                return NotFound();
            }

            return adm;
        }

        // PUT: api/Adm/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdm(int id, Adm adm)
        {
            if (id != adm.Id)
            {
                return BadRequest();
            }

            _context.Entry(adm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdmExists(id))
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

        // POST: api/Adm
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adm>> PostAdm(Adm adm)
        {
            _context.Adm.Add(adm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdm", new { id = adm.Id }, adm);
        }

        // DELETE: api/Adm/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdm(int id)
        {
            var adm = await _context.Adm.FindAsync(id);
            if (adm == null)
            {
                return NotFound();
            }

            _context.Adm.Remove(adm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdmExists(int id)
        {
            return _context.Adm.Any(e => e.Id == id);
        }
    }
}
