using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2025.BE.Data;
using Proyecto2025.BE.Models;

namespace Proyecto2025.BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InscripcionesController(AppDbContext context)
        {
            _context = context;
        }

        // 1. INSCRIBIR (POST)
        // Recibe: { "alumnoId": 1, "materiaId": 5 }
        [HttpPost]
        public async Task<ActionResult> Inscribir(Inscripciones inscripcion)
        {
            // Validar que no esté inscrito ya (Opcional pero recomendado)
            bool yaExiste = await _context.Inscripciones
                .AnyAsync(x => x.AlumnoId == inscripcion.AlumnoId && x.MateriaId == inscripcion.MateriaId);

            if (yaExiste)
            {
                return BadRequest("El alumno ya está inscrito en esa materia.");
            }

            _context.Inscripciones.Add(inscripcion);
            await _context.SaveChangesAsync();
            return Ok("Inscripción exitosa");
        }

        // 2. VER MATERIAS DE UN ALUMNO (GET)
        // Ruta: api/Inscripciones/alumno/5
        [HttpGet("alumno/{alumnoId}")]
        public async Task<ActionResult<List<Materia>>> ObtenerMateriasPorAlumno(int alumnoId)
        {
            // Esto es LINQ avanzado: "Traduce" de inscripciones a materias
            var materias = await _context.Inscripciones
                .Where(i => i.AlumnoId == alumnoId)
                .Select(i => i.Materia) // ¡Aquí hacemos el salto mágico!
                .ToListAsync();

            return materias;
        }

        // 3. DAR DE BAJA (DELETE)
        // Ruta: api/Inscripciones?alumnoId=1&materiaId=5
        [HttpDelete]
        public async Task<IActionResult> DarDeBaja(int alumnoId, int materiaId)
        {
            var inscripcion = await _context.Inscripciones
                .FirstOrDefaultAsync(x => x.AlumnoId == alumnoId && x.MateriaId == materiaId);

            if (inscripcion == null) return NotFound("No se encontró la inscripción");

            _context.Inscripciones.Remove(inscripcion);
            await _context.SaveChangesAsync();
            return Ok("Eliminado");
        }
    }
}