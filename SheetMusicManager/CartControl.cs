using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SheetMusicManager
{
    public partial class CartControl : UserControl
    {
        public CartControl()
        {
            InitializeComponent();
            CargarCarritoBD();
        }

        private void CargarCarritoBD()
        {
            // Limpiar solo los ítems (excepto panelTotal)
            var panelesAEliminar = flowLayoutPanelVentas.Controls
                .OfType<Panel>()
                .Where(p => p != panelTotal)
                .ToList();

            foreach (var panel in panelesAEliminar)
                flowLayoutPanelVentas.Controls.Remove(panel);

            decimal total = 0;
            int cantidad = 0;

            string connStr = DatabaseConnection.ConnectionString;
            using var conn = new SqlConnection(connStr);
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT 
                    c.Id, 
                    p.Nombre, 
                    p.Compositor,
                    STRING_AGG(i.Nombre, ', ') AS Instrumentos,
                    c.TipoLicencia, 
                    p.Precio
                FROM Carrito c
                JOIN Partituras p ON c.IdPartitura = p.Id
                LEFT JOIN InstrumentosPorPartitura ipp ON p.Id = ipp.IdPartitura
                LEFT JOIN Instrumentos i ON i.Id = ipp.IdInstrumento
                WHERE c.IdUsuario = @id
                GROUP BY c.Id, p.Nombre, p.Compositor, c.TipoLicencia, p.Precio", conn);


            cmd.Parameters.AddWithValue("@id", Session.UsuarioId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cantidad++;

                Panel item = ClonarPanel(panelPartituras);
                item.Visible = true;

                string tipoLicencia = reader["TipoLicencia"].ToString();
                decimal precio = CalcularPrecioPorTipoLicencia(reader.GetDecimal(5), tipoLicencia);
                total += precio;

                SetLabelText(item, "labelNombreP", reader["Nombre"].ToString());
                SetLabelText(item, "labelCompositorP", reader["Compositor"].ToString());
                SetLabelText(item, "labelInstrumentosP", reader["Instrumentos"].ToString());
                SetLabelText(item, "labelTiempoP", $"Tiempo de uso: {FormatearLicencia(tipoLicencia)}");
                SetLabelText(item, "labelPrecioP", $"{precio:0.00}€");

                var btnEliminar = item.Controls.Find("btnEliminar", true).FirstOrDefault() as PictureBox;
                if (btnEliminar != null)
                {
                    int idCarrito = reader.GetInt32(0);
                    btnEliminar.Cursor = Cursors.Hand;
                    btnEliminar.Click += (s, e) =>
                    {
                        DialogResult confirm = MessageBox.Show("¿Deseas eliminar esta partitura del carrito?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirm == DialogResult.Yes)
                        {
                            EliminarDeCarrito(idCarrito);
                            CargarCarritoBD();
                        }
                    };
                }


                flowLayoutPanelVentas.Controls.Add(item);
            }

            // Mostrar totales
            labelNumeroP.Text = cantidad.ToString();
            labelPrecioTotalP.Text = $"{total:0.00}€";

            // Panel total al final
            if (!flowLayoutPanelVentas.Controls.Contains(panelTotal))
                flowLayoutPanelVentas.Controls.Add(panelTotal);
            else
                flowLayoutPanelVentas.Controls.SetChildIndex(panelTotal, flowLayoutPanelVentas.Controls.Count - 1);
        }


        private void EliminarDeCarrito(int id)
        {
            string connStr = DatabaseConnection.ConnectionString;
            using var conn = new SqlConnection(connStr);
            conn.Open();

            var cmd = new SqlCommand("DELETE FROM Carrito WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private Panel ClonarPanel(Panel original)
        {
            Panel clone = new Panel
            {
                Size = original.Size,
                BackColor = original.BackColor,
                BorderStyle = original.BorderStyle,
                Margin = new Padding(20, 10, 20, 10),
                Padding = original.Padding,
                Name = original.Name
            };

            clone.Paint += DibujarBordePanel;

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

                if (ctrl is PictureBox pbOrig && newCtrl is PictureBox pbNew)
                {
                    pbNew.Image = pbOrig.Image;
                    pbNew.SizeMode = pbOrig.SizeMode;
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
                "1año" => "1 año",
                "permanente" => "Permanente",
                _ => tipo
            };
        }

        private (DateTime inicio, DateTime? fin) CalcularPeriodoLicencia(string tipo)
        {
            DateTime inicio = DateTime.Now;
            return tipo switch
            {
                "90dias" => (inicio, inicio.AddDays(90)),
                "180dias" => (inicio, inicio.AddDays(180)),
                "1año" or "1ano" => (inicio, inicio.AddYears(1)),
                "permanente" => (inicio, null),
                _ => (inicio, null)
            };
        }

        private decimal GetPrecioBase(int partituraId, SqlConnection conn)
        {
            var cmd = new SqlCommand("SELECT Precio FROM Partituras WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", partituraId);
            return (decimal?)cmd.ExecuteScalar() ?? 0m;
        }

        private decimal CalcularPrecioPorTipoLicencia(decimal basePrecio, string tipo)
        {
            return tipo switch
            {
                "90dias" => basePrecio,
                "180dias" => basePrecio * 1.25m,
                "1año" or "1ano" => basePrecio * 1.5m,
                "permanente" => basePrecio * 1.75m,
                _ => basePrecio
            };
        }


        private void DibujarBordePanel(object sender, PaintEventArgs e)
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
        private void btnVaciar_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanelVentas.Controls
                .OfType<Panel>()
                .Any(p => p != panelTotal))
            {
                DialogResult confirm = MessageBox.Show("¿Estás seguro de que quieres vaciar el carrito completo?", "Vaciar carrito", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    string connStr = DatabaseConnection.ConnectionString;
                    using var conn = new SqlConnection(connStr);
                    conn.Open();

                    var cmd = new SqlCommand("DELETE FROM Carrito WHERE IdUsuario = @id", conn);
                    cmd.Parameters.AddWithValue("@id", Session.UsuarioId);
                    cmd.ExecuteNonQuery();

                    CargarCarritoBD();
                }
            }
            else
            {
                MessageBox.Show("El carrito ya está vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int ObtenerIdVendedor(int partituraId, SqlConnection conn)
        {
            var cmd = new SqlCommand("SELECT IdUsuario FROM Partituras WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", partituraId);
            return (int)cmd.ExecuteScalar();
        }


        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanelVentas.Controls.OfType<Panel>().Count(p => p != panelTotal) == 0)
            {
                MessageBox.Show("No hay partituras en el carrito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("¿Deseas completar la compra de las partituras?", "Confirmar compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            string connStr = DatabaseConnection.ConnectionString;
            using var conn = new SqlConnection(connStr);
            conn.Open();

            // Crear nuevo pedido
            var insertPedidoCmd = new SqlCommand("INSERT INTO Pedidos (IdUsuario, Fecha) OUTPUT INSERTED.Id VALUES (@id, GETDATE())", conn);
            insertPedidoCmd.Parameters.AddWithValue("@id", Session.UsuarioId);
            int idPedido = (int)insertPedidoCmd.ExecuteScalar();

            // Obtener partituras del carrito
            var selectCmd = new SqlCommand(@"
        SELECT IdPartitura, TipoLicencia
        FROM Carrito
        WHERE IdUsuario = @id", conn);
            selectCmd.Parameters.AddWithValue("@id", Session.UsuarioId);

            var carrito = new List<(int IdPartitura, string TipoLicencia)>();
            using (var reader = selectCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    carrito.Add((reader.GetInt32(0), reader.GetString(1)));
                }
            }

            // Insertar licencias con ID del pedido
            foreach (var item in carrito)
            {
                var (inicio, fin) = CalcularPeriodoLicencia(item.TipoLicencia);
                decimal precio = CalcularPrecioPorTipoLicencia(GetPrecioBase(item.IdPartitura, conn), item.TipoLicencia);

                // Insertar licencia
                var insertLicenciaCmd = new SqlCommand(@"
                    INSERT INTO Licencias 
                    (IdUsuario, IdPartitura, TipoLicencia, FechaInicio, FechaFin, Precio, PrecioTotal, IdPedido)
                    OUTPUT INSERTED.Id
                    VALUES 
                    (@usuario, @partitura, @tipo, @inicio, @fin, @precio, @precioTotal, @pedido)", conn);


                insertLicenciaCmd.Parameters.AddWithValue("@usuario", Session.UsuarioId);
                insertLicenciaCmd.Parameters.AddWithValue("@partitura", item.IdPartitura);
                insertLicenciaCmd.Parameters.AddWithValue("@tipo", item.TipoLicencia);
                insertLicenciaCmd.Parameters.AddWithValue("@inicio", inicio);
                insertLicenciaCmd.Parameters.AddWithValue("@fin", (object?)fin ?? DBNull.Value);
                insertLicenciaCmd.Parameters.AddWithValue("@precio", precio);
                insertLicenciaCmd.Parameters.AddWithValue("@precioTotal", precio);
                insertLicenciaCmd.Parameters.AddWithValue("@pedido", idPedido);

                int idLicencia = (int)insertLicenciaCmd.ExecuteScalar();

                // Obtener vendedor
                int idVendedor = ObtenerIdVendedor(item.IdPartitura, conn);

                // Insertar venta
                var insertVentaCmd = new SqlCommand(@"
            INSERT INTO Ventas (IdPedido, IdVendedor, IdComprador, IdPartitura, IdLicencia, Fecha, Importe)
            VALUES (@pedido, @vendedor, @comprador, @partitura, @licencia, GETDATE(), @importe)", conn);

                insertVentaCmd.Parameters.AddWithValue("@pedido", idPedido);
                insertVentaCmd.Parameters.AddWithValue("@vendedor", idVendedor);
                insertVentaCmd.Parameters.AddWithValue("@comprador", Session.UsuarioId);
                insertVentaCmd.Parameters.AddWithValue("@partitura", item.IdPartitura);
                insertVentaCmd.Parameters.AddWithValue("@licencia", idLicencia);
                insertVentaCmd.Parameters.AddWithValue("@importe", precio);


                insertVentaCmd.ExecuteNonQuery();
            }

            // Vaciar carrito
            var deleteCmd = new SqlCommand("DELETE FROM Carrito WHERE IdUsuario = @id", conn);
            deleteCmd.Parameters.AddWithValue("@id", Session.UsuarioId);
            deleteCmd.ExecuteNonQuery();

            MessageBox.Show("¡Compra completada correctamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarCarritoBD();
        }
    }
}
