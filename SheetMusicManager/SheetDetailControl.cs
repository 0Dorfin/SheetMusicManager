using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PdfiumViewer;
using System.Data.SqlClient;

namespace SheetMusicManager
{
    public partial class SheetDetailControl : UserControl
    {
        private int idPartitura;
        private int idUsuario;

        public SheetDetailControl(int idPartitura, int idUsuario)
        {
            InitializeComponent();
            this.idPartitura = idPartitura;
            this.idUsuario = idUsuario;

            CargarDetallePartitura();
            RegistrarEventos();
        }

        private void RegistrarEventos()
        {
            radio90.CheckedChanged += LicenciaSeleccionada;
            radio180.CheckedChanged += LicenciaSeleccionada;
            radio365.CheckedChanged += LicenciaSeleccionada;
            radioPermanente.CheckedChanged += LicenciaSeleccionada;
        }

        private void LicenciaSeleccionada(object sender, EventArgs e)
        {
            string tipo = GetTipoLicenciaSeleccionado();
            string texto = FormatearTextoLicencia(tipo);
            labelTiempoP.Text = texto;

            decimal precioActual = CalcularPrecioPorTipo(tipo);
            labelPrecioP.Text = $"{precioActual:F2}€";
        }

        private string FormatearTextoLicencia(string tipo)
        {
            return tipo switch
            {
                "90dias" => "90 días",
                "180dias" => "180 días",
                "1año" or "1ano" => "1 año",
                "permanente" => "Permanente",
                _ => ""
            };
        }

        private void CargarDetallePartitura()
        {
            var licencia = ObtenerLicenciaActiva(idUsuario, idPartitura);
            string licenciaActiva = licencia.tipo;
            bool tieneLicencia = licenciaActiva != null;
            int paginasMostrar = tieneLicencia ? 10 : 3;

            if (tieneLicencia)
            {
                string textoTipo = FormatearTextoLicencia(licenciaActiva);
                labelTiempoP.Text = textoTipo;
                labelLicenciaComprada.Visible = true;
                labelVencimiento.Visible = true;
                btnDescargar.Visible = true;
                pictureBoxDescargar.Image = CargarIcono("download_blanco.png");
                pictureBoxDescargar.Visible = true;
                pictureBoxDescargar.BringToFront();
                pictureBoxDescargar.Refresh();

                if (licencia.fechaFin.HasValue)
                {
                    labelLicenciaComprada.Text = $"Licencia comprada de {textoTipo}";
                    labelVencimiento.Text = $"Vence el {licencia.fechaFin.Value:dd/MM/yyyy}";
                }
                else
                {
                    labelLicenciaComprada.Text = "Licencia permanente comprada";
                    labelVencimiento.Text = "";
                }

                if (licenciaActiva == "90dias") radio90.Enabled = false;
                else if (licenciaActiva == "180dias") { radio90.Enabled = false; radio180.Enabled = false; }
                else if (licenciaActiva == "1año" || licenciaActiva == "1ano") { radio90.Enabled = false; radio180.Enabled = false; radio365.Enabled = false; }
                else if (licenciaActiva == "permanente") { radio90.Enabled = false; radio180.Enabled = false; radio365.Enabled = false; radioPermanente.Enabled = false; }
            }
            else
            {
                labelLicenciaComprada.Visible = false;
                btnDescargar.Visible = false;
                pictureBoxDescargar.Visible = false;
                labelTiempoP.Text = "";
                labelVencimiento.Text = "";
            }

            string connStr = DatabaseConnection.ConnectionString;
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT 
                        P.Nombre, 
                        P.Compositor, 
                        P.Epoca, 
                        P.Agrupacion,
                        STRING_AGG(I.Nombre, ', ') AS Instrumentos,
                        P.ArchivoPDF, 
                        P.Precio
                    FROM Partituras P
                    LEFT JOIN InstrumentosPorPartitura IPP ON P.Id = IPP.IdPartitura
                    LEFT JOIN Instrumentos I ON IPP.IdInstrumento = I.Id
                    WHERE P.Id = @id
                    GROUP BY P.Nombre, P.Compositor, P.Epoca, P.Agrupacion, P.ArchivoPDF, P.Precio
                ", conn);

                cmd.Parameters.AddWithValue("@id", idPartitura);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    labelNombreP.Text = reader.IsDBNull(0) ? "Sin título" : reader.GetString(0);
                    labelAutorP.Text = reader.IsDBNull(1) ? "Autor desconocido" : reader.GetString(1);
                    labelEpocaP.Text = reader.IsDBNull(2) ? "N/A" : reader.GetString(2);
                    labelAgrupacionP.Text = reader.IsDBNull(3) ? "N/A" : reader.GetString(3);
                    labelInstrumentosP.Text = reader.IsDBNull(4) ? "N/A" : reader.GetString(4);


                    byte[] pdfBytes = (byte[])reader["ArchivoPDF"];

                    decimal precio = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);
                    precioBase = precio;
                    LicenciaSeleccionada(radio90, EventArgs.Empty);

