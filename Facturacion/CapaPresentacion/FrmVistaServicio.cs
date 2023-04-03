using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmVistaServicio : Form
    {

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmVistaServicio _Instancia;

        public static FrmVistaServicio GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmVistaServicio();
            }

            return _Instancia;
        }



        public FrmVistaServicio()
        {
            InitializeComponent();
        }

        //Metodo de mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void OcultarColumnasServicio()
        {
            this.dataListado.Columns[0].Visible = false;
            //this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[5].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[7].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[9].Visible = false;
            //this.dataListado.Columns[10].Visible = false;
            
            
        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
                this.dataListado.DataSource = NServicio.Mostrar();
                this.OcultarColumnasServicio();
                lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarServicio()
        {
            this.dataListado.DataSource = NServicio.BuscarServicio(this.txtBuscar.Text);
            this.OcultarColumnasServicio();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }



        private void FrmVistaServicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //Al hacer doble Click sobre un producto o servicio se cargan en el formulario Ventas los siguiente datos
                FrmOrdenTrabajo frm = FrmOrdenTrabajo.GetInstancia();
                string codigo, descripcion, precio, iva, divisor, gravadas, comision;
                codigo = Convert.ToString(dataListado.CurrentRow.Cells["ServicioNro"].Value);
                descripcion = Convert.ToString(dataListado.CurrentRow.Cells["Servicio"].Value);
                precio = Convert.ToString(dataListado.CurrentRow.Cells["Precio"].Value);
                iva = Convert.ToString(dataListado.CurrentRow.Cells["PorcentajeIva"].Value);
                divisor = Convert.ToString(dataListado.CurrentRow.Cells["Divisor"].Value);
                gravadas = Convert.ToString(dataListado.CurrentRow.Cells["Gravadas"].Value);
                comision = Convert.ToString(dataListado.CurrentRow.Cells["PorcentajeComision"].Value);
                frm.ObtenerServicio(codigo, descripcion, precio, iva, divisor, gravadas, comision);

                FrmUsuarioServicio frmUS = new FrmUsuarioServicio();
                frmUS.ObtenerDato(Convert.ToInt32(codigo));
                frmUS.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarServicio();
        }

        private void FrmVistaServicio_Load(object sender, EventArgs e)
        {
            //top para ubicar en la parte superior
            
            //alineado hacia la izquierda
            
            this.Mostrar();
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataListado.Columns["Precio"].DefaultCellStyle.Format = "N0";
        }
    }
}
