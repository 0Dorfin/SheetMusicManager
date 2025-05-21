namespace SheetMusicManager
{
    partial class SalesControl
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
            panel1 = new Panel();
            labelMostrar = new Label();
            flowLayoutPanelVentas = new FlowLayoutPanel();
            panelVentas = new Panel();
            labelCompradorV = new Label();
            flowPartituras = new FlowLayoutPanel();
            panelPartituras = new Panel();
            labelPrecioP = new Label();
            labelNombreP = new Label();
            labelCompositorP = new Label();
            labelInstrumentosP = new Label();
            labelTiempoP = new Label();
            panelTotal = new Panel();
            label1 = new Label();
            labelPrecioTotalP = new Label();
            label5 = new Label();
            labelMetodoPago = new Label();
            labelNumeroP = new Label();
            label2 = new Label();
            pictureBoxFecha = new PictureBox();
            labelFechaVentaV = new Label();
            labelVendido = new Label();
            lblPartituras = new Label();
            labelVentasRegistradas = new Label();
            panel2 = new Panel();
            cbUsuario = new ComboBox();
            cbLicencia = new ComboBox();
            dateTimeHasta = new DateTimePicker();
            label6 = new Label();
            dateTimeDesde = new DateTimePicker();
            btnAplicar = new Button();
            label4 = new Label();
            label3 = new Label();
            labelUsuario = new Label();
            labelLimpiar = new Label();
            label12 = new Label();
            panel1.SuspendLayout();
            flowLayoutPanelVentas.SuspendLayout();
            panelVentas.SuspendLayout();
            flowPartituras.SuspendLayout();
            panelPartituras.SuspendLayout();
            panelTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFecha).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(labelMostrar);
            panel1.Controls.Add(flowLayoutPanelVentas);
            panel1.Location = new Point(343, 163);
            panel1.Margin = new Padding(3, 3, 3, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(1639, 1390);
            panel1.TabIndex = 6;
            // 
            // labelMostrar
            // 
            labelMostrar.AutoSize = true;
            labelMostrar.Font = new Font("Segoe UI", 16F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelMostrar.Location = new Point(630, 534);
            labelMostrar.Name = "labelMostrar";
            labelMostrar.Size = new Size(393, 45);
            labelMostrar.TabIndex = 8;
            labelMostrar.Text = "No hay ventas que mostrar";
            labelMostrar.Visible = false;
            // 
            // flowLayoutPanelVentas
            // 
            flowLayoutPanelVentas.AutoSize = true;
            flowLayoutPanelVentas.BackColor = SystemColors.Control;
            flowLayoutPanelVentas.Controls.Add(panelVentas);
            flowLayoutPanelVentas.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelVentas.Location = new Point(98, 29);
            flowLayoutPanelVentas.Margin = new Padding(3, 3, 3, 30);
            flowLayoutPanelVentas.Name = "flowLayoutPanelVentas";
            flowLayoutPanelVentas.Size = new Size(1500, 331);
            flowLayoutPanelVentas.TabIndex = 1;
            flowLayoutPanelVentas.WrapContents = false;
            // 
            // panelVentas
            // 
            panelVentas.AutoSize = true;
            panelVentas.BackColor = SystemColors.Control;
            panelVentas.Controls.Add(labelCompradorV);
            panelVentas.Controls.Add(flowPartituras);
            panelVentas.Controls.Add(labelNumeroP);
            panelVentas.Controls.Add(label2);
            panelVentas.Controls.Add(pictureBoxFecha);
            panelVentas.Controls.Add(labelFechaVentaV);
            panelVentas.Controls.Add(labelVendido);
            panelVentas.Location = new Point(3, 3);
            panelVentas.Name = "panelVentas";
            panelVentas.Size = new Size(1485, 322);
            panelVentas.TabIndex = 0;
            panelVentas.Visible = false;
            panelVentas.Paint += panelVentas_Paint;
            // 
            // labelCompradorV
            // 
            labelCompradorV.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelCompradorV.Location = new Point(180, 34);
            labelCompradorV.Name = "labelCompradorV";
            labelCompradorV.Size = new Size(904, 32);
            labelCompradorV.TabIndex = 25;
            labelCompradorV.Text = "Comprador";
            // 
            // flowPartituras
            // 
            flowPartituras.AutoScroll = true;
            flowPartituras.Controls.Add(panelPartituras);
            flowPartituras.Controls.Add(panelTotal);
            flowPartituras.FlowDirection = FlowDirection.TopDown;
            flowPartituras.Location = new Point(53, 136);
            flowPartituras.Name = "flowPartituras";
            flowPartituras.Size = new Size(1429, 183);
            flowPartituras.TabIndex = 24;
            flowPartituras.WrapContents = false;
            // 
            // panelPartituras
            // 
            panelPartituras.Controls.Add(labelPrecioP);
            panelPartituras.Controls.Add(labelNombreP);
            panelPartituras.Controls.Add(labelCompositorP);
            panelPartituras.Controls.Add(labelInstrumentosP);
            panelPartituras.Controls.Add(labelTiempoP);
            panelPartituras.Location = new Point(3, 3);
            panelPartituras.Name = "panelPartituras";
            panelPartituras.Size = new Size(1396, 90);
            panelPartituras.TabIndex = 2;
            // 
            // labelPrecioP
            // 
            labelPrecioP.AutoSize = true;
            labelPrecioP.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPrecioP.Location = new Point(1244, 18);
            labelPrecioP.Name = "labelPrecioP";
            labelPrecioP.Size = new Size(132, 25);
            labelPrecioP.TabIndex = 6;
            labelPrecioP.Text = "Precio partitura";
            // 
            // labelNombreP
            // 
            labelNombreP.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelNombreP.Location = new Point(3, 13);
            labelNombreP.Name = "labelNombreP";
            labelNombreP.Size = new Size(390, 30);
            labelNombreP.TabIndex = 2;
            labelNombreP.Text = "Nombre partitura";
            // 
            // labelCompositorP
            // 
            labelCompositorP.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCompositorP.Location = new Point(3, 53);
            labelCompositorP.Name = "labelCompositorP";
            labelCompositorP.Size = new Size(364, 25);
            labelCompositorP.TabIndex = 3;
            labelCompositorP.Text = "Compositor";
            // 
            // labelInstrumentosP
            // 
            labelInstrumentosP.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelInstrumentosP.Location = new Point(399, 18);
            labelInstrumentosP.Name = "labelInstrumentosP";
            labelInstrumentosP.Size = new Size(379, 60);
            labelInstrumentosP.TabIndex = 4;
            labelInstrumentosP.Text = "Instrumentos";
            // 
            // labelTiempoP
            // 
            labelTiempoP.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTiempoP.Location = new Point(784, 18);
            labelTiempoP.Name = "labelTiempoP";
            labelTiempoP.Size = new Size(294, 25);
            labelTiempoP.TabIndex = 5;
            labelTiempoP.Text = "Tiempo de uso: 180 días";
            // 
            // panelTotal
            // 
            panelTotal.Controls.Add(label1);
            panelTotal.Controls.Add(labelPrecioTotalP);
            panelTotal.Controls.Add(label5);
            panelTotal.Controls.Add(labelMetodoPago);
            panelTotal.Location = new Point(0, 96);
            panelTotal.Margin = new Padding(0, 0, 0, 25);
            panelTotal.Name = "panelTotal";
            panelTotal.Size = new Size(1399, 83);
            panelTotal.TabIndex = 4;
            panelTotal.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(1289, 26);
            label1.Name = "label1";
            label1.Size = new Size(88, 32);
            label1.TabIndex = 9;
            label1.Text = "PayPal";
            // 
            // labelPrecioTotalP
            // 
            labelPrecioTotalP.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelPrecioTotalP.Location = new Point(149, 28);
            labelPrecioTotalP.Name = "labelPrecioTotalP";
            labelPrecioTotalP.Size = new Size(191, 32);
            labelPrecioTotalP.TabIndex = 9;
            labelPrecioTotalP.Text = "99.99€";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 28);
            label5.Name = "label5";
            label5.Size = new Size(149, 30);
            label5.TabIndex = 8;
            label5.Text = "Total recibido:";
            // 
            // labelMetodoPago
            // 
            labelMetodoPago.AutoSize = true;
            labelMetodoPago.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelMetodoPago.Location = new Point(1069, 26);
            labelMetodoPago.Name = "labelMetodoPago";
            labelMetodoPago.Size = new Size(221, 32);
            labelMetodoPago.TabIndex = 8;
            labelMetodoPago.Text = "Método de pago -";
            // 
            // labelNumeroP
            // 
            labelNumeroP.AutoSize = true;
            labelNumeroP.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNumeroP.Location = new Point(143, 88);
            labelNumeroP.Name = "labelNumeroP";
            labelNumeroP.Size = new Size(48, 28);
            labelNumeroP.TabIndex = 23;
            labelNumeroP.Text = "100";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(59, 90);
            label2.Name = "label2";
            label2.Size = new Size(89, 25);
            label2.TabIndex = 7;
            label2.Text = "Partituras:";
            // 
            // pictureBoxFecha
            // 
            pictureBoxFecha.Image = Properties.Resources._event;
            pictureBoxFecha.Location = new Point(1205, 40);
            pictureBoxFecha.Name = "pictureBoxFecha";
            pictureBoxFecha.Size = new Size(30, 30);
            pictureBoxFecha.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxFecha.TabIndex = 7;
            pictureBoxFecha.TabStop = false;
            // 
            // labelFechaVentaV
            // 
            labelFechaVentaV.AutoSize = true;
            labelFechaVentaV.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFechaVentaV.Location = new Point(1241, 40);
            labelFechaVentaV.Name = "labelFechaVentaV";
            labelFechaVentaV.Size = new Size(208, 25);
            labelFechaVentaV.TabIndex = 6;
            labelFechaVentaV.Text = "Fecha venta: 30/04/2025";
            labelFechaVentaV.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelVendido
            // 
            labelVendido.AutoSize = true;
            labelVendido.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelVendido.Location = new Point(53, 34);
            labelVendido.Name = "labelVendido";
            labelVendido.Size = new Size(126, 32);
            labelVendido.TabIndex = 0;
            labelVendido.Text = "Vendido a:";
            // 
            // lblPartituras
            // 
            lblPartituras.AutoSize = true;
            lblPartituras.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPartituras.Location = new Point(441, 97);
            lblPartituras.Name = "lblPartituras";
            lblPartituras.Size = new Size(261, 38);
            lblPartituras.TabIndex = 5;
            lblPartituras.Text = "Historial de ventas";
            // 
            // labelVentasRegistradas
            // 
            labelVentasRegistradas.AutoSize = true;
            labelVentasRegistradas.Font = new Font("Segoe UI", 14F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelVentasRegistradas.Location = new Point(900, 600);
            labelVentasRegistradas.Name = "labelVentasRegistradas";
            labelVentasRegistradas.Size = new Size(332, 38);
            labelVentasRegistradas.TabIndex = 7;
            labelVentasRegistradas.Text = "No hay ventas registradas";
            labelVentasRegistradas.Visible = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(cbUsuario);
            panel2.Controls.Add(cbLicencia);
            panel2.Controls.Add(dateTimeHasta);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(dateTimeDesde);
            panel2.Controls.Add(btnAplicar);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(labelUsuario);
            panel2.Controls.Add(labelLimpiar);
            panel2.Controls.Add(label12);
            panel2.Location = new Point(3, 97);
            panel2.Name = "panel2";
            panel2.Size = new Size(334, 1337);
            panel2.TabIndex = 6;
            // 
            // cbUsuario
            // 
            cbUsuario.FormattingEnabled = true;
            cbUsuario.Location = new Point(139, 339);
            cbUsuario.Name = "cbUsuario";
            cbUsuario.Size = new Size(182, 33);
            cbUsuario.TabIndex = 51;
            // 
            // cbLicencia
            // 
            cbLicencia.FormattingEnabled = true;
            cbLicencia.Location = new Point(139, 282);
            cbLicencia.Name = "cbLicencia";
            cbLicencia.Size = new Size(182, 33);
            cbLicencia.TabIndex = 50;
            // 
            // dateTimeHasta
            // 
            dateTimeHasta.Format = DateTimePickerFormat.Short;
            dateTimeHasta.Location = new Point(139, 221);
            dateTimeHasta.Name = "dateTimeHasta";
            dateTimeHasta.Size = new Size(182, 31);
            dateTimeHasta.TabIndex = 49;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(31, 220);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(73, 32);
            label6.TabIndex = 48;
            label6.Text = "Hasta";
            // 
            // dateTimeDesde
            // 
            dateTimeDesde.Format = DateTimePickerFormat.Short;
            dateTimeDesde.Location = new Point(139, 162);
            dateTimeDesde.Name = "dateTimeDesde";
            dateTimeDesde.Size = new Size(182, 31);
            dateTimeDesde.TabIndex = 46;
            // 
            // btnAplicar
            // 
            btnAplicar.BackColor = Color.FromArgb(61, 76, 158);
            btnAplicar.Cursor = Cursors.Hand;
            btnAplicar.FlatAppearance.BorderSize = 0;
            btnAplicar.FlatStyle = FlatStyle.Flat;
            btnAplicar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAplicar.ForeColor = Color.Transparent;
            btnAplicar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAplicar.Location = new Point(84, 394);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(152, 45);
            btnAplicar.TabIndex = 23;
            btnAplicar.TabStop = false;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = false;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(32, 279);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(98, 32);
            label4.TabIndex = 44;
            label4.Text = "Licencia";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(31, 159);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(81, 32);
            label3.TabIndex = 43;
            label3.Text = "Desde";
            // 
            // labelUsuario
            // 
            labelUsuario.AutoSize = true;
            labelUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUsuario.ForeColor = SystemColors.ControlDarkDark;
            labelUsuario.Location = new Point(31, 340);
            labelUsuario.Margin = new Padding(2, 0, 2, 0);
            labelUsuario.Name = "labelUsuario";
            labelUsuario.Size = new Size(94, 32);
            labelUsuario.TabIndex = 42;
            labelUsuario.Text = "Usuario";
            // 
            // labelLimpiar
            // 
            labelLimpiar.AutoSize = true;
            labelLimpiar.Cursor = Cursors.Hand;
            labelLimpiar.Font = new Font("Segoe UI", 9.857143F);
            labelLimpiar.ForeColor = Color.FromArgb(61, 76, 158);
            labelLimpiar.Location = new Point(221, 72);
            labelLimpiar.Name = "labelLimpiar";
            labelLimpiar.Size = new Size(77, 28);
            labelLimpiar.TabIndex = 41;
            labelLimpiar.Text = "Limpiar";
            labelLimpiar.Visible = false;
            labelLimpiar.Click += labelLimpiar_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(31, 66);
            label12.Name = "label12";
            label12.Size = new Size(99, 38);
            label12.TabIndex = 40;
            label12.Text = "Filtros";
            // 
            // SalesControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(labelVentasRegistradas);
            Controls.Add(lblPartituras);
            Name = "SalesControl";
            Size = new Size(2069, 1606);
            Load += SalesControl_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanelVentas.ResumeLayout(false);
            flowLayoutPanelVentas.PerformLayout();
            panelVentas.ResumeLayout(false);
            panelVentas.PerformLayout();
            flowPartituras.ResumeLayout(false);
            panelPartituras.ResumeLayout(false);
            panelPartituras.PerformLayout();
            panelTotal.ResumeLayout(false);
            panelTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFecha).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanelVentas;
        private Panel panelVentas;
        private Panel panelPartituras;
        private Label labelNombreP;
        private Label labelCompositorP;
        private Label labelTiempoP;
        private Label labelPrecioTotalP;
        private Label label5;
        private PictureBox pictureBoxFecha;
        private Label labelFechaVentaV;
        private Label labelVendido;
        private Label lblPartituras;
        private Label labelPrecioP;
        private Label labelInstrumentosP;
        private Label label2;
        private Label labelNumeroP;
        private Label labelVentasRegistradas;
        private FlowLayoutPanel flowPartituras;
        private Panel panelTotal;
        private Label label1;
        private Label labelMetodoPago;
        private Label labelCompradorV;
        private Panel panel2;
        private ComboBox cbUsuario;
        private ComboBox cbLicencia;
        private DateTimePicker dateTimeHasta;
        private Label label6;
        private DateTimePicker dateTimeDesde;
        private Button btnAplicar;
        private Label label4;
        private Label label3;
        private Label labelUsuario;
        private Label labelLimpiar;
        private Label label12;
        private Label labelMostrar;
    }
}
