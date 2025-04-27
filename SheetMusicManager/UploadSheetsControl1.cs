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
                    previewBox.Visible = false;
                    MessageBox.Show("PDF cargado correctamente (no se puede previsualizar aquí).");
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
            }
        }

        private void btnProcesarPartitura_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Primero selecciona una partitura.");
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

                string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    var cmd = new SqlCommand(@"
                        INSERT INTO Partituras 
                        (NombreArchivo, ArchivoPDF, FechaSubida, Nombre, Compositor, Epoca, Instrumentos, Agrupacion)
                        VALUES 
                        (@nombreArchivo, @pdf, @fecha, @nombre, @compositor, @epoca, @instrumentos, @agrupacion)", conn);


                    cmd.Parameters.AddWithValue("@nombreArchivo", nombreArchivo);
                    cmd.Parameters.AddWithValue("@pdf", contenidoPDF);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@compositor", compositor);
                    cmd.Parameters.AddWithValue("@epoca", epoca);
                    cmd.Parameters.AddWithValue("@instrumentos", instrumentosSeleccionados);
                    cmd.Parameters.AddWithValue("@agrupacion", agrupacion);

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

        private void LimpiarFormulario()
        {
            textBoxNombre.Clear();
            textBoxCompositor.Clear();
            comboBoxEpoca.SelectedIndex = -1;
            comboBoxAgrupacion.SelectedIndex = -1;
            lblArchivo.Text = "Ningún archivo seleccionado";

            foreach (CheckBoxComboBoxItem item in comboBoxInstrumentos.CheckBoxItems)
            {
                item.Checked = false;
            }
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
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Primero selecciona una partitura.");
                return;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(selectedFilePath);
            string carpetaDescargas = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
            string pdfPath = Path.Combine(carpetaDescargas, fileNameWithoutExt + "-print.pdf");

            if (!File.Exists(pdfPath))
            {
                MessageBox.Show("No se encontró el PDF generado. Asegúrate de haberlo exportado desde Audiveris.");
                return;
            }

            GuardarPartituraSinConfirmacion(pdfPath);
        }

        private void btnVisualizarPartitura_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Primero selecciona una imagen.");
                return;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(selectedFilePath);
            string carpetaDescargas = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
            string pdfPath = Path.Combine(carpetaDescargas, fileNameWithoutExt + "-print.pdf");

            if (!File.Exists(pdfPath))
            {
                MessageBox.Show("❌ No se encontró el PDF exportado.\nAsegúrate de hacer clic en el botón de 'Exportar PDF' dentro de Audiveris.");
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
    }
}
