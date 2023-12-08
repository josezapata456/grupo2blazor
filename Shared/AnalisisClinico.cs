using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp3.Shared
{
    
    public class AnalisisClinico
    {
        [Key]
        public int AnalisisID { get; set; }
        public int HistorialID { get; set; }
        public string TipoAnalisis { get; set; } = string.Empty;
        public string Resultados { get; set; } = string.Empty;

        [JsonIgnore]
        public HistorialMedico HistorialMedico { get; set; }
    }

}
