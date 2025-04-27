using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace SheetMusicManager
{
    public partial class MainForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnLogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 25, 25));

            btnLogout.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogout.Width, btnLogout.Height, 25, 25));

            panelBuscar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelBuscar.Width, panelBuscar.Height, 15, 15));

            btnSubirPartitura.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSubirPartitura.Width, btnSubirPartitura.Height, 25, 25));

            ActualizarNombreUsuario(); // por si ya viene logueado

            mainContentPanel.Controls.Clear();
            AllSheetsControl allSheetsControl = new AllSheetsControl();
            allSheetsControl.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(allSheetsControl);

        }

        private void CargarUploadSheetsControl()
        {
            mainContentPanel.Controls.Clear();
            UploadSheetsControl1 upload = new UploadSheetsControl1();
            upload.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(upload);
        }



        private void panelBuscar_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panelBuscar.ClientRectangle,
            Color.LightGray, 2, ButtonBorderStyle.Solid,
            Color.LightGray, 2, ButtonBorderStyle.Solid,
            Color.LightGray, 2, ButtonBorderStyle.Solid,
            Color.LightGray, 2, ButtonBorderStyle.Solid);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }

        private void btnSubirPartitura_Click(object sender, EventArgs e)
        {
            CargarUploadSheetsControl();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            mainContentPanel.Controls.Clear();
            MySheetsControl control = new MySheetsControl();
            control.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(control);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            mainContentPanel.Controls.Clear();
            AllSheetsControl control = new AllSheetsControl();
            control.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(control);
        }

        public void ActualizarNombreUsuario()
        {
            if (!string.IsNullOrEmpty(Session.NombreUsuario))
            {
                btnLogin.Text = $"{Session.NombreUsuario}";
                btnLogout.Visible = true; // Mostrar el botón de cerrar sesión

            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que quieres cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Session.UsuarioId = 0;
                Session.NombreUsuario = null;

                btnLogin.Text = "    Iniciar sesión";
                btnLogout.Visible = false;
            }
        }

    }
}
