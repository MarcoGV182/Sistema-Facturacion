namespace CapaPresentacion
{
    partial class FrmLibroVentas
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.DsReporte = new CapaPresentacion.DsReporte();
            this.sp_LibroVentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_LibroVentaTableAdapter = new CapaPresentacion.DsReporteTableAdapters.sp_LibroVentaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_LibroVentaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DsLibroVenta";
            reportDataSource2.Value = this.sp_LibroVentaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.RptLibroVenta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(14, 43);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1090, 482);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label1.Location = new System.Drawing.Point(250, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label2.Location = new System.Drawing.Point(439, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(302, 10);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(109, 23);
            this.dtpDesde.TabIndex = 3;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(484, 10);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(107, 23);
            this.dtpHasta.TabIndex = 4;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(595, 7);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(87, 27);
            this.btnGenerar.TabIndex = 5;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // DsReporte
            // 
            this.DsReporte.DataSetName = "DsReporte";
            this.DsReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_LibroVentaBindingSource
            // 
            this.sp_LibroVentaBindingSource.DataMember = "sp_LibroVenta";
            this.sp_LibroVentaBindingSource.DataSource = this.DsReporte;
            // 
            // sp_LibroVentaTableAdapter
            // 
            this.sp_LibroVentaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmLibroVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 534);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.Name = "FrmLibroVentas";
            this.Text = "Libro de Ventas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLibroVentas_FormClosing);
            this.Load += new System.EventHandler(this.FrmLibroVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_LibroVentaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnGenerar;
        private DsReporte DsReporte;
        private System.Windows.Forms.BindingSource sp_LibroVentaBindingSource;
        private DsReporteTableAdapters.sp_LibroVentaTableAdapter sp_LibroVentaTableAdapter;
    }
}