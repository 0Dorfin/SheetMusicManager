using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SheetMusicManager
{
    public partial class LoginForm : Form
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


        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load;
            this.DoubleBuffered = true;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            panelLogin.Location = new Point(
                (this.ClientSize.Width - panelLogin.Width) / 2,
                (this.ClientSize.Height - panelLogin.Height) / 2);

            panelLogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelLogin.Width, panelLogin.Height, 40, 40));
            panelUsuario.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelUsuario.Width, panelUsuario.Height, 10, 10));
            panelPassword.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelPassword.Width, panelPassword.Height, 10, 10));
            txtUsuario.BorderStyle = BorderStyle.None;
            txtPassword.BorderStyle = BorderStyle.None;
            panelUsuario.BackColor = Color.White;
            panelPassword.BackColor = Color.White;
            txtUsuario.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
            btnLogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 45, 45));
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 50, 50));

        }



        private void lblRegistrarse_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, introduce un usuario y una contraseña para registrarte.");
                return;
            }

            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Verificar si ya existe
                string check = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @usuario";
                SqlCommand checkCmd = new SqlCommand(check, conn);
                checkCmd.Parameters.AddWithValue("@usuario", usuario);
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    MessageBox.Show("❌ Ya existe un usuario con ese nombre.");
                    return;
                }

                // Insertar nuevo usuario
                string insert = "INSERT INTO Usuarios (NombreUsuario, Contrasena) VALUES (@usuario, @contrasena)";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Usuario registrado correctamente. Ahora puedes iniciar sesión.");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT Id, NombreUsuario FROM Usuarios WHERE NombreUsuario = @usuario AND Contrasena = @contrasena";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Session.UsuarioId = reader.GetInt32(0);
                    Session.NombreUsuario = reader.GetString(1);

                    // ✅ actualizar el botón desde MainForm
                    MainForm mainForm = Application.OpenForms["MainForm"] as MainForm;
                    if (mainForm != null)
                    {
                        mainForm.ActualizarNombreUsuario();
                    }

                    MessageBox.Show("✅ Inicio de sesión exitoso");
                    this.Close(); // cerramos solo el login
                }
                else
                {
                    MessageBox.Show("❌ Usuario o contraseña incorrectos");
                }
            }
        }


        private void txtUsuario_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
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
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            this.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
    }
}
