namespace CapaPresentacion
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
            this.grbRegistro.Location = new System.Drawing.Point(15, 143);
            this.grbRegistro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbRegistro.Name = "grbRegistro";
            this.grbRegistro.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbRegistro.Size = new System.Drawing.Size(927, 506);
            this.grbRegistro.TabIndex = 11;
            this.grbRegistro.TabStop = false;
            this.grbRegistro.Text = "Numeración";
            // 
            // chkEstadoNumeracion
            // 
            this.chkEstadoNumeracion.AutoSize = true;
            this.chkEstadoNumeracion.Location = new System.Drawing.Point(758, 60);
            this.chkEstadoNumeracion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkEstadoNumeracion.Name = "chkEstadoNumeracion";
            this.chkEstadoNumeracion.Size = new System.Drawing.Size(76, 23);
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
            this.dataListado.Location = new System.Drawing.Point(9, 142);
            this.dataListado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowHeadersWidth = 51;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(911, 352);
            this.dataListado.TabIndex = 17;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(121, 106);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(100, 30);
            this.btnQuitar.TabIndex = 12;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.btnAgregar.Location = new System.Drawing.Point(13, 106);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 30);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(461, 39);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 19);
            this.label10.TabIndex = 15;
            this.label10.Text = "Hasta";
            // 
            // txtNumeroHasta
            // 
            this.txtNumeroHasta.Location = new System.Drawing.Point(420, 59);
            this.txtNumeroHasta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumeroHasta.MaxLength = 10;
            this.txtNumeroHasta.Name = "txtNumeroHasta";
            this.txtNumeroHasta.Size = new System.Drawing.Size(132, 27);
            this.txtNumeroHasta.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(576, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 19);
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
            this.cboComprobante.Location = new System.Drawing.Point(572, 58);
            this.cboComprobante.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboComprobante.Name = "cboComprobante";
            this.cboComprobante.Size = new System.Drawing.Size(160, 27);
            this.cboComprobante.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Punto Exp.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Establecimiento";
            // 
            // txtNumeroDesde
            // 
            this.txtNumeroDesde.Location = new System.Drawing.Point(279, 59);
            this.txtNumeroDesde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumeroDesde.MaxLength = 10;
            this.txtNumeroDesde.Name = "txtNumeroDesde";
            this.txtNumeroDesde.Size = new System.Drawing.Size(132, 27);
            this.txtNumeroDesde.TabIndex = 7;
            this.txtNumeroDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // txtPuntoExpedicion
            // 
            this.txtPuntoExpedicion.Location = new System.Drawing.Point(128, 60);
            this.txtPuntoExpedicion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPuntoExpedicion.MaxLength = 3;
            this.txtPuntoExpedicion.Name = "txtPuntoExpedicion";
            this.txtPuntoExpedicion.Size = new System.Drawing.Size(132, 27);
            this.txtPuntoExpedicion.TabIndex = 6;
            this.txtPuntoExpedicion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPuntoExpedicion_KeyPress);
            // 
            // txtEstablecimiento
            // 
            this.txtEstablecimiento.Location = new System.Drawing.Point(12, 60);
            this.txtEstablecimiento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEstablecimiento.MaxLength = 3;
            this.txtEstablecimiento.Name = "txtEstablecimiento";
            this.txtEstablecimiento.Size = new System.Drawing.Size(84, 27);
            this.txtEstablecimiento.TabIndex = 5;
            this.txtEstablecimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstablecimiento_KeyPress);
            // 
            // chkEstadoTimbrado
            // 
            this.chkEstadoTimbrado.AutoSize = true;
            this.chkEstadoTimbrado.Location = new System.Drawing.Point(805, 89);
            this.chkEstadoTimbrado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkEstadoTimbrado.Name = "chkEstadoTimbrado";
            this.chkEstadoTimbrado.Size = new System.Drawing.Size(76, 23);
            this.chkEstadoTimbrado.TabIndex = 4;
            this.chkEstadoTimbrado.Text = "Activo";
            this.chkEstadoTimbrado.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminarTimbrado);
            this.groupBox2.Controls.Add(this.dgTimbrados);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.groupBox2.Location = new System.Drawing.Point(16, 30);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(687, 507);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timbrado";
            // 
            // btnEliminarTimbrado
            // 
            this.btnEliminarTimbrado.Location = new System.Drawing.Point(8, 47);
            this.btnEliminarTimbrado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminarTimbrado.Name = "btnEliminarTimbrado";
            this.btnEliminarTimbrado.Size = new System.Drawing.Size(100, 28);
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
            this.dgTimbrados.Location = new System.Drawing.Point(8, 82);
            this.dgTimbrados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgTimbrados.MultiSelect = false;
            this.dgTimbrados.Name = "dgTimbrados";
            this.dgTimbrados.ReadOnly = true;
            this.dgTimbrados.RowHeadersWidth = 51;
            this.dgTimbrados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTimbrados.Size = new System.Drawing.Size(657, 395);
            this.dgTimbrados.TabIndex = 15;
            this.dgTimbrados.DoubleClick += new System.EventHandler(this.dgTimbrados_DoubleClick);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(527, 11);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(85, 28);
            this.btnNuevo.TabIndex = 19;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardarTimbrado
            // 
            this.btnGuardarTimbrado.Location = new System.Drawing.Point(624, 11);
            this.btnGuardarTimbrado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardarTimbrado.Name = "btnGuardarTimbrado";
            this.btnGuardarTimbrado.Size = new System.Drawing.Size(85, 28);
            this.btnGuardarTimbrado.TabIndex = 14;
            this.btnGuardarTimbrado.Text = "Guardar";
            this.btnGuardarTimbrado.UseVisualStyleBackColor = true;
            this.btnGuardarTimbrado.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditarTimbrado
            // 
            this.btnEditarTimbrado.Location = new System.Drawing.Point(723, 11);
            this.btnEditarTimbrado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditarTimbrado.Name = "btnEditarTimbrado";
            this.btnEditarTimbrado.Size = new System.Drawing.Size(87, 28);
            this.btnEditarTimbrado.TabIndex = 16;
            this.btnEditarTimbrado.Text = "Editar";
            this.btnEditarTimbrado.UseVisualStyleBackColor = true;
            this.btnEditarTimbrado.Click += new System.EventHandler(this.btnEditarTimbrado_Click);
            // 
            // dtpFechaInicioVigencia
            // 
            this.dtpFechaInicioVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicioVigencia.Location = new System.Drawing.Point(211, 87);
            this.dtpFechaInicioVigencia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFechaInicioVigencia.Name = "dtpFechaInicioVigencia";
            this.dtpFechaInicioVigencia.ShowCheckBox = true;
            this.dtpFechaInicioVigencia.Size = new System.Drawing.Size(149, 27);
            this.dtpFechaInicioVigencia.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label9.Location = new System.Drawing.Point(213, 68);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Fecha Inicio Vig.";
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(379, 87);
            this.dtpFechaVencimiento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.ShowCheckBox = true;
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(149, 27);
            this.dtpFechaVencimiento.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label8.Location = new System.Drawing.Point(375, 68);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 19);
            this.label8.TabIndex = 11;
            this.label8.Text = "Fecha Vencimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label7.Location = new System.Drawing.Point(20, 68);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "Número";
            // 
            // txtNroTimbrado
            // 
            this.txtNroTimbrado.Location = new System.Drawing.Point(21, 87);
            this.txtNroTimbrado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNroTimbrado.MaxLength = 10;
            this.txtNroTimbrado.Name = "txtNroTimbrado";
            this.txtNroTimbrado.Size = new System.Drawing.Size(172, 27);
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
            this.grbNumeracion.Location = new System.Drawing.Point(711, 30);
            this.grbNumeracion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbNumeracion.Name = "grbNumeracion";
            this.grbNumeracion.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbNumeracion.Size = new System.Drawing.Size(957, 673);
            this.grbNumeracion.TabIndex = 14;
            this.grbNumeracion.TabStop = false;
            this.grbNumeracion.Text = "Mantenimiento";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(827, 11);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 28);
            this.btnCancelar.TabIndex = 52;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // rbManual
            // 
            this.rbManual.AutoSize = true;
            this.rbManual.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.rbManual.Location = new System.Drawing.Point(697, 87);
            this.rbManual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbManual.Name = "rbManual";
            this.rbManual.Size = new System.Drawing.Size(80, 23);
            this.rbManual.TabIndex = 51;
            this.rbManual.Text = "Manual";
            this.rbManual.UseVisualStyleBackColor = true;
            // 
            // rbAutoimprenta
            // 
            this.rbAutoimprenta.AutoSize = true;
            this.rbAutoimprenta.Checked = true;
            this.rbAutoimprenta.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.rbAutoimprenta.Location = new System.Drawing.Point(555, 87);
            this.rbAutoimprenta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbAutoimprenta.Name = "rbAutoimprenta";
            this.rbAutoimprenta.Size = new System.Drawing.Size(123, 23);
            this.rbAutoimprenta.TabIndex = 50;
            this.rbAutoimprenta.TabStop = true;
            this.rbAutoimprenta.Text = "Autoimprenta";
            this.rbAutoimprenta.UseVisualStyleBackColor = true;
            // 
            // FrmMantenimientoTimbrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1713, 718);
            this.Controls.Add(this.grbNumeracion);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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