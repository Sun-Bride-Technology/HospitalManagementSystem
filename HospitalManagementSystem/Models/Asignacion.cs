using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    class Asignacion
    {
        public int IdAsignacion { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int Cama { get; set; }
        public DateTime FechaAlta { get; set; }
        public Nullable<DateTime> FechaBaja { get; set; }
    }
}
