namespace CapaPresentacion
{
    partial class FrmInformeMovimientoCaja
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DsReporte = new CapaPresentacion.DsReporte();
            this.sp_ReporteMovimientoCajaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ReporteMovimientoCajaTableAdapter = new CapaPresentacion.DsReporteTableAdapters.sp_ReporteMovimientoCajaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteMovimientoCajaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsMovimientoCaja";
            reportDataSource1.Value = this.sp_ReporteMovimientoCajaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.ReporteMovimientoCaja.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(883, 514);
            this.reportViewer1.TabIndex = 0;
            // 
            // DsReporte
            // 
            this.DsReporte.DataSetName = "DsReporte";
            this.DsReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_ReporteMovimientoCajaBindingSource
            // 
            this.sp_ReporteMovimientoCajaBindingSource.DataMember = "sp_ReporteMovimientoCaja";
            this.sp_ReporteMovimientoCajaBindingSource.DataSource = this.DsReporte;
            // 
            // sp_ReporteMovimientoCajaTableAdapter
            // 
            this.sp_ReporteMovimientoCajaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmInformeMovimientoCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 514);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmInformeMovimientoCaja";
            this.Text = "FrmInformeMovimientoCaja";
            this.Load += new System.EventHandler(this.FrmInformeMovimientoCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteMovimientoCajaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_ReporteMovimientoCajaBindingSource;
        private DsReporte DsReporte;
        private DsReporteTableAdapters.sp_ReporteMovimientoCajaTableAdapter sp_ReporteMovimientoCajaTableAdapter;
    }
}