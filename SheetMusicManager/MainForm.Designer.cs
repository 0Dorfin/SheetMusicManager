namespace SheetMusicManager
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            btnLogout = new Button();
            btnSubirPartitura = new Button();
            label5 = new Label();
            panelBuscar = new Panel();
            textBox1 = new TextBox();
            pictureBox2 = new PictureBox();
            btnLogin = new Button();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            mainContentPanel = new Panel();
            panelHeader.SuspendLayout();
            panelBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(btnLogout);
            panelHeader.Controls.Add(btnSubirPartitura);
            panelHeader.Controls.Add(label5);
            panelHeader.Controls.Add(panelBuscar);
            panelHeader.Controls.Add(btnLogin);
            panelHeader.Controls.Add(label4);
            panelHeader.Controls.Add(label3);
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(pictureBox1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(2261, 100);
            panelHeader.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DimGray;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Transparent;
            btnLogout.Image = Properties.Resources.whiteuser4__1_1;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(1702, 23);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(187, 55);
            btnLogout.TabIndex = 8;
            btnLogout.TabStop = false;
            btnLogout.Text = "    Cerrar sesión";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Visible = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnSubirPartitura
            // 
            btnSubirPartitura.BackColor = Color.White;
            btnSubirPartitura.Cursor = Cursors.Hand;
            btnSubirPartitura.FlatAppearance.BorderColor = Color.LightGray;
            btnSubirPartitura.FlatStyle = FlatStyle.Flat;
            btnSubirPartitura.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubirPartitura.Image = Properties.Resources.sheetm1;
            btnSubirPartitura.ImageAlign = ContentAlignment.MiddleLeft;
            btnSubirPartitura.Location = new Point(1271, 23);
            btnSubirPartitura.Name = "btnSubirPartitura";
            btnSubirPartitura.Size = new Size(191, 54);
            btnSubirPartitura.TabIndex = 1;
            btnSubirPartitura.Text = "    Subir paritura";
            btnSubirPartitura.UseVisualStyleBackColor = false;
            btnSubirPartitura.Click += btnSubirPartitura_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Cursor = Cursors.Hand;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(61, 76, 158);
            label5.Location = new Point(212, 33);
            label5.Name = "label5";
            label5.Size = new Size(116, 30);
            label5.TabIndex = 7;
            label5.Text = "Partituras";
            label5.Click += label5_Click;
            // 
            // panelBuscar
            // 
            panelBuscar.BackColor = Color.White;
            panelBuscar.Controls.Add(textBox1);
            panelBuscar.Controls.Add(pictureBox2);
            panelBuscar.Location = new Point(818, 23);
            panelBuscar.Name = "panelBuscar";
            panelBuscar.Size = new Size(383, 55);
            panelBuscar.TabIndex = 6;
            panelBuscar.Paint += panelBuscar_Paint;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(60, 14);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(304, 24);
            textBox1.TabIndex = 1;
            textBox1.Text = "Buscar partituras";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.search;
            pictureBox2.InitialImage = Properties.Resources.search;
            pictureBox2.Location = new Point(14, 8);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 38);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(61, 76, 158);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.Transparent;
            btnLogin.Image = Properties.Resources.whiteuser4__1_1;
            btnLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogin.Location = new Point(1488, 23);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(187, 55);
            btnLogin.TabIndex = 5;
            btnLogin.TabStop = false;
            btnLogin.Text = "    Iniciar sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(681, 31);
            label4.Name = "label4";
            label4.Size = new Size(83, 30);
            label4.TabIndex = 4;
            label4.Text = "Ventas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Cursor = Cursors.Hand;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(548, 31);
            label3.Name = "label3";
            label3.Size = new Size(105, 30);
            label3.TabIndex = 3;
            label3.Text = "Licencias";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(361, 31);
            label1.Name = "label1";
            label1.Size = new Size(160, 30);
            label1.TabIndex = 1;
            label1.Text = "Mis partituras";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(96, 91);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // mainContentPanel
            // 
            mainContentPanel.Dock = DockStyle.Fill;
            mainContentPanel.Location = new Point(0, 100);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Size = new Size(2261, 1318);
            mainContentPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2261, 1418);
            Controls.Add(mainContentPanel);
            Controls.Add(panelHeader);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sheets";
            Load += MainForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelBuscar.ResumeLayout(false);
            panelBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private PictureBox pictureBox1;
        private Button btnLogin;
        private Label label4;
        private Label label3;
        private Label label1;
        private Panel panelBuscar;
        private PictureBox pictureBox2;
        private TextBox textBox1;
        private Label label5;
        private Button btnSubirPartitura;
        private Panel mainContentPanel;
        private Button btnLogout;
    }
}