namespace CapaPresentacion.Formularios.Facturacion
{
    partial class FrmFacturaVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFacturaVenta));
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnQuitar = new CapaPresentacion.Utilidades.RButton();
            this.btnAgregar = new CapaPresentacion.Utilidades.RButton();
            this.btnBuscarItem = new CapaPresentacion.Utilidades.RButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExistencia = new System.Windows.Forms.TextBox();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodItem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpfechahasta = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechadesde = new System.Windows.Forms.DateTimePicker();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.Anular = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvDetalleFactura = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.chkAnular = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalGravadas = new System.Windows.Forms.TextBox();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbTipo = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbManual = new System.Windows.Forms.RadioButton();
            this.rbAutoimprenta = new System.Windows.Forms.RadioButton();
            this.cboComprobante = new System.Windows.Forms.ComboBox();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.lblAyuda = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNumeracionOT = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNroFactura = new System.Windows.Forms.TextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.cboTipoPago = new System.Windows.Forms.ComboBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnImprimir = new CapaPresentacion.Utilidades.RButton();
            this.btnAnular = new CapaPresentacion.Utilidades.RButton();
            this.btnBuscar = new CapaPresentacion.Utilidades.RButton();
            this.lblSinRegistros = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnImprimir2 = new CapaPresentacion.Utilidades.RButton();
            this.btnCancelar = new CapaPresentacion.Utilidades.RButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTotalGral = new System.Windows.Forms.TextBox();
            this.txttotalIva = new System.Windows.Forms.TextBox();
            this.btnGuardar = new CapaPresentacion.Utilidades.RButton();
            this.btnNuevo = new CapaPresentacion.Utilidades.RButton();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.gbTipo.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.errorIcono.SetError(this.label11, resources.GetString("label11.Error"));
            this.errorIcono.SetIconAlignment(this.label11, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label11.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.label11, ((int)(resources.GetObject("label11.IconPadding"))));
            this.label11.Name = "label11";
            this.ttMensaje.SetToolTip(this.label11, resources.GetString("label11.ToolTip"));
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.btnQuitar);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.btnBuscarItem);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtExistencia);
            this.groupBox2.Controls.Add(this.txtIva);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtCantidad);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtPrecio);
            this.groupBox2.Controls.Add(this.txtItem);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCodItem);
            this.groupBox2.Controls.Add(this.label1);
            this.errorIcono.SetError(this.groupBox2, resources.GetString("groupBox2.Error"));
            this.errorIcono.SetIconAlignment(this.groupBox2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("groupBox2.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.groupBox2, ((int)(resources.GetObject("groupBox2.IconPadding"))));
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.ttMensaje.SetToolTip(this.groupBox2, resources.GetString("groupBox2.ToolTip"));
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnQuitar
            // 
            resources.ApplyResources(this.btnQuitar, "btnQuitar");
            this.btnQuitar.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnQuitar.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnQuitar.BorderColor = System.Drawing.Color.Lavender;
            this.btnQuitar.BorderRadius = 10;
            this.btnQuitar.BorderSize = 0;
            this.errorIcono.SetError(this.btnQuitar, resources.GetString("btnQuitar.Error"));
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.ForeColor = System.Drawing.Color.White;
            this.errorIcono.SetIconAlignment(this.btnQuitar, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnQuitar.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.btnQuitar, ((int)(resources.GetObject("btnQuitar.IconPadding"))));
            this.btnQuitar.Image = global::CapaPresentacion.Properties.Resources.menos;
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.TextColor = System.Drawing.Color.White;
            this.ttMensaje.SetToolTip(this.btnQuitar, resources.GetString("btnQuitar.ToolTip"));
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            resources.ApplyResources(this.btnAgregar, "btnAgregar");
            this.btnAgregar.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAgregar.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAgregar.BorderColor = System.Drawing.Color.Lavender;
            this.btnAgregar.BorderRadius = 10;
            this.btnAgregar.BorderSize = 0;
            this.errorIcono.SetError(this.btnAgregar, resources.GetString("btnAgregar.Error"));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.errorIcono.SetIconAlignment(this.btnAgregar, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnAgregar.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.btnAgregar, ((int)(resources.GetObject("btnAgregar.IconPadding"))));
            this.btnAgregar.Image = global::CapaPresentacion.Properties.Resources.mas;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.TextColor = System.Drawing.Color.White;
            this.ttMensaje.SetToolTip(this.btnAgregar, resources.GetString("btnAgregar.ToolTip"));
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBuscarItem
            // 
            resources.ApplyResources(this.btnBuscarItem, "btnBuscarItem");
            this.btnBuscarItem.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnBuscarItem.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnBuscarItem.BorderColor = System.Drawing.Color.Lavender;
            this.btnBuscarItem.BorderRadius = 10;
            this.btnBuscarItem.BorderSize = 0;
            this.errorIcono.SetError(this.btnBuscarItem, resources.GetString("btnBuscarItem.Error"));
            this.btnBuscarItem.FlatAppearance.BorderSize = 0;
            this.btnBuscarItem.ForeColor = System.Drawing.Color.White;
            this.errorIcono.SetIconAlignment(this.btnBuscarItem, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnBuscarItem.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.btnBuscarItem, ((int)(resources.GetObject("btnBuscarItem.IconPadding"))));
            this.btnBuscarItem.Name = "btnBuscarItem";
            this.btnBuscarItem.TextColor = System.Drawing.Color.White;
            this.ttMensaje.SetToolTip(this.btnBuscarItem, resources.GetString("btnBuscarItem.ToolTip"));
            this.btnBuscarItem.UseVisualStyleBackColor = false;
            this.btnBuscarItem.Click += new System.EventHandler(this.btnBuscarItem_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.errorIcono.SetError(this.label4, resources.GetString("label4.Error"));
            this.errorIcono.SetIconAlignment(this.label4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label4.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.label4, ((int)(resources.GetObject("label4.IconPadding"))));
            this.label4.Name = "label4";
            this.ttMensaje.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // txtExistencia
            // 
            resources.ApplyResources(this.txtExistencia, "txtExistencia");
            this.txtExistencia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.errorIcono.SetError(this.txtExistencia, resources.GetString("txtExistencia.Error"));
            this.errorIcono.SetIconAlignment(this.txtExistencia, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtExistencia.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.txtExistencia, ((int)(resources.GetObject("txtExistencia.IconPadding"))));
            this.txtExistencia.Name = "txtExistencia";
            this.ttMensaje.SetToolTip(this.txtExistencia, resources.GetString("txtExistencia.ToolTip"));
            // 
            // txtIva
            // 
            resources.ApplyResources(this.txtIva, "txtIva");
            this.txtIva.BackColor = System.Drawing.Color.WhiteSmoke;
            this.errorIcono.SetError(this.txtIva, resources.GetString("txtIva.Error"));
            this.errorIcono.SetIconAlignment(this.txtIva, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtIva.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.txtIva, ((int)(resources.GetObject("txtIva.IconPadding"))));
            this.txtIva.Name = "txtIva";
            this.ttMensaje.SetToolTip(this.txtIva, resources.GetString("txtIva.ToolTip"));
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.errorIcono.SetError(this.label12, resources.GetString("label12.Error"));
            this.errorIcono.SetIconAlignment(this.label12, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label12.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.label12, ((int)(resources.GetObject("label12.IconPadding"))));
            this.label12.Name = "label12";
            this.ttMensaje.SetToolTip(this.label12, resources.GetString("label12.ToolTip"));
            // 
            // txtCantidad
            // 
            resources.ApplyResources(this.txtCantidad, "txtCantidad");
            this.errorIcono.SetError(this.txtCantidad, resources.GetString("txtCantidad.Error"));
            this.errorIcono.SetIconAlignment(this.txtCantidad, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtCantidad.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.txtCantidad, ((int)(resources.GetObject("txtCantidad.IconPadding"))));
            this.txtCantidad.Name = "txtCantidad";
            this.ttMensaje.SetToolTip(this.txtCantidad, resources.GetString("txtCantidad.ToolTip"));
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.errorIcono.SetError(this.label6, resources.GetString("label6.Error"));
            this.errorIcono.SetIconAlignment(this.label6, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label6.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.label6, ((int)(resources.GetObject("label6.IconPadding"))));
            this.label6.Name = "label6";
            this.ttMensaje.SetToolTip(this.label6, resources.GetString("label6.ToolTip"));
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.errorIcono.SetError(this.label5, resources.GetString("label5.Error"));
            this.errorIcono.SetIconAlignment(this.label5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label5.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.label5, ((int)(resources.GetObject("label5.IconPadding"))));
            this.label5.Name = "label5";
            this.ttMensaje.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // txtPrecio
            // 
            resources.ApplyResources(this.txtPrecio, "txtPrecio");
            this.txtPrecio.BackColor = System.Drawing.SystemColors.Window;
            this.errorIcono.SetError(this.txtPrecio, resources.GetString("txtPrecio.Error"));
            this.errorIcono.SetIconAlignment(this.txtPrecio, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtPrecio.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.txtPrecio, ((int)(resources.GetObject("txtPrecio.IconPadding"))));
            this.txtPrecio.Name = "txtPrecio";
            this.ttMensaje.SetToolTip(this.txtPrecio, resources.GetString("txtPrecio.ToolTip"));
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            this.txtPrecio.Leave += new System.EventHandler(this.txtPrecio_Leave);
            // 
            // txtItem
            // 
            resources.ApplyResources(this.txtItem, "txtItem");
            this.txtItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.errorIcono.SetError(this.txtItem, resources.GetString("txtItem.Error"));
            this.errorIcono.SetIconAlignment(this.txtItem, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtItem.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.txtItem, ((int)(resources.GetObject("txtItem.IconPadding"))));
            this.txtItem.Name = "txtItem";
            this.ttMensaje.SetToolTip(this.txtItem, resources.GetString("txtItem.ToolTip"));
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.errorIcono.SetError(this.label3, resources.GetString("label3.Error"));
            this.errorIcono.SetIconAlignment(this.label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.label3, ((int)(resources.GetObject("label3.IconPadding"))));
            this.label3.Name = "label3";
            this.ttMensaje.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // txtCodItem
            // 
            resources.ApplyResources(this.txtCodItem, "txtCodItem");
            this.txtCodItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.errorIcono.SetError(this.txtCodItem, resources.GetString("txtCodItem.Error"));
            this.errorIcono.SetIconAlignment(this.txtCodItem, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtCodItem.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.txtCodItem, ((int)(resources.GetObject("txtCodItem.IconPadding"))));
            this.txtCodItem.Name = "txtCodItem";
            this.ttMensaje.SetToolTip(this.txtCodItem, resources.GetString("txtCodItem.ToolTip"));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.errorIcono.SetError(this.label1, resources.GetString("label1.Error"));
            this.errorIcono.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.label1.Name = "label1";
            this.ttMensaje.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // dtpfechahasta
            // 
            resources.ApplyResources(this.dtpfechahasta, "dtpfechahasta");
            this.errorIcono.SetError(this.dtpfechahasta, resources.GetString("dtpfechahasta.Error"));
            this.dtpfechahasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.errorIcono.SetIconAlignment(this.dtpfechahasta, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("dtpfechahasta.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.dtpfechahasta, ((int)(resources.GetObject("dtpfechahasta.IconPadding"))));
            this.dtpfechahasta.Name = "dtpfechahasta";
            this.ttMensaje.SetToolTip(this.dtpfechahasta, resources.GetString("dtpfechahasta.ToolTip"));
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.errorIcono.SetError(this.label14, resources.GetString("label14.Error"));
            this.errorIcono.SetIconAlignment(this.label14, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label14.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.label14, ((int)(resources.GetObject("label14.IconPadding"))));
            this.label14.Name = "label14";
            this.ttMensaje.SetToolTip(this.label14, resources.GetString("label14.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.errorIcono.SetError(this.label2, resources.GetString("label2.Error"));
            this.errorIcono.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
            this.label2.Name = "label2";
            this.ttMensaje.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // dtpFechadesde
            // 
            resources.ApplyResources(this.dtpFechadesde, "dtpFechadesde");
            this.errorIcono.SetError(this.dtpFechadesde, resources.GetString("dtpFechadesde.Error"));
            this.dtpFechadesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.errorIcono.SetIconAlignment(this.dtpFechadesde, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("dtpFechadesde.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.dtpFechadesde, ((int)(resources.GetObject("dtpFechadesde.IconPadding"))));
            this.dtpFechadesde.Name = "dtpFechadesde";
            this.ttMensaje.SetToolTip(this.dtpFechadesde, resources.GetString("dtpFechadesde.ToolTip"));
            // 
            // dataListado
            // 
            resources.ApplyResources(this.dataListado, "dataListado");
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataListado.BackgroundColor = System.Drawing.Color.White;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Anular});
            this.errorIcono.SetError(this.dataListado, resources.GetString("dataListado.Error"));
            this.errorIcono.SetIconAlignment(this.dataListado, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("dataListado.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.dataListado, ((int)(resources.GetObject("dataListado.IconPadding"))));
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowHeadersVisible = false;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ttMensaje.SetToolTip(this.dataListado, resources.GetString("dataListado.ToolTip"));
            this.dataListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListado_CellContentClick);
            this.dataListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataListado_CellFormatting);
            this.dataListado.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataListado_CellPainting);
            this.dataListado.DoubleClick += new System.EventHandler(this.dataListado_DoubleClick);
            // 
            // Anular
            // 
            resources.ApplyResources(this.Anular, "Anular");
            this.Anular.Name = "Anular";
            this.Anular.ReadOnly = true;
            // 
            // dgvDetalleFactura
            // 
            resources.ApplyResources(this.dgvDetalleFactura, "dgvDetalleFactura");
            this.dgvDetalleFactura.AllowUserToAddRows = false;
            this.dgvDetalleFactura.AllowUserToDeleteRows = false;
            this.dgvDetalleFactura.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.errorIcono.SetError(this.dgvDetalleFactura, resources.GetString("dgvDetalleFactura.Error"));
            this.errorIcono.SetIconAlignment(this.dgvDetalleFactura, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("dgvDetalleFactura.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.dgvDetalleFactura, ((int)(resources.GetObject("dgvDetalleFactura.IconPadding"))));
            this.dgvDetalleFactura.MultiSelect = false;
            this.dgvDetalleFactura.Name = "dgvDetalleFactura";
            this.dgvDetalleFactura.ReadOnly = true;
            this.dgvDetalleFactura.RowHeadersVisible = false;
            this.dgvDetalleFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ttMensaje.SetToolTip(this.dgvDetalleFactura, resources.GetString("dgvDetalleFactura.ToolTip"));
            this.dgvDetalleFactura.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetalleFactura_CellFormatting);
            this.dgvDetalleFactura.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetalleFactura_CellMouseClick);
            this.dgvDetalleFactura.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDetalleFactura_KeyDown);
            // 
            // lblTotal
            // 
            resources.ApplyResources(this.lblTotal, "lblTotal");
            this.errorIcono.SetError(this.lblTotal, resources.GetString("lblTotal.Error"));
            this.errorIcono.SetIconAlignment(this.lblTotal, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblTotal.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.lblTotal, ((int)(resources.GetObject("lblTotal.IconPadding"))));
            this.lblTotal.Name = "lblTotal";
            this.ttMensaje.SetToolTip(this.lblTotal, resources.GetString("lblTotal.ToolTip"));
            // 
            // chkAnular
            // 
            resources.ApplyResources(this.chkAnular, "chkAnular");
            this.errorIcono.SetError(this.chkAnular, resources.GetString("chkAnular.Error"));
            this.errorIcono.SetIconAlignment(this.chkAnular, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("chkAnular.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.chkAnular, ((int)(resources.GetObject("chkAnular.IconPadding"))));
            this.chkAnular.Name = "chkAnular";
            this.ttMensaje.SetToolTip(this.chkAnular, resources.GetString("chkAnular.ToolTip"));
            this.chkAnular.UseVisualStyleBackColor = true;
            this.chkAnular.CheckedChanged += new System.EventHandler(this.chkAnular_CheckedChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.errorIcono.SetError(this.label10, resources.GetString("label10.Error"));
            this.errorIcono.SetIconAlignment(this.label10, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label10.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.label10, ((int)(resources.GetObject("label10.IconPadding"))));
            this.label10.Name = "label10";
            this.ttMensaje.SetToolTip(this.label10, resources.GetString("label10.ToolTip"));
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.errorIcono.SetError(this.label9, resources.GetString("label9.Error"));
            this.errorIcono.SetIconAlignment(this.label9, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label9.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.label9, ((int)(resources.GetObject("label9.IconPadding"))));
            this.label9.Name = "label9";
            this.ttMensaje.SetToolTip(this.label9, resources.GetString("label9.ToolTip"));
            // 
            // txtTotalGravadas
            // 
            resources.ApplyResources(this.txtTotalGravadas, "txtTotalGravadas");
            this.txtTotalGravadas.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.errorIcono.SetError(this.txtTotalGravadas, resources.GetString("txtTotalGravadas.Error"));
            this.errorIcono.SetIconAlignment(this.txtTotalGravadas, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtTotalGravadas.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.txtTotalGravadas, ((int)(resources.GetObject("txtTotalGravadas.IconPadding"))));
            this.txtTotalGravadas.Name = "txtTotalGravadas";
            this.ttMensaje.SetToolTip(this.txtTotalGravadas, resources.GetString("txtTotalGravadas.ToolTip"));
            // 
            // txtObservacion
            // 
            resources.ApplyResources(this.txtObservacion, "txtObservacion");
            this.errorIcono.SetError(this.txtObservacion, resources.GetString("txtObservacion.Error"));
            this.errorIcono.SetIconAlignment(this.txtObservacion, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtObservacion.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.txtObservacion, ((int)(resources.GetObject("txtObservacion.IconPadding"))));
            this.txtObservacion.Name = "txtObservacion";
            this.ttMensaje.SetToolTip(this.txtObservacion, resources.GetString("txtObservacion.ToolTip"));
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.errorIcono.SetError(this.label13, resources.GetString("label13.Error"));
            this.errorIcono.SetIconAlignment(this.label13, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label13.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.label13, ((int)(resources.GetObject("label13.IconPadding"))));
            this.label13.Name = "label13";
            this.ttMensaje.SetToolTip(this.label13, resources.GetString("label13.ToolTip"));
            // 
            // lblFecha
            // 
            resources.ApplyResources(this.lblFecha, "lblFecha");
            this.errorIcono.SetError(this.lblFecha, resources.GetString("lblFecha.Error"));
            this.errorIcono.SetIconAlignment(this.lblFecha, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblFecha.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.lblFecha, ((int)(resources.GetObject("lblFecha.IconPadding"))));
            this.lblFecha.Name = "lblFecha";
            this.ttMensaje.SetToolTip(this.lblFecha, resources.GetString("lblFecha.ToolTip"));
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            resources.ApplyResources(this.errorIcono, "errorIcono");
            // 
            // gbTipo
            // 
            resources.ApplyResources(this.gbTipo, "gbTipo");
            this.gbTipo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.gbTipo.Controls.Add(this.groupBox4);
            this.gbTipo.Controls.Add(this.cboComprobante);
            this.gbTipo.Controls.Add(this.lblComprobante);
            this.gbTipo.Controls.Add(this.lblAyuda);
            this.gbTipo.Controls.Add(this.label18);
            this.gbTipo.Controls.Add(this.txtNumeracionOT);
            this.gbTipo.Controls.Add(this.label16);
            this.gbTipo.Controls.Add(this.txtNroFactura);
            this.gbTipo.Controls.Add(this.txtDocumento);
            this.gbTipo.Controls.Add(this.label7);
            this.gbTipo.Controls.Add(this.dtpFecha);
            this.gbTipo.Controls.Add(this.lblFecha);
            this.gbTipo.Controls.Add(this.btnBuscarCliente);
            this.gbTipo.Controls.Add(this.cboTipoPago);
            this.gbTipo.Controls.Add(this.txtCliente);
            this.gbTipo.Controls.Add(this.lblProveedor);
            this.gbTipo.Controls.Add(this.lblDescripcion);
            this.errorIcono.SetError(this.gbTipo, resources.GetString("gbTipo.Error"));
            this.errorIcono.SetIconAlignment(this.gbTipo, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("gbTipo.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.gbTipo, ((int)(resources.GetObject("gbTipo.IconPadding"))));
            this.gbTipo.Name = "gbTipo";
            this.gbTipo.TabStop = false;
            this.ttMensaje.SetToolTip(this.gbTipo, resources.GetString("gbTipo.ToolTip"));
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.rbManual);
            this.groupBox4.Controls.Add(this.rbAutoimprenta);
            this.errorIcono.SetError(this.groupBox4, resources.GetString("groupBox4.Error"));
            this.errorIcono.SetIconAlignment(this.groupBox4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("groupBox4.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.groupBox4, ((int)(resources.GetObject("groupBox4.IconPadding"))));
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            this.ttMensaje.SetToolTip(this.groupBox4, resources.GetString("groupBox4.ToolTip"));
            // 
            // rbManual
            // 
            resources.ApplyResources(this.rbManual, "rbManual");
            this.errorIcono.SetError(this.rbManual, resources.GetString("rbManual.Error"));
            this.errorIcono.SetIconAlignment(this.rbManual, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("rbManual.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.rbManual, ((int)(resources.GetObject("rbManual.IconPadding"))));
            this.rbManual.Name = "rbManual";
            this.ttMensaje.SetToolTip(this.rbManual, resources.GetString("rbManual.ToolTip"));
            this.rbManual.UseVisualStyleBackColor = true;
            // 
            // rbAutoimprenta
            // 
            resources.ApplyResources(this.rbAutoimprenta, "rbAutoimprenta");
            this.rbAutoimprenta.Checked = true;
            this.errorIcono.SetError(this.rbAutoimprenta, resources.GetString("rbAutoimprenta.Error"));
            this.errorIcono.SetIconAlignment(this.rbAutoimprenta, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("rbAutoimprenta.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.rbAutoimprenta, ((int)(resources.GetObject("rbAutoimprenta.IconPadding"))));
            this.rbAutoimprenta.Name = "rbAutoimprenta";
            this.rbAutoimprenta.TabStop = true;
            this.ttMensaje.SetToolTip(this.rbAutoimprenta, resources.GetString("rbAutoimprenta.ToolTip"));
            this.rbAutoimprenta.UseVisualStyleBackColor = true;
            // 
            // cboComprobante
            // 
            resources.ApplyResources(this.cboComprobante, "cboComprobante");
            this.cboComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.errorIcono.SetError(this.cboComprobante, resources.GetString("cboComprobante.Error"));
            this.cboComprobante.FormattingEnabled = true;
            this.errorIcono.SetIconAlignment(this.cboComprobante, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cboComprobante.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.cboComprobante, ((int)(resources.GetObject("cboComprobante.IconPadding"))));
            this.cboComprobante.Name = "cboComprobante";
            this.ttMensaje.SetToolTip(this.cboComprobante, resources.GetString("cboComprobante.ToolTip"));
            this.cboComprobante.SelectedIndexChanged += new System.EventHandler(this.cboComprobante_SelectedIndexChanged);
            // 
            // lblComprobante
            // 
            resources.ApplyResources(this.lblComprobante, "lblComprobante");
            this.errorIcono.SetError(this.lblComprobante, resources.GetString("lblComprobante.Error"));
            this.errorIcono.SetIconAlignment(this.lblComprobante, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblComprobante.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.lblComprobante, ((int)(resources.GetObject("lblComprobante.IconPadding"))));
            this.lblComprobante.Name = "lblComprobante";
            this.ttMensaje.SetToolTip(this.lblComprobante, resources.GetString("lblComprobante.ToolTip"));
            // 
            // lblAyuda
            // 
            resources.ApplyResources(this.lblAyuda, "lblAyuda");
            this.errorIcono.SetError(this.lblAyuda, resources.GetString("lblAyuda.Error"));
            this.errorIcono.SetIconAlignment(this.lblAyuda, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblAyuda.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.lblAyuda, ((int)(resources.GetObject("lblAyuda.IconPadding"))));
            this.lblAyuda.Name = "lblAyuda";
            this.ttMensaje.SetToolTip(this.lblAyuda, resources.GetString("lblAyuda.ToolTip"));
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.errorIcono.SetError(this.label18, resources.GetString("label18.Error"));
            this.errorIcono.SetIconAlignment(this.label18, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label18.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.label18, ((int)(resources.GetObject("label18.IconPadding"))));
            this.label18.Name = "label18";
            this.ttMensaje.SetToolTip(this.label18, resources.GetString("label18.ToolTip"));
            // 
            // txtNumeracionOT
            // 
            resources.ApplyResources(this.txtNumeracionOT, "txtNumeracionOT");
            this.errorIcono.SetError(this.txtNumeracionOT, resources.GetString("txtNumeracionOT.Error"));
            this.errorIcono.SetIconAlignment(this.txtNumeracionOT, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtNumeracionOT.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.txtNumeracionOT, ((int)(resources.GetObject("txtNumeracionOT.IconPadding"))));
            this.txtNumeracionOT.Name = "txtNumeracionOT";
            this.ttMensaje.SetToolTip(this.txtNumeracionOT, resources.GetString("txtNumeracionOT.ToolTip"));
            this.txtNumeracionOT.Leave += new System.EventHandler(this.txtNumeracionOT_Leave);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.errorIcono.SetError(this.label16, resources.GetString("label16.Error"));
            this.errorIcono.SetIconAlignment(this.label16, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label16.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.label16, ((int)(resources.GetObject("label16.IconPadding"))));
            this.label16.Name = "label16";
            this.ttMensaje.SetToolTip(this.label16, resources.GetString("label16.ToolTip"));
            // 
            // txtNroFactura
            // 
            resources.ApplyResources(this.txtNroFactura, "txtNroFactura");
            this.errorIcono.SetError(this.txtNroFactura, resources.GetString("txtNroFactura.Error"));
            this.errorIcono.SetIconAlignment(this.txtNroFactura, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtNroFactura.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.txtNroFactura, ((int)(resources.GetObject("txtNroFactura.IconPadding"))));
            this.txtNroFactura.Name = "txtNroFactura";
            this.ttMensaje.SetToolTip(this.txtNroFactura, resources.GetString("txtNroFactura.ToolTip"));
            this.txtNroFactura.Leave += new System.EventHandler(this.txtDocumento_Leave);
            this.txtNroFactura.Validating += new System.ComponentModel.CancelEventHandler(this.txtNroFactura_Validating);
            // 
            // txtDocumento
            // 
            resources.ApplyResources(this.txtDocumento, "txtDocumento");
            this.errorIcono.SetError(this.txtDocumento, resources.GetString("txtDocumento.Error"));
            this.errorIcono.SetIconAlignment(this.txtDocumento, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtDocumento.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.txtDocumento, ((int)(resources.GetObject("txtDocumento.IconPadding"))));
            this.txtDocumento.Name = "txtDocumento";
            this.ttMensaje.SetToolTip(this.txtDocumento, resources.GetString("txtDocumento.ToolTip"));
            this.txtDocumento.Click += new System.EventHandler(this.txtDocumento_Click);
            this.txtDocumento.Leave += new System.EventHandler(this.txtDocumento_Leave);
            this.txtDocumento.MouseLeave += new System.EventHandler(this.txtDocumento_MouseLeave);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.errorIcono.SetError(this.label7, resources.GetString("label7.Error"));
            this.errorIcono.SetIconAlignment(this.label7, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label7.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.label7, ((int)(resources.GetObject("label7.IconPadding"))));
            this.label7.Name = "label7";
            this.ttMensaje.SetToolTip(this.label7, resources.GetString("label7.ToolTip"));
            // 
            // dtpFecha
            // 
            resources.ApplyResources(this.dtpFecha, "dtpFecha");
            this.errorIcono.SetError(this.dtpFecha, resources.GetString("dtpFecha.Error"));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.errorIcono.SetIconAlignment(this.dtpFecha, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("dtpFecha.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.dtpFecha, ((int)(resources.GetObject("dtpFecha.IconPadding"))));
            this.dtpFecha.Name = "dtpFecha";
            this.ttMensaje.SetToolTip(this.dtpFecha, resources.GetString("dtpFecha.ToolTip"));
            // 
            // btnBuscarCliente
            // 
            resources.ApplyResources(this.btnBuscarCliente, "btnBuscarCliente");
            this.btnBuscarCliente.BackColor = System.Drawing.Color.Transparent;
            this.errorIcono.SetError(this.btnBuscarCliente, resources.GetString("btnBuscarCliente.Error"));
            this.errorIcono.SetIconAlignment(this.btnBuscarCliente, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnBuscarCliente.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.btnBuscarCliente, ((int)(resources.GetObject("btnBuscarCliente.IconPadding"))));
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.ttMensaje.SetToolTip(this.btnBuscarCliente, resources.GetString("btnBuscarCliente.ToolTip"));
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // cboTipoPago
            // 
            resources.ApplyResources(this.cboTipoPago, "cboTipoPago");
            this.cboTipoPago.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.errorIcono.SetError(this.cboTipoPago, resources.GetString("cboTipoPago.Error"));
            this.cboTipoPago.FormattingEnabled = true;
            this.errorIcono.SetIconAlignment(this.cboTipoPago, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cboTipoPago.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.cboTipoPago, ((int)(resources.GetObject("cboTipoPago.IconPadding"))));
            this.cboTipoPago.Name = "cboTipoPago";
            this.ttMensaje.SetToolTip(this.cboTipoPago, resources.GetString("cboTipoPago.ToolTip"));
            // 
            // txtCliente
            // 
            resources.ApplyResources(this.txtCliente, "txtCliente");
            this.txtCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.errorIcono.SetError(this.txtCliente, resources.GetString("txtCliente.Error"));
            this.errorIcono.SetIconAlignment(this.txtCliente, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtCliente.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.txtCliente, ((int)(resources.GetObject("txtCliente.IconPadding"))));
            this.txtCliente.Name = "txtCliente";
            this.ttMensaje.SetToolTip(this.txtCliente, resources.GetString("txtCliente.ToolTip"));
            // 
            // lblProveedor
            // 
            resources.ApplyResources(this.lblProveedor, "lblProveedor");
            this.errorIcono.SetError(this.lblProveedor, resources.GetString("lblProveedor.Error"));
            this.errorIcono.SetIconAlignment(this.lblProveedor, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblProveedor.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.lblProveedor, ((int)(resources.GetObject("lblProveedor.IconPadding"))));
            this.lblProveedor.Name = "lblProveedor";
            this.ttMensaje.SetToolTip(this.lblProveedor, resources.GetString("lblProveedor.ToolTip"));
            // 
            // lblDescripcion
            // 
            resources.ApplyResources(this.lblDescripcion, "lblDescripcion");
            this.errorIcono.SetError(this.lblDescripcion, resources.GetString("lblDescripcion.Error"));
            this.errorIcono.SetIconAlignment(this.lblDescripcion, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblDescripcion.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.lblDescripcion, ((int)(resources.GetObject("lblDescripcion.IconPadding"))));
            this.lblDescripcion.Name = "lblDescripcion";
            this.ttMensaje.SetToolTip(this.lblDescripcion, resources.GetString("lblDescripcion.ToolTip"));
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.btnImprimir);
            this.tabPage1.Controls.Add(this.btnAnular);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.lblSinRegistros);
            this.tabPage1.Controls.Add(this.dtpfechahasta);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dtpFechadesde);
            this.tabPage1.Controls.Add(this.dataListado);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.chkAnular);
            this.errorIcono.SetError(this.tabPage1, resources.GetString("tabPage1.Error"));
            this.errorIcono.SetIconAlignment(this.tabPage1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tabPage1.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.tabPage1, ((int)(resources.GetObject("tabPage1.IconPadding"))));
            this.tabPage1.Name = "tabPage1";
            this.ttMensaje.SetToolTip(this.tabPage1, resources.GetString("tabPage1.ToolTip"));
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            resources.ApplyResources(this.btnImprimir, "btnImprimir");
            this.btnImprimir.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnImprimir.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnImprimir.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnImprimir.BorderRadius = 10;
            this.btnImprimir.BorderSize = 0;
            this.errorIcono.SetError(this.btnImprimir, resources.GetString("btnImprimir.Error"));
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.errorIcono.SetIconAlignment(this.btnImprimir, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnImprimir.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.btnImprimir, ((int)(resources.GetObject("btnImprimir.IconPadding"))));
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.TextColor = System.Drawing.Color.White;
            this.ttMensaje.SetToolTip(this.btnImprimir, resources.GetString("btnImprimir.ToolTip"));
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnAnular
            // 
            resources.ApplyResources(this.btnAnular, "btnAnular");
            this.btnAnular.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAnular.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAnular.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAnular.BorderRadius = 10;
            this.btnAnular.BorderSize = 0;
            this.errorIcono.SetError(this.btnAnular, resources.GetString("btnAnular.Error"));
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.ForeColor = System.Drawing.Color.White;
            this.errorIcono.SetIconAlignment(this.btnAnular, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnAnular.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.btnAnular, ((int)(resources.GetObject("btnAnular.IconPadding"))));
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.TextColor = System.Drawing.Color.White;
            this.ttMensaje.SetToolTip(this.btnAnular, resources.GetString("btnAnular.ToolTip"));
            this.btnAnular.UseVisualStyleBackColor = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnBuscar
            // 
            resources.ApplyResources(this.btnBuscar, "btnBuscar");
            this.btnBuscar.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnBuscar.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnBuscar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnBuscar.BorderRadius = 10;
            this.btnBuscar.BorderSize = 0;
            this.errorIcono.SetError(this.btnBuscar, resources.GetString("btnBuscar.Error"));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.errorIcono.SetIconAlignment(this.btnBuscar, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnBuscar.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.btnBuscar, ((int)(resources.GetObject("btnBuscar.IconPadding"))));
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.TextColor = System.Drawing.Color.White;
            this.ttMensaje.SetToolTip(this.btnBuscar, resources.GetString("btnBuscar.ToolTip"));
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblSinRegistros
            // 
            resources.ApplyResources(this.lblSinRegistros, "lblSinRegistros");
            this.lblSinRegistros.BackColor = System.Drawing.Color.Gainsboro;
            this.errorIcono.SetError(this.lblSinRegistros, resources.GetString("lblSinRegistros.Error"));
            this.errorIcono.SetIconAlignment(this.lblSinRegistros, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblSinRegistros.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.lblSinRegistros, ((int)(resources.GetObject("lblSinRegistros.IconPadding"))));
            this.lblSinRegistros.Name = "lblSinRegistros";
            this.ttMensaje.SetToolTip(this.lblSinRegistros, resources.GetString("lblSinRegistros.ToolTip"));
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.errorIcono.SetError(this.tabControl1, resources.GetString("tabControl1.Error"));
            this.errorIcono.SetIconAlignment(this.tabControl1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tabControl1.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.tabControl1, ((int)(resources.GetObject("tabControl1.IconPadding"))));
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.ttMensaje.SetToolTip(this.tabControl1, resources.GetString("tabControl1.ToolTip"));
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.btnImprimir2);
            this.tabPage2.Controls.Add(this.btnCancelar);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.dgvDetalleFactura);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.txtObservacion);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.gbTipo);
            this.tabPage2.Controls.Add(this.btnGuardar);
            this.tabPage2.Controls.Add(this.btnNuevo);
            this.errorIcono.SetError(this.tabPage2, resources.GetString("tabPage2.Error"));
            this.errorIcono.SetIconAlignment(this.tabPage2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tabPage2.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.tabPage2, ((int)(resources.GetObject("tabPage2.IconPadding"))));
            this.tabPage2.Name = "tabPage2";
            this.ttMensaje.SetToolTip(this.tabPage2, resources.GetString("tabPage2.ToolTip"));
            // 
            // btnImprimir2
            // 
            resources.ApplyResources(this.btnImprimir2, "btnImprimir2");
            this.btnImprimir2.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnImprimir2.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnImprimir2.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnImprimir2.BorderRadius = 10;
            this.btnImprimir2.BorderSize = 0;
            this.errorIcono.SetError(this.btnImprimir2, resources.GetString("btnImprimir2.Error"));
            this.btnImprimir2.FlatAppearance.BorderSize = 0;
            this.btnImprimir2.ForeColor = System.Drawing.Color.White;
            this.errorIcono.SetIconAlignment(this.btnImprimir2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnImprimir2.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.btnImprimir2, ((int)(resources.GetObject("btnImprimir2.IconPadding"))));
            this.btnImprimir2.Name = "btnImprimir2";
            this.btnImprimir2.TextColor = System.Drawing.Color.White;
            this.ttMensaje.SetToolTip(this.btnImprimir2, resources.GetString("btnImprimir2.ToolTip"));
            this.btnImprimir2.UseVisualStyleBackColor = false;
            this.btnImprimir2.Click += new System.EventHandler(this.btnImprimir2_Click);
            // 
            // btnCancelar
            // 
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCancelar.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnCancelar.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnCancelar.BorderRadius = 10;
            this.btnCancelar.BorderSize = 0;
            this.errorIcono.SetError(this.btnCancelar, resources.GetString("btnCancelar.Error"));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.errorIcono.SetIconAlignment(this.btnCancelar, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnCancelar.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.btnCancelar, ((int)(resources.GetObject("btnCancelar.IconPadding"))));
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.White;
            this.ttMensaje.SetToolTip(this.btnCancelar, resources.GetString("btnCancelar.ToolTip"));
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.txtTotalGral);
            this.groupBox3.Controls.Add(this.txttotalIva);
            this.groupBox3.Controls.Add(this.txtTotalGravadas);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.errorIcono.SetError(this.groupBox3, resources.GetString("groupBox3.Error"));
            this.errorIcono.SetIconAlignment(this.groupBox3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("groupBox3.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.groupBox3, ((int)(resources.GetObject("groupBox3.IconPadding"))));
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            this.ttMensaje.SetToolTip(this.groupBox3, resources.GetString("groupBox3.ToolTip"));
            // 
            // txtTotalGral
            // 
            resources.ApplyResources(this.txtTotalGral, "txtTotalGral");
            this.txtTotalGral.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.errorIcono.SetError(this.txtTotalGral, resources.GetString("txtTotalGral.Error"));
            this.errorIcono.SetIconAlignment(this.txtTotalGral, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtTotalGral.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.txtTotalGral, ((int)(resources.GetObject("txtTotalGral.IconPadding"))));
            this.txtTotalGral.Name = "txtTotalGral";
            this.ttMensaje.SetToolTip(this.txtTotalGral, resources.GetString("txtTotalGral.ToolTip"));
            // 
            // txttotalIva
            // 
            resources.ApplyResources(this.txttotalIva, "txttotalIva");
            this.txttotalIva.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.errorIcono.SetError(this.txttotalIva, resources.GetString("txttotalIva.Error"));
            this.errorIcono.SetIconAlignment(this.txttotalIva, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txttotalIva.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.txttotalIva, ((int)(resources.GetObject("txttotalIva.IconPadding"))));
            this.txttotalIva.Name = "txttotalIva";
            this.ttMensaje.SetToolTip(this.txttotalIva, resources.GetString("txttotalIva.ToolTip"));
            // 
            // btnGuardar
            // 
            resources.ApplyResources(this.btnGuardar, "btnGuardar");
            this.btnGuardar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGuardar.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnGuardar.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnGuardar.BorderRadius = 10;
            this.btnGuardar.BorderSize = 0;
            this.errorIcono.SetError(this.btnGuardar, resources.GetString("btnGuardar.Error"));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.errorIcono.SetIconAlignment(this.btnGuardar, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnGuardar.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.btnGuardar, ((int)(resources.GetObject("btnGuardar.IconPadding"))));
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.guardar;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.TextColor = System.Drawing.Color.White;
            this.ttMensaje.SetToolTip(this.btnGuardar, resources.GetString("btnGuardar.ToolTip"));
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            resources.ApplyResources(this.btnNuevo, "btnNuevo");
            this.btnNuevo.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNuevo.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnNuevo.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnNuevo.BorderRadius = 10;
            this.btnNuevo.BorderSize = 0;
            this.errorIcono.SetError(this.btnNuevo, resources.GetString("btnNuevo.Error"));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.errorIcono.SetIconAlignment(this.btnNuevo, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnNuevo.IconAlignment"))));
            this.errorIcono.SetIconPadding(this.btnNuevo, ((int)(resources.GetObject("btnNuevo.IconPadding"))));
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.Nuevo;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.TextColor = System.Drawing.Color.White;
            this.ttMensaje.SetToolTip(this.btnNuevo, resources.GetString("btnNuevo.ToolTip"));
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // FrmFacturaVenta
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "FrmFacturaVenta";
            this.ttMensaje.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFacturaVenta_FormClosing);
            this.Load += new System.EventHandler(this.FrmFacturaVenta_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmFacturaVenta_KeyUp);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.gbTipo.ResumeLayout(false);
            this.gbTipo.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DateTimePicker dtpfechahasta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechadesde;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Anular;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.CheckBox chkAnular;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTotalGral;
        private System.Windows.Forms.TextBox txttotalIva;
        private System.Windows.Forms.TextBox txtTotalGravadas;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvDetalleFactura;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.GroupBox gbTipo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.ComboBox cboTipoPago;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.TextBox txtExistencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblAyuda;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNumeracionOT;
        private System.Windows.Forms.TextBox txtNroFactura;
        private System.Windows.Forms.ComboBox cboComprobante;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.Label lblSinRegistros;
        private System.Windows.Forms.RadioButton rbManual;
        private System.Windows.Forms.RadioButton rbAutoimprenta;
        private System.Windows.Forms.GroupBox groupBox4;
        private CapaPresentacion.Utilidades.RButton btnBuscar;
        private CapaPresentacion.Utilidades.RButton btnImprimir;
        private CapaPresentacion.Utilidades.RButton btnAnular;
        private CapaPresentacion.Utilidades.RButton btnBuscarItem;
        private CapaPresentacion.Utilidades.RButton btnAgregar;
        private CapaPresentacion.Utilidades.RButton btnQuitar;
        private CapaPresentacion.Utilidades.RButton btnNuevo;
        private CapaPresentacion.Utilidades.RButton btnGuardar;
        private CapaPresentacion.Utilidades.RButton btnCancelar;
        private CapaPresentacion.Utilidades.RButton btnImprimir2;
    }
}