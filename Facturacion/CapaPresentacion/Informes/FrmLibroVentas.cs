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
    public partial class FrmLibroVentas : Form
    {
        public FrmLibroVentas()
        {
            InitializeComponent();
        }

        private static FrmLibroVentas _Instancia;

        public static FrmLibroVentas GetInstancia() 
        { 
            if(_Instancia==null) {
                _Instancia = new FrmLibroVentas();
            }
            return _Instancia;
        }


        private void FrmLibroVentas_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 50;


        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
        try 
        {
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_LibroVenta' Puede moverla o quitarla según sea necesario.
                this.sp_LibroVentaTableAdapter.Fill(this.DsReporte.sp_LibroVenta, this.dtpDesde.Value.ToString("dd/MM/yyyy"), this.dtpHasta.Value.ToString("dd/MM/yyyy"));

                this.reportViewer1.RefreshReport();
        }
            catch(Exception ex) 
        {
                MessageBox.Show(ex.Message);
        }
           
        }

        private void FrmLibroVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
