namespace SheetMusicManager
{
    partial class ForgotPasswordForm
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
            btnRecuperar = new Button();
            pictureBox4 = new PictureBox();
            panelForgot = new Panel();
            panelCorreo = new Panel();
            pictureBox1 = new PictureBox();
            txtCorreo = new TextBox();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panelForgot.SuspendLayout();
            panelCorreo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox5
            // 
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Image = Properties.Resources.close;
            pictureBox5.Location = new Point(1132, 38);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(43, 39);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 3;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // btnRecuperar
            // 
            btnRecuperar.BackColor = Color.FromArgb(61, 76, 158);
            btnRecuperar.FlatStyle = FlatStyle.Flat;
            btnRecuperar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRecuperar.ForeColor = SystemColors.Control;
            btnRecuperar.Location = new Point(119, 423);
            btnRecuperar.Name = "btnRecuperar";
            btnRecuperar.Size = new Size(671, 56);
            btnRecuperar.TabIndex = 2;
            btnRecuperar.Text = "Recuperar contraseña";
            btnRecuperar.UseVisualStyleBackColor = false;
            btnRecuperar.Click += btnRecuperar_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.logo;
            pictureBox4.Location = new Point(315, -39);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(259, 201);
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // panelForgot
            // 
            panelForgot.BackColor = Color.Azure;
            panelForgot.Controls.Add(panelCorreo);
            panelForgot.Controls.Add(label2);
            panelForgot.Controls.Add(pictureBox4);
            panelForgot.Controls.Add(btnRecuperar);
            panelForgot.Location = new Point(150, 130);
            panelForgot.Name = "panelForgot";
            panelForgot.Size = new Size(915, 541);
            panelForgot.TabIndex = 4;
            // 
            // panelCorreo
            // 
            panelCorreo.BackColor = Color.White;
            panelCorreo.Controls.Add(pictureBox1);
            panelCorreo.Controls.Add(txtCorreo);
            panelCorreo.Controls.Add(label3);
            panelCorreo.Location = new Point(121, 292);
            panelCorreo.Name = "panelCorreo";
            panelCorreo.Size = new Size(669, 90);
            panelCorreo.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.email;
            pictureBox1.Location = new Point(12, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(31, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txtCorreo
            // 
            txtCorreo.BorderStyle = BorderStyle.None;
            txtCorreo.ForeColor = Color.Black;
            txtCorreo.Location = new Point(49, 45);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(600, 24);
            txtCorreo.TabIndex = 1;
            txtCorreo.Text = "Correo Electrónico";
            txtCorreo.Click += txtCorreo_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 11);
            label3.Name = "label3";
            label3.Size = new Size(75, 28);
            label3.TabIndex = 0;
            label3.Text = "Correo";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(119, 208);
            label2.MinimumSize = new Size(200, 0);
            label2.Name = "label2";
            label2.Size = new Size(671, 62);
            label2.TabIndex = 3;
            label2.Text = "Por favor, introduce tu correo electrónico. Recibirás un código de verificación para crear una nueva contraseña si este es válido.";
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(217, 226, 243);
            ClientSize = new Size(1217, 798);
            Controls.Add(panelForgot);
            Controls.Add(pictureBox5);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ForgotPasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ForgotPasswordForm";
            Load += ForgotPasswordForm_Load;
            MouseDown += ForgotPasswordForm_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panelForgot.ResumeLayout(false);
            panelCorreo.ResumeLayout(false);
            panelCorreo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox5;
        private Button btnRecuperar;
        private PictureBox pictureBox4;
        private Panel panelForgot;
        private Label label2;
        private Panel panelCorreo;
        private PictureBox pictureBox1;
        private TextBox txtCorreo;
        private Label label3;
    }
}