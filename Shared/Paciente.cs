
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp3.Shared
{
    public class Paciente
    {        

        public int PacienteID { get; set; }
        public string Nombre { get; set; } = string.Empty;
            public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string SeguroMedico { get; set; } = string.Empty;
        
        [JsonIgnore]
        public List<HistorialMedico> HistorialesMedicos { get; set; }
        [JsonIgnore]
        public List<Cita> Citas { get; set; }

    }

    }

