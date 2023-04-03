namespace CapaPresentacion
{
    partial class FrmCierreCaja
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtfechaApertura = new System.Windows.Forms.TextBox();
            this.txtMontoInicial = new System.Windows.Forms.TextBox();
            this.gbCaja = new System.Windows.Forms.GroupBox();
            this.lblnrocaja = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dtpFechaCierre = new System.Windows.Forms.DateTimePicker();
            this.txtSaldoActual = new System.Windows.Forms.TextBox();
            this.txtImporteEntrega = new System.Windows.Forms.TextBox();
            this.txtDiferenciaSaldo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiferencia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtegreso = new System.Windows.Forms.TextBox();
            this.txtingreso = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.gbCaja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(13, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha apertura:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(14, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Monto Inicial:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label4.Location = new System.Drawing.Point(28, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha de Cierre:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblUsuario.Location = new System.Drawing.Point(129, 29);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 16);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtfechaApertura
            // 
            this.txtfechaApertura.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtfechaApertura.Location = new System.Drawing.Point(132, 69);
            this.txtfechaApertura.Name = "txtfechaApertura";
            this.txtfechaApertura.ReadOnly = true;
            this.txtfechaApertura.Size = new System.Drawing.Size(132, 24);
            this.txtfechaApertura.TabIndex = 5;
            // 
            // txtMontoInicial
            // 
            this.txtMontoInicial.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoInicial.Location = new System.Drawing.Point(132, 107);
            this.txtMontoInicial.Name = "txtMontoInicial";
            this.txtMontoInicial.ReadOnly = true;
            this.txtMontoInicial.Size = new System.Drawing.Size(132, 27);
            this.txtMontoInicial.TabIndex = 6;
            this.txtMontoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbCaja
            // 
            this.gbCaja.Controls.Add(this.lblnrocaja);
            this.gbCaja.Controls.Add(this.txtMontoInicial);
            this.gbCaja.Controls.Add(this.label1);
            this.gbCaja.Controls.Add(this.txtfechaApertura);
            this.gbCaja.Controls.Add(this.label2);
            this.gbCaja.Controls.Add(this.lblUsuario);
            this.gbCaja.Controls.Add(this.label3);
            this.gbCaja.Location = new System.Drawing.Point(14, 14);
            this.gbCaja.Name = "gbCaja";
            this.gbCaja.Size = new System.Drawing.Size(309, 159);
            this.gbCaja.TabIndex = 7;
            this.gbCaja.TabStop = false;
            this.gbCaja.Text = "Caja";
            // 
            // lblnrocaja
            // 
            this.lblnrocaja.AutoSize = true;
            this.lblnrocaja.Location = new System.Drawing.Point(239, 30);
            this.lblnrocaja.Name = "lblnrocaja";
            this.lblnrocaja.Size = new System.Drawing.Size(53, 16);
            this.lblnrocaja.TabIndex = 13;
            this.lblnrocaja.Text = "CajaNro";
            this.lblnrocaja.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(79, 338);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(87, 27);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Cerrar caja";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(202, 338);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(46, 27);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtpFechaCierre
            // 
            this.dtpFechaCierre.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpFechaCierre.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaCierre.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.dtpFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaCierre.Location = new System.Drawing.Point(146, 184);
            this.dtpFechaCierre.Name = "dtpFechaCierre";
            this.dtpFechaCierre.Size = new System.Drawing.Size(137, 23);
            this.dtpFechaCierre.TabIndex = 12;
            this.dtpFechaCierre.ValueChanged += new System.EventHandler(this.dtpFechaCierre_ValueChanged);
            // 
            // txtSaldoActual
            // 
            this.txtSaldoActual.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoActual.Location = new System.Drawing.Point(146, 217);
            this.txtSaldoActual.Name = "txtSaldoActual";
            this.txtSaldoActual.ReadOnly = true;
            this.txtSaldoActual.Size = new System.Drawing.Size(132, 25);
            this.txtSaldoActual.TabIndex = 13;
            this.txtSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImporteEntrega
            // 
            this.txtImporteEntrega.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtImporteEntrega.Location = new System.Drawing.Point(146, 248);
            this.txtImporteEntrega.Name = "txtImporteEntrega";
            this.txtImporteEntrega.Size = new System.Drawing.Size(132, 24);
            this.txtImporteEntrega.TabIndex = 14;
            this.txtImporteEntrega.Text = "0";
            this.txtImporteEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporteEntrega.TextChanged += new System.EventHandler(this.txtImporteEntrega_TextChanged);
            // 
            // txtDiferenciaSaldo
            // 
            this.txtDiferenciaSaldo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiferenciaSaldo.Location = new System.Drawing.Point(146, 279);
            this.txtDiferenciaSaldo.Name = "txtDiferenciaSaldo";
            this.txtDiferenciaSaldo.ReadOnly = true;
            this.txtDiferenciaSaldo.Size = new System.Drawing.Size(132, 25);
            this.txtDiferenciaSaldo.TabIndex = 15;
            this.txtDiferenciaSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label5.Location = new System.Drawing.Point(28, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Saldo Actual:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label6.Location = new System.Drawing.Point(27, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Importe Entrega:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label7.Location = new System.Drawing.Point(28, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Diferencia:";
            // 
            // txtDiferencia
            // 
            this.txtDiferencia.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiferencia.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtDiferencia.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtDiferencia.Location = new System.Drawing.Point(853, 336);
            this.txtDiferencia.Name = "txtDiferencia";
            this.txtDiferencia.ReadOnly = true;
            this.txtDiferencia.Size = new System.Drawing.Size(156, 18);
            this.txtDiferencia.TabIndex = 25;
            this.txtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(767, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Diferencia:";
            // 
            // txtegreso
            // 
            this.txtegreso.BackColor = System.Drawing.Color.Gainsboro;
            this.txtegreso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtegreso.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtegreso.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtegreso.Location = new System.Drawing.Point(853, 306);
            this.txtegreso.Name = "txtegreso";
            this.txtegreso.ReadOnly = true;
            this.txtegreso.Size = new System.Drawing.Size(156, 18);
            this.txtegreso.TabIndex = 23;
            this.txtegreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtingreso
            // 
            this.txtingreso.BackColor = System.Drawing.Color.Gainsboro;
            this.txtingreso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtingreso.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtingreso.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtingreso.Location = new System.Drawing.Point(853, 277);
            this.txtingreso.Name = "txtingreso";
            this.txtingreso.ReadOnly = true;
            this.txtingreso.Size = new System.Drawing.Size(156, 18);
            this.txtingreso.TabIndex = 22;
            this.txtingreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(786, 307);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Egreso:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(786, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Ingreso:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(637, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 22);
            this.label11.TabIndex = 0;
            this.label11.Text = "Movimiento de Caja";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(449, 277);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "Efectivo:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(448, 309);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 17);
            this.label13.TabIndex = 20;
            this.label13.Text = "Tarjeta:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(447, 339);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 17);
            this.label14.TabIndex = 20;
            this.label14.Text = "Cheque:";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BackColor = System.Drawing.Color.Gainsboro;
            this.txtEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEfectivo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtEfectivo.Location = new System.Drawing.Point(520, 277);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.ReadOnly = true;
            this.txtEfectivo.Size = new System.Drawing.Size(156, 18);
            this.txtEfectivo.TabIndex = 22;
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTarjeta.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarjeta.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtTarjeta.Location = new System.Drawing.Point(520, 309);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.ReadOnly = true;
            this.txtTarjeta.Size = new System.Drawing.Size(156, 18);
            this.txtTarjeta.TabIndex = 22;
            this.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCheque
            // 
            this.txtCheque.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCheque.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCheque.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheque.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtCheque.Location = new System.Drawing.Point(519, 339);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.ReadOnly = true;
            this.txtCheque.Size = new System.Drawing.Size(156, 18);
            this.txtCheque.TabIndex = 22;
            this.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataListado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataListado.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataListado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.EnableHeadersVisualStyles = false;
            this.dataListado.Location = new System.Drawing.Point(329, 34);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataListado.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataListado.Size = new System.Drawing.Size(794, 232);
            this.dataListado.TabIndex = 19;
            this.dataListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataListado_CellFormatting);
            this.dataListado.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataListado_CellPainting);
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // FrmCierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 397);
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
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDiferenciaSaldo);
            this.Controls.Add(this.txtImporteEntrega);
            this.Controls.Add(this.txtSaldoActual);
            this.Controls.Add(this.dtpFechaCierre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.gbCaja);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.ForeColor = System.Drawing.SystemColors.MenuText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCierreCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cierre de Caja";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCierreCaja_FormClosing);
            this.Load += new System.EventHandler(this.FrmCierreCaja_Load);
            this.gbCaja.ResumeLayout(false);
            this.gbCaja.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtfechaApertura;
        private System.Windows.Forms.TextBox txtMontoInicial;
        private System.Windows.Forms.GroupBox gbCaja;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblnrocaja;
        private System.Windows.Forms.DateTimePicker dtpFechaCierre;
        private System.Windows.Forms.TextBox txtSaldoActual;
        private System.Windows.Forms.TextBox txtImporteEntrega;
        private System.Windows.Forms.TextBox txtDiferenciaSaldo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiferencia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtegreso;
        private System.Windows.Forms.TextBox txtingreso;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.ToolTip ttMensaje;
    }
}