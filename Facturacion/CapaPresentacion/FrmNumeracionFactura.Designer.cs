namespace CapaPresentacion
{
    partial class FrmNumeracionFactura
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
            this.cboComprobante = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtPuntoExpedicion = new System.Windows.Forms.TextBox();
            this.txtEstablecimiento = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpFechaInicioVigencia = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNroTimbrado = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboComprobante
            // 
            this.cboComprobante.FormattingEnabled = true;
            this.cboComprobante.Items.AddRange(new object[] {
            "Factura",
            "Nota de Credito",
            "AutoFactura",
            "Ticket",
            "Proforma"});
            this.cboComprobante.Location = new System.Drawing.Point(361, 67);
            this.cboComprobante.Name = "cboComprobante";
            this.cboComprobante.Size = new System.Drawing.Size(121, 21);
            this.cboComprobante.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tipo Comprobante";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(22, 182);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataListado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataListado.BackgroundColor = System.Drawing.Color.White;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.dataListado.Location = new System.Drawing.Point(22, 211);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(602, 165);
            this.dataListado.TabIndex = 8;
            this.dataListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListado_CellContentClick);
            this.dataListado.DoubleClick += new System.EventHandler(this.dataListado_DoubleClick);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(488, 70);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(59, 17);
            this.chkEstado.TabIndex = 9;
            this.chkEstado.Text = "Estado";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(103, 182);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.txtPuntoExpedicion);
            this.groupBox1.Controls.Add(this.txtEstablecimiento);
            this.groupBox1.Location = new System.Drawing.Point(23, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 73);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Numeración";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Numero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Punto Exp.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Establecimiento";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(206, 36);
            this.txtNumero.MaxLength = 50;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 10;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // txtPuntoExpedicion
            // 
            this.txtPuntoExpedicion.Location = new System.Drawing.Point(86, 37);
            this.txtPuntoExpedicion.MaxLength = 3;
            this.txtPuntoExpedicion.Name = "txtPuntoExpedicion";
            this.txtPuntoExpedicion.Size = new System.Drawing.Size(100, 20);
            this.txtPuntoExpedicion.TabIndex = 9;
            this.txtPuntoExpedicion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPuntoExpedicion_KeyPress);
            // 
            // txtEstablecimiento
            // 
            this.txtEstablecimiento.Location = new System.Drawing.Point(9, 37);
            this.txtEstablecimiento.MaxLength = 3;
            this.txtEstablecimiento.Name = "txtEstablecimiento";
            this.txtEstablecimiento.Size = new System.Drawing.Size(64, 20);
            this.txtEstablecimiento.TabIndex = 3;
            this.txtEstablecimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstablecimiento_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpFechaInicioVigencia);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dtpFechaVencimiento);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtNroTimbrado);
            this.groupBox2.Location = new System.Drawing.Point(23, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 66);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timbrado";
            // 
            // dtpFechaInicioVigencia
            // 
            this.dtpFechaInicioVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicioVigencia.Location = new System.Drawing.Point(172, 36);
            this.dtpFechaInicioVigencia.Name = "dtpFechaInicioVigencia";
            this.dtpFechaInicioVigencia.ShowCheckBox = true;
            this.dtpFechaInicioVigencia.Size = new System.Drawing.Size(113, 20);
            this.dtpFechaInicioVigencia.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(183, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Fecha Inicio Vig.";
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(312, 36);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.ShowCheckBox = true;
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(113, 20);
            this.dtpFechaVencimiento.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(309, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Fecha Vencimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Número";
            // 
            // txtNroTimbrado
            // 
            this.txtNroTimbrado.Location = new System.Drawing.Point(11, 36);
            this.txtNroTimbrado.MaxLength = 50;
            this.txtNroTimbrado.Name = "txtNroTimbrado";
            this.txtNroTimbrado.Size = new System.Drawing.Size(130, 20);
            this.txtNroTimbrado.TabIndex = 10;
            this.txtNroTimbrado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimbrado_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(184, 182);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmNumeracionFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 388);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.chkEstado);
            this.Controls.Add(this.dataListado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cboComprobante);
            this.Controls.Add(this.label6);
            this.Name = "FrmNumeracionFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Numeracion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNumeracionFactura_FormClosing);
            this.Load += new System.EventHandler(this.FrmNumeracionFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboComprobante;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtPuntoExpedicion;
        private System.Windows.Forms.TextBox txtEstablecimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNroTimbrado;
        private System.Windows.Forms.DateTimePicker dtpFechaInicioVigencia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancelar;
    }
}