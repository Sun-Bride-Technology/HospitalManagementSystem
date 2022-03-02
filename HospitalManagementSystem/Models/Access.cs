﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Rol del usuario")]
        public int Rol { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Estado de la cuenta")]
        public bool State { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "El {0} debe contener al menos {2} caracteres y maximo {1} caracteres", MinimumLength = 5)]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(1000, ErrorMessage = "El {0} debe contener al menos {2} caracteres y maximo {1} caracteres", MinimumLength = 5)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        
    }
    class Rol
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe contener al menos {2} caracteres y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre del rol")]
        public string Name { get; set; }
    }
}