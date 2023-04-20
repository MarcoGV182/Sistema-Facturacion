using CapaPresentacion.Informes;
namespace CapaPresentacion
{
    partial class FrmInformePagosProveedor
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
            this.DsReporte = new Informes.DsReporte();
            this.sp_ReportePagosProveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ReportePagosProveedorTableAdapter = new Informes.DsReporteTableAdapters.sp_ReportePagosProveedorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReportePagosProveedorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsReportePagosProveedor";
            reportDataSource1.Value = this.sp_ReportePagosProveedorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.RptInformePagosProveedor.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(788, 516);
            this.reportViewer1.TabIndex = 0;
            // 
            // DsReporte
            // 
            this.DsReporte.DataSetName = "DsReporte";
            this.DsReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_ReportePagosProveedorBindingSource
            // 
            this.sp_ReportePagosProveedorBindingSource.DataMember = "sp_ReportePagosProveedor";
            this.sp_ReportePagosProveedorBindingSource.DataSource = this.DsReporte;
            // 
            // sp_ReportePagosProveedorTableAdapter
            // 
            this.sp_ReportePagosProveedorTableAdapter.ClearBeforeFill = true;
            // 
            // FrmInformePagosProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 516);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmInformePagosProveedor";
            this.Text = "PAGOS CLIENTE";
            this.Load += new System.EventHandler(this.FrmInformePagosCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReportePagosProveedorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_ReportePagosProveedorBindingSource;
        private DsReporte DsReporte;
        private Informes.DsReporteTableAdapters.sp_ReportePagosProveedorTableAdapter sp_ReportePagosProveedorTableAdapter;
    }
}