using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
                    // Esperar a que Audiveris inicie y capture su ventana
                    foreach (Process p in Process.GetProcessesByName("java"))
                    {
                        if (!string.IsNullOrEmpty(p.MainWindowTitle))
                        {
                            timer.Stop();

                            // Insertar dentro del panel
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


    }
}