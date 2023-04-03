namespace CapaPresentacion
{
    partial class FrmImportarPersonaExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportarPersonaExcel));
            this.btnImportar = new System.Windows.Forms.Button();
            this.dataExcel = new System.Windows.Forms.DataGridView();
            this.btnguardar = new System.Windows.Forms.Button();
            this.txturl = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(400, 32);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(64, 23);
            this.btnImportar.TabIndex = 0;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // dataExcel
            // 
            this.dataExcel.AllowUserToAddRows = false;
            this.dataExcel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataExcel.BackgroundColor = System.Drawing.Color.White;
            this.dataExcel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataExcel.Location = new System.Drawing.Point(12, 88);
            this.dataExcel.Name = "dataExcel";
            this.dataExcel.Size = new System.Drawing.Size(554, 263);
            this.dataExcel.TabIndex = 1;
            this.dataExcel.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataExcel_RowsRemoved);
            // 
            // btnguardar
            // 
            this.btnguardar.Location = new System.Drawing.Point(400, 357);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(75, 23);
            this.btnguardar.TabIndex = 2;
            this.btnguardar.Text = "Insertar";
            this.btnguardar.UseVisualStyleBackColor = true;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // txturl
            // 
            this.txturl.Location = new System.Drawing.Point(71, 34);
            this.txturl.Name = "txturl";
            this.txturl.Size = new System.Drawing.Size(323, 20);
            this.txturl.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.Ncrow_Mega_Pack_1_Excel;
            this.pictureBox1.Location = new System.Drawing.Point(31, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(364, 72);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 13);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Total de registros: 0";
            // 
            // FrmImportarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(579, 395);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txturl);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.dataExcel);
            this.Controls.Add(this.btnImportar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmImportarPersona";
            this.Text = "Importar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmImportarPersona_FormClosing);
            this.Load += new System.EventHandler(this.FrmImportarPersona_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.DataGridView dataExcel;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.TextBox txturl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTotal;
    }
}