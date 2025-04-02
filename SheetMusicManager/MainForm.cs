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

            panelBuscar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelBuscar.Width, panelBuscar.Height, 15, 15));

            btnSubirPartitura.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSubirPartitura.Width, btnSubirPartitura.Height, 25, 25));

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
    }
}
