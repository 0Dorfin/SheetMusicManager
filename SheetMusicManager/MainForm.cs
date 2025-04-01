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
        }

        private void panelBuscar_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panelBuscar.ClientRectangle,
            Color.LightGray, 2, ButtonBorderStyle.Solid,
            Color.LightGray, 2, ButtonBorderStyle.Solid,
            Color.LightGray, 2, ButtonBorderStyle.Solid,
            Color.LightGray, 2, ButtonBorderStyle.Solid);
        }
    }
}
