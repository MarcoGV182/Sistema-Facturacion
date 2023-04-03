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
    public partial class FrmInformeAjuste : Form
    {
        public int codajuste;
        public FrmInformeAjuste()
        {
            InitializeComponent();
        }

        private void FrmInformeAjuste_Load(object sender, EventArgs e)
        {
            try 
            {
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteAjuste' Puede moverla o quitarla según sea necesario.
                this.sp_ReporteAjusteTableAdapter.Fill(this.DsReporte.sp_ReporteAjuste, codajuste);

                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)             
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
