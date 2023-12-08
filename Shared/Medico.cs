using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp3.Shared
{
    public class Medico
    {
        public int MedicoID { get; set; }
        public string Nombre { get; set; }=string.Empty;
        public string Especialidad { get; set; }=string.Empty;
        public string HorarioTrabajo { get; set; }=string.Empty;
        public List<Cita> Citas { get; set; }
    }

}
