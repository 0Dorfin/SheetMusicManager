using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SheetMusicManager
{
    public partial class LoginForm : Form
    {
        // DLL para bordes redondeados
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load;
            this.DoubleBuffered = true;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Centrar panel principal (si tienes uno)
            panelLogin.Location = new Point(
                (this.ClientSize.Width - panelLogin.Width) / 2,
                (this.ClientSize.Height - panelLogin.Height) / 2);

            // Bordes redondeados del panel principal
            panelLogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelLogin.Width, panelLogin.Height, 40, 40));

            // 👉 Bordes redondeados del panel del campo "Usuario"
            panelUsuario.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelUsuario.Width, panelUsuario.Height, 10, 10));

            // 👉 Eliminar bordes del TextBox
            txtUsuario.BorderStyle = BorderStyle.None;

            // 👉 Asegurarse que los fondos coincidan
            panelUsuario.BackColor = Color.White;
            txtUsuario.BackColor = Color.White;

            btnLogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 45, 45));

        }
    }
}
