using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRest.Models;
using ApiRest.Data;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly CatalogosDbContext _context;

        public CatalogosController(CatalogosDbContext context)
        {
            _context = context;
        }

        // GET: api/Catalogos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalogos>>> GetCatalogos()
        {
            return await _context.Catalogos.ToListAsync();
        }

        // GET: api/Catalogos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Catalogos>> GetCatalogos(int id)
        {
            var catalogos = await _context.Catalogos.FindAsync(id);

            if (catalogos == null)
            {
                return NotFound();
            }

            return catalogos;
        }

        // PUT: api/Catalogos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<IActionResult> PutCatalogos(int id, [FromBody] string nuevaDescripcion)
        {
            var catalogo = await _context.Catalogos.FindAsync(id);

            if (catalogo == null)
            {
                return NotFound();
            }

           
            catalogo.Descripcion = nuevaDescripcion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogosExists(id))
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


        // POST: api/Catalogos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Catalogos>> PostCatalogos(Catalogos catalogos)
        {
            _context.Catalogos.Add(catalogos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogos", new { id = catalogos.Id }, catalogos);
        }

        // DELETE: api/Catalogos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogos(int id)
        {
            var catalogos = await _context.Catalogos.FindAsync(id);
            if (catalogos == null)
            {
                return NotFound();
            }

            _context.Catalogos.Remove(catalogos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatalogosExists(int id)
        {
            return _context.Catalogos.Any(e => e.Id == id);
        }
    }
}
