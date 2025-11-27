using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2025.BE.Data;
using Proyecto2025.BE.Models;

namespace Proyecto2025.BE.Controllers
{
    //
    [ApiController]
    [Route("api/[controller]")]
    public class MateriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MateriasController(AppDbContext context)
        {
            _context = context;
        }

        // GET /Materias
        [HttpGet]
        public async Task<IActionResult> GetMaterias()
        {
            var materias = await _context.Materias.ToListAsync();
            return Ok(materias);
        }

        // GET /Materias/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMateria(int id)
        {
            var materia = await _context.Materias.FindAsync(id);

            if (materia == null)
                return NotFound();

            return Ok(materia);
        }

        // POST /Materias
        [HttpPost]
        public async Task<IActionResult> CrearMateria([FromBody] Materia materia)
        {
            _context.Materias.Add(materia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMateria), new { id = materia.Id }, materia);
        }

        // PUT /Materias/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarMateria(int id, [FromBody] Materia materia)
        {
            if (id != materia.Id)
                return BadRequest();

            _context.Entry(materia).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE /Materias/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarMateria(int id)
        {
            var materia = await _context.Materias.FindAsync(id);

            if (materia == null)
                return NotFound();

            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
