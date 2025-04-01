namespace SheetMusicManager
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelLogin = new Panel();
            pictureBox4 = new PictureBox();
            lblContrasenaO = new Label();
            lblRegistrar = new Label();
            btnLogin = new Button();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            textBox1 = new TextBox();
            lblContrasena = new Label();
            panelUsuario = new Panel();
            pictureBox1 = new PictureBox();
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.Azure;
            panelLogin.Controls.Add(pictureBox4);
            panelLogin.Controls.Add(lblContrasenaO);
            panelLogin.Controls.Add(lblRegistrar);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(panel1);
            panelLogin.Controls.Add(panelUsuario);
            panelLogin.Location = new Point(365, 140);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(583, 609);
            panelLogin.TabIndex = 1;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.logo;
            pictureBox4.Location = new Point(162, -39);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(259, 201);
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // lblContrasenaO
            // 
            lblContrasenaO.AutoSize = true;
            lblContrasenaO.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContrasenaO.Location = new Point(367, 550);
            lblContrasenaO.Name = "lblContrasenaO";
            lblContrasenaO.Size = new Size(162, 21);
            lblContrasenaO.TabIndex = 4;
            lblContrasenaO.Text = "Contraseña Olvidada?";
            // 
            // lblRegistrar
            // 
            lblRegistrar.AutoSize = true;
            lblRegistrar.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegistrar.Location = new Point(62, 550);
            lblRegistrar.Name = "lblRegistrar";
            lblRegistrar.Size = new Size(88, 21);
            lblRegistrar.TabIndex = 3;
            lblRegistrar.Text = "Registrarse";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(61, 76, 158);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.Control;
            btnLogin.Location = new Point(119, 423);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(348, 56);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(lblContrasena);
            panel1.Location = new Point(121, 292);
            panel1.Name = "panel1";
            panel1.Size = new Size(346, 90);
            panel1.TabIndex = 1;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.visible__1_;
            pictureBox3.Location = new Point(269, 42);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(31, 31);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.password2__1_;
            pictureBox2.Location = new Point(12, 42);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(31, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = Color.Black;
            textBox1.Location = new Point(49, 49);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(279, 24);
            textBox1.TabIndex = 1;
            textBox1.Text = "*********";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContrasena.Location = new Point(12, 11);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(118, 28);
            lblContrasena.TabIndex = 0;
            lblContrasena.Text = "Contraseña";
            // 
            // panelUsuario
            // 
            panelUsuario.BackColor = Color.White;
            panelUsuario.Controls.Add(pictureBox1);
            panelUsuario.Controls.Add(txtUsuario);
            panelUsuario.Controls.Add(lblUsuario);
            panelUsuario.Location = new Point(119, 168);
            panelUsuario.Name = "panelUsuario";
            panelUsuario.Size = new Size(346, 90);
            panelUsuario.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user1;
            pictureBox1.Location = new Point(12, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(31, 31);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.ForeColor = Color.Black;
            txtUsuario.Location = new Point(49, 49);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(279, 24);
            txtUsuario.TabIndex = 1;
            txtUsuario.Text = "Usuario";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(12, 11);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(84, 28);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(217, 226, 243);
            ClientSize = new Size(1281, 869);
            Controls.Add(panelLogin);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelUsuario.ResumeLayout(false);
            panelUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLogin;
        private Panel panelUsuario;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private PictureBox pictureBox1;
        private Panel panel1;
        private PictureBox pictureBox2;
        private TextBox textBox1;
        private Label lblContrasena;
        private PictureBox pictureBox3;
        private Button btnLogin;
        private Label lblContrasenaO;
        private Label lblRegistrar;
        private PictureBox pictureBox4;
    }
}
