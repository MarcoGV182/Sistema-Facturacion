namespace CapaPresentacion.Formularios.Herramientas
{
    partial class FrmRecordatorio
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
            this.gbAvisos = new System.Windows.Forms.GroupBox();
            this.lblSinRegistros = new System.Windows.Forms.Label();
            this.dataAvisos = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cboRango = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAvisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAvisos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAvisos
            // 
            this.gbAvisos.BackColor = System.Drawing.Color.White;
            this.gbAvisos.Controls.Add(this.lblSinRegistros);
            this.gbAvisos.Controls.Add(this.dataAvisos);
            this.gbAvisos.Controls.Add(this.lblTotal);
            this.gbAvisos.Controls.Add(this.cboRango);
            this.gbAvisos.ForeColor = System.Drawing.Color.Black;
            this.gbAvisos.Location = new System.Drawing.Point(4, 24);
            this.gbAvisos.Name = "gbAvisos";
            this.gbAvisos.Size = new System.Drawing.Size(496, 254);
            this.gbAvisos.TabIndex = 5;
            this.gbAvisos.TabStop = false;
            // 
            // lblSinRegistros
            // 
            this.lblSinRegistros.AutoSize = true;
            this.lblSinRegistros.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSinRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSinRegistros.Location = new System.Drawing.Point(180, 97);
            this.lblSinRegistros.Name = "lblSinRegistros";
            this.lblSinRegistros.Size = new System.Drawing.Size(116, 17);
            this.lblSinRegistros.TabIndex = 19;
            this.lblSinRegistros.Text = "Sin recordatorios";
            this.lblSinRegistros.Visible = false;
            // 
            // dataAvisos
            // 
            this.dataAvisos.AllowUserToAddRows = false;
            this.dataAvisos.AllowUserToDeleteRows = false;
            this.dataAvisos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataAvisos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataAvisos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataAvisos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataAvisos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataAvisos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataAvisos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataAvisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAvisos.EnableHeadersVisualStyles = false;
            this.dataAvisos.GridColor = System.Drawing.SystemColors.Control;
            this.dataAvisos.Location = new System.Drawing.Point(9, 46);
            this.dataAvisos.MultiSelect = false;
            this.dataAvisos.Name = "dataAvisos";
            this.dataAvisos.ReadOnly = true;
            this.dataAvisos.RowHeadersVisible = false;
            this.dataAvisos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataAvisos.Size = new System.Drawing.Size(481, 199);
            this.dataAvisos.TabIndex = 8;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblTotal.Location = new System.Drawing.Point(180, 21);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(119, 16);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total de registros: 0";
            // 
            // cboRango
            // 
            this.cboRango.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRango.ForeColor = System.Drawing.Color.Black;
            this.cboRango.FormattingEnabled = true;
            this.cboRango.Items.AddRange(new object[] {
            "HOY",
            "MAÑANA",
            "EN LA SEMANA",
            "EN EL MES",
            "EN EL AÑO"});
            this.cboRango.Location = new System.Drawing.Point(8, 19);
            this.cboRango.Name = "cboRango";
            this.cboRango.Size = new System.Drawing.Size(157, 21);
            this.cboRango.TabIndex = 1;
            this.cboRango.SelectedIndexChanged += new System.EventHandler(this.cboRango_SelectedIndexChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.DarkRed;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSalir.Location = new System.Drawing.Point(483, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(19, 18);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "X";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 18);
            this.panel1.TabIndex = 20;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(205, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recordatorios";
            // 
            // FrmRecordatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 281);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbAvisos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRecordatorio";
            this.Text = "RECORDATORIOS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAviso_FormClosing);
            this.Load += new System.EventHandler(this.FrmAviso_Load);
            this.gbAvisos.ResumeLayout(false);
            this.gbAvisos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAvisos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAvisos;
        private System.Windows.Forms.DataGridView dataAvisos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cboRango;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblSinRegistros;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}