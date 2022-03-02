using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Security;

namespace HospitalManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string email = txtUser.Text;
            string password = txtPassword.Text;

            //Obtención de Usuario de la Base de Datos
            int id = 1;
            int rol = 1;
            bool state = true;

            //Validación del Modelo
            User user = new User { Id = id, Rol = rol, State = state, Email = email, Password = password};

            ValidationContext context = new ValidationContext(user, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(user, context, errors, true))
            {
                //Validación denegada
                foreach (ValidationResult result in errors)
                    MessageBox.Show(result.ErrorMessage);
            }
            else
            {
                //Validación aprobada
                password = DataSecurity.GetSHA256(txtPassword.Text); //Encriptación de contraseña

                //Autorización del login
                MessageBox.Show("Validated");
            }
                
        }
    }
}
