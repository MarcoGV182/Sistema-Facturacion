using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmProductosMasVendidos : Form
    {
        public FrmProductosMasVendidos()
        {
            InitializeComponent();
        }

        private static FrmProductosMasVendidos _Instancia;

        public static FrmProductosMasVendidos GetInstancia() {
            if(_Instancia==null) {
                _Instancia = new FrmProductosMasVendidos();
            }
            return _Instancia;
        }

        private void FrmProductosMasVendidos_Load(object sender, EventArgs e)
        {
            this.Top = 100;
            this.Left = 50;

            //Primer dia del mes actual
            dtpDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //Ultimo dia del mes actual
            dtpHasta.Value = dtpDesde.Value.AddMonths(1).AddDays(-1);

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try 
            {
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteProductosMasVendidos' Puede moverla o quitarla según sea necesario.
                DateTime desde = dtpDesde.Value;
                DateTime hasta = dtpHasta.Value;
                this.sp_ReporteProductosMasVendidosTableAdapter.Fill(this.DsReporte.sp_ReporteProductosMasVendidos, desde, hasta);

                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
           
        }

        private void FrmProductosMasVendidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
