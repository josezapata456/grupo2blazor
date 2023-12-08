using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp3.Shared
{
    public class Cita
    {
        public int CitaID { get; set; }
        public int PacienteID { get; set; }
        public int MedicoID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Motivo { get; set; } = string.Empty;

        // Propiedades de navegación para las relaciones con Pacientes y Medicos
        [JsonIgnore]
        public Paciente Paciente { get; set; }
        [JsonIgnore]
        public Medico Medico { get; set; } 
    }

}
