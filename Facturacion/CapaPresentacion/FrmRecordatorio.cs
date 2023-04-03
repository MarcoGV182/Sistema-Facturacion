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
        public FrmRecordatorio()
        {
            InitializeComponent();
        }

        private static FrmRecordatorio _Instancia;
        public static FrmRecordatorio GetInstancia() 
        { 
            if(_Instancia==null) 
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
            this.Top = 0;
            this.Left = 900;
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
    }
}
