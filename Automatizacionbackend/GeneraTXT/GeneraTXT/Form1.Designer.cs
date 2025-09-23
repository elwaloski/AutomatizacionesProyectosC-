namespace GeneraTXT
{
    partial class Form1
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
            tabPage1 = new TabPage();
            cbxAccion = new ComboBox();
            lblAcción = new Label();
            ckbNormativo = new CheckBox();
            ckbLeyMadera = new CheckBox();
            CKBGeoReferencia = new CheckBox();
            btnSalir = new Button();
            btnGenerar = new Button();
            TxbDirectorio = new TextBox();
            txbDigi = new TextBox();
            txbRut = new TextBox();
            txbCantidadTotal = new TextBox();
            txbFolioDesde = new TextBox();
            BtnDirectorio = new Button();
            dtFechVenc = new DateTimePicker();
            dtFechEmis = new DateTimePicker();
            lblFolioDesde = new Label();
            lblCantidadTotal = new Label();
            lblFechaVencimiento = new Label();
            lblFechaEmision = new Label();
            lblRutEmpresa = new Label();
            cbxTipoDocumento = new ComboBox();
            lblTipoDocumento = new Label();
            tabControl1 = new TabControl();
            tabPage1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(cbxAccion);
            tabPage1.Controls.Add(lblAcción);
            tabPage1.Controls.Add(ckbNormativo);
            tabPage1.Controls.Add(ckbLeyMadera);
            tabPage1.Controls.Add(CKBGeoReferencia);
            tabPage1.Controls.Add(btnSalir);
            tabPage1.Controls.Add(btnGenerar);
            tabPage1.Controls.Add(TxbDirectorio);
            tabPage1.Controls.Add(txbDigi);
            tabPage1.Controls.Add(txbRut);
            tabPage1.Controls.Add(txbCantidadTotal);
            tabPage1.Controls.Add(txbFolioDesde);
            tabPage1.Controls.Add(BtnDirectorio);
            tabPage1.Controls.Add(dtFechVenc);
            tabPage1.Controls.Add(dtFechEmis);
            tabPage1.Controls.Add(lblFolioDesde);
            tabPage1.Controls.Add(lblCantidadTotal);
            tabPage1.Controls.Add(lblFechaVencimiento);
            tabPage1.Controls.Add(lblFechaEmision);
            tabPage1.Controls.Add(lblRutEmpresa);
            tabPage1.Controls.Add(cbxTipoDocumento);
            tabPage1.Controls.Add(lblTipoDocumento);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(410, 342);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "TXT";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // cbxAccion
            // 
            cbxAccion.FormattingEnabled = true;
            cbxAccion.Items.AddRange(new object[] { "TXT", "TXT API2020", "JSON GATEWAY", "JSON API2020", "SEM API2020" });
            cbxAccion.Location = new Point(109, 11);
            cbxAccion.Name = "cbxAccion";
            cbxAccion.Size = new Size(101, 23);
            cbxAccion.TabIndex = 97;
            cbxAccion.SelectedIndexChanged += cbxAccion_SelectedIndexChanged;
            // 
            // lblAcción
            // 
            lblAcción.AutoSize = true;
            lblAcción.Location = new Point(-1, 11);
            lblAcción.Name = "lblAcción";
            lblAcción.Size = new Size(44, 15);
            lblAcción.TabIndex = 96;
            lblAcción.Text = "Acción";
            // 
            // ckbNormativo
            // 
            ckbNormativo.AutoSize = true;
            ckbNormativo.Location = new Point(225, 91);
            ckbNormativo.Name = "ckbNormativo";
            ckbNormativo.Size = new Size(118, 19);
            ckbNormativo.TabIndex = 95;
            ckbNormativo.Text = "Normativo 135UF";
            ckbNormativo.UseVisualStyleBackColor = true;
            // 
            // ckbLeyMadera
            // 
            ckbLeyMadera.AutoSize = true;
            ckbLeyMadera.Location = new Point(226, 67);
            ckbLeyMadera.Name = "ckbLeyMadera";
            ckbLeyMadera.Size = new Size(87, 19);
            ckbLeyMadera.TabIndex = 94;
            ckbLeyMadera.Text = "Ley madera";
            ckbLeyMadera.UseVisualStyleBackColor = true;
            // 
            // CKBGeoReferencia
            // 
            CKBGeoReferencia.AutoSize = true;
            CKBGeoReferencia.Location = new Point(226, 42);
            CKBGeoReferencia.Name = "CKBGeoReferencia";
            CKBGeoReferencia.Size = new Size(99, 19);
            CKBGeoReferencia.TabIndex = 93;
            CKBGeoReferencia.Text = "Georeferencia";
            CKBGeoReferencia.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(182, 269);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 92;
            btnSalir.Text = " Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(101, 269);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(75, 23);
            btnGenerar.TabIndex = 91;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // TxbDirectorio
            // 
            TxbDirectorio.Location = new Point(109, 221);
            TxbDirectorio.Name = "TxbDirectorio";
            TxbDirectorio.Size = new Size(273, 23);
            TxbDirectorio.TabIndex = 90;
            TxbDirectorio.TextChanged += TxbDirectorio_TextChanged;
            // 
            // txbDigi
            // 
            txbDigi.Location = new Point(187, 73);
            txbDigi.Name = "txbDigi";
            txbDigi.Size = new Size(23, 23);
            txbDigi.TabIndex = 86;
            txbDigi.TextChanged += txbDigi_TextChanged;
            txbDigi.KeyPress += txbDigi_KeyPress;
            // 
            // txbRut
            // 
            txbRut.ImeMode = ImeMode.Hiragana;
            txbRut.Location = new Point(109, 73);
            txbRut.Name = "txbRut";
            txbRut.Size = new Size(75, 23);
            txbRut.TabIndex = 85;
            txbRut.TextChanged += txbRut_TextChanged;
            txbRut.KeyPress += txbRut_KeyPress;
            // 
            // txbCantidadTotal
            // 
            txbCantidadTotal.Location = new Point(109, 158);
            txbCantidadTotal.Name = "txbCantidadTotal";
            txbCantidadTotal.Size = new Size(100, 23);
            txbCantidadTotal.TabIndex = 84;
            txbCantidadTotal.TextChanged += txbCantidadTotal_TextChanged;
            txbCantidadTotal.KeyPress += txbCantidadTotal_KeyPress;
            // 
            // txbFolioDesde
            // 
            txbFolioDesde.Location = new Point(109, 185);
            txbFolioDesde.Name = "txbFolioDesde";
            txbFolioDesde.Size = new Size(100, 23);
            txbFolioDesde.TabIndex = 83;
            txbFolioDesde.TextChanged += txbFolioDesde_TextChanged;
            txbFolioDesde.KeyPress += txbFolioDesde_KeyPress;
            // 
            // BtnDirectorio
            // 
            BtnDirectorio.Location = new Point(-1, 221);
            BtnDirectorio.Name = "BtnDirectorio";
            BtnDirectorio.Size = new Size(75, 23);
            BtnDirectorio.TabIndex = 89;
            BtnDirectorio.Text = "Directorio";
            BtnDirectorio.UseVisualStyleBackColor = true;
            BtnDirectorio.Click += BtnDirectorio_Click_1;
            // 
            // dtFechVenc
            // 
            dtFechVenc.Format = DateTimePickerFormat.Short;
            dtFechVenc.Location = new Point(109, 128);
            dtFechVenc.Name = "dtFechVenc";
            dtFechVenc.Size = new Size(100, 23);
            dtFechVenc.TabIndex = 88;
            dtFechVenc.ValueChanged += dtFechVenc_ValueChanged;
            // 
            // dtFechEmis
            // 
            dtFechEmis.Format = DateTimePickerFormat.Short;
            dtFechEmis.Location = new Point(109, 102);
            dtFechEmis.Name = "dtFechEmis";
            dtFechEmis.Size = new Size(100, 23);
            dtFechEmis.TabIndex = 87;
            dtFechEmis.ValueChanged += dtFechEmis_ValueChanged;
            // 
            // lblFolioDesde
            // 
            lblFolioDesde.AutoSize = true;
            lblFolioDesde.Location = new Point(-2, 192);
            lblFolioDesde.Name = "lblFolioDesde";
            lblFolioDesde.Size = new Size(68, 15);
            lblFolioDesde.TabIndex = 80;
            lblFolioDesde.Text = "Folio Desde";
            // 
            // lblCantidadTotal
            // 
            lblCantidadTotal.AutoSize = true;
            lblCantidadTotal.Location = new Point(-1, 166);
            lblCantidadTotal.Name = "lblCantidadTotal";
            lblCantidadTotal.Size = new Size(83, 15);
            lblCantidadTotal.TabIndex = 79;
            lblCantidadTotal.Text = "Cantidad Total";
            // 
            // lblFechaVencimiento
            // 
            lblFechaVencimiento.AutoSize = true;
            lblFechaVencimiento.Location = new Point(-1, 125);
            lblFechaVencimiento.Name = "lblFechaVencimiento";
            lblFechaVencimiento.Size = new Size(107, 15);
            lblFechaVencimiento.TabIndex = 78;
            lblFechaVencimiento.Text = "Fecha Vencimiento";
            // 
            // lblFechaEmision
            // 
            lblFechaEmision.AutoSize = true;
            lblFechaEmision.Location = new Point(-1, 100);
            lblFechaEmision.Name = "lblFechaEmision";
            lblFechaEmision.Size = new Size(83, 15);
            lblFechaEmision.TabIndex = 77;
            lblFechaEmision.Text = "Fecha Emisión";
            // 
            // lblRutEmpresa
            // 
            lblRutEmpresa.AutoSize = true;
            lblRutEmpresa.Location = new Point(-1, 73);
            lblRutEmpresa.Name = "lblRutEmpresa";
            lblRutEmpresa.Size = new Size(73, 15);
            lblRutEmpresa.TabIndex = 76;
            lblRutEmpresa.Text = "Rut Empresa";
            // 
            // cbxTipoDocumento
            // 
            cbxTipoDocumento.FormattingEnabled = true;
            cbxTipoDocumento.Items.AddRange(new object[] { "33", "34", "39", "41", "43", "46", "52", "56", "61", "110", "111", "112" });
            cbxTipoDocumento.Location = new Point(109, 40);
            cbxTipoDocumento.Name = "cbxTipoDocumento";
            cbxTipoDocumento.Size = new Size(101, 23);
            cbxTipoDocumento.TabIndex = 68;
            cbxTipoDocumento.SelectedIndexChanged += cbxTipoDocumento_SelectedIndexChanged;
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.AutoSize = true;
            lblTipoDocumento.Location = new Point(-1, 40);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(96, 15);
            lblTipoDocumento.TabIndex = 67;
            lblTipoDocumento.Text = "Tipo Documento";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(418, 370);
            tabControl1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 406);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Herramienta QA";
            Load += Form1_Load;
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabPage1;
        private ComboBox cbxAccion;
        private Label lblAcción;
        private CheckBox ckbNormativo;
        private CheckBox ckbLeyMadera;
        private CheckBox CKBGeoReferencia;
        private Button btnSalir;
        private Button btnGenerar;
        private TextBox TxbDirectorio;
        private TextBox txbDigi;
        private TextBox txbRut;
        private TextBox txbCantidadTotal;
        private TextBox txbFolioDesde;
        private Button BtnDirectorio;
        private DateTimePicker dtFechVenc;
        private DateTimePicker dtFechEmis;
        private Label lblFolioDesde;
        private Label lblCantidadTotal;
        private Label lblFechaVencimiento;
        private Label lblFechaEmision;
        private Label lblRutEmpresa;
        private ComboBox cbxTipoDocumento;
        private Label lblTipoDocumento;
        private TabControl tabControl1;
    }
}
