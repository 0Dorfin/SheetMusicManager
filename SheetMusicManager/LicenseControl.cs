using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SheetMusicManager
{
    public partial class LicenseControl : UserControl
    {
        public LicenseControl()
        {
            InitializeComponent();
        }

        private void panelPago_MouseEnter(object sender, EventArgs e)
        {
            panelLicenciasPago.Focus();
        }

        private void radioLicenciasGratuitas_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLicenciasGratuitas.Checked)
            {
                panelLicenciasGratuitas.Visible = true;
                panelGratuitas2.Visible = true;

                panelLicenciasPago.Visible = false;
                panelPago2.Visible = false;
            }
        }

        private void radioLicenciasPago_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLicenciasPago.Checked)
            {
                panelLicenciasPago.Visible = true;
                panelPago2.Visible = true;

                panelLicenciasGratuitas.Visible = false;
                panelGratuitas2.Visible = false;

            }
        }

        private void panelBotones_Paint(object sender, PaintEventArgs e)
        {
            Color borderColor = Color.FromArgb(61, 76, 158);
            int borderWidth = 10;
            var rect = panelBotones.ClientRectangle;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawLine(pen, 0, 0, 0, rect.Height);
            }
        }

    }
}