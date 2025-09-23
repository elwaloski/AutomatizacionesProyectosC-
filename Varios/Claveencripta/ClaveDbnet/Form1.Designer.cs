namespace ClaveDbnet
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxbDesencripta = new System.Windows.Forms.TextBox();
            this.TxBEncripta = new System.Windows.Forms.TextBox();
            this.BtnDesencripta = new System.Windows.Forms.Button();
            this.BtnEncripta = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxbDesencripta);
            this.groupBox1.Controls.Add(this.TxBEncripta);
            this.groupBox1.Controls.Add(this.BtnDesencripta);
            this.groupBox1.Controls.Add(this.BtnEncripta);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // TxbDesencripta
            // 
            this.TxbDesencripta.Location = new System.Drawing.Point(161, 36);
            this.TxbDesencripta.Name = "TxbDesencripta";
            this.TxbDesencripta.Size = new System.Drawing.Size(100, 20);
            this.TxbDesencripta.TabIndex = 3;
            // 
            // TxBEncripta
            // 
            this.TxBEncripta.Location = new System.Drawing.Point(38, 36);
            this.TxBEncripta.Name = "TxBEncripta";
            this.TxBEncripta.Size = new System.Drawing.Size(100, 20);
            this.TxBEncripta.TabIndex = 2;
            // 
            // BtnDesencripta
            // 
            this.BtnDesencripta.Location = new System.Drawing.Point(161, 69);
            this.BtnDesencripta.Name = "BtnDesencripta";
            this.BtnDesencripta.Size = new System.Drawing.Size(100, 37);
            this.BtnDesencripta.TabIndex = 1;
            this.BtnDesencripta.Text = "Desencripta";
            this.BtnDesencripta.UseVisualStyleBackColor = true;
            this.BtnDesencripta.Click += new System.EventHandler(this.BtnDesencripta_Click);
            // 
            // BtnEncripta
            // 
            this.BtnEncripta.Location = new System.Drawing.Point(38, 69);
            this.BtnEncripta.Name = "BtnEncripta";
            this.BtnEncripta.Size = new System.Drawing.Size(100, 37);
            this.BtnEncripta.TabIndex = 0;
            this.BtnEncripta.Text = "Encripta";
            this.BtnEncripta.UseVisualStyleBackColor = true;
            this.BtnEncripta.Click += new System.EventHandler(this.BtnEncripta_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 156);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Encripta/Desencripta Dbnet";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxbDesencripta;
        private System.Windows.Forms.TextBox TxBEncripta;
        private System.Windows.Forms.Button BtnDesencripta;
        private System.Windows.Forms.Button BtnEncripta;
    }
}

