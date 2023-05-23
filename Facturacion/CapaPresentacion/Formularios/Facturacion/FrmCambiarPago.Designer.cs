namespace CapaPresentacion.Formularios.Facturacion
{
    partial class FrmCambiarPago
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
            this.txtNroVenta = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.dataDetalle = new System.Windows.Forms.DataGridView();
            this.label22 = new System.Windows.Forms.Label();
            this.txtNroFactura = new System.Windows.Forms.TextBox();
            this.lblNroFactura = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.btnCancelar = new CapaPresentacion.Utilidades.RButton();
            this.btnModificarPago = new CapaPresentacion.Utilidades.RButton();
            this.btnConsultar = new CapaPresentacion.Utilidades.RButton();
            this.txtFechaFactura = new System.Windows.Forms.TextBox();
            this.txtTotalPagado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNroVenta
            // 
            this.txtNroVenta.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.txtNroVenta.Location = new System.Drawing.Point(125, 23);
            this.txtNroVenta.Name = "txtNroVenta";
            this.txtNroVenta.Size = new System.Drawing.Size(100, 26);
            this.txtNroVenta.TabIndex = 19;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(21, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(96, 20);
            this.label21.TabIndex = 20;
            this.label21.Text = "Nro. de Venta:";
            // 
            // dataDetalle
            // 
            this.dataDetalle.AllowUserToAddRows = false;
            this.dataDetalle.AllowUserToDeleteRows = false;
            this.dataDetalle.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataDetalle.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDetalle.EnableHeadersVisualStyles = false;
            this.dataDetalle.GridColor = System.Drawing.SystemColors.Control;
            this.dataDetalle.Location = new System.Drawing.Point(63, 171);
            this.dataDetalle.MultiSelect = false;
            this.dataDetalle.Name = "dataDetalle";
            this.dataDetalle.ReadOnly = true;
            this.dataDetalle.RowHeadersVisible = false;
            this.dataDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataDetalle.Size = new System.Drawing.Size(434, 126);
            this.dataDetalle.TabIndex = 24;
            this.dataDetalle.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataDetalle_CellFormatting);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label22.Location = new System.Drawing.Point(60, 151);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(115, 17);
            this.label22.TabIndex = 23;
            this.label22.Text = "Detalles de Pagos";
            // 
            // txtNroFactura
            // 
            this.txtNroFactura.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.txtNroFactura.Location = new System.Drawing.Point(100, 74);
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.ReadOnly = true;
            this.txtNroFactura.Size = new System.Drawing.Size(177, 26);
            this.txtNroFactura.TabIndex = 27;
            // 
            // lblNroFactura
            // 
            this.lblNroFactura.AutoSize = true;
            this.lblNroFactura.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroFactura.Location = new System.Drawing.Point(9, 77);
            this.lblNroFactura.Name = "lblNroFactura";
            this.lblNroFactura.Size = new System.Drawing.Size(85, 20);
            this.lblNroFactura.TabIndex = 28;
            this.lblNroFactura.Text = "Nro. Factura:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(283, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(279, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Importe:";
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.txtCliente.Location = new System.Drawing.Point(333, 71);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(177, 26);
            this.txtCliente.TabIndex = 32;
            // 
            // txtImporte
            // 
            this.txtImporte.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.txtImporte.Location = new System.Drawing.Point(334, 106);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.ReadOnly = true;
            this.txtImporte.Size = new System.Drawing.Size(177, 26);
            this.txtImporte.TabIndex = 33;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCancelar.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCancelar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancelar.BorderRadius = 10;
            this.btnCancelar.BorderSize = 0;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(112, 321);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 30);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnModificarPago
            // 
            this.btnModificarPago.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnModificarPago.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnModificarPago.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnModificarPago.BorderRadius = 10;
            this.btnModificarPago.BorderSize = 0;
            this.btnModificarPago.FlatAppearance.BorderSize = 0;
            this.btnModificarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarPago.ForeColor = System.Drawing.Color.White;
            this.btnModificarPago.Location = new System.Drawing.Point(12, 321);
            this.btnModificarPago.Name = "btnModificarPago";
            this.btnModificarPago.Size = new System.Drawing.Size(94, 30);
            this.btnModificarPago.TabIndex = 25;
            this.btnModificarPago.Text = "Modificar Pago";
            this.btnModificarPago.TextColor = System.Drawing.Color.White;
            this.btnModificarPago.UseVisualStyleBackColor = false;
            this.btnModificarPago.Click += new System.EventHandler(this.btnModificarPago_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnConsultar.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnConsultar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnConsultar.BorderRadius = 10;
            this.btnConsultar.BorderSize = 0;
            this.btnConsultar.FlatAppearance.BorderSize = 0;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(228, 20);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(94, 30);
            this.btnConsultar.TabIndex = 21;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextColor = System.Drawing.Color.White;
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtFechaFactura
            // 
            this.txtFechaFactura.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.txtFechaFactura.Location = new System.Drawing.Point(100, 108);
            this.txtFechaFactura.Name = "txtFechaFactura";
            this.txtFechaFactura.ReadOnly = true;
            this.txtFechaFactura.Size = new System.Drawing.Size(177, 26);
            this.txtFechaFactura.TabIndex = 34;
            // 
            // txtTotalPagado
            // 
            this.txtTotalPagado.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.txtTotalPagado.Location = new System.Drawing.Point(374, 303);
            this.txtTotalPagado.Name = "txtTotalPagado";
            this.txtTotalPagado.ReadOnly = true;
            this.txtTotalPagado.Size = new System.Drawing.Size(123, 26);
            this.txtTotalPagado.TabIndex = 35;
            // 
            // FrmCambiarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 363);
            this.Controls.Add(this.txtTotalPagado);
            this.Controls.Add(this.txtFechaFactura);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNroFactura);
            this.Controls.Add(this.txtNroFactura);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnModificarPago);
            this.Controls.Add(this.dataDetalle);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtNroVenta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmCambiarPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cambiar Pagos Registrados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCambiarPago_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNroVenta;
        private System.Windows.Forms.Label label21;
        private Utilidades.RButton btnConsultar;
        private System.Windows.Forms.DataGridView dataDetalle;
        private System.Windows.Forms.Label label22;
        private Utilidades.RButton btnModificarPago;
        private Utilidades.RButton btnCancelar;
        private System.Windows.Forms.TextBox txtNroFactura;
        private System.Windows.Forms.Label lblNroFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.TextBox txtFechaFactura;
        private System.Windows.Forms.TextBox txtTotalPagado;
    }
}