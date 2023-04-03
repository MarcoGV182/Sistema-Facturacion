namespace CapaPresentacion
{
    partial class FrmConsultaRUC
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
            this.txtRucNombre = new System.Windows.Forms.TextBox();
            this.lblRucNombre = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.dgListaRUC = new System.Windows.Forms.DataGridView();
            this.btnRecargar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgListaRUC)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRucNombre
            // 
            this.txtRucNombre.Location = new System.Drawing.Point(164, 25);
            this.txtRucNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRucNombre.Name = "txtRucNombre";
            this.txtRucNombre.Size = new System.Drawing.Size(340, 22);
            this.txtRucNombre.TabIndex = 1;
            // 
            // lblRucNombre
            // 
            this.lblRucNombre.AutoSize = true;
            this.lblRucNombre.Location = new System.Drawing.Point(47, 30);
            this.lblRucNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRucNombre.Name = "lblRucNombre";
            this.lblRucNombre.Size = new System.Drawing.Size(102, 16);
            this.lblRucNombre.TabIndex = 2;
            this.lblRucNombre.Text = "RUC o Nombre:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(513, 22);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 28);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(639, 228);
            this.webView21.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(63, 72);
            this.webView21.TabIndex = 4;
            this.webView21.Visible = false;
            this.webView21.ZoomFactor = 1D;
            // 
            // dgListaRUC
            // 
            this.dgListaRUC.AllowUserToAddRows = false;
            this.dgListaRUC.AllowUserToDeleteRows = false;
            this.dgListaRUC.AllowUserToOrderColumns = true;
            this.dgListaRUC.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgListaRUC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListaRUC.Location = new System.Drawing.Point(51, 54);
            this.dgListaRUC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgListaRUC.Name = "dgListaRUC";
            this.dgListaRUC.ReadOnly = true;
            this.dgListaRUC.RowHeadersWidth = 51;
            this.dgListaRUC.RowTemplate.Height = 24;
            this.dgListaRUC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgListaRUC.Size = new System.Drawing.Size(562, 246);
            this.dgListaRUC.TabIndex = 5;
            // 
            // btnRecargar
            // 
            this.btnRecargar.Location = new System.Drawing.Point(620, 22);
            this.btnRecargar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(80, 28);
            this.btnRecargar.TabIndex = 6;
            this.btnRecargar.Text = "Recargar";
            this.btnRecargar.UseVisualStyleBackColor = true;
            this.btnRecargar.Click += new System.EventHandler(this.btnRecargar_Click);
            // 
            // FrmConsultaRUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 329);
            this.Controls.Add(this.btnRecargar);
            this.Controls.Add(this.dgListaRUC);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.lblRucNombre);
            this.Controls.Add(this.txtRucNombre);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmConsultaRUC";
            this.Text = "ConsultaRUC";
            this.Load += new System.EventHandler(this.FrmConsultaRUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgListaRUC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtRucNombre;
        private System.Windows.Forms.Label lblRucNombre;
        private System.Windows.Forms.Button btnConsultar;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.DataGridView dgListaRUC;
        private System.Windows.Forms.Button btnRecargar;
    }
}