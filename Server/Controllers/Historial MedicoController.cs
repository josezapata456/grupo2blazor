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
    public class HistorialMedicoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HistorialMedicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<HistorialMedico>>> GetHistorialesMedicos()
        {
            var lista = await _context.HistorialesMedicos.Include(h => h.Paciente).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialMedico>> GetSingleHistorialMedico(int id)
        {
            var miobjeto = await _context.HistorialesMedicos.Include(h => h.Paciente)
                                                            .FirstOrDefaultAsync(ob => ob.HistorialID == id);

            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }

        [HttpPost]
        public async Task<ActionResult<HistorialMedico>> CreateHistorialMedico(HistorialMedico objeto)
        {
            _context.HistorialesMedicos.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(objeto);
        }

        [HttpPut("{historialID}")]
        public async Task<ActionResult<HistorialMedico>> UpdateHistorialMedico(int historialID, HistorialMedico objeto)
        {
            var dbObjeto = await _context.HistorialesMedicos.FindAsync(historialID);
            if (dbObjeto == null)
                return BadRequest("No se encuentra el historial médico.");

            dbObjeto.PacienteID = objeto.PacienteID;
            dbObjeto.FechaConsulta = objeto.FechaConsulta;
            dbObjeto.Diagnostico = objeto.Diagnostico;
            dbObjeto.Tratamiento = objeto.Tratamiento;
            dbObjeto.ResultadosExamenes = objeto.ResultadosExamenes;

            await _context.SaveChangesAsync();

            return Ok(dbObjeto);
        }

        [HttpDelete("{historialID}")]
        public async Task<ActionResult<HistorialMedico>> DeleteHistorialMedico(int historialID)
        {
            var dbObjeto = await _context.HistorialesMedicos.FindAsync(historialID);
            if (dbObjeto == null)
            {
                return NotFound("No existe el historial médico :/");
            }

            _context.HistorialesMedicos.Remove(dbObjeto);
            await _context.SaveChangesAsync();

            return Ok(dbObjeto);
        }
    }
}

