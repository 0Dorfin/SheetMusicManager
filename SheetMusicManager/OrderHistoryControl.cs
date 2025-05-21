using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace SheetMusicManager
{
    public partial class OrderHistoryControl : UserControl
    {
        public OrderHistoryControl()
        {
            InitializeComponent();
            CargarPedidosUsuario();
        }

        private void CargarPedidosUsuario(DateTime? desde = null, DateTime? hasta = null, List<string> licencias = null, List<string> usuarios = null)
        {
            string connStr = DatabaseConnection.ConnectionString;
            using SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query = @"
        SELECT 
            l.IdPedido, l.FechaInicio, l.TipoLicencia,
            p.Id AS IdPartitura,
            p.Nombre AS NombrePartitura, p.Compositor,
            (
                SELECT STRING_AGG(i.Nombre, ', ')
                FROM InstrumentosPorPartitura ipp
                JOIN Instrumentos i ON i.Id = ipp.IdInstrumento
                WHERE ipp.IdPartitura = p.Id
            ) AS Instrumentos,
            l.PrecioTotal
        FROM Licencias l
        JOIN Partituras p ON l.IdPartitura = p.Id
        JOIN Usuarios u ON l.IdUsuario = u.Id
        WHERE l.IdPedido IS NOT NULL";

            // Filtro por usuario
            if (!Session.Admin)
            {
                query += " AND l.IdUsuario = @UsuarioId";
            }
            else if (usuarios != null && usuarios.Count > 0)
            {
                string userFilter = string.Join(",", usuarios.Select((u, i) => $"@User{i}"));
                query += $" AND u.NombreUsuario IN ({userFilter})";
            }

            // Filtro por licencia
            if (licencias != null && licencias.Count > 0)
            {
                string licenciaFilter = string.Join(",", licencias.Select((l, i) => $"@Lic{i}"));
                query += $" AND l.TipoLicencia IN ({licenciaFilter})";
            }

            // Filtro por fecha
            if (desde.HasValue)
                query += " AND l.FechaInicio >= @Desde";
            if (hasta.HasValue)
                query += " AND l.FechaInicio <= @Hasta";

            query += " ORDER BY l.IdPedido DESC, l.FechaInicio DESC";

            using SqlCommand cmd = new SqlCommand(query, conn);

            // Parámetros de sesión o usuarios seleccionados
            if (!Session.Admin)
            {
                cmd.Parameters.AddWithValue("@UsuarioId", Session.UsuarioId);
            }
            else if (usuarios != null)
            {
                for (int i = 0; i < usuarios.Count; i++)
                    cmd.Parameters.AddWithValue($"@User{i}", usuarios[i]);
            }

            // Parámetros de licencia
            if (licencias != null)
            {
                for (int i = 0; i < licencias.Count; i++)
                    cmd.Parameters.AddWithValue($"@Lic{i}", licencias[i]);
            }

            // Parámetros de fecha
            if (desde.HasValue)
                cmd.Parameters.AddWithValue("@Desde", desde.Value);
            if (hasta.HasValue)
                cmd.Parameters.AddWithValue("@Hasta", hasta.Value);

            using SqlDataReader reader = cmd.ExecuteReader();

            flowLayoutPanel1.Controls.Clear();

            int? pedidoActual = null;
            Panel pedidoPanel = null;
            FlowLayoutPanel contenedorPartituras = null;
            decimal total = 0;
            DateTime fechaAnterior = DateTime.Now;
            List<(int Id, string Nombre, string Compositor, decimal Precio)> itemsPedido = new();

            while (reader.Read())
            {
                int idPedido = reader.GetInt32(0);
                DateTime fecha = reader.GetDateTime(1);
                string tipo = reader.GetString(2);
                int idPartitura = reader.GetInt32(3);
                string nombre = reader.GetString(4);
                string compositor = reader.GetString(5);
                string instrumentos = reader.IsDBNull(6) ? "" : reader.GetString(6);
                decimal precio = reader.GetDecimal(7);

                if (pedidoActual == null || pedidoActual != idPedido)
                {
                    if (pedidoPanel != null)
                    {
                        AgregarTotalAlPedido(pedidoPanel, total, pedidoActual.Value, fechaAnterior, itemsPedido);
                        flowLayoutPanel1.Controls.Add(pedidoPanel);
                    }

                    pedidoPanel = ClonarPanel(panelPedido);
                    pedidoPanel.Visible = true;
                    pedidoPanel.Paint += panelPedido_Paint;
                    pedidoPanel.Margin = new Padding(0, 0, 0, 25);
                    SetLabelText(pedidoPanel, "labelFechaPedidoP", $"Fecha pedido: {fecha:dd/MM/yyyy}");

                    var oldFlow = pedidoPanel.Controls.Find("flowPartituras", true).FirstOrDefault() as FlowLayoutPanel;
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
                        pedidoPanel.Controls.Remove(oldFlow);
                        pedidoPanel.Controls.Add(nuevoFlow);
                        contenedorPartituras = nuevoFlow;
                    }

                    total = 0;
                    itemsPedido = new();
                    pedidoActual = idPedido;
                    fechaAnterior = fecha;
                }

                Panel partitura = ClonarPanel(panelPlantillaPartituras);
                partitura.Visible = true;
                SetLabelText(partitura, "labelNombreP", nombre);
                SetLabelText(partitura, "labelCompositorP", compositor);
                SetLabelText(partitura, "labelInstrumentosP", instrumentos);
                SetLabelText(partitura, "labelTiempoP", $"Tiempo de uso: {FormatearLicencia(tipo)}");
                SetLabelText(partitura, "labelPrecioPartitura", $"{precio:0.00}€");

                contenedorPartituras?.Controls.Add(partitura);
                total += precio;
                itemsPedido.Add((idPartitura, nombre, compositor, precio));
            }

            if (pedidoPanel != null)
            {
                AgregarTotalAlPedido(pedidoPanel, total, pedidoActual.Value, fechaAnterior, itemsPedido);
                flowLayoutPanel1.Controls.Add(pedidoPanel);
            }
            labelMostrar.Visible = flowLayoutPanel1.Controls.Count == 0;
        }



        private void AgregarTotalAlPedido(Panel pedidoPanel, decimal total, int pedidoId, DateTime fechaInicio, List<(int Id, string Nombre, string Compositor, decimal Precio)> items)
        {
            var contenedorPartituras = pedidoPanel.Controls.Find("flowPartituras", true).FirstOrDefault() as FlowLayoutPanel;
            if (contenedorPartituras == null) return;

            Panel totalPanel = ClonarPanel(panelTotal);
            totalPanel.Visible = true;
            SetLabelText(totalPanel, "labelPrecioP", $"{total:0.00}€");
            SetLabelText(pedidoPanel, "labelNumeroP", $"{items.Count}");

            var btn = totalPanel.Controls.Find("btnRecibo", true).FirstOrDefault() as Button;
            if (btn != null)
            {
                btn.Click += (s, e) =>
                {
                    string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"recibo_pedido_{pedidoId}.pdf");
                    string numFactura = GenerarNumeroFactura();
                    GenerarReciboPDF(filePath, items, numFactura, "Paypal", fechaInicio, pedidoId);
                    MessageBox.Show("Recibo generado en el escritorio.", "PDF Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
            }

            contenedorPartituras.Controls.Add(totalPanel);
        }

        private string GenerarNumeroFactura()
        {
            string año = DateTime.Now.Year.ToString();
            string path = Path.Combine(Application.StartupPath, $"ultimo_num_factura_{año}.txt");

            int numero = 1;

            if (File.Exists(path))
            {
                string contenido = File.ReadAllText(path);
                if (int.TryParse(contenido, out int ultimo))
                {
                    numero = ultimo + 1;
                }
            }

            File.WriteAllText(path, numero.ToString());

            return $"{año}-{numero:D4}";
        }


        public void GenerarReciboPDF(string filePath, List<(int Id, string Nombre, string Compositor, decimal Precio)> items, string numFactura, string formaPago, DateTime fecha, int idPedido)
        {
            var doc = new Document();
            var section = doc.AddSection();
            section.PageSetup.TopMargin = Unit.FromCentimeter(2);

            // Tabla de cabecera con logo y datos de empresa
            var headerTable = section.AddTable();
            headerTable.Borders.Width = 0;
            headerTable.AddColumn(Unit.FromCentimeter(10)); // Logo
            headerTable.AddColumn(Unit.FromCentimeter(7));  // Datos empresa

            section.PageSetup.TopMargin = Unit.FromCentimeter(1); // Menor margen superior

            var headerRow = headerTable.AddRow();
            headerRow.Height = Unit.FromCentimeter(2.5); // Menor altura para que suba
            headerRow.HeightRule = RowHeightRule.Exactly;
            headerRow.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            headerRow.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;


            // Celda de logo
            var logoPath = Path.Combine(Application.StartupPath, "Iconos", "logo.png");
            if (System.IO.File.Exists(logoPath))
            {
                var image = headerRow.Cells[0].AddImage(logoPath);
                image.Height = "3.3cm";
                image.LockAspectRatio = true;
            }
            else
            {
                headerRow.Cells[0].AddParagraph("LOGO").Format.Font.Bold = true;
            }

            // Celda de datos empresa
            var empresa = headerRow.Cells[1].AddParagraph();

            headerRow.Cells[1].VerticalAlignment = VerticalAlignment.Top;
            headerRow.Cells[1].Format.SpaceBefore = 0;
            headerRow.Cells[1].Format.SpaceAfter = 0;
            empresa.Format.SpaceAfter = 0;

            empresa.AddFormattedText("Sheetify", TextFormat.Bold);
            empresa.AddLineBreak();
            empresa.AddText("Avenida de América 22");
            empresa.AddLineBreak();
            empresa.AddText("28028 Madrid, España");
            empresa.AddLineBreak();
            empresa.AddText("CIF: B12345678");
            empresa.Format.Alignment = ParagraphAlignment.Right;

            // Título
            var title = section.AddParagraph("FACTURA SIMPLIFICADA");
            title.Format.Font.Size = 22;
            title.Format.SpaceAfter = "1cm";
            title.Format.Alignment = ParagraphAlignment.Center;

            // Info de factura
            var infoTable = section.AddTable();
            infoTable.AddColumn(Unit.FromCentimeter(6));
            infoTable.AddColumn(Unit.FromCentimeter(5));
            infoTable.AddColumn(Unit.FromCentimeter(5));

            var infoRow = infoTable.AddRow();
            infoRow.Cells[0].AddParagraph($"Nº de factura: {numFactura}");
            infoRow.Cells[1].AddParagraph($"Fecha: {fecha:dd/MM/yyyy}");
            infoRow.Cells[2].AddParagraph($"Forma de pago: {formaPago}");
            infoTable.Format.SpaceAfter = "0.8cm";

            var pedidoParrafo = section.AddParagraph($"Pedido: {idPedido}");
            pedidoParrafo.Format.SpaceAfter = "0.8cm";
            pedidoParrafo.Format.Font.Size = 10;

            // Tabla de artículos
            var table = section.AddTable();
            table.Borders.Width = 0.75;
            table.AddColumn(Unit.FromCentimeter(2.5));
            table.AddColumn(Unit.FromCentimeter(6));
            table.AddColumn(Unit.FromCentimeter(3));
            table.AddColumn(Unit.FromCentimeter(2.5));
            table.AddColumn(Unit.FromCentimeter(3));

            var header = table.AddRow();
            header.Shading.Color = Colors.LightGray;
            header.Height = Unit.FromCentimeter(0.8);
            header.HeadingFormat = true;
            header.Format.Font.Bold = true;
            header.VerticalAlignment = VerticalAlignment.Center;

            string[] headers = { "Código", "Artículo", "Precio", "Cantidad", "Total" };
            for (int i = 0; i < headers.Length; i++)
            {
                var paragraph = header.Cells[i].AddParagraph(headers[i]);

                header.Cells[i].Format.Alignment = ParagraphAlignment.Left;
                paragraph.Format.Alignment = ParagraphAlignment.Left;
                paragraph.Format.Font.Bold = true;
            }

            decimal total = 0;
            foreach (var (Id, Nombre, Compositor, Precio) in items)
            {
                var row = table.AddRow();
                row.Height = Unit.FromCentimeter(0.8);
                row.VerticalAlignment = VerticalAlignment.Center;

                decimal precioSinIVA = Precio / 1.21m;

                row.Cells[0].AddParagraph(Id.ToString());
                row.Cells[1].AddParagraph($"{Nombre} - {Compositor}");
                row.Cells[2].AddParagraph($"{Precio:0.00} €");
                row.Cells[3].AddParagraph("1");
                row.Cells[4].AddParagraph($"{precioSinIVA:0.00} €");
                total += Precio;
            }

            section.AddParagraph().Format.SpaceAfter = "0.25cm";

            // Tabla resumen de totales
            var resumen = section.AddTable();
            resumen.Borders.Width = 0.75;
            resumen.AddColumn(Unit.FromCentimeter(6));
            resumen.AddColumn(Unit.FromCentimeter(4));
            resumen.AddColumn(Unit.FromCentimeter(7));

            // Fila de encabezado
            var resumenHeader = resumen.AddRow();
            resumenHeader.Shading.Color = Colors.LightGray;
            resumenHeader.Height = Unit.FromCentimeter(0.8);
            resumenHeader.HeadingFormat = true;
            resumenHeader.Format.Font.Bold = true;
            resumenHeader.VerticalAlignment = VerticalAlignment.Center;

            resumenHeader.Cells[0].AddParagraph("Base Imponible");
            resumenHeader.Cells[1].AddParagraph("IVA");
            resumenHeader.Cells[2].AddParagraph("Total factura");

            decimal baseImponible = total / 1.21m;
            decimal ivaIncluido = total - baseImponible;

            // Fila de datos
            var resumenRow = resumen.AddRow();
            resumenRow.Height = Unit.FromCentimeter(0.8);
            resumenRow.VerticalAlignment = VerticalAlignment.Center;

            resumenRow.Cells[0].AddParagraph($"{baseImponible:0.00} €");
            resumenRow.Cells[1].AddParagraph($"21% ({ivaIncluido:0.00} €)");
            resumenRow.Cells[2].AddParagraph($"{total:0.00} €");

            // Fila de total a pagar (en negrita y a la derecha)
            var pagarRow = resumen.AddRow();
            pagarRow.Height = Unit.FromCentimeter(0.8);
            pagarRow.VerticalAlignment = VerticalAlignment.Center;
            pagarRow.Cells[0].MergeRight = 1;

            var label = pagarRow.Cells[0].AddParagraph("TOTAL A PAGAR");
            label.Format.Font.Bold = true;
            label.Format.Alignment = ParagraphAlignment.Right;

            var totalCell = pagarRow.Cells[2].AddParagraph($"{total:0.00} €");
            totalCell.Format.Font.Bold = true;

            var pdfRenderer = new PdfDocumentRenderer(true);
            pdfRenderer.Document = doc;
            pdfRenderer.RenderDocument();
            pdfRenderer.PdfDocument.Save(filePath);
            Process.Start("explorer.exe", filePath);
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

                if (ctrl is PictureBox origPic && newCtrl is PictureBox newPic)
                {
                    newPic.Image = origPic.Image;
                    newPic.SizeMode = origPic.SizeMode;
                }

                clone.Controls.Add(newCtrl);
            }

            return clone;
        }

        private void SetLabelText(Control parent, string name, string text)
        {
            var label = parent.Controls.Find(name, true).FirstOrDefault();
            if (label != null) label.Text = text;
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

        private void OrderHistoryControl_Load(object sender, EventArgs e)
        {
            cbUsuario.Visible = Session.Admin;
            labelUsuario.Visible = Session.Admin;

            cbLicencia.SelectedIndexChanged += (s, ev) => ActualizarVisibilidadLimpiar();
            cbUsuario.SelectedIndexChanged += (s, ev) => ActualizarVisibilidadLimpiar();
            dateTimeDesde.ValueChanged += (s, ev) => ActualizarVisibilidadLimpiar();
            dateTimeHasta.ValueChanged += (s, ev) => ActualizarVisibilidadLimpiar();

            CargarLicencias();

            if (Session.Admin)
                CargarUsuarios();

            CargarPedidosUsuario();
        }

        private void CargarLicencias()
        {
            var licencias = new[] { "90 dias", "180 dias", "1 año", "Permanente" };
            cbLicencia.Items.Clear();
            cbLicencia.Items.AddRange(licencias);
        }

        private void CargarUsuarios()
        {
            string connStr = DatabaseConnection.ConnectionString;
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


        private void panelPedido_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            if (panel != null)
            {
                System.Drawing.Color borderColor = System.Drawing.Color.FromArgb(61, 76, 158);
                int borderThickness = 2;
                using (Pen pen = new Pen(borderColor, borderThickness))
                {
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnAplicar_Click(object sender, EventArgs e)
        {
            DateTime? fechaDesde = dateTimeDesde.Checked ? dateTimeDesde.Value.Date : (DateTime?)null;
            DateTime? fechaHasta = dateTimeHasta.Checked ? dateTimeHasta.Value.Date : (DateTime?)null;

            // Licencia seleccionada (ComboBox con nombres bonitos)
            var licencias = new List<string>();
            string raw = cbLicencia.Text?.Trim().ToLower();
            string tipoLicencia = raw switch
            {
                "90 días" => "90dias",
                "180 días" => "180dias",
                "1 año" => "1año",
                "permanente" => "permanente",
                _ => null
            };
            if (tipoLicencia != null)
                licencias.Add(tipoLicencia);

            // Usuario seleccionado (solo si es admin)
            List<string> usuarios = null;
            if (Session.Admin && !string.IsNullOrWhiteSpace(cbUsuario.Text))
                usuarios = new List<string> { cbUsuario.Text };

            // Ejecutar filtro
            CargarPedidosUsuario(fechaDesde, fechaHasta, licencias, usuarios);
        }


        private void ActualizarVisibilidadLimpiar()
        {
            bool hayFiltros = dateTimeDesde.Checked || dateTimeHasta.Checked ||
                              !string.IsNullOrWhiteSpace(cbLicencia.Text) ||
                              (Session.Admin && !string.IsNullOrWhiteSpace(cbUsuario.Text));

            labelLimpiar.Visible = hayFiltros;
        }


        private void labelLimpiar_Click(object sender, EventArgs e)
        {
            dateTimeDesde.Value = DateTime.Today;
            dateTimeDesde.Checked = false;

            dateTimeHasta.Value = DateTime.Today;
            dateTimeHasta.Checked = false;

            cbLicencia.SelectedIndex = -1;
            cbUsuario.SelectedIndex = -1;

            CargarPedidosUsuario();
            ActualizarVisibilidadLimpiar();
        }
    }
}
