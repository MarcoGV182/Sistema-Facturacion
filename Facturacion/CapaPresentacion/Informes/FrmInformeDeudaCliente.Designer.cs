namespace CapaPresentacion
{
    partial class FrmInformeDeudaCliente
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
            this.sp_ReporteDeudasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ReporteDeudasTableAdapter = new CapaPresentacion.DsReporteTableAdapters.sp_ReporteDeudasTableAdapter();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteDeudasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DsDeudaCliente";
            reportDataSource1.Value = this.sp_ReporteDeudasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.RptReporteDeudasCliente.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(7, 45);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(722, 429);
            this.reportViewer1.TabIndex = 0;
            // 
            // DsReporte
            // 
            this.DsReporte.DataSetName = "DsReporte";
            this.DsReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_ReporteDeudasBindingSource
            // 
            this.sp_ReporteDeudasBindingSource.DataMember = "sp_ReporteDeudas";
            this.sp_ReporteDeudasBindingSource.DataSource = this.DsReporte;
            // 
            // sp_ReporteDeudasTableAdapter
            // 
            this.sp_ReporteDeudasTableAdapter.ClearBeforeFill = true;
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "PENDIENTE",
            "CANCELADO"});
            this.cboEstado.Location = new System.Drawing.Point(80, 12);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(144, 21);
            this.cboEstado.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Estado:";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(228, 11);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // FrmInformeDeudaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 503);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmInformeDeudaCliente";
            this.Text = "Informe de Deudas";
            this.Load += new System.EventHandler(this.FrmInformeDeudaCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteDeudasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_ReporteDeudasBindingSource;
        private DsReporte DsReporte;
        private DsReporteTableAdapters.sp_ReporteDeudasTableAdapter sp_ReporteDeudasTableAdapter;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerar;
    }
}