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
    public partial class FrmInformeMovimiento : Form
    {
        public FrmInformeMovimiento()
        {
            InitializeComponent();
        }

        private void FrmInformeMovimiento_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 50;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
        try 
        {
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteMovimiento' Puede moverla o quitarla según sea necesario.
                this.sp_ReporteMovimientoTableAdapter.Fill(this.DsReporte.sp_ReporteMovimiento, dtpDesde.Value.ToString("yyyy-MM-dd"), dtpHasta.Value.ToString("yyyy-MM-dd"));

                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex) 
        {
                MessageBox.Show(ex.Message);
        }
            
        }
    }
}
