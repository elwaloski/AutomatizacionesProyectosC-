namespace GeneradorJsonFECO
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbEmpresaAdquiriente = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxCorrelativoDocumento = new System.Windows.Forms.TextBox();
            this.tbxCantidadDocumento = new System.Windows.Forms.TextBox();
            this.cmbSeriePrefijo = new System.Windows.Forms.ComboBox();
            this.cmbIdArea = new System.Windows.Forms.ComboBox();
            this.cmbEmpresaEmisora = new System.Windows.Forms.ComboBox();
            this.cmbMetodoCarga = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmbResponsabilidadAdquiriente = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbResponsabilidadEmisor = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbRegimenAdquiriente = new System.Windows.Forms.ComboBox();
            this.cmbTipoIdentificacionAdquiriente = new System.Windows.Forms.ComboBox();
            this.dtpFechaHoraEmision = new System.Windows.Forms.DateTimePicker();
            this.cmbRegimenEmisor = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTipoIdentificacionEmisor = new System.Windows.Forms.ComboBox();
            this.cmbMonedaDocumento = new System.Windows.Forms.ComboBox();
            this.cmbTipoOperacion = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cmbMedioPago = new System.Windows.Forms.ComboBox();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tbxValorCodigo = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cmbCodigoItems = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbCodReferenciaItems = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbxCantidadRefItems = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbImpuestoItem = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbUnidadMedida = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbxCantidadItems = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dtpFechaDocReferencia = new System.Windows.Forms.DateTimePicker();
            this.tbxNumeroReferencia = new System.Windows.Forms.TextBox();
            this.cmbTipoDocReferencia = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cmbTipoReferencia = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tbxMailOculto = new System.Windows.Forms.TextBox();
            this.tbxMailPara = new System.Windows.Forms.TextBox();
            this.tbxMailCopia = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.tbxRutaDestino = new System.Windows.Forms.TextBox();
            this.btnGenerarDocumento = new System.Windows.Forms.Button();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmbAsigAuto = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1326, 531);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbAsigAuto);
            this.tabPage1.Controls.Add(this.label32);
            this.tabPage1.Controls.Add(this.cmbEmpresaAdquiriente);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.cmbTipoDocumento);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.tbxCorrelativoDocumento);
            this.tabPage1.Controls.Add(this.tbxCantidadDocumento);
            this.tabPage1.Controls.Add(this.cmbSeriePrefijo);
            this.tabPage1.Controls.Add(this.cmbIdArea);
            this.tabPage1.Controls.Add(this.cmbEmpresaEmisora);
            this.tabPage1.Controls.Add(this.cmbMetodoCarga);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1318, 505);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Configuración";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbEmpresaAdquiriente
            // 
            this.cmbEmpresaAdquiriente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpresaAdquiriente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpresaAdquiriente.FormattingEnabled = true;
            this.cmbEmpresaAdquiriente.Items.AddRange(new object[] {
            "830058737 - VQ Ingeniería",
            "900918004 - DBNET CO"});
            this.cmbEmpresaAdquiriente.Location = new System.Drawing.Point(311, 174);
            this.cmbEmpresaAdquiriente.Name = "cmbEmpresaAdquiriente";
            this.cmbEmpresaAdquiriente.Size = new System.Drawing.Size(247, 28);
            this.cmbEmpresaAdquiriente.TabIndex = 14;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(80, 178);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(158, 20);
            this.label17.TabIndex = 13;
            this.label17.Text = "Empresa Adquiriente";
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Items.AddRange(new object[] {
            "FE GENÉRICA",
            "FE EXPORTACIÓN",
            "NOTA CRÉDITO",
            "NOTA DÉBITO"});
            this.cmbTipoDocumento.Location = new System.Drawing.Point(311, 269);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(247, 28);
            this.cmbTipoDocumento.TabIndex = 5;
            this.cmbTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDocumento_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(80, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tipo Documento";
            // 
            // tbxCorrelativoDocumento
            // 
            this.tbxCorrelativoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCorrelativoDocumento.Location = new System.Drawing.Point(311, 424);
            this.tbxCorrelativoDocumento.Name = "tbxCorrelativoDocumento";
            this.tbxCorrelativoDocumento.Size = new System.Drawing.Size(247, 26);
            this.tbxCorrelativoDocumento.TabIndex = 7;
            this.tbxCorrelativoDocumento.Leave += new System.EventHandler(this.tbxCorrelativoDocumento_Leave);
            // 
            // tbxCantidadDocumento
            // 
            this.tbxCantidadDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCantidadDocumento.Location = new System.Drawing.Point(311, 372);
            this.tbxCantidadDocumento.Name = "tbxCantidadDocumento";
            this.tbxCantidadDocumento.Size = new System.Drawing.Size(247, 26);
            this.tbxCantidadDocumento.TabIndex = 6;
            this.tbxCantidadDocumento.Leave += new System.EventHandler(this.tbxCantidadDocumento_Leave);
            // 
            // cmbSeriePrefijo
            // 
            this.cmbSeriePrefijo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeriePrefijo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSeriePrefijo.FormattingEnabled = true;
            this.cmbSeriePrefijo.Items.AddRange(new object[] {
            "SETP",
            "SETT"});
            this.cmbSeriePrefijo.Location = new System.Drawing.Point(311, 316);
            this.cmbSeriePrefijo.Name = "cmbSeriePrefijo";
            this.cmbSeriePrefijo.Size = new System.Drawing.Size(247, 28);
            this.cmbSeriePrefijo.TabIndex = 4;
            // 
            // cmbIdArea
            // 
            this.cmbIdArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIdArea.FormattingEnabled = true;
            this.cmbIdArea.Items.AddRange(new object[] {
            "PREV",
            "BOGT"});
            this.cmbIdArea.Location = new System.Drawing.Point(311, 221);
            this.cmbIdArea.Name = "cmbIdArea";
            this.cmbIdArea.Size = new System.Drawing.Size(247, 28);
            this.cmbIdArea.TabIndex = 3;
            // 
            // cmbEmpresaEmisora
            // 
            this.cmbEmpresaEmisora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpresaEmisora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpresaEmisora.FormattingEnabled = true;
            this.cmbEmpresaEmisora.Items.AddRange(new object[] {
            "900918004",
            "111111111"});
            this.cmbEmpresaEmisora.Location = new System.Drawing.Point(311, 123);
            this.cmbEmpresaEmisora.Name = "cmbEmpresaEmisora";
            this.cmbEmpresaEmisora.Size = new System.Drawing.Size(247, 28);
            this.cmbEmpresaEmisora.TabIndex = 2;
            this.cmbEmpresaEmisora.SelectedIndexChanged += new System.EventHandler(this.cmbEmpresaEmisora_SelectedIndexChanged);
            // 
            // cmbMetodoCarga
            // 
            this.cmbMetodoCarga.BackColor = System.Drawing.SystemColors.Window;
            this.cmbMetodoCarga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoCarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMetodoCarga.FormattingEnabled = true;
            this.cmbMetodoCarga.Items.AddRange(new object[] {
            "ARCHIVO",
            "WSS",
            "ALLIANZ",
            "INYECCIÓN DIRECTA BD"});
            this.cmbMetodoCarga.Location = new System.Drawing.Point(311, 34);
            this.cmbMetodoCarga.Name = "cmbMetodoCarga";
            this.cmbMetodoCarga.Size = new System.Drawing.Size(247, 28);
            this.cmbMetodoCarga.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(80, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Correlativo Documento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(80, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cantidad Documentos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Área Factura";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Serie/Prefijo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Empresa Emisora";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Metodo Carga";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmbResponsabilidadAdquiriente);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.cmbResponsabilidadEmisor);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.cmbRegimenAdquiriente);
            this.tabPage2.Controls.Add(this.cmbTipoIdentificacionAdquiriente);
            this.tabPage2.Controls.Add(this.dtpFechaHoraEmision);
            this.tabPage2.Controls.Add(this.cmbRegimenEmisor);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.cmbTipoIdentificacionEmisor);
            this.tabPage2.Controls.Add(this.cmbMonedaDocumento);
            this.tabPage2.Controls.Add(this.cmbTipoOperacion);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1318, 505);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Encabezado";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmbResponsabilidadAdquiriente
            // 
            this.cmbResponsabilidadAdquiriente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsabilidadAdquiriente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbResponsabilidadAdquiriente.FormattingEnabled = true;
            this.cmbResponsabilidadAdquiriente.Items.AddRange(new object[] {
            "Aleatorio",
            "O-13",
            "O-15",
            "O-23",
            "O-47",
            "R-99-PN"});
            this.cmbResponsabilidadAdquiriente.Location = new System.Drawing.Point(311, 439);
            this.cmbResponsabilidadAdquiriente.Name = "cmbResponsabilidadAdquiriente";
            this.cmbResponsabilidadAdquiriente.Size = new System.Drawing.Size(247, 28);
            this.cmbResponsabilidadAdquiriente.TabIndex = 32;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(80, 443);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(204, 20);
            this.label16.TabIndex = 33;
            this.label16.Text = "Reponsabilidad Adquiriente";
            // 
            // cmbResponsabilidadEmisor
            // 
            this.cmbResponsabilidadEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsabilidadEmisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbResponsabilidadEmisor.FormattingEnabled = true;
            this.cmbResponsabilidadEmisor.Items.AddRange(new object[] {
            "Aleatorio",
            "O-13",
            "O-15",
            "O-23",
            "O-47",
            "R-99-PN"});
            this.cmbResponsabilidadEmisor.Location = new System.Drawing.Point(311, 287);
            this.cmbResponsabilidadEmisor.Name = "cmbResponsabilidadEmisor";
            this.cmbResponsabilidadEmisor.Size = new System.Drawing.Size(247, 28);
            this.cmbResponsabilidadEmisor.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(80, 291);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(172, 20);
            this.label15.TabIndex = 31;
            this.label15.Text = "Reponsabilidad Emisor";
            // 
            // cmbRegimenAdquiriente
            // 
            this.cmbRegimenAdquiriente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegimenAdquiriente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRegimenAdquiriente.FormattingEnabled = true;
            this.cmbRegimenAdquiriente.Items.AddRange(new object[] {
            "Aleatorio",
            "48 - Responsable del impuesto",
            "49 - No responsable de IVA"});
            this.cmbRegimenAdquiriente.Location = new System.Drawing.Point(311, 386);
            this.cmbRegimenAdquiriente.Name = "cmbRegimenAdquiriente";
            this.cmbRegimenAdquiriente.Size = new System.Drawing.Size(247, 28);
            this.cmbRegimenAdquiriente.TabIndex = 29;
            // 
            // cmbTipoIdentificacionAdquiriente
            // 
            this.cmbTipoIdentificacionAdquiriente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoIdentificacionAdquiriente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoIdentificacionAdquiriente.FormattingEnabled = true;
            this.cmbTipoIdentificacionAdquiriente.Items.AddRange(new object[] {
            "Aleatorio",
            "11 - Registro civil  ",
            "12 - Tarjeta de identidad  ",
            "13 - Cédula de ciudadanía  ",
            "21 - Tarjeta de extranjería  ",
            "22 - Cédula de extranjería  ",
            "31 - NIT 41  Pasaporte  ",
            "42 - Documento de identificación extranjero  ",
            "50 - NIT de otro país ",
            "91 - NUIP"});
            this.cmbTipoIdentificacionAdquiriente.Location = new System.Drawing.Point(311, 334);
            this.cmbTipoIdentificacionAdquiriente.Name = "cmbTipoIdentificacionAdquiriente";
            this.cmbTipoIdentificacionAdquiriente.Size = new System.Drawing.Size(247, 28);
            this.cmbTipoIdentificacionAdquiriente.TabIndex = 28;
            // 
            // dtpFechaHoraEmision
            // 
            this.dtpFechaHoraEmision.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHoraEmision.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHoraEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaHoraEmision.Location = new System.Drawing.Point(311, 38);
            this.dtpFechaHoraEmision.Name = "dtpFechaHoraEmision";
            this.dtpFechaHoraEmision.Size = new System.Drawing.Size(247, 26);
            this.dtpFechaHoraEmision.TabIndex = 27;
            // 
            // cmbRegimenEmisor
            // 
            this.cmbRegimenEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegimenEmisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRegimenEmisor.FormattingEnabled = true;
            this.cmbRegimenEmisor.Items.AddRange(new object[] {
            "Aleatorio",
            "48 - Responsable del impuesto",
            "49 - No responsable de IVA"});
            this.cmbRegimenEmisor.Location = new System.Drawing.Point(311, 241);
            this.cmbRegimenEmisor.Name = "cmbRegimenEmisor";
            this.cmbRegimenEmisor.Size = new System.Drawing.Size(247, 28);
            this.cmbRegimenEmisor.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(80, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 20);
            this.label8.TabIndex = 26;
            this.label8.Text = "Régimen Emisor";
            // 
            // cmbTipoIdentificacionEmisor
            // 
            this.cmbTipoIdentificacionEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoIdentificacionEmisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoIdentificacionEmisor.FormattingEnabled = true;
            this.cmbTipoIdentificacionEmisor.Items.AddRange(new object[] {
            "Aleatorio",
            "11 - Registro civil  ",
            "12 - Tarjeta de identidad  ",
            "13 - Cédula de ciudadanía  ",
            "21 - Tarjeta de extranjería  ",
            "22 - Cédula de extranjería  ",
            "31 - NIT 41  Pasaporte  ",
            "42 - Documento de identificación extranjero  ",
            "50 - NIT de otro país "});
            this.cmbTipoIdentificacionEmisor.Location = new System.Drawing.Point(311, 190);
            this.cmbTipoIdentificacionEmisor.Name = "cmbTipoIdentificacionEmisor";
            this.cmbTipoIdentificacionEmisor.Size = new System.Drawing.Size(247, 28);
            this.cmbTipoIdentificacionEmisor.TabIndex = 20;
            // 
            // cmbMonedaDocumento
            // 
            this.cmbMonedaDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonedaDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonedaDocumento.FormattingEnabled = true;
            this.cmbMonedaDocumento.Items.AddRange(new object[] {
            "COP",
            "USD",
            "EURO"});
            this.cmbMonedaDocumento.Location = new System.Drawing.Point(311, 138);
            this.cmbMonedaDocumento.Name = "cmbMonedaDocumento";
            this.cmbMonedaDocumento.Size = new System.Drawing.Size(247, 28);
            this.cmbMonedaDocumento.TabIndex = 18;
            // 
            // cmbTipoOperacion
            // 
            this.cmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoOperacion.FormattingEnabled = true;
            this.cmbTipoOperacion.Location = new System.Drawing.Point(311, 86);
            this.cmbTipoOperacion.Name = "cmbTipoOperacion";
            this.cmbTipoOperacion.Size = new System.Drawing.Size(247, 28);
            this.cmbTipoOperacion.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(80, 386);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Régimen Adquiriente";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(80, 334);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(222, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Tipo Identificación Adquiriente";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(80, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Moneda Documento";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(80, 194);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(190, 20);
            this.label12.TabIndex = 17;
            this.label12.Text = "Tipo Identificación Emisor";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(80, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 20);
            this.label13.TabIndex = 15;
            this.label13.Text = "Tipo Operación";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(80, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(153, 20);
            this.label14.TabIndex = 13;
            this.label14.Text = "Fecha/Hora Emisión";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cmbMedioPago);
            this.tabPage3.Controls.Add(this.cmbFormaPago);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1318, 505);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Medio Pago";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cmbMedioPago
            // 
            this.cmbMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedioPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMedioPago.FormattingEnabled = true;
            this.cmbMedioPago.Items.AddRange(new object[] {
            "Aleatorio",
            "10 - Efectivo",
            "20 - Cheque",
            "42 - Cons. Banc",
            "48 - T. Crédito",
            "49 - T. Débito",
            "71 - Bonos",
            "72 - Vales"});
            this.cmbMedioPago.Location = new System.Drawing.Point(311, 86);
            this.cmbMedioPago.Name = "cmbMedioPago";
            this.cmbMedioPago.Size = new System.Drawing.Size(247, 28);
            this.cmbMedioPago.TabIndex = 18;
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Items.AddRange(new object[] {
            "Aleatorio",
            "Contado",
            "Crédito"});
            this.cmbFormaPago.Location = new System.Drawing.Point(311, 34);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(247, 28);
            this.cmbFormaPago.TabIndex = 16;
            this.cmbFormaPago.SelectedIndexChanged += new System.EventHandler(this.cmbFormaPago_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(80, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 20);
            this.label20.TabIndex = 17;
            this.label20.Text = "Medio Pago";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(80, 38);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(96, 20);
            this.label21.TabIndex = 15;
            this.label21.Text = "Forma Pago";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tbxValorCodigo);
            this.tabPage4.Controls.Add(this.label25);
            this.tabPage4.Controls.Add(this.cmbCodigoItems);
            this.tabPage4.Controls.Add(this.label26);
            this.tabPage4.Controls.Add(this.cmbCodReferenciaItems);
            this.tabPage4.Controls.Add(this.label23);
            this.tabPage4.Controls.Add(this.tbxCantidadRefItems);
            this.tabPage4.Controls.Add(this.label24);
            this.tabPage4.Controls.Add(this.cmbImpuestoItem);
            this.tabPage4.Controls.Add(this.label22);
            this.tabPage4.Controls.Add(this.cmbUnidadMedida);
            this.tabPage4.Controls.Add(this.label19);
            this.tabPage4.Controls.Add(this.tbxCantidadItems);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1318, 505);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Items";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tbxValorCodigo
            // 
            this.tbxValorCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxValorCodigo.Location = new System.Drawing.Point(310, 247);
            this.tbxValorCodigo.Name = "tbxValorCodigo";
            this.tbxValorCodigo.Size = new System.Drawing.Size(247, 26);
            this.tbxValorCodigo.TabIndex = 30;
            this.tbxValorCodigo.Leave += new System.EventHandler(this.tbxValorCodigo_Leave);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(79, 250);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(100, 20);
            this.label25.TabIndex = 29;
            this.label25.Text = "Valor Codigo";
            // 
            // cmbCodigoItems
            // 
            this.cmbCodigoItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodigoItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCodigoItems.FormattingEnabled = true;
            this.cmbCodigoItems.Items.AddRange(new object[] {
            "Aleatorio",
            "001 - UNSPSC",
            "010 - GTIN",
            "020 - Partida Arancelaria",
            "999 - Estandar de Adopc. Contri."});
            this.cmbCodigoItems.Location = new System.Drawing.Point(310, 193);
            this.cmbCodigoItems.Name = "cmbCodigoItems";
            this.cmbCodigoItems.Size = new System.Drawing.Size(247, 28);
            this.cmbCodigoItems.TabIndex = 28;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(79, 197);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(103, 20);
            this.label26.TabIndex = 27;
            this.label26.Text = "Codigo Items";
            // 
            // cmbCodReferenciaItems
            // 
            this.cmbCodReferenciaItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodReferenciaItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCodReferenciaItems.FormattingEnabled = true;
            this.cmbCodReferenciaItems.Items.AddRange(new object[] {
            "Ninguno",
            "Aleatorio",
            "BIL",
            "DES",
            "DOC",
            "LIN",
            "REC"});
            this.cmbCodReferenciaItems.Location = new System.Drawing.Point(310, 299);
            this.cmbCodReferenciaItems.Name = "cmbCodReferenciaItems";
            this.cmbCodReferenciaItems.Size = new System.Drawing.Size(247, 28);
            this.cmbCodReferenciaItems.TabIndex = 26;
            this.cmbCodReferenciaItems.SelectedIndexChanged += new System.EventHandler(this.cmbCodReferenciaItems_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(79, 303);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(185, 20);
            this.label23.TabIndex = 25;
            this.label23.Text = "Codigo Referencia Items";
            // 
            // tbxCantidadRefItems
            // 
            this.tbxCantidadRefItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCantidadRefItems.Location = new System.Drawing.Point(310, 353);
            this.tbxCantidadRefItems.Name = "tbxCantidadRefItems";
            this.tbxCantidadRefItems.Size = new System.Drawing.Size(247, 26);
            this.tbxCantidadRefItems.TabIndex = 24;
            this.tbxCantidadRefItems.Leave += new System.EventHandler(this.tbxCantidadRefItems_Leave);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(79, 356);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(199, 20);
            this.label24.TabIndex = 23;
            this.label24.Text = "Cantidad Referencia Items";
            // 
            // cmbImpuestoItem
            // 
            this.cmbImpuestoItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImpuestoItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbImpuestoItem.FormattingEnabled = true;
            this.cmbImpuestoItem.Items.AddRange(new object[] {
            "Aleatorio",
            "01 - IVA",
            "02 - IC",
            "03 - ICA",
            "04 - INC",
            "20 - FtoHorticultura ",
            "21 - Timbre",
            "22 - Bolsas",
            "23 - INCarbono",
            "24 - INCombustibles",
            "25 - Sobretasa",
            "26 - Sordicom",
            "ZY - Nocausa",
            "ZZ - Nombredelafiguratributaria"});
            this.cmbImpuestoItem.Location = new System.Drawing.Point(310, 140);
            this.cmbImpuestoItem.Name = "cmbImpuestoItem";
            this.cmbImpuestoItem.Size = new System.Drawing.Size(247, 28);
            this.cmbImpuestoItem.TabIndex = 22;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(79, 144);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(112, 20);
            this.label22.TabIndex = 21;
            this.label22.Text = "Impuesto Item";
            // 
            // cmbUnidadMedida
            // 
            this.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidadMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnidadMedida.FormattingEnabled = true;
            this.cmbUnidadMedida.Items.AddRange(new object[] {
            "Aleatorio",
            "94  - Unidad",
            "JR  - Tarro",
            "KGM - Kilogramo",
            "BO  - Botella",
            "KT  - Equipo",
            "04  - Spray Pequeño"});
            this.cmbUnidadMedida.Location = new System.Drawing.Point(310, 87);
            this.cmbUnidadMedida.Name = "cmbUnidadMedida";
            this.cmbUnidadMedida.Size = new System.Drawing.Size(247, 28);
            this.cmbUnidadMedida.TabIndex = 20;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(79, 91);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(138, 20);
            this.label19.TabIndex = 19;
            this.label19.Text = "Unidad de Medida";
            // 
            // tbxCantidadItems
            // 
            this.tbxCantidadItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCantidadItems.Location = new System.Drawing.Point(310, 35);
            this.tbxCantidadItems.Name = "tbxCantidadItems";
            this.tbxCantidadItems.Size = new System.Drawing.Size(247, 26);
            this.tbxCantidadItems.TabIndex = 18;
            this.tbxCantidadItems.Leave += new System.EventHandler(this.tbxCantidadItems_Leave);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(79, 38);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(117, 20);
            this.label18.TabIndex = 17;
            this.label18.Text = "Cantidad Items";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dtpFechaDocReferencia);
            this.tabPage5.Controls.Add(this.tbxNumeroReferencia);
            this.tabPage5.Controls.Add(this.cmbTipoDocReferencia);
            this.tabPage5.Controls.Add(this.label27);
            this.tabPage5.Controls.Add(this.cmbTipoReferencia);
            this.tabPage5.Controls.Add(this.label28);
            this.tabPage5.Controls.Add(this.label29);
            this.tabPage5.Controls.Add(this.label30);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1318, 505);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Referencias";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dtpFechaDocReferencia
            // 
            this.dtpFechaDocReferencia.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDocReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDocReferencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaDocReferencia.Location = new System.Drawing.Point(313, 187);
            this.dtpFechaDocReferencia.Name = "dtpFechaDocReferencia";
            this.dtpFechaDocReferencia.Size = new System.Drawing.Size(247, 26);
            this.dtpFechaDocReferencia.TabIndex = 28;
            // 
            // tbxNumeroReferencia
            // 
            this.tbxNumeroReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNumeroReferencia.Location = new System.Drawing.Point(313, 87);
            this.tbxNumeroReferencia.Name = "tbxNumeroReferencia";
            this.tbxNumeroReferencia.Size = new System.Drawing.Size(247, 26);
            this.tbxNumeroReferencia.TabIndex = 23;
            this.tbxNumeroReferencia.Leave += new System.EventHandler(this.tbxNumeroReferencia_Leave);
            // 
            // cmbTipoDocReferencia
            // 
            this.cmbTipoDocReferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDocReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoDocReferencia.FormattingEnabled = true;
            this.cmbTipoDocReferencia.Items.AddRange(new object[] {
            "FE",
            "NC",
            "ND"});
            this.cmbTipoDocReferencia.Location = new System.Drawing.Point(313, 136);
            this.cmbTipoDocReferencia.Name = "cmbTipoDocReferencia";
            this.cmbTipoDocReferencia.Size = new System.Drawing.Size(247, 28);
            this.cmbTipoDocReferencia.TabIndex = 22;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(82, 140);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(154, 20);
            this.label27.TabIndex = 21;
            this.label27.Text = "Tipo Doc Referencia";
            // 
            // cmbTipoReferencia
            // 
            this.cmbTipoReferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoReferencia.FormattingEnabled = true;
            this.cmbTipoReferencia.Items.AddRange(new object[] {
            "Ninguna",
            "Referencia Factura",
            "Otra Referencia"});
            this.cmbTipoReferencia.Location = new System.Drawing.Point(313, 36);
            this.cmbTipoReferencia.Name = "cmbTipoReferencia";
            this.cmbTipoReferencia.Size = new System.Drawing.Size(247, 28);
            this.cmbTipoReferencia.TabIndex = 16;
            this.cmbTipoReferencia.SelectedIndexChanged += new System.EventHandler(this.cmbTipoReferencia_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(82, 190);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(169, 20);
            this.label28.TabIndex = 20;
            this.label28.Text = "Fecha Doc Referencia";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(82, 90);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(147, 20);
            this.label29.TabIndex = 17;
            this.label29.Text = "Número Referencia";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(82, 40);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(121, 20);
            this.label30.TabIndex = 15;
            this.label30.Text = "Tipo Referencia";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.tbxMailOculto);
            this.tabPage6.Controls.Add(this.tbxMailPara);
            this.tabPage6.Controls.Add(this.tbxMailCopia);
            this.tabPage6.Controls.Add(this.label31);
            this.tabPage6.Controls.Add(this.label33);
            this.tabPage6.Controls.Add(this.label34);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1318, 505);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Despacho";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tbxMailOculto
            // 
            this.tbxMailOculto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMailOculto.Location = new System.Drawing.Point(313, 140);
            this.tbxMailOculto.Name = "tbxMailOculto";
            this.tbxMailOculto.Size = new System.Drawing.Size(247, 26);
            this.tbxMailOculto.TabIndex = 33;
            // 
            // tbxMailPara
            // 
            this.tbxMailPara.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMailPara.Location = new System.Drawing.Point(313, 37);
            this.tbxMailPara.Name = "tbxMailPara";
            this.tbxMailPara.Size = new System.Drawing.Size(247, 26);
            this.tbxMailPara.TabIndex = 32;
            // 
            // tbxMailCopia
            // 
            this.tbxMailCopia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMailCopia.Location = new System.Drawing.Point(313, 89);
            this.tbxMailCopia.Name = "tbxMailCopia";
            this.tbxMailCopia.Size = new System.Drawing.Size(247, 26);
            this.tbxMailCopia.TabIndex = 31;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(82, 143);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(87, 20);
            this.label31.TabIndex = 29;
            this.label31.Text = "Mail Oculto";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(82, 92);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(82, 20);
            this.label33.TabIndex = 27;
            this.label33.Text = "Mail Copia";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(82, 40);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(74, 20);
            this.label34.TabIndex = 25;
            this.label34.Text = "Mail Para";
            // 
            // tbxRutaDestino
            // 
            this.tbxRutaDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRutaDestino.Location = new System.Drawing.Point(100, 573);
            this.tbxRutaDestino.Name = "tbxRutaDestino";
            this.tbxRutaDestino.Size = new System.Drawing.Size(474, 26);
            this.tbxRutaDestino.TabIndex = 15;
            // 
            // btnGenerarDocumento
            // 
            this.btnGenerarDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarDocumento.Location = new System.Drawing.Point(1117, 564);
            this.btnGenerarDocumento.Name = "btnGenerarDocumento";
            this.btnGenerarDocumento.Size = new System.Drawing.Size(217, 44);
            this.btnGenerarDocumento.TabIndex = 1;
            this.btnGenerarDocumento.Text = "GENERAR";
            this.btnGenerarDocumento.UseVisualStyleBackColor = true;
            this.btnGenerarDocumento.Click += new System.EventHandler(this.btnGenerarDocumento_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExaminar.Location = new System.Drawing.Point(580, 573);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(141, 26);
            this.btnExaminar.TabIndex = 16;
            this.btnExaminar.Text = "EXAMINAR";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbAsigAuto
            // 
            this.cmbAsigAuto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAsigAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAsigAuto.FormattingEnabled = true;
            this.cmbAsigAuto.Items.AddRange(new object[] {
            "NO",
            "SI"});
            this.cmbAsigAuto.Location = new System.Drawing.Point(311, 79);
            this.cmbAsigAuto.Name = "cmbAsigAuto";
            this.cmbAsigAuto.Size = new System.Drawing.Size(247, 28);
            this.cmbAsigAuto.TabIndex = 16;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(80, 83);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(125, 20);
            this.label32.TabIndex = 15;
            this.label32.Text = "Asig Automatica";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 658);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.tbxRutaDestino);
            this.Controls.Add(this.btnGenerarDocumento);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Generador Json FECO";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEmpresaEmisora;
        private System.Windows.Forms.TextBox tbxCorrelativoDocumento;
        private System.Windows.Forms.TextBox tbxCantidadDocumento;
        private System.Windows.Forms.ComboBox cmbSeriePrefijo;
        private System.Windows.Forms.ComboBox cmbIdArea;
        private System.Windows.Forms.ComboBox cmbTipoDocumento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbRegimenEmisor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTipoIdentificacionEmisor;
        private System.Windows.Forms.ComboBox cmbMonedaDocumento;
        private System.Windows.Forms.ComboBox cmbTipoOperacion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbMetodoCarga;
        private System.Windows.Forms.DateTimePicker dtpFechaHoraEmision;
        private System.Windows.Forms.ComboBox cmbRegimenAdquiriente;
        private System.Windows.Forms.ComboBox cmbTipoIdentificacionAdquiriente;
        private System.Windows.Forms.ComboBox cmbResponsabilidadAdquiriente;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbResponsabilidadEmisor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbEmpresaAdquiriente;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cmbMedioPago;
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox tbxCantidadItems;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbUnidadMedida;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbImpuestoItem;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmbCodReferenciaItems;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbxCantidadRefItems;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tbxValorCodigo;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cmbCodigoItems;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ComboBox cmbTipoDocReferencia;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cmbTipoReferencia;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox tbxNumeroReferencia;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TextBox tbxMailCopia;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox tbxMailOculto;
        private System.Windows.Forms.TextBox tbxMailPara;
        private System.Windows.Forms.TextBox tbxRutaDestino;
        private System.Windows.Forms.Button btnGenerarDocumento;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DateTimePicker dtpFechaDocReferencia;
        private System.Windows.Forms.ComboBox cmbAsigAuto;
        private System.Windows.Forms.Label label32;
    }
}

