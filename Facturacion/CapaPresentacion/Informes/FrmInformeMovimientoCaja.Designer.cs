using CapaPresentacion.Informes;

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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.spMostrarCabeceraArqueoCajaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spMostrarDetalleArqueoCajaBindingSource = new System.Windows.Forms.BindingSource(this.components);            

            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DsReporte = new Informes.DsReporte();
            this.sp_MostrarCabeceraArqueoCajaTableAdapter = new Informes.DsReporteTableAdapters.sp_MostrarCabeceraArqueoCajaTableAdapter();
            this.sp_MostrarDetalleArqueoCajaTableAdapter = new Informes.DsReporteTableAdapters.sp_MostrarDetalleArqueoCajaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spMostrarCabeceraArqueoCajaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMostrarDetalleArqueoCajaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_ReporteFacturaBindingSource
            // 
            this.spMostrarCabeceraArqueoCajaBindingSource.DataMember = "sp_MostrarCabeceraArqueoCaja";
            this.spMostrarCabeceraArqueoCajaBindingSource.DataSource = this.DsReporte;
            // 
            // DsReporte
            // 
            this.DsReporte.DataSetName = "DsReporte";
            this.DsReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spReporteFacturaDetalleBindingSource
            // 
            this.spMostrarDetalleArqueoCajaBindingSource.DataMember = "sp_MostrarDetalleArqueoCaja";
            this.spMostrarDetalleArqueoCajaBindingSource.DataSource = this.DsReporte;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsCabecera";
            reportDataSource1.Value = this.spMostrarCabeceraArqueoCajaBindingSource;
            reportDataSource2.Name = "DsDetalle";
            reportDataSource2.Value = this.spMostrarDetalleArqueoCajaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.ReporteMovimientoCaja.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(883, 514);
            this.reportViewer1.TabIndex = 0;
            // 
            // DsReporte
            // 
            this.DsReporte.DataSetName = "DsReporte";
            this.DsReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_MostrarCabeceraArqueoCajaTableAdapter
            // 
            this.sp_MostrarCabeceraArqueoCajaTableAdapter.ClearBeforeFill = true;
            // 
            // sp_MostrarDetalleArqueoCajaTableAdapter
            // 
            this.sp_MostrarDetalleArqueoCajaTableAdapter.ClearBeforeFill = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.spMostrarCabeceraArqueoCajaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMostrarDetalleArqueoCajaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_ReporteMovimientoCajaBindingSource;
        private System.Windows.Forms.BindingSource spMostrarCabeceraArqueoCajaBindingSource;
        private System.Windows.Forms.BindingSource spMostrarDetalleArqueoCajaBindingSource;
        private Informes.DsReporteTableAdapters.sp_MostrarCabeceraArqueoCajaTableAdapter sp_MostrarCabeceraArqueoCajaTableAdapter;
        private Informes.DsReporteTableAdapters.sp_MostrarDetalleArqueoCajaTableAdapter sp_MostrarDetalleArqueoCajaTableAdapter;
        private DsReporte DsReporte;
    }
}