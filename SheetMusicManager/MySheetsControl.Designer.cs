namespace SheetMusicManager
{
    public partial class MySheetsControl : UserControl
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
            flowPartiturasPanel = new FlowLayoutPanel();
            filaPartitura = new Panel();
            txtAgrupacion = new Label();
            btnDescargar = new PictureBox();
            txtCompositor = new Label();
            btnVer = new PictureBox();
            btnEliminar = new PictureBox();
            txtFecha = new Label();
            txtEpoca = new Label();
            txtInstrumentos = new Label();
            txtPartitura = new Label();
            filaPartirua = new Panel();
            label9 = new Label();
            label10 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panelOpciones = new Panel();
            panelFilters = new Panel();
            linkXCoro = new LinkLabel();
            linkLabelCoro = new LinkLabel();
            linkXOrquesta = new LinkLabel();
            linkLabelOrquesta = new LinkLabel();
            linkXCamara = new LinkLabel();
            linkLabelCamara = new LinkLabel();
            linkXSolo = new LinkLabel();
            linkLabelSolo = new LinkLabel();
            labelAgrupacion = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel7 = new Panel();
            labelTeclado = new Label();
            down1 = new PictureBox();
            right1 = new PictureBox();
            panelTeclado = new Panel();
            linkLabelOrgano = new LinkLabel();
            linkXOrgano = new LinkLabel();
            linkLabelClave = new LinkLabel();
            linkXClave = new LinkLabel();
            linkLabelPiano = new LinkLabel();
            linkXPiano = new LinkLabel();
            panel5 = new Panel();
            labelCuerda = new Label();
            down2 = new PictureBox();
            right2 = new PictureBox();
            panelCuerda = new Panel();
            linkLabelContrabajo = new LinkLabel();
            linkXContrabajo = new LinkLabel();
            linkLabelViolin = new LinkLabel();
            linkXViolin = new LinkLabel();
            linkLabelViola = new LinkLabel();
            linkXViola = new LinkLabel();
            linkLabelCello = new LinkLabel();
            linkXCello = new LinkLabel();
            panel8 = new Panel();
            labelVientoMa = new Label();
            down3 = new PictureBox();
            right3 = new PictureBox();
            panelVientoMa = new Panel();
            linkXFagot = new LinkLabel();
            linkLabelClarinete = new LinkLabel();
            linkXOboe = new LinkLabel();
            linkLabelOboe = new LinkLabel();
            linkLabelFagot = new LinkLabel();
            linkXClarinete = new LinkLabel();
            panel9 = new Panel();
            labelVientoMe = new Label();
            down4 = new PictureBox();
            right4 = new PictureBox();
            panelVientoMe = new Panel();
            linkXTrompa = new LinkLabel();
            linkLabelTrompa = new LinkLabel();
            linkXTrombon = new LinkLabel();
            linkLabelTrompeta = new LinkLabel();
            linkLabelFlauta = new LinkLabel();
            linkXFlauta = new LinkLabel();
            linkLabelTrombon = new LinkLabel();
            linkXTrompeta = new LinkLabel();
            panel6 = new Panel();
            labelVoz = new Label();
            down5 = new PictureBox();
            right5 = new PictureBox();
            panelVoz = new Panel();
            linkLabelBajo = new LinkLabel();
            linkXBajo = new LinkLabel();
            linkLabelSoprano = new LinkLabel();
            linkXSoprano = new LinkLabel();
            linkLabelMezzo = new LinkLabel();
            linkXMezzo = new LinkLabel();
            linkLabelTenor = new LinkLabel();
            linkXTenor = new LinkLabel();
            panel10 = new Panel();
            labelPercusion = new Label();
            down6 = new PictureBox();
            right6 = new PictureBox();
            panelPercusion = new Panel();
            linkLabelTimbales = new LinkLabel();
            linkXTimbales = new LinkLabel();
            linkXRomanticismo = new LinkLabel();
            linkLabelRoman = new LinkLabel();
            linkXClasicismo = new LinkLabel();
            linkLabelClas = new LinkLabel();
            linkXBarroco = new LinkLabel();
            linkLabelBarroco = new LinkLabel();
            labelInstrtumento = new Label();
            labelEpoca = new Label();
            lblPartituras = new Label();
            panelBuscar = new Panel();
            textBoxMisPartituras = new TextBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            flowPartiturasPanel.SuspendLayout();
            filaPartitura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnDescargar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnVer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEliminar).BeginInit();
            filaPartirua.SuspendLayout();
            panelOpciones.SuspendLayout();
            panelFilters.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)down1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)right1).BeginInit();
            panelTeclado.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)down2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)right2).BeginInit();
            panelCuerda.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)down3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)right3).BeginInit();
            panelVientoMa.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)down4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)right4).BeginInit();
            panelVientoMe.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)down5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)right5).BeginInit();
            panelVoz.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)down6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)right6).BeginInit();
            panelPercusion.SuspendLayout();
            panelBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // flowPartiturasPanel
            // 
            flowPartiturasPanel.BorderStyle = BorderStyle.FixedSingle;
            flowPartiturasPanel.Controls.Add(filaPartitura);
            flowPartiturasPanel.Location = new Point(337, 387);
            flowPartiturasPanel.Name = "flowPartiturasPanel";
            flowPartiturasPanel.Size = new Size(1410, 568);
            flowPartiturasPanel.TabIndex = 0;
            // 
            // filaPartitura
            // 
            filaPartitura.Controls.Add(txtAgrupacion);
            filaPartitura.Controls.Add(btnDescargar);
            filaPartitura.Controls.Add(txtCompositor);
            filaPartitura.Controls.Add(btnVer);
            filaPartitura.Controls.Add(btnEliminar);
            filaPartitura.Controls.Add(txtFecha);
            filaPartitura.Controls.Add(txtEpoca);
            filaPartitura.Controls.Add(txtInstrumentos);
            filaPartitura.Controls.Add(txtPartitura);
            filaPartitura.Location = new Point(2, 2);
            filaPartitura.Margin = new Padding(2);
            filaPartitura.Name = "filaPartitura";
            filaPartitura.Size = new Size(1418, 79);
            filaPartitura.TabIndex = 0;
            // 
            // txtAgrupacion
            // 
            txtAgrupacion.AutoSize = true;
            txtAgrupacion.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAgrupacion.Location = new Point(541, 21);
            txtAgrupacion.Margin = new Padding(2, 0, 2, 0);
            txtAgrupacion.MaximumSize = new Size(200, 0);
            txtAgrupacion.Name = "txtAgrupacion";
            txtAgrupacion.Size = new Size(114, 28);
            txtAgrupacion.TabIndex = 10;
            txtAgrupacion.Text = "Agrupación";
            // 
            // btnDescargar
            // 
            btnDescargar.Image = Properties.Resources.download_pdf;
            btnDescargar.Location = new Point(1231, 19);
            btnDescargar.Margin = new Padding(2);
            btnDescargar.Name = "btnDescargar";
            btnDescargar.Size = new Size(47, 40);
            btnDescargar.SizeMode = PictureBoxSizeMode.StretchImage;
            btnDescargar.TabIndex = 9;
            btnDescargar.TabStop = false;
            // 
            // txtCompositor
            // 
            txtCompositor.AutoSize = true;
            txtCompositor.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCompositor.Location = new Point(209, 21);
            txtCompositor.Margin = new Padding(2, 0, 2, 0);
            txtCompositor.Name = "txtCompositor";
            txtCompositor.Size = new Size(116, 28);
            txtCompositor.TabIndex = 8;
            txtCompositor.Text = "Compositor";
            // 
            // btnVer
            // 
            btnVer.Image = Properties.Resources.preview;
            btnVer.Location = new Point(1123, 21);
            btnVer.Margin = new Padding(2);
            btnVer.Name = "btnVer";
            btnVer.Size = new Size(40, 36);
            btnVer.SizeMode = PictureBoxSizeMode.StretchImage;
            btnVer.TabIndex = 5;
            btnVer.TabStop = false;
            // 
            // btnEliminar
            // 
            btnEliminar.Image = Properties.Resources.delete1;
            btnEliminar.Location = new Point(1337, 21);
            btnEliminar.Margin = new Padding(2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(40, 38);
            btnEliminar.SizeMode = PictureBoxSizeMode.StretchImage;
            btnEliminar.TabIndex = 4;
            btnEliminar.TabStop = false;
            // 
            // txtFecha
            // 
            txtFecha.AutoSize = true;
            txtFecha.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFecha.Location = new Point(930, 21);
            txtFecha.Margin = new Padding(2, 0, 2, 0);
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(125, 28);
            txtFecha.TabIndex = 4;
            txtFecha.Text = "Fecha subida";
            // 
            // txtEpoca
            // 
            txtEpoca.AutoSize = true;
            txtEpoca.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEpoca.Location = new Point(390, 19);
            txtEpoca.Margin = new Padding(2, 0, 2, 0);
            txtEpoca.MaximumSize = new Size(200, 0);
            txtEpoca.Name = "txtEpoca";
            txtEpoca.Size = new Size(65, 28);
            txtEpoca.TabIndex = 2;
            txtEpoca.Text = "Época";
            // 
            // txtInstrumentos
            // 
            txtInstrumentos.AutoSize = true;
            txtInstrumentos.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtInstrumentos.Location = new Point(706, 21);
            txtInstrumentos.Margin = new Padding(2, 0, 2, 0);
            txtInstrumentos.Name = "txtInstrumentos";
            txtInstrumentos.Size = new Size(126, 28);
            txtInstrumentos.TabIndex = 1;
            txtInstrumentos.Text = "Instrumentos";
            // 
            // txtPartitura
            // 
            txtPartitura.AutoSize = true;
            txtPartitura.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPartitura.Location = new Point(40, 21);
            txtPartitura.Margin = new Padding(2, 0, 2, 0);
            txtPartitura.Name = "txtPartitura";
            txtPartitura.Size = new Size(85, 28);
            txtPartitura.TabIndex = 0;
            txtPartitura.Text = "Nombre";
            // 
            // filaPartirua
            // 
            filaPartirua.Controls.Add(label9);
            filaPartirua.Controls.Add(label10);
            filaPartirua.Controls.Add(label8);
            filaPartirua.Controls.Add(label7);
            filaPartirua.Controls.Add(label6);
            filaPartirua.Controls.Add(label2);
            filaPartirua.Controls.Add(label3);
            filaPartirua.Controls.Add(label4);
            filaPartirua.Controls.Add(label5);
            filaPartirua.Location = new Point(339, 301);
            filaPartirua.Margin = new Padding(2);
            filaPartirua.Name = "filaPartirua";
            filaPartirua.Size = new Size(1408, 70);
            filaPartirua.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(542, 21);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(114, 28);
            label9.TabIndex = 9;
            label9.Text = "Agrupación";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(1206, 21);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(99, 28);
            label10.TabIndex = 8;
            label10.Text = "Descargar";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(210, 21);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(116, 28);
            label8.TabIndex = 7;
            label8.Text = "Compositor";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(1323, 21);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(66, 28);
            label7.TabIndex = 6;
            label7.Text = "Borrar";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(1125, 21);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(40, 28);
            label6.TabIndex = 5;
            label6.Text = "Ver";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(931, 21);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(125, 28);
            label2.TabIndex = 4;
            label2.Text = "Fecha subida";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(390, 21);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(65, 28);
            label3.TabIndex = 2;
            label3.Text = "Época";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(707, 21);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(126, 28);
            label4.TabIndex = 1;
            label4.Text = "Instrumentos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(41, 21);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(85, 28);
            label5.TabIndex = 0;
            label5.Text = "Nombre";
            // 
            // panelOpciones
            // 
            panelOpciones.Controls.Add(panelFilters);
            panelOpciones.Dock = DockStyle.Left;
            panelOpciones.Location = new Point(0, 0);
            panelOpciones.Name = "panelOpciones";
            panelOpciones.Size = new Size(300, 1606);
            panelOpciones.TabIndex = 1;
            // 
            // panelFilters
            // 
            panelFilters.Controls.Add(linkXCoro);
            panelFilters.Controls.Add(linkLabelCoro);
            panelFilters.Controls.Add(linkXOrquesta);
            panelFilters.Controls.Add(linkLabelOrquesta);
            panelFilters.Controls.Add(linkXCamara);
            panelFilters.Controls.Add(linkLabelCamara);
            panelFilters.Controls.Add(linkXSolo);
            panelFilters.Controls.Add(linkLabelSolo);
            panelFilters.Controls.Add(labelAgrupacion);
            panelFilters.Controls.Add(flowLayoutPanel1);
            panelFilters.Controls.Add(linkXRomanticismo);
            panelFilters.Controls.Add(linkLabelRoman);
            panelFilters.Controls.Add(linkXClasicismo);
            panelFilters.Controls.Add(linkLabelClas);
            panelFilters.Controls.Add(linkXBarroco);
            panelFilters.Controls.Add(linkLabelBarroco);
            panelFilters.Controls.Add(labelInstrtumento);
            panelFilters.Controls.Add(labelEpoca);
            panelFilters.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelFilters.Location = new Point(16, 224);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(260, 1400);
            panelFilters.TabIndex = 0;
            // 
            // linkXCoro
            // 
            linkXCoro.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXCoro.AutoSize = true;
            linkXCoro.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXCoro.ForeColor = Color.FromArgb(61, 76, 158);
            linkXCoro.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXCoro.LinkColor = Color.FromArgb(61, 76, 158);
            linkXCoro.Location = new Point(100, 380);
            linkXCoro.Margin = new Padding(2, 0, 2, 0);
            linkXCoro.Name = "linkXCoro";
            linkXCoro.Size = new Size(30, 32);
            linkXCoro.TabIndex = 23;
            linkXCoro.TabStop = true;
            linkXCoro.Text = "×";
            linkXCoro.Visible = false;
            linkXCoro.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelCoro
            // 
            linkLabelCoro.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelCoro.AutoSize = true;
            linkLabelCoro.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelCoro.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelCoro.LinkColor = Color.Black;
            linkLabelCoro.Location = new Point(52, 383);
            linkLabelCoro.Margin = new Padding(2, 0, 2, 0);
            linkLabelCoro.Name = "linkLabelCoro";
            linkLabelCoro.Size = new Size(55, 28);
            linkLabelCoro.TabIndex = 22;
            linkLabelCoro.TabStop = true;
            linkLabelCoro.Text = "Coro";
            linkLabelCoro.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXOrquesta
            // 
            linkXOrquesta.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXOrquesta.AutoSize = true;
            linkXOrquesta.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXOrquesta.ForeColor = Color.FromArgb(61, 76, 158);
            linkXOrquesta.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXOrquesta.LinkColor = Color.FromArgb(61, 76, 158);
            linkXOrquesta.Location = new Point(142, 338);
            linkXOrquesta.Margin = new Padding(2, 0, 2, 0);
            linkXOrquesta.Name = "linkXOrquesta";
            linkXOrquesta.Size = new Size(30, 32);
            linkXOrquesta.TabIndex = 21;
            linkXOrquesta.TabStop = true;
            linkXOrquesta.Text = "×";
            linkXOrquesta.Visible = false;
            linkXOrquesta.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelOrquesta
            // 
            linkLabelOrquesta.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelOrquesta.AutoSize = true;
            linkLabelOrquesta.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelOrquesta.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelOrquesta.LinkColor = Color.Black;
            linkLabelOrquesta.Location = new Point(52, 342);
            linkLabelOrquesta.Margin = new Padding(2, 0, 2, 0);
            linkLabelOrquesta.Name = "linkLabelOrquesta";
            linkLabelOrquesta.Size = new Size(92, 28);
            linkLabelOrquesta.TabIndex = 20;
            linkLabelOrquesta.TabStop = true;
            linkLabelOrquesta.Text = "Orquesta";
            linkLabelOrquesta.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXCamara
            // 
            linkXCamara.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXCamara.AutoSize = true;
            linkXCamara.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXCamara.ForeColor = Color.FromArgb(61, 76, 158);
            linkXCamara.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXCamara.LinkColor = Color.FromArgb(61, 76, 158);
            linkXCamara.Location = new Point(128, 297);
            linkXCamara.Margin = new Padding(2, 0, 2, 0);
            linkXCamara.Name = "linkXCamara";
            linkXCamara.Size = new Size(30, 32);
            linkXCamara.TabIndex = 19;
            linkXCamara.TabStop = true;
            linkXCamara.Text = "×";
            linkXCamara.Visible = false;
            linkXCamara.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelCamara
            // 
            linkLabelCamara.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelCamara.AutoSize = true;
            linkLabelCamara.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelCamara.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelCamara.LinkColor = Color.Black;
            linkLabelCamara.Location = new Point(52, 300);
            linkLabelCamara.Margin = new Padding(2, 0, 2, 0);
            linkLabelCamara.Name = "linkLabelCamara";
            linkLabelCamara.Size = new Size(78, 28);
            linkLabelCamara.TabIndex = 18;
            linkLabelCamara.TabStop = true;
            linkLabelCamara.Text = "Cámara";
            linkLabelCamara.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXSolo
            // 
            linkXSolo.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXSolo.AutoSize = true;
            linkXSolo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXSolo.ForeColor = Color.FromArgb(61, 76, 158);
            linkXSolo.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXSolo.LinkColor = Color.FromArgb(61, 76, 158);
            linkXSolo.Location = new Point(100, 256);
            linkXSolo.Margin = new Padding(2, 0, 2, 0);
            linkXSolo.Name = "linkXSolo";
            linkXSolo.Size = new Size(30, 32);
            linkXSolo.TabIndex = 17;
            linkXSolo.TabStop = true;
            linkXSolo.Text = "×";
            linkXSolo.Visible = false;
            linkXSolo.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelSolo
            // 
            linkLabelSolo.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelSolo.AutoSize = true;
            linkLabelSolo.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelSolo.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelSolo.LinkColor = Color.Black;
            linkLabelSolo.Location = new Point(52, 258);
            linkLabelSolo.Margin = new Padding(2, 0, 2, 0);
            linkLabelSolo.Name = "linkLabelSolo";
            linkLabelSolo.Size = new Size(52, 28);
            linkLabelSolo.TabIndex = 16;
            linkLabelSolo.TabStop = true;
            linkLabelSolo.Text = "Solo";
            linkLabelSolo.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // labelAgrupacion
            // 
            labelAgrupacion.AutoSize = true;
            labelAgrupacion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAgrupacion.ForeColor = SystemColors.ControlDarkDark;
            labelAgrupacion.Location = new Point(22, 212);
            labelAgrupacion.Margin = new Padding(2, 0, 2, 0);
            labelAgrupacion.Name = "labelAgrupacion";
            labelAgrupacion.Size = new Size(136, 32);
            labelAgrupacion.TabIndex = 15;
            labelAgrupacion.Text = "Agrupación";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(panel7);
            flowLayoutPanel1.Controls.Add(panelTeclado);
            flowLayoutPanel1.Controls.Add(panel5);
            flowLayoutPanel1.Controls.Add(panelCuerda);
            flowLayoutPanel1.Controls.Add(panel8);
            flowLayoutPanel1.Controls.Add(panelVientoMa);
            flowLayoutPanel1.Controls.Add(panel9);
            flowLayoutPanel1.Controls.Add(panelVientoMe);
            flowLayoutPanel1.Controls.Add(panel6);
            flowLayoutPanel1.Controls.Add(panelVoz);
            flowLayoutPanel1.Controls.Add(panel10);
            flowLayoutPanel1.Controls.Add(panelPercusion);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(51, 468);
            flowLayoutPanel1.Margin = new Padding(2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(207, 895);
            flowLayoutPanel1.TabIndex = 6;
            flowLayoutPanel1.WrapContents = false;
            // 
            // panel7
            // 
            panel7.Controls.Add(labelTeclado);
            panel7.Controls.Add(down1);
            panel7.Controls.Add(right1);
            panel7.Location = new Point(3, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(171, 32);
            panel7.TabIndex = 34;
            // 
            // labelTeclado
            // 
            labelTeclado.AutoSize = true;
            labelTeclado.Cursor = Cursors.Hand;
            labelTeclado.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTeclado.Location = new Point(15, 0);
            labelTeclado.Margin = new Padding(0);
            labelTeclado.Name = "labelTeclado";
            labelTeclado.Size = new Size(78, 28);
            labelTeclado.TabIndex = 6;
            labelTeclado.Text = "Teclado";
            // 
            // down1
            // 
            down1.Image = Properties.Resources.down_arrow;
            down1.Location = new Point(2, 8);
            down1.Margin = new Padding(0);
            down1.Name = "down1";
            down1.Size = new Size(12, 12);
            down1.SizeMode = PictureBoxSizeMode.StretchImage;
            down1.TabIndex = 32;
            down1.TabStop = false;
            down1.Visible = false;
            // 
            // right1
            // 
            right1.Image = Properties.Resources.right_arrow;
            right1.Location = new Point(2, 8);
            right1.Margin = new Padding(2);
            right1.Name = "right1";
            right1.Size = new Size(12, 12);
            right1.SizeMode = PictureBoxSizeMode.StretchImage;
            right1.TabIndex = 6;
            right1.TabStop = false;
            // 
            // panelTeclado
            // 
            panelTeclado.AutoSize = true;
            panelTeclado.Controls.Add(linkLabelOrgano);
            panelTeclado.Controls.Add(linkXOrgano);
            panelTeclado.Controls.Add(linkLabelClave);
            panelTeclado.Controls.Add(linkXClave);
            panelTeclado.Controls.Add(linkLabelPiano);
            panelTeclado.Controls.Add(linkXPiano);
            panelTeclado.Location = new Point(21, 40);
            panelTeclado.Margin = new Padding(21, 2, 2, 2);
            panelTeclado.Name = "panelTeclado";
            panelTeclado.Size = new Size(115, 99);
            panelTeclado.TabIndex = 33;
            panelTeclado.Visible = false;
            // 
            // linkLabelOrgano
            // 
            linkLabelOrgano.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelOrgano.AutoSize = true;
            linkLabelOrgano.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelOrgano.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelOrgano.LinkColor = Color.Black;
            linkLabelOrgano.Location = new Point(10, 2);
            linkLabelOrgano.Margin = new Padding(2, 0, 2, 0);
            linkLabelOrgano.Name = "linkLabelOrgano";
            linkLabelOrgano.Size = new Size(79, 28);
            linkLabelOrgano.TabIndex = 17;
            linkLabelOrgano.TabStop = true;
            linkLabelOrgano.Text = "Órgano";
            linkLabelOrgano.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXOrgano
            // 
            linkXOrgano.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXOrgano.AutoSize = true;
            linkXOrgano.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXOrgano.ForeColor = Color.FromArgb(61, 76, 158);
            linkXOrgano.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXOrgano.LinkColor = Color.FromArgb(61, 76, 158);
            linkXOrgano.Location = new Point(83, 0);
            linkXOrgano.Margin = new Padding(2, 0, 2, 0);
            linkXOrgano.Name = "linkXOrgano";
            linkXOrgano.Size = new Size(30, 32);
            linkXOrgano.TabIndex = 18;
            linkXOrgano.TabStop = true;
            linkXOrgano.Text = "×";
            linkXOrgano.Visible = false;
            linkXOrgano.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelClave
            // 
            linkLabelClave.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelClave.AutoSize = true;
            linkLabelClave.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelClave.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelClave.LinkColor = Color.Black;
            linkLabelClave.Location = new Point(10, 35);
            linkLabelClave.Margin = new Padding(2, 0, 2, 0);
            linkLabelClave.Name = "linkLabelClave";
            linkLabelClave.Size = new Size(59, 28);
            linkLabelClave.TabIndex = 19;
            linkLabelClave.TabStop = true;
            linkLabelClave.Text = "Clave";
            linkLabelClave.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXClave
            // 
            linkXClave.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXClave.AutoSize = true;
            linkXClave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXClave.ForeColor = Color.FromArgb(61, 76, 158);
            linkXClave.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXClave.LinkColor = Color.FromArgb(61, 76, 158);
            linkXClave.Location = new Point(68, 33);
            linkXClave.Margin = new Padding(2, 0, 2, 0);
            linkXClave.Name = "linkXClave";
            linkXClave.Size = new Size(30, 32);
            linkXClave.TabIndex = 20;
            linkXClave.TabStop = true;
            linkXClave.Text = "×";
            linkXClave.Visible = false;
            linkXClave.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelPiano
            // 
            linkLabelPiano.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelPiano.AutoSize = true;
            linkLabelPiano.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelPiano.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelPiano.LinkColor = Color.Black;
            linkLabelPiano.Location = new Point(10, 68);
            linkLabelPiano.Margin = new Padding(2, 0, 2, 0);
            linkLabelPiano.Name = "linkLabelPiano";
            linkLabelPiano.Size = new Size(61, 28);
            linkLabelPiano.TabIndex = 21;
            linkLabelPiano.TabStop = true;
            linkLabelPiano.Text = "Piano";
            linkLabelPiano.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXPiano
            // 
            linkXPiano.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXPiano.AutoSize = true;
            linkXPiano.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXPiano.ForeColor = Color.FromArgb(61, 76, 158);
            linkXPiano.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXPiano.LinkColor = Color.FromArgb(61, 76, 158);
            linkXPiano.Location = new Point(63, 67);
            linkXPiano.Margin = new Padding(2, 0, 2, 0);
            linkXPiano.Name = "linkXPiano";
            linkXPiano.Size = new Size(30, 32);
            linkXPiano.TabIndex = 22;
            linkXPiano.TabStop = true;
            linkXPiano.Text = "×";
            linkXPiano.Visible = false;
            linkXPiano.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // panel5
            // 
            panel5.Controls.Add(labelCuerda);
            panel5.Controls.Add(down2);
            panel5.Controls.Add(right2);
            panel5.Location = new Point(3, 144);
            panel5.Name = "panel5";
            panel5.Size = new Size(171, 32);
            panel5.TabIndex = 1;
            // 
            // labelCuerda
            // 
            labelCuerda.AutoSize = true;
            labelCuerda.Cursor = Cursors.Hand;
            labelCuerda.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCuerda.Location = new Point(15, 0);
            labelCuerda.Margin = new Padding(0);
            labelCuerda.Name = "labelCuerda";
            labelCuerda.Size = new Size(74, 28);
            labelCuerda.TabIndex = 6;
            labelCuerda.Text = "Cuerda";
            // 
            // down2
            // 
            down2.Image = Properties.Resources.down_arrow;
            down2.Location = new Point(2, 8);
            down2.Margin = new Padding(0);
            down2.Name = "down2";
            down2.Size = new Size(12, 12);
            down2.SizeMode = PictureBoxSizeMode.StretchImage;
            down2.TabIndex = 32;
            down2.TabStop = false;
            down2.Visible = false;
            // 
            // right2
            // 
            right2.Image = Properties.Resources.right_arrow;
            right2.Location = new Point(2, 8);
            right2.Margin = new Padding(2);
            right2.Name = "right2";
            right2.Size = new Size(12, 12);
            right2.SizeMode = PictureBoxSizeMode.StretchImage;
            right2.TabIndex = 6;
            right2.TabStop = false;
            // 
            // panelCuerda
            // 
            panelCuerda.AutoSize = true;
            panelCuerda.Controls.Add(linkLabelContrabajo);
            panelCuerda.Controls.Add(linkXContrabajo);
            panelCuerda.Controls.Add(linkLabelViolin);
            panelCuerda.Controls.Add(linkXViolin);
            panelCuerda.Controls.Add(linkLabelViola);
            panelCuerda.Controls.Add(linkXViola);
            panelCuerda.Controls.Add(linkLabelCello);
            panelCuerda.Controls.Add(linkXCello);
            panelCuerda.Location = new Point(21, 181);
            panelCuerda.Margin = new Padding(21, 2, 2, 2);
            panelCuerda.Name = "panelCuerda";
            panelCuerda.Size = new Size(155, 132);
            panelCuerda.TabIndex = 38;
            panelCuerda.Visible = false;
            // 
            // linkLabelContrabajo
            // 
            linkLabelContrabajo.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelContrabajo.AutoSize = true;
            linkLabelContrabajo.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelContrabajo.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelContrabajo.LinkColor = Color.Black;
            linkLabelContrabajo.Location = new Point(10, 102);
            linkLabelContrabajo.Margin = new Padding(2, 0, 2, 0);
            linkLabelContrabajo.Name = "linkLabelContrabajo";
            linkLabelContrabajo.Size = new Size(110, 28);
            linkLabelContrabajo.TabIndex = 23;
            linkLabelContrabajo.TabStop = true;
            linkLabelContrabajo.Text = "Contrabajo";
            linkLabelContrabajo.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXContrabajo
            // 
            linkXContrabajo.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXContrabajo.AutoSize = true;
            linkXContrabajo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXContrabajo.ForeColor = Color.FromArgb(61, 76, 158);
            linkXContrabajo.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXContrabajo.LinkColor = Color.FromArgb(61, 76, 158);
            linkXContrabajo.Location = new Point(117, 100);
            linkXContrabajo.Margin = new Padding(2, 0, 2, 0);
            linkXContrabajo.Name = "linkXContrabajo";
            linkXContrabajo.Size = new Size(30, 32);
            linkXContrabajo.TabIndex = 24;
            linkXContrabajo.TabStop = true;
            linkXContrabajo.Text = "×";
            linkXContrabajo.Visible = false;
            linkXContrabajo.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelViolin
            // 
            linkLabelViolin.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelViolin.AutoSize = true;
            linkLabelViolin.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelViolin.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelViolin.LinkColor = Color.Black;
            linkLabelViolin.Location = new Point(10, 2);
            linkLabelViolin.Margin = new Padding(2, 0, 2, 0);
            linkLabelViolin.Name = "linkLabelViolin";
            linkLabelViolin.Size = new Size(62, 28);
            linkLabelViolin.TabIndex = 17;
            linkLabelViolin.TabStop = true;
            linkLabelViolin.Text = "Violín";
            linkLabelViolin.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXViolin
            // 
            linkXViolin.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXViolin.AutoSize = true;
            linkXViolin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXViolin.ForeColor = Color.FromArgb(61, 76, 158);
            linkXViolin.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXViolin.LinkColor = Color.FromArgb(61, 76, 158);
            linkXViolin.Location = new Point(65, 0);
            linkXViolin.Margin = new Padding(2, 0, 2, 0);
            linkXViolin.Name = "linkXViolin";
            linkXViolin.Size = new Size(30, 32);
            linkXViolin.TabIndex = 18;
            linkXViolin.TabStop = true;
            linkXViolin.Text = "×";
            linkXViolin.Visible = false;
            linkXViolin.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelViola
            // 
            linkLabelViola.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelViola.AutoSize = true;
            linkLabelViola.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelViola.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelViola.LinkColor = Color.Black;
            linkLabelViola.Location = new Point(10, 35);
            linkLabelViola.Margin = new Padding(2, 0, 2, 0);
            linkLabelViola.Name = "linkLabelViola";
            linkLabelViola.Size = new Size(56, 28);
            linkLabelViola.TabIndex = 19;
            linkLabelViola.TabStop = true;
            linkLabelViola.Text = "Viola";
            linkLabelViola.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXViola
            // 
            linkXViola.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXViola.AutoSize = true;
            linkXViola.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXViola.ForeColor = Color.FromArgb(61, 76, 158);
            linkXViola.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXViola.LinkColor = Color.FromArgb(61, 76, 158);
            linkXViola.Location = new Point(61, 33);
            linkXViola.Margin = new Padding(2, 0, 2, 0);
            linkXViola.Name = "linkXViola";
            linkXViola.Size = new Size(30, 32);
            linkXViola.TabIndex = 20;
            linkXViola.TabStop = true;
            linkXViola.Text = "×";
            linkXViola.Visible = false;
            linkXViola.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelCello
            // 
            linkLabelCello.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelCello.AutoSize = true;
            linkLabelCello.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelCello.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelCello.LinkColor = Color.Black;
            linkLabelCello.Location = new Point(10, 68);
            linkLabelCello.Margin = new Padding(2, 0, 2, 0);
            linkLabelCello.Name = "linkLabelCello";
            linkLabelCello.Size = new Size(116, 28);
            linkLabelCello.TabIndex = 21;
            linkLabelCello.TabStop = true;
            linkLabelCello.Text = "Violonchelo";
            linkLabelCello.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXCello
            // 
            linkXCello.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXCello.AutoSize = true;
            linkXCello.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXCello.ForeColor = Color.FromArgb(61, 76, 158);
            linkXCello.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXCello.LinkColor = Color.FromArgb(61, 76, 158);
            linkXCello.Location = new Point(123, 67);
            linkXCello.Margin = new Padding(2, 0, 2, 0);
            linkXCello.Name = "linkXCello";
            linkXCello.Size = new Size(30, 32);
            linkXCello.TabIndex = 22;
            linkXCello.TabStop = true;
            linkXCello.Text = "×";
            linkXCello.Visible = false;
            linkXCello.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // panel8
            // 
            panel8.Controls.Add(labelVientoMa);
            panel8.Controls.Add(down3);
            panel8.Controls.Add(right3);
            panel8.Location = new Point(3, 318);
            panel8.Name = "panel8";
            panel8.Size = new Size(171, 32);
            panel8.TabIndex = 34;
            // 
            // labelVientoMa
            // 
            labelVientoMa.AutoSize = true;
            labelVientoMa.Cursor = Cursors.Hand;
            labelVientoMa.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelVientoMa.Location = new Point(15, 0);
            labelVientoMa.Margin = new Padding(0);
            labelVientoMa.Name = "labelVientoMa";
            labelVientoMa.Size = new Size(140, 28);
            labelVientoMa.TabIndex = 6;
            labelVientoMa.Text = "Viento madera";
            // 
            // down3
            // 
            down3.Image = Properties.Resources.down_arrow;
            down3.Location = new Point(2, 8);
            down3.Margin = new Padding(0);
            down3.Name = "down3";
            down3.Size = new Size(12, 12);
            down3.SizeMode = PictureBoxSizeMode.StretchImage;
            down3.TabIndex = 32;
            down3.TabStop = false;
            down3.Visible = false;
            // 
            // right3
            // 
            right3.Image = Properties.Resources.right_arrow;
            right3.Location = new Point(2, 8);
            right3.Margin = new Padding(2);
            right3.Name = "right3";
            right3.Size = new Size(12, 12);
            right3.SizeMode = PictureBoxSizeMode.StretchImage;
            right3.TabIndex = 6;
            right3.TabStop = false;
            // 
            // panelVientoMa
            // 
            panelVientoMa.AutoSize = true;
            panelVientoMa.Controls.Add(linkXFagot);
            panelVientoMa.Controls.Add(linkLabelClarinete);
            panelVientoMa.Controls.Add(linkXOboe);
            panelVientoMa.Controls.Add(linkLabelOboe);
            panelVientoMa.Controls.Add(linkLabelFagot);
            panelVientoMa.Controls.Add(linkXClarinete);
            panelVientoMa.Location = new Point(21, 355);
            panelVientoMa.Margin = new Padding(21, 2, 2, 2);
            panelVientoMa.Name = "panelVientoMa";
            panelVientoMa.Size = new Size(126, 99);
            panelVientoMa.TabIndex = 34;
            panelVientoMa.Visible = false;
            // 
            // linkXFagot
            // 
            linkXFagot.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXFagot.AutoSize = true;
            linkXFagot.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXFagot.ForeColor = Color.FromArgb(61, 76, 158);
            linkXFagot.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXFagot.LinkColor = Color.FromArgb(61, 76, 158);
            linkXFagot.Location = new Point(67, 67);
            linkXFagot.Margin = new Padding(2, 0, 2, 0);
            linkXFagot.Name = "linkXFagot";
            linkXFagot.Size = new Size(30, 32);
            linkXFagot.TabIndex = 23;
            linkXFagot.TabStop = true;
            linkXFagot.Text = "×";
            linkXFagot.Visible = false;
            linkXFagot.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelClarinete
            // 
            linkLabelClarinete.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelClarinete.AutoSize = true;
            linkLabelClarinete.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelClarinete.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelClarinete.LinkColor = Color.Black;
            linkLabelClarinete.Location = new Point(10, 2);
            linkLabelClarinete.Margin = new Padding(2, 0, 2, 0);
            linkLabelClarinete.Name = "linkLabelClarinete";
            linkLabelClarinete.Size = new Size(89, 28);
            linkLabelClarinete.TabIndex = 17;
            linkLabelClarinete.TabStop = true;
            linkLabelClarinete.Text = "Clarinete";
            linkLabelClarinete.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXOboe
            // 
            linkXOboe.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXOboe.AutoSize = true;
            linkXOboe.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXOboe.ForeColor = Color.FromArgb(61, 76, 158);
            linkXOboe.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXOboe.LinkColor = Color.FromArgb(61, 76, 158);
            linkXOboe.Location = new Point(65, 33);
            linkXOboe.Margin = new Padding(2, 0, 2, 0);
            linkXOboe.Name = "linkXOboe";
            linkXOboe.Size = new Size(30, 32);
            linkXOboe.TabIndex = 18;
            linkXOboe.TabStop = true;
            linkXOboe.Text = "×";
            linkXOboe.Visible = false;
            linkXOboe.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelOboe
            // 
            linkLabelOboe.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelOboe.AutoSize = true;
            linkLabelOboe.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelOboe.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelOboe.LinkColor = Color.Black;
            linkLabelOboe.Location = new Point(10, 35);
            linkLabelOboe.Margin = new Padding(2, 0, 2, 0);
            linkLabelOboe.Name = "linkLabelOboe";
            linkLabelOboe.Size = new Size(61, 28);
            linkLabelOboe.TabIndex = 19;
            linkLabelOboe.TabStop = true;
            linkLabelOboe.Text = "Oboe";
            linkLabelOboe.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelFagot
            // 
            linkLabelFagot.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelFagot.AutoSize = true;
            linkLabelFagot.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelFagot.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelFagot.LinkColor = Color.Black;
            linkLabelFagot.Location = new Point(10, 68);
            linkLabelFagot.Margin = new Padding(2, 0, 2, 0);
            linkLabelFagot.Name = "linkLabelFagot";
            linkLabelFagot.Size = new Size(62, 28);
            linkLabelFagot.TabIndex = 21;
            linkLabelFagot.TabStop = true;
            linkLabelFagot.Text = "Fagot";
            linkLabelFagot.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXClarinete
            // 
            linkXClarinete.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXClarinete.AutoSize = true;
            linkXClarinete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXClarinete.ForeColor = Color.FromArgb(61, 76, 158);
            linkXClarinete.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXClarinete.LinkColor = Color.FromArgb(61, 76, 158);
            linkXClarinete.Location = new Point(94, 0);
            linkXClarinete.Margin = new Padding(2, 0, 2, 0);
            linkXClarinete.Name = "linkXClarinete";
            linkXClarinete.Size = new Size(30, 32);
            linkXClarinete.TabIndex = 22;
            linkXClarinete.TabStop = true;
            linkXClarinete.Text = "×";
            linkXClarinete.Visible = false;
            linkXClarinete.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // panel9
            // 
            panel9.Controls.Add(labelVientoMe);
            panel9.Controls.Add(down4);
            panel9.Controls.Add(right4);
            panel9.Location = new Point(3, 459);
            panel9.Name = "panel9";
            panel9.Size = new Size(171, 32);
            panel9.TabIndex = 35;
            // 
            // labelVientoMe
            // 
            labelVientoMe.AutoSize = true;
            labelVientoMe.Cursor = Cursors.Hand;
            labelVientoMe.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelVientoMe.Location = new Point(15, 0);
            labelVientoMe.Margin = new Padding(0);
            labelVientoMe.Name = "labelVientoMe";
            labelVientoMe.Size = new Size(123, 28);
            labelVientoMe.TabIndex = 6;
            labelVientoMe.Text = "Viento metal";
            // 
            // down4
            // 
            down4.Image = Properties.Resources.down_arrow;
            down4.Location = new Point(2, 8);
            down4.Margin = new Padding(0);
            down4.Name = "down4";
            down4.Size = new Size(12, 12);
            down4.SizeMode = PictureBoxSizeMode.StretchImage;
            down4.TabIndex = 32;
            down4.TabStop = false;
            down4.Visible = false;
            // 
            // right4
            // 
            right4.Image = Properties.Resources.right_arrow;
            right4.Location = new Point(2, 8);
            right4.Margin = new Padding(2);
            right4.Name = "right4";
            right4.Size = new Size(12, 12);
            right4.SizeMode = PictureBoxSizeMode.StretchImage;
            right4.TabIndex = 6;
            right4.TabStop = false;
            // 
            // panelVientoMe
            // 
            panelVientoMe.AutoSize = true;
            panelVientoMe.Controls.Add(linkXTrompa);
            panelVientoMe.Controls.Add(linkLabelTrompa);
            panelVientoMe.Controls.Add(linkXTrombon);
            panelVientoMe.Controls.Add(linkLabelTrompeta);
            panelVientoMe.Controls.Add(linkLabelFlauta);
            panelVientoMe.Controls.Add(linkXFlauta);
            panelVientoMe.Controls.Add(linkLabelTrombon);
            panelVientoMe.Controls.Add(linkXTrompeta);
            panelVientoMe.Location = new Point(21, 496);
            panelVientoMe.Margin = new Padding(21, 2, 2, 2);
            panelVientoMe.Name = "panelVientoMe";
            panelVientoMe.Size = new Size(130, 132);
            panelVientoMe.TabIndex = 38;
            panelVientoMe.Visible = false;
            // 
            // linkXTrompa
            // 
            linkXTrompa.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXTrompa.AutoSize = true;
            linkXTrompa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXTrompa.ForeColor = Color.FromArgb(61, 76, 158);
            linkXTrompa.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXTrompa.LinkColor = Color.FromArgb(61, 76, 158);
            linkXTrompa.Location = new Point(88, 100);
            linkXTrompa.Margin = new Padding(2, 0, 2, 0);
            linkXTrompa.Name = "linkXTrompa";
            linkXTrompa.Size = new Size(30, 32);
            linkXTrompa.TabIndex = 25;
            linkXTrompa.TabStop = true;
            linkXTrompa.Text = "×";
            linkXTrompa.Visible = false;
            linkXTrompa.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelTrompa
            // 
            linkLabelTrompa.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelTrompa.AutoSize = true;
            linkLabelTrompa.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelTrompa.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelTrompa.LinkColor = Color.Black;
            linkLabelTrompa.Location = new Point(10, 102);
            linkLabelTrompa.Margin = new Padding(2, 0, 2, 0);
            linkLabelTrompa.Name = "linkLabelTrompa";
            linkLabelTrompa.Size = new Size(78, 28);
            linkLabelTrompa.TabIndex = 24;
            linkLabelTrompa.TabStop = true;
            linkLabelTrompa.Text = "Trompa";
            linkLabelTrompa.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXTrombon
            // 
            linkXTrombon.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXTrombon.AutoSize = true;
            linkXTrombon.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXTrombon.ForeColor = Color.FromArgb(61, 76, 158);
            linkXTrombon.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXTrombon.LinkColor = Color.FromArgb(61, 76, 158);
            linkXTrombon.Location = new Point(96, 67);
            linkXTrombon.Margin = new Padding(2, 0, 2, 0);
            linkXTrombon.Name = "linkXTrombon";
            linkXTrombon.Size = new Size(30, 32);
            linkXTrombon.TabIndex = 23;
            linkXTrombon.TabStop = true;
            linkXTrombon.Text = "×";
            linkXTrombon.Visible = false;
            linkXTrombon.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelTrompeta
            // 
            linkLabelTrompeta.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelTrompeta.AutoSize = true;
            linkLabelTrompeta.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelTrompeta.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelTrompeta.LinkColor = Color.Black;
            linkLabelTrompeta.Location = new Point(10, 2);
            linkLabelTrompeta.Margin = new Padding(2, 0, 2, 0);
            linkLabelTrompeta.Name = "linkLabelTrompeta";
            linkLabelTrompeta.Size = new Size(95, 28);
            linkLabelTrompeta.TabIndex = 17;
            linkLabelTrompeta.TabStop = true;
            linkLabelTrompeta.Text = "Trompeta";
            linkLabelTrompeta.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelFlauta
            // 
            linkLabelFlauta.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelFlauta.AutoSize = true;
            linkLabelFlauta.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelFlauta.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelFlauta.LinkColor = Color.Black;
            linkLabelFlauta.Location = new Point(10, 35);
            linkLabelFlauta.Margin = new Padding(2, 0, 2, 0);
            linkLabelFlauta.Name = "linkLabelFlauta";
            linkLabelFlauta.Size = new Size(65, 28);
            linkLabelFlauta.TabIndex = 19;
            linkLabelFlauta.TabStop = true;
            linkLabelFlauta.Text = "Flauta";
            linkLabelFlauta.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXFlauta
            // 
            linkXFlauta.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXFlauta.AutoSize = true;
            linkXFlauta.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXFlauta.ForeColor = Color.FromArgb(61, 76, 158);
            linkXFlauta.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXFlauta.LinkColor = Color.FromArgb(61, 76, 158);
            linkXFlauta.Location = new Point(67, 33);
            linkXFlauta.Margin = new Padding(2, 0, 2, 0);
            linkXFlauta.Name = "linkXFlauta";
            linkXFlauta.Size = new Size(30, 32);
            linkXFlauta.TabIndex = 20;
            linkXFlauta.TabStop = true;
            linkXFlauta.Text = "×";
            linkXFlauta.Visible = false;
            linkXFlauta.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelTrombon
            // 
            linkLabelTrombon.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelTrombon.AutoSize = true;
            linkLabelTrombon.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelTrombon.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelTrombon.LinkColor = Color.Black;
            linkLabelTrombon.Location = new Point(10, 68);
            linkLabelTrombon.Margin = new Padding(2, 0, 2, 0);
            linkLabelTrombon.Name = "linkLabelTrombon";
            linkLabelTrombon.Size = new Size(91, 28);
            linkLabelTrombon.TabIndex = 21;
            linkLabelTrombon.TabStop = true;
            linkLabelTrombon.Text = "Trombón";
            linkLabelTrombon.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXTrompeta
            // 
            linkXTrompeta.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXTrompeta.AutoSize = true;
            linkXTrompeta.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXTrompeta.ForeColor = Color.FromArgb(61, 76, 158);
            linkXTrompeta.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXTrompeta.LinkColor = Color.FromArgb(61, 76, 158);
            linkXTrompeta.Location = new Point(98, 0);
            linkXTrompeta.Margin = new Padding(2, 0, 2, 0);
            linkXTrompeta.Name = "linkXTrompeta";
            linkXTrompeta.Size = new Size(30, 32);
            linkXTrompeta.TabIndex = 22;
            linkXTrompeta.TabStop = true;
            linkXTrompeta.Text = "×";
            linkXTrompeta.Visible = false;
            linkXTrompeta.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // panel6
            // 
            panel6.Controls.Add(labelVoz);
            panel6.Controls.Add(down5);
            panel6.Controls.Add(right5);
            panel6.Location = new Point(3, 633);
            panel6.Name = "panel6";
            panel6.Size = new Size(171, 32);
            panel6.TabIndex = 33;
            // 
            // labelVoz
            // 
            labelVoz.AutoSize = true;
            labelVoz.Cursor = Cursors.Hand;
            labelVoz.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelVoz.Location = new Point(15, 0);
            labelVoz.Margin = new Padding(0);
            labelVoz.Name = "labelVoz";
            labelVoz.Size = new Size(44, 28);
            labelVoz.TabIndex = 6;
            labelVoz.Text = "Voz";
            // 
            // down5
            // 
            down5.Image = Properties.Resources.down_arrow;
            down5.Location = new Point(2, 8);
            down5.Margin = new Padding(0);
            down5.Name = "down5";
            down5.Size = new Size(12, 12);
            down5.SizeMode = PictureBoxSizeMode.StretchImage;
            down5.TabIndex = 32;
            down5.TabStop = false;
            down5.Visible = false;
            // 
            // right5
            // 
            right5.Image = Properties.Resources.right_arrow;
            right5.Location = new Point(2, 8);
            right5.Margin = new Padding(2);
            right5.Name = "right5";
            right5.Size = new Size(12, 12);
            right5.SizeMode = PictureBoxSizeMode.StretchImage;
            right5.TabIndex = 6;
            right5.TabStop = false;
            // 
            // panelVoz
            // 
            panelVoz.AutoSize = true;
            panelVoz.Controls.Add(linkLabelBajo);
            panelVoz.Controls.Add(linkXBajo);
            panelVoz.Controls.Add(linkLabelSoprano);
            panelVoz.Controls.Add(linkXSoprano);
            panelVoz.Controls.Add(linkLabelMezzo);
            panelVoz.Controls.Add(linkXMezzo);
            panelVoz.Controls.Add(linkLabelTenor);
            panelVoz.Controls.Add(linkXTenor);
            panelVoz.Location = new Point(21, 670);
            panelVoz.Margin = new Padding(21, 2, 2, 2);
            panelVoz.Name = "panelVoz";
            panelVoz.Size = new Size(125, 132);
            panelVoz.TabIndex = 36;
            panelVoz.Visible = false;
            // 
            // linkLabelBajo
            // 
            linkLabelBajo.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelBajo.AutoSize = true;
            linkLabelBajo.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelBajo.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelBajo.LinkColor = Color.Black;
            linkLabelBajo.Location = new Point(10, 102);
            linkLabelBajo.Margin = new Padding(2, 0, 2, 0);
            linkLabelBajo.Name = "linkLabelBajo";
            linkLabelBajo.Size = new Size(50, 28);
            linkLabelBajo.TabIndex = 23;
            linkLabelBajo.TabStop = true;
            linkLabelBajo.Text = "Bajo";
            linkLabelBajo.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXBajo
            // 
            linkXBajo.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXBajo.AutoSize = true;
            linkXBajo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXBajo.ForeColor = Color.FromArgb(61, 76, 158);
            linkXBajo.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXBajo.LinkColor = Color.FromArgb(61, 76, 158);
            linkXBajo.Location = new Point(50, 100);
            linkXBajo.Margin = new Padding(2, 0, 2, 0);
            linkXBajo.Name = "linkXBajo";
            linkXBajo.Size = new Size(30, 32);
            linkXBajo.TabIndex = 24;
            linkXBajo.TabStop = true;
            linkXBajo.Text = "×";
            linkXBajo.Visible = false;
            linkXBajo.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelSoprano
            // 
            linkLabelSoprano.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelSoprano.AutoSize = true;
            linkLabelSoprano.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelSoprano.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelSoprano.LinkColor = Color.Black;
            linkLabelSoprano.Location = new Point(12, 2);
            linkLabelSoprano.Margin = new Padding(2, 0, 2, 0);
            linkLabelSoprano.Name = "linkLabelSoprano";
            linkLabelSoprano.Size = new Size(87, 28);
            linkLabelSoprano.TabIndex = 17;
            linkLabelSoprano.TabStop = true;
            linkLabelSoprano.Text = "Soprano";
            linkLabelSoprano.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXSoprano
            // 
            linkXSoprano.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXSoprano.AutoSize = true;
            linkXSoprano.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXSoprano.ForeColor = Color.FromArgb(61, 76, 158);
            linkXSoprano.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXSoprano.LinkColor = Color.FromArgb(61, 76, 158);
            linkXSoprano.Location = new Point(93, 0);
            linkXSoprano.Margin = new Padding(2, 0, 2, 0);
            linkXSoprano.Name = "linkXSoprano";
            linkXSoprano.Size = new Size(30, 32);
            linkXSoprano.TabIndex = 18;
            linkXSoprano.TabStop = true;
            linkXSoprano.Text = "×";
            linkXSoprano.Visible = false;
            linkXSoprano.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelMezzo
            // 
            linkLabelMezzo.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelMezzo.AutoSize = true;
            linkLabelMezzo.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelMezzo.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelMezzo.LinkColor = Color.Black;
            linkLabelMezzo.Location = new Point(10, 35);
            linkLabelMezzo.Margin = new Padding(2, 0, 2, 0);
            linkLabelMezzo.Name = "linkLabelMezzo";
            linkLabelMezzo.Size = new Size(70, 28);
            linkLabelMezzo.TabIndex = 19;
            linkLabelMezzo.TabStop = true;
            linkLabelMezzo.Text = "Mezzo";
            linkLabelMezzo.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXMezzo
            // 
            linkXMezzo.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXMezzo.AutoSize = true;
            linkXMezzo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXMezzo.ForeColor = Color.FromArgb(61, 76, 158);
            linkXMezzo.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXMezzo.LinkColor = Color.FromArgb(61, 76, 158);
            linkXMezzo.Location = new Point(79, 33);
            linkXMezzo.Margin = new Padding(2, 0, 2, 0);
            linkXMezzo.Name = "linkXMezzo";
            linkXMezzo.Size = new Size(30, 32);
            linkXMezzo.TabIndex = 20;
            linkXMezzo.TabStop = true;
            linkXMezzo.Text = "×";
            linkXMezzo.Visible = false;
            linkXMezzo.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelTenor
            // 
            linkLabelTenor.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelTenor.AutoSize = true;
            linkLabelTenor.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelTenor.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelTenor.LinkColor = Color.Black;
            linkLabelTenor.Location = new Point(10, 68);
            linkLabelTenor.Margin = new Padding(2, 0, 2, 0);
            linkLabelTenor.Name = "linkLabelTenor";
            linkLabelTenor.Size = new Size(60, 28);
            linkLabelTenor.TabIndex = 21;
            linkLabelTenor.TabStop = true;
            linkLabelTenor.Text = "Tenor";
            linkLabelTenor.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXTenor
            // 
            linkXTenor.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXTenor.AutoSize = true;
            linkXTenor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXTenor.ForeColor = Color.FromArgb(61, 76, 158);
            linkXTenor.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXTenor.LinkColor = Color.FromArgb(61, 76, 158);
            linkXTenor.Location = new Point(67, 67);
            linkXTenor.Margin = new Padding(2, 0, 2, 0);
            linkXTenor.Name = "linkXTenor";
            linkXTenor.Size = new Size(30, 32);
            linkXTenor.TabIndex = 22;
            linkXTenor.TabStop = true;
            linkXTenor.Text = "×";
            linkXTenor.Visible = false;
            linkXTenor.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // panel10
            // 
            panel10.Controls.Add(labelPercusion);
            panel10.Controls.Add(down6);
            panel10.Controls.Add(right6);
            panel10.Location = new Point(3, 807);
            panel10.Name = "panel10";
            panel10.Size = new Size(171, 32);
            panel10.TabIndex = 37;
            // 
            // labelPercusion
            // 
            labelPercusion.AutoSize = true;
            labelPercusion.Cursor = Cursors.Hand;
            labelPercusion.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPercusion.Location = new Point(15, 0);
            labelPercusion.Margin = new Padding(0);
            labelPercusion.Name = "labelPercusion";
            labelPercusion.Size = new Size(95, 28);
            labelPercusion.TabIndex = 6;
            labelPercusion.Text = "Percusión";
            // 
            // down6
            // 
            down6.Image = Properties.Resources.down_arrow;
            down6.Location = new Point(3, 8);
            down6.Margin = new Padding(0);
            down6.Name = "down6";
            down6.Size = new Size(12, 12);
            down6.SizeMode = PictureBoxSizeMode.StretchImage;
            down6.TabIndex = 32;
            down6.TabStop = false;
            down6.Visible = false;
            // 
            // right6
            // 
            right6.Image = Properties.Resources.right_arrow;
            right6.Location = new Point(2, 8);
            right6.Margin = new Padding(2);
            right6.Name = "right6";
            right6.Size = new Size(12, 12);
            right6.SizeMode = PictureBoxSizeMode.StretchImage;
            right6.TabIndex = 6;
            right6.TabStop = false;
            // 
            // panelPercusion
            // 
            panelPercusion.AutoSize = true;
            panelPercusion.Controls.Add(linkLabelTimbales);
            panelPercusion.Controls.Add(linkXTimbales);
            panelPercusion.Location = new Point(21, 844);
            panelPercusion.Margin = new Padding(21, 2, 2, 2);
            panelPercusion.Name = "panelPercusion";
            panelPercusion.Size = new Size(125, 32);
            panelPercusion.TabIndex = 38;
            panelPercusion.Visible = false;
            // 
            // linkLabelTimbales
            // 
            linkLabelTimbales.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelTimbales.AutoSize = true;
            linkLabelTimbales.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelTimbales.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelTimbales.LinkColor = Color.Black;
            linkLabelTimbales.Location = new Point(10, 2);
            linkLabelTimbales.Margin = new Padding(2, 0, 2, 0);
            linkLabelTimbales.Name = "linkLabelTimbales";
            linkLabelTimbales.Size = new Size(89, 28);
            linkLabelTimbales.TabIndex = 17;
            linkLabelTimbales.TabStop = true;
            linkLabelTimbales.Text = "Timbales";
            linkLabelTimbales.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXTimbales
            // 
            linkXTimbales.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXTimbales.AutoSize = true;
            linkXTimbales.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXTimbales.ForeColor = Color.FromArgb(61, 76, 158);
            linkXTimbales.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXTimbales.LinkColor = Color.FromArgb(61, 76, 158);
            linkXTimbales.Location = new Point(93, 0);
            linkXTimbales.Margin = new Padding(2, 0, 2, 0);
            linkXTimbales.Name = "linkXTimbales";
            linkXTimbales.Size = new Size(30, 32);
            linkXTimbales.TabIndex = 18;
            linkXTimbales.TabStop = true;
            linkXTimbales.Text = "×";
            linkXTimbales.Visible = false;
            linkXTimbales.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXRomanticismo
            // 
            linkXRomanticismo.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXRomanticismo.AutoSize = true;
            linkXRomanticismo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXRomanticismo.ForeColor = Color.FromArgb(61, 76, 158);
            linkXRomanticismo.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXRomanticismo.LinkColor = Color.FromArgb(61, 76, 158);
            linkXRomanticismo.Location = new Point(183, 172);
            linkXRomanticismo.Margin = new Padding(2, 0, 2, 0);
            linkXRomanticismo.Name = "linkXRomanticismo";
            linkXRomanticismo.Size = new Size(30, 32);
            linkXRomanticismo.TabIndex = 14;
            linkXRomanticismo.TabStop = true;
            linkXRomanticismo.Text = "×";
            linkXRomanticismo.Visible = false;
            linkXRomanticismo.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelRoman
            // 
            linkLabelRoman.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelRoman.AutoSize = true;
            linkLabelRoman.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelRoman.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelRoman.LinkColor = Color.Black;
            linkLabelRoman.Location = new Point(53, 175);
            linkLabelRoman.Margin = new Padding(2, 0, 2, 0);
            linkLabelRoman.Name = "linkLabelRoman";
            linkLabelRoman.Size = new Size(136, 28);
            linkLabelRoman.TabIndex = 13;
            linkLabelRoman.TabStop = true;
            linkLabelRoman.Text = "Romanticismo";
            linkLabelRoman.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXClasicismo
            // 
            linkXClasicismo.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXClasicismo.AutoSize = true;
            linkXClasicismo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXClasicismo.ForeColor = Color.FromArgb(61, 76, 158);
            linkXClasicismo.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXClasicismo.LinkColor = Color.FromArgb(61, 76, 158);
            linkXClasicismo.Location = new Point(150, 131);
            linkXClasicismo.Margin = new Padding(2, 0, 2, 0);
            linkXClasicismo.Name = "linkXClasicismo";
            linkXClasicismo.Size = new Size(30, 32);
            linkXClasicismo.TabIndex = 12;
            linkXClasicismo.TabStop = true;
            linkXClasicismo.Text = "×";
            linkXClasicismo.Visible = false;
            linkXClasicismo.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelClas
            // 
            linkLabelClas.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelClas.AutoSize = true;
            linkLabelClas.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelClas.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelClas.LinkColor = Color.Black;
            linkLabelClas.Location = new Point(53, 133);
            linkLabelClas.Margin = new Padding(2, 0, 2, 0);
            linkLabelClas.Name = "linkLabelClas";
            linkLabelClas.Size = new Size(103, 28);
            linkLabelClas.TabIndex = 11;
            linkLabelClas.TabStop = true;
            linkLabelClas.Text = "Clasicismo";
            linkLabelClas.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkXBarroco
            // 
            linkXBarroco.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkXBarroco.AutoSize = true;
            linkXBarroco.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkXBarroco.ForeColor = Color.FromArgb(61, 76, 158);
            linkXBarroco.LinkBehavior = LinkBehavior.NeverUnderline;
            linkXBarroco.LinkColor = Color.FromArgb(61, 76, 158);
            linkXBarroco.Location = new Point(128, 89);
            linkXBarroco.Margin = new Padding(2, 0, 2, 0);
            linkXBarroco.Name = "linkXBarroco";
            linkXBarroco.Size = new Size(30, 32);
            linkXBarroco.TabIndex = 10;
            linkXBarroco.TabStop = true;
            linkXBarroco.Text = "×";
            linkXBarroco.Visible = false;
            linkXBarroco.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // linkLabelBarroco
            // 
            linkLabelBarroco.ActiveLinkColor = Color.FromArgb(61, 76, 158);
            linkLabelBarroco.AutoSize = true;
            linkLabelBarroco.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelBarroco.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelBarroco.LinkColor = Color.Black;
            linkLabelBarroco.Location = new Point(53, 92);
            linkLabelBarroco.Margin = new Padding(2, 0, 2, 0);
            linkLabelBarroco.Name = "linkLabelBarroco";
            linkLabelBarroco.Size = new Size(80, 28);
            linkLabelBarroco.TabIndex = 9;
            linkLabelBarroco.TabStop = true;
            linkLabelBarroco.Text = "Barroco";
            linkLabelBarroco.VisitedLinkColor = Color.FromArgb(61, 76, 158);
            // 
            // labelInstrtumento
            // 
            labelInstrtumento.AutoSize = true;
            labelInstrtumento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelInstrtumento.ForeColor = SystemColors.ControlDarkDark;
            labelInstrtumento.Location = new Point(22, 415);
            labelInstrtumento.Margin = new Padding(2, 0, 2, 0);
            labelInstrtumento.Name = "labelInstrtumento";
            labelInstrtumento.Size = new Size(187, 32);
            labelInstrtumento.TabIndex = 8;
            labelInstrtumento.Text = "Instrumentación";
            // 
            // labelEpoca
            // 
            labelEpoca.AutoSize = true;
            labelEpoca.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEpoca.ForeColor = SystemColors.ControlDarkDark;
            labelEpoca.Location = new Point(22, 52);
            labelEpoca.Margin = new Padding(2, 0, 2, 0);
            labelEpoca.Name = "labelEpoca";
            labelEpoca.Size = new Size(77, 32);
            labelEpoca.TabIndex = 6;
            labelEpoca.Text = "Época";
            // 
            // lblPartituras
            // 
            lblPartituras.AutoSize = true;
            lblPartituras.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPartituras.Location = new Point(333, 198);
            lblPartituras.Name = "lblPartituras";
            lblPartituras.Size = new Size(251, 38);
            lblPartituras.TabIndex = 2;
            lblPartituras.Text = "Partituras subidas";
            // 
            // panelBuscar
            // 
            panelBuscar.BackColor = Color.White;
            panelBuscar.Controls.Add(textBoxMisPartituras);
            panelBuscar.Controls.Add(pictureBox2);
            panelBuscar.Location = new Point(1364, 207);
            panelBuscar.Name = "panelBuscar";
            panelBuscar.Size = new Size(383, 55);
            panelBuscar.TabIndex = 7;
            // 
            // textBoxMisPartituras
            // 
            textBoxMisPartituras.BorderStyle = BorderStyle.None;
            textBoxMisPartituras.Location = new Point(60, 14);
            textBoxMisPartituras.Name = "textBoxMisPartituras";
            textBoxMisPartituras.Size = new Size(304, 24);
            textBoxMisPartituras.TabIndex = 1;
            textBoxMisPartituras.Text = "Buscar partituras";
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(337, 80);
            label1.Name = "label1";
            label1.Size = new Size(201, 65);
            label1.TabIndex = 8;
            label1.Text = "Usuario";
            // 
            // MySheetsControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(filaPartirua);
            Controls.Add(label1);
            Controls.Add(panelBuscar);
            Controls.Add(lblPartituras);
            Controls.Add(panelOpciones);
            Controls.Add(flowPartiturasPanel);
            Name = "MySheetsControl";
            Size = new Size(1771, 1606);
            flowPartiturasPanel.ResumeLayout(false);
            filaPartitura.ResumeLayout(false);
            filaPartitura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnDescargar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnVer).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEliminar).EndInit();
            filaPartirua.ResumeLayout(false);
            filaPartirua.PerformLayout();
            panelOpciones.ResumeLayout(false);
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)down1).EndInit();
            ((System.ComponentModel.ISupportInitialize)right1).EndInit();
            panelTeclado.ResumeLayout(false);
            panelTeclado.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)down2).EndInit();
            ((System.ComponentModel.ISupportInitialize)right2).EndInit();
            panelCuerda.ResumeLayout(false);
            panelCuerda.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)down3).EndInit();
            ((System.ComponentModel.ISupportInitialize)right3).EndInit();
            panelVientoMa.ResumeLayout(false);
            panelVientoMa.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)down4).EndInit();
            ((System.ComponentModel.ISupportInitialize)right4).EndInit();
            panelVientoMe.ResumeLayout(false);
            panelVientoMe.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)down5).EndInit();
            ((System.ComponentModel.ISupportInitialize)right5).EndInit();
            panelVoz.ResumeLayout(false);
            panelVoz.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)down6).EndInit();
            ((System.ComponentModel.ISupportInitialize)right6).EndInit();
            panelPercusion.ResumeLayout(false);
            panelPercusion.PerformLayout();
            panelBuscar.ResumeLayout(false);
            panelBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowPartiturasPanel;
        private Panel panelOpciones;
        private Label lblPartituras;
        private Panel panelBuscar;
        private TextBox textBoxMisPartituras;
        private PictureBox pictureBox2;
        private Label label1;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Panel filaPartirua;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label txtPartitura;
        private Label txtInstrumentos;
        private Label txtEpoca;
        private Label txtFecha;
        private Panel filaPartitura;
        private PictureBox btnVer;
        private PictureBox btnEliminar;
        private Label label7;
        private Label label6;
        private Panel panelFilters;
        private Label labelEpoca;
        private Label labelInstrtumento;
        private LinkLabel linkLabelBarroco;
        private LinkLabel linkXBarroco;
        private LinkLabel linkXOrgano;
        private LinkLabel linkLabelOrgano;
        private LinkLabel linkXP;
        private LinkLabel linkLabelPiano;
        private LinkLabel linkXRomanticismo;
        private LinkLabel linkLabelRoman;
        private LinkLabel linkXClasicismo;
        private LinkLabel linkLabelClas;
        private LinkLabel linkXT;
        private LinkLabel linkLabelVoz;
        private LinkLabel linkXG;
        private LinkLabel linkLabelTrompeta;
        private LinkLabel linkLabel12;
        private LinkLabel linkLabelGuitarra;
        private LinkLabel linkXPiano;
        private LinkLabel linkXClave;
        private LinkLabel linkLabelClave;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panelTeclado;
        private PictureBox right2;
        private Label labelCuerda;
        private PictureBox down2;
        private Panel panelVientoMa;
        private LinkLabel linkLabelClarinete;
        private LinkLabel linkXOboe;
        private LinkLabel linkLabelOboe;
        private LinkLabel linkLabelFagot;
        private LinkLabel linkXClarinete;
        private Panel panelVientoMe;
        private LinkLabel linkXTrombon;
        private LinkLabel linkLabel18;
        private LinkLabel linkLabelFlauta;
        private LinkLabel linkXFlauta;
        private LinkLabel linkLabelTrombon;
        private LinkLabel linkXTrompeta;
        private Panel panelVoz;
        private LinkLabel linkLabelSoprano;
        private LinkLabel linkXSoprano;
        private LinkLabel linkLabelMezzo;
        private LinkLabel linkXMezzo;
        private LinkLabel linkLabelTenor;
        private LinkLabel linkXTenor;
        private Panel panelCuerda;
        private LinkLabel linkLabelViolin;
        private LinkLabel linkXViolin;
        private LinkLabel linkLabelViola;
        private LinkLabel linkXViola;
        private LinkLabel linkLabelCello;
        private LinkLabel linkXCello;
        private Panel panel5;
        private Panel panel7;
        private Label labelTeclado;
        private PictureBox down1;
        private PictureBox right1;
        private Panel panel8;
        private Label labelVientoMa;
        private PictureBox down3;
        private PictureBox right3;
        private Panel panel9;
        private Label labelVientoMe;
        private PictureBox down4;
        private PictureBox right4;
        private Panel panel6;
        private Label labelVoz;
        private PictureBox down5;
        private PictureBox right5;
        private LinkLabel linkLabelContrabajo;
        private LinkLabel linkXContrabajo;
        private Panel panel10;
        private Label labelPercusion;
        private PictureBox down6;
        private PictureBox right6;
        private Panel panelPercusion;
        private LinkLabel linkLabelTimbales;
        private LinkLabel linkXTimbales;
        private LinkLabel linkXTrompa;
        private LinkLabel linkLabelTrompa;
        private LinkLabel linkLabelBajo;
        private LinkLabel linkXBajo;
        private LinkLabel linkXFagot;
        private LinkLabel linkXOrquesta;
        private LinkLabel linkLabelOrquesta;
        private LinkLabel linkXCamara;
        private LinkLabel linkLabelCamara;
        private LinkLabel linkXSolo;
        private LinkLabel linkLabelSolo;
        private Label labelAgrupacion;
        private LinkLabel linkLabelCoro;
        private LinkLabel linkXCoro;
        private Label txtCompositor;
        private Label label8;
        private PictureBox btnDescargar;
        private Label label10;
        private Label txtAgrupacion;
        private Label label9;
    }
}
