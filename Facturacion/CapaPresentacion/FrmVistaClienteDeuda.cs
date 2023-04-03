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
    public partial class FrmVistaClienteDeuda : Form
    {
        public FrmVistaClienteDeuda()
        {
            InitializeComponent();
        }

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmVistaClienteDeuda _Instancia;
        public static FrmVistaClienteDeuda GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmVistaClienteDeuda();
            }
            return _Instancia;
        }


        //Metodo de mensaje de confirmacion
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Metodo de mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //ocultar columnas
        private void OcultarColumnas()
        {
            try
            {
                this.dataListado.Columns[0].Visible = false;
                this.dataListado.Columns[1].Visible = false;
                this.dataListado.Columns["CodTipoPago"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            try 
            {
                this.dataListado.DataSource = NCliente.MostrarDeudaCliente();
                //this.dataListado.Columns["Descripcion"].Width = 100;
                this.OcultarColumnas();
                lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            }
            catch(Exception) 
            {
                MessageBox.Show("No existen Cuentas a Pagar");
            }
            

        }
              

        private void BuscarRUC()
        {
            this.dataListado.DataSource = NCliente.BuscarDeudaClienteDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmVistaClienteDeuda_Load(object sender, EventArgs e)
        {
            
            //top para ubicar en la parte superior
            this.Top = 100;
            //alineado hacia la izquierda
            this.Left = 50;           
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text==string.Empty)
            {
                this.Mostrar();
            }
            else
            {
                this.BuscarRUC();
            }
            
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
        try 
        {
                FrmCuentaPorCobrar frm = FrmCuentaPorCobrar.GetInstancia();
                string codigo, documento, nombre, apellido, direccion;
                codigo = Convert.ToString(dataListado.CurrentRow.Cells["PersonaNro"].Value);
                documento = Convert.ToString(dataListado.CurrentRow.Cells["documento"].Value);
                nombre = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
                apellido = Convert.ToString(dataListado.CurrentRow.Cells["apellido"].Value);
                direccion = Convert.ToString(dataListado.CurrentRow.Cells["direccion"].Value);
                frm.ObtenerDatosCliente(codigo, documento, nombre, apellido, direccion);
                this.Hide();

            }
            catch(Exception) 
        {
                MessageBox.Show("Seleccione un registro", "Sistema de Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void FrmVistaClienteDeuda_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