                    if (precio == 0)
                    {
                        panelLicenciaGratuita.Visible = true;
                        panel2.Visible = true;
                        labelLicenciaGratuita.Visible = true;
                        btnDescargar1.Visible = true;

                        panelComprarLicencia.Visible = false;
                        panel1.Visible = false;

                        panelLicenciaGratuita.Controls.Add(btnFavorito);
                        btnFavorito.BringToFront();
                        btnFavorito.Visible = true;
                    }
                    else
                    {
                        panelLicenciaGratuita.Visible = false;
                        panel2.Visible = false;
                        labelLicenciaGratuita.Visible = false;
                        btnDescargar1.Visible = false;

                        panelComprarLicencia.Visible = true;
                        panel1.Visible = true;

                        panelComprarLicencia.Controls.Add(btnFavorito);
                        btnFavorito.BringToFront();
                        btnFavorito.Visible = true;
                    }


                    bool enFavoritos = false;
                    using (var connFav = new SqlConnection(connStr))
                    {
                        connFav.Open();
                        var cmdFav = new SqlCommand("SELECT COUNT(*) FROM Favoritos WHERE IdUsuario = @u AND IdPartitura = @p", connFav);
                        cmdFav.Parameters.AddWithValue("@u", idUsuario);
                        cmdFav.Parameters.AddWithValue("@p", idPartitura);
                        enFavoritos = (int)cmdFav.ExecuteScalar() > 0;
                    }

                    // Cambiar icono según estado de favorito
                    btnFavorito.Image = enFavoritos
                        ? CargarIcono("heart_filled.png")
                        : CargarIcono("favorite.png");
                    btnFavorito.Tag = enFavoritos;

                    using var stream = new MemoryStream(pdfBytes);
                    using var document = PdfiumViewer.PdfDocument.Load(stream);

