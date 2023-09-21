using CapaNegocio;
using CapaNegocio.Reporting;
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
            //Se inicializa el fecha desde con el primer día del mes
            var FechaInicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDesde.Value = FechaInicioMes;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteOT' Puede moverla o quitarla según sea necesario.
                var desde = dtpDesde.Value;
                var hasta = dtpHasta.Value;
                CargarDatos(desde, hasta);
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


        private void CargarDatos(DateTime inicio, DateTime fin)
        {
            NInformeCaja reportModel = new NInformeCaja();
            reportModel.ResumenCajaReport(inicio, fin);

            nInformeCajaBindingSource.DataSource = reportModel;
            dCajaBindingSource.DataSource = reportModel.ListaArqueos;

            this.reportViewer1.RefreshReport();
        }
    }
}
