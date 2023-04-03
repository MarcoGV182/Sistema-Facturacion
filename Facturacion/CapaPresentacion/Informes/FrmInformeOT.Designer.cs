namespace CapaPresentacion
{
    partial class FrmInformeOT
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
            this.sp_ReporteOTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsReporte = new CapaPresentacion.DsReporte();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_ReporteOTTableAdapter = new CapaPresentacion.DsReporteTableAdapters.sp_ReporteOTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteOTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_ReporteOTBindingSource
            // 
            this.sp_ReporteOTBindingSource.DataMember = "sp_ReporteOT";
            this.sp_ReporteOTBindingSource.DataSource = this.DsReporte;
            // 
            // DsReporte
            // 
            this.DsReporte.DataSetName = "DsReporte";
            this.DsReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsOT";
            reportDataSource1.Value = this.sp_ReporteOTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.RptInformeOT.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(817, 536);
            this.reportViewer1.TabIndex = 0;
            // 
            // sp_ReporteOTTableAdapter
            // 
            this.sp_ReporteOTTableAdapter.ClearBeforeFill = true;
            // 
            // FrmInformeOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 536);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmInformeOT";
            this.Text = "OT";
            this.Load += new System.EventHandler(this.FrmInformeOT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteOTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_ReporteOTBindingSource;
        private DsReporte DsReporte;
        private DsReporteTableAdapters.sp_ReporteOTTableAdapter sp_ReporteOTTableAdapter;
    }
}