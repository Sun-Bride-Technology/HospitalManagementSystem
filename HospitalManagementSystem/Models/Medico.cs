using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    class Medico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public int Edad { get; set; }
        public string Especialidad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
    public class Doctor
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre")]
        [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "{0}: No se permiten numeros ni caracteres especiales")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Apellido Paterno")]
        [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "{0}: No se permiten numeros ni caracteres especiales")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Apellido Materno")]
        [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "{0}: No se permiten numeros ni caracteres especiales")]
        public string MotherLastName { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(1, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Genero")]
        [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "{0}: No se permiten numeros ni caracteres especiales")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Edad")]
        public int Age { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(10, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 10)]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "{0}: Solo se permiten numeros")]
        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Trabajo")]
        public int Job { get; set; }
    }
}
