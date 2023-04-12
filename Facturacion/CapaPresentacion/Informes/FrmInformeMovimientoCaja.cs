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
        public double ImporteApertura;
        public double ImporteEntrega;
        public double SaldoFinal;
        public double DiferenciaCierre;
        public double Efectivo;
        public double tarjeta;
        public double Cheque;
        public double Otros;
        public string Estado = "";



        public FrmInformeMovimientoCaja()
        {
            InitializeComponent();
        }

        private void FrmInformeMovimientoCaja_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteMovimientoCaja' Puede moverla o quitarla según sea necesario.
            //this.sp_ReporteMovimientoCajaTableAdapter.Fill(this.DsReporte.sp_ReporteMovimientoCaja,this.FechaApertura,this.FechaCierre,this.Usuario,this.FechaApertura,this.FechaCierre,this.ImporteApertura,this.ImporteEntrega,this.SaldoFinal,this.DiferenciaCierre,Efectivo,tarjeta,Cheque, Otros, this.Estado);

            this.reportViewer1.RefreshReport();
        }
    }
}
