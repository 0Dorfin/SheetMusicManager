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

        private UploadSheetsControl1 uploadSheetsControl;

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

            ActualizarNombreUsuario();

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

            // Llamar a limpiar por si acaso (extra protección si el constructor no lo hace)
            upload.LimpiarFormulario();

            mainContentPanel.Controls.Add(upload);
        }


        public void MostrarEditorPartitura(Partitura partitura)
        {
            if (uploadSheetsControl == null)
                uploadSheetsControl = new UploadSheetsControl1();

            uploadSheetsControl.CargarPartituraParaEditar(partitura);

            mainContentPanel.Controls.Clear();
            uploadSheetsControl.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(uploadSheetsControl);
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
            if (!string.IsNullOrEmpty(Session.NombreUsuario))
            {
                mainContentPanel.Controls.Clear();
                OrderHistoryControl control = new OrderHistoryControl();
                control.Dock = DockStyle.Fill;
                mainContentPanel.Controls.Add(control);
            }
            else
            {
                LoginForm login = new LoginForm();
                login.Show();

                ActualizarNombreUsuario();
            }
        }


        private void btnSubirPartitura_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session.NombreUsuario))
            {
                MessageBox.Show("Debes iniciar sesión para subir una partitura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CargarUploadSheetsControl();

        }

        private void label1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Session.NombreUsuario))
            {
                MessageBox.Show("Debes iniciar sesión para acceder a tus partituras.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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
                btnLogin.Text = $"   {Session.NombreUsuario}";
                btnLogout.Visible = true;

            }
        }

        public void MostrarMisPartituras()
        {
            mainContentPanel.Controls.Clear();
            MySheetsControl control = new MySheetsControl();
            control.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(control);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que quieres cerrar sesión?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Session.UsuarioId = 0;
                Session.NombreUsuario = null;

                btnLogin.Text = "    Iniciar sesión";
                btnLogout.Visible = false;

                mainContentPanel.Controls.Clear();
                AllSheetsControl control = new AllSheetsControl();
                control.Dock = DockStyle.Fill;
                mainContentPanel.Controls.Add(control);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            mainContentPanel.Controls.Clear();
            LicenseControl control = new LicenseControl();
            control.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(control);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session.NombreUsuario))
            {
                MessageBox.Show("Debes iniciar sesión para acceder a tus ventas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            mainContentPanel.Controls.Clear();
            SalesControl control = new SalesControl();
            control.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(control);
        }

        private void textBoxBuscar_Click(object sender, EventArgs e)
        {
            if (textBoxBuscar.Text == "Buscar partituras")
            {
                textBoxBuscar.Text = "";
                textBoxBuscar.ForeColor = Color.Black;
            }
        }

        private void textBoxBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string texto = textBoxBuscar.Text.Trim();

                AllSheetsControl actual;

                if (mainContentPanel.Controls.Count == 0 || !(mainContentPanel.Controls[0] is AllSheetsControl))
                {
                    mainContentPanel.Controls.Clear();
                    actual = new AllSheetsControl();
                    actual.Dock = DockStyle.Fill;
                    mainContentPanel.Controls.Add(actual);
                }
                else
                {
                    actual = (AllSheetsControl)mainContentPanel.Controls[0];
                }

                // Filtrar si hay texto, o mostrar todo si está vacío
                if (!string.IsNullOrEmpty(texto))
                    actual.FiltrarPorNombre(texto);
                else
                    actual.MostrarTodas();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            mainContentPanel.Controls.Clear();
            CartControl control = new CartControl();
            control.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(control);
        }
    }
}
