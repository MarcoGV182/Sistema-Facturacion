namespace CapaPresentacion.Informes
{
    partial class FrmInformeVentaColaborador
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
            this.nInformeVentaColaboradorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eDetalleInformeVentaColaboradorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.cboColaborador = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.nInformeVentaColaboradorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eDetalleInformeVentaColaboradorBindingSource)).BeginInit();
            this.gbFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // nInformeVentaColaboradorBindingSource
            // 
            this.nInformeVentaColaboradorBindingSource.DataSource = typeof(CapaNegocio.Reporting.NInformeVentaColaborador);
            // 
            // eDetalleInformeVentaColaboradorBindingSource
            // 
            this.eDetalleInformeVentaColaboradorBindingSource.DataSource = typeof(CapaEntidades.Reporting.EDetalleInformeVentaColaborador);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DsInformeVentaColaboradorCab";
            reportDataSource1.Value = this.nInformeVentaColaboradorBindingSource;
            reportDataSource2.Name = "DsInformeVentaColaboradorDet";
            reportDataSource2.Value = this.eDetalleInformeVentaColaboradorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.RptInformeVentaColaborador.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(5, 127);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(909, 474);
            this.reportViewer1.TabIndex = 0;
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.cboColaborador);
            this.gbFiltro.Controls.Add(this.label3);
            this.gbFiltro.Controls.Add(this.label1);
            this.gbFiltro.Controls.Add(this.btnConsultar);
            this.gbFiltro.Controls.Add(this.label2);
            this.gbFiltro.Controls.Add(this.dtpHasta);
            this.gbFiltro.Controls.Add(this.dtpDesde);
            this.gbFiltro.Location = new System.Drawing.Point(5, -1);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(701, 122);
            this.gbFiltro.TabIndex = 7;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtro";
            // 
            // cboColaborador
            // 
            this.cboColaborador.FormattingEnabled = true;
            this.cboColaborador.Location = new System.Drawing.Point(97, 85);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(322, 21);
            this.cboColaborador.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label3.Location = new System.Drawing.Point(15, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Colaborador:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(425, 83);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(87, 27);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label2.Location = new System.Drawing.Point(19, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(64, 56);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(112, 24);
            this.dtpHasta.TabIndex = 2;
            // 
            // dtpDesde
            // 
            this.dtpDesde.CalendarFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(64, 26);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(112, 24);
            this.dtpDesde.TabIndex = 1;
            // 
            // FrmInformeVentaColaborador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 602);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmInformeVentaColaborador";
            this.Text = "Reporte Ventas por Colaborador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInformeVentaColaborador_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nInformeVentaColaboradorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eDetalleInformeVentaColaboradorBindingSource)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.ComboBox cboColaborador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.BindingSource nInformeVentaColaboradorBindingSource;
        private System.Windows.Forms.BindingSource eDetalleInformeVentaColaboradorBindingSource;
    }
}