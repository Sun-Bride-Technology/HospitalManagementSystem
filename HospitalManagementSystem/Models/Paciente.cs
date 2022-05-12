using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    class Paciente
    {
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre")]
        [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "{0}: No se permiten numeros ni caracteres especiales")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Apellido Paterno")]
        [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "{0}: No se permiten numeros ni caracteres especiales")]
        public string ApPaterno { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Apellido Materno")]
        [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "{0}: No se permiten numeros ni caracteres especiales")]
        public string ApMaterno { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Edad")]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "Solo se permiten numeros")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Genero")]
        [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "{0}: No se permiten numeros ni caracteres especiales")]
        public char Sexo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(10, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Telefono")]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "{0}: Solo se permiten numeros")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(18, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "CURP")]
        public string CURP { get; set; }
    }
}
