using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    class Paciente
    {
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public int Edad { get; set; }
        public char Sexo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
