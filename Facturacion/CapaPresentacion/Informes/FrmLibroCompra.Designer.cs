namespace CapaPresentacion
{
    partial class FrmLibroCompra
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.sp_LibroCompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsReporte = new CapaPresentacion.DsReporte();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_LibroCompraTableAdapter = new CapaPresentacion.DsReporteTableAdapters.sp_LibroCompraTableAdapter();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sp_LibroCompraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_LibroCompraBindingSource
            // 
            this.sp_LibroCompraBindingSource.DataMember = "sp_LibroCompra";
            this.sp_LibroCompraBindingSource.DataSource = this.DsReporte;
            // 
            // DsReporte
            // 
            this.DsReporte.DataSetName = "DsReporte";
            this.DsReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DsLibroCompras";
            reportDataSource1.Value = this.sp_LibroCompraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.RptLibroCompras.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 58);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1008, 434);
            this.reportViewer1.TabIndex = 0;
            // 
            // sp_LibroCompraTableAdapter
            // 
            this.sp_LibroCompraTableAdapter.ClearBeforeFill = true;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(568, 11);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(87, 27);
            this.btnGenerar.TabIndex = 10;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(457, 14);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(107, 20);
            this.dtpHasta.TabIndex = 9;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(275, 14);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(109, 20);
            this.dtpDesde.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label2.Location = new System.Drawing.Point(412, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label1.Location = new System.Drawing.Point(223, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Desde:";
            // 
            // FrmLibroCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 504);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmLibroCompra";
            this.Text = "Libro de Compras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLibroCompra_FormClosing);
            this.Load += new System.EventHandler(this.FrmLibroCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_LibroCompraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_LibroCompraBindingSource;
        private DsReporte DsReporte;
        private DsReporteTableAdapters.sp_LibroCompraTableAdapter sp_LibroCompraTableAdapter;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}