                    int totalPages = document.PageCount;
                    labelPaginasP.Text = totalPages.ToString();
                    int paginasAMostrar = Math.Min(paginasMostrar, totalPages);
                    MostrarPaginas(document, paginasAMostrar, tieneLicencia);
                }
            }
        }

        private void MostrarPaginas(PdfiumViewer.PdfDocument document, int paginasAMostrar, bool tieneLicencia)
        {
            flowLayoutPanelPaginas.Controls.Clear();

            for (int i = 0; i < paginasAMostrar; i++)
            {
                Image img = document.Render(i, 800, 1100, true);

                PictureBox pb = new PictureBox
                {
                    Image = img,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 800,
                    Height = 1100,
                    Margin = new Padding(10)
                };

                if (!tieneLicencia && precioBase > 0 && (i >= 1 || document.PageCount == 1))
                {
                    Panel overlay = new Panel
                    {
                        Size = pb.Size,
                        BackColor = Color.FromArgb(220, Color.Black),
                        Location = new Point(0, 0)
                    };

                    Panel franjaCentral = new Panel
                    {
                        Width = pb.Width,
                        Height = 200,
                        BackColor = Color.Black,
                        Location = new Point(0, pb.Height / 2 - 40)
                    };

                    Label aviso = new Label
                    {
                        Text = "🔒 Requiere licencia para seguir viendo",
                        Font = new Font("Segoe UI", 14, FontStyle.Bold),
                        ForeColor = Color.White,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    franjaCentral.Controls.Add(aviso);
                    overlay.Controls.Add(franjaCentral);
                    pb.Controls.Add(overlay);
                }

                flowLayoutPanelPaginas.Controls.Add(pb);
            }
        }

        private (string tipo, DateTime? fechaFin) ObtenerLicenciaActiva(int idUsuario, int idPartitura)
        {
            string tipoEncontrado = null;
            DateTime? fechaFin = null;

            string connStr = DatabaseConnection.ConnectionString;
            using var conn = new SqlConnection(connStr);
            conn.Open();

            string query = @"SELECT TipoLicencia, FechaFin
                             FROM Licencias
                             WHERE IdUsuario = @u AND IdPartitura = @p
                               AND (FechaFin IS NULL OR FechaFin >= GETDATE())";

            var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", idUsuario);
            cmd.Parameters.AddWithValue("@p", idPartitura);

            var reader = cmd.ExecuteReader();
            var licencias = new List<(string tipo, DateTime? fin)>();

            while (reader.Read())
            {
                string tipo = reader.GetString(0);
                DateTime? fin = reader.IsDBNull(1) ? null : reader.GetDateTime(1);
                licencias.Add((tipo, fin));
            }

            if (licencias.Count > 0)
            {
                string[] orden = { "90dias", "180dias", "1año", "permanente" };
                tipoEncontrado = licencias.OrderBy(l => Array.IndexOf(orden, l.tipo.ToLower())).Last().tipo;
                fechaFin = licencias.FirstOrDefault(l => l.tipo == tipoEncontrado).fin;
            }

            return (tipoEncontrado, fechaFin);
        }

        private (DateTime inicio, DateTime? fin) CalcularPeriodoLicencia(string tipoLicencia)
        {
            DateTime inicio = DateTime.Now;
            DateTime? fin = tipoLicencia.ToLower() switch
            {
                "90dias" => inicio.AddDays(90),
                "180dias" => inicio.AddDays(180),
                "1año" or "1ano" => inicio.AddYears(1),
                _ => null
            };

            return (inicio, fin);
        }

        private string GetTipoLicenciaSeleccionado()
        {
            if (radio90.Checked) return "90dias";
            if (radio180.Checked) return "180dias";
            if (radio365.Checked) return "1año";
            if (radioPermanente.Checked) return "permanente";
            return null;
        }

        private void RegistrarCompraEnPartiturasUsuario(int usuarioId, int partituraId)
        {
            string connStr = DatabaseConnection.ConnectionString;
            using var conn = new SqlConnection(connStr);
            conn.Open();

            var checkCmd = new SqlCommand("SELECT COUNT(*) FROM PartiturasUsuario WHERE UsuarioId = @u AND PartituraId = @p", conn);
            checkCmd.Parameters.AddWithValue("@u", usuarioId);
            checkCmd.Parameters.AddWithValue("@p", partituraId);

            int existe = (int)checkCmd.ExecuteScalar();
            if (existe == 0)
            {
                var insertCmd = new SqlCommand(
                    "INSERT INTO PartiturasUsuario (UsuarioId, PartituraId, Tipo, Fecha) VALUES (@u, @p, 'Comprada', GETDATE())", conn);
                insertCmd.Parameters.AddWithValue("@u", usuarioId);
                insertCmd.Parameters.AddWithValue("@p", partituraId);
                insertCmd.ExecuteNonQuery();
            }
        }


        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session.NombreUsuario))
            {
                MessageBox.Show("Debes iniciar sesión para comprar la partitura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string tipoSeleccionado = GetTipoLicenciaSeleccionado();
            var licencia = ObtenerLicenciaActiva(idUsuario, idPartitura);

            if (licencia.tipo == tipoSeleccionado)
            {
                MessageBox.Show("Ya has comprado esta licencia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var (inicio, fin) = CalcularPeriodoLicencia(tipoSeleccionado);

            int idPedido = GuardarPedidoEnBD(idUsuario);

            GuardarLicenciaEnBD(idUsuario, idPartitura, tipoSeleccionado, inicio, fin, idPedido);
            RegistrarCompraEnPartiturasUsuario(idUsuario, idPartitura);

            MessageBox.Show("¡Licencia registrada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDetallePartitura();
        }


        private decimal precioBase = 0;
        private decimal CalcularPrecioPorTipo(string tipoLicencia)
        {
            return tipoLicencia switch
            {
                "90dias" => precioBase,
                "180dias" => precioBase * 1.25m,
                "1año" or "1ano" => precioBase * 1.5m,
                "permanente" => precioBase * 1.75m,
                _ => 0
            };
        }

        private int GuardarPedidoEnBD(int usuarioId)
        {
            string connStr = DatabaseConnection.ConnectionString;
            using var conn = new SqlConnection(connStr);
            conn.Open();

            var cmd = new SqlCommand("INSERT INTO Pedidos (IdUsuario, Fecha) OUTPUT INSERTED.Id VALUES (@u, GETDATE())", conn);
            cmd.Parameters.AddWithValue("@u", usuarioId);
            return (int)cmd.ExecuteScalar();
        }

        private void GuardarLicenciaEnBD(int usuarioId, int partituraId, string tipo, DateTime inicio, DateTime? fin, int idPedido)
        {
            decimal precio = CalcularPrecioPorTipo(tipo);
            string connStr = DatabaseConnection.ConnectionString;
            using var conn = new SqlConnection(connStr);
            conn.Open();

            // 1. Insertar licencia y obtener ID generado
            string queryLicencia = @"
        INSERT INTO Licencias 
        (IdUsuario, IdPartitura, TipoLicencia, FechaInicio, FechaFin, Precio, PrecioTotal, IdPedido)
        OUTPUT INSERTED.Id
        VALUES (@u, @p, @t, @fi, @ff, @pr, @pr, @pedidoId)";

            var cmdLicencia = new SqlCommand(queryLicencia, conn);
            cmdLicencia.Parameters.AddWithValue("@u", usuarioId);
            cmdLicencia.Parameters.AddWithValue("@p", partituraId);
            cmdLicencia.Parameters.AddWithValue("@t", tipo);
            cmdLicencia.Parameters.AddWithValue("@fi", inicio);
            cmdLicencia.Parameters.AddWithValue("@ff", (object?)fin ?? DBNull.Value);
            cmdLicencia.Parameters.AddWithValue("@pr", precio);
            cmdLicencia.Parameters.AddWithValue("@pedidoId", idPedido);

            int idLicencia = (int)cmdLicencia.ExecuteScalar();

            // 2. Obtener el vendedor de la partitura
            var cmdVendedor = new SqlCommand("SELECT IdUsuario FROM Partituras WHERE Id = @id", conn);
            cmdVendedor.Parameters.AddWithValue("@id", partituraId);
            int idVendedor = (int)cmdVendedor.ExecuteScalar();

            // 3. Insertar venta
            var cmdVenta = new SqlCommand(@"
        INSERT INTO Ventas 
        (IdPedido, IdLicencia, IdVendedor, IdComprador, IdPartitura, Importe)
        VALUES (@pedido, @licencia, @vendedor, @comprador, @partitura, @importe)", conn);

            cmdVenta.Parameters.AddWithValue("@pedido", idPedido);
            cmdVenta.Parameters.AddWithValue("@licencia", idLicencia);
            cmdVenta.Parameters.AddWithValue("@vendedor", idVendedor);
            cmdVenta.Parameters.AddWithValue("@comprador", usuarioId);
            cmdVenta.Parameters.AddWithValue("@partitura", partituraId);
            cmdVenta.Parameters.AddWithValue("@importe", precio);

            cmdVenta.ExecuteNonQuery();
        }


        private int ObtenerPrioridadLicencia(string tipo)
        {
            return tipo switch
            {
                "90dias" => 1,
                "180dias" => 2,
                "1año" => 3,
                "permanente" => 4,
                _ => 0
            };
        }


        private void btnDescargar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session.NombreUsuario))
            {
                MessageBox.Show("Debes iniciar sesión para descargar la partitura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {
            string tipoLicenciaNueva = GetTipoLicenciaSeleccionado();

            using var conn = new SqlConnection(DatabaseConnection.ConnectionString);
            conn.Open();

            var checkCmd = new SqlCommand(@"
                SELECT Id, TipoLicencia 
                FROM Carrito 
                WHERE IdUsuario = @u AND IdPartitura = @p", conn);

            checkCmd.Parameters.AddWithValue("@u", Session.UsuarioId);
            checkCmd.Parameters.AddWithValue("@p", idPartitura);

            using var reader = checkCmd.ExecuteReader();
            if (reader.Read())
            {
                int idExistente = reader.GetInt32(0);
                string tipoExistente = reader.GetString(1);

                int prioridadExistente = ObtenerPrioridadLicencia(tipoExistente);
                int prioridadNueva = ObtenerPrioridadLicencia(tipoLicenciaNueva);

                if (prioridadNueva < prioridadExistente)
                {
                    MessageBox.Show("Ya tienes una licencia superior para esta partitura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (prioridadNueva > prioridadExistente)
                {
                    reader.Close();

                    var updateCmd = new SqlCommand("UPDATE Carrito SET TipoLicencia = @nueva WHERE Id = @id", conn);
                    updateCmd.Parameters.AddWithValue("@nueva", tipoLicenciaNueva);
                    updateCmd.Parameters.AddWithValue("@id", idExistente);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Se ha actualizado la licencia por una de mayor duración.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("Ya tienes una licencia superior para esta partitura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            reader.Close();
            var insertCmd = new SqlCommand("INSERT INTO Carrito (IdUsuario, IdPartitura, TipoLicencia) VALUES (@u, @p, @t)", conn);
            insertCmd.Parameters.AddWithValue("@u", Session.UsuarioId);
            insertCmd.Parameters.AddWithValue("@p", idPartitura);
            insertCmd.Parameters.AddWithValue("@t", tipoLicenciaNueva);
            insertCmd.ExecuteNonQuery();

            MessageBox.Show("¡Partitura añadida al carrito!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private Image CargarIcono(string nombreArchivo)
        {
            string ruta = Path.Combine(Application.StartupPath, "Iconos", nombreArchivo);
            return Image.FromFile(ruta);
        }

        private void btnFavorito_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session.NombreUsuario))
            {
                MessageBox.Show("Debes iniciar sesión para guardar la partitura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool yaFavorito = (bool)(btnFavorito.Tag ?? false);

            if (yaFavorito)
            {
                EliminarFavorito(idUsuario, idPartitura);
                btnFavorito.Image = CargarIcono("favorite.png");
                btnFavorito.Tag = false;
                MessageBox.Show("Partitura eliminada de favoritos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (precioBase > 0)
                {
                    var licencia = ObtenerLicenciaActiva(idUsuario, idPartitura);
                    if (string.IsNullOrEmpty(licencia.tipo))
                    {
                        MessageBox.Show("Debes comprar esta partitura para guardarla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                GuardarFavorito(idUsuario, idPartitura);
                btnFavorito.Image = CargarIcono("heart_filled.png");
                btnFavorito.Tag = true;
                MessageBox.Show("¡Partitura añadida a favoritos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GuardarFavorito(int usuarioId, int partituraId)
        {
            string connStr = DatabaseConnection.ConnectionString;
            using var conn = new SqlConnection(connStr);
            conn.Open();

            var checkFavCmd = new SqlCommand("SELECT COUNT(*) FROM Favoritos WHERE IdUsuario = @u AND IdPartitura = @p", conn);
            checkFavCmd.Parameters.AddWithValue("@u", usuarioId);
            checkFavCmd.Parameters.AddWithValue("@p", partituraId);

            int yaEsFavorita = (int)checkFavCmd.ExecuteScalar();
            if (yaEsFavorita == 0)
            {
                var insertFavCmd = new SqlCommand("INSERT INTO Favoritos (IdUsuario, IdPartitura) VALUES (@u, @p)", conn);
                insertFavCmd.Parameters.AddWithValue("@u", usuarioId);
                insertFavCmd.Parameters.AddWithValue("@p", partituraId);
                insertFavCmd.ExecuteNonQuery();
            }

            var checkUsuarioCmd = new SqlCommand("SELECT COUNT(*) FROM PartiturasUsuario WHERE UsuarioId = @u AND PartituraId = @p", conn);
            checkUsuarioCmd.Parameters.AddWithValue("@u", usuarioId);
            checkUsuarioCmd.Parameters.AddWithValue("@p", partituraId);

            int yaTieneEntrada = (int)checkUsuarioCmd.ExecuteScalar();
            if (yaTieneEntrada == 0)
            {
                string tipo = precioBase == 0 ? "Gratuita" : "Comprada";
                var insertUsuarioCmd = new SqlCommand("INSERT INTO PartiturasUsuario (UsuarioId, PartituraId, Tipo) VALUES (@u, @p, @t)", conn);
                insertUsuarioCmd.Parameters.AddWithValue("@u", usuarioId);
                insertUsuarioCmd.Parameters.AddWithValue("@p", partituraId);
                insertUsuarioCmd.Parameters.AddWithValue("@t", tipo);
                insertUsuarioCmd.ExecuteNonQuery();

                if (precioBase == 0)
                {
                    var insertLicenciaCmd = new SqlCommand(@"
                INSERT INTO Licencias 
                (IdUsuario, IdPartitura, TipoLicencia, FechaInicio, FechaFin, Precio, PrecioTotal) 
                VALUES (@u, @p, 'permanente', @inicio, NULL, 0, 0)", conn);

                    insertLicenciaCmd.Parameters.AddWithValue("@u", usuarioId);
                    insertLicenciaCmd.Parameters.AddWithValue("@p", partituraId);
                    insertLicenciaCmd.Parameters.AddWithValue("@inicio", DateTime.Now);
                    insertLicenciaCmd.ExecuteNonQuery();
                }
            }

        }


        private void EliminarFavorito(int usuarioId, int partituraId)
        {
            string connStr = DatabaseConnection.ConnectionString;
            using var conn = new SqlConnection(connStr);
            conn.Open();

            // 1. Eliminar de Favoritos
            var cmd = new SqlCommand("DELETE FROM Favoritos WHERE IdUsuario = @u AND IdPartitura = @p", conn);
            cmd.Parameters.AddWithValue("@u", usuarioId);
            cmd.Parameters.AddWithValue("@p", partituraId);
            cmd.ExecuteNonQuery();

            // 2. Eliminar licencia si era gratuita
            var deleteLicenciaCmd = new SqlCommand(@"
        DELETE FROM Licencias
        WHERE IdUsuario = @u AND IdPartitura = @p AND Precio = 0 AND TipoLicencia = 'permanente'", conn);
            deleteLicenciaCmd.Parameters.AddWithValue("@u", usuarioId);
            deleteLicenciaCmd.Parameters.AddWithValue("@p", partituraId);
            deleteLicenciaCmd.ExecuteNonQuery();

            // 3. Comprobar si sigue teniendo relación con la partitura
            var checkLicenciaCmd = new SqlCommand(@"
        SELECT COUNT(*) 
        FROM Licencias 
        WHERE IdUsuario = @u AND IdPartitura = @p", conn);
            checkLicenciaCmd.Parameters.AddWithValue("@u", usuarioId);
            checkLicenciaCmd.Parameters.AddWithValue("@p", partituraId);
            int tieneLicencia = (int)checkLicenciaCmd.ExecuteScalar();

            var checkPropiaCmd = new SqlCommand(@"
        SELECT COUNT(*) 
        FROM PartiturasUsuario 
        WHERE UsuarioId = @u AND PartituraId = @p AND Tipo = 'Propia'", conn);
            checkPropiaCmd.Parameters.AddWithValue("@u", usuarioId);
            checkPropiaCmd.Parameters.AddWithValue("@p", partituraId);
            int esPropia = (int)checkPropiaCmd.ExecuteScalar();

            if (tieneLicencia == 0 && esPropia == 0)
            {
                var deletePUCmd = new SqlCommand("DELETE FROM PartiturasUsuario WHERE UsuarioId = @u AND PartituraId = @p", conn);
                deletePUCmd.Parameters.AddWithValue("@u", usuarioId);
                deletePUCmd.Parameters.AddWithValue("@p", partituraId);
                deletePUCmd.ExecuteNonQuery();
            }
        }


    }

}
