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
    public class PacienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PacienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Paciente>>> GetPacientes()
        {
            var lista = await _context.Pacientes.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetSinglePaciente(int id)
        {
            var miobjeto = await _context.Pacientes.FirstOrDefaultAsync(ob => ob.PacienteID == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }

        [HttpPost]
        public async Task<ActionResult<Paciente>> CreatePaciente(Paciente objeto)
        {
            _context.Pacientes.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(objeto);
        }

        [HttpPut("{pacienteID}")]
        public async Task<ActionResult<Paciente>> UpdatePaciente(int pacienteID, Paciente objeto)
        {
            var dbObjeto = await _context.Pacientes.FindAsync(pacienteID);
            if (dbObjeto == null)
                return BadRequest("No se encuentra el paciente.");

            dbObjeto.Nombre = objeto.Nombre;
            dbObjeto.FechaNacimiento = objeto.FechaNacimiento;
            dbObjeto.Genero = objeto.Genero;
            dbObjeto.Direccion = objeto.Direccion;
            dbObjeto.Telefono = objeto.Telefono;
            dbObjeto.SeguroMedico = objeto.SeguroMedico;

            await _context.SaveChangesAsync();

            return Ok(dbObjeto);
        }

        [HttpDelete("{pacienteID}")]
        public async Task<ActionResult<Paciente>> DeletePaciente(int pacienteID)
        {
            var dbObjeto = await _context.Pacientes.FindAsync(pacienteID);
            if (dbObjeto == null)
            {
                return NotFound("No existe el paciente :/");
            }

            _context.Pacientes.Remove(dbObjeto);
            await _context.SaveChangesAsync();

            return Ok(dbObjeto);
        }
    }
}



