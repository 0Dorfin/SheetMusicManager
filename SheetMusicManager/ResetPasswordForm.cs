using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using BCrypt.Net;

namespace SheetMusicManager
{
    public partial class ResetPasswordForm : Form
    {
        private string correoUsuario;

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


        public ResetPasswordForm(string correo)
        {
            InitializeComponent();
            correoUsuario = correo;
            this.Load += ResetPasswordForm_Load;
            this.DoubleBuffered = true;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nuevaPassword = txtNuevaContrasena.Text;
            string confirmarPassword = txtConfirmarContrasena.Text;
            string fortaleza = EvaluarFortaleza(nuevaPassword);

            if (fortaleza != "Fuerte")
            {
                MessageBox.Show("La contraseña debe ser fuerte para poder guardarse.\nIncluye al menos 8 caracteres, una mayúscula, una minúscula, un número y un símbolo.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(nuevaPassword))
            {
                MessageBox.Show("La nueva contraseña no puede estar vacía.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nuevaPassword != confirmarPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(nuevaPassword);
            ActualizarContraseñaEnBD(correoUsuario, hashedPassword);

            MessageBox.Show("Contraseña actualizada correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ActualizarContraseñaEnBD(string correo, string nuevaPass)
        {
            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            using var conn = new SqlConnection(connStr);
            conn.Open();

            var cmd = new SqlCommand("UPDATE Usuarios SET Contrasena = @pass WHERE Correo = @correo", conn);
            cmd.Parameters.AddWithValue("@pass", nuevaPass);
            cmd.Parameters.AddWithValue("@correo", correo);

            cmd.ExecuteNonQuery();
        }

        private void ResetPasswordForm_Load(object sender, EventArgs e)
        {
            panelReset.Location = new Point(
            (this.ClientSize.Width - panelReset.Width) / 2,
            (this.ClientSize.Height - panelReset.Height) / 2);

            panelReset.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelReset.Width, panelReset.Height, 40, 40));
            btnGuardar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnGuardar.Width, btnGuardar.Height, 45, 45));
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 50, 50));
        }

        private void pictureBoxPass_MouseUp(object sender, MouseEventArgs e)
        {
            txtConfirmarContrasena.UseSystemPasswordChar = true;
        }

        private void pictureBoxPass_MouseDown(object sender, MouseEventArgs e)
        {
            txtConfirmarContrasena.UseSystemPasswordChar = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            txtNuevaContrasena.UseSystemPasswordChar = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            txtNuevaContrasena.UseSystemPasswordChar = true;
        }

        private void ResetPasswordForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNuevaContrasena_Click(object sender, EventArgs e)
        {
            if (txtNuevaContrasena.Text == "*********")
            {
                txtNuevaContrasena.Clear();
                txtNuevaContrasena.ForeColor = Color.Black;
            }
            txtNuevaContrasena.UseSystemPasswordChar = true;
        }

        private void txtConfirmarContrasena_Click(object sender, EventArgs e)
        {
            if (txtConfirmarContrasena.Text == "*********")
            {
                txtConfirmarContrasena.Text = "";
                txtConfirmarContrasena.ForeColor = Color.Black;
            }
            txtConfirmarContrasena.UseSystemPasswordChar = true;
        }

        private void VerificarCoincidencia()
        {
            if (string.IsNullOrEmpty(txtConfirmarContrasena.Text))
            {
                lblCoincidencia.Visible = false;
                return;
            }

            lblCoincidencia.Visible = true;

            if (txtConfirmarContrasena.Text == txtNuevaContrasena.Text)
            {
                lblCoincidencia.Text = "Coinciden";
                lblCoincidencia.ForeColor = Color.Green;
            }
            else
            {
                lblCoincidencia.Text = "No coinciden";
                lblCoincidencia.ForeColor = Color.Red;
            }
        }


        private void txtNuevaContrasena_TextChanged(object sender, EventArgs e)
        {
            string password = txtNuevaContrasena.Text;
            lblFuerza.Visible = true;
            lblFuerza.Text = EvaluarFortaleza(password);
            lblFuerza.ForeColor = ObtenerColorFortaleza(password);

            VerificarCoincidencia();
        }

        private void txtConfirmarContrasena_TextChanged(object sender, EventArgs e)
        {
            txtConfirmarContrasena.UseSystemPasswordChar = true;
            VerificarCoincidencia();
        }
    }
}
