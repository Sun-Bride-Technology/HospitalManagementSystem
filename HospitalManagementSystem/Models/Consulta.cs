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
        public string Allocation { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public System.DateTime ConsultationDate { get; set; }
    }

    class DetalleConsulta
    {
        public int Id { get; set; }
        public string Allocation { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public System.DateTime ConsultationDate { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
    }
}
