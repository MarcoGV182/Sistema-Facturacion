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
    public partial class FrmInformeServicio : Form
    {
        public FrmInformeServicio()
        {
            InitializeComponent();
        }

        private void FrmInformeServicio_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 50;
            try 
        {      
                this.sp_ReporteServicioTableAdapter.Fill(this.DsReporte.sp_ReporteServicio);
                this.reportViewer1.RefreshReport();
        }
        catch(Exception ex) 
        {
                MessageBox.Show(ex.Message); 
        }
            
        }
    }
}
