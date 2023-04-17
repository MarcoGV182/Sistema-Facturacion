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
using System.Data.SqlClient;
using CapaDatos;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class FrmVistaCliente : Form
    {

        bool IsNuevo = false;

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmVistaCliente _Instancia;

        public static FrmVistaCliente GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmVistaCliente();
            }
            return _Instancia;
        }

        public FrmVistaCliente()
        {
            InitializeComponent();
            LlenarComboBox();
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


        private void DataGridDiseno(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv.BackgroundColor = Color.White;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }



        //Limpiar los controles del formulario
        private void Limpiar()
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cboCiudad.Text = string.Empty;
            dtpFechaNac.Text = string.Empty;
            txtObservacion.Text = string.Empty;

            dtpFechaNac.Value = DateTime.Now;
            dtpFechaNac.Checked = false;

            //Iniciliar los combobox
            cboCiudad.SelectedIndex = 0;
            cboTipoDocumento.SelectedIndex = 0;
        }

        //Habilitar botones
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.txtDocumento.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.cboCiudad.Enabled = valor;
            this.dtpFechaNac.Enabled = valor;
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        //ocultar columnas
        private void OcultarColumnas()
        {  
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns["NroTipoDocumento"].Visible = false;
        }

        private void LlenarComboBox()
        {
            cboCiudad.DataSource = ControlesCompartidos.AgregarNuevaFila(NCiudad.Mostrar(), "Descripcion", "CiudadNro");
            cboCiudad.ValueMember = "CiudadNro";
            cboCiudad.DisplayMember = "Descripcion";


            cboTipoDocumento.DataSource = ControlesCompartidos.AgregarNuevaFila(NTipoDocumento.Mostrar(), "Descripcion", "idTipoDocumento");
            cboTipoDocumento.ValueMember = "idTipoDocumento";
            cboTipoDocumento.DisplayMember = "Descripcion";
        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
            //this.dataListado.Columns["Descripcion"].Width = 100;
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

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

        private void BuscarDocumento()
        {
            this.dataListado.DataSource = NCliente.BuscarDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmVistaCliente_Load(object sender, EventArgs e)
        {
            DataGridDiseno(dataListado);
            //inicializar combo de busqueda
            cboBuscar.SelectedIndex = 0;
            dtpFechaNac.Checked = false;

            //top para ubicar en la parte superior
            this.Top = 100;
            //alineado hacia la izquierda
            this.Left = 50;
            this.Habilitar(false);
            this.Botones();
            this.Mostrar();
        }
                

        private void NuevoRegistro()
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private bool ValidacionCliente()
        {
            if (this.txtNombre.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtNombre, "Ingrese la Nombre o Razon Social");
                return false;
            }

            if (Convert.ToInt32(cboTipoDocumento.SelectedValue) == 0)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboTipoDocumento, "Seleccione el tipo de documento");
                return false;
            }

            if (this.txtDocumento.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtDocumento, "Ingrese el Nro de documento");
                return false;
            }
            

            return true;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (!ValidacionCliente())
                    return;

                //si se ingresa un nuevo registro

                DClientes cliente = new DClientes();
                int codigoCliente = string.IsNullOrEmpty(txtCodigo.Text) ? 0 : Convert.ToInt32(txtCodigo.Text);
                cliente.PersonaNro = codigoCliente;
                cliente.Nombre = this.txtNombre.Text.Trim().ToUpper();
                cliente.Apellido = this.txtApellido.Text.Trim().ToUpper();
                cliente.Documento = this.txtDocumento.Text.Trim();
                DTipoDocumento tipoDocumento = new DTipoDocumento()
                {
                    idTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue),
                    Descripcion = cboTipoDocumento.Text
                };
                cliente.TipoDocumento = tipoDocumento;
                cliente.FechaNacimiento = dtpFechaNac.Checked == false ? (DateTime?)null : dtpFechaNac.Value;
                if (Convert.ToInt32(cboCiudad.SelectedValue) != 0)
                    cliente.CiudadNro = Convert.ToInt32(cboCiudad.SelectedValue);
                cliente.Direccion = this.txtDireccion.Text.Trim();
                cliente.Telefono = this.txtTelefono.Text.Trim();
                cliente.Email = this.txtEmail.Text.Trim();
                cliente.Observacion = this.txtObservacion.Text.Trim().ToUpper();

                rpta = NCliente.Insertar(cliente);

                if (rpta.Equals("OK"))
                    this.MensajeOK("Se ha insertado con exito");
                else 
                {
                    this.MensajeError(rpta);
                    return;
                }

                this.Botones();
                this.Limpiar();
                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtCodigo.Text.Equals(""))
            {  
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void FrmVistaCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmFacturaVenta frmVenta = FrmFacturaVenta.GetInstancia();
            int codigo;
            string documento,nombre,apellido;
            codigo = Convert.ToInt32(dataListado.CurrentRow.Cells["PersonaNro"].Value);
            nombre = Convert.ToString(dataListado.CurrentRow.Cells["Nombre"].Value);
            apellido = Convert.ToString(dataListado.CurrentRow.Cells["Apellido"].Value);
            documento = Convert.ToString(dataListado.CurrentRow.Cells["Documento"].Value); 
            frmVenta.ObtenerCliente(codigo,documento, nombre,apellido);
            this.Hide();
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
       

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                NuevoRegistro();
            }
        }
    }
}
