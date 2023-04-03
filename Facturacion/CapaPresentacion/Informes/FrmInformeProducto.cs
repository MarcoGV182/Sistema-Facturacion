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
    public partial class FrmInformeProducto : Form
    {
        public FrmInformeProducto()
        {
            InitializeComponent();
        }

        private void FrmInformeProducto_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 50;
            
            try 
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                this.sp_ReporteProductoTableAdapter.Fill(this.DsReporte.sp_ReporteProducto);
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
