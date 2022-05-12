using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalManagementSystem.DataBase;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem
{
    public partial class AgregarPaciente : Form
    {
        public AgregarPaciente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Name4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("¿Deseas continuar?", "Confirmar", MessageBoxButtons.YesNo);
            if( Result ==DialogResult.Yes)
            {
                try
                {
                    Paciente oPaciente = new Paciente {
                        Nombre = txboxNombre.Text,
                        ApPaterno = txboxAPPP.Text,
                        ApMaterno = txboxAPPM.Text,
                        Edad = Convert.ToInt32(txboxEdad.Text),
                        Sexo = txboxGenero.Text[0],
                        Direccion = txboxDireccion.Text,
                        Telefono = txboxTelefono.Text,
                        CURP = txboxCURP.Text
                    };

                    ValidationContext context = new ValidationContext(oPaciente, null, null);
                    IList<ValidationResult> errors = new List<ValidationResult>();

                    if (!Validator.TryValidateObject(oPaciente, context, errors, true))
                    {
                        //Validación del Modelo Denegada
                        Thread.Sleep(4000);
                        foreach (ValidationResult result in errors)
                        {
                            Thread.Sleep(250);
                            MessageBox.Show(result.ErrorMessage);
                        }
                    }
                    else
                    {
                        using (HMSystemEntities db = new HMSystemEntities())
                        {
                            var edad = Convert.ToInt32(txboxEdad.Text);
                            var nacimiento = Convert.ToDateTime(txboxNacimiento.Text);
                            db.SP_REGISTER_PATIENT(txboxCURP.Text, txboxNombre.Text, Convert.ToString(txboxAPPP.Text), Convert.ToString(txboxAPPM.Text), Convert.ToString(txboxGenero.Text[0]), nacimiento, edad, Convert.ToString(txboxTelefono.Text), Convert.ToString(txboxDireccion.Text));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
       
        }
                

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
