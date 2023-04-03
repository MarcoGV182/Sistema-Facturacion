namespace CapaPresentacion
{
    partial class FrmComprobanteVenta
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.sp_ReporteFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsReporte = new CapaPresentacion.DsReporte();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_ReporteFacturaTableAdapter = new CapaPresentacion.DsReporteTableAdapters.sp_ReporteFacturaTableAdapter();
            this.spReporteFacturaDetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ReporteFacturaDetalleTableAdapter = new CapaPresentacion.DsReporteTableAdapters.sp_ReporteFacturaDetalleTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteFacturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spReporteFacturaDetalleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_ReporteFacturaBindingSource
            // 
            this.sp_ReporteFacturaBindingSource.DataMember = "sp_ReporteFactura";
            this.sp_ReporteFacturaBindingSource.DataSource = this.DsReporte;
            // 
            // DsReporte
            // 
            this.DsReporte.DataSetName = "DsReporte";
            this.DsReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSFactura";
            reportDataSource1.Value = this.sp_ReporteFacturaBindingSource;
            reportDataSource2.Name = "DsDetalle";
            reportDataSource2.Value = this.spReporteFacturaDetalleBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.RptFacturaFormato.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(865, 559);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            this.reportViewer1.Load += new System.EventHandler(this.FrmComprobanteVenta_Load);
            // 
            // sp_ReporteFacturaTableAdapter
            // 
            this.sp_ReporteFacturaTableAdapter.ClearBeforeFill = true;
            // 
            // spReporteFacturaDetalleBindingSource
            // 
            this.spReporteFacturaDetalleBindingSource.DataMember = "sp_ReporteFacturaDetalle";
            this.spReporteFacturaDetalleBindingSource.DataSource = this.DsReporte;
            // 
            // sp_ReporteFacturaDetalleTableAdapter
            // 
            this.sp_ReporteFacturaDetalleTableAdapter.ClearBeforeFill = true;
            // 
            // FrmComprobanteVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 559);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmComprobanteVenta";
            this.Text = "Factura Venta";
            this.Load += new System.EventHandler(this.FrmComprobanteVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteFacturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spReporteFacturaDetalleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_ReporteFacturaBindingSource;
        private DsReporte DsReporte;
        private DsReporteTableAdapters.sp_ReporteFacturaTableAdapter sp_ReporteFacturaTableAdapter;
        private System.Windows.Forms.BindingSource spReporteFacturaDetalleBindingSource;
        private DsReporteTableAdapters.sp_ReporteFacturaDetalleTableAdapter sp_ReporteFacturaDetalleTableAdapter;
    }
}