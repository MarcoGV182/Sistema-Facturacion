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
    public partial class FrmInformePagosProveedor : Form
    {
        public int cuentapagarnro;
        public FrmInformePagosProveedor()
        {
            InitializeComponent();
        }

        private void FrmInformePagosCliente_Load(object sender, EventArgs e)
        {
            try
            {
                this.sp_ReportePagosProveedorTableAdapter.Fill(this.DsReporte.sp_ReportePagosProveedor, cuentapagarnro);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
