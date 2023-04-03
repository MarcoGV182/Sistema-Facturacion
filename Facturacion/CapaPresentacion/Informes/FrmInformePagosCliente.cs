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
    public partial class FrmInformePagosCliente : Form
    {
        public int cuentacobrarnro;
        public FrmInformePagosCliente()
        {
            InitializeComponent();
        }

        private void FrmInformePagosCliente_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReportePagosCliente' Puede moverla o quitarla según sea necesario.
                this.sp_ReportePagosClienteTableAdapter.Fill(this.DsReporte.sp_ReportePagosCliente, cuentacobrarnro);
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteOT' Puede moverla o quitarla según sea necesario.

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
