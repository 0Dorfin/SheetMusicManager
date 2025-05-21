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
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            lblSubirPartitura = new Label();
            btnSeleccionar = new Button();
            lblArchivo = new Label();
            previewBox = new PictureBox();
            btnProcesarPartitura = new Button();
            panelAudiveris = new Panel();
            btnGuardarPartitura = new Button();
            btnVisualizarPartitura = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBoxNombre = new TextBox();
            panelNombre = new Panel();
            panelEpoca = new Panel();
            comboBoxEpoca = new ComboBox();
            panelInstrumentos = new Panel();
            comboBoxInstrumentos = new PresentationControls.CheckBoxComboBox();
            textBox3 = new TextBox();
            panelAgrupacion = new Panel();
            comboBoxAgrupacion = new ComboBox();
            textBox4 = new TextBox();
            panelCompositor = new Panel();
            textBoxCompositor = new TextBox();
            label5 = new Label();
            checkBoxGratuita = new CheckBox();
            label6 = new Label();
            checkBoxPago = new CheckBox();
            textBoxPrecioBase = new TextBox();
            panelPrecio = new Panel();
            labelEuro = new Label();
            labelPrecio1 = new Label();
            labelPrecio2 = new Label();
            label7 = new Label();
            btnCancelar = new Button();
            lblLimpiar = new Label();
            ((System.ComponentModel.ISupportInitialize)previewBox).BeginInit();
            panelNombre.SuspendLayout();
            panelEpoca.SuspendLayout();
            panelInstrumentos.SuspendLayout();
            panelAgrupacion.SuspendLayout();
            panelCompositor.SuspendLayout();
            panelPrecio.SuspendLayout();
            SuspendLayout();
            // 
            // lblSubirPartitura
            // 
            lblSubirPartitura.AutoSize = true;
            lblSubirPartitura.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubirPartitura.Location = new Point(35, 29);
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
            btnSeleccionar.Location = new Point(35, 105);
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
            lblArchivo.Location = new Point(40, 170);
            lblArchivo.Name = "lblArchivo";
            lblArchivo.Size = new Size(239, 25);
            lblArchivo.TabIndex = 8;
            lblArchivo.Text = "Ningún archivo seleccionado";
            // 
            // previewBox
            // 
            previewBox.Location = new Point(40, 214);
            previewBox.Name = "previewBox";
            previewBox.Size = new Size(389, 500);
            previewBox.SizeMode = PictureBoxSizeMode.Zoom;
            previewBox.TabIndex = 9;
            previewBox.TabStop = false;
            previewBox.Visible = false;
            previewBox.Paint += previewBox_Paint;
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
            panelAudiveris.Size = new Size(1763, 1099);
            panelAudiveris.TabIndex = 11;
            // 
            // btnGuardarPartitura
            // 
            btnGuardarPartitura.BackColor = Color.FromArgb(61, 76, 158);
            btnGuardarPartitura.FlatStyle = FlatStyle.Flat;
            btnGuardarPartitura.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardarPartitura.ForeColor = Color.White;
            btnGuardarPartitura.Location = new Point(1946, 105);
            btnGuardarPartitura.Name = "btnGuardarPartitura";
            btnGuardarPartitura.Size = new Size(274, 50);
            btnGuardarPartitura.TabIndex = 12;
            btnGuardarPartitura.Text = "Guardar partitura";
            btnGuardarPartitura.UseVisualStyleBackColor = false;
            btnGuardarPartitura.Click += btnGuardarPartitura_Click;
            // 
            // btnVisualizarPartitura
            // 
            btnVisualizarPartitura.BackColor = Color.FromArgb(61, 76, 158);
            btnVisualizarPartitura.FlatStyle = FlatStyle.Flat;
            btnVisualizarPartitura.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVisualizarPartitura.ForeColor = Color.White;
            btnVisualizarPartitura.Location = new Point(1575, 105);
            btnVisualizarPartitura.Name = "btnVisualizarPartitura";
            btnVisualizarPartitura.Size = new Size(274, 50);
            btnVisualizarPartitura.TabIndex = 13;
            btnVisualizarPartitura.Text = "Ver partitura";
            btnVisualizarPartitura.UseVisualStyleBackColor = false;
            btnVisualizarPartitura.Click += btnVisualizarPartitura_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 734);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 28);
            label1.TabIndex = 14;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(30, 1049);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(137, 28);
            label2.TabIndex = 17;
            label2.Text = "Instrumentos";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(30, 944);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(68, 28);
            label3.TabIndex = 19;
            label3.Text = "Época";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(30, 1154);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(121, 28);
            label4.TabIndex = 21;
            label4.Text = "Agrupación";
            // 
            // textBoxNombre
            // 
            textBoxNombre.BackColor = Color.White;
            textBoxNombre.BorderStyle = BorderStyle.None;
            textBoxNombre.Location = new Point(14, 10);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(350, 24);
            textBoxNombre.TabIndex = 1;
            // 
            // panelNombre
            // 
            panelNombre.BackColor = Color.White;
            panelNombre.BorderStyle = BorderStyle.FixedSingle;
            panelNombre.Controls.Add(textBoxNombre);
            panelNombre.Location = new Point(35, 777);
            panelNombre.Name = "panelNombre";
            panelNombre.Size = new Size(384, 45);
            panelNombre.TabIndex = 22;
            panelNombre.Paint += panelNombre_Paint;
            // 
            // panelEpoca
            // 
            panelEpoca.BackColor = Color.White;
            panelEpoca.BorderStyle = BorderStyle.FixedSingle;
            panelEpoca.Controls.Add(comboBoxEpoca);
            panelEpoca.Location = new Point(35, 987);
            panelEpoca.Name = "panelEpoca";
            panelEpoca.Size = new Size(384, 45);
            panelEpoca.TabIndex = 24;
            panelEpoca.Paint += panelEpoca_Paint;
            // 
            // comboBoxEpoca
            // 
            comboBoxEpoca.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEpoca.FlatStyle = FlatStyle.Flat;
            comboBoxEpoca.FormattingEnabled = true;
            comboBoxEpoca.Items.AddRange(new object[] { "Barroco", "Clasicismo", "Romanticismo" });
            comboBoxEpoca.Location = new Point(14, 5);
            comboBoxEpoca.Name = "comboBoxEpoca";
            comboBoxEpoca.Size = new Size(350, 33);
            comboBoxEpoca.TabIndex = 2;
            // 
            // panelInstrumentos
            // 
            panelInstrumentos.BackColor = Color.White;
            panelInstrumentos.BorderStyle = BorderStyle.FixedSingle;
            panelInstrumentos.Controls.Add(comboBoxInstrumentos);
            panelInstrumentos.Controls.Add(textBox3);
            panelInstrumentos.Location = new Point(30, 1092);
            panelInstrumentos.Name = "panelInstrumentos";
            panelInstrumentos.Size = new Size(384, 45);
            panelInstrumentos.TabIndex = 26;
            panelInstrumentos.Paint += panelInstrumentos_Paint;
            // 
            // comboBoxInstrumentos
            // 
            checkBoxProperties1.ForeColor = SystemColors.ControlText;
            comboBoxInstrumentos.CheckBoxProperties = checkBoxProperties1;
            comboBoxInstrumentos.DisplayMemberSingleItem = "";
            comboBoxInstrumentos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxInstrumentos.FlatStyle = FlatStyle.Flat;
            comboBoxInstrumentos.FormattingEnabled = true;
            comboBoxInstrumentos.Items.AddRange(new object[] { "Órgano", "Clave", "Piano", "Violín", "Viola", "Violonchelo", "Contrabajo", "Clarinete", "Oboe", "Fagot", "Trompeta", "Flauta", "Trombón", "Trompa", "Soprano", "Mezzo", "Tenor", "Bajo", "Timbales" });
            comboBoxInstrumentos.Location = new Point(14, 5);
            comboBoxInstrumentos.Name = "comboBoxInstrumentos";
            comboBoxInstrumentos.Size = new Size(350, 33);
            comboBoxInstrumentos.TabIndex = 29;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.White;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Location = new Point(14, 14);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(350, 24);
            textBox3.TabIndex = 1;
            // 
            // panelAgrupacion
            // 
            panelAgrupacion.BackColor = Color.White;
            panelAgrupacion.BorderStyle = BorderStyle.FixedSingle;
            panelAgrupacion.Controls.Add(comboBoxAgrupacion);
            panelAgrupacion.Controls.Add(textBox4);
            panelAgrupacion.Location = new Point(30, 1197);
            panelAgrupacion.Name = "panelAgrupacion";
            panelAgrupacion.Size = new Size(384, 45);
            panelAgrupacion.TabIndex = 28;
            panelAgrupacion.Paint += panelAgrupacion_Paint;
            // 
            // comboBoxAgrupacion
            // 
            comboBoxAgrupacion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAgrupacion.FlatStyle = FlatStyle.Flat;
            comboBoxAgrupacion.FormattingEnabled = true;
            comboBoxAgrupacion.Items.AddRange(new object[] { "Solo", "Cámara", "Orquesta", "Coro" });
            comboBoxAgrupacion.Location = new Point(14, 5);
            comboBoxAgrupacion.Name = "comboBoxAgrupacion";
            comboBoxAgrupacion.Size = new Size(350, 33);
            comboBoxAgrupacion.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.White;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Location = new Point(14, 14);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(350, 24);
            textBox4.TabIndex = 1;
            // 
            // panelCompositor
            // 
            panelCompositor.BackColor = Color.White;
            panelCompositor.BorderStyle = BorderStyle.FixedSingle;
            panelCompositor.Controls.Add(textBoxCompositor);
            panelCompositor.Location = new Point(35, 882);
            panelCompositor.Name = "panelCompositor";
            panelCompositor.Size = new Size(384, 45);
            panelCompositor.TabIndex = 24;
            panelCompositor.Paint += panelCompositor_Paint;
            // 
            // textBoxCompositor
            // 
            textBoxCompositor.BackColor = Color.White;
            textBoxCompositor.BorderStyle = BorderStyle.None;
            textBoxCompositor.Location = new Point(14, 10);
            textBoxCompositor.Name = "textBoxCompositor";
            textBoxCompositor.Size = new Size(350, 24);
            textBoxCompositor.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(30, 839);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(121, 28);
            label5.TabIndex = 23;
            label5.Text = "Compositor";
            // 
            // checkBoxGratuita
            // 
            checkBoxGratuita.AutoSize = true;
            checkBoxGratuita.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoxGratuita.Location = new Point(35, 1297);
            checkBoxGratuita.Name = "checkBoxGratuita";
            checkBoxGratuita.Size = new Size(109, 32);
            checkBoxGratuita.TabIndex = 29;
            checkBoxGratuita.Text = "Gratuita";
            checkBoxGratuita.UseVisualStyleBackColor = true;
            checkBoxGratuita.CheckedChanged += checkBoxGratuita_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(30, 1259);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(88, 28);
            label6.TabIndex = 30;
            label6.Text = "Licencia";
            // 
            // checkBoxPago
            // 
            checkBoxPago.AutoSize = true;
            checkBoxPago.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoxPago.Location = new Point(150, 1297);
            checkBoxPago.Name = "checkBoxPago";
            checkBoxPago.Size = new Size(82, 32);
            checkBoxPago.TabIndex = 31;
            checkBoxPago.Text = "Pago";
            checkBoxPago.UseVisualStyleBackColor = true;
            checkBoxPago.CheckedChanged += checkBoxPago_CheckedChanged;
            // 
            // textBoxPrecioBase
            // 
            textBoxPrecioBase.BackColor = Color.White;
            textBoxPrecioBase.BorderStyle = BorderStyle.None;
            textBoxPrecioBase.Location = new Point(35, 10);
            textBoxPrecioBase.Name = "textBoxPrecioBase";
            textBoxPrecioBase.Size = new Size(329, 24);
            textBoxPrecioBase.TabIndex = 1;
            textBoxPrecioBase.KeyPress += textBoxPrecioBase_KeyPress;
            // 
            // panelPrecio
            // 
            panelPrecio.BackColor = Color.White;
            panelPrecio.BorderStyle = BorderStyle.FixedSingle;
            panelPrecio.Controls.Add(labelEuro);
            panelPrecio.Controls.Add(textBoxPrecioBase);
            panelPrecio.Location = new Point(30, 1416);
            panelPrecio.Name = "panelPrecio";
            panelPrecio.Padding = new Padding(0, 0, 0, 10);
            panelPrecio.Size = new Size(384, 0);
            panelPrecio.TabIndex = 23;
            panelPrecio.Paint += panelPrecio_Paint;
            // 
            // labelEuro
            // 
            labelEuro.AutoSize = true;
            labelEuro.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEuro.Location = new Point(7, 7);
            labelEuro.Margin = new Padding(2, 0, 2, 0);
            labelEuro.Name = "labelEuro";
            labelEuro.Size = new Size(23, 28);
            labelEuro.TabIndex = 35;
            labelEuro.Text = "€";
            labelEuro.Visible = false;
            // 
            // labelPrecio1
            // 
            labelPrecio1.AutoSize = true;
            labelPrecio1.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPrecio1.Location = new Point(30, 1344);
            labelPrecio1.Margin = new Padding(2, 0, 2, 0);
            labelPrecio1.Name = "labelPrecio1";
            labelPrecio1.Size = new Size(357, 28);
            labelPrecio1.TabIndex = 32;
            labelPrecio1.Text = "Precio licencia 90 días (IVA incluido)";
            labelPrecio1.Visible = false;
            // 
            // labelPrecio2
            // 
            labelPrecio2.AutoSize = true;
            labelPrecio2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPrecio2.Location = new Point(30, 1372);
            labelPrecio2.Margin = new Padding(2, 0, 2, 0);
            labelPrecio2.Name = "labelPrecio2";
            labelPrecio2.Size = new Size(339, 28);
            labelPrecio2.TabIndex = 33;
            labelPrecio2.Text = "(aumentará un 25% con cada licencia)";
            labelPrecio2.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(30, 1474);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(0, 28);
            label7.TabIndex = 34;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(61, 76, 158);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(1946, 29);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(274, 50);
            btnCancelar.TabIndex = 35;
            btnCancelar.Text = "Cancelar edición";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Visible = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblLimpiar
            // 
            lblLimpiar.AutoSize = true;
            lblLimpiar.Cursor = Cursors.Hand;
            lblLimpiar.Font = new Font("Segoe UI", 9.857143F);
            lblLimpiar.ForeColor = Color.FromArgb(61, 76, 158);
            lblLimpiar.Location = new Point(457, 37);
            lblLimpiar.Name = "lblLimpiar";
            lblLimpiar.Size = new Size(150, 28);
            lblLimpiar.TabIndex = 36;
            lblLimpiar.Text = "Limpiar campos";
            lblLimpiar.Visible = false;
            lblLimpiar.Click += lblLimpiar_Click;
            // 
            // UploadSheetsControl1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(lblLimpiar);
            Controls.Add(btnCancelar);
            Controls.Add(label7);
            Controls.Add(labelPrecio2);
            Controls.Add(labelPrecio1);
            Controls.Add(panelPrecio);
            Controls.Add(checkBoxPago);
            Controls.Add(label6);
            Controls.Add(checkBoxGratuita);
            Controls.Add(panelCompositor);
            Controls.Add(label5);
            Controls.Add(panelAgrupacion);
            Controls.Add(panelInstrumentos);
            Controls.Add(panelEpoca);
            Controls.Add(panelNombre);
            Controls.Add(btnVisualizarPartitura);
            Controls.Add(btnGuardarPartitura);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panelAudiveris);
            Controls.Add(btnProcesarPartitura);
            Controls.Add(previewBox);
            Controls.Add(lblArchivo);
            Controls.Add(btnSeleccionar);
            Controls.Add(lblSubirPartitura);
            Name = "UploadSheetsControl1";
            Size = new Size(2422, 1861);
            Load += UploadSheetsControl1_Load;
            ((System.ComponentModel.ISupportInitialize)previewBox).EndInit();
            panelNombre.ResumeLayout(false);
            panelNombre.PerformLayout();
            panelEpoca.ResumeLayout(false);
            panelInstrumentos.ResumeLayout(false);
            panelInstrumentos.PerformLayout();
            panelAgrupacion.ResumeLayout(false);
            panelAgrupacion.PerformLayout();
            panelCompositor.ResumeLayout(false);
            panelCompositor.PerformLayout();
            panelPrecio.ResumeLayout(false);
            panelPrecio.PerformLayout();
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
        private Button btnGuardarPartitura;
        private Button btnVisualizarPartitura;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBoxNombre;
        private Panel panelNombre;
        private Panel panelEpoca;
        private ComboBox comboBoxEpoca;
        private Panel panelInstrumentos;
        private Panel panelAgrupacion;
        private ComboBox comboBoxAgrupacion;
        private TextBox textBox3;
        private TextBox textBox4;
        private PresentationControls.CheckBoxComboBox comboBoxInstrumentos;
        private Panel panelCompositor;
        private TextBox textBoxCompositor;
        private Label label5;
        private CheckBox checkBoxGratuita;
        private Label label6;
        private CheckBox checkBoxPago;
        private TextBox textBoxPrecioBase;
        private Panel panelPrecio;
        private Label labelPrecio1;
        private Label labelPrecio2;
        private Label label7;
        private Label labelEuro;
        private Button btnCancelar;
        private Label lblLimpiar;
    }
}
