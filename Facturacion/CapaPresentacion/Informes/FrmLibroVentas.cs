using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmLibroVentas : Form
    {
        public FrmLibroVentas()
        {
            InitializeComponent();
        }

        private static FrmLibroVentas _Instancia;

        public static FrmLibroVentas GetInstancia() 
        { 
            if(_Instancia==null) {
                _Instancia = new FrmLibroVentas();
            }
            return _Instancia;
        }


        private void FrmLibroVentas_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 50;

            //Se inicializa el fecha desde con el primer día del mes
            var FechaInicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDesde.Value = FechaInicioMes;

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
        try 
        {
                var desde = dtpDesde.Value;
                var hasta = dtpHasta.Value;
                CargarDatos(desde, hasta);
        }
            catch(Exception ex) 
        {
                MessageBox.Show(ex.Message);
        }
           
        }

        private void FrmLibroVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }


        private void CargarDatos(DateTime inicio, DateTime fin) 
        {
            NLibroVentaReport reportModel = new NLibroVentaReport();
            reportModel.LibroVentaReport(inicio, fin);

            nLibroVentaReportBindingSource.DataSource = reportModel;
            nDetalleDeVentasBindingSource.DataSource = reportModel.DetallesVentas;

            this.reportViewer1.RefreshReport();
        }
    }
}
