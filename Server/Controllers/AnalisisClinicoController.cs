using BlazorApp3.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp3.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp3.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalisisClinicoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnalisisClinicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnalisisClinico>>> GetAnalisisClinicos()
        {
            var lista = await _context.AnalisisClinicos.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{analisisID}")]
        public async Task<ActionResult<AnalisisClinico>> GetSingleAnalisisClinico(int analisisID)
        {
            var analisisClinico = await _context.AnalisisClinicos.FindAsync(analisisID);

            if (analisisClinico == null)
            {
                return NotFound(" :/");
            }

            return Ok(analisisClinico);
        }

        [HttpPost]
        public async Task<ActionResult<AnalisisClinico>> CreateAnalisisClinico(AnalisisClinico analisisClinico)
        {
            _context.AnalisisClinicos.Add(analisisClinico);
            await _context.SaveChangesAsync();

            return Ok(analisisClinico);
        }

        [HttpPut("{analisisID}")]
        public async Task<ActionResult<AnalisisClinico>> UpdateAnalisisClinico(int analisisID, AnalisisClinico analisisClinico)
        {
            var dbObjeto = await _context.AnalisisClinicos.FindAsync(analisisID);
            if (dbObjeto == null)
                return BadRequest("No se encuentra el análisis clínico.");

            dbObjeto.TipoAnalisis = analisisClinico.TipoAnalisis;
            dbObjeto.Resultados = analisisClinico.Resultados;

            await _context.SaveChangesAsync();

            return Ok(dbObjeto);
        }

        [HttpDelete("{analisisID}")]
        public async Task<ActionResult<AnalisisClinico>> DeleteAnalisisClinico(int analisisID)
        {
            var dbObjeto = await _context.AnalisisClinicos.FindAsync(analisisID);
            if (dbObjeto == null)
            {
                return NotFound("No existe el análisis clínico :/");
            }

            _context.AnalisisClinicos.Remove(dbObjeto);
            await _context.SaveChangesAsync();

            return Ok(dbObjeto);
        }
    }
}

