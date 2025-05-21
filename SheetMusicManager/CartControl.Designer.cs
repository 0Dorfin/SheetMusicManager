namespace SheetMusicManager
{
    partial class CartControl
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
            flowLayoutPanelVentas = new FlowLayoutPanel();
            panelVentas = new Panel();
            panelPartituras = new Panel();
            btnEliminar = new PictureBox();
            labelPrecioP = new Label();
            labelNombreP = new Label();
            labelCompositorP = new Label();
            labelInstrumentosP = new Label();
            labelTiempoP = new Label();
            panelTotal = new Panel();
            pictureBox6 = new PictureBox();
            btnVaciar = new Button();
            labelPrecioTotalP = new Label();
            pictureBoxRecibo = new PictureBox();
            label5 = new Label();
            btnComprar = new Button();
            labelNumeroP = new Label();
            label2 = new Label();
            labelVentasRegistradas = new Label();
            lblCarrito = new Label();
            panel1.SuspendLayout();
            flowLayoutPanelVentas.SuspendLayout();
            panelVentas.SuspendLayout();
            panelPartituras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnEliminar).BeginInit();
            panelTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecibo).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(flowLayoutPanelVentas);
            panel1.Controls.Add(labelNumeroP);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(238, 189);
            panel1.Margin = new Padding(3, 3, 3, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(1639, 1316);
            panel1.TabIndex = 9;
            // 
            // flowLayoutPanelVentas
            // 
            flowLayoutPanelVentas.AutoSize = true;
            flowLayoutPanelVentas.BackColor = SystemColors.Control;
            flowLayoutPanelVentas.Controls.Add(panelVentas);
            flowLayoutPanelVentas.Controls.Add(panelTotal);
            flowLayoutPanelVentas.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelVentas.Location = new Point(101, 74);
            flowLayoutPanelVentas.Margin = new Padding(3, 3, 3, 30);
            flowLayoutPanelVentas.Name = "flowLayoutPanelVentas";
            flowLayoutPanelVentas.Size = new Size(1500, 206);
            flowLayoutPanelVentas.TabIndex = 1;
            flowLayoutPanelVentas.WrapContents = false;
            // 
            // panelVentas
            // 
            panelVentas.BackColor = SystemColors.Control;
            panelVentas.Controls.Add(panelPartituras);
            panelVentas.Location = new Point(3, 3);
            panelVentas.Name = "panelVentas";
            panelVentas.Size = new Size(1494, 108);
            panelVentas.TabIndex = 0;
            panelVentas.Visible = false;
            // 
            // panelPartituras
            // 
            panelPartituras.Controls.Add(btnEliminar);
            panelPartituras.Controls.Add(labelPrecioP);
            panelPartituras.Controls.Add(labelNombreP);
            panelPartituras.Controls.Add(labelCompositorP);
            panelPartituras.Controls.Add(labelInstrumentosP);
            panelPartituras.Controls.Add(labelTiempoP);
            panelPartituras.Dock = DockStyle.Fill;
            panelPartituras.Location = new Point(0, 0);
            panelPartituras.Name = "panelPartituras";
            panelPartituras.Size = new Size(1494, 108);
            panelPartituras.TabIndex = 0;
            // 
            // btnEliminar
            // 
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Image = Properties.Resources.delete1;
            btnEliminar.Location = new Point(1419, 25);
            btnEliminar.Margin = new Padding(2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(30, 30);
            btnEliminar.SizeMode = PictureBoxSizeMode.StretchImage;
            btnEliminar.TabIndex = 31;
            btnEliminar.TabStop = false;
            // 
            // labelPrecioP
            // 
            labelPrecioP.AutoSize = true;
            labelPrecioP.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPrecioP.Location = new Point(1285, 25);
            labelPrecioP.Name = "labelPrecioP";
            labelPrecioP.Size = new Size(132, 25);
            labelPrecioP.TabIndex = 28;
            labelPrecioP.Text = "Precio partitura";
            // 
            // labelNombreP
            // 
            labelNombreP.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelNombreP.Location = new Point(27, 20);
            labelNombreP.Name = "labelNombreP";
            labelNombreP.Size = new Size(390, 30);
            labelNombreP.TabIndex = 24;
            labelNombreP.Text = "Nombre partitura";
            // 
            // labelCompositorP
            // 
            labelCompositorP.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCompositorP.Location = new Point(27, 60);
            labelCompositorP.Name = "labelCompositorP";
            labelCompositorP.Size = new Size(390, 25);
            labelCompositorP.TabIndex = 25;
            labelCompositorP.Text = "Compositor";
            // 
            // labelInstrumentosP
            // 
            labelInstrumentosP.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelInstrumentosP.Location = new Point(423, 25);
            labelInstrumentosP.Name = "labelInstrumentosP";
            labelInstrumentosP.Size = new Size(351, 60);
            labelInstrumentosP.TabIndex = 26;
            labelInstrumentosP.Text = "Instrumentos";
            // 
            // labelTiempoP
            // 
            labelTiempoP.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTiempoP.Location = new Point(808, 25);
            labelTiempoP.Name = "labelTiempoP";
            labelTiempoP.Size = new Size(305, 25);
            labelTiempoP.TabIndex = 27;
            labelTiempoP.Text = "Tiempo de uso: 180 días";
            // 
            // panelTotal
            // 
            panelTotal.Controls.Add(pictureBox6);
            panelTotal.Controls.Add(btnVaciar);
            panelTotal.Controls.Add(labelPrecioTotalP);
            panelTotal.Controls.Add(pictureBoxRecibo);
            panelTotal.Controls.Add(label5);
            panelTotal.Controls.Add(btnComprar);
            panelTotal.Location = new Point(3, 117);
            panelTotal.Name = "panelTotal";
            panelTotal.Size = new Size(1494, 86);
            panelTotal.TabIndex = 1;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.bag;
            pictureBox6.Location = new Point(1168, 36);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(25, 25);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 25;
            pictureBox6.TabStop = false;
            // 
            // btnVaciar
            // 
            btnVaciar.BackColor = Color.White;
            btnVaciar.Cursor = Cursors.Hand;
            btnVaciar.FlatAppearance.BorderColor = Color.LightGray;
            btnVaciar.FlatStyle = FlatStyle.Flat;
            btnVaciar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVaciar.ForeColor = Color.FromArgb(61, 76, 158);
            btnVaciar.ImageAlign = ContentAlignment.MiddleLeft;
            btnVaciar.Location = new Point(1147, 23);
            btnVaciar.Name = "btnVaciar";
            btnVaciar.Size = new Size(152, 45);
            btnVaciar.TabIndex = 26;
            btnVaciar.Text = "     Vaciar";
            btnVaciar.UseVisualStyleBackColor = false;
            btnVaciar.Click += btnVaciar_Click;
            // 
            // labelPrecioTotalP
            // 
            labelPrecioTotalP.AutoSize = true;
            labelPrecioTotalP.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelPrecioTotalP.Location = new Point(82, 29);
            labelPrecioTotalP.Name = "labelPrecioTotalP";
            labelPrecioTotalP.Size = new Size(91, 32);
            labelPrecioTotalP.TabIndex = 9;
            labelPrecioTotalP.Text = "99.99€";
            // 
            // pictureBoxRecibo
            // 
            pictureBoxRecibo.BackColor = Color.FromArgb(61, 76, 158);
            pictureBoxRecibo.Image = Properties.Resources.checklist;
            pictureBoxRecibo.Location = new Point(1343, 36);
            pictureBoxRecibo.Name = "pictureBoxRecibo";
            pictureBoxRecibo.Size = new Size(25, 25);
            pictureBoxRecibo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRecibo.TabIndex = 22;
            pictureBoxRecibo.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(27, 29);
            label5.Name = "label5";
            label5.Size = new Size(64, 30);
            label5.TabIndex = 8;
            label5.Text = "Total:";
            // 
            // btnComprar
            // 
            btnComprar.BackColor = Color.FromArgb(61, 76, 158);
            btnComprar.Cursor = Cursors.Hand;
            btnComprar.FlatAppearance.BorderSize = 0;
            btnComprar.FlatStyle = FlatStyle.Flat;
            btnComprar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnComprar.ForeColor = Color.Transparent;
            btnComprar.ImageAlign = ContentAlignment.MiddleLeft;
            btnComprar.Location = new Point(1328, 24);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(152, 45);
            btnComprar.TabIndex = 21;
            btnComprar.TabStop = false;
            btnComprar.Text = "    Comprar";
            btnComprar.UseVisualStyleBackColor = false;
            btnComprar.Click += btnComprar_Click;
            // 
            // labelNumeroP
            // 
            labelNumeroP.AutoSize = true;
            labelNumeroP.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNumeroP.Location = new Point(213, 29);
            labelNumeroP.Name = "labelNumeroP";
            labelNumeroP.Size = new Size(48, 28);
            labelNumeroP.TabIndex = 30;
            labelNumeroP.Text = "100";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(131, 31);
            label2.Name = "label2";
            label2.Size = new Size(89, 25);
            label2.TabIndex = 29;
            label2.Text = "Partituras:";
            // 
            // labelVentasRegistradas
            // 
            labelVentasRegistradas.AutoSize = true;
            labelVentasRegistradas.Font = new Font("Segoe UI", 14F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelVentasRegistradas.Location = new Point(980, 606);
            labelVentasRegistradas.Name = "labelVentasRegistradas";
            labelVentasRegistradas.Size = new Size(332, 38);
            labelVentasRegistradas.TabIndex = 10;
            labelVentasRegistradas.Text = "No hay ventas registradas";
            labelVentasRegistradas.Visible = false;
            // 
            // lblCarrito
            // 
            lblCarrito.AutoSize = true;
            lblCarrito.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCarrito.Location = new Point(339, 132);
            lblCarrito.Name = "lblCarrito";
            lblCarrito.Size = new Size(307, 45);
            lblCarrito.TabIndex = 8;
            lblCarrito.Text = "Carrito de compras";
            // 
            // CartControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(labelVentasRegistradas);
            Controls.Add(lblCarrito);
            Name = "CartControl";
            Size = new Size(2358, 1861);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanelVentas.ResumeLayout(false);
            panelVentas.ResumeLayout(false);
            panelPartituras.ResumeLayout(false);
            panelPartituras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnEliminar).EndInit();
            panelTotal.ResumeLayout(false);
            panelTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecibo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanelVentas;
        private Panel panelVentas;
        private PictureBox pictureBoxRecibo;
        private Label labelPrecioTotalP;
        private Label label5;
        private Button btnComprar;
        private Label labelVentasRegistradas;
        private Label lblCarrito;
        private Panel panelTotal;
        private Panel panelPartituras;
        private Label labelNumeroP;
        private Label label2;
        private Label labelPrecioP;
        private Label labelNombreP;
        private Label labelCompositorP;
        private Label labelInstrumentosP;
        private Label labelTiempoP;
        private PictureBox btnEliminar;
        private PictureBox pictureBox6;
        private Button btnVaciar;
    }
}
