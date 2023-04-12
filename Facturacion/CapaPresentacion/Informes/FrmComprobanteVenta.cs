using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CapaPresentacion
{
    public partial class FrmComprobanteVenta : Form
    {
        public int nroVenta;
      
        public FrmComprobanteVenta()
        {
            InitializeComponent();           
        }        

        private void FrmComprobanteVenta_Load(object sender, EventArgs e)
        {
            this.Top = 100;
            this.Left = 50;

            try
            {   
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteFactura' Puede moverla o quitarla según sea necesario.
                DsReporte.sp_ReporteFactura.Clear();
                DsReporte.EnforceConstraints = false;

                this.sp_ReporteFacturaTableAdapter.Fill(this.DsReporte.sp_ReporteFactura, nroVenta);
                this.sp_ReporteFacturaDetalleTableAdapter.Fill(this.DsReporte.sp_ReporteFacturaDetalle, nroVenta);
                this.reportViewer1.RefreshReport();
                //this.reportViewer1.RenderingComplete+= new RenderingCompleteEventHandler(reportViewer1_RenderingComplete);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmComprobanteVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Liberar recursos y hacer limpieza antes de cerrar el formulario
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
