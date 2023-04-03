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
    public partial class FrmInformeCaja : Form
    {
        public FrmInformeCaja()
        {
            InitializeComponent();
        }

        private static FrmInformeCaja _Instancia;
        public static FrmInformeCaja GetInstancia() 
        { 
            if(_Instancia==null)
            {
                _Instancia = new FrmInformeCaja();
            }
            return _Instancia;
        }



        private void FrmInformeCaja_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteOT' Puede moverla o quitarla según sea necesario.
                this.sp_ReporteResumenCajaFechaTableAdapter.Fill(this.DsReporte.sp_ReporteResumenCajaFecha, this.dtpDesde.Value.ToString("dd/MM/yyyy"), this.dtpHasta.Value.ToString("dd/MM/yyyy"));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmInformeCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia=null;
        }
    }
}
