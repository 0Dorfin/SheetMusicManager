using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SheetMusicManager
{
    public partial class AllSheetsControl : UserControl
    {
        private Dictionary<LinkLabel, LinkLabel> mapaFiltros = new Dictionary<LinkLabel, LinkLabel>();
        private List<LinkLabel> filtrosEpoca = new List<LinkLabel>();
        private List<LinkLabel> filtrosAgrupacion = new List<LinkLabel>();
        private List<LinkLabel> filtrosLicencia = new List<LinkLabel>();

        private string filtroEpoca = "";
        private string filtroAgrupacion = "";
        private string filtroLicencia = "";
        private List<string> filtrosInstrumentos = new List<string>();

        public AllSheetsControl()
        {
            InitializeComponent();
            this.Load += AllSheetsControl_Load;
        }

        private void AllSheetsControl_Load(object sender, EventArgs e)
        {

            ActualizarEtiquetasDeFiltros();

            AgregarFiltroConEventos(linkLabelPago, linkXPago);
            AgregarFiltroConEventos(linkLabelGratuita, linkXGratuita);

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
            filtrosLicencia.AddRange(new[] { linkLabelPago, linkLabelGratuita });

            // Paneles de instrumentos
            AsignarTogglePanel(labelTeclado, panelTeclado, down1, right1);
            AsignarTogglePanel(labelCuerda, panelCuerda, down2, right2);
            AsignarTogglePanel(labelVientoMa, panelVientoMa, down3, right3);
            AsignarTogglePanel(labelVientoMe, panelVientoMe, down4, right4);
            AsignarTogglePanel(labelVoz, panelVoz, down5, right5);
            AsignarTogglePanel(labelPercusion, panelPercusion, down6, right6);

            botonesPaginas = new Button[] { btn1, btn2, btn3, btn4, btn5 };

            foreach (var btn in botonesPaginas)
            {
                btn.Click += btnNumero_Click;
            }
            CargarPagina();

        }

        private void CargarPartituras()
        {
            flowLayoutPanelPartituras.Controls.Clear();

            string connStr = DatabaseConnection.ConnectionString;
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT Id, Nombre, Compositor, Epoca, Agrupacion, Instrumentos, Precio FROM vwPartiturasConInstrumentos WHERE 1=1";

                if (!string.IsNullOrEmpty(filtroEpoca))
                    query += " AND Epoca = @epoca";

                if (!string.IsNullOrEmpty(filtroAgrupacion))
                    query += " AND Agrupacion = @agrupacion";
                if (!string.IsNullOrEmpty(filtroLicencia))
                {
                    if (filtroLicencia.Equals("Gratuita", StringComparison.OrdinalIgnoreCase))
                        query += " AND Precio = 0";
                    else if (filtroLicencia.Equals("Pago", StringComparison.OrdinalIgnoreCase))
                        query += " AND Precio > 0";
                }

                foreach (var instrumento in filtrosInstrumentos)
                {
                    query += $" AND Instrumentos LIKE '%{instrumento}%'";
                }

                query += " ORDER BY Id OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";

                var cmd = new SqlCommand(query, conn);

                if (!string.IsNullOrEmpty(filtroEpoca))
                    cmd.Parameters.AddWithValue("@epoca", filtroEpoca);

                if (!string.IsNullOrEmpty(filtroAgrupacion))
                    cmd.Parameters.AddWithValue("@agrupacion", filtroAgrupacion);

                cmd.Parameters.AddWithValue("@offset", (paginaActual - 1) * itemsPorPagina);
                cmd.Parameters.AddWithValue("@limit", itemsPorPagina);

                for (int i = 0; i < filtrosInstrumentos.Count; i++)
                {
                    cmd.Parameters.AddWithValue($"@inst{i}", $"%{filtrosInstrumentos[i]}%");
                }

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.IsDBNull(1) ? "Sin nombre" : reader.GetString(1);
                    string compositor = reader.IsDBNull(2) ? "Desconocido" : reader.GetString(2);
                    string epoca = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    string agrupacion = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    string instrumentos = reader.IsDBNull(5) ? "" : reader.GetString(5);
                    decimal precio = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);

                    Panel nuevaPartitura = CrearPanelPartitura(id, nombre, compositor, epoca, agrupacion, instrumentos, precio);
                    flowLayoutPanelPartituras.Controls.Add(nuevaPartitura);
                }
            }
            labelMostrar.Visible = flowLayoutPanelPartituras.Controls.Count == 0;
        }


        private Image ObtenerPrimeraPaginaPDF(int idPartitura)
        {
            try
            {
                string connStr = DatabaseConnection.ConnectionString;
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


        private Panel CrearPanelPartitura(int id, string nombre, string compositor, string epoca, string agrupacion, string instrumentos, decimal precio)
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
                    {
                        nuevoLbl.Text = nombre;
                        nuevoLbl.Name = "labelNombreP";
                    }
                    else if (control.Name.Contains("CompositorP"))
                        nuevoLbl.Text = compositor;
                    else if (control.Name.Contains("EpocaP"))
                        nuevoLbl.Text = epoca;
                    else if (control.Name.Contains("AgrupacionP"))
                        nuevoLbl.Text = agrupacion;
                    else if (control.Name.Contains("InstrumentosP"))
                        nuevoLbl.Text = instrumentos;
                    else if (control.Name.Contains("PrecioP"))
                    {
                        nuevoLbl.Text = precio == 0 ? "Gratuita" : $"{precio:F2}€";
                        if (precio == 0)
                        {
                            nuevoLbl.Location = new Point(nuevoLbl.Location.X - 20, nuevoLbl.Location.Y);
                        }
                    }
                    else
                        nuevoLbl.Text = originalLbl.Text;
                }
                else if (control is PictureBox originalPic && clonado is PictureBox nuevoPic)
                {
                    nuevoPic.SizeMode = originalPic.SizeMode;
                    nuevoPic.Image = ObtenerPrimeraPaginaPDF(id);

                    nuevoPic.Paint += pictureBoxPartitura_Paint;
                    nuevoPic.MouseEnter += pictureBoxPartitura_MouseEnter;
                    nuevoPic.MouseLeave += pictureBoxPartitura_MouseLeave;

                    nuevoPic.Tag = id;
                    nuevoPic.Click += pictureBoxPartitura_Click;
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
            string texto = filtro.Text.Split('(')[0].Trim();

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
            else if (filtrosLicencia.Contains(filtro))
            {
                DesactivarGrupo(filtrosLicencia);
                filtroLicencia = texto;
            }
            else
            {
                if (!filtrosInstrumentos.Contains(texto))
                    filtrosInstrumentos.Add(texto);
            }


            ActivarFiltro(filtro, botonCerrar);
            CargarPartituras();
            ActualizarVisibilidadBotonLimpiar();
            ActualizarEtiquetasDeFiltros();
        }

        private void BotonCerrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var botonCerrar = (LinkLabel)sender;
            var filtro = mapaFiltros.FirstOrDefault(x => x.Value == botonCerrar).Key;
            if (filtro != null)
            {
                string texto = filtro.Text.Split('(')[0].Trim();

                if (filtrosEpoca.Contains(filtro)) filtroEpoca = "";
                else if (filtrosAgrupacion.Contains(filtro)) filtroAgrupacion = "";
                else if (filtrosLicencia.Contains(filtro)) filtroLicencia = "";
                else filtrosInstrumentos.Remove(texto);

                DesactivarFiltro(filtro, botonCerrar);
                CargarPartituras();
                ActualizarVisibilidadBotonLimpiar();
                ActualizarEtiquetasDeFiltros();
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

        public void FiltrarPorNombre(string nombre)
        {

            foreach (Control control in flowLayoutPanelPartituras.Controls)
            {
                if (control is Panel panel)
                {
                    var labelNombre = panel.Controls.Find("labelNombreP", true).FirstOrDefault();
                    if (labelNombre != null)
                    {
                        bool visible = labelNombre.Text.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0;
                        panel.Visible = visible;
                    }
                }
            }
        }

        public void MostrarTodas()
        {
            foreach (Control control in flowLayoutPanelPartituras.Controls)
            {
                control.Visible = true;
            }
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
                  !string.IsNullOrEmpty(filtroLicencia) ||
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

            CargarPartituras();
            ActualizarVisibilidadBotonLimpiar();
            ActualizarEtiquetasDeFiltros();
        }

        private void pictureBoxPartitura_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
                pb.Cursor = Cursors.Hand;
        }

        private void pictureBoxPartitura_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
                pb.Cursor = Cursors.Default;
        }

        private void pictureBoxPartitura_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null && pb.Tag != null)
            {
                int idPartitura = (int)pb.Tag;
                MostrarDetallePartitura(idPartitura, Session.UsuarioId);
            }
        }

        private void MostrarDetallePartitura(int idPartitura, int idUsuario)
        {
            var detalleControl = new SheetDetailControl(idPartitura, idUsuario)
            {
                Dock = DockStyle.Fill
            };

            if (this.Parent is Panel contenedor)
            {
                contenedor.Controls.Clear();
                contenedor.Controls.Add(detalleControl);
            }
        }

        private Dictionary<string, int> ObtenerRecuentoPorCampo(string campo)
        {
            Dictionary<string, int> recuentos = new Dictionary<string, int>();
            string connStr = DatabaseConnection.ConnectionString;
            string query = $"SELECT {campo}, COUNT(*) as Total FROM Partituras GROUP BY {campo}";

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string valor = reader.IsDBNull(0) ? "Sin clasificar" : reader.GetString(0);
                        int total = reader.GetInt32(1);
                        recuentos[valor] = total;
                    }
                }
            }

            return recuentos;
        }

        private Dictionary<string, int> ObtenerRecuentoPorCampoConFiltros(string campo)
        {
            var recuentos = new Dictionary<string, int>();
            string query = $"SELECT {campo}, COUNT(*) FROM Partituras WHERE 1=1";

            if (campo != "Epoca" && !string.IsNullOrEmpty(filtroEpoca))
                query += " AND Epoca = @epoca";

            if (campo != "Agrupacion" && !string.IsNullOrEmpty(filtroAgrupacion))
                query += " AND Agrupacion = @agrupacion";

            if (campo != "Precio" && !string.IsNullOrEmpty(filtroLicencia))
            {
                if (filtroLicencia.Equals("Gratuita", StringComparison.OrdinalIgnoreCase))
                    query += " AND Precio = 0";
                else if (filtroLicencia.Equals("Pago", StringComparison.OrdinalIgnoreCase))
                    query += " AND Precio > 0";
            }

            foreach (var instrumento in filtrosInstrumentos)
            {
                query += $" AND Instrumentos LIKE '%{instrumento}%'";
            }

            query += $" GROUP BY {campo}";

            using (var conn = new SqlConnection("Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;"))
            using (var cmd = new SqlCommand(query, conn))
            {
                if (campo != "Epoca" && !string.IsNullOrEmpty(filtroEpoca))
                    cmd.Parameters.AddWithValue("@epoca", filtroEpoca);

                if (campo != "Agrupacion" && !string.IsNullOrEmpty(filtroAgrupacion))
                    cmd.Parameters.AddWithValue("@agrupacion", filtroAgrupacion);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string valor = reader.IsDBNull(0) ? "Sin clasificar" : reader.GetString(0);
                        recuentos[valor] = reader.GetInt32(1);
                    }
                }
            }

            return recuentos;
        }



        private Dictionary<string, int> ObtenerRecuentoInstrumentos()
        {
            var recuentos = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            string query = "SELECT Instrumentos FROM Partituras WHERE Instrumentos IS NOT NULL";

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string instrumentosRaw = reader.GetString(0);
                        var instrumentos = instrumentosRaw.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var inst in instrumentos)
                        {
                            string limpio = inst.Trim();
                            if (!string.IsNullOrEmpty(limpio))
                            {
                                if (recuentos.ContainsKey(limpio))
                                    recuentos[limpio]++;
                                else
                                    recuentos[limpio] = 1;
                            }
                        }
                    }
                }
            }

            return recuentos;
        }

        private Dictionary<string, int> ObtenerRecuentoInstrumentosConFiltros()
        {
            var recuentos = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            string query = "SELECT Instrumentos FROM vwPartiturasConInstrumentos WHERE Instrumentos IS NOT NULL";

            if (!string.IsNullOrEmpty(filtroEpoca))
                query += " AND Epoca = @epoca";
            if (!string.IsNullOrEmpty(filtroAgrupacion))
                query += " AND Agrupacion = @agrupacion";
            if (!string.IsNullOrEmpty(filtroLicencia))
            {
                if (filtroLicencia == "Gratuita")
                    query += " AND Precio = 0";
                else if (filtroLicencia == "Pago")
                    query += " AND Precio > 0";
            }

            using (var conn = new SqlConnection("Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;"))
            using (var cmd = new SqlCommand(query, conn))
            {
                if (!string.IsNullOrEmpty(filtroEpoca))
                    cmd.Parameters.AddWithValue("@epoca", filtroEpoca);
                if (!string.IsNullOrEmpty(filtroAgrupacion))
                    cmd.Parameters.AddWithValue("@agrupacion", filtroAgrupacion);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string instrumentosRaw = reader.GetString(0);
                        var instrumentos = instrumentosRaw.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var inst in instrumentos)
                        {
                            string limpio = inst.Trim();
                            if (!string.IsNullOrEmpty(limpio))
                            {
                                if (recuentos.ContainsKey(limpio))
                                    recuentos[limpio]++;
                                else
                                    recuentos[limpio] = 1;
                            }
                        }
                    }
                }
            }

            return recuentos;
        }


        private int ObtenerCantidadPorPrecio(int tipo)
        {
            int total = 0;
            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            string query = tipo == 0
                ? "SELECT COUNT(*) FROM Partituras WHERE Precio = 0"
                : "SELECT COUNT(*) FROM Partituras WHERE Precio > 0";

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                total = (int)cmd.ExecuteScalar();
            }

            return total;
        }

        private int ObtenerCantidadPorPrecioConFiltros(int tipo)
        {
            string query = "SELECT COUNT(*) FROM Partituras WHERE 1=1";

            if (tipo == 0)
                query += " AND Precio = 0";
            else
                query += " AND Precio > 0";

            if (!string.IsNullOrEmpty(filtroEpoca))
                query += " AND Epoca = @epoca";

            if (!string.IsNullOrEmpty(filtroAgrupacion))
                query += " AND Agrupacion = @agrupacion";

            foreach (var instrumento in filtrosInstrumentos)
                query += $" AND Instrumentos LIKE '%{instrumento}%'";

            using (var conn = new SqlConnection("Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;"))
            using (var cmd = new SqlCommand(query, conn))
            {
                if (!string.IsNullOrEmpty(filtroEpoca))
                    cmd.Parameters.AddWithValue("@epoca", filtroEpoca);

                if (!string.IsNullOrEmpty(filtroAgrupacion))
                    cmd.Parameters.AddWithValue("@agrupacion", filtroAgrupacion);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }


        private void ActualizarEtiquetasDeFiltros()
        {
            var epocaCounts = ObtenerRecuentoPorCampoConFiltros("Epoca");
            var agrupacionCounts = ObtenerRecuentoPorCampoConFiltros("Agrupacion");
            var instrumentoCounts = ObtenerRecuentoInstrumentosConFiltros();

            int gratuitas = ObtenerCantidadPorPrecioConFiltros(0);
            int pago = ObtenerCantidadPorPrecioConFiltros(1);

            // Licencia
            linkLabelGratuita.Text = $"Gratuita ({gratuitas})";
            linkLabelPago.Text = $"Pago ({pago})";

            // Época
            linkLabelBarroco.Text = $"Barroco ({epocaCounts.GetValueOrDefault("Barroco", 0)})";
            linkLabelClas.Text = $"Clasicismo ({epocaCounts.GetValueOrDefault("Clasicismo", 0)})";
            linkLabelRoman.Text = $"Romanticismo ({epocaCounts.GetValueOrDefault("Romanticismo", 0)})";

            // Agrupación
            linkLabelSolo.Text = $"Solo ({agrupacionCounts.GetValueOrDefault("Solo", 0)})";
            linkLabelCamara.Text = $"Cámara ({agrupacionCounts.GetValueOrDefault("Cámara", 0)})";
            linkLabelOrquesta.Text = $"Orquesta ({agrupacionCounts.GetValueOrDefault("Orquesta", 0)})";
            linkLabelCoro.Text = $"Coro ({agrupacionCounts.GetValueOrDefault("Coro", 0)})";

            // Instrumentos (algunos ejemplos, puedes completar el resto igual)
            linkLabelPiano.Text = $"Piano ({instrumentoCounts.GetValueOrDefault("Piano", 0)})";
            linkLabelViolin.Text = $"Violín ({instrumentoCounts.GetValueOrDefault("Violín", 0)})";
            linkLabelViola.Text = $"Viola ({instrumentoCounts.GetValueOrDefault("Viola", 0)})";
            linkLabelClave.Text = $"Clave ({instrumentoCounts.GetValueOrDefault("Clave", 0)})";
            linkLabelOrgano.Text = $"Órgano ({instrumentoCounts.GetValueOrDefault("Órgano", 0)})";
            linkLabelTrombon.Text = $"Trombón ({instrumentoCounts.GetValueOrDefault("Trombón", 0)})";
            linkLabelTrompa.Text = $"Trompa ({instrumentoCounts.GetValueOrDefault("Trompa", 0)})";
            linkLabelFagot.Text = $"Fagot ({instrumentoCounts.GetValueOrDefault("Fagot", 0)})";
            linkLabelClarinete.Text = $"Clarinete ({instrumentoCounts.GetValueOrDefault("Clarinete", 0)})";
            linkLabelOboe.Text = $"Oboe ({instrumentoCounts.GetValueOrDefault("Oboe", 0)})";
            linkLabelContrabajo.Text = $"Contrabajo ({instrumentoCounts.GetValueOrDefault("Contrabajo", 0)})";
            linkLabelCello.Text = $"Violonchelo ({instrumentoCounts.GetValueOrDefault("Violonchelo", 0)})";
            linkLabelTimbales.Text = $"Timbales ({instrumentoCounts.GetValueOrDefault("Timbales", 0)})";
            linkLabelSoprano.Text = $"Soprano ({instrumentoCounts.GetValueOrDefault("Soprano", 0)})";
            linkLabelTenor.Text = $"Tenor ({instrumentoCounts.GetValueOrDefault("Tenor", 0)})";
            linkLabelMezzo.Text = $"Mezzo ({instrumentoCounts.GetValueOrDefault("Mezzo", 0)})";
            linkLabelBajo.Text = $"Bajo ({instrumentoCounts.GetValueOrDefault("Bajo", 0)})";
            linkLabelFlauta.Text = $"Flauta ({instrumentoCounts.GetValueOrDefault("Flauta", 0)})";
            linkLabelTrompeta.Text = $"Trompeta ({instrumentoCounts.GetValueOrDefault("Trompeta", 0)})";
        }


        private int paginaActual = 1;
        private int totalPaginas = 1;
        private int itemsPorPagina = 8;
        private Button[] botonesPaginas;

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                CargarPagina();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                CargarPagina();
            }
        }

        private void CalcularTotalPaginas()
        {
            string query = "SELECT COUNT(*) FROM Partituras WHERE 1=1";

            if (!string.IsNullOrEmpty(filtroEpoca))
                query += " AND Epoca = @epoca";

            if (!string.IsNullOrEmpty(filtroAgrupacion))
                query += " AND Agrupacion = @agrupacion";

            if (!string.IsNullOrEmpty(filtroLicencia))
            {
                if (filtroLicencia == "Gratuita")
                    query += " AND Precio = 0";
                else if (filtroLicencia == "Pago")
                    query += " AND Precio > 0";
            }

            foreach (var instrumento in filtrosInstrumentos)
            {
                query += $" AND Instrumentos LIKE '%{instrumento}%'";
            }

            using (var conn = new SqlConnection("Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;"))
            using (var cmd = new SqlCommand(query, conn))
            {
                if (!string.IsNullOrEmpty(filtroEpoca))
                    cmd.Parameters.AddWithValue("@epoca", filtroEpoca);
                if (!string.IsNullOrEmpty(filtroAgrupacion))
                    cmd.Parameters.AddWithValue("@agrupacion", filtroAgrupacion);

                conn.Open();
                int totalItems = (int)cmd.ExecuteScalar();
                totalPaginas = (int)Math.Ceiling((double)totalItems / itemsPorPagina);
            }
        }

        private void ActualizarBotonesPaginador()
        {
            int maxVisibles = botonesPaginas.Length;

            int start = Math.Max(1, paginaActual - 2);
            int end = Math.Min(totalPaginas, start + maxVisibles - 1);

            if (end - start < maxVisibles - 1)
                start = Math.Max(1, end - maxVisibles + 1);

            for (int i = 0; i < maxVisibles; i++)
            {
                int numero = start + i;
                Button btn = botonesPaginas[i];

                if (numero <= totalPaginas)
                {
                    btn.Visible = true;
                    btn.Text = numero.ToString();
                    btn.Tag = numero;

                    if (numero == paginaActual)
                    {
                        btn.BackColor = Color.FromArgb(61, 76, 158);
                        btn.ForeColor = Color.White;
                    }
                    else
                    {
                        btn.BackColor = Color.White;
                        btn.ForeColor = Color.Black;
                    }
                }
                else
                {
                    btn.Visible = false;
                }
            }

            btnAnterior.Enabled = paginaActual > 1;
            btnSiguiente.Enabled = paginaActual < totalPaginas;
        }

        private void btnNumero_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is int numero)
            {
                paginaActual = numero;
                CargarPagina();
            }
        }


        private void CargarPagina()
        {
            CalcularTotalPaginas();
            CargarPartituras();
            ActualizarBotonesPaginador();
        }

    }
}
