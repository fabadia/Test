using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiliaisController : ControllerBase
    {
        private readonly Context _context;

        public FiliaisController(Context context)
        {
            _context = context;
        }

        // GET: api/Filiais
        [HttpGet]
        public IEnumerable<object> GetFiliais()
        {
            return _context.Filiais.Select(x => new {
                x.Id,
                x.Nome
            });
        }

        // GET: api/Filiais/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var filial = await _context.Filiais
                .Where(x => x.Id == id)
                .Select(x => new {
                    x.Id,
                    x.Nome
                })
                .OrderBy(x => x.Nome)
                .ToListAsync();

            if (filial == null)
            {
                return NotFound();
            }

            return Ok(filial);
        }

        // PUT: api/Filiais/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilial([FromRoute] int id, [FromBody] Filial filial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != filial.Id)
            {
                return BadRequest();
            }

            _context.Entry(filial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilialExists(id))
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

        // POST: api/Filiais
        [HttpPost]
        public async Task<IActionResult> PostFilial([FromBody] Filial filial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Filiais.Add(filial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilial", new { id = filial.Id }, filial);
        }

        // DELETE: api/Filiais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var filial = await _context.Filiais.FindAsync(id);
            if (filial == null)
            {
                return NotFound();
            }

            _context.Filiais.Remove(filial);
            await _context.SaveChangesAsync();

            return Ok(filial);
        }

        private bool FilialExists(int id)
        {
            return _context.Filiais.Any(e => e.Id == id);
        }
    }
}