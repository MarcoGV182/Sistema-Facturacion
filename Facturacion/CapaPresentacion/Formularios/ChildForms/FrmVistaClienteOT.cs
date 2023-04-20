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
using CapaPresentacion.Formularios.Mantenimiento;

namespace CapaPresentacion.Formularios.ChildForms
{
    public partial class FrmVistaClienteOT : Form
    {
        public FrmVistaClienteOT()
        {
            InitializeComponent();
        }


        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmVistaClienteOT _Instancia;

        public static FrmVistaClienteOT GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmVistaClienteOT();
            }
            return _Instancia;
        }

        //ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Metodo de mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void DataGridDiseno()
        {
            dataListado.BorderStyle = BorderStyle.None;
            dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataListado.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataListado.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dataListado.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataListado.BackgroundColor = Color.White;

            dataListado.EnableHeadersVisualStyles = false;
            dataListado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataListado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataListado.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }



        //Metodo buscar por Nombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCliente.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        

        //Metodo buscar por Apellido
        private void BuscarApellido()
        {
            this.dataListado.DataSource = NCliente.BuscarApellido(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        //Metodo buscar por Documento
        private void BuscarDocumento()
        {
            this.dataListado.DataSource = NCliente.BuscarDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
            //this.dataListado.Columns["Descripcion"].Width = 100;
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        private void MedidaColumna(DataGridView dg)
        {
            dg.Columns["Nombre"].Width = 150;
            dg.Columns["Apellido"].Width = 150;
            dg.Columns["Direccion"].Width = 200;
            dg.Columns["Documento"].Width = 80;
            dg.Columns["FechaNacimiento"].Width = 50;
        }


        private void FrmVistaClienteOT_Load(object sender, EventArgs e)
        {
            DataGridDiseno();
            //inicializar combo de busqueda
            cboBuscar.SelectedIndex = 0;

            //top para ubicar en la parte superior
            this.Top = 100;
            //alineado hacia la izquierda
            this.Left = 50;
            this.Mostrar();
            this.MedidaColumna(dataListado);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (this.txtBuscar.Text == string.Empty)
            {
                this.Mostrar();
            }
            else if (cboBuscar.SelectedItem.Equals("Nombre"))
            {
                this.BuscarNombre();
            }
            else if (cboBuscar.SelectedItem.Equals("Apellido"))
            {
                this.BuscarApellido();
            }

            else
            {
                this.BuscarDocumento();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FrmOrdenTrabajo frmVenta = FrmOrdenTrabajo.GetInstancia();
                string codigo, documento, nombre, apellido;
                codigo = Convert.ToString(dataListado.CurrentRow.Cells["PersonaNro"].Value);
                documento = Convert.ToString(dataListado.CurrentRow.Cells["Documento"].Value);
                nombre = Convert.ToString(dataListado.CurrentRow.Cells["Nombre"].Value);
                apellido = Convert.ToString(dataListado.CurrentRow.Cells["Apellido"].Value);
                frmVenta.ObtenerCliente(codigo, documento, nombre, apellido);
                this.Hide();
            }
            catch (Exception)
            {
                MensajeError("Seleccione a un Cliente");
            }
            
        }

        private void FrmVistaClienteOT_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
