namespace CapaPresentacion.Formularios.Herramientas
{
    partial class FrmMantenimientoTimbrado
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
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.grbRegistro = new System.Windows.Forms.GroupBox();
            this.chkEstadoNumeracion = new System.Windows.Forms.CheckBox();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNumeroHasta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboComprobante = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroDesde = new System.Windows.Forms.TextBox();
            this.txtPuntoExpedicion = new System.Windows.Forms.TextBox();
            this.txtEstablecimiento = new System.Windows.Forms.TextBox();
            this.chkEstadoTimbrado = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminarTimbrado = new System.Windows.Forms.Button();
            this.dgTimbrados = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardarTimbrado = new System.Windows.Forms.Button();
            this.btnEditarTimbrado = new System.Windows.Forms.Button();
            this.dtpFechaInicioVigencia = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNroTimbrado = new System.Windows.Forms.TextBox();
            this.grbNumeracion = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.rbManual = new System.Windows.Forms.RadioButton();
            this.rbAutoimprenta = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.grbRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTimbrados)).BeginInit();
            this.grbNumeracion.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // grbRegistro
            // 
            this.grbRegistro.Controls.Add(this.chkEstadoNumeracion);
            this.grbRegistro.Controls.Add(this.dataListado);
            this.grbRegistro.Controls.Add(this.btnQuitar);
            this.grbRegistro.Controls.Add(this.btnAgregar);
            this.grbRegistro.Controls.Add(this.label10);
            this.grbRegistro.Controls.Add(this.txtNumeroHasta);
            this.grbRegistro.Controls.Add(this.label6);
            this.grbRegistro.Controls.Add(this.cboComprobante);
            this.grbRegistro.Controls.Add(this.label3);
            this.grbRegistro.Controls.Add(this.label2);
            this.grbRegistro.Controls.Add(this.label4);
            this.grbRegistro.Controls.Add(this.label1);
            this.grbRegistro.Controls.Add(this.txtNumeroDesde);
            this.grbRegistro.Controls.Add(this.txtPuntoExpedicion);
            this.grbRegistro.Controls.Add(this.txtEstablecimiento);
            this.grbRegistro.Location = new System.Drawing.Point(11, 116);
            this.grbRegistro.Name = "grbRegistro";
            this.grbRegistro.Size = new System.Drawing.Size(695, 411);
            this.grbRegistro.TabIndex = 11;
            this.grbRegistro.TabStop = false;
            this.grbRegistro.Text = "Numeración";
            // 
            // chkEstadoNumeracion
            // 
            this.chkEstadoNumeracion.AutoSize = true;
            this.chkEstadoNumeracion.Location = new System.Drawing.Point(568, 49);
            this.chkEstadoNumeracion.Name = "chkEstadoNumeracion";
            this.chkEstadoNumeracion.Size = new System.Drawing.Size(63, 20);
            this.chkEstadoNumeracion.TabIndex = 10;
            this.chkEstadoNumeracion.Text = "Activo";
            this.chkEstadoNumeracion.UseVisualStyleBackColor = true;
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
            this.dataListado.Location = new System.Drawing.Point(7, 115);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowHeadersWidth = 51;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(683, 286);
            this.dataListado.TabIndex = 17;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(91, 86);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 24);
            this.btnQuitar.TabIndex = 12;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.btnAgregar.Location = new System.Drawing.Point(10, 86);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 24);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(346, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "Hasta";
            // 
            // txtNumeroHasta
            // 
            this.txtNumeroHasta.Location = new System.Drawing.Point(315, 48);
            this.txtNumeroHasta.MaxLength = 10;
            this.txtNumeroHasta.Name = "txtNumeroHasta";
            this.txtNumeroHasta.Size = new System.Drawing.Size(100, 23);
            this.txtNumeroHasta.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(432, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tipo Comprobante";
            // 
            // cboComprobante
            // 
            this.cboComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComprobante.FormattingEnabled = true;
            this.cboComprobante.Items.AddRange(new object[] {
            "Factura",
            "Nota de Credito",
            "AutoFactura",
            "Ticket",
            "Proforma"});
            this.cboComprobante.Location = new System.Drawing.Point(429, 47);
            this.cboComprobante.Name = "cboComprobante";
            this.cboComprobante.Size = new System.Drawing.Size(121, 23);
            this.cboComprobante.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Punto Exp.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Establecimiento";
            // 
            // txtNumeroDesde
            // 
            this.txtNumeroDesde.Location = new System.Drawing.Point(209, 48);
            this.txtNumeroDesde.MaxLength = 10;
            this.txtNumeroDesde.Name = "txtNumeroDesde";
            this.txtNumeroDesde.Size = new System.Drawing.Size(100, 23);
            this.txtNumeroDesde.TabIndex = 7;
            this.txtNumeroDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // txtPuntoExpedicion
            // 
            this.txtPuntoExpedicion.Location = new System.Drawing.Point(96, 49);
            this.txtPuntoExpedicion.MaxLength = 3;
            this.txtPuntoExpedicion.Name = "txtPuntoExpedicion";
            this.txtPuntoExpedicion.Size = new System.Drawing.Size(100, 23);
            this.txtPuntoExpedicion.TabIndex = 6;
            this.txtPuntoExpedicion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPuntoExpedicion_KeyPress);
            // 
            // txtEstablecimiento
            // 
            this.txtEstablecimiento.Location = new System.Drawing.Point(9, 49);
            this.txtEstablecimiento.MaxLength = 3;
            this.txtEstablecimiento.Name = "txtEstablecimiento";
            this.txtEstablecimiento.Size = new System.Drawing.Size(64, 23);
            this.txtEstablecimiento.TabIndex = 5;
            this.txtEstablecimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstablecimiento_KeyPress);
            // 
            // chkEstadoTimbrado
            // 
            this.chkEstadoTimbrado.AutoSize = true;
            this.chkEstadoTimbrado.Location = new System.Drawing.Point(604, 72);
            this.chkEstadoTimbrado.Name = "chkEstadoTimbrado";
            this.chkEstadoTimbrado.Size = new System.Drawing.Size(63, 20);
            this.chkEstadoTimbrado.TabIndex = 4;
            this.chkEstadoTimbrado.Text = "Activo";
            this.chkEstadoTimbrado.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminarTimbrado);
            this.groupBox2.Controls.Add(this.dgTimbrados);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.groupBox2.Location = new System.Drawing.Point(12, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(515, 412);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timbrado";
            // 
            // btnEliminarTimbrado
            // 
            this.btnEliminarTimbrado.Location = new System.Drawing.Point(6, 38);
            this.btnEliminarTimbrado.Name = "btnEliminarTimbrado";
            this.btnEliminarTimbrado.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarTimbrado.TabIndex = 17;
            this.btnEliminarTimbrado.Text = "Eliminar";
            this.btnEliminarTimbrado.UseVisualStyleBackColor = true;
            this.btnEliminarTimbrado.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgTimbrados
            // 
            this.dgTimbrados.AllowUserToAddRows = false;
            this.dgTimbrados.AllowUserToDeleteRows = false;
            this.dgTimbrados.AllowUserToOrderColumns = true;
            this.dgTimbrados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTimbrados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgTimbrados.BackgroundColor = System.Drawing.Color.White;
            this.dgTimbrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTimbrados.Location = new System.Drawing.Point(6, 67);
            this.dgTimbrados.MultiSelect = false;
            this.dgTimbrados.Name = "dgTimbrados";
            this.dgTimbrados.ReadOnly = true;
            this.dgTimbrados.RowHeadersWidth = 51;
            this.dgTimbrados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTimbrados.Size = new System.Drawing.Size(503, 321);
            this.dgTimbrados.TabIndex = 15;
            this.dgTimbrados.DoubleClick += new System.EventHandler(this.dgTimbrados_DoubleClick);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(395, 9);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(64, 23);
            this.btnNuevo.TabIndex = 19;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardarTimbrado
            // 
            this.btnGuardarTimbrado.Location = new System.Drawing.Point(468, 9);
            this.btnGuardarTimbrado.Name = "btnGuardarTimbrado";
            this.btnGuardarTimbrado.Size = new System.Drawing.Size(64, 23);
            this.btnGuardarTimbrado.TabIndex = 14;
            this.btnGuardarTimbrado.Text = "Guardar";
            this.btnGuardarTimbrado.UseVisualStyleBackColor = true;
            this.btnGuardarTimbrado.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditarTimbrado
            // 
            this.btnEditarTimbrado.Location = new System.Drawing.Point(542, 9);
            this.btnEditarTimbrado.Name = "btnEditarTimbrado";
            this.btnEditarTimbrado.Size = new System.Drawing.Size(65, 23);
            this.btnEditarTimbrado.TabIndex = 16;
            this.btnEditarTimbrado.Text = "Editar";
            this.btnEditarTimbrado.UseVisualStyleBackColor = true;
            this.btnEditarTimbrado.Click += new System.EventHandler(this.btnEditarTimbrado_Click);
            // 
            // dtpFechaInicioVigencia
            // 
            this.dtpFechaInicioVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicioVigencia.Location = new System.Drawing.Point(158, 71);
            this.dtpFechaInicioVigencia.Name = "dtpFechaInicioVigencia";
            this.dtpFechaInicioVigencia.ShowCheckBox = true;
            this.dtpFechaInicioVigencia.Size = new System.Drawing.Size(113, 23);
            this.dtpFechaInicioVigencia.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label9.Location = new System.Drawing.Point(160, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "Fecha Inicio Vig.";
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(284, 71);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.ShowCheckBox = true;
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(113, 23);
            this.dtpFechaVencimiento.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label8.Location = new System.Drawing.Point(281, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Fecha Vencimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label7.Location = new System.Drawing.Point(15, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Número";
            // 
            // txtNroTimbrado
            // 
            this.txtNroTimbrado.Location = new System.Drawing.Point(16, 71);
            this.txtNroTimbrado.MaxLength = 10;
            this.txtNroTimbrado.Name = "txtNroTimbrado";
            this.txtNroTimbrado.Size = new System.Drawing.Size(130, 23);
            this.txtNroTimbrado.TabIndex = 1;
            this.txtNroTimbrado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimbrado_KeyPress);
            // 
            // grbNumeracion
            // 
            this.grbNumeracion.Controls.Add(this.btnCancelar);
            this.grbNumeracion.Controls.Add(this.btnNuevo);
            this.grbNumeracion.Controls.Add(this.btnEditarTimbrado);
            this.grbNumeracion.Controls.Add(this.rbManual);
            this.grbNumeracion.Controls.Add(this.btnGuardarTimbrado);
            this.grbNumeracion.Controls.Add(this.rbAutoimprenta);
            this.grbNumeracion.Controls.Add(this.grbRegistro);
            this.grbNumeracion.Controls.Add(this.dtpFechaInicioVigencia);
            this.grbNumeracion.Controls.Add(this.label9);
            this.grbNumeracion.Controls.Add(this.chkEstadoTimbrado);
            this.grbNumeracion.Controls.Add(this.dtpFechaVencimiento);
            this.grbNumeracion.Controls.Add(this.label8);
            this.grbNumeracion.Controls.Add(this.label7);
            this.grbNumeracion.Controls.Add(this.txtNroTimbrado);
            this.grbNumeracion.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.grbNumeracion.Location = new System.Drawing.Point(533, 24);
            this.grbNumeracion.Name = "grbNumeracion";
            this.grbNumeracion.Size = new System.Drawing.Size(718, 547);
            this.grbNumeracion.TabIndex = 14;
            this.grbNumeracion.TabStop = false;
            this.grbNumeracion.Text = "Mantenimiento";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(620, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(69, 23);
            this.btnCancelar.TabIndex = 52;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // rbManual
            // 
            this.rbManual.AutoSize = true;
            this.rbManual.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.rbManual.Location = new System.Drawing.Point(523, 71);
            this.rbManual.Name = "rbManual";
            this.rbManual.Size = new System.Drawing.Size(66, 20);
            this.rbManual.TabIndex = 51;
            this.rbManual.Text = "Manual";
            this.rbManual.UseVisualStyleBackColor = true;
            // 
            // rbAutoimprenta
            // 
            this.rbAutoimprenta.AutoSize = true;
            this.rbAutoimprenta.Checked = true;
            this.rbAutoimprenta.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.rbAutoimprenta.Location = new System.Drawing.Point(416, 71);
            this.rbAutoimprenta.Name = "rbAutoimprenta";
            this.rbAutoimprenta.Size = new System.Drawing.Size(101, 20);
            this.rbAutoimprenta.TabIndex = 50;
            this.rbAutoimprenta.TabStop = true;
            this.rbAutoimprenta.Text = "Autoimprenta";
            this.rbAutoimprenta.UseVisualStyleBackColor = true;
            // 
            // FrmMantenimientoTimbrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 583);
            this.Controls.Add(this.grbNumeracion);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmMantenimientoTimbrado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Numeracion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNumeracionFactura_FormClosing);
            this.Load += new System.EventHandler(this.FrmNumeracionFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.grbRegistro.ResumeLayout(false);
            this.grbRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTimbrados)).EndInit();
            this.grbNumeracion.ResumeLayout(false);
            this.grbNumeracion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grbRegistro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumeroDesde;
        private System.Windows.Forms.TextBox txtPuntoExpedicion;
        private System.Windows.Forms.TextBox txtEstablecimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNroTimbrado;
        private System.Windows.Forms.DateTimePicker dtpFechaInicioVigencia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grbNumeracion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNumeroHasta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboComprobante;
        private System.Windows.Forms.CheckBox chkEstadoTimbrado;
        private System.Windows.Forms.DataGridView dgTimbrados;
        private System.Windows.Forms.Button btnEliminarTimbrado;
        private System.Windows.Forms.Button btnEditarTimbrado;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnGuardarTimbrado;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.CheckBox chkEstadoNumeracion;
        private System.Windows.Forms.RadioButton rbManual;
        private System.Windows.Forms.RadioButton rbAutoimprenta;
        private System.Windows.Forms.Button btnCancelar;
    }
}