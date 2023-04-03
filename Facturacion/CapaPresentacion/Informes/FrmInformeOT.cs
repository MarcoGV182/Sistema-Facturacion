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
    public partial class FrmInformeOT : Form
    {
        public int nroot; 
        public FrmInformeOT()
        {
            InitializeComponent();
        }

        private void FrmInformeOT_Load(object sender, EventArgs e)
        {
            this.Top = 100;
            this.Left = 50;
            try 
            {
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteOT' Puede moverla o quitarla según sea necesario.
                this.sp_ReporteOTTableAdapter.Fill(this.DsReporte.sp_ReporteOT, nroot);

                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }

           
        }
    }
}
