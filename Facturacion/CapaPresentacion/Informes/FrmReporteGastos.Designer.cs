namespace CapaPresentacion
{
    partial class FrmReporteGastos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DsReporte = new CapaPresentacion.DsReporte();
            this.sp_ReporteGastosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ReporteGastosTableAdapter = new CapaPresentacion.DsReporteTableAdapters.sp_ReporteGastosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteGastosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource3.Name = "DsReporteGasto";
            reportDataSource3.Value = this.sp_ReporteGastosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.RptInformeGastos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 49);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(819, 357);
            this.reportViewer1.TabIndex = 0;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(530, 9);
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
            this.dtpHasta.Location = new System.Drawing.Point(419, 12);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(107, 20);
            this.dtpHasta.TabIndex = 9;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(237, 12);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(109, 20);
            this.dtpDesde.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label2.Location = new System.Drawing.Point(374, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label1.Location = new System.Drawing.Point(185, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Desde:";
            // 
            // DsReporte
            // 
            this.DsReporte.DataSetName = "DsReporte";
            this.DsReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_ReporteGastosBindingSource
            // 
            this.sp_ReporteGastosBindingSource.DataMember = "sp_ReporteGastos";
            this.sp_ReporteGastosBindingSource.DataSource = this.DsReporte;
            // 
            // sp_ReporteGastosTableAdapter
            // 
            this.sp_ReporteGastosTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 418);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteGastos";
            this.Text = "Informe Gastos";
            this.Load += new System.EventHandler(this.FrmReporteGastos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteGastosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource sp_ReporteGastosBindingSource;
        private DsReporte DsReporte;
        private DsReporteTableAdapters.sp_ReporteGastosTableAdapter sp_ReporteGastosTableAdapter;
    }
}