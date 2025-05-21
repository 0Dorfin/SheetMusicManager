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

namespace SheetMusicManager
{
    public partial class VerifyCodeForm : Form
    {
        private readonly string codigoCorrecto;
        private readonly DateTime codigoGeneradoEn;
        private readonly string correoUsuario;

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

        public VerifyCodeForm(string codigo, string correo)
        {
            InitializeComponent();
            this.Load += VerifyCodeForm_Load;
            codigoCorrecto = codigo;
            correoUsuario = correo;
            codigoGeneradoEn = DateTime.Now;

            AsignarEventos(textCode1);
            AsignarEventos(textCode2);
            AsignarEventos(textCode3);
            AsignarEventos(textCode4);
            AsignarEventos(textCode5);
            AsignarEventos(textCode6);
        }

        private void AsignarEventos(TextBox box)
        {
            box.MaxLength = 1;
            box.KeyPress += OnlyDigits_KeyPress;
            box.TextChanged += CodeBox_TextChanged;
            box.KeyDown += CodeBox_KeyDown;
        }

        private void CodeBox_TextChanged(object sender, EventArgs e)
        {
            TextBox current = sender as TextBox;

            if (current.Text.Length > 1)
            {
                current.Text = current.Text.Substring(0, 1);
                current.SelectionStart = 1;
            }

            if (current.Text.Length == 1)
            {
                this.SelectNextControl(current, true, true, true, true);
            }
        }


        private void CodeBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox current = sender as TextBox;

            if (e.KeyCode == Keys.Back)
            {
                if (!string.IsNullOrEmpty(current.Text))
                {
                    current.Clear();
                    e.Handled = true;
                }
                else
                {
                    this.SelectNextControl(current, false, true, true, true);
                }
            }
        }


        private void OnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (DateTime.Now > codigoGeneradoEn.AddMinutes(10))
            {
                MessageBox.Show("El código ha expirado. Por favor, solicita uno nuevo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            string ingresado = textCode1.Text + textCode2.Text + textCode3.Text +
                               textCode4.Text + textCode5.Text + textCode6.Text;

            if (ingresado == codigoCorrecto)
            {
                MessageBox.Show("Código correcto. Puedes restablecer tu contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new ResetPasswordForm(correoUsuario).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Código incorrecto. Inténtalo de nuevo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void VerifyCodeForm_Load(object sender, EventArgs e)
        {
            panelVerificar.Location = new Point(
            (this.ClientSize.Width - panelVerificar.Width) / 2,
            (this.ClientSize.Height - panelVerificar.Height) / 2);

            panelVerificar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelVerificar.Width, panelVerificar.Height, 40, 40));
            btnConfirmar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnConfirmar.Width, btnConfirmar.Height, 45, 45));
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 50, 50));
        }

        private void VerifyCodeForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
