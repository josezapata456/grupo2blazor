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
    public class CitaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CitaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cita>>> GetCitas()
        {
            var lista = await _context.Citas.Include(c => c.Paciente).Include(c => c.Medico).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cita>> GetSingleCita(int id)
        {
            var miobjeto = await _context.Citas.Include(c => c.Paciente).Include(c => c.Medico)
                                              .FirstOrDefaultAsync(ob => ob.CitaID == id);

            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }

        [HttpPost]
        public async Task<ActionResult<Cita>> CreateCita(Cita objeto)
        {
            _context.Citas.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(objeto);
        }

        [HttpPut("{citaID}")]
        public async Task<ActionResult<Cita>> UpdateCita(int citaID, Cita objeto)
        {
            var dbObjeto = await _context.Citas.FindAsync(citaID);
            if (dbObjeto == null)
                return BadRequest("No se encuentra la cita.");

            dbObjeto.PacienteID = objeto.PacienteID;
            dbObjeto.MedicoID = objeto.MedicoID;
            dbObjeto.Fecha = objeto.Fecha;
            dbObjeto.Hora = objeto.Hora;
            dbObjeto.Motivo = objeto.Motivo;

            await _context.SaveChangesAsync();

            return Ok(dbObjeto);
        }

        [HttpDelete("{citaID}")]
        public async Task<ActionResult<Cita>> DeleteCita(int citaID)
        {
            var dbObjeto = await _context.Citas.FindAsync(citaID);
            if (dbObjeto == null)
            {
                return NotFound("No existe la cita :/");
            }

            _context.Citas.Remove(dbObjeto);
            await _context.SaveChangesAsync();

            return Ok(dbObjeto);
        }
    }
}

