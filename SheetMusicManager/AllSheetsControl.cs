using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace SheetMusicManager
{
    public partial class AllSheetsControl : UserControl
    {
        private Dictionary<LinkLabel, LinkLabel> mapaFiltros = new Dictionary<LinkLabel, LinkLabel>();
        private List<LinkLabel> filtrosEpoca = new List<LinkLabel>();
        private List<LinkLabel> filtrosAgrupacion = new List<LinkLabel>();

        private string filtroEpoca = "";
        private string filtroAgrupacion = "";
        private List<string> filtrosInstrumentos = new List<string>();

        public AllSheetsControl()
        {
            InitializeComponent();
            this.Load += AllSheetsControl_Load;
        }

        private void AllSheetsControl_Load(object sender, EventArgs e)
        {
            CargarPartituras();

            // Época
            AgregarFiltroConEventos(linkLabelBarroco, linkXBarroco);
            AgregarFiltroConEventos(linkLabelClas, linkXClasicismo);
            AgregarFiltroConEventos(linkLabelRoman, linkXRomanticismo);

            // Agrupación
            AgregarFiltroConEventos(linkLabelSolo, linkXSolo);
            AgregarFiltroConEventos(linkLabelCamara, linkXCamara);
            AgregarFiltroConEventos(linkLabelOrquesta, linkXOrquesta);
            AgregarFiltroConEventos(linkLabelCoro, linkXCoro);

            // Instrumentación
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

            // Agrupaciones
            filtrosEpoca.AddRange(new[] { linkLabelBarroco, linkLabelClas, linkLabelRoman });
            filtrosAgrupacion.AddRange(new[] { linkLabelSolo, linkLabelCamara, linkLabelOrquesta, linkLabelCoro });

            // Paneles de instrumentos
            AsignarTogglePanel(labelTeclado, panelTeclado, down1, right1);
            AsignarTogglePanel(labelCuerda, panelCuerda, down2, right2);
            AsignarTogglePanel(labelVientoMa, panelVientoMa, down3, right3);
            AsignarTogglePanel(labelVientoMe, panelVientoMe, down4, right4);
            AsignarTogglePanel(labelVoz, panelVoz, down5, right5);
            AsignarTogglePanel(labelPercusion, panelPercusion, down6, right6);
        }

        private void CargarPartituras()
        {
            flowLayoutPanelPartituras.Controls.Clear();

            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT Id, Nombre, Compositor, Epoca, Agrupacion, Instrumentos FROM Partituras WHERE 1=1";

                // Aplicar filtros
                if (!string.IsNullOrEmpty(filtroEpoca))
                    query += " AND Epoca = @epoca";

                if (!string.IsNullOrEmpty(filtroAgrupacion))
                    query += " AND Agrupacion = @agrupacion";

                foreach (var instrumento in filtrosInstrumentos)
                {
                    query += $" AND Instrumentos LIKE '%{instrumento}%'";
                }

                var cmd = new SqlCommand(query, conn);

                if (!string.IsNullOrEmpty(filtroEpoca))
                    cmd.Parameters.AddWithValue("@epoca", filtroEpoca);

                if (!string.IsNullOrEmpty(filtroAgrupacion))
                    cmd.Parameters.AddWithValue("@agrupacion", filtroAgrupacion);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.IsDBNull(1) ? "Sin nombre" : reader.GetString(1);
                    string compositor = reader.IsDBNull(2) ? "Desconocido" : reader.GetString(2);
                    string epoca = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    string agrupacion = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    string instrumentos = reader.IsDBNull(5) ? "" : reader.GetString(5);

                    Panel nuevaPartitura = CrearPanelPartitura(id, nombre, compositor, epoca, agrupacion, instrumentos);
                    flowLayoutPanelPartituras.Controls.Add(nuevaPartitura);
                }
            }
        }


        private Image ObtenerPrimeraPaginaPDF(int idPartitura)
        {
            try
            {
                string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT ArchivoPDF FROM Partituras WHERE Id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", idPartitura);
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        byte[] pdfBytes = (byte[])reader["ArchivoPDF"];

                        using (var stream = new MemoryStream(pdfBytes))
                        using (var document = PdfiumViewer.PdfDocument.Load(stream))
                        {
                            return document.Render(0, pictureBoxPartitura.Width, pictureBoxPartitura.Height, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error mostrando preview del PDF: " + ex.Message);
            }

            return null;
        }


        private Panel CrearPanelPartitura(int id, string nombre, string compositor, string epoca, string agrupacion, string instrumentos)
        {
            Panel panelClone = new Panel
            {
                Size = panelPartitura.Size,
                BackColor = panelPartitura.BackColor,
                Margin = new Padding(10)
            };

            foreach (Control control in panelPartitura.Controls)
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
                    nuevoLbl.AutoSize = true;
                    nuevoLbl.MaximumSize = new Size(300, 0);

                    if (control.Name.Contains("NombreP"))
                        nuevoLbl.Text = nombre;
                    else if (control.Name.Contains("CompositorP"))
                        nuevoLbl.Text = compositor;
                    else if (control.Name.Contains("EpocaP"))
                        nuevoLbl.Text = epoca;
                    else if (control.Name.Contains("AgrupacionP"))
                        nuevoLbl.Text = agrupacion;
                    else if (control.Name.Contains("InstrumentosP"))
                        nuevoLbl.Text = instrumentos;
                    else
                        nuevoLbl.Text = originalLbl.Text;
                }
                else if (control is PictureBox originalPic && clonado is PictureBox nuevoPic)
                {
                    nuevoPic.SizeMode = originalPic.SizeMode;
                    nuevoPic.Image = ObtenerPrimeraPaginaPDF(id);

                    nuevoPic.Paint += pictureBoxPartitura_Paint;

                }

                panelClone.Controls.Add(clonado);
            }

            return panelClone;
        }

        private void pictureBoxPartitura_Paint(object sender, PaintEventArgs e)
        {
            var pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                Color borderColor = Color.FromArgb(61, 76, 158);
                int borderThickness = 2;

                using (Pen pen = new Pen(borderColor, borderThickness))
                {
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    e.Graphics.DrawRectangle(pen, 0, 0, pictureBox.Width - 1, pictureBox.Height - 1);
                }
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
            ActualizarVisibilidadBotonLimpiar();
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
                ActualizarVisibilidadBotonLimpiar();
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

        private void ActualizarVisibilidadBotonLimpiar()
        {
            bool hayFiltros = !string.IsNullOrEmpty(filtroEpoca) ||
                              !string.IsNullOrEmpty(filtroAgrupacion) ||
                              filtrosInstrumentos.Count > 0;

            labelLimpiar.Visible = hayFiltros;
        }


        private void labelLimpiar_Click(object sender, EventArgs e)
        {
            filtroEpoca = "";
            filtroAgrupacion = "";
            filtrosInstrumentos.Clear();

            foreach (var filtro in mapaFiltros.Keys)
            {
                DesactivarFiltro(filtro, mapaFiltros[filtro]);
            }

            // Recargar partituras sin filtros
            CargarPartituras();
            ActualizarVisibilidadBotonLimpiar();
        }
    }
}
