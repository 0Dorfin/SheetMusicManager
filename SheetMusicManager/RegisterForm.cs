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
using System.Data.SqlClient;

namespace SheetMusicManager
{
    public partial class RegisterForm : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        public RegisterForm()
        {
            InitializeComponent();
            this.Load += RegisterForm_Load;
            this.DoubleBuffered = true;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            panelRegister.Location = new Point(
                (this.ClientSize.Width - panelRegister.Width) / 2,
                (this.ClientSize.Height - panelRegister.Height) / 2);

            panelRegister.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelRegister.Width, panelRegister.Height, 40, 40));
            panelUsuario.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelUsuario.Width, panelUsuario.Height, 10, 10));
            panelCorreo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelCorreo.Width, panelCorreo.Height, 10, 10));
            panelPassword.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelPassword.Width, panelPassword.Height, 10, 10));
            btnRegister.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnRegister.Width, btnRegister.Height, 45, 45));
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 50, 50));

            txtUsuario.BorderStyle = BorderStyle.None;
            txtCorreo.BorderStyle = BorderStyle.None;
            txtPassword.BorderStyle = BorderStyle.None;

            panelUsuario.BackColor = Color.White;
            panelCorreo.BackColor = Color.White;
            panelPassword.BackColor = Color.White;

            txtUsuario.BackColor = Color.White;
            txtCorreo.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtCorreo_Click(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "Correo Electrónico")
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.Black;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == "*********")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("⚠️ Por favor, completa todos los campos.");
                return;
            }

            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @usuario";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@usuario", usuario);

                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("❌ Ya existe un usuario con ese nombre.");
                    return;
                }

                string insert = "INSERT INTO Usuarios (NombreUsuario, Correo, Contrasena) VALUES (@usuario, @correo, @contrasena)";
                SqlCommand insertCmd = new SqlCommand(insert, conn);
                insertCmd.Parameters.AddWithValue("@usuario", usuario);
                insertCmd.Parameters.AddWithValue("@correo", correo);
                insertCmd.Parameters.AddWithValue("@contrasena", contrasena);

                insertCmd.ExecuteNonQuery();
                MessageBox.Show("✅ Usuario registrado correctamente. Ya puedes iniciar sesión.");

                string getIdQuery = "SELECT Id FROM Usuarios WHERE NombreUsuario = @usuario";
                SqlCommand getIdCmd = new SqlCommand(getIdQuery, conn);
                getIdCmd.Parameters.AddWithValue("@usuario", usuario);

                int userId = (int)getIdCmd.ExecuteScalar();

                // Guardar datos de sesión
                Session.UsuarioId = userId;
                Session.NombreUsuario = usuario;

                // Abrir MainForm directamente
                MessageBox.Show("✅ Registro exitoso. Bienvenido, " + usuario + "!");
                this.Hide();
                MainForm main = new MainForm();
                main.Show();

            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "*********")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void lblRegistrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
    }
}
