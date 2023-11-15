using CapaPresentacion.Informes;
namespace CapaPresentacion
{
    partial class FrmLibroVentas
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
            this.eLibroVentaReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eDetalleDeVentasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnObtener = new System.Windows.Forms.Button();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eLibroVentaReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eDetalleDeVentasBindingSource)).BeginInit();
            this.gbFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // eLibroVentaReportBindingSource
            // 
            this.eLibroVentaReportBindingSource.DataSource = typeof(CapaEntidades.Reporting.ELibroVentaReport);
            // 
            // eDetalleDeVentasBindingSource
            // 
            this.eDetalleDeVentasBindingSource.DataSource = typeof(CapaEntidades.Reporting.EDetalleDeVentas);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DsLibroVentaReport";
            reportDataSource1.Value = this.eLibroVentaReportBindingSource;
            reportDataSource2.Name = "DsDetalleDeVentas";
            reportDataSource2.Value = this.eDetalleDeVentasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.RptLibroVenta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 138);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1095, 401);
            this.reportViewer1.TabIndex = 0;
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
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(64, 56);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(112, 24);
            this.dtpHasta.TabIndex = 2;
            // 
            // btnObtener
            // 
            this.btnObtener.Location = new System.Drawing.Point(182, 81);
            this.btnObtener.Name = "btnObtener";
            this.btnObtener.Size = new System.Drawing.Size(87, 27);
            this.btnObtener.TabIndex = 5;
            this.btnObtener.Text = "Consultar";
            this.btnObtener.UseVisualStyleBackColor = true;
            this.btnObtener.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.cboEstado);
            this.gbFiltro.Controls.Add(this.label3);
            this.gbFiltro.Controls.Add(this.label1);
            this.gbFiltro.Controls.Add(this.btnObtener);
            this.gbFiltro.Controls.Add(this.label2);
            this.gbFiltro.Controls.Add(this.dtpHasta);
            this.gbFiltro.Controls.Add(this.dtpDesde);
            this.gbFiltro.Location = new System.Drawing.Point(12, 12);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(301, 122);
            this.gbFiltro.TabIndex = 6;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtro";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "EMITIDO",
            "ANULADO"});
            this.cboEstado.Location = new System.Drawing.Point(64, 85);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(112, 23);
            this.cboEstado.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label3.Location = new System.Drawing.Point(14, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Estado:";
            // 
            // FrmLibroVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 551);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.Name = "FrmLibroVentas";
            this.Text = "Libro de Ventas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLibroVentas_FormClosing);
            this.Load += new System.EventHandler(this.FrmLibroVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eLibroVentaReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eDetalleDeVentasBindingSource)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnObtener;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.BindingSource eLibroVentaReportBindingSource;
        private System.Windows.Forms.BindingSource eDetalleDeVentasBindingSource;
    }
}