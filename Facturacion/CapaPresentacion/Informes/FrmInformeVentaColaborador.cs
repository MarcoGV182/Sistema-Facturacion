using CapaNegocio;
using CapaNegocio.Reporting;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class FrmInformeVentaColaborador : Form
    {
        private static FrmInformeVentaColaborador _Instancia;

        public FrmInformeVentaColaborador()
        {
            InitializeComponent();            
        }

        public static FrmInformeVentaColaborador GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmInformeVentaColaborador();
            }
            return _Instancia;
        }

        private void LlenarCombo() 
        {
            cboColaborador.DataSource = ControlesCompartidos.AgregarNuevaFila(NColaborador.MostrarColaboradorActivo(), "NombreApellido", "ColaboradorNro"); ;
            cboColaborador.DisplayMember = "NombreApellido";
            cboColaborador.ValueMember = "ColaboradorNro";

        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            LlenarCombo();

            //Se inicializa el fecha desde con el primer día del mes
            var FechaInicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDesde.Value = FechaInicioMes;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                var desde = dtpDesde.Value;
                var hasta = dtpHasta.Value;
                var idColaborador = Convert.ToInt32(cboColaborador.SelectedValue) == 0 ? (int?)null : Convert.ToInt32(cboColaborador.SelectedValue);
                CargarDatos(desde, hasta, idColaborador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarDatos(DateTime inicio, DateTime fin, int? colaborador)
        {
            NInformeVentaColaborador reportModel = new NInformeVentaColaborador();
            reportModel.ObtenerInformeVentaColaborador(inicio, fin, colaborador);
            reportModel.NombreColaborador = Convert.ToInt32(cboColaborador.SelectedValue) == 0 ? "Todos" : $"{cboColaborador.Text} ({cboColaborador.SelectedValue})"  ;
            nInformeVentaColaboradorBindingSource.DataSource = reportModel;
            eDetalleInformeVentaColaboradorBindingSource.DataSource = reportModel.Detalleinforme;

            this.reportViewer1.RefreshReport();
        }

        private void FrmInformeVentaColaborador_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
