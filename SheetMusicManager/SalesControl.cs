using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SheetMusicManager
{
    public partial class SalesControl : UserControl
    {
        public SalesControl()
        {
            InitializeComponent();
            CargarVentasUsuario();
        }

        private void CargarVentasUsuario(DateTime? desde = null, DateTime? hasta = null, List<string> licencias = null, List<string> usuarios = null)
        {
            string connectionString = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            string query = @"
        SELECT 
            v.IdPedido, v.Fecha,
            l.TipoLicencia,
            v.Importe AS PrecioTotal,
            u.NombreUsuario AS Comprador,
            p.Id AS IdPartitura,
            p.Nombre AS NombrePartitura,
            p.Compositor,
            (
                SELECT STRING_AGG(i.Nombre, ', ')
                FROM InstrumentosPorPartitura ipp
                JOIN Instrumentos i ON i.Id = ipp.IdInstrumento
                WHERE ipp.IdPartitura = p.Id
            ) AS Instrumentos,
            v.Id
        FROM Ventas v
        JOIN Licencias l ON v.IdLicencia = l.Id
        JOIN Usuarios u ON v.IdComprador = u.Id
        JOIN Partituras p ON v.IdPartitura = p.Id
        WHERE 1=1";

            if (!Session.Admin)
            {
                query += " AND v.IdVendedor = @UsuarioId";
            }
            else if (usuarios != null && usuarios.Count > 0)
            {
                string userFilter = string.Join(",", usuarios.Select((u, i) => $"@User{i}"));
                query += $" AND u.NombreUsuario IN ({userFilter})";
            }

            if (licencias != null && licencias.Count > 0)
            {
                string licenciaFilter = string.Join(",", licencias.Select((l, i) => $"@Lic{i}"));
                query += $" AND l.TipoLicencia IN ({licenciaFilter})";
            }
            if (desde.HasValue)
                query += " AND v.Fecha >= @Desde";
            if (hasta.HasValue)
                query += " AND v.Fecha <= @Hasta";

            query += " ORDER BY v.IdPedido DESC, v.Fecha DESC";

            using var cmd = new SqlCommand(query, conn);

            if (!Session.Admin)
                cmd.Parameters.AddWithValue("@UsuarioId", Session.UsuarioId);
            else if (usuarios != null)
            {
                for (int i = 0; i < usuarios.Count; i++)
                    cmd.Parameters.AddWithValue($"@User{i}", usuarios[i]);
            }

            if (licencias != null)
            {
                for (int i = 0; i < licencias.Count; i++)
                    cmd.Parameters.AddWithValue($"@Lic{i}", licencias[i]);
            }

            if (desde.HasValue)
                cmd.Parameters.AddWithValue("@Desde", desde.Value);
            if (hasta.HasValue)
                cmd.Parameters.AddWithValue("@Hasta", hasta.Value);

            using var reader = cmd.ExecuteReader();

            flowLayoutPanelVentas.Controls.Clear();
            int? pedidoActual = null;
            Panel ventaPanel = null;
            FlowLayoutPanel contenedorPartituras = null;
            decimal total = 0;
            int contadorPartituras = 0;

            while (reader.Read())
            {
                int idPedido = reader.GetInt32(0);
                DateTime fecha = reader.GetDateTime(1);
                string tipo = reader.GetString(2);
                decimal precio = reader.GetDecimal(3);
                string comprador = reader.GetString(4);
                string nombre = reader.GetString(6);
                string compositor = reader.GetString(7);
                string instrumentos = reader.GetString(8);

                if (pedidoActual == null || pedidoActual != idPedido)
                {
                    if (ventaPanel != null)
                    {
                        AgregarTotalYContador(ventaPanel, total, contadorPartituras);
                        flowLayoutPanelVentas.Controls.Add(ventaPanel);
                    }

                    ventaPanel = ClonarPanel(panelVentas);
                    ventaPanel.Visible = true;
                    ventaPanel.Paint += panelVentas_Paint;
                    ventaPanel.Margin = new Padding(0, 0, 0, 25);

                    SetLabelText(ventaPanel, "labelFechaVentaV", $"Fecha venta: {fecha:dd/MM/yyyy}");
                    SetLabelText(ventaPanel, "labelCompradorV", $"{comprador}");

                    pedidoActual = idPedido;
                    total = 0;
                    contadorPartituras = 0;

                    var oldFlow = ventaPanel.Controls.Find("flowPartituras", true).FirstOrDefault() as FlowLayoutPanel;
                    if (oldFlow != null)
                    {
                        var nuevoFlow = new FlowLayoutPanel
                        {
                            Name = "flowPartituras",
                            AutoSize = true,
                            FlowDirection = FlowDirection.TopDown,
                            WrapContents = false,
                            Location = oldFlow.Location,
                            Size = oldFlow.Size,
                            Margin = oldFlow.Margin
                        };
                        ventaPanel.Controls.Remove(oldFlow);
                        ventaPanel.Controls.Add(nuevoFlow);
                        contenedorPartituras = nuevoFlow;
                    }
                }

                Panel partituraPanel = ClonarPanel(panelPartituras);
                partituraPanel.Visible = true;
                SetLabelText(partituraPanel, "labelNombreP", nombre);
                SetLabelText(partituraPanel, "labelCompositorP", compositor);
                SetLabelText(partituraPanel, "labelInstrumentosP", instrumentos);
                SetLabelText(partituraPanel, "labelTiempoP", $"Tiempo de uso: {FormatearLicencia(tipo)}");
                SetLabelText(partituraPanel, "labelPrecioP", $"{precio:0.00}€");

                contenedorPartituras?.Controls.Add(partituraPanel);
                total += precio;
                contadorPartituras++;
            }

            if (ventaPanel != null)
            {
                AgregarTotalYContador(ventaPanel, total, contadorPartituras);
                flowLayoutPanelVentas.Controls.Add(ventaPanel);
            }

            labelMostrar.Visible = flowLayoutPanelVentas.Controls.Count == 0;

        }

        private Panel ClonarPanel(Panel original)
        {
            Panel clone = new Panel
            {
                Size = original.Size,
                BackColor = original.BackColor,
                BorderStyle = original.BorderStyle,
                Margin = original.Margin,
                Padding = original.Padding,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            foreach (Control ctrl in original.Controls)
            {
                Control newCtrl = (Control)Activator.CreateInstance(ctrl.GetType());
                newCtrl.Text = ctrl.Text;
                newCtrl.Size = ctrl.Size;
                newCtrl.Location = ctrl.Location;
                newCtrl.Font = ctrl.Font;
                newCtrl.Name = ctrl.Name;
                newCtrl.BackColor = ctrl.BackColor;
                newCtrl.ForeColor = ctrl.ForeColor;
                newCtrl.Anchor = ctrl.Anchor;

                if (ctrl is PictureBox pbOrig && newCtrl is PictureBox pbNew)
                {
                    pbNew.Image = pbOrig.Image;
                    pbNew.SizeMode = pbOrig.SizeMode;
                }

                clone.Controls.Add(newCtrl);
            }

            return clone;
        }

        private void AgregarTotalYContador(Panel ventaPanel, decimal total, int cantidadPartituras)
        {
            var contenedor = ventaPanel.Controls.Find("flowPartituras", true).FirstOrDefault() as FlowLayoutPanel;
            if (contenedor == null) return;

            // Clona y añade el panel de total
            Panel totalPanel = ClonarPanel(panelTotal);
            totalPanel.Visible = true;
            SetLabelText(totalPanel, "labelPrecioTotalP", $"{total:0.00}€");
            contenedor.Controls.Add(totalPanel);

            // Establece el número de partituras en el label del panel principal
            SetLabelText(ventaPanel, "labelNumeroP", cantidadPartituras.ToString());
        }


        private string FormatearLicencia(string tipo)
        {
            return tipo switch
            {
                "90dias" => "90 días",
                "180dias" => "180 días",
                "1año" or "1ano" => "1 año",
                "permanente" => "Permanente",
                _ => tipo
            };
        }

        private void SetLabelText(Control parent, string controlName, string text)
        {
            var ctrl = parent.Controls.Find(controlName, true).FirstOrDefault();
            if (ctrl != null)
            {
                ctrl.Text = text;
                Debug.WriteLine($"✔ Label '{controlName}' actualizado con: {text}");
            }
            else
            {
                Debug.WriteLine($"⚠ No se encontró el label '{controlName}' en '{parent.Name}'");
            }
        }

        private void panelVentas_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                Color borderColor = Color.FromArgb(61, 76, 158);
                int borderThickness = 2;

                using Pen pen = new Pen(borderColor, borderThickness)
                {
                    Alignment = System.Drawing.Drawing2D.PenAlignment.Inset
                };
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private void CargarUsuarios()
        {
            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            using var conn = new SqlConnection(connStr);
            conn.Open();

            string query = "SELECT NombreUsuario FROM Usuarios ORDER BY NombreUsuario";
            using var cmd = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            cbUsuario.Items.Clear();
            while (reader.Read())
            {
                cbUsuario.Items.Add(reader.GetString(0));
            }
        }

        private void SalesControl_Load(object sender, EventArgs e)
        {
            cbUsuario.Visible = Session.Admin;
            labelUsuario.Visible = Session.Admin;

            cbLicencia.Items.AddRange(new object[]
                {
                    "90 días",
                    "180 días",
                    "1 año",
                    "Permanente"
                });

            if (Session.Admin)
                CargarUsuarios();

            cbLicencia.SelectedIndexChanged += (s, ev) => ActualizarVisibilidadLimpiarVentas();
            dateTimeDesde.ValueChanged += (s, ev) => ActualizarVisibilidadLimpiarVentas();
            dateTimeHasta.ValueChanged += (s, ev) => ActualizarVisibilidadLimpiarVentas();

        }

        private void ActualizarVisibilidadLimpiarVentas()
        {
            bool hayFiltros = dateTimeDesde.Checked || dateTimeHasta.Checked ||
                              !string.IsNullOrWhiteSpace(cbLicencia.Text) ||
                              (Session.Admin && !string.IsNullOrWhiteSpace(cbUsuario.Text));

            labelLimpiar.Visible = hayFiltros;
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            DateTime? fechaDesde = dateTimeDesde.Checked ? dateTimeDesde.Value.Date : (DateTime?)null;
            DateTime? fechaHasta = dateTimeHasta.Checked ? dateTimeHasta.Value.Date : (DateTime?)null;

            string raw = cbLicencia.Text?.Trim().ToLower();
            string tipoLicencia = raw switch
            {
                "90 días" => "90dias",
                "180 días" => "180dias",
                "1 año" => "1año",
                "permanente" => "permanente",
                _ => null
            };

            var licencias = new List<string>();
            if (tipoLicencia != null)
                licencias.Add(tipoLicencia);

            List<string> usuarios = null;
            if (Session.Admin && !string.IsNullOrWhiteSpace(cbUsuario.Text))
                usuarios = new List<string> { cbUsuario.Text };

            CargarVentasUsuario(fechaDesde, fechaHasta, licencias, usuarios);
        }

        private void labelLimpiar_Click(object sender, EventArgs e)
        {
            dateTimeDesde.Value = DateTime.Today;
            dateTimeDesde.Checked = false;

            dateTimeHasta.Value = DateTime.Today;
            dateTimeHasta.Checked = false;

            cbLicencia.SelectedIndex = -1;
            cbUsuario.SelectedIndex = -1;

            CargarVentasUsuario();
            ActualizarVisibilidadLimpiarVentas();
        }
    }
}
