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
            labelOlvidada = new Label();
            label1 = new Label();
            pictureBox4 = new PictureBox();
            lblRegistrar = new Label();
            btnLogin = new Button();
            panelPassword = new Panel();
            pictureBoxPass = new PictureBox();
            pictureBox2 = new PictureBox();
            txtPassword = new TextBox();
            lblContrasena = new Label();
            panelUsuario = new Panel();
            pictureBox1 = new PictureBox();
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            pictureBox5 = new PictureBox();
            panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panelPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.Azure;
            panelLogin.Controls.Add(labelOlvidada);
            panelLogin.Controls.Add(label1);
            panelLogin.Controls.Add(pictureBox4);
            panelLogin.Controls.Add(lblRegistrar);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(panelPassword);
            panelLogin.Controls.Add(panelUsuario);
            panelLogin.Location = new Point(349, 140);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(583, 609);
            panelLogin.TabIndex = 1;
            // 
            // labelOlvidada
            // 
            labelOlvidada.AutoSize = true;
            labelOlvidada.Cursor = Cursors.Hand;
            labelOlvidada.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelOlvidada.ForeColor = Color.MediumBlue;
            labelOlvidada.Location = new Point(362, 550);
            labelOlvidada.Name = "labelOlvidada";
            labelOlvidada.Size = new Size(159, 21);
            labelOlvidada.TabIndex = 7;
            labelOlvidada.Text = "Contraseña olvidada?";
            labelOlvidada.Click += labelOlvidada_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(62, 519);
            label1.Name = "label1";
            label1.Size = new Size(133, 21);
            label1.TabIndex = 6;
            label1.Text = "No tienes cuenta?";
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
            // lblRegistrar
            // 
            lblRegistrar.AutoSize = true;
            lblRegistrar.Cursor = Cursors.Hand;
            lblRegistrar.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegistrar.ForeColor = Color.MediumBlue;
            lblRegistrar.Location = new Point(62, 550);
            lblRegistrar.Name = "lblRegistrar";
            lblRegistrar.Size = new Size(88, 21);
            lblRegistrar.TabIndex = 3;
            lblRegistrar.Text = "Registrarse";
            lblRegistrar.Click += lblRegistrar_Click;
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
            btnLogin.Click += btnLogin_Click;
            // 
            // panelPassword
            // 
            panelPassword.BackColor = Color.White;
            panelPassword.Controls.Add(pictureBoxPass);
            panelPassword.Controls.Add(pictureBox2);
            panelPassword.Controls.Add(txtPassword);
            panelPassword.Controls.Add(lblContrasena);
            panelPassword.Location = new Point(121, 292);
            panelPassword.Name = "panelPassword";
            panelPassword.Size = new Size(346, 90);
            panelPassword.TabIndex = 1;
            // 
            // pictureBoxPass
            // 
            pictureBoxPass.Cursor = Cursors.Hand;
            pictureBoxPass.Image = Properties.Resources.visible__1_;
            pictureBoxPass.Location = new Point(269, 42);
            pictureBoxPass.Name = "pictureBoxPass";
            pictureBoxPass.Size = new Size(31, 31);
            pictureBoxPass.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxPass.TabIndex = 2;
            pictureBoxPass.TabStop = false;
            pictureBoxPass.MouseDown += pictureBoxPass_MouseDown;
            pictureBoxPass.MouseUp += pictureBoxPass_MouseUp;
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
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(49, 49);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(279, 24);
            txtPassword.TabIndex = 1;
            txtPassword.Text = "*********";
            txtPassword.TextChanged += txtPassword_TextChanged;
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
            txtUsuario.Click += txtUsuario_Click;
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
            // pictureBox5
            // 
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Image = Properties.Resources.close;
            pictureBox5.Location = new Point(1190, 40);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(43, 39);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 2;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(217, 226, 243);
            ClientSize = new Size(1281, 869);
            Controls.Add(pictureBox5);
            Controls.Add(panelLogin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
            MouseDown += LoginForm_MouseDown;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panelPassword.ResumeLayout(false);
            panelPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelUsuario.ResumeLayout(false);
            panelUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLogin;
        private Panel panelUsuario;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private PictureBox pictureBox1;
        private Panel panelPassword;
        private PictureBox pictureBox2;
        private TextBox txtPassword;
        private Label lblContrasena;
        private PictureBox pictureBoxPass;
        private Button btnLogin;
        private Label lblRegistrar;
        private PictureBox pictureBox4;
        private Label label1;
        private PictureBox pictureBox5;
        private Label labelOlvidada;
    }
}
