namespace CapaPresentacion
{
    partial class FrmInformeMovimiento
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
            this.sp_ReporteMovimientoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsReporte = new CapaPresentacion.DsReporte();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sp_ReporteMovimientoTableAdapter = new CapaPresentacion.DsReporteTableAdapters.sp_ReporteMovimientoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteMovimientoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_ReporteMovimientoBindingSource
            // 
            this.sp_ReporteMovimientoBindingSource.DataMember = "sp_ReporteMovimiento";
            this.sp_ReporteMovimientoBindingSource.DataSource = this.DsReporte;
            // 
            // DsReporte
            // 
            this.DsReporte.DataSetName = "DsReporte";
            this.DsReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DsInformeMovimiento";
            reportDataSource1.Value = this.sp_ReporteMovimientoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.RptInformeMovimiento.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 54);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(787, 471);
            this.reportViewer1.TabIndex = 0;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(493, 14);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(87, 23);
            this.btnGenerar.TabIndex = 15;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(382, 16);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(107, 20);
            this.dtpHasta.TabIndex = 14;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(200, 16);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(109, 20);
            this.dtpDesde.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label2.Location = new System.Drawing.Point(337, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label1.Location = new System.Drawing.Point(148, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Desde:";
            // 
            // sp_ReporteMovimientoTableAdapter
            // 
            this.sp_ReporteMovimientoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmInformeMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 560);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmInformeMovimiento";
            this.Text = "Informe Movimientos";
            this.Load += new System.EventHandler(this.FrmInformeMovimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteMovimientoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).EndInit();
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
        private System.Windows.Forms.BindingSource sp_ReporteMovimientoBindingSource;
        private DsReporte DsReporte;
        private DsReporteTableAdapters.sp_ReporteMovimientoTableAdapter sp_ReporteMovimientoTableAdapter;
    }
}