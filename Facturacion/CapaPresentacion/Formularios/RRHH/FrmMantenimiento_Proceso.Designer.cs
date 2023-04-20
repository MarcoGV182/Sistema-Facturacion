namespace CapaPresentacion.Formularios.RRHH
{
    partial class FrmMantenimiento_Proceso
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCerrarProceso = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalListado = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.chktodos = new System.Windows.Forms.CheckBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.chkEliminar = new System.Windows.Forms.CheckBox();
            this.dataProceso = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalDescuento = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescuentoNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboEmpleados = new System.Windows.Forms.ComboBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cboDescuento = new System.Windows.Forms.ComboBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTotalGanancia = new System.Windows.Forms.TextBox();
            this.dataDetalle = new System.Windows.Forms.DataGridView();
            this.btnTodos = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cboUsuarioFiltro = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProcesoNro = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.btnAbrirProceso = new System.Windows.Forms.Button();
            this.btnLiquidacion = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalPrecio = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProceso)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDetalle)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label1.Location = new System.Drawing.Point(329, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proceso:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label4.Location = new System.Drawing.Point(466, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Descripcion:";
            // 
            // btnCerrarProceso
            // 
            this.btnCerrarProceso.Location = new System.Drawing.Point(15, 550);
            this.btnCerrarProceso.Name = "btnCerrarProceso";
            this.btnCerrarProceso.Size = new System.Drawing.Size(75, 23);
            this.btnCerrarProceso.TabIndex = 9;
            this.btnCerrarProceso.Text = "Cerrar Proc.";
            this.btnCerrarProceso.UseVisualStyleBackColor = true;
            this.btnCerrarProceso.Click += new System.EventHandler(this.btnCerrarProceso_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(764, 81);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(62, 20);
            this.lblEstado.TabIndex = 11;
            this.lblEstado.Text = "Estado";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(11, 138);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(859, 400);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.txtTotalListado);
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Controls.Add(this.chktodos);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.chkEliminar);
            this.tabPage1.Controls.Add(this.dataProceso);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(851, 374);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label11.Location = new System.Drawing.Point(608, 321);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 16);
            this.label11.TabIndex = 17;
            this.label11.Text = "Total:";
            // 
            // txtTotalListado
            // 
            this.txtTotalListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalListado.Location = new System.Drawing.Point(649, 319);
            this.txtTotalListado.Name = "txtTotalListado";
            this.txtTotalListado.ReadOnly = true;
            this.txtTotalListado.Size = new System.Drawing.Size(100, 22);
            this.txtTotalListado.TabIndex = 16;
            this.txtTotalListado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(284, 26);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // chktodos
            // 
            this.chktodos.AutoSize = true;
            this.chktodos.Location = new System.Drawing.Point(168, 30);
            this.chktodos.Name = "chktodos";
            this.chktodos.Size = new System.Drawing.Size(111, 17);
            this.chktodos.TabIndex = 12;
            this.chktodos.Text = "Seleccionar todos";
            this.chktodos.UseVisualStyleBackColor = true;
            this.chktodos.CheckedChanged += new System.EventHandler(this.chktodos_CheckedChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(649, 34);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 13);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Total de registros: 0";
            // 
            // chkEliminar
            // 
            this.chkEliminar.AutoSize = true;
            this.chkEliminar.Location = new System.Drawing.Point(100, 30);
            this.chkEliminar.Name = "chkEliminar";
            this.chkEliminar.Size = new System.Drawing.Size(62, 17);
            this.chkEliminar.TabIndex = 10;
            this.chkEliminar.Text = "Eliminar";
            this.chkEliminar.UseVisualStyleBackColor = true;
            this.chkEliminar.CheckedChanged += new System.EventHandler(this.chkEliminar_CheckedChanged);
            // 
            // dataProceso
            // 
            this.dataProceso.AllowUserToAddRows = false;
            this.dataProceso.AllowUserToDeleteRows = false;
            this.dataProceso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataProceso.BackgroundColor = System.Drawing.Color.White;
            this.dataProceso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProceso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.dataProceso.Location = new System.Drawing.Point(100, 56);
            this.dataProceso.Name = "dataProceso";
            this.dataProceso.ReadOnly = true;
            this.dataProceso.Size = new System.Drawing.Size(649, 257);
            this.dataProceso.TabIndex = 0;
            this.dataProceso.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProceso_CellContentClick);
            this.dataProceso.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataProceso_CellFormatting);
            // 
            // Eliminar
            // 
            this.Eliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Width = 49;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtTotalDescuento);
            this.tabPage2.Controls.Add(this.btnGuardar);
            this.tabPage2.Controls.Add(this.dataListado);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(851, 374);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mant. Proceso";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label10.Location = new System.Drawing.Point(596, 321);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "Total:";
            // 
            // txtTotalDescuento
            // 
            this.txtTotalDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDescuento.Location = new System.Drawing.Point(637, 319);
            this.txtTotalDescuento.Name = "txtTotalDescuento";
            this.txtTotalDescuento.ReadOnly = true;
            this.txtTotalDescuento.Size = new System.Drawing.Size(100, 22);
            this.txtTotalDescuento.TabIndex = 14;
            this.txtTotalDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(662, 343);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.Nombre,
            this.UsuarioNro,
            this.DescuentoNro,
            this.Descuento,
            this.Cantidad,
            this.Monto,
            this.Total});
            this.dataListado.Location = new System.Drawing.Point(50, 109);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(687, 208);
            this.dataListado.TabIndex = 11;
            this.dataListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataListado_CellFormatting);
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre y Apellido";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // UsuarioNro
            // 
            this.UsuarioNro.HeaderText = "UsuarioNro";
            this.UsuarioNro.Name = "UsuarioNro";
            this.UsuarioNro.ReadOnly = true;
            this.UsuarioNro.Visible = false;
            this.UsuarioNro.Width = 85;
            // 
            // DescuentoNro
            // 
            this.DescuentoNro.HeaderText = "DescuentoNro";
            this.DescuentoNro.Name = "DescuentoNro";
            this.DescuentoNro.ReadOnly = true;
            this.DescuentoNro.Visible = false;
            this.DescuentoNro.Width = 101;
            // 
            // Descuento
            // 
            this.Descuento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 74;
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Width = 62;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 56;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboEmpleados);
            this.groupBox1.Controls.Add(this.btnQuitar);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.cboDescuento);
            this.groupBox1.Controls.Add(this.txtMonto);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.groupBox1.Location = new System.Drawing.Point(23, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 92);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Empleados";
            // 
            // cboEmpleados
            // 
            this.cboEmpleados.FormattingEnabled = true;
            this.cboEmpleados.Location = new System.Drawing.Point(27, 48);
            this.cboEmpleados.Name = "cboEmpleados";
            this.cboEmpleados.Size = new System.Drawing.Size(259, 23);
            this.cboEmpleados.TabIndex = 12;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnQuitar.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnQuitar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.btnQuitar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnQuitar.Image = global::CapaPresentacion.Properties.Resources.menos;
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.Location = new System.Drawing.Point(719, 45);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(63, 26);
            this.btnQuitar.TabIndex = 11;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnAgregar.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.btnAgregar.Image = global::CapaPresentacion.Properties.Resources.mas;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(644, 45);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(69, 26);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cboDescuento
            // 
            this.cboDescuento.FormattingEnabled = true;
            this.cboDescuento.Location = new System.Drawing.Point(292, 48);
            this.cboDescuento.Name = "cboDescuento";
            this.cboDescuento.Size = new System.Drawing.Size(184, 23);
            this.cboDescuento.TabIndex = 2;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(532, 48);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 23);
            this.txtMonto.TabIndex = 1;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(482, 48);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(44, 23);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(562, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Monto:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(482, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cant.:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(353, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Descuento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nombre y Apellido:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.txtTotalPrecio);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.txtTotalGanancia);
            this.tabPage3.Controls.Add(this.dataDetalle);
            this.tabPage3.Controls.Add(this.btnTodos);
            this.tabPage3.Controls.Add(this.btnFiltrar);
            this.tabPage3.Controls.Add(this.cboUsuarioFiltro);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(851, 374);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Detalle Proceso";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label13.Location = new System.Drawing.Point(451, 335);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 16);
            this.label13.TabIndex = 21;
            this.label13.Text = "Total Precio:";
            // 
            // txtTotalGanancia
            // 
            this.txtTotalGanancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalGanancia.Location = new System.Drawing.Point(727, 331);
            this.txtTotalGanancia.Name = "txtTotalGanancia";
            this.txtTotalGanancia.ReadOnly = true;
            this.txtTotalGanancia.Size = new System.Drawing.Size(80, 22);
            this.txtTotalGanancia.TabIndex = 20;
            this.txtTotalGanancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataDetalle
            // 
            this.dataDetalle.AllowUserToAddRows = false;
            this.dataDetalle.AllowUserToDeleteRows = false;
            this.dataDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dataDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDetalle.Location = new System.Drawing.Point(36, 33);
            this.dataDetalle.Name = "dataDetalle";
            this.dataDetalle.ReadOnly = true;
            this.dataDetalle.Size = new System.Drawing.Size(771, 295);
            this.dataDetalle.TabIndex = 2;
            this.dataDetalle.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataDetalle_CellFormatting);
            // 
            // btnTodos
            // 
            this.btnTodos.Location = new System.Drawing.Point(576, 6);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(59, 23);
            this.btnTodos.TabIndex = 1;
            this.btnTodos.Text = "Todos";
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(511, 6);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(59, 23);
            this.btnFiltrar.TabIndex = 1;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // cboUsuarioFiltro
            // 
            this.cboUsuarioFiltro.FormattingEnabled = true;
            this.cboUsuarioFiltro.Location = new System.Drawing.Point(249, 7);
            this.cboUsuarioFiltro.Name = "cboUsuarioFiltro";
            this.cboUsuarioFiltro.Size = new System.Drawing.Size(256, 21);
            this.cboUsuarioFiltro.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(774, 553);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblFechaFin);
            this.groupBox2.Controls.Add(this.lblFechaInicio);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(15, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 80);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblFechaFin.Location = new System.Drawing.Point(137, 52);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(55, 17);
            this.lblFechaFin.TabIndex = 13;
            this.lblFechaFin.Text = "label10";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblFechaInicio.Location = new System.Drawing.Point(20, 52);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(55, 17);
            this.lblFechaInicio.TabIndex = 13;
            this.lblFechaInicio.Text = "label10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label3.Location = new System.Drawing.Point(131, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Fecha Fin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Fecha Inicio:";
            // 
            // lblProcesoNro
            // 
            this.lblProcesoNro.AutoSize = true;
            this.lblProcesoNro.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblProcesoNro.Location = new System.Drawing.Point(327, 104);
            this.lblProcesoNro.Name = "lblProcesoNro";
            this.lblProcesoNro.Size = new System.Drawing.Size(86, 17);
            this.lblProcesoNro.TabIndex = 14;
            this.lblProcesoNro.Text = "ProcesoNro";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblDescripcion.Location = new System.Drawing.Point(466, 104);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(86, 17);
            this.lblDescripcion.TabIndex = 14;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Britannic Bold", 17F);
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(325, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(285, 26);
            this.label12.TabIndex = 15;
            this.label12.Text = "PROCESO DE DESCUENTOS";
            // 
            // btnAbrirProceso
            // 
            this.btnAbrirProceso.Location = new System.Drawing.Point(758, 110);
            this.btnAbrirProceso.Name = "btnAbrirProceso";
            this.btnAbrirProceso.Size = new System.Drawing.Size(78, 23);
            this.btnAbrirProceso.TabIndex = 16;
            this.btnAbrirProceso.Text = "Abrir Proceso";
            this.btnAbrirProceso.UseVisualStyleBackColor = true;
            this.btnAbrirProceso.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLiquidacion
            // 
            this.btnLiquidacion.Location = new System.Drawing.Point(689, 110);
            this.btnLiquidacion.Name = "btnLiquidacion";
            this.btnLiquidacion.Size = new System.Drawing.Size(67, 23);
            this.btnLiquidacion.TabIndex = 16;
            this.btnLiquidacion.Text = "Recibos";
            this.btnLiquidacion.UseVisualStyleBackColor = true;
            this.btnLiquidacion.Click += new System.EventHandler(this.btnLiquidacion_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label5.Location = new System.Drawing.Point(629, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Total Ganancia:";
            // 
            // txtTotalPrecio
            // 
            this.txtTotalPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPrecio.Location = new System.Drawing.Point(536, 332);
            this.txtTotalPrecio.Name = "txtTotalPrecio";
            this.txtTotalPrecio.ReadOnly = true;
            this.txtTotalPrecio.Size = new System.Drawing.Size(80, 22);
            this.txtTotalPrecio.TabIndex = 20;
            this.txtTotalPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmMantenimiento_Proceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 583);
            this.Controls.Add(this.btnLiquidacion);
            this.Controls.Add(this.btnAbrirProceso);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblProcesoNro);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnCerrarProceso);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "FrmMantenimiento_Proceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Proceso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMantenimiento_Proceso_FormClosing);
            this.Load += new System.EventHandler(this.FrmMantenimiento_Proceso_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProceso)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDetalle)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCerrarProceso;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboEmpleados;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ComboBox cboDescuento;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataProceso;
        private System.Windows.Forms.CheckBox chktodos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.CheckBox chkEliminar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblProcesoNro;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalDescuento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalListado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAbrirProceso;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataDetalle;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ComboBox cboUsuarioFiltro;
        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTotalGanancia;
        private System.Windows.Forms.Button btnLiquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescuentoNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalPrecio;
    }
}