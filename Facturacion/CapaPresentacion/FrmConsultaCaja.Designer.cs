namespace CapaPresentacion
{
    partial class FrmConsultaCaja
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataResumenCaja = new System.Windows.Forms.DataGridView();
            this.gbFechas = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.btnVerMovimientos = new System.Windows.Forms.Button();
            this.txtDiferencia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtegreso = new System.Windows.Forms.TextBox();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.txtingreso = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblSinRegistros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataResumenCaja)).BeginInit();
            this.gbFechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.SuspendLayout();
            // 
            // dataResumenCaja
            // 
            this.dataResumenCaja.AllowUserToAddRows = false;
            this.dataResumenCaja.AllowUserToDeleteRows = false;
            this.dataResumenCaja.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataResumenCaja.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataResumenCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataResumenCaja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataResumenCaja.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataResumenCaja.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataResumenCaja.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataResumenCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataResumenCaja.EnableHeadersVisualStyles = false;
            this.dataResumenCaja.GridColor = System.Drawing.SystemColors.Control;
            this.dataResumenCaja.Location = new System.Drawing.Point(4, 80);
            this.dataResumenCaja.MultiSelect = false;
            this.dataResumenCaja.Name = "dataResumenCaja";
            this.dataResumenCaja.ReadOnly = true;
            this.dataResumenCaja.RowHeadersVisible = false;
            this.dataResumenCaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataResumenCaja.Size = new System.Drawing.Size(569, 347);
            this.dataResumenCaja.TabIndex = 9;
            this.dataResumenCaja.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataResumenCaja_CellFormatting);
            // 
            // gbFechas
            // 
            this.gbFechas.Controls.Add(this.btnBuscar);
            this.gbFechas.Controls.Add(this.label2);
            this.gbFechas.Controls.Add(this.label1);
            this.gbFechas.Controls.Add(this.dtpHasta);
            this.gbFechas.Controls.Add(this.dtpDesde);
            this.gbFechas.Font = new System.Drawing.Font("Times New Roman", 9.5F);
            this.gbFechas.Location = new System.Drawing.Point(57, 2);
            this.gbFechas.Name = "gbFechas";
            this.gbFechas.Size = new System.Drawing.Size(371, 76);
            this.gbFechas.TabIndex = 12;
            this.gbFechas.TabStop = false;
            this.gbFechas.Text = "Fechas";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(281, 40);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(55, 23);
            this.btnBuscar.TabIndex = 16;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label2.Location = new System.Drawing.Point(180, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label1.Location = new System.Drawing.Point(33, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Desde:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpHasta.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(172, 40);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(103, 24);
            this.dtpHasta.TabIndex = 12;
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDesde.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(30, 40);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(103, 24);
            this.dtpDesde.TabIndex = 13;
            // 
            // btnVerMovimientos
            // 
            this.btnVerMovimientos.Location = new System.Drawing.Point(4, 433);
            this.btnVerMovimientos.Name = "btnVerMovimientos";
            this.btnVerMovimientos.Size = new System.Drawing.Size(98, 23);
            this.btnVerMovimientos.TabIndex = 16;
            this.btnVerMovimientos.Text = "Ver Movimientos";
            this.btnVerMovimientos.UseVisualStyleBackColor = true;
            this.btnVerMovimientos.Click += new System.EventHandler(this.btnVerMovimientos_Click);
            // 
            // txtDiferencia
            // 
            this.txtDiferencia.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiferencia.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtDiferencia.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtDiferencia.Location = new System.Drawing.Point(1074, 439);
            this.txtDiferencia.Name = "txtDiferencia";
            this.txtDiferencia.Size = new System.Drawing.Size(156, 18);
            this.txtDiferencia.TabIndex = 39;
            this.txtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(988, 439);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 38;
            this.label8.Text = "Diferencia:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(887, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 22);
            this.label11.TabIndex = 26;
            this.label11.Text = "Movimiento de Caja";
            // 
            // txtegreso
            // 
            this.txtegreso.BackColor = System.Drawing.Color.Gainsboro;
            this.txtegreso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtegreso.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtegreso.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtegreso.Location = new System.Drawing.Point(1074, 409);
            this.txtegreso.Name = "txtegreso";
            this.txtegreso.Size = new System.Drawing.Size(156, 18);
            this.txtegreso.TabIndex = 37;
            this.txtegreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCheque
            // 
            this.txtCheque.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCheque.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCheque.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheque.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtCheque.Location = new System.Drawing.Point(740, 442);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(156, 18);
            this.txtCheque.TabIndex = 33;
            this.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTarjeta.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarjeta.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtTarjeta.Location = new System.Drawing.Point(741, 412);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(156, 18);
            this.txtTarjeta.TabIndex = 34;
            this.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BackColor = System.Drawing.Color.Gainsboro;
            this.txtEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEfectivo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtEfectivo.Location = new System.Drawing.Point(741, 380);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(156, 18);
            this.txtEfectivo.TabIndex = 35;
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtingreso
            // 
            this.txtingreso.BackColor = System.Drawing.Color.Gainsboro;
            this.txtingreso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtingreso.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtingreso.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtingreso.Location = new System.Drawing.Point(1074, 380);
            this.txtingreso.Name = "txtingreso";
            this.txtingreso.Size = new System.Drawing.Size(156, 18);
            this.txtingreso.TabIndex = 36;
            this.txtingreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1007, 410);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "Egreso:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(668, 442);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 17);
            this.label14.TabIndex = 28;
            this.label14.Text = "Cheque:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(669, 412);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 17);
            this.label13.TabIndex = 29;
            this.label13.Text = "Tarjeta:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(670, 380);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 17);
            this.label12.TabIndex = 30;
            this.label12.Text = "Efectivo:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1007, 382);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 17);
            this.label10.TabIndex = 31;
            this.label10.Text = "Ingreso:";
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataListado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataListado.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataListado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.EnableHeadersVisualStyles = false;
            this.dataListado.Location = new System.Drawing.Point(579, 80);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataListado.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataListado.Size = new System.Drawing.Size(738, 283);
            this.dataListado.TabIndex = 27;
            this.dataListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataListado_CellFormatting);
            this.dataListado.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataListado_CellPainting);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(1209, 55);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(101, 23);
            this.btnImprimir.TabIndex = 40;
            this.btnImprimir.Text = "Generar informe";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblSinRegistros
            // 
            this.lblSinRegistros.AutoSize = true;
            this.lblSinRegistros.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSinRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSinRegistros.Location = new System.Drawing.Point(245, 189);
            this.lblSinRegistros.Name = "lblSinRegistros";
            this.lblSinRegistros.Size = new System.Drawing.Size(87, 17);
            this.lblSinRegistros.TabIndex = 41;
            this.lblSinRegistros.Text = "Sin registros";
            this.lblSinRegistros.Visible = false;
            // 
            // FrmConsultaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 484);
            this.Controls.Add(this.lblSinRegistros);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.txtDiferencia);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtegreso);
            this.Controls.Add(this.txtCheque);
            this.Controls.Add(this.txtTarjeta);
            this.Controls.Add(this.txtEfectivo);
            this.Controls.Add(this.txtingreso);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataListado);
            this.Controls.Add(this.btnVerMovimientos);
            this.Controls.Add(this.gbFechas);
            this.Controls.Add(this.dataResumenCaja);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmConsultaCaja";
            this.Text = "Consulta Caja";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConsultaCaja_FormClosing);
            this.Load += new System.EventHandler(this.FrmConsultaCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataResumenCaja)).EndInit();
            this.gbFechas.ResumeLayout(false);
            this.gbFechas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataResumenCaja;
        private System.Windows.Forms.GroupBox gbFechas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button btnVerMovimientos;
        private System.Windows.Forms.TextBox txtDiferencia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtegreso;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.TextBox txtingreso;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblSinRegistros;
    }
}