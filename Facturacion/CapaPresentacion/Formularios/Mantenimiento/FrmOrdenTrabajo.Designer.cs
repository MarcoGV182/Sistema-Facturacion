namespace CapaPresentacion.Formularios.Mantenimiento
{
    partial class FrmOrdenTrabajo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrdenTrabajo));
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbAviso = new System.Windows.Forms.GroupBox();
            this.txtDias = new System.Windows.Forms.TextBox();
            this.dtpFechaVisita = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFormula = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClienteNro = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.txtNumeracion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbltotalgral = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvDetalleOT = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtGanancia = new System.Windows.Forms.TextBox();
            this.txtComisionServicio = new System.Windows.Forms.TextBox();
            this.txtUsuarioNro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.txtGravadas = new System.Windows.Forms.TextBox();
            this.txtDivisor = new System.Windows.Forms.TextBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnBuscarItem = new System.Windows.Forms.Button();
            this.txtUsuarioNombre = new System.Windows.Forms.TextBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodItem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblSinRegistros = new System.Windows.Forms.Label();
            this.gbFechas = new System.Windows.Forms.GroupBox();
            this.dtpfechahasta = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechadesde = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.chkEliminar = new System.Windows.Forms.CheckBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbAviso.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOT)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbFechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.SuspendLayout();
            // 
            // txtObservacion
            // 
            this.txtObservacion.BackColor = System.Drawing.Color.White;
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Location = new System.Drawing.Point(572, 346);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(231, 127);
            this.txtObservacion.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label13.Location = new System.Drawing.Point(569, 327);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 16);
            this.label13.TabIndex = 23;
            this.label13.Text = "Observacion (Opcional):";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(486, 523);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 26);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar[ESC]";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.ForeColor = System.Drawing.SystemColors.InfoText;
            this.errorIcono.SetIconAlignment(this.txtCodigo, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtCodigo.Location = new System.Drawing.Point(96, 114);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(39, 23);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigo.Visible = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFecha.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.errorIcono.SetIconAlignment(this.dtpFecha, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.dtpFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpFecha.Location = new System.Drawing.Point(73, 72);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(140, 24);
            this.dtpFecha.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.errorIcono.SetIconAlignment(this.btnAgregar, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.btnAgregar.Image = global::CapaPresentacion.Properties.Resources.mas;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(605, 60);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(73, 26);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "[Enter]";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbAviso);
            this.groupBox1.Controls.Add(this.txtDocumento);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.Controls.Add(this.btnBuscarCliente);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtClienteNro);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.lblProveedor);
            this.groupBox1.Controls.Add(this.txtNumeracion);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.lblDescripcion);
            this.groupBox1.Controls.Add(this.lblCodigo);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(40, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(763, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // gbAviso
            // 
            this.gbAviso.BackColor = System.Drawing.Color.PeachPuff;
            this.gbAviso.Controls.Add(this.txtDias);
            this.gbAviso.Controls.Add(this.dtpFechaVisita);
            this.gbAviso.Controls.Add(this.label11);
            this.gbAviso.Controls.Add(this.txtFormula);
            this.gbAviso.Controls.Add(this.label10);
            this.gbAviso.Controls.Add(this.lblComprobante);
            this.gbAviso.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.gbAviso.Location = new System.Drawing.Point(353, 66);
            this.gbAviso.Name = "gbAviso";
            this.gbAviso.Size = new System.Drawing.Size(372, 80);
            this.gbAviso.TabIndex = 38;
            this.gbAviso.TabStop = false;
            this.gbAviso.Text = "Datos recordatorio";
            // 
            // txtDias
            // 
            this.txtDias.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDias.Location = new System.Drawing.Point(160, 44);
            this.txtDias.Name = "txtDias";
            this.txtDias.Size = new System.Drawing.Size(37, 22);
            this.txtDias.TabIndex = 44;
            this.txtDias.Leave += new System.EventHandler(this.txtdias_Leave);
            // 
            // dtpFechaVisita
            // 
            this.dtpFechaVisita.CalendarFont = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dtpFechaVisita.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaVisita.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.dtpFechaVisita.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVisita.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpFechaVisita.Location = new System.Drawing.Point(216, 43);
            this.dtpFechaVisita.Name = "dtpFechaVisita";
            this.dtpFechaVisita.ShowCheckBox = true;
            this.dtpFechaVisita.Size = new System.Drawing.Size(122, 24);
            this.dtpFechaVisita.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label11.Location = new System.Drawing.Point(213, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 16);
            this.label11.TabIndex = 42;
            this.label11.Text = "Fecha prox. visita:";
            // 
            // txtFormula
            // 
            this.txtFormula.BackColor = System.Drawing.Color.White;
            this.txtFormula.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtFormula.Location = new System.Drawing.Point(20, 43);
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.Size = new System.Drawing.Size(121, 23);
            this.txtFormula.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label10.Location = new System.Drawing.Point(159, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 16);
            this.label10.TabIndex = 41;
            this.label10.Text = "Dias:";
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblComprobante.Location = new System.Drawing.Point(51, 25);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(58, 16);
            this.lblComprobante.TabIndex = 34;
            this.lblComprobante.Text = "Formula:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtDocumento.Location = new System.Drawing.Point(280, 29);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(86, 24);
            this.txtDocumento.TabIndex = 2;
            this.txtDocumento.Leave += new System.EventHandler(this.txtDocumento_Leave);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblFecha.Location = new System.Drawing.Point(11, 77);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(45, 16);
            this.lblFecha.TabIndex = 29;
            this.lblFecha.Text = "Fecha:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarCliente.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCliente.Location = new System.Drawing.Point(584, 29);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(56, 25);
            this.btnBuscarCliente.TabIndex = 2;
            this.btnBuscarCliente.Text = "...[F2]";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.label8.Location = new System.Drawing.Point(419, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 15);
            this.label8.TabIndex = 34;
            this.label8.Text = "Nombre y Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.label4.Location = new System.Drawing.Point(297, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 34;
            this.label4.Text = "N° Doc.";
            // 
            // txtClienteNro
            // 
            this.txtClienteNro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtClienteNro.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtClienteNro.Location = new System.Drawing.Point(142, 113);
            this.txtClienteNro.Name = "txtClienteNro";
            this.txtClienteNro.Size = new System.Drawing.Size(37, 23);
            this.txtClienteNro.TabIndex = 25;
            this.txtClienteNro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClienteNro.Visible = false;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCliente.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtCliente.Location = new System.Drawing.Point(372, 29);
            this.txtCliente.Multiline = true;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(209, 24);
            this.txtCliente.TabIndex = 2;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblProveedor.Location = new System.Drawing.Point(225, 33);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(49, 16);
            this.lblProveedor.TabIndex = 8;
            this.lblProveedor.Text = "Cliente:";
            // 
            // txtNumeracion
            // 
            this.txtNumeracion.BackColor = System.Drawing.Color.White;
            this.txtNumeracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeracion.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtNumeracion.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtNumeracion.Location = new System.Drawing.Point(73, 29);
            this.txtNumeracion.Name = "txtNumeracion";
            this.txtNumeracion.ReadOnly = true;
            this.txtNumeracion.Size = new System.Drawing.Size(106, 23);
            this.txtNumeracion.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblDescripcion.Location = new System.Drawing.Point(12, 33);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(55, 16);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Nro OT:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(38, 120);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(56, 16);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Cod OT:";
            this.lblCodigo.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Snow;
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.lbltotalgral);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.dgvDetalleOT);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.txtObservacion);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.btnEditar);
            this.tabPage2.Controls.Add(this.btnCancelar);
            this.tabPage2.Controls.Add(this.btnNuevo);
            this.tabPage2.Controls.Add(this.btnGuardar);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(894, 557);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Orden de Trabajo";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(268, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 31);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(30, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "ORDEN DE TRABAJO";
            // 
            // lbltotalgral
            // 
            this.lbltotalgral.AutoSize = true;
            this.lbltotalgral.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbltotalgral.Location = new System.Drawing.Point(283, 478);
            this.lbltotalgral.Name = "lbltotalgral";
            this.lbltotalgral.Size = new System.Drawing.Size(17, 17);
            this.lbltotalgral.TabIndex = 43;
            this.lbltotalgral.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label9.Location = new System.Drawing.Point(68, 479);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 16);
            this.label9.TabIndex = 42;
            this.label9.Text = "Total: ";
            // 
            // dgvDetalleOT
            // 
            this.dgvDetalleOT.AllowUserToAddRows = false;
            this.dgvDetalleOT.AllowUserToDeleteRows = false;
            this.dgvDetalleOT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleOT.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalleOT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetalleOT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleOT.Location = new System.Drawing.Point(66, 314);
            this.dgvDetalleOT.Name = "dgvDetalleOT";
            this.dgvDetalleOT.ReadOnly = true;
            this.dgvDetalleOT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleOT.Size = new System.Drawing.Size(493, 159);
            this.dgvDetalleOT.TabIndex = 25;
            this.dgvDetalleOT.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetalleOT_CellFormatting);
            this.dgvDetalleOT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDetalleOT_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtGanancia);
            this.groupBox2.Controls.Add(this.txtComisionServicio);
            this.groupBox2.Controls.Add(this.txtUsuarioNro);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtPrecio);
            this.groupBox2.Controls.Add(this.txtPrecioCompra);
            this.groupBox2.Controls.Add(this.txtGravadas);
            this.groupBox2.Controls.Add(this.txtDivisor);
            this.groupBox2.Controls.Add(this.btnQuitar);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.btnBuscarItem);
            this.groupBox2.Controls.Add(this.txtUsuarioNombre);
            this.groupBox2.Controls.Add(this.txtItem);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCodItem);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(53, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(750, 124);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // txtGanancia
            // 
            this.txtGanancia.Location = new System.Drawing.Point(172, 92);
            this.txtGanancia.Name = "txtGanancia";
            this.txtGanancia.Size = new System.Drawing.Size(29, 21);
            this.txtGanancia.TabIndex = 24;
            this.txtGanancia.Visible = false;
            // 
            // txtComisionServicio
            // 
            this.txtComisionServicio.Location = new System.Drawing.Point(137, 92);
            this.txtComisionServicio.Name = "txtComisionServicio";
            this.txtComisionServicio.Size = new System.Drawing.Size(29, 21);
            this.txtComisionServicio.TabIndex = 24;
            this.txtComisionServicio.Visible = false;
            // 
            // txtUsuarioNro
            // 
            this.txtUsuarioNro.Location = new System.Drawing.Point(99, 92);
            this.txtUsuarioNro.Name = "txtUsuarioNro";
            this.txtUsuarioNro.Size = new System.Drawing.Size(29, 21);
            this.txtUsuarioNro.TabIndex = 24;
            this.txtUsuarioNro.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label6.Location = new System.Drawing.Point(538, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "Precio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.Color.White;
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecio.ForeColor = System.Drawing.Color.Black;
            this.txtPrecio.Location = new System.Drawing.Point(527, 31);
            this.txtPrecio.Multiline = true;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(62, 23);
            this.txtPrecio.TabIndex = 22;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Location = new System.Drawing.Point(68, 92);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.Size = new System.Drawing.Size(24, 21);
            this.txtPrecioCompra.TabIndex = 21;
            this.txtPrecioCompra.Visible = false;
            // 
            // txtGravadas
            // 
            this.txtGravadas.Location = new System.Drawing.Point(39, 92);
            this.txtGravadas.Name = "txtGravadas";
            this.txtGravadas.Size = new System.Drawing.Size(23, 21);
            this.txtGravadas.TabIndex = 18;
            this.txtGravadas.Visible = false;
            // 
            // txtDivisor
            // 
            this.txtDivisor.Location = new System.Drawing.Point(13, 92);
            this.txtDivisor.Name = "txtDivisor";
            this.txtDivisor.Size = new System.Drawing.Size(20, 21);
            this.txtDivisor.TabIndex = 15;
            this.txtDivisor.Visible = false;
            this.txtDivisor.TextChanged += new System.EventHandler(this.txtDivisor_TextChanged);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.Image = global::CapaPresentacion.Properties.Resources.menos;
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.Location = new System.Drawing.Point(604, 92);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(74, 27);
            this.btnQuitar.TabIndex = 10;
            this.btnQuitar.Text = "[Supr]";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnBuscarItem
            // 
            this.btnBuscarItem.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscarItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarItem.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuscarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarItem.Font = new System.Drawing.Font("Times New Roman", 8.7F);
            this.btnBuscarItem.Image = global::CapaPresentacion.Properties.Resources.boton_de_un_ojo;
            this.btnBuscarItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarItem.Location = new System.Drawing.Point(605, 28);
            this.btnBuscarItem.Name = "btnBuscarItem";
            this.btnBuscarItem.Size = new System.Drawing.Size(73, 26);
            this.btnBuscarItem.TabIndex = 8;
            this.btnBuscarItem.Text = "[F5]";
            this.btnBuscarItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarItem.UseVisualStyleBackColor = false;
            this.btnBuscarItem.Click += new System.EventHandler(this.btnBuscarItem_Click);
            // 
            // txtUsuarioNombre
            // 
            this.txtUsuarioNombre.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtUsuarioNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuarioNombre.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtUsuarioNombre.ForeColor = System.Drawing.Color.Black;
            this.txtUsuarioNombre.Location = new System.Drawing.Point(361, 31);
            this.txtUsuarioNombre.Name = "txtUsuarioNombre";
            this.txtUsuarioNombre.ReadOnly = true;
            this.txtUsuarioNombre.Size = new System.Drawing.Size(160, 23);
            this.txtUsuarioNombre.TabIndex = 3;
            this.txtUsuarioNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtItem
            // 
            this.txtItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItem.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtItem.ForeColor = System.Drawing.Color.Black;
            this.txtItem.Location = new System.Drawing.Point(58, 31);
            this.txtItem.Name = "txtItem";
            this.txtItem.ReadOnly = true;
            this.txtItem.Size = new System.Drawing.Size(297, 23);
            this.txtItem.TabIndex = 3;
            this.txtItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label7.Location = new System.Drawing.Point(391, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Personal/Empleado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label3.Location = new System.Drawing.Point(183, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Servicio";
            // 
            // txtCodItem
            // 
            this.txtCodItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCodItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodItem.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtCodItem.ForeColor = System.Drawing.Color.Black;
            this.txtCodItem.Location = new System.Drawing.Point(18, 31);
            this.txtCodItem.Name = "txtCodItem";
            this.txtCodItem.Size = new System.Drawing.Size(37, 23);
            this.txtCodItem.TabIndex = 1;
            this.txtCodItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label1.Location = new System.Drawing.Point(20, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cod.";
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(418, 523);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(62, 26);
            this.btnEditar.TabIndex = 13;
            this.btnEditar.Text = "Editar[F2]";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.Nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(225, 523);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(89, 26);
            this.btnNuevo.TabIndex = 12;
            this.btnNuevo.Text = "Nuevo[F1]";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(320, 523);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(92, 26);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar[F4]";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(902, 583);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblSinRegistros);
            this.tabPage1.Controls.Add(this.gbFechas);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.dataListado);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.chkEliminar);
            this.tabPage1.Controls.Add(this.btnImprimir);
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(894, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblSinRegistros
            // 
            this.lblSinRegistros.AutoSize = true;
            this.lblSinRegistros.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSinRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSinRegistros.Location = new System.Drawing.Point(354, 252);
            this.lblSinRegistros.Name = "lblSinRegistros";
            this.lblSinRegistros.Size = new System.Drawing.Size(172, 17);
            this.lblSinRegistros.TabIndex = 16;
            this.lblSinRegistros.Text = "Sin registros para mostrar";
            this.lblSinRegistros.Visible = false;
            // 
            // gbFechas
            // 
            this.gbFechas.Controls.Add(this.dtpfechahasta);
            this.gbFechas.Controls.Add(this.label14);
            this.gbFechas.Controls.Add(this.label2);
            this.gbFechas.Controls.Add(this.dtpFechadesde);
            this.gbFechas.Controls.Add(this.btnBuscar);
            this.gbFechas.Location = new System.Drawing.Point(10, 6);
            this.gbFechas.Name = "gbFechas";
            this.gbFechas.Size = new System.Drawing.Size(462, 69);
            this.gbFechas.TabIndex = 15;
            this.gbFechas.TabStop = false;
            this.gbFechas.Text = "Fechas";
            // 
            // dtpfechahasta
            // 
            this.dtpfechahasta.Checked = false;
            this.dtpfechahasta.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpfechahasta.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.dtpfechahasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfechahasta.Location = new System.Drawing.Point(234, 28);
            this.dtpfechahasta.Name = "dtpfechahasta";
            this.dtpfechahasta.Size = new System.Drawing.Size(142, 24);
            this.dtpfechahasta.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label14.Location = new System.Drawing.Point(189, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 16);
            this.label14.TabIndex = 17;
            this.label14.Text = "Hasta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "De:";
            // 
            // dtpFechadesde
            // 
            this.dtpFechadesde.Checked = false;
            this.dtpFechadesde.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechadesde.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.dtpFechadesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechadesde.Location = new System.Drawing.Point(36, 28);
            this.dtpFechadesde.Name = "dtpFechadesde";
            this.dtpFechadesde.Size = new System.Drawing.Size(147, 24);
            this.dtpFechadesde.TabIndex = 15;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(382, 27);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBuscar.Size = new System.Drawing.Size(63, 25);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "&Filtrar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(708, 103);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(180, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "*Doble click en el registro para editar";
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataListado.BackgroundColor = System.Drawing.Color.White;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.dataListado.Location = new System.Drawing.Point(10, 121);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(878, 430);
            this.dataListado.TabIndex = 7;
            this.dataListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListado_CellContentClick);
            this.dataListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataListado_CellFormatting);
            this.dataListado.DoubleClick += new System.EventHandler(this.dataListado_DoubleClick);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Width = 49;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(331, 96);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(141, 17);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total de registros: 0";
            // 
            // chkEliminar
            // 
            this.chkEliminar.AutoSize = true;
            this.chkEliminar.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.chkEliminar.Location = new System.Drawing.Point(10, 96);
            this.chkEliminar.Name = "chkEliminar";
            this.chkEliminar.Size = new System.Drawing.Size(73, 20);
            this.chkEliminar.TabIndex = 5;
            this.chkEliminar.Text = "Eliminar";
            this.chkEliminar.UseVisualStyleBackColor = true;
            this.chkEliminar.CheckedChanged += new System.EventHandler(this.chkEliminar_CheckedChanged);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.btnImprimir.Location = new System.Drawing.Point(164, 91);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 25);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.btnEliminar.Location = new System.Drawing.Point(89, 91);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(69, 25);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FrmOrdenTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(917, 594);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmOrdenTrabajo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orden de Trabajo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOrdenTrabajo_FormClosing);
            this.Load += new System.EventHandler(this.FrmOrdenTrabajo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmOrdenTrabajo_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmOrdenTrabajo_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbAviso.ResumeLayout(false);
            this.gbAviso.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOT)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gbFechas.ResumeLayout(false);
            this.gbFechas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.CheckBox chkEliminar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvDetalleOT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.TextBox txtGravadas;
        private System.Windows.Forms.TextBox txtDivisor;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnBuscarItem;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodItem;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtClienteNro;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.TextBox txtNumeracion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.TextBox txtFormula;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lbltotalgral;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbAviso;
        private System.Windows.Forms.TextBox txtDias;
        private System.Windows.Forms.DateTimePicker dtpFechaVisita;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox txtUsuarioNro;
        private System.Windows.Forms.TextBox txtUsuarioNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGanancia;
        private System.Windows.Forms.TextBox txtComisionServicio;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbFechas;
        private System.Windows.Forms.DateTimePicker dtpfechahasta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechadesde;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblSinRegistros;
    }
}