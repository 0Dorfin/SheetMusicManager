using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Runtime.InteropServices;


namespace SheetMusicManager
{
    public partial class ForgotPasswordForm : Form
    {
        private string codigoGenerado;

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

        public ForgotPasswordForm()
        {
            InitializeComponent();
            this.Load += ForgotPasswordForm_Load;
            this.DoubleBuffered = true;
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            string correoUsuario = txtCorreo.Text.Trim();

            if (string.IsNullOrEmpty(correoUsuario))
            {
                MessageBox.Show("Por favor, introduce tu correo electrónico.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ExisteCorreoEnBD(correoUsuario))
            {
                MessageBox.Show("El correo no está registrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreUsuario = ObtenerNombreUsuario(correoUsuario);
            codigoGenerado = new Random().Next(100000, 999999).ToString();

            try
            {
                EnviarCorreo(correoUsuario, nombreUsuario, codigoGenerado);
                MessageBox.Show("Se ha enviado un código de verificación a tu correo para restablecer la contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new VerifyCodeForm(codigoGenerado, correoUsuario).Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message);
            }
        }

        private bool ExisteCorreoEnBD(string correo)
        {
            string connStr = DatabaseConnection.ConnectionString;
            using var conn = new SqlConnection(connStr);
            conn.Open();

            var cmd = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE Correo = @correo", conn);
            cmd.Parameters.AddWithValue("@correo", correo);
            int count = (int)cmd.ExecuteScalar();

            return count > 0;
        }


        private string ObtenerNombreUsuario(string correo)
        {
            string connStr = DatabaseConnection.ConnectionString;
            using var conn = new SqlConnection(connStr);
            conn.Open();

            var cmd = new SqlCommand("SELECT NombreUsuario FROM Usuarios WHERE Correo = @correo", conn);
            cmd.Parameters.AddWithValue("@correo", correo);
            var result = cmd.ExecuteScalar();

            return result?.ToString() ?? "usuario";
        }

        private void EnviarCorreo(string destino, string nombre, string codigo)
        {
            var mensaje = new MailMessage();
            mensaje.From = new MailAddress("sheetify.app@gmail.com", "Sheetify");
            mensaje.To.Add(destino);
            mensaje.Subject = "Código de verificación de Sheetify";

            string html = $@"
                <html>
                <body style='font-family: Arial, sans-serif; font-size: 15px; color: #333;'>
                    <p>Hola {nombre},</p>

                    <p>
                        Hemos recibido una solicitud para restablecer la contraseña de tu cuenta asociada a
                        <a href='mailto:{destino}' style='color: #1a73e8;'>{destino}</a>.
                        Tu código de verificación de <strong>Sheetify</strong> es:
                    </p>

                    <p style='font-size: 28px; font-weight: bold; color: #000;'>{codigo}</p>

                    <p>
                        Si no has solicitado este código, puede que alguien esté intentando acceder a tu cuenta.
                        <strong>No reenvíes este correo electrónico ni des el código a nadie.</strong>
                    </p>

                    <p style='margin-top: 32px; margin-bottom: 0;'>Atentamente,</p>
                    <p style='margin-top: 4px;'>El equipo de cuentas de <strong>Sheetify</strong></p>
                </body>
                </html>";


            mensaje.Body = html;
            mensaje.IsBodyHtml = true;

            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("sheetify.app@gmail.com", "zkqy nwdx zkox sjob")
            };

            smtp.Send(mensaje);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
            panelForgot.Location = new Point(
            (this.ClientSize.Width - panelForgot.Width) / 2,
            (this.ClientSize.Height - panelForgot.Height) / 2);

            panelForgot.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelForgot.Width, panelForgot.Height, 40, 40));
            btnRecuperar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnRecuperar.Width, btnRecuperar.Height, 45, 45));
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 50, 50));
        }

        private void ForgotPasswordForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void txtCorreo_Click(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "Correo Electrónico")
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.Black;
            }
        }
    }
}
