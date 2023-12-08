using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp3.Shared
{
    public class HistorialMedico
    {
        [Key]
        public int HistorialID { get; set; }
        public int PacienteID { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string Diagnostico { get; set; } = string.Empty;
        public string Tratamiento { get; set; } = string.Empty;
        public string ResultadosExamenes { get; set; } = string.Empty;

        // Propiedad de navegación para la relación con Pacientes
        [JsonIgnore]
        public Paciente Paciente { get; set; }
        [JsonIgnore]
        public List<AnalisisClinico> AnalisisClinicos { get; set; }

    }


}
