﻿namespace CapaPresentacion
{
    partial class FrmComprasFiltro
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
            this.sp_ReporteCompraPorFechaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsReporte = new CapaPresentacion.DsReporte();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_ReporteCompraPorFechaTableAdapter = new CapaPresentacion.DsReporteTableAdapters.sp_ReporteCompraPorFechaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteCompraPorFechaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_ReporteCompraPorFechaBindingSource
            // 
            this.sp_ReporteCompraPorFechaBindingSource.DataMember = "sp_ReporteCompraPorFecha";
            this.sp_ReporteCompraPorFechaBindingSource.DataSource = this.DsReporte;
            // 
            // DsReporte
            // 
            this.DsReporte.DataSetName = "DsReporte";
            this.DsReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsReporteCompras";
            reportDataSource1.Value = this.sp_ReporteCompraPorFechaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.RptReporteComprasFiltro.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(822, 549);
            this.reportViewer1.TabIndex = 0;
            // 
            // sp_ReporteCompraPorFechaTableAdapter
            // 
            this.sp_ReporteCompraPorFechaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmComprasFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 549);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmComprasFiltro";
            this.Text = "Reporte de Compras";
            this.Load += new System.EventHandler(this.FrmComprasFiltro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteCompraPorFechaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_ReporteCompraPorFechaBindingSource;
        private DsReporte DsReporte;
        private DsReporteTableAdapters.sp_ReporteCompraPorFechaTableAdapter sp_ReporteCompraPorFechaTableAdapter;
    }
}