using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SheetMusicManager
{
    public partial class MySheetsControl : UserControl
    {
        private Dictionary<LinkLabel, LinkLabel> mapaFiltros = new Dictionary<LinkLabel, LinkLabel>();
        private List<LinkLabel> filtrosEpoca = new List<LinkLabel>();
        private List<LinkLabel> filtrosAgrupacion = new List<LinkLabel>();

        private string filtroEpoca = "";
        private string filtroAgrupacion = "";
        private List<string> filtrosInstrumentos = new List<string>();
        private string textoBusqueda = "";

        private readonly string placeholder = "Buscar en mis partituras";
        private readonly Color placeholderColor = Color.Gray;
        private readonly Color textoNormalColor = Color.Black;


        public MySheetsControl()
        {
            InitializeComponent();
            this.Load += MySheetsControl_Load;
        }

        private void MySheetsControl_Load(object sender, EventArgs e)
        {
            CargarPartituras();

            AgregarFiltroConEventos(linkLabelBarroco, linkXBarroco);
            AgregarFiltroConEventos(linkLabelClas, linkXClasicismo);
            AgregarFiltroConEventos(linkLabelRoman, linkXRomanticismo);

            AgregarFiltroConEventos(linkLabelSolo, linkXSolo);
            AgregarFiltroConEventos(linkLabelCamara, linkXCamara);
            AgregarFiltroConEventos(linkLabelOrquesta, linkXOrquesta);
            AgregarFiltroConEventos(linkLabelCoro, linkXCoro);

            AgregarFiltroConEventos(linkLabelOrgano, linkXOrgano);
            AgregarFiltroConEventos(linkLabelClave, linkXClave);
            AgregarFiltroConEventos(linkLabelPiano, linkXPiano);

            AgregarFiltroConEventos(linkLabelViolin, linkXViolin);
            AgregarFiltroConEventos(linkLabelViola, linkXViola);
            AgregarFiltroConEventos(linkLabelCello, linkXCello);
            AgregarFiltroConEventos(linkLabelContrabajo, linkXContrabajo);

            AgregarFiltroConEventos(linkLabelClarinete, linkXClarinete);
            AgregarFiltroConEventos(linkLabelOboe, linkXOboe);
            AgregarFiltroConEventos(linkLabelFagot, linkXFagot);

            AgregarFiltroConEventos(linkLabelTrompeta, linkXTrompeta);
            AgregarFiltroConEventos(linkLabelFlauta, linkXFlauta);
            AgregarFiltroConEventos(linkLabelTrombon, linkXTrombon);
            AgregarFiltroConEventos(linkLabelTrompa, linkXTrompa);

            AgregarFiltroConEventos(linkLabelSoprano, linkXSoprano);
            AgregarFiltroConEventos(linkLabelMezzo, linkXMezzo);
            AgregarFiltroConEventos(linkLabelTenor, linkXTenor);
            AgregarFiltroConEventos(linkLabelBajo, linkXBajo);

            AgregarFiltroConEventos(linkLabelTimbales, linkXTimbales);

            filtrosEpoca.AddRange(new[] { linkLabelBarroco, linkLabelClas, linkLabelRoman });
            filtrosAgrupacion.AddRange(new[] { linkLabelSolo, linkLabelCamara, linkLabelOrquesta, linkLabelCoro });

            AsignarTogglePanel(labelTeclado, panelTeclado, down1, right1);
            AsignarTogglePanel(labelCuerda, panelCuerda, down2, right2);
            AsignarTogglePanel(labelVientoMa, panelVientoMa, down3, right3);
            AsignarTogglePanel(labelVientoMe, panelVientoMe, down4, right4);
            AsignarTogglePanel(labelVoz, panelVoz, down5, right5);
            AsignarTogglePanel(labelPercusion, panelPercusion, down6, right6);

            textBoxMisPartituras.Text = placeholder;
            textBoxMisPartituras.ForeColor = placeholderColor;


            textBoxMisPartituras.Enter += textBoxMisPartituras_Enter;
            textBoxMisPartituras.Leave += textBoxMisPartituras_Leave;
            textBoxMisPartituras.TextChanged += textBoxMisPartituras_TextChanged;
        }

        private void textBoxMisPartituras_Enter(object sender, EventArgs e)
        {
            if (textBoxMisPartituras.Text == placeholder)
            {
                textBoxMisPartituras.Text = "";
                textBoxMisPartituras.ForeColor = textoNormalColor;
            }
        }

        private void textBoxMisPartituras_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMisPartituras.Text))
            {
                textBoxMisPartituras.Text = placeholder;
                textBoxMisPartituras.ForeColor = placeholderColor;
                textoBusqueda = "";
                CargarPartituras();
            }
        }

        private void textBoxMisPartituras_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMisPartituras.Text != placeholder)
            {
                textoBusqueda = textBoxMisPartituras.Text.Trim();
                CargarPartituras();
            }
        }


        private void AgregarFiltroConEventos(LinkLabel filtro, LinkLabel botonCerrar)
        {
            if (filtro == null || botonCerrar == null)
                return;

            mapaFiltros[filtro] = botonCerrar;
            filtro.LinkClicked += Filtro_LinkClicked;
            botonCerrar.LinkClicked += BotonCerrar_LinkClicked;
        }

        private void Filtro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var filtro = (LinkLabel)sender;
            var botonCerrar = mapaFiltros[filtro];
            string texto = filtro.Text.Trim();

            if (filtrosEpoca.Contains(filtro))
            {
                DesactivarGrupo(filtrosEpoca);
                filtroEpoca = texto;
            }
            else if (filtrosAgrupacion.Contains(filtro))
            {
                DesactivarGrupo(filtrosAgrupacion);
                filtroAgrupacion = texto;
            }
            else
            {
                if (!filtrosInstrumentos.Contains(texto))
                    filtrosInstrumentos.Add(texto);
            }

            ActivarFiltro(filtro, botonCerrar);
            CargarPartituras();
        }

        private void BotonCerrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var botonCerrar = (LinkLabel)sender;
            var filtro = mapaFiltros.FirstOrDefault(x => x.Value == botonCerrar).Key;
            if (filtro != null)
            {
                string texto = filtro.Text.Trim();

                if (filtrosEpoca.Contains(filtro)) filtroEpoca = "";
                else if (filtrosAgrupacion.Contains(filtro)) filtroAgrupacion = "";
                else filtrosInstrumentos.Remove(texto);

                DesactivarFiltro(filtro, botonCerrar);
                CargarPartituras();
            }
        }

        private void DesactivarGrupo(List<LinkLabel> grupo)
        {
            foreach (var filtro in grupo)
            {
                if (mapaFiltros.TryGetValue(filtro, out var botonCerrar))
                {
                    DesactivarFiltro(filtro, botonCerrar);
                }
            }
        }

        private void ActivarFiltro(LinkLabel filtro, LinkLabel botonCerrar)
        {
            filtro.LinkColor = Color.FromArgb(61, 76, 158);
            botonCerrar.LinkColor = Color.FromArgb(61, 76, 158);
            botonCerrar.Visible = true;
        }

        private void DesactivarFiltro(LinkLabel filtro, LinkLabel botonCerrar)
        {
            filtro.LinkColor = Color.Black;
            botonCerrar.Visible = false;
        }

        private void AsignarTogglePanel(Label label, Panel panel, PictureBox downIcon, PictureBox rightIcon)
        {
            label.Click += (s, e) =>
            {
                bool visible = !panel.Visible;
                panel.Visible = visible;
                MostrarFlechaAbierta(downIcon, rightIcon, visible);
            };
        }

        private void MostrarFlechaAbierta(PictureBox down, PictureBox right, bool expandido)
        {
            if (down != null) down.Visible = expandido;
            if (right != null) right.Visible = !expandido;
        }

        private void CargarPartituras()
        {
            flowPartiturasPanel.Controls.Clear();

            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT Id, Nombre, Compositor, Epoca, Agrupacion, Instrumentos, FechaSubida FROM Partituras WHERE 1=1";

                if (!string.IsNullOrEmpty(filtroEpoca))
                    query += " AND Epoca = @epoca";

                if (!string.IsNullOrEmpty(filtroAgrupacion))
                    query += " AND Agrupacion = @agrupacion";

                foreach (var instrumento in filtrosInstrumentos)
                    query += $" AND Instrumentos LIKE '%{instrumento}%'";

                if (!string.IsNullOrEmpty(textoBusqueda))
                    query += " AND (Nombre LIKE @texto OR Compositor LIKE @texto OR Instrumentos LIKE @texto)";

                var cmd = new SqlCommand(query, conn);

                if (!string.IsNullOrEmpty(filtroEpoca))
                    cmd.Parameters.AddWithValue("@epoca", filtroEpoca);

                if (!string.IsNullOrEmpty(filtroAgrupacion))
                    cmd.Parameters.AddWithValue("@agrupacion", filtroAgrupacion);

                if (!string.IsNullOrEmpty(textoBusqueda))
                    cmd.Parameters.AddWithValue("@texto", "%" + textoBusqueda + "%");

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.IsDBNull(1) ? "Sin nombre" : reader.GetString(1);
                    string compositor = reader.IsDBNull(2) ? "Desconocido" : reader.GetString(2);
                    string epoca = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    string agrupacion = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    string instrumentos = reader.IsDBNull(5) ? "" : reader.GetString(5);
                    DateTime fecha = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);

                    Panel fila = ClonarPanelPlantilla(id, nombre, compositor, epoca, agrupacion, instrumentos, fecha);
                    flowPartiturasPanel.Controls.Add(fila);
                }
            }
        }

        private Panel ClonarPanelPlantilla(int id, string nombre, string compositor, string epoca, string agrupacion, string instrumentos, DateTime fecha)
        {
            Panel panelClone = new Panel
            {
                Size = filaPartitura.Size,
                BackColor = filaPartitura.BackColor,
                Margin = filaPartitura.Margin
            };

            foreach (Control control in filaPartitura.Controls)
            {
                Control clonado = (Control)Activator.CreateInstance(control.GetType());

                clonado.Size = control.Size;
                clonado.Location = control.Location;
                clonado.Font = control.Font;
                clonado.BackColor = control.BackColor;
                clonado.ForeColor = control.ForeColor;

                if (control is Label originalLbl && clonado is Label nuevoLbl)
                {
                    nuevoLbl.UseCompatibleTextRendering = true;
                    nuevoLbl.AutoEllipsis = false;
                    nuevoLbl.AutoSize = true;

                    if (control.Name.Contains("Partitura"))
                    {
                        nuevoLbl.Text = nombre;
                        nuevoLbl.MaximumSize = new Size(160, 0);
                    }
                    else if (control.Name.Contains("Compositor"))
                    {
                        nuevoLbl.Text = compositor;
                        nuevoLbl.MaximumSize = new Size(160, 0);
                    }
                    else if (control.Name.Contains("Epoca"))
                        nuevoLbl.Text = epoca;
                    else if (control.Name.Contains("Agrupacion"))
                        nuevoLbl.Text = agrupacion;
                    else if (control.Name.Contains("Instrumentos"))
                    {
                        nuevoLbl.Text = instrumentos;
                        nuevoLbl.MaximumSize = new Size(200, 0);
                    }
                    else if (control.Name.Contains("Fecha"))
                        nuevoLbl.Text = fecha.ToShortDateString();
                    else
                        nuevoLbl.Text = originalLbl.Text;
                }
                else if (control is PictureBox originalImg && clonado is PictureBox nuevoImg)
                {
                    nuevoImg.Image = originalImg.Image;
                    nuevoImg.SizeMode = originalImg.SizeMode;

                    if (originalImg.Name.Contains("Ver"))
                        nuevoImg.Click += (s, e) => VerPartitura(id);
                    else if (originalImg.Name.Contains("Eliminar"))
                        nuevoImg.Click += (s, e) => EliminarPartitura(id);
                }

                panelClone.Controls.Add(clonado);
            }

            return panelClone;
        }

        private void VerPartitura(int id)
        {
            try
            {
                string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT ArchivoPDF FROM Partituras WHERE Id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        byte[] pdfBytes = (byte[])reader["ArchivoPDF"];
                        string tempPath = Path.Combine(Path.GetTempPath(), $"partitura_{id}.pdf");
                        File.WriteAllBytes(tempPath, pdfBytes);
                        Process.Start(new ProcessStartInfo(tempPath) { UseShellExecute = true });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ No se pudo abrir la partitura: " + ex.Message);
            }
        }

        private void EliminarPartitura(int id)
        {
            var confirm = MessageBox.Show("¿Eliminar esta partitura?", "Confirmación", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand("DELETE FROM Partituras WHERE Id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                CargarPartituras();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al eliminar: " + ex.Message);
            }
        }

    }
}
