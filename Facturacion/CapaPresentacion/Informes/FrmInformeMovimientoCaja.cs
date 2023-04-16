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
    public partial class FrmInformeMovimientoCaja : Form
    {
        //ATRIBUTOS CAJA
        public int? CajaNro;



        public FrmInformeMovimientoCaja()
        {
            InitializeComponent();
        }

        private void FrmInformeMovimientoCaja_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteFactura' Puede moverla o quitarla según sea necesario.
            DsReporte.sp_ReporteFactura.Clear();
            DsReporte.EnforceConstraints = false;
                        
            this.sp_MostrarCabeceraArqueoCajaTableAdapter.Fill(this.DsReporte.sp_MostrarCabeceraArqueoCaja, CajaNro);
            this.sp_MostrarDetalleArqueoCajaTableAdapter.Fill(this.DsReporte.sp_MostrarDetalleArqueoCaja,CajaNro);
            this.reportViewer1.RefreshReport();

        }
    }
}
