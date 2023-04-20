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
    public partial class FrmInformeLiquidacion : Form
    {
        private int proceso;
            
        public FrmInformeLiquidacion()
        {
            InitializeComponent();
            CargarCombo();
        }

        public void CargarCombo() 
        {
            cboEmpleado.DataSource = NColaborador.MostrarColaboradorActivo();
            cboEmpleado.ValueMember = "ColaboradorNro";
            cboEmpleado.DisplayMember = "NombreApellido";
        }
            

        public void obtenerProceso(int procesonro) 
        {
            proceso = procesonro;
        }


        private void FrmInformeLiquidacion_Load(object sender, EventArgs e)
        {
            

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteLiquidacionFinal' Puede moverla o quitarla según sea necesario.
                this.sp_ReporteLiquidacionFinalTableAdapter.Fill(this.DsReporte.sp_ReporteLiquidacionFinal, Convert.ToInt32(this.cboEmpleado.SelectedValue), proceso);
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteDetalleLiquidacionFinal' Puede moverla o quitarla según sea necesario.
                this.sp_ReporteDetalleLiquidacionFinalTableAdapter.Fill(this.DsReporte.sp_ReporteDetalleLiquidacionFinal, Convert.ToInt32(this.cboEmpleado.SelectedValue), proceso);
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteDetalleLiquidacionFinal' Puede moverla o quitarla según sea necesario.
                this.sp_ReporteServiciosRealizadosUsuarioTableAdapter.Fill(this.DsReporte.sp_ReporteServiciosRealizadosUsuario, Convert.ToInt32(this.cboEmpleado.SelectedValue), proceso);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
