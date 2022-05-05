using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalManagementSystem.DataBase;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem
{
    public partial class Recepcion : Form
    {
        private HMSystemEntities db = new HMSystemEntities();

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font ProximaNova_Regular;
        private int borderSize = 2;
        public Recepcion()
        {
            InitializeComponent();
            CollapseMenu();
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(152, 135, 143);

            #region ProximaNove_Regular
            byte[] fontData = Properties.Resources.ProximaNova_Regular;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.ProximaNova_Regular.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.ProximaNova_Regular.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            ProximaNova_Regular = new Font(fonts.Families[0], 12.0F);
            #endregion
        }
        private void Recepcion_Load(object sender, EventArgs e)
        {
            iconButton2.Font = ProximaNova_Regular;
            iconButton3.Font = ProximaNova_Regular;
            iconButton4.Font = ProximaNova_Regular;
            iconButton5.Font = ProximaNova_Regular;
            btnSignOut.Font = ProximaNova_Regular;

            //TblReports
            LoadReports();

            GenerateBeds();
        }

        #region Diseño de formulario
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Overridden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            //const int WM_SYSCOMMAND = 0x0112;
            //const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            //const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion
            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            base.WndProc(ref m);
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Recepcion_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(0, 8, 8, 0);
                    break;

                case FormWindowState.Normal:
                    if(this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void CollapseMenu()
        {
            if(this.panelMenu.Width > 200)
            {
                panelMenu.Width = 100;
                pictureBox1.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach(Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            {
                panelMenu.Width = 230;
                pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "        " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        #endregion

        #region Home
        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (panelHome.Visible != true)
            {
                panelHome.Visible = true;
            }
        }
        #endregion

        #region Reportes
        public void LoadReports()
        {
            List<Consulta> lstAllocations = new List<Consulta>();
            foreach (var item in db.CONSULTATION.OrderByDescending(c => c.ConsultationDate))//.Where(consult => consult.PATIENT1.Status == 4))
            {
                Consulta consulta = new Consulta()
                {
                    Id = item.Id,
                    Allocation = item.ALLOCATION1.Assgnment,
                    Patient = $"{item.PATIENT1.Name} {item.PATIENT1.LastName} {item.PATIENT1.MotherLastName}",
                    Doctor = $"{item.EMPLOYEE.Name} {item.EMPLOYEE.LastName} {item.EMPLOYEE.MotherLastName}",
                    ConsultationDate = item.ConsultationDate
                };
                lstAllocations.Add(consulta);
            }
            this.grdvReports.DataSource = lstAllocations;
            
        }
        

        private void grdvReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(grdvReports.Columns[e.ColumnIndex].Name == "Acciones")
            {
                var index = grdvReports.Rows[e.RowIndex].Index;
                var id = grdvReports.Rows[index].Cells[1].Value.ToString();

                Report report = new Report();
                report.GetConsultation(Convert.ToInt32(grdvReports.Rows[index].Cells[1].Value.ToString()));
                report.Show();
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            LoadReports();
            if (panelReportes.Visible == true)
            {
                panelReportes.Visible = false;
                panelHome.Visible = true;
            }
            else
            {
                panelReportes.Visible = true;
                panelHome.Visible = false;
            }
        }
        #endregion

        #region Asignacion
        public void GenerateBeds()
        {
            var allocation = db.ALLOCATION.Select(a => a.Assgnment).ToList();
            foreach (var item in allocation)
            {
                try
                {
                    if (item.Contains("A"))
                    {
                        if(item.Contains("01"))
                            A01.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("02"))
                            A02.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("03"))
                            A03.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("04"))
                            A04.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("05"))
                            A05.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("06"))
                            A06.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("07"))
                            A07.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("08"))
                            A08.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("09"))
                            A09.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("10"))
                            A10.BackColor = Color.FromArgb(153, 93, 111);
                    }
                    else if(item.Contains("B"))
                    {
                        if (item.Contains("01"))
                            B01.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("02"))
                            B02.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("03"))
                            B03.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("04"))
                            B04.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("05"))
                            B05.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("06"))
                            B06.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("07"))
                            B07.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("08"))
                            B08.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("09"))
                            B09.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("10"))
                            B10.BackColor = Color.FromArgb(153, 93, 111);
                    }
                    else
                    {
                        if (item.Contains("01"))
                            C01.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("02"))
                            C02.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("03"))
                            C03.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("04"))
                            C04.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("05"))
                            C05.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("06"))
                            C06.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("07"))
                            C07.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("08"))
                            C08.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("09"))
                            C09.BackColor = Color.FromArgb(153, 93, 111);
                        if (item.Contains("10"))
                            C10.BackColor = Color.FromArgb(153, 93, 111);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private void iconButton4_Click(object sender, EventArgs e)
        {
            GenerateBeds();
            if (panelAsignacion.Visible == true)
            {
                panelAsignacion.Visible = false;
                panelHome.Visible = true;
            }
            else
            {
                panelAsignacion.Visible = true;
                panelHome.Visible = false;
            }
        }
        #endregion

        #region Paciente
        private void iconButton5_Click_1(object sender, EventArgs e)
        {
            if (panelPaciente.Visible == true)
            {
                panelPaciente.Visible = false;
            }
            else
            {
                panelPaciente.Visible = true;
            }
        }
        
        #endregion

    }
}
