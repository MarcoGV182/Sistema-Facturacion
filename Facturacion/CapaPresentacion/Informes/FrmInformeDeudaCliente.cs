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
    public partial class FrmInformeDeudaCliente : Form
    {
        public FrmInformeDeudaCliente()
        {
            InitializeComponent();
        }

        private void FrmInformeDeudaCliente_Load(object sender, EventArgs e)
        {
           
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteDeudas' Puede moverla o quitarla según sea necesario.
            this.sp_ReporteDeudasTableAdapter.Fill(this.DsReporte.sp_ReporteDeudas,cboEstado.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
