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
        public string Usuario = "";
        public string FechaApertura = "";
        public string FechaCierre = "";
        public decimal ImporteApertura;
        public decimal ImporteEntrega;
        public decimal SaldoFinal;
        public decimal DiferenciaCierre;
        public decimal Efectivo;
        public decimal tarjeta;
        public decimal Cheque;
        public string Estado = "";



        public FrmInformeMovimientoCaja()
        {
            InitializeComponent();
        }

        private void FrmInformeMovimientoCaja_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteMovimientoCaja' Puede moverla o quitarla según sea necesario.
            this.sp_ReporteMovimientoCajaTableAdapter.Fill(this.DsReporte.sp_ReporteMovimientoCaja,this.FechaApertura,this.FechaCierre,this.Usuario,this.FechaApertura,this.FechaCierre,this.ImporteApertura,this.ImporteEntrega,this.SaldoFinal,this.DiferenciaCierre,Efectivo,tarjeta,Cheque,this.Estado);

            this.reportViewer1.RefreshReport();
        }
    }
}
