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
    public partial class FrmLibroCompra : Form
    {
        public FrmLibroCompra()
        {
            InitializeComponent();
        }

        private static FrmLibroCompra _Instancia;

        public static FrmLibroCompra GetInstancia() 
        { 
            if(_Instancia==null) 
            {
                _Instancia = new FrmLibroCompra();
            }
            return _Instancia;
        }


        private void FrmLibroCompra_Load(object sender, EventArgs e)
        {
            this.Top =0;
            this.Left = 50;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try 
            {
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_LibroCompra' Puede moverla o quitarla según sea necesario.
                this.sp_LibroCompraTableAdapter.Fill(this.DsReporte.sp_LibroCompra,dtpDesde.Value.ToString("dd-MM-yyyy"),dtpHasta.Value.ToString("dd-MM-yyyy"));

                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }
            
           
        }

        private void FrmLibroCompra_FormClosing(object sender, FormClosingEventArgs e)
        {

            _Instancia = null;
        }
    }
}
