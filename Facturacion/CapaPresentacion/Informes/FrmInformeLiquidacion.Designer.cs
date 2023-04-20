using CapaPresentacion.Informes;
namespace CapaPresentacion
{
    partial class FrmInformeLiquidacion
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DsReporte = new DsReporte();
            this.sp_ReporteLiquidacionFinalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ReporteLiquidacionFinalTableAdapter = new Informes.DsReporteTableAdapters.sp_ReporteLiquidacionFinalTableAdapter();
            this.sp_ReporteDetalleLiquidacionFinalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ReporteDetalleLiquidacionFinalTableAdapter = new Informes.DsReporteTableAdapters.sp_ReporteDetalleLiquidacionFinalTableAdapter();
            this.sp_ReporteServiciosRealizadosUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ReporteServiciosRealizadosUsuarioTableAdapter = new Informes.DsReporteTableAdapters.sp_ReporteServiciosRealizadosUsuarioTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteLiquidacionFinalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteDetalleLiquidacionFinalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteServiciosRealizadosUsuarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(266, 12);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(303, 21);
            this.cboEmpleado.TabIndex = 1;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(575, 12);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(61, 23);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DsInformeLiquidacion";
            reportDataSource1.Value = this.sp_ReporteLiquidacionFinalBindingSource;
            reportDataSource2.Name = "DsInformeDetalleLiquidacion";
            reportDataSource2.Value = this.sp_ReporteDetalleLiquidacionFinalBindingSource;
            reportDataSource3.Name = "DataSetServiciosRealizados";
            reportDataSource3.Value = this.sp_ReporteServiciosRealizadosUsuarioBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.RptInformeLiquidacion.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 39);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(842, 459);
            this.reportViewer1.TabIndex = 3;
            // 
            // DsReporte
            // 
            this.DsReporte.DataSetName = "DsReporte";
            this.DsReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_ReporteLiquidacionFinalBindingSource
            // 
            this.sp_ReporteLiquidacionFinalBindingSource.DataMember = "sp_ReporteLiquidacionFinal";
            this.sp_ReporteLiquidacionFinalBindingSource.DataSource = this.DsReporte;
            // 
            // sp_ReporteLiquidacionFinalTableAdapter
            // 
            this.sp_ReporteLiquidacionFinalTableAdapter.ClearBeforeFill = true;
            // 
            // sp_ReporteDetalleLiquidacionFinalBindingSource
            // 
            this.sp_ReporteDetalleLiquidacionFinalBindingSource.DataMember = "sp_ReporteDetalleLiquidacionFinal";
            this.sp_ReporteDetalleLiquidacionFinalBindingSource.DataSource = this.DsReporte;
            // 
            // sp_ReporteDetalleLiquidacionFinalTableAdapter
            // 
            this.sp_ReporteDetalleLiquidacionFinalTableAdapter.ClearBeforeFill = true;
            // 
            // sp_ReporteServiciosRealizadosUsuarioBindingSource
            // 
            this.sp_ReporteServiciosRealizadosUsuarioBindingSource.DataMember = "sp_ReporteServiciosRealizadosUsuario";
            this.sp_ReporteServiciosRealizadosUsuarioBindingSource.DataSource = this.DsReporte;
            // 
            // sp_ReporteServiciosRealizadosUsuarioTableAdapter
            // 
            this.sp_ReporteServiciosRealizadosUsuarioTableAdapter.ClearBeforeFill = true;
            // 
            // FrmInformeLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 505);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.cboEmpleado);
            this.Name = "FrmInformeLiquidacion";
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.FrmInformeLiquidacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteLiquidacionFinalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteDetalleLiquidacionFinalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteServiciosRealizadosUsuarioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cboEmpleado;
        private System.Windows.Forms.Button btnGenerar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_ReporteLiquidacionFinalBindingSource;
        private DsReporte DsReporte;
        private System.Windows.Forms.BindingSource sp_ReporteDetalleLiquidacionFinalBindingSource;
        private System.Windows.Forms.BindingSource sp_ReporteServiciosRealizadosUsuarioBindingSource;
        private Informes.DsReporteTableAdapters.sp_ReporteLiquidacionFinalTableAdapter sp_ReporteLiquidacionFinalTableAdapter;
        private Informes.DsReporteTableAdapters.sp_ReporteDetalleLiquidacionFinalTableAdapter sp_ReporteDetalleLiquidacionFinalTableAdapter;
        private Informes.DsReporteTableAdapters.sp_ReporteServiciosRealizadosUsuarioTableAdapter sp_ReporteServiciosRealizadosUsuarioTableAdapter;
    }
}