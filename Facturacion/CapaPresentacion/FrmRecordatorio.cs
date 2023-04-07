using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmRecordatorio : Form
    {
        private Point mouseOffset;
        private bool isDragging = false;
        public FrmRecordatorio()
        {
            InitializeComponent();
        }

        private static FrmRecordatorio _Instancia;

        public static FrmRecordatorio GetInstancia() 
        {           
            if (_Instancia==null) 
            {
                _Instancia = new FrmRecordatorio();
            }
            return _Instancia;
        }

        private void Mostrar()
        {
            dataAvisos.DataSource = NBackup.MostrarRecordatorio(this.cboRango.Text);
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataAvisos.Rows.Count);
            SinRegistros();
        }


        //MOSTRAR LABEL DE SIN REGISTROS
        private void SinRegistros() 
        {
            if (dataAvisos.Rows.Count <= 0)
            {
                lblSinRegistros.Visible = true;
            }
            else
            {
                lblSinRegistros.Visible = false;
            }
        }



        private void FrmAviso_Load(object sender, EventArgs e)
        {
            this.cboRango.SelectedIndex = 0;

            this.StartPosition = FormStartPosition.Manual;
            int x = this.MdiParent.Location.X + this.MdiParent.ClientSize.Width - this.Width;
            int y = Math.Max(this.MdiParent.Location.Y, 0) + SystemInformation.CaptionHeight;
            this.Location = new Point(x, y);            
            this.MdiParent = this.MdiParent;
            /*this.Top = 0;
            this.Left = 2000;*/
            this.Mostrar();
        }

        private void FrmAviso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void cboRango_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Mostrar(); 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Eventos de Mouse
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOffset = new Point(-e.X, -e.Y);
                isDragging = true;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePos;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        #endregion

    }
}
