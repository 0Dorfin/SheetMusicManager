namespace SheetMusicManager
{
    partial class OrderHistoryControl
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
            panelPedido = new Panel();
            labelNumeroP = new Label();
            label3 = new Label();
            flowPartituras = new FlowLayoutPanel();
            panelPlantillaPartituras = new Panel();
            labelPrecioPartitura = new Label();
            labelNombreP = new Label();
            labelCompositorP = new Label();
            labelInstrumentosP = new Label();
            labelTiempoP = new Label();
            panelTotal = new Panel();
            pictureBoxRecibo = new PictureBox();
            btnRecibo = new Button();
            label5 = new Label();
            labelPrecioP = new Label();
            pictureBoxFecha = new PictureBox();
            labelFechaPedidoP = new Label();
            label2 = new Label();
            labelMetodoPago = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblPartituras = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            cbUsuario = new ComboBox();
            cbLicencia = new ComboBox();
            dateTimeHasta = new DateTimePicker();
            label6 = new Label();
            dateTimeDesde = new DateTimePicker();
            btnAplicar = new Button();
            label4 = new Label();
            label1 = new Label();
            labelUsuario = new Label();
            labelLimpiar = new Label();
            label12 = new Label();
            labelMostrar = new Label();
            panelPedido.SuspendLayout();
            flowPartituras.SuspendLayout();
            panelPlantillaPartituras.SuspendLayout();
            panelTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecibo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFecha).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panelPedido
            // 
            panelPedido.AutoSize = true;
            panelPedido.BackColor = SystemColors.Control;
            panelPedido.Controls.Add(labelNumeroP);
            panelPedido.Controls.Add(label3);
            panelPedido.Controls.Add(flowPartituras);
            panelPedido.Controls.Add(pictureBoxFecha);
            panelPedido.Controls.Add(labelFechaPedidoP);
            panelPedido.Controls.Add(label2);
            panelPedido.Controls.Add(labelMetodoPago);
            panelPedido.Location = new Point(3, 3);
            panelPedido.Name = "panelPedido";
            panelPedido.Size = new Size(1474, 311);
            panelPedido.TabIndex = 0;
            panelPedido.Visible = false;
            panelPedido.Paint += panelPedido_Paint;
            // 
            // labelNumeroP
            // 
            labelNumeroP.AutoSize = true;
            labelNumeroP.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNumeroP.Location = new Point(140, 84);
            labelNumeroP.Name = "labelNumeroP";
            labelNumeroP.Size = new Size(48, 28);
            labelNumeroP.TabIndex = 25;
            labelNumeroP.Text = "100";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(56, 86);
            label3.Name = "label3";
            label3.Size = new Size(89, 25);
            label3.TabIndex = 24;
            label3.Text = "Partituras:";
            // 
            // flowPartituras
            // 
            flowPartituras.AutoScroll = true;
            flowPartituras.Controls.Add(panelPlantillaPartituras);
            flowPartituras.Controls.Add(panelTotal);
            flowPartituras.FlowDirection = FlowDirection.TopDown;
            flowPartituras.Location = new Point(53, 127);
            flowPartituras.Name = "flowPartituras";
            flowPartituras.Size = new Size(1418, 181);
            flowPartituras.TabIndex = 23;
            flowPartituras.WrapContents = false;
            // 
            // panelPlantillaPartituras
            // 
            panelPlantillaPartituras.Controls.Add(labelPrecioPartitura);
            panelPlantillaPartituras.Controls.Add(labelNombreP);
            panelPlantillaPartituras.Controls.Add(labelCompositorP);
            panelPlantillaPartituras.Controls.Add(labelInstrumentosP);
            panelPlantillaPartituras.Controls.Add(labelTiempoP);
            panelPlantillaPartituras.Location = new Point(3, 3);
            panelPlantillaPartituras.Name = "panelPlantillaPartituras";
            panelPlantillaPartituras.Size = new Size(1385, 90);
            panelPlantillaPartituras.TabIndex = 2;
            panelPlantillaPartituras.Visible = false;
            // 
            // labelPrecioPartitura
            // 
            labelPrecioPartitura.AutoSize = true;
            labelPrecioPartitura.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPrecioPartitura.Location = new Point(1197, 20);
            labelPrecioPartitura.Name = "labelPrecioPartitura";
            labelPrecioPartitura.Size = new Size(132, 25);
            labelPrecioPartitura.TabIndex = 7;
            labelPrecioPartitura.Text = "Precio partitura";
            // 
            // labelNombreP
            // 
            labelNombreP.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelNombreP.Location = new Point(11, 15);
            labelNombreP.Name = "labelNombreP";
            labelNombreP.Size = new Size(382, 30);
            labelNombreP.TabIndex = 2;
            labelNombreP.Text = "Nombre partitura";
            // 
            // labelCompositorP
            // 
            labelCompositorP.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCompositorP.Location = new Point(11, 55);
            labelCompositorP.Name = "labelCompositorP";
            labelCompositorP.Size = new Size(425, 25);
            labelCompositorP.TabIndex = 3;
            labelCompositorP.Text = "Compositor";
            // 
            // labelInstrumentosP
            // 
            labelInstrumentosP.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelInstrumentosP.Location = new Point(400, 19);
            labelInstrumentosP.Name = "labelInstrumentosP";
            labelInstrumentosP.Size = new Size(351, 60);
            labelInstrumentosP.TabIndex = 4;
            labelInstrumentosP.Text = "Instrumentos";
            // 
            // labelTiempoP
            // 
            labelTiempoP.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTiempoP.Location = new Point(785, 20);
            labelTiempoP.Name = "labelTiempoP";
            labelTiempoP.Size = new Size(251, 25);
            labelTiempoP.TabIndex = 5;
            labelTiempoP.Text = "Tiempo de uso: 180 días";
            // 
            // panelTotal
            // 
            panelTotal.Controls.Add(pictureBoxRecibo);
            panelTotal.Controls.Add(btnRecibo);
            panelTotal.Controls.Add(label5);
            panelTotal.Controls.Add(labelPrecioP);
            panelTotal.Location = new Point(0, 96);
            panelTotal.Margin = new Padding(0, 0, 0, 25);
            panelTotal.Name = "panelTotal";
            panelTotal.Size = new Size(1388, 82);
            panelTotal.TabIndex = 3;
            panelTotal.Visible = false;
            // 
            // pictureBoxRecibo
            // 
            pictureBoxRecibo.BackColor = Color.FromArgb(61, 76, 158);
            pictureBoxRecibo.Image = Properties.Resources.download_blanco;
            pictureBoxRecibo.Location = new Point(1236, 35);
            pictureBoxRecibo.Name = "pictureBoxRecibo";
            pictureBoxRecibo.Size = new Size(25, 25);
            pictureBoxRecibo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRecibo.TabIndex = 22;
            pictureBoxRecibo.TabStop = false;
            // 
            // btnRecibo
            // 
            btnRecibo.BackColor = Color.FromArgb(61, 76, 158);
            btnRecibo.Cursor = Cursors.Hand;
            btnRecibo.FlatAppearance.BorderSize = 0;
            btnRecibo.FlatStyle = FlatStyle.Flat;
            btnRecibo.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRecibo.ForeColor = Color.Transparent;
            btnRecibo.ImageAlign = ContentAlignment.MiddleLeft;
            btnRecibo.Location = new Point(1221, 23);
            btnRecibo.Name = "btnRecibo";
            btnRecibo.Size = new Size(152, 45);
            btnRecibo.TabIndex = 21;
            btnRecibo.TabStop = false;
            btnRecibo.Text = "    Recibo";
            btnRecibo.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 23);
            label5.Name = "label5";
            label5.Size = new Size(64, 30);
            label5.TabIndex = 8;
            label5.Text = "Total:";
            // 
            // labelPrecioP
            // 
            labelPrecioP.AutoSize = true;
            labelPrecioP.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelPrecioP.Location = new Point(61, 21);
            labelPrecioP.Name = "labelPrecioP";
            labelPrecioP.Size = new Size(91, 32);
            labelPrecioP.TabIndex = 9;
            labelPrecioP.Text = "99.99€";
            // 
            // pictureBoxFecha
            // 
            pictureBoxFecha.Image = Properties.Resources._event;
            pictureBoxFecha.Location = new Point(1183, 34);
            pictureBoxFecha.Name = "pictureBoxFecha";
            pictureBoxFecha.Size = new Size(30, 30);
            pictureBoxFecha.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxFecha.TabIndex = 7;
            pictureBoxFecha.TabStop = false;
            // 
            // labelFechaPedidoP
            // 
            labelFechaPedidoP.AutoSize = true;
            labelFechaPedidoP.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFechaPedidoP.Location = new Point(1219, 34);
            labelFechaPedidoP.Name = "labelFechaPedidoP";
            labelFechaPedidoP.Size = new Size(222, 25);
            labelFechaPedidoP.TabIndex = 6;
            labelFechaPedidoP.Text = "Fecha pedido: 30/04/2025";
            labelFechaPedidoP.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.SeaGreen;
            label2.Location = new Point(147, 34);
            label2.Name = "label2";
            label2.Size = new Size(99, 32);
            label2.TabIndex = 1;
            label2.Text = "Pagado";
            // 
            // labelMetodoPago
            // 
            labelMetodoPago.AutoSize = true;
            labelMetodoPago.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelMetodoPago.Location = new Point(53, 34);
            labelMetodoPago.Name = "labelMetodoPago";
            labelMetodoPago.Size = new Size(106, 32);
            labelMetodoPago.TabIndex = 0;
            labelMetodoPago.Text = "Paypal -";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.BackColor = SystemColors.Control;
            flowLayoutPanel1.Controls.Add(panelPedido);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(98, 29);
            flowLayoutPanel1.Margin = new Padding(3, 3, 3, 30);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1556, 317);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.WrapContents = false;
            // 
            // lblPartituras
            // 
            lblPartituras.AutoSize = true;
            lblPartituras.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPartituras.Location = new Point(441, 97);
            lblPartituras.Name = "lblPartituras";
            lblPartituras.Size = new Size(279, 38);
            lblPartituras.TabIndex = 3;
            lblPartituras.Text = "Historial de pedidos";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(labelMostrar);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Location = new Point(343, 163);
            panel1.Margin = new Padding(3, 3, 3, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(1657, 1337);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
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
            panel2.Controls.Add(label1);
            panel2.Controls.Add(labelUsuario);
            panel2.Controls.Add(labelLimpiar);
            panel2.Controls.Add(label12);
            panel2.Location = new Point(3, 97);
            panel2.Name = "panel2";
            panel2.Size = new Size(334, 1337);
            panel2.TabIndex = 5;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(31, 159);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(81, 32);
            label1.TabIndex = 43;
            label1.Text = "Desde";
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
            // labelMostrar
            // 
            labelMostrar.AutoSize = true;
            labelMostrar.Font = new Font("Segoe UI", 16F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelMostrar.Location = new Point(630, 534);
            labelMostrar.Name = "labelMostrar";
            labelMostrar.Size = new Size(409, 45);
            labelMostrar.TabIndex = 9;
            labelMostrar.Text = "No hay pedidos que mostrar";
            labelMostrar.Visible = false;
            // 
            // OrderHistoryControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblPartituras);
            Name = "OrderHistoryControl";
            Size = new Size(2069, 1606);
            Load += OrderHistoryControl_Load;
            panelPedido.ResumeLayout(false);
            panelPedido.PerformLayout();
            flowPartituras.ResumeLayout(false);
            panelPlantillaPartituras.ResumeLayout(false);
            panelPlantillaPartituras.PerformLayout();
            panelTotal.ResumeLayout(false);
            panelTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecibo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFecha).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelPedido;
        private Label labelMetodoPago;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label labelNombreP;
        private Label labelInstrumentosP;
        private Label labelCompositorP;
        private Label labelTiempoP;
        private Label labelFechaPedidoP;
        private Label labelPrecioP;
        private Label label5;
        private PictureBox pictureBoxFecha;
        private PictureBox pictureBoxRecibo;
        private Button btnRecibo;
        private Panel panelPlantillaPartituras;
        private Label lblPartituras;
        private Panel panel1;
        private FlowLayoutPanel flowPartituras;
        private Panel panelTotal;
        private Label labelPrecioPartitura;
        private Label labelNumeroP;
        private Label label3;
        private Panel panel2;
        private DateTimePicker dateTimeDesde;
        private Button btnAplicar;
        private Label label4;
        private Label label1;
        private Label labelUsuario;
        private Label labelLimpiar;
        private Label label12;
        private DateTimePicker dateTimeHasta;
        private Label label6;
        private ComboBox cbUsuario;
        private ComboBox cbLicencia;
        private Label labelMostrar;
    }
}
