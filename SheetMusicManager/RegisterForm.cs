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
using BCrypt.Net;

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
            }
            txtPassword.UseSystemPasswordChar = true;
            string pass = txtPassword.Text;
            string fortaleza = EvaluarFortaleza(pass);
            lblFuerza.Visible = true;
            lblFuerza.Text = $"{fortaleza}";
            lblFuerza.ForeColor = ObtenerColorFortaleza(pass);
        }

        private bool CorreoValido(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!CorreoValido(correo))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (EvaluarFortaleza(contrasena) != "Fuerte")
            {
                MessageBox.Show("La contraseña debe ser fuerte para completar el registro","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = DatabaseConnection.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string checkUserQuery = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @usuario";
                SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, conn);
                checkUserCmd.Parameters.AddWithValue("@usuario", usuario);
                if ((int)checkUserCmd.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Ya existe un usuario con ese nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string checkCorreoQuery = "SELECT COUNT(*) FROM Usuarios WHERE Correo = @correo";
                SqlCommand checkCorreoCmd = new SqlCommand(checkCorreoQuery, conn);
                checkCorreoCmd.Parameters.AddWithValue("@correo", correo);
                if ((int)checkCorreoCmd.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Ya existe una cuenta registrada con ese correo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(contrasena);

                string insert = "INSERT INTO Usuarios (NombreUsuario, Correo, Contrasena) VALUES (@usuario, @correo, @contrasena)";
                SqlCommand insertCmd = new SqlCommand(insert, conn);
                insertCmd.Parameters.AddWithValue("@usuario", usuario);
                insertCmd.Parameters.AddWithValue("@correo", correo);
                insertCmd.Parameters.AddWithValue("@contrasena", hashedPassword);
                insertCmd.ExecuteNonQuery();

                string getIdQuery = "SELECT Id FROM Usuarios WHERE NombreUsuario = @usuario";
                SqlCommand getIdCmd = new SqlCommand(getIdQuery, conn);
                getIdCmd.Parameters.AddWithValue("@usuario", usuario);
                int userId = (int)getIdCmd.ExecuteScalar();

                Session.UsuarioId = userId;
                Session.NombreUsuario = usuario;

                MainForm main = Application.OpenForms["MainForm"] as MainForm;
                if (main != null)
                {
                    main.ActualizarNombreUsuario();
                }

                MessageBox.Show("Registro exitoso. Bienvenido, " + usuario + "!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void lblIniciarS_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm registerForm = new LoginForm();
            registerForm.ShowDialog();
        }

        private string EvaluarFortaleza(string password)
        {
            int score = 0;
            if (password.Length >= 8) score++;
            if (password.Any(char.IsUpper)) score++;
            if (password.Any(char.IsLower)) score++;
            if (password.Any(char.IsDigit)) score++;
            if (password.Any(ch => !char.IsLetterOrDigit(ch))) score++;

            return score switch
            {
                <= 2 => "Débil",
                3 => "Media",
                >= 4 => "Fuerte"
            };
        }

        private Color ObtenerColorFortaleza(string password)
        {
            return EvaluarFortaleza(password) switch
            {
                "Débil" => Color.Red,
                "Media" => Color.Orange,
                "Fuerte" => Color.Green,
                _ => Color.Black
            };
        }


        private void pictureBoxPass_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void pictureBoxPass_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}
