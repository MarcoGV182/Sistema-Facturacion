using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmInformeRetencion : Form
    {
        public FrmInformeRetencion()
        {
            InitializeComponent();
        }

        private static FrmInformeRetencion _Instancia;
        public static FrmInformeRetencion GetInstancia() 
        { 
            if(_Instancia==null) 
            {
                _Instancia = new FrmInformeRetencion();
            }
            return _Instancia;
        }



        private void FrmInformeRetencion_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 50;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try 
            {
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteRetencion' Puede moverla o quitarla según sea necesario.
                this.sp_ReporteRetencionTableAdapter.Fill(this.DsReporte.sp_ReporteRetencion, dtpDesde.Value.ToString("dd-MM-yyyy"), dtpHasta.Value.ToString("dd-MM-yyyy"));

                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);            
            }
        }

        private void FrmInformeRetencion_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
