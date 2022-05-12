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

namespace HospitalManagementSystem.Models
{
    public partial class AgregarDoctor : Form
    {
        private HMSystemEntities db = new HMSystemEntities();
        public AgregarDoctor()
        {
            InitializeComponent();
        }

        private void AgregarDoctor_Load(object sender, EventArgs e)
        {
            var lstJob = db.JOB.ToList();
            cmbJob.DataSource = lstJob;
            cmbJob.DisplayMember = "Description";
            cmbJob.ValueMember = "Id";
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var age = Convert.ToInt32(txtAge.Text);
                var birthDate = Convert.ToDateTime(txtBirthDay.Text);
                var job = (int)cmbJob.SelectedValue;

                Doctor oDoctor = new Doctor
                {
                    Name = txtName.Text,
                    LastName = txtLastName.Text,
                    MotherLastName = txtMLastName.Text,
                    Gender = txtGender.Text,
                    BirthDate = birthDate,
                    Age = age,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text,
                    Job = job
                };

                ValidationContext context = new ValidationContext(oDoctor, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();

                if (!Validator.TryValidateObject(oDoctor, context, errors, true))
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
                    db.SP_ADD_EMPLOYEE(txtName.Text, txtLastName.Text, txtMLastName.Text, txtGender.Text, birthDate, age, txtEmail.Text, txtPhone.Text, txtAddress.Text, job);
                }
            }
            catch (Exception ex)
            {
                if (txtAge.Text == "" || txtBirthDay.Text == "" || cmbJob.SelectedValue == null)
                {
                    MessageBox.Show("Asegurate de llenar todos los valores");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            

        }
    }
}
