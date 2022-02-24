using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    class Consulta
    {
        public int Id { get; set; }
        public int IdAsignacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Sintomas { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }

    }
}
