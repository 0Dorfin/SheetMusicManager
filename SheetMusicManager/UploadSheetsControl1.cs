using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Data.SqlClient;
using PresentationControls;

namespace SheetMusicManager
{
    public partial class UploadSheetsControl1 : UserControl
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private string selectedFilePath;
        private bool enModoEdicion = false;
        private bool hayCambios = false;
        private int partituraEditandoId = -1;

        public UploadSheetsControl1()
        {
            InitializeComponent();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Archivos de imagen o PDF|*.pdf;*.png;*.jpg;*.jpeg";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFile.FileName;
                lblArchivo.Text = "Archivo: " + Path.GetFileName(selectedFilePath);

                if (Path.GetExtension(selectedFilePath).ToLower().EndsWith(".pdf"))
                {
                    try
                    {
                        using var stream = new MemoryStream(File.ReadAllBytes(selectedFilePath));
                        using var document = PdfiumViewer.PdfDocument.Load(stream);

                        Image previewImage = document.Render(0, previewBox.Width, previewBox.Height, true);
                        previewBox.Image = previewImage;
                        previewBox.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al mostrar el PDF: " + ex.Message);
                        previewBox.Visible = false;
                    }
                }

                else
                {
                    try
                    {
                        previewBox.Image = Image.FromFile(selectedFilePath);
                        previewBox.Visible = true;
                    }
                    catch
                    {
                        MessageBox.Show("Error al cargar la imagen.");
                    }
                }

                Modificado();
            }
        }

        private void btnProcesarPartitura_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Primero selecciona una partitura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string audiverisDir = @"C:\Users\diego\source\repos\SheetMusicApp\SheetMusicManager\audiveris";
            string argumentos = $"run -PjvmLineArgs=--enable-preview -PcmdLineArgs=\"{selectedFilePath}\"";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c cd /d \"{audiverisDir}\" && .\\gradlew.bat {argumentos}",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = false,
                RedirectStandardError = false,
                WindowStyle = ProcessWindowStyle.Minimized
            };

            try
            {
                var proc = Process.Start(psi);

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 2000;
                timer.Tick += (s, ev) =>
                {
                    foreach (Process p in Process.GetProcessesByName("java"))
                    {
                        if (!string.IsNullOrEmpty(p.MainWindowTitle))
                        {
                            timer.Stop();

                            SetParent(p.MainWindowHandle, panelAudiveris.Handle);
                            MoveWindow(p.MainWindowHandle, 0, 0, panelAudiveris.Width, panelAudiveris.Height, true);
                            break;
                        }
                    }
                };
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar Audiveris: " + ex.Message);
            }
        }

        private void GuardarPartituraSinConfirmacion(string pdfPath)
        {
            try
            {
                string nombreArchivo = Path.GetFileName(pdfPath);
                byte[] contenidoPDF = File.ReadAllBytes(pdfPath);

                string nombre = textBoxNombre.Text.Trim();
                string compositor = textBoxCompositor.Text.Trim();
                string epoca = comboBoxEpoca.SelectedItem?.ToString() ?? "";
                string agrupacion = comboBoxAgrupacion.SelectedItem?.ToString() ?? "";
                string instrumentosSeleccionados = ObtenerInstrumentosSeleccionados();
                decimal precioBase = 0;

                if (checkBoxPago.Checked)
                {
                    if (!decimal.TryParse(textBoxPrecioBase.Text.Trim(), out precioBase))
                    {
                        MessageBox.Show("Introduce un precio válido.");
                        return;
                    }

                    if (agrupacion.Equals("Solo", StringComparison.OrdinalIgnoreCase) && precioBase > 10)
                    {
                        MessageBox.Show("El precio base no puede superar los 10€ para partituras de tipo 'Solo'.");
                        return;
                    }
                }


                string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    var cmd = new SqlCommand(@"
                        INSERT INTO Partituras 
                            (NombreArchivo, ArchivoPDF, FechaSubida, Nombre, Compositor, Epoca, Instrumentos, Agrupacion, Precio)
                            VALUES 
                            (@nombreArchivo, @pdf, @fecha, @nombre, @compositor, @epoca, @instrumentos, @agrupacion, @precio)", conn);


                    cmd.Parameters.AddWithValue("@nombreArchivo", nombreArchivo);
                    cmd.Parameters.AddWithValue("@pdf", contenidoPDF);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@compositor", compositor);
                    cmd.Parameters.AddWithValue("@epoca", epoca);
                    cmd.Parameters.AddWithValue("@instrumentos", instrumentosSeleccionados);
                    cmd.Parameters.AddWithValue("@agrupacion", agrupacion);
                    cmd.Parameters.AddWithValue("@precio", precioBase);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("✅ Partitura guardada correctamente.");
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al guardar: " + ex.Message);
            }
        }


        private string ObtenerInstrumentosSeleccionados()
        {
            if (comboBoxInstrumentos == null) return "";

            var seleccionados = new List<string>();

            foreach (CheckBoxComboBoxItem item in comboBoxInstrumentos.CheckBoxItems)
            {
                if (item.Checked)
                    seleccionados.Add(item.Text);
            }

            return string.Join(", ", seleccionados);
        }
        public void LimpiarFormulario()
        {
            textBoxNombre.Text = "";
            textBoxCompositor.Text = "";
            comboBoxEpoca.SelectedIndex = -1;
            comboBoxAgrupacion.SelectedIndex = -1;
            foreach (CheckBoxComboBoxItem item in comboBoxInstrumentos.CheckBoxItems)
                item.Checked = false;

            checkBoxGratuita.Checked = false;
            checkBoxPago.Checked = false;
            textBoxPrecioBase.Text = "";

            lblSubirPartitura.Text = "Subir partitura";
            lblArchivo.Text = "Ningún archivo seleccionado";
            selectedFilePath = null;
            previewBox.Image = null;
            btnCancelar.Visible = false;

            enModoEdicion = false;
            hayCambios = false;
            lblLimpiar.Visible = false;
            partituraEditandoId = 0;
        }


        private DialogResult MostrarVistaPreviaPDF(string pdfPath)
        {
            DialogResult result = MessageBox.Show(
                "¿Quieres abrir la partitura para revisarla antes de guardarla?",
                "Vista previa de la partitura",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir el archivo PDF: " + ex.Message);
                }
            }

            return result == DialogResult.Yes ? DialogResult.OK : DialogResult.Cancel;
        }

        private void btnGuardarPartitura_Click(object sender, EventArgs e)
        {
            if (!enModoEdicion && string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Primero selecciona una partitura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                string.IsNullOrWhiteSpace(textBoxCompositor.Text) ||
                comboBoxEpoca.SelectedIndex == -1 ||
                comboBoxAgrupacion.SelectedIndex == -1 ||
                ObtenerInstrumentosSeleccionados() == "" ||
                (!checkBoxGratuita.Checked && !checkBoxPago.Checked))
            {
                MessageBox.Show("Completa todos los campos antes de guardar la partitura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string pdfFinalPath = selectedFilePath;
            if (!enModoEdicion)
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(selectedFilePath);
                string carpetaDescargas = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
                string pdfPath = Path.Combine(carpetaDescargas, fileNameWithoutExt + "-print.pdf");

                if (File.Exists(pdfPath))
                {
                    pdfFinalPath = pdfPath;
                }
                else
                {
                    MessageBox.Show("No se encontró el PDF exportado desde Audiveris. Se usará el archivo original seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            decimal precio = 0;
            if (checkBoxPago.Checked)
            {
                if (!decimal.TryParse(textBoxPrecioBase.Text.Trim(), out precio))
                {
                    MessageBox.Show("Introduce un precio válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (comboBoxAgrupacion.SelectedItem?.ToString().Equals("Solo", StringComparison.OrdinalIgnoreCase) == true && precio > 10)
                {
                    MessageBox.Show("El precio base no puede superar los 10€ para partituras de tipo 'Solo'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            string nombre = textBoxNombre.Text.Trim();
            string compositor = textBoxCompositor.Text.Trim();
            string epoca = comboBoxEpoca.SelectedItem.ToString();
            string agrupacion = comboBoxAgrupacion.SelectedItem.ToString();
            string instrumentos = ObtenerInstrumentosSeleccionados().TrimStart(',', ' ');

            byte[] pdfBytes = null;
            if (!string.IsNullOrEmpty(pdfFinalPath))
            {
                try
                {
                    pdfBytes = File.ReadAllBytes(pdfFinalPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo leer el archivo PDF: " + ex.Message);
                    return;
                }
            }

            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                if (enModoEdicion)
                {
                    string query = @"
                        UPDATE Partituras SET 
                            Nombre = @nombre,
                            Compositor = @compositor,
                            Epoca = @epoca,
                            Agrupacion = @agrupacion,
                            Precio = @precio";

                    if (pdfBytes != null)
                        query += ", ArchivoPDF = @pdf";

                    query += " WHERE Id = @id";

                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", partituraEditandoId);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@compositor", compositor);
                    cmd.Parameters.AddWithValue("@epoca", epoca);
                    cmd.Parameters.AddWithValue("@agrupacion", agrupacion);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    if (pdfBytes != null)
                        cmd.Parameters.AddWithValue("@pdf", pdfBytes);
                    cmd.ExecuteNonQuery();

                    // Eliminar instrumentos anteriores
                    var deleteCmd = new SqlCommand("DELETE FROM InstrumentosPorPartitura WHERE IdPartitura = @id", conn);
                    deleteCmd.Parameters.AddWithValue("@id", partituraEditandoId);
                    deleteCmd.ExecuteNonQuery();

                    // Insertar nuevos instrumentos
                    foreach (string instrumento in instrumentos.Split(',').Select(i => i.Trim()))
                    {
                        var cmdInstrumento = new SqlCommand(@"
                    INSERT INTO InstrumentosPorPartitura (IdPartitura, IdInstrumento)
                    VALUES (@partituraId, (SELECT Id FROM Instrumentos WHERE Nombre = @nombreInstrumento))", conn);
                        cmdInstrumento.Parameters.AddWithValue("@partituraId", partituraEditandoId);
                        cmdInstrumento.Parameters.AddWithValue("@nombreInstrumento", instrumento);
                        cmdInstrumento.ExecuteNonQuery();
                    }

                    MessageBox.Show("Partitura actualizada correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Inserción de nueva partitura
                    int idPartitura = 0;

                    string insertQuery = @"
                        INSERT INTO Partituras
                        (NombreArchivo, ArchivoPDF, FechaSubida, Nombre, Compositor, Epoca, Agrupacion, Precio, IdUsuario)
                        OUTPUT INSERTED.Id
                        VALUES
                        (@nombreArchivo, @pdf, @fecha, @nombre, @compositor, @epoca, @agrupacion, @precio, @idUsuario)";

                    string nombreArchivo = Path.GetFileName(pdfFinalPath);

                    using (var insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@nombreArchivo", nombreArchivo);
                        insertCmd.Parameters.AddWithValue("@pdf", pdfBytes);
                        insertCmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                        insertCmd.Parameters.AddWithValue("@nombre", nombre);
                        insertCmd.Parameters.AddWithValue("@compositor", compositor);
                        insertCmd.Parameters.AddWithValue("@epoca", epoca);
                        insertCmd.Parameters.AddWithValue("@agrupacion", agrupacion);
                        insertCmd.Parameters.AddWithValue("@precio", precio);
                        insertCmd.Parameters.AddWithValue("@idUsuario", Session.UsuarioId);

                        object result = insertCmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            idPartitura = Convert.ToInt32(result);
                        else
                        {
                            MessageBox.Show("❌ Error: No se pudo obtener el ID de la partitura insertada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insertar instrumentos
                    foreach (string instrumento in instrumentos.Split(',').Select(i => i.Trim()))
                    {
                        var cmdInstrumento = new SqlCommand(@"
                    INSERT INTO InstrumentosPorPartitura (IdPartitura, IdInstrumento)
                    VALUES (@partituraId, (SELECT Id FROM Instrumentos WHERE Nombre = @nombreInstrumento))", conn);
                        cmdInstrumento.Parameters.AddWithValue("@partituraId", idPartitura);
                        cmdInstrumento.Parameters.AddWithValue("@nombreInstrumento", instrumento);
                        cmdInstrumento.ExecuteNonQuery();
                    }

                    // Insertar relación usuario-partitura
                    using (var cmdUsuario = new SqlCommand(
                        "INSERT INTO PartiturasUsuario (UsuarioId, PartituraId, Tipo) VALUES (@usuarioId, @partituraId, 'Propia')", conn))
                    {
                        cmdUsuario.Parameters.AddWithValue("@usuarioId", Session.UsuarioId);
                        cmdUsuario.Parameters.AddWithValue("@partituraId", idPartitura);
                        cmdUsuario.ExecuteNonQuery();
                    }

                    MessageBox.Show("Partitura guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            LimpiarFormulario();
        }


        public void CargarPartituraParaEditar(Partitura partitura)
        {
            textBoxNombre.Text = partitura.Nombre;
            textBoxCompositor.Text = partitura.Compositor;
            comboBoxEpoca.SelectedItem = partitura.Epoca;
            comboBoxAgrupacion.SelectedItem = partitura.Agrupacion;

            // 1. Limpiar selección actual
            foreach (CheckBoxComboBoxItem item in comboBoxInstrumentos.CheckBoxItems)
                item.Checked = false;

            // 2. Obtener instrumentos desde la tabla intermedia
            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                var cmd = new SqlCommand(@"
            SELECT i.Nombre 
            FROM InstrumentosPorPartitura ipp
            JOIN Instrumentos i ON i.Id = ipp.IdInstrumento
            WHERE ipp.IdPartitura = @id", conn);
                cmd.Parameters.AddWithValue("@id", partitura.Id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string instrumento = reader.GetString(0);
                        foreach (CheckBoxComboBoxItem item in comboBoxInstrumentos.CheckBoxItems)
                        {
                            if (item.Text.Equals(instrumento, StringComparison.OrdinalIgnoreCase))
                            {
                                item.Checked = true;
                                break;
                            }
                        }
                    }
                }
            }

            enModoEdicion = true;
            partituraEditandoId = partitura.Id;

            selectedFilePath = null;
            lblSubirPartitura.Text = "Editar partitura";
            lblArchivo.Text = "Editando partitura existente";
            previewBox.Image = null;
            previewBox.Visible = false;
            btnCancelar.Visible = true;

            if (partitura.ArchivoPDF != null)
            {
                try
                {
                    using var stream = new MemoryStream(partitura.ArchivoPDF);
                    using var document = PdfiumViewer.PdfDocument.Load(stream);

                    Image previewImage = document.Render(0, previewBox.Width, previewBox.Height, true);
                    previewBox.Image = previewImage;
                    previewBox.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al mostrar el PDF existente: " + ex.Message);
                }
            }

            if (partitura.Precio == 0)
            {
                checkBoxGratuita.Checked = true;
            }
            else
            {
                checkBoxPago.Checked = true;
                textBoxPrecioBase.Text = partitura.Precio.ToString("0.00");
            }
        }


        private void ActualizarPartituraEnBD(int id, string nombre, string compositor, string epoca,
                                     string agrupacion, string instrumentos, decimal precio, byte[] pdfBytes)
        {
            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                var cmd = new SqlCommand(@"
            UPDATE Partituras
            SET Nombre = @nombre,
                Compositor = @compositor,
                Epoca = @epoca,
                Agrupacion = @agrupacion,
                Instrumentos = @instrumentos,
                Precio = @precio,
                ArchivoPDF = @pdf
            WHERE Id = @id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@compositor", compositor);
                cmd.Parameters.AddWithValue("@epoca", epoca);
                cmd.Parameters.AddWithValue("@agrupacion", agrupacion);
                cmd.Parameters.AddWithValue("@instrumentos", instrumentos);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@pdf", pdfBytes ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Partitura actualizada.");
        }


        private void btnVisualizarPartitura_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Primero selecciona una imagen.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(selectedFilePath);
            string carpetaDescargas = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
            string pdfPath = Path.Combine(carpetaDescargas, fileNameWithoutExt + "-print.pdf");

            if (!File.Exists(pdfPath))
            {
                MessageBox.Show("No se encontró el PDF exportado.\nAsegúrate de hacer clic en el botón de 'Exportar PDF' dentro de Audiveris.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MostrarVistaPreviaPDF(pdfPath);
        }

        private void DibujarBordePanel(Control panel, PaintEventArgs e, Color color, int grosor)
        {
            ControlPaint.DrawBorder(
                e.Graphics,
                panel.ClientRectangle,
                color,
                grosor,
                ButtonBorderStyle.Solid,
                color,
                grosor,
                ButtonBorderStyle.Solid,
                color,
                grosor,
                ButtonBorderStyle.Solid,
                color,
                grosor,
                ButtonBorderStyle.Solid);
        }

        private void panelEpoca_Paint(object sender, PaintEventArgs e)
        {
            DibujarBordePanel(panelEpoca, e, Color.FromArgb(61, 76, 158), 2);
        }

        private void panelInstrumentos_Paint(object sender, PaintEventArgs e)
        {
            DibujarBordePanel(panelInstrumentos, e, Color.FromArgb(61, 76, 158), 2);
        }

        private void panelAgrupacion_Paint(object sender, PaintEventArgs e)
        {
            DibujarBordePanel(panelAgrupacion, e, Color.FromArgb(61, 76, 158), 2);
        }

        private void panelCompositor_Paint(object sender, PaintEventArgs e)
        {
            DibujarBordePanel(panelCompositor, e, Color.FromArgb(61, 76, 158), 2);
        }

        private void panelNombre_Paint(object sender, PaintEventArgs e)
        {
            DibujarBordePanel(panelNombre, e, Color.FromArgb(61, 76, 158), 2);
        }

        private void panelPrecio_Paint(object sender, PaintEventArgs e)
        {
            DibujarBordePanel(panelNombre, e, Color.FromArgb(61, 76, 158), 2);
        }

        private void checkBoxGratuita_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGratuita.Checked)
            {
                checkBoxPago.Checked = false;
                textBoxPrecioBase.Enabled = false;
                textBoxPrecioBase.Text = "";
                panelPrecio.Height = 0;
                labelPrecio1.Visible = false;
                labelEuro.Visible = false;
                labelPrecio2.Visible = false;
            }
        }

        private void checkBoxPago_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPago.Checked)
            {
                checkBoxGratuita.Checked = false;
                panelPrecio.Height = 45;
                textBoxPrecioBase.Enabled = true;
                labelEuro.Visible = true;
                labelPrecio1.Visible = true;
                labelPrecio2.Visible = true;
            }
        }

        private void textBoxPrecioBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            char decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
            {
                if (textBox.Text.Contains(decimalSeparator))
                {
                    int index = textBox.Text.IndexOf(decimalSeparator);
                    string decimals = textBox.Text.Substring(index + 1);
                    if (textBox.SelectionStart > index && decimals.Length >= 2)
                    {
                        e.Handled = true;
                        return;
                    }
                }
                return;
            }

            if (e.KeyChar == decimalSeparator && !textBox.Text.Contains(decimalSeparator))
                return;

            e.Handled = true;
        }

        private void previewBox_Paint(object sender, PaintEventArgs e)
        {
            if (previewBox.Image != null)
            {
                DibujarBordePanel(previewBox, e, Color.FromArgb(61, 76, 158), 2);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (hayCambios)
            {
                DialogResult resultado = MessageBox.Show(
                    "Hay cambios sin guardar. ¿Seguro que quieres cancelar?",
                    "Aviso",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado != DialogResult.Yes)
                    return;
            }

            var mainForm = this.FindForm() as MainForm;
            if (mainForm != null)
            {
                mainForm.MostrarMisPartituras();
            }
        }


        private void Modificado()
        {
            hayCambios = true;
            lblLimpiar.Visible = true;
        }

        private void Cambios(object sender, EventArgs e)
        {
            Modificado();
        }


        private void UploadSheetsControl1_Load(object sender, EventArgs e)
        {
            textBoxNombre.TextChanged += Cambios;
            textBoxCompositor.TextChanged += Cambios;
            comboBoxEpoca.SelectedIndexChanged += Cambios;
            comboBoxAgrupacion.SelectedIndexChanged += Cambios;
            textBoxPrecioBase.TextChanged += Cambios;
            checkBoxGratuita.CheckedChanged += Cambios;
            checkBoxPago.CheckedChanged += Cambios;

        }

        private void lblLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            hayCambios = false;
            lblLimpiar.Visible = false;
        }
    }
}
