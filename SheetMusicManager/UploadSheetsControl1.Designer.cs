namespace SheetMusicManager
{
    partial class UploadSheetsControl1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSubirPartitura = new Label();
            btnSeleccionar = new Button();
            lblArchivo = new Label();
            previewBox = new PictureBox();
            btnProcesarPartitura = new Button();
            panelAudiveris = new Panel();
            ((System.ComponentModel.ISupportInitialize)previewBox).BeginInit();
            SuspendLayout();
            // 
            // lblSubirPartitura
            // 
            lblSubirPartitura.AutoSize = true;
            lblSubirPartitura.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubirPartitura.Location = new Point(25, 35);
            lblSubirPartitura.Name = "lblSubirPartitura";
            lblSubirPartitura.Size = new Size(298, 38);
            lblSubirPartitura.TabIndex = 0;
            lblSubirPartitura.Text = "Subir nueva partitura";
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.BackColor = Color.FromArgb(61, 76, 158);
            btnSeleccionar.FlatStyle = FlatStyle.Flat;
            btnSeleccionar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSeleccionar.ForeColor = Color.White;
            btnSeleccionar.Location = new Point(25, 105);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(274, 50);
            btnSeleccionar.TabIndex = 7;
            btnSeleccionar.Text = "Seleccionar archivo";
            btnSeleccionar.UseVisualStyleBackColor = false;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // lblArchivo
            // 
            lblArchivo.AutoSize = true;
            lblArchivo.Location = new Point(25, 188);
            lblArchivo.Name = "lblArchivo";
            lblArchivo.Size = new Size(239, 25);
            lblArchivo.TabIndex = 8;
            lblArchivo.Text = "Ningún archivo seleccionado";
            // 
            // previewBox
            // 
            previewBox.BorderStyle = BorderStyle.FixedSingle;
            previewBox.Location = new Point(35, 241);
            previewBox.Name = "previewBox";
            previewBox.Size = new Size(389, 540);
            previewBox.SizeMode = PictureBoxSizeMode.Zoom;
            previewBox.TabIndex = 9;
            previewBox.TabStop = false;
            previewBox.Visible = false;
            // 
            // btnProcesarPartitura
            // 
            btnProcesarPartitura.BackColor = Color.FromArgb(61, 76, 158);
            btnProcesarPartitura.FlatStyle = FlatStyle.Flat;
            btnProcesarPartitura.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProcesarPartitura.ForeColor = Color.White;
            btnProcesarPartitura.Location = new Point(457, 105);
            btnProcesarPartitura.Name = "btnProcesarPartitura";
            btnProcesarPartitura.Size = new Size(274, 50);
            btnProcesarPartitura.TabIndex = 10;
            btnProcesarPartitura.Text = "Procesar partitura";
            btnProcesarPartitura.UseVisualStyleBackColor = false;
            btnProcesarPartitura.Click += btnProcesarPartitura_Click;
            // 
            // panelAudiveris
            // 
            panelAudiveris.Location = new Point(457, 188);
            panelAudiveris.Name = "panelAudiveris";
            panelAudiveris.Size = new Size(1763, 1102);
            panelAudiveris.TabIndex = 11;
            // 
            // UploadSheetsControl1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelAudiveris);
            Controls.Add(btnProcesarPartitura);
            Controls.Add(previewBox);
            Controls.Add(lblArchivo);
            Controls.Add(btnSeleccionar);
            Controls.Add(lblSubirPartitura);
            Name = "UploadSheetsControl1";
            Size = new Size(2422, 1601);
            ((System.ComponentModel.ISupportInitialize)previewBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSubirPartitura;
        private Button btnSeleccionar;
        private Label lblArchivo;
        private PictureBox previewBox;
        private Button btnProcesarPartitura;
        private Panel panelAudiveris;
    }
}
