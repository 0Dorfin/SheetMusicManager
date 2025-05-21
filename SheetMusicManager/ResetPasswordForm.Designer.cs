namespace SheetMusicManager
{
    partial class ResetPasswordForm
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
            pictureBox5 = new PictureBox();
            panelReset = new Panel();
            lblFuerza = new Label();
            label3 = new Label();
            lblCoincidencia = new Label();
            label1 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            txtNuevaContrasena = new TextBox();
            label2 = new Label();
            pictureBox4 = new PictureBox();
            btnGuardar = new Button();
            panelPassword = new Panel();
            pictureBoxPass = new PictureBox();
            pictureBox2 = new PictureBox();
            txtConfirmarContrasena = new TextBox();
            lblContrasena = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panelReset.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panelPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox5
            // 
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Image = Properties.Resources.close;
            pictureBox5.Location = new Point(1190, 40);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(43, 39);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 4;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // panelReset
            // 
            panelReset.BackColor = Color.Azure;
            panelReset.Controls.Add(lblFuerza);
            panelReset.Controls.Add(label3);
            panelReset.Controls.Add(lblCoincidencia);
            panelReset.Controls.Add(label1);
            panelReset.Controls.Add(panel1);
            panelReset.Controls.Add(pictureBox4);
            panelReset.Controls.Add(btnGuardar);
            panelReset.Controls.Add(panelPassword);
            panelReset.Location = new Point(349, 100);
            panelReset.Name = "panelReset";
            panelReset.Size = new Size(624, 687);
            panelReset.TabIndex = 3;
            // 
            // lblFuerza
            // 
            lblFuerza.AutoSize = true;
            lblFuerza.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFuerza.Location = new Point(355, 275);
            lblFuerza.Name = "lblFuerza";
            lblFuerza.Size = new Size(132, 28);
            lblFuerza.TabIndex = 11;
            lblFuerza.Text = "Débil/Fuerte";
            lblFuerza.Visible = false;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(119, 312);
            label3.Name = "label3";
            label3.Size = new Size(385, 87);
            label3.TabIndex = 10;
            label3.Text = "La contraseña debe tener al menos 8 caracteres, incluir una letra mayúscula, una minúscula, un número y un símbolo.";
            // 
            // lblCoincidencia
            // 
            lblCoincidencia.AutoSize = true;
            lblCoincidencia.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCoincidencia.Location = new Point(119, 522);
            lblCoincidencia.Name = "lblCoincidencia";
            lblCoincidencia.Size = new Size(251, 28);
            lblCoincidencia.TabIndex = 9;
            lblCoincidencia.Text = "Coinciden / No coinciden";
            lblCoincidencia.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(119, 275);
            label1.Name = "label1";
            label1.Size = new Size(241, 28);
            label1.TabIndex = 3;
            label1.Text = "Fuerza de la contraseña:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(txtNuevaContrasena);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(119, 168);
            panel1.Name = "panel1";
            panel1.Size = new Size(385, 90);
            panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.visible__1_;
            pictureBox1.Location = new Point(325, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(31, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.password2__1_;
            pictureBox3.Location = new Point(12, 42);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(31, 31);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // txtNuevaContrasena
            // 
            txtNuevaContrasena.BorderStyle = BorderStyle.None;
            txtNuevaContrasena.ForeColor = Color.Black;
            txtNuevaContrasena.Location = new Point(49, 49);
            txtNuevaContrasena.Name = "txtNuevaContrasena";
            txtNuevaContrasena.Size = new Size(250, 24);
            txtNuevaContrasena.TabIndex = 1;
            txtNuevaContrasena.Text = "*********";
            txtNuevaContrasena.Click += txtNuevaContrasena_Click;
            txtNuevaContrasena.TextChanged += txtNuevaContrasena_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 11);
            label2.Name = "label2";
            label2.Size = new Size(183, 28);
            label2.TabIndex = 0;
            label2.Text = "Nueva contraseña";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.logo;
            pictureBox4.Location = new Point(185, -39);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(259, 201);
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(61, 76, 158);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.Control;
            btnGuardar.Location = new Point(119, 580);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(385, 56);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar contraseña";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // panelPassword
            // 
            panelPassword.BackColor = Color.White;
            panelPassword.Controls.Add(pictureBoxPass);
            panelPassword.Controls.Add(pictureBox2);
            panelPassword.Controls.Add(txtConfirmarContrasena);
            panelPassword.Controls.Add(lblContrasena);
            panelPassword.Location = new Point(119, 420);
            panelPassword.Name = "panelPassword";
            panelPassword.Size = new Size(385, 90);
            panelPassword.TabIndex = 1;
            // 
            // pictureBoxPass
            // 
            pictureBoxPass.Cursor = Cursors.Hand;
            pictureBoxPass.Image = Properties.Resources.visible__1_;
            pictureBoxPass.Location = new Point(325, 42);
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
            // txtConfirmarContrasena
            // 
            txtConfirmarContrasena.BorderStyle = BorderStyle.None;
            txtConfirmarContrasena.ForeColor = Color.Black;
            txtConfirmarContrasena.Location = new Point(49, 49);
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            txtConfirmarContrasena.Size = new Size(250, 24);
            txtConfirmarContrasena.TabIndex = 1;
            txtConfirmarContrasena.Text = "*********";
            txtConfirmarContrasena.Click += txtConfirmarContrasena_Click;
            txtConfirmarContrasena.TextChanged += txtConfirmarContrasena_TextChanged;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContrasena.Location = new Point(12, 11);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(232, 28);
            lblContrasena.TabIndex = 0;
            lblContrasena.Text = "Confirma la contraseña";
            // 
            // ResetPasswordForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(217, 226, 243);
            ClientSize = new Size(1281, 869);
            Controls.Add(pictureBox5);
            Controls.Add(panelReset);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ResetPasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ResetPasswordForm";
            Load += ResetPasswordForm_Load;
            MouseDown += ResetPasswordForm_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panelReset.ResumeLayout(false);
            panelReset.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panelPassword.ResumeLayout(false);
            panelPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox5;
        private Panel panelReset;
        private PictureBox pictureBox4;
        private Button btnGuardar;
        private Panel panelPassword;
        private PictureBox pictureBoxPass;
        private PictureBox pictureBox2;
        private TextBox txtConfirmarContrasena;
        private Label lblContrasena;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private TextBox txtNuevaContrasena;
        private Label label2;
        private Label label3;
        private Label lblCoincidencia;
        private Label label1;
        private Label lblFuerza;
    }
}