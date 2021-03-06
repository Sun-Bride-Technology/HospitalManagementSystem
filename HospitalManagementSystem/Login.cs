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
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Threading;
using HospitalManagementSystem.DataBase;

namespace HospitalManagementSystem
{
    public partial class Login : Form
    {
        private HMSystemEntities db = new HMSystemEntities();
        #region Fonts
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font ProximaNova_Regular;
        Font Proxima_Nova_Thin;
        #endregion
        public Login()
        {
            InitializeComponent();

            #region ProximaNove_Regular
            byte[] fontData = Properties.Resources.ProximaNova_Regular;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.ProximaNova_Regular.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.ProximaNova_Regular.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            ProximaNova_Regular = new Font(fonts.Families[0], 48.0F);
            #endregion

            #region Proxima_Nova_Thin
            byte[] fontDataNova_Thin = Properties.Resources.Proxima_Nova_Thin;
            IntPtr fontPtrNova_Thin = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontDataNova_Thin.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontDataNova_Thin, 0, fontPtrNova_Thin, fontDataNova_Thin.Length);

            uint dummyNova_Thin = 0;
            fonts.AddMemoryFont(fontPtrNova_Thin, Properties.Resources.Proxima_Nova_Thin.Length);
            AddFontMemResourceEx(fontPtrNova_Thin, (uint)Properties.Resources.Proxima_Nova_Thin.Length, IntPtr.Zero, ref dummyNova_Thin);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtrNova_Thin);

            Proxima_Nova_Thin = new Font(fonts.Families[0], 10.0F);
            #endregion
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {

            string email = txtUser.Text;
            string password = txtPassword.Text;
            //Obtención de Usuario de la Base de Datos
            int id = 1;
            int rol = 2;
            int state = 1;
            //Validación del Modelo
            User user = new User { Id = id, Rol = rol, Status = state, Email = email };

            //Validación del Modelo
            Models.Login mUser = new Models.Login { Email = email, Password = password };

            ValidationContext context = new ValidationContext(mUser, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(mUser, context, errors, true))
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
                //Validación del Modelo Aprobada
                password = DataSecurity.GetSHA256(txtPassword.Text); //Encriptación de contraseña

                //Validación de Base de Datos
                List<SP_LOGIN_Result> oUser = new List<SP_LOGIN_Result>();
                try
                {
                    
                    oUser = db.SP_LOGIN(email, password).ToList();

                    //Autorización del login
                    if (oUser.Count() > 0)
                    {
                        if (oUser[0].Rol == 1)
                        {                   //Administrador
                            Administrador admin = new Administrador();
                            admin.Show();
                        }
                        else if (oUser[0].Rol == 2)
                        {                   //Recepción
                            Recepcion rp = new Recepcion();
                            rp.Show();
                        }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario / Contraseña incorrectos");
                    }
                }
                catch (Exception ex)
                {
                    if(oUser.Count() == 0)
                        MessageBox.Show("ERROR: Datos incorrectos");
                    else
                        MessageBox.Show(ex.Message);
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lblTitle.Font = ProximaNova_Regular;
            lblEmail.Font = Proxima_Nova_Thin;
            lblPassword.Font = Proxima_Nova_Thin;

            txtUser.Font = Proxima_Nova_Thin;
            txtPassword.Font = Proxima_Nova_Thin;

            btnEnter.Font = Proxima_Nova_Thin;

            TransparetBackground(lblTitle);
            TransparetBackground(lblEmail);
            TransparetBackground(lblPassword);
            TransparetBackground(btnClose);
            TransparetBackground(lblLogo);
        }

        #region Helpers
        void TransparetBackground(Control C)
        {
            C.Visible = false;

            C.Refresh();
            Application.DoEvents();

            Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
            int titleHeight = screenRectangle.Top - this.Top;
            int Right = screenRectangle.Left - this.Left;

            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            Bitmap bmpImage = new Bitmap(bmp);
            bmp = bmpImage.Clone(new Rectangle(C.Location.X + Right, C.Location.Y + titleHeight, C.Width, C.Height), bmpImage.PixelFormat);
            C.BackgroundImage = bmp;

            C.Visible = true;
        }
        #endregion
        
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
