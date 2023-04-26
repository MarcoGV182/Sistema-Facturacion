using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios.Herramientas
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
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int Iparam);

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

       
        #endregion

    }
}
