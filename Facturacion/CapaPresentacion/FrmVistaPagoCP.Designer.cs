namespace CapaPresentacion
{
    partial class FrmVistaPagoCP
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImportePago = new System.Windows.Forms.TextBox();
            this.txtNroFactura = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtfechacompra = new System.Windows.Forms.TextBox();
            this.txtcuentapagar = new System.Windows.Forms.TextBox();
            this.txtValorInicial = new System.Windows.Forms.TextBox();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtProveedorNro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboFormaPago = new System.Windows.Forms.ComboBox();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label1.Location = new System.Drawing.Point(11, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha compra:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(94, 406);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(175, 406);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label2.Location = new System.Drawing.Point(10, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Importe:";
            // 
            // txtImportePago
            // 
            this.txtImportePago.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtImportePago.Location = new System.Drawing.Point(108, 85);
            this.txtImportePago.Name = "txtImportePago";
            this.txtImportePago.Size = new System.Drawing.Size(123, 23);
            this.txtImportePago.TabIndex = 6;
            this.txtImportePago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImportePago_KeyPress);
            // 
            // txtNroFactura
            // 
            this.txtNroFactura.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtNroFactura.Location = new System.Drawing.Point(118, 21);
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.ReadOnly = true;
            this.txtNroFactura.Size = new System.Drawing.Size(123, 23);
            this.txtNroFactura.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label3.Location = new System.Drawing.Point(11, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nro de Factura:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtfechacompra);
            this.groupBox1.Controls.Add(this.txtcuentapagar);
            this.groupBox1.Controls.Add(this.txtValorInicial);
            this.groupBox1.Controls.Add(this.txtSaldo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtProveedorNro);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNroFactura);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 150);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Factura";
            // 
            // txtfechacompra
            // 
            this.txtfechacompra.Location = new System.Drawing.Point(118, 51);
            this.txtfechacompra.Name = "txtfechacompra";
            this.txtfechacompra.ReadOnly = true;
            this.txtfechacompra.Size = new System.Drawing.Size(100, 25);
            this.txtfechacompra.TabIndex = 16;
            // 
            // txtcuentapagar
            // 
            this.txtcuentapagar.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtcuentapagar.Location = new System.Drawing.Point(226, 116);
            this.txtcuentapagar.Name = "txtcuentapagar";
            this.txtcuentapagar.Size = new System.Drawing.Size(48, 23);
            this.txtcuentapagar.TabIndex = 15;
            this.txtcuentapagar.Visible = false;
            // 
            // txtValorInicial
            // 
            this.txtValorInicial.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtValorInicial.Location = new System.Drawing.Point(184, 116);
            this.txtValorInicial.Name = "txtValorInicial";
            this.txtValorInicial.Size = new System.Drawing.Size(35, 23);
            this.txtValorInicial.TabIndex = 14;
            this.txtValorInicial.Visible = false;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtSaldo.Location = new System.Drawing.Point(80, 116);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(100, 23);
            this.txtSaldo.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label6.Location = new System.Drawing.Point(11, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Saldo:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtNombre.Location = new System.Drawing.Point(124, 85);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(160, 23);
            this.txtNombre.TabIndex = 11;
            // 
            // txtProveedorNro
            // 
            this.txtProveedorNro.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtProveedorNro.Location = new System.Drawing.Point(80, 85);
            this.txtProveedorNro.Name = "txtProveedorNro";
            this.txtProveedorNro.ReadOnly = true;
            this.txtProveedorNro.Size = new System.Drawing.Size(42, 23);
            this.txtProveedorNro.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label5.Location = new System.Drawing.Point(11, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Proveedor: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cboFormaPago);
            this.groupBox2.Controls.Add(this.txtObservacion);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtObs);
            this.groupBox2.Controls.Add(this.dtpFechaPago);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtImportePago);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 223);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pago";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label8.Location = new System.Drawing.Point(9, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "Forma de Pago:";
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormaPago.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Location = new System.Drawing.Point(108, 54);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(139, 23);
            this.cboFormaPago.TabIndex = 34;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(10, 144);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(283, 71);
            this.txtObservacion.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label7.Location = new System.Drawing.Point(10, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Observacion:";
            // 
            // txtObs
            // 
            this.txtObs.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtObs.Location = new System.Drawing.Point(235, 85);
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(62, 23);
            this.txtObs.TabIndex = 9;
            this.txtObs.Visible = false;
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.CalendarFont = new System.Drawing.Font("Times New Roman", 12F);
            this.dtpFechaPago.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaPago.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaPago.Location = new System.Drawing.Point(107, 19);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(140, 25);
            this.dtpFechaPago.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label4.Location = new System.Drawing.Point(11, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha:";
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // FrmVistaPagoCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 440);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVistaPagoCP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vista Pago";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVistaPago_FormClosing);
            this.Load += new System.EventHandler(this.FrmVistaPago_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImportePago;
        private System.Windows.Forms.TextBox txtNroFactura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtProveedorNro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.TextBox txtValorInicial;
        private System.Windows.Forms.TextBox txtcuentapagar;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtfechacompra;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboFormaPago;
    }
}