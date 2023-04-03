namespace CapaPresentacion
{
    partial class FrmCuentaPorPagar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCuentaPorPagar));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSeleccion = new System.Windows.Forms.TextBox();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblHistorico = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtProveedorNro = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDeuda = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBuscarProveedor = new System.Windows.Forms.Button();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnImprimir);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtSeleccion);
            this.tabPage1.Controls.Add(this.dataListado);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(625, 347);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Facturas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(6, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Pagar seleccionado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label3.Location = new System.Drawing.Point(347, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total Seleccionado:";
            // 
            // txtSeleccion
            // 
            this.txtSeleccion.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.txtSeleccion.Location = new System.Drawing.Point(470, 297);
            this.txtSeleccion.Name = "txtSeleccion";
            this.txtSeleccion.Size = new System.Drawing.Size(134, 23);
            this.txtSeleccion.TabIndex = 8;
            this.txtSeleccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataListado.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Location = new System.Drawing.Point(6, 27);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(600, 264);
            this.dataListado.TabIndex = 7;
            this.dataListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListado_CellContentClick);
            this.dataListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataListado_CellFormatting);
            this.dataListado.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataListado_CellPainting);
            this.dataListado.CurrentCellChanged += new System.EventHandler(this.dataListado_CurrentCellChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblTotal.Location = new System.Drawing.Point(413, 6);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(120, 16);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total de registros: 0";
            // 
            // dgvHistorico
            // 
            this.dgvHistorico.AllowUserToAddRows = false;
            this.dgvHistorico.AllowUserToDeleteRows = false;
            this.dgvHistorico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorico.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorico.Location = new System.Drawing.Point(6, 27);
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.ReadOnly = true;
            this.dgvHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorico.Size = new System.Drawing.Size(613, 274);
            this.dgvHistorico.TabIndex = 25;
            this.dgvHistorico.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHistorico_CellFormatting);
            this.dgvHistorico.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvHistorico_CellPainting);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(426, 446);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(62, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(376, 446);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(44, 23);
            this.btnEditar.TabIndex = 21;
            this.btnEditar.Text = "E&ditar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnEliminar);
            this.tabPage2.Controls.Add(this.lblHistorico);
            this.tabPage2.Controls.Add(this.dgvHistorico);
            this.tabPage2.Controls.Add(this.btnCancelar);
            this.tabPage2.Controls.Add(this.btnEditar);
            this.tabPage2.Controls.Add(this.btnGuardar);
            this.tabPage2.Controls.Add(this.btnNuevo);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(625, 347);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Historico";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnEliminar.Location = new System.Drawing.Point(6, 307);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 23);
            this.btnEliminar.TabIndex = 28;
            this.btnEliminar.Text = "Eliminar seleccionado";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblHistorico
            // 
            this.lblHistorico.AutoSize = true;
            this.lblHistorico.Location = new System.Drawing.Point(416, 7);
            this.lblHistorico.Name = "lblHistorico";
            this.lblHistorico.Size = new System.Drawing.Size(120, 16);
            this.lblHistorico.TabIndex = 26;
            this.lblHistorico.Text = "Total de registros: 0";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(299, 445);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(70, 26);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.Nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(230, 445);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(63, 26);
            this.btnNuevo.TabIndex = 12;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.tabControl1.Location = new System.Drawing.Point(16, 98);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(633, 375);
            this.tabControl1.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProveedorNro);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDeuda);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnBuscarProveedor);
            this.groupBox1.Controls.Add(this.txtDocumento);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblProveedor);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 80);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // txtProveedorNro
            // 
            this.txtProveedorNro.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtProveedorNro.Location = new System.Drawing.Point(86, 15);
            this.txtProveedorNro.Name = "txtProveedorNro";
            this.txtProveedorNro.ReadOnly = true;
            this.txtProveedorNro.Size = new System.Drawing.Size(39, 23);
            this.txtProveedorNro.TabIndex = 38;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtDireccion.Location = new System.Drawing.Point(80, 47);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(233, 23);
            this.txtDireccion.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label1.Location = new System.Drawing.Point(15, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Direccion:";
            // 
            // txtDeuda
            // 
            this.txtDeuda.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtDeuda.Location = new System.Drawing.Point(403, 46);
            this.txtDeuda.Name = "txtDeuda";
            this.txtDeuda.Size = new System.Drawing.Size(81, 23);
            this.txtDeuda.TabIndex = 35;
            this.txtDeuda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label7.Location = new System.Drawing.Point(326, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 34;
            this.label7.Text = "Deuda total:";
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarProveedor.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProveedor.Location = new System.Drawing.Point(447, 13);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.Size = new System.Drawing.Size(77, 26);
            this.btnBuscarProveedor.TabIndex = 2;
            this.btnBuscarProveedor.Text = "Buscar[F2]";
            this.btnBuscarProveedor.UseVisualStyleBackColor = false;
            this.btnBuscarProveedor.Click += new System.EventHandler(this.btnBuscarProveedor_Click);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtDocumento.Location = new System.Drawing.Point(128, 15);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.ReadOnly = true;
            this.txtDocumento.Size = new System.Drawing.Size(99, 23);
            this.txtDocumento.TabIndex = 25;
            this.txtDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtNombre.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtNombre.Location = new System.Drawing.Point(229, 15);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(218, 23);
            this.txtNombre.TabIndex = 2;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblProveedor.Location = new System.Drawing.Point(15, 19);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(69, 16);
            this.lblProveedor.TabIndex = 8;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(133, 297);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(110, 23);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Text = "Ver Detalles-Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // FrmCuentaPorPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(661, 487);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmCuentaPorPagar";
            this.Text = "Cuentas por Pagar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCuentaxPagar_FormClosing);
            this.Load += new System.EventHandler(this.FrmCuentaxPagar_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCuentaxPagar_KeyUp);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.ToolTip ttMensaje;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDeuda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBuscarProveedor;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSeleccion;
        private System.Windows.Forms.TextBox txtProveedorNro;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.Label lblHistorico;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnImprimir;
    }
}