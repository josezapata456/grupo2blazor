using BlazorApp3.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp3.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp3.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MedicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Medico>>> GetMedicos()
        {
            var lista = await _context.Medicos.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medico>> GetSingleMedico(int id)
        {
            var miobjeto = await _context.Medicos.FirstOrDefaultAsync(ob => ob.MedicoID == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }

        [HttpPost]
        public async Task<ActionResult<Medico>> CreateMedico(Medico objeto)
        {
            _context.Medicos.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(objeto);
        }

        [HttpPut("{medicoID}")]
        public async Task<ActionResult<Medico>> UpdateMedico(int medicoID, Medico objeto)
        {
            var dbObjeto = await _context.Medicos.FindAsync(medicoID);
            if (dbObjeto == null)
                return BadRequest("No se encuentra el médico.");

            dbObjeto.Nombre = objeto.Nombre;
            dbObjeto.Especialidad = objeto.Especialidad;
            dbObjeto.HorarioTrabajo = objeto.HorarioTrabajo;

            await _context.SaveChangesAsync();

            return Ok(dbObjeto);
        }

        [HttpDelete("{medicoID}")]
        public async Task<ActionResult<Medico>> DeleteMedico(int medicoID)
        {
            var dbObjeto = await _context.Medicos.FindAsync(medicoID);
            if (dbObjeto == null)
            {
                return NotFound("No existe el médico :/");
            }

            _context.Medicos.Remove(dbObjeto);
            await _context.SaveChangesAsync();

            return Ok(dbObjeto);
        }
    }
}

