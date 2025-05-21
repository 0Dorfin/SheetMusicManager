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
        private List<LinkLabel> filtrosCategoria = new List<LinkLabel>();
        private List<LinkLabel> filtrosEpoca = new List<LinkLabel>();
        private List<LinkLabel> filtrosAgrupacion = new List<LinkLabel>();

        private string filtroCategoria = "";
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
            labelUsuario.Text = ObtenerNombreUsuario();

            CargarPartituras();

            ActualizarEtiquetasDeFiltros();

            AgregarFiltroConEventos(linkLabelComprada, linkXComprada);
            AgregarFiltroConEventos(linkLabelGratuita, linkXGratuita);
            AgregarFiltroConEventos(linkLabelPropia, linkXPropia);
            AgregarFiltroConEventos(linkLabelFavorita, linkXFavorita);

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

            filtrosCategoria.AddRange(new[] { linkLabelComprada, linkLabelGratuita, linkLabelPropia, linkLabelFavorita });
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
            string texto = filtro.Text.Split('(')[0].Trim();

            if (filtrosEpoca.Contains(filtro))
            {
                DesactivarGrupo(filtrosEpoca);
                filtroEpoca = texto;
            }
            else if (filtrosCategoria.Contains(filtro))
            {
                DesactivarGrupo(filtrosCategoria);
                filtroCategoria = texto;
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
                string texto = filtro.Text.Split('(')[0].Trim();

                if (filtrosEpoca.Contains(filtro)) filtroEpoca = "";
                else if (filtrosCategoria.Contains(filtro)) filtroCategoria = "";
                else if (filtrosAgrupacion.Contains(filtro)) filtroAgrupacion = "";
                else filtrosInstrumentos.Remove(texto);

                DesactivarFiltro(filtro, botonCerrar);
                if (string.IsNullOrEmpty(filtroCategoria))
                    lblPartituras.Text = "Todas las partituras";
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

        private void CargarPartituras()
        {
            flowPartiturasPanel.Controls.Clear();

            MessageBox.Show(
        $"Session.Admin = {Session.Admin}\nSession.UsuarioId = {Session.UsuarioId}",
        "Verificando sesión",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information
    );

            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
            SELECT 
                p.Id, p.Nombre, p.Compositor, p.Epoca, p.Agrupacion,
                ISNULL(STUFF((
                    SELECT ', ' + i.Nombre
                    FROM InstrumentosPorPartitura ipp
                    JOIN Instrumentos i ON ipp.IdInstrumento = i.Id
                    WHERE ipp.IdPartitura = p.Id
                    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, ''), '') AS Instrumentos,
                p.FechaSubida, p.Precio, p.ArchivoPDF,
                ISNULL(up.Tipo, '') as Tipo, 
                l.TipoLicencia
            FROM Partituras p
        ";

                if (!Session.Admin)
                {
                    query += @"
                LEFT JOIN PartiturasUsuario up ON p.Id = up.PartituraId AND up.UsuarioId = @usuarioId";
                }
                else
                {
                    query += @"
                LEFT JOIN PartiturasUsuario up ON p.Id = up.PartituraId";
                }

                query += @"
            LEFT JOIN (
                SELECT *, ROW_NUMBER() OVER (PARTITION BY IdPartitura ORDER BY FechaInicio DESC) AS rn
                FROM Licencias
            ) l ON l.IdPartitura = p.Id AND l.rn = 1
            WHERE 1 = 1";

                if (!Session.Admin)
                {
                    query += " AND up.UsuarioId IS NOT NULL";
                }

                if (!string.IsNullOrEmpty(filtroCategoria))
                {
                    if (filtroCategoria.ToLower() == "favorita")
                        query += " AND EXISTS (SELECT 1 FROM Favoritos f WHERE f.IdUsuario = @usuarioId AND f.IdPartitura = p.Id)";
                    else
                        query += " AND up.Tipo = @tipo";
                }

                if (!string.IsNullOrEmpty(filtroEpoca))
                    query += " AND p.Epoca = @epoca";

                if (!string.IsNullOrEmpty(filtroAgrupacion))
                    query += " AND p.Agrupacion = @agrupacion";

                if (!string.IsNullOrEmpty(textoBusqueda))
                    query += " AND (p.Nombre LIKE @texto OR p.Compositor LIKE @texto)";

                if (filtrosInstrumentos.Any())
                {
                    query += " AND EXISTS (SELECT 1 FROM InstrumentosPorPartitura ipp JOIN Instrumentos i ON ipp.IdInstrumento = i.Id WHERE ipp.IdPartitura = p.Id";
                    foreach (var instrumento in filtrosInstrumentos)
                    {
                        query += $" AND i.Nombre LIKE '%{instrumento}%'";
                    }
                    query += ")";
                }

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuarioId", Session.UsuarioId);

                if (!string.IsNullOrEmpty(filtroCategoria))
                {
                    switch (filtroCategoria.ToLower())
                    {
                        case "comprada":
                            lblPartituras.Text = "Partituras compradas";
                            break;
                        case "propia":
                            lblPartituras.Text = "Partituras propias";
                            break;
                        case "gratuita":
                            lblPartituras.Text = "Partituras gratuitas";
                            break;
                    }

                    if (filtroCategoria.ToLower() != "favorita")
                        cmd.Parameters.AddWithValue("@tipo", filtroCategoria);
                }

                if (!string.IsNullOrEmpty(filtroEpoca))
                    cmd.Parameters.AddWithValue("@epoca", filtroEpoca);

                if (!string.IsNullOrEmpty(filtroAgrupacion))
                    cmd.Parameters.AddWithValue("@agrupacion", filtroAgrupacion);

                if (!string.IsNullOrEmpty(textoBusqueda))
                    cmd.Parameters.AddWithValue("@texto", "%" + textoBusqueda + "%");

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string compositor = reader.GetString(2);
                        string epoca = reader.GetString(3);
                        string agrupacion = reader.GetString(4);
                        string instrumentos = reader.GetString(5);
                        DateTime fecha = reader.GetDateTime(6);
                        decimal precio = reader.GetDecimal(7);
                        byte[] archivoPDF = (byte[])reader[8];
                        string tipo = reader.GetString(9);
                        string tipoLicencia = reader.IsDBNull(10) ? "" : reader.GetString(10);

                        var fila = ClonarPanelPlantilla(id, nombre, compositor, epoca, agrupacion, instrumentos, fecha, precio, archivoPDF);

                        bool puedeVer, puedeDescargar, puedeEditar, puedeBorrar;

                        if (Session.Admin)
                        {
                            puedeVer = true;
                            puedeDescargar = true;
                            puedeEditar = true;
                            puedeBorrar = true;
                        }
                        else
                        {
                            puedeVer = tipo == "Propia" || !string.IsNullOrEmpty(tipoLicencia);
                            puedeDescargar = tipo == "Propia" || tipoLicencia == "permanente";
                            puedeEditar = tipo == "Propia";
                            puedeBorrar = tipo == "Propia";
                        }

                        foreach (Control ctrl in fila.Controls)
                        {
                            if (ctrl is PictureBox pb)
                            {
                                if (pb.Name.Contains("Ver"))
                                    pb.Visible = puedeVer;
                                else if (pb.Name.Contains("Descargar"))
                                    pb.Visible = puedeDescargar;
                                else if (pb.Name.Contains("Editar"))
                                    pb.Visible = puedeEditar;
                                else if (pb.Name.Contains("Eliminar"))
                                    pb.Visible = puedeBorrar;
                            }
                        }

                        flowPartiturasPanel.Controls.Add(fila);
                    }
                }
                labelMostrar.Visible = flowPartiturasPanel.Controls.Count == 0;
            }
        }



        private Panel ClonarPanelPlantilla(int id, string nombre, string compositor, string epoca, string agrupacion, string instrumentos, DateTime fecha, decimal precio, byte[] archivoPDF)
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
                    nuevoImg.Name = originalImg.Name;
                    nuevoImg.Cursor = Cursors.Hand;

                    if (originalImg.Name.Contains("Ver"))
                        nuevoImg.Click += (s, e) => VerPartitura(id);
                    else if (originalImg.Name.Contains("Eliminar"))
                        nuevoImg.Click += (s, e) => EliminarPartitura(id);
                    else if (originalImg.Name.Contains("Editar"))
                    {
                        nuevoImg.Click += (s, e) =>
                        {
                            var partitura = new Partitura
                            {
                                Id = id,
                                Nombre = nombre,
                                Compositor = compositor,
                                Epoca = epoca,
                                Agrupacion = agrupacion,
                                Instrumentos = instrumentos,
                                Precio = precio,
                                ArchivoPDF = archivoPDF

                            };

                            AbrirEditorDePartitura(partitura);
                        };
                    }

                }

                panelClone.Controls.Add(clonado);
            }

            return panelClone;
        }

        private void AbrirEditorDePartitura(Partitura partitura)
        {
            MessageBox.Show("Abriendo editor para: " + partitura.Nombre);

            var mainForm = this.FindForm() as MainForm;
            if (mainForm != null)
            {
                mainForm.MostrarEditorPartitura(partitura);
            }
        }

        private Dictionary<string, int> ObtenerRecuentoCategoriasUsuario()
        {
            Dictionary<string, int> recuentos = new Dictionary<string, int>();
            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(@"SELECT Tipo, COUNT(*) FROM PartiturasUsuario WHERE UsuarioId = @uid GROUP BY Tipo", conn))
            {
                cmd.Parameters.AddWithValue("@uid", Session.UsuarioId);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        recuentos[reader.GetString(0)] = reader.GetInt32(1);
                }
            }
            return recuentos;
        }

        private string ObtenerNombreUsuario()
        {
            string nombre = "Usuario";
            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT NombreUsuario FROM Usuarios WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Session.UsuarioId);
                    var resultado = cmd.ExecuteScalar();
                    if (resultado != null)
                        nombre = resultado.ToString();
                }
            }
            return nombre;
        }

        private Dictionary<string, int> ObtenerRecuentoInstrumentosUsuario()
        {
            var recuentos = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            string query = @"
                SELECT i.Nombre, COUNT(*) AS Total
                FROM PartiturasUsuario pu
                INNER JOIN InstrumentosPorPartitura ipp ON pu.PartituraId = ipp.IdPartitura
                INNER JOIN Instrumentos i ON ipp.IdInstrumento = i.Id
                WHERE pu.UsuarioId = @uid
                GROUP BY i.Nombre";

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@uid", Session.UsuarioId);
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


        private Dictionary<string, int> ObtenerRecuentoPorCampo(string campo)
        {
            Dictionary<string, int> recuentos = new Dictionary<string, int>();
            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
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

        private Dictionary<string, int> ObtenerRecuentoCategoriasAdmin()
        {
            var recuentos = new Dictionary<string, int>();
            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            string query = "SELECT Tipo, COUNT(*) FROM PartiturasUsuario GROUP BY Tipo";

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        recuentos[reader.GetString(0)] = reader.GetInt32(1);
                }
            }
            return recuentos;
        }

        private Dictionary<string, int> ObtenerRecuentoInstrumentosAdmin()
        {
            var recuentos = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            string query = @"
        SELECT i.Nombre, COUNT(*) AS Total
        FROM InstrumentosPorPartitura ipp
        JOIN Instrumentos i ON ipp.IdInstrumento = i.Id
        GROUP BY i.Nombre";

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader.GetString(0).Trim();
                        if (!string.IsNullOrEmpty(nombre))
                            recuentos[nombre] = reader.GetInt32(1);
                    }
                }
            }
            return recuentos;
        }


        private Dictionary<string, int> ObtenerRecuentoPorCampoUsuario(string campo)
        {
            var recuentos = new Dictionary<string, int>();
            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            string query = $@"
                SELECT p.{campo}, COUNT(*) 
                FROM Partituras p
                INNER JOIN PartiturasUsuario up ON p.Id = up.PartituraId
                WHERE up.UsuarioId = @uid
                GROUP BY p.{campo}";

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@uid", Session.UsuarioId);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string valor = reader.IsDBNull(0) ? "Sin clasificar" : reader.GetString(0);
                recuentos[valor] = reader.GetInt32(1);
            }
            return recuentos;
        }

        private void VerPartitura(int id)
        {
            try
            {
                string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string tipoLicencia = null;
                    DateTime? fechaFin = null;

                    // Buscar licencia si existe
                    var licenciaCmd = new SqlCommand(@"
                SELECT TipoLicencia, FechaFin 
                FROM Licencias 
                WHERE IdUsuario = @uid AND IdPartitura = @pid", conn);

                    licenciaCmd.Parameters.AddWithValue("@uid", Session.UsuarioId);
                    licenciaCmd.Parameters.AddWithValue("@pid", id);

                    using (var reader = licenciaCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tipoLicencia = reader.GetString(0);
                            fechaFin = reader.IsDBNull(1) ? null : reader.GetDateTime(1);
                        }
                    }

                    bool tieneLicenciaValida = tipoLicencia == "permanente" || (fechaFin != null && fechaFin >= DateTime.Now);

                    if (!tieneLicenciaValida)
                    {
                        var tipoCmd = new SqlCommand(@"
                    SELECT Tipo 
                    FROM PartiturasUsuario 
                    WHERE UsuarioId = @uid AND PartituraId = @pid", conn);
                        tipoCmd.Parameters.AddWithValue("@uid", Session.UsuarioId);
                        tipoCmd.Parameters.AddWithValue("@pid", id);

                        var tipo = tipoCmd.ExecuteScalar() as string;

                        if (tipo != "Gratuita" && tipo != "Propia")
                        {
                            MessageBox.Show("No tienes licencia para ver esta partitura.");
                            return;
                        }
                    }

                    var nombreCmd = new SqlCommand("SELECT Nombre FROM Partituras WHERE Id = @id", conn);
                    nombreCmd.Parameters.AddWithValue("@id", id);
                    string nombrePartitura = (string)nombreCmd.ExecuteScalar();

                    var pdfCmd = new SqlCommand("SELECT ArchivoPDF FROM Partituras WHERE Id = @id", conn);
                    pdfCmd.Parameters.AddWithValue("@id", id);
                    var pdfReader = pdfCmd.ExecuteReader();

                    if (pdfReader.Read())
                    {
                        byte[] pdfBytes = (byte[])pdfReader["ArchivoPDF"];

                        using (var stream = new MemoryStream(pdfBytes))
                        using (var doc = PdfiumViewer.PdfDocument.Load(stream))
                        {
                            var form = new Form
                            {
                                Text = nombrePartitura,
                                Width = 1000,
                                Height = 800
                            };

                            var viewer = new PdfiumViewer.PdfViewer
                            {
                                Dock = DockStyle.Fill,
                                ShowToolbar = false,
                                Document = doc
                            };

                            form.Icon = new Icon(Path.Combine(Application.StartupPath, "Iconos", "logo.ico"));
                            form.Controls.Add(viewer);
                            form.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la partitura: " + ex.Message);
            }
        }

        private void ActualizarEtiquetasDeFiltros()
        {
            Dictionary<string, int> categorias, epocaCounts, agrupacionCounts, instrumentoCounts;

            if (Session.Admin)
            {
                categorias = ObtenerRecuentoCategoriasAdmin();
                epocaCounts = ObtenerRecuentoPorCampo("Epoca");
                agrupacionCounts = ObtenerRecuentoPorCampo("Agrupacion");
                instrumentoCounts = ObtenerRecuentoInstrumentosAdmin();
            }
            else
            {
                categorias = ObtenerRecuentoCategoriasUsuario();
                epocaCounts = ObtenerRecuentoPorCampoUsuario("Epoca");
                agrupacionCounts = ObtenerRecuentoPorCampoUsuario("Agrupacion");
                instrumentoCounts = ObtenerRecuentoInstrumentosUsuario();
            }

            int favoritas = Session.Admin ? 0 : ObtenerRecuentoFavoritas();
            linkLabelFavorita.Text = $"Favorita ({favoritas})";
            linkLabelPropia.Text = $"Propia ({categorias.GetValueOrDefault("Propia", 0)})";
            linkLabelComprada.Text = $"Comprada ({categorias.GetValueOrDefault("Comprada", 0)})";
            linkLabelGratuita.Text = $"Gratuita ({categorias.GetValueOrDefault("Gratuita", 0)})";

            linkLabelBarroco.Text = $"Barroco ({epocaCounts.GetValueOrDefault("Barroco", 0)})";
            linkLabelClas.Text = $"Clasicismo ({epocaCounts.GetValueOrDefault("Clasicismo", 0)})";
            linkLabelRoman.Text = $"Romanticismo ({epocaCounts.GetValueOrDefault("Romanticismo", 0)})";

            linkLabelSolo.Text = $"Solo ({agrupacionCounts.GetValueOrDefault("Solo", 0)})";
            linkLabelCamara.Text = $"Cámara ({agrupacionCounts.GetValueOrDefault("Cámara", 0)})";
            linkLabelOrquesta.Text = $"Orquesta ({agrupacionCounts.GetValueOrDefault("Orquesta", 0)})";
            linkLabelCoro.Text = $"Coro ({agrupacionCounts.GetValueOrDefault("Coro", 0)})";

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


        private int ObtenerRecuentoFavoritas()
        {
            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            using var conn = new SqlConnection(connStr);
            var cmd = new SqlCommand("SELECT COUNT(*) FROM Favoritos WHERE IdUsuario = @uid", conn);
            cmd.Parameters.AddWithValue("@uid", Session.UsuarioId);
            conn.Open();
            return (int)cmd.ExecuteScalar();
        }

        private void EliminarPartitura(int id)
        {
            var confirm = MessageBox.Show("¿Seguro que quieres eliminar permanentemente esta partitura?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
            DELETE FROM Ventas WHERE IdPartitura = @id;
            DELETE FROM Licencias WHERE IdPartitura = @id;
            DELETE FROM PartiturasUsuario WHERE PartituraId = @id;
            DELETE FROM Favoritos WHERE IdPartitura = @id;
            DELETE FROM Carrito WHERE IdPartitura = @id;
            DELETE FROM Partituras WHERE Id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                CargarPartituras();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }


        private void ActualizarVisibilidadBotonLimpiar()
        {
            bool hayFiltros = !string.IsNullOrEmpty(filtroCategoria) ||
                              !string.IsNullOrEmpty(filtroEpoca) ||
                              !string.IsNullOrEmpty(filtroAgrupacion) ||
                              filtrosInstrumentos.Count > 0;

            labelLimpiar.Visible = hayFiltros;
        }

        private void labelLimpiar_Click(object sender, EventArgs e)
        {
            filtroCategoria = "";
            filtroEpoca = "";
            filtroAgrupacion = "";
            filtrosInstrumentos.Clear();

            foreach (var filtro in mapaFiltros.Keys)
            {
                DesactivarFiltro(filtro, mapaFiltros[filtro]);
            }

            lblPartituras.Text = "Todas las partituras";
            CargarPartituras();
            ActualizarVisibilidadBotonLimpiar();
        }
    }
}
