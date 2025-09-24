using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Models;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonasController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 GET con OData habilitado
        // Ejemplo: /api/personas?$filter=id eq 3&$orderby=edad desc
        [HttpGet]
        [EnableQuery]
        [Authorize]
        public IQueryable<Personas> GetPersonas()
        {
            return _context.Personas;
        }

        // 🔹 GET por ID específico (normal)
        [HttpGet("{id}")]
        [EnableQuery]
        [Authorize]
        public async Task<ActionResult<Personas>> GetPersonas(int id)
        {
            var personas = await _context.Personas.FindAsync(id);

            if (personas == null)
            {
                return NotFound();
            }

            return personas;
        }

        // PUT: api/Personas/5
        [HttpPut("{id}")]
        [EnableQuery]
        [Authorize]
        public async Task<IActionResult> PutPersonas(int id, Personas personas)
        {
            if (id != personas.id)
            {
                return BadRequest();
            }

            _context.Entry(personas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonasExists(id))
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

        // POST: api/Personas
        [HttpPost]
        [EnableQuery]
        [Authorize]
        public async Task<ActionResult<Personas>> PostPersonas(Personas personas)
        {
            // 🔹 Validar que el objeto no sea nulo
            if (personas == null)
            {
                return BadRequest(new { mensaje = "El cuerpo de la solicitud no puede estar vacío." });
            }

            // 🔹 Validar RUT
            if (string.IsNullOrWhiteSpace(personas.Rut))
            {
                return BadRequest(new { mensaje = "El RUT es obligatorio." });
            }

            var existeRut = await _context.Personas.AnyAsync(p => p.Rut == personas.Rut);
            if (existeRut)
            {
                return BadRequest(new { mensaje = "El RUT ya está registrado, no se puede duplicar." });
            }

            // 🔹 Validar nombre
            if (string.IsNullOrWhiteSpace(personas.Nombre))
            {
                return BadRequest(new { mensaje = "El nombre es obligatorio." });
            }

            // 🔹 Validar sexo (solo M o F por ejemplo)
            if (string.IsNullOrWhiteSpace(personas.Sexo) ||
                !(personas.Sexo.ToUpper() == "M" || personas.Sexo.ToUpper() == "F"))
            {
                return BadRequest(new { mensaje = "El sexo debe ser 'M' o 'F'." });
            }

            // 🔹 Validar edad
            if (personas.edad <= 0)
            {
                return BadRequest(new { mensaje = "La edad debe ser un número mayor a 0." });
            }

            // 🔹 Insertar si todo es válido
            _context.Personas.Add(personas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonas", new { id = personas.id }, personas);
        }


        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        [EnableQuery]
        [Authorize]
        public async Task<IActionResult> DeletePersonas(string id)
        {
            // 🔹 Validar que sea un número
            if (!int.TryParse(id, out int idPersona))
            {
                return BadRequest(new { mensaje = "El ID debe ser un número válido." });
            }

            var personas = await _context.Personas.FindAsync(idPersona);
            if (personas == null)
            {
                return NotFound(new { mensaje = "La persona no existe." });
            }

            _context.Personas.Remove(personas);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "La persona fue eliminada correctamente." });
        }



        private bool PersonasExists(int id)
        {
            return _context.Personas.Any(e => e.id == id);
        }
    }
}
