namespace CapaPresentacion
{
    partial class FrmInformePagosCliente
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
            this.DsReporte = new CapaPresentacion.DsReporte();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_ReportePagosClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ReportePagosClienteTableAdapter = new CapaPresentacion.DsReporteTableAdapters.sp_ReportePagosClienteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReportePagosClienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DsReporte
            // 
            this.DsReporte.DataSetName = "DsReporte";
            this.DsReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsReportePagosCliente";
            reportDataSource1.Value = this.sp_ReportePagosClienteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.RptInformePagosCliente.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(788, 516);
            this.reportViewer1.TabIndex = 0;
            // 
            // sp_ReportePagosClienteBindingSource
            // 
            this.sp_ReportePagosClienteBindingSource.DataMember = "sp_ReportePagosCliente";
            this.sp_ReportePagosClienteBindingSource.DataSource = this.DsReporte;
            // 
            // sp_ReportePagosClienteTableAdapter
            // 
            this.sp_ReportePagosClienteTableAdapter.ClearBeforeFill = true;
            // 
            // FrmInformePagosCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 516);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmInformePagosCliente";
            this.Text = "PAGOS CLIENTE";
            this.Load += new System.EventHandler(this.FrmInformePagosCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReportePagosClienteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DsReporte DsReporte;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_ReportePagosClienteBindingSource;
        private DsReporteTableAdapters.sp_ReportePagosClienteTableAdapter sp_ReportePagosClienteTableAdapter;
    }
}