﻿using CapaPresentacion.Informes;
namespace CapaPresentacion
{
    partial class FrmVentasFiltro
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
            this.sp_ReporteVentaPorFechaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsReporte = new Informes.DsReporte();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_ReporteVentaPorFechaTableAdapter = new Informes.DsReporteTableAdapters.sp_ReporteVentaPorFechaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteVentaPorFechaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_ReporteVentaPorFechaBindingSource
            // 
            this.sp_ReporteVentaPorFechaBindingSource.DataMember = "sp_ReporteVentaPorFecha";
            this.sp_ReporteVentaPorFechaBindingSource.DataSource = this.DsReporte;
            // 
            // DsReporte
            // 
            this.DsReporte.DataSetName = "DsReporte";
            this.DsReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsVentasFiltro";
            reportDataSource1.Value = this.sp_ReporteVentaPorFechaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.RptReporteVentasFiltro.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(809, 530);
            this.reportViewer1.TabIndex = 0;
            // 
            // sp_ReporteVentaPorFechaTableAdapter
            // 
            this.sp_ReporteVentaPorFechaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmVentasFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 530);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmVentasFiltro";
            this.Text = "Reporte de Ventas";
            this.Load += new System.EventHandler(this.FrmVentasFiltro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteVentaPorFechaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_ReporteVentaPorFechaBindingSource;
        private DsReporte DsReporte;
        public Informes.DsReporteTableAdapters.sp_ReporteVentaPorFechaTableAdapter sp_ReporteVentaPorFechaTableAdapter;
    }
}