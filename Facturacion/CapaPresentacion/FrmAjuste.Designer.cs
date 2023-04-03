namespace CapaPresentacion
{
    partial class FrmAjuste
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAjuste));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.dgvDetalleAjuste = new System.Windows.Forms.DataGridView();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.txtTotalGral = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtExistencia = new System.Windows.Forms.TextBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodItem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cboTipoAjuste = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtpfechahasta = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechadesde = new System.Windows.Forms.DateTimePicker();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.chkEliminar = new System.Windows.Forms.CheckBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleAjuste)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(521, 7);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBuscar.Size = new System.Drawing.Size(84, 28);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.errorIcono.SetIconAlignment(this.btnAgregar, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.btnAgregar.Image = global::CapaPresentacion.Properties.Resources.mas;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(821, 49);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(89, 30);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumero.ForeColor = System.Drawing.SystemColors.InfoText;
            this.errorIcono.SetIconAlignment(this.txtNumero, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtNumero.Location = new System.Drawing.Point(56, 18);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(99, 27);
            this.txtNumero.TabIndex = 0;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.errorIcono.SetIconAlignment(this.btnQuitar, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.btnQuitar.Image = global::CapaPresentacion.Properties.Resources.menos;
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.Location = new System.Drawing.Point(921, 49);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(83, 30);
            this.btnQuitar.TabIndex = 9;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // dgvDetalleAjuste
            // 
            this.dgvDetalleAjuste.AllowUserToAddRows = false;
            this.dgvDetalleAjuste.AllowUserToDeleteRows = false;
            this.dgvDetalleAjuste.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleAjuste.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalleAjuste.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetalleAjuste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleAjuste.Location = new System.Drawing.Point(53, 240);
            this.dgvDetalleAjuste.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDetalleAjuste.Name = "dgvDetalleAjuste";
            this.dgvDetalleAjuste.RowHeadersWidth = 51;
            this.dgvDetalleAjuste.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleAjuste.Size = new System.Drawing.Size(908, 233);
            this.dgvDetalleAjuste.TabIndex = 25;
            this.dgvDetalleAjuste.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetalleAjuste_CellFormatting);
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label7.Location = new System.Drawing.Point(743, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 19);
            this.label7.TabIndex = 31;
            this.label7.Text = "Motivo:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(599, 21);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(136, 29);
            this.dtpFecha.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LblUsuario);
            this.tabPage2.Controls.Add(this.lblSerie);
            this.tabPage2.Controls.Add(this.txtTotalGral);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.dgvDetalleAjuste);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.txtObservacion);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.btnCancelar);
            this.tabPage2.Controls.Add(this.btnGuardar);
            this.tabPage2.Controls.Add(this.btnNuevo);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1136, 648);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.LblUsuario.Location = new System.Drawing.Point(940, 620);
            this.LblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(42, 19);
            this.LblUsuario.TabIndex = 30;
            this.LblUsuario.Text = "User";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblSerie.Location = new System.Drawing.Point(855, 619);
            this.lblSerie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(68, 19);
            this.lblSerie.TabIndex = 29;
            this.lblSerie.Text = "Usuario:";
            // 
            // txtTotalGral
            // 
            this.txtTotalGral.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalGral.Location = new System.Drawing.Point(807, 480);
            this.txtTotalGral.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalGral.Name = "txtTotalGral";
            this.txtTotalGral.ReadOnly = true;
            this.txtTotalGral.Size = new System.Drawing.Size(153, 29);
            this.txtTotalGral.TabIndex = 28;
            this.txtTotalGral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(745, 485);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 19);
            this.label11.TabIndex = 27;
            this.label11.Text = "Total:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStock);
            this.groupBox2.Controls.Add(this.txtExistencia);
            this.groupBox2.Controls.Add(this.btnQuitar);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.btnBuscarProducto);
            this.groupBox2.Controls.Add(this.txtCantidad);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtPrecio);
            this.groupBox2.Controls.Add(this.txtItem);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCodItem);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.groupBox2.Location = new System.Drawing.Point(9, 118);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1057, 106);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Productos";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblStock.Location = new System.Drawing.Point(497, 28);
            this.lblStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(80, 19);
            this.lblStock.TabIndex = 20;
            this.lblStock.Text = "Existencia";
            // 
            // txtExistencia
            // 
            this.txtExistencia.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtExistencia.Location = new System.Drawing.Point(499, 52);
            this.txtExistencia.Margin = new System.Windows.Forms.Padding(4);
            this.txtExistencia.Name = "txtExistencia";
            this.txtExistencia.Size = new System.Drawing.Size(85, 27);
            this.txtExistencia.TabIndex = 19;
            this.txtExistencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarProducto.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.btnBuscarProducto.Image = global::CapaPresentacion.Properties.Resources.boton_de_un_ojo;
            this.btnBuscarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarProducto.Location = new System.Drawing.Point(717, 49);
            this.btnBuscarProducto.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(95, 30);
            this.btnBuscarProducto.TabIndex = 7;
            this.btnBuscarProducto.Text = "Buscar";
            this.btnBuscarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarItem_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtCantidad.Location = new System.Drawing.Point(593, 52);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(88, 27);
            this.txtCantidad.TabIndex = 9;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label6.Location = new System.Drawing.Point(597, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Cantidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label5.Location = new System.Drawing.Point(401, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Precio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtPrecio.Location = new System.Drawing.Point(360, 52);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(132, 27);
            this.txtPrecio.TabIndex = 6;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtItem
            // 
            this.txtItem.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtItem.Location = new System.Drawing.Point(83, 52);
            this.txtItem.Margin = new System.Windows.Forms.Padding(4);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(268, 27);
            this.txtItem.TabIndex = 3;
            this.txtItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label3.Location = new System.Drawing.Point(184, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Producto";
            // 
            // txtCodItem
            // 
            this.txtCodItem.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtCodItem.Location = new System.Drawing.Point(25, 52);
            this.txtCodItem.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodItem.Name = "txtCodItem";
            this.txtCodItem.Size = new System.Drawing.Size(48, 27);
            this.txtCodItem.TabIndex = 1;
            this.txtCodItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label1.Location = new System.Drawing.Point(25, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cod.";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(53, 508);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservacion.MaxLength = 250;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(415, 125);
            this.txtObservacion.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label13.Location = new System.Drawing.Point(57, 485);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 19);
            this.label13.TabIndex = 23;
            this.label13.Text = "Observacion:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(701, 588);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 28);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(600, 586);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(93, 32);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.Nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(508, 586);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(84, 32);
            this.btnNuevo.TabIndex = 12;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.Controls.Add(this.cboTipoAjuste);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.lblDescripcion);
            this.groupBox1.Controls.Add(this.lblCodigo);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.groupBox1.Location = new System.Drawing.Point(5, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1080, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ajuste";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblFecha.Location = new System.Drawing.Point(536, 25);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(54, 19);
            this.lblFecha.TabIndex = 29;
            this.lblFecha.Text = "Fecha:";
            // 
            // cboTipoAjuste
            // 
            this.cboTipoAjuste.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cboTipoAjuste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAjuste.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.cboTipoAjuste.FormattingEnabled = true;
            this.cboTipoAjuste.Location = new System.Drawing.Point(811, 18);
            this.cboTipoAjuste.Margin = new System.Windows.Forms.Padding(4);
            this.cboTipoAjuste.Name = "cboTipoAjuste";
            this.cboTipoAjuste.Size = new System.Drawing.Size(249, 25);
            this.cboTipoAjuste.TabIndex = 6;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtDescripcion.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtDescripcion.Location = new System.Drawing.Point(263, 18);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.MaxLength = 200;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(264, 62);
            this.txtDescripcion.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblDescripcion.Location = new System.Drawing.Point(160, 23);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(98, 19);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblCodigo.Location = new System.Drawing.Point(8, 26);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(45, 19);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Nro.:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(8, 7);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1144, 677);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtpfechahasta);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dtpFechadesde);
            this.tabPage1.Controls.Add(this.dataListado);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.chkEliminar);
            this.tabPage1.Controls.Add(this.btnImprimir);
            this.tabPage1.Controls.Add(this.btnAnular);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1136, 648);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtpfechahasta
            // 
            this.dtpfechahasta.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpfechahasta.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.dtpfechahasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfechahasta.Location = new System.Drawing.Point(345, 7);
            this.dtpfechahasta.Margin = new System.Windows.Forms.Padding(4);
            this.dtpfechahasta.Name = "dtpfechahasta";
            this.dtpfechahasta.Size = new System.Drawing.Size(165, 27);
            this.dtpfechahasta.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label14.Location = new System.Drawing.Point(284, 12);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 19);
            this.label14.TabIndex = 12;
            this.label14.Text = "Hasta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label2.Location = new System.Drawing.Point(51, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "De:";
            // 
            // dtpFechadesde
            // 
            this.dtpFechadesde.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechadesde.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.dtpFechadesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechadesde.Location = new System.Drawing.Point(92, 7);
            this.dtpFechadesde.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechadesde.Name = "dtpFechadesde";
            this.dtpFechadesde.Size = new System.Drawing.Size(163, 27);
            this.dtpFechadesde.TabIndex = 10;
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
            this.dataListado.Location = new System.Drawing.Point(13, 79);
            this.dataListado.Margin = new System.Windows.Forms.Padding(4);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowHeadersWidth = 51;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(1053, 459);
            this.dataListado.TabIndex = 7;
            this.dataListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListado_CellContentClick);
            this.dataListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataListado_CellFormatting);
            this.dataListado.DoubleClick += new System.EventHandler(this.dataListado_DoubleClick);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.MinimumWidth = 6;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Width = 61;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblTotal.Location = new System.Drawing.Point(508, 55);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(146, 19);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total de registros: 0";
            // 
            // chkEliminar
            // 
            this.chkEliminar.AutoSize = true;
            this.chkEliminar.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.chkEliminar.Location = new System.Drawing.Point(16, 50);
            this.chkEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.chkEliminar.Name = "chkEliminar";
            this.chkEliminar.Size = new System.Drawing.Size(90, 23);
            this.chkEliminar.TabIndex = 5;
            this.chkEliminar.Text = "Eliminar";
            this.chkEliminar.UseVisualStyleBackColor = true;
            this.chkEliminar.CheckedChanged += new System.EventHandler(this.chkAnular_CheckedChanged);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(700, 7);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 28);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.Location = new System.Drawing.Point(613, 7);
            this.btnAnular.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(79, 28);
            this.btnAnular.TabIndex = 3;
            this.btnAnular.Text = "&Eliminar";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // FrmAjuste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1167, 697);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmAjuste";
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAjuste_FormClosing);
            this.Load += new System.EventHandler(this.FrmAjuste_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleAjuste)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DateTimePicker dtpfechahasta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechadesde;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.CheckBox chkEliminar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvDetalleAjuste;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtExistencia;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ComboBox cboTipoAjuste;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.TextBox txtTotalGral;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.Button btnBuscarProducto;
    }
}