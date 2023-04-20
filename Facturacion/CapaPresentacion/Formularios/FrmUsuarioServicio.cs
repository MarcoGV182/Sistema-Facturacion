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
using CapaPresentacion.Formularios.Facturacion;
using CapaPresentacion.Formularios.Mantenimiento;

namespace CapaPresentacion
{
    public partial class FrmUsuarioServicio : Form
    {
        int servicio;
        public FrmUsuarioServicio()
        {
            InitializeComponent();
        }

        //Metodo de mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }



        //OBTENER DATOS DEL FORMULARIO ANTERIOR
        public void ObtenerDato(int servicionro) 
        {
            servicio = servicionro;
        }


        private void Mostrar()
        {
            //this.dataListado.DataSource = NUsuarios.MostrarUsuarioServicio(servicio);
            //this.dataListado.Columns["Descripcion"].Width = 100;
            //this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void Frm_UsuarioServicio_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
            
                FrmOrdenTrabajo frm = FrmOrdenTrabajo.GetInstancia();
                string usuarionro, nombre;
                usuarionro = Convert.ToString(dataListado.CurrentRow.Cells["PersonaNro"].Value);
                nombre = Convert.ToString(dataListado.CurrentRow.Cells["Nombre"].Value) + " " + Convert.ToString(dataListado.CurrentRow.Cells["Apellido"].Value);
                frm.ObtenerEmpleado(usuarionro, nombre);
                //LLEVAR LOS DATOS DE USUARIOSERVICIO SELECCIONADO A FACTURA
                FrmFacturaVenta frmF = FrmFacturaVenta.GetInstancia();
                frmF.ObtenerEmpleadoFactura(usuarionro, nombre);

                this.Hide();
            }
            catch (Exception)
            {
                MensajeError("Seleccione una fila");
            
            }
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataListado.Columns["Salario"].DefaultCellStyle.Format = "N0";
        }
    }
}
