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
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.cboCiudad.Text = string.Empty;
            this.dtpFechaNac.Text = string.Empty;
            this.cboEstado.Text = string.Empty;
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
            this.cboEstado.Enabled = valor;
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        //ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        private void LlenarComboBox()
        {
            cboCiudad.DataSource = NCiudad.Mostrar();
            cboCiudad.ValueMember = "CiudadNro";
            cboCiudad.DisplayMember = "Descripcion";

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
            
            //top para ubicar en la parte superior
            this.Top = 100;
            //alineado hacia la izquierda
            this.Left = 50;
            this.Habilitar(false);
            this.Botones();
            this.Mostrar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.cboEstado.SelectedIndex = 0;
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

            if (this.txtDocumento.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtDocumento, "Ingrese el Nro de documento");
                return false;
            }

            if (this.cboEstado.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboEstado, "Ingrese el Estado");
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


                DClientes cliente = new DClientes();
                int codigoCliente = string.IsNullOrEmpty(txtCodigo.Text) ? 0 : Convert.ToInt32(txtCodigo.Text);
                cliente.PersonaNro = codigoCliente;
                cliente.Nombre = this.txtNombre.Text.Trim().ToUpper();
                cliente.Apellido = this.txtApellido.Text.Trim().ToUpper();
                cliente.Documento = this.txtDocumento.Text.Trim();
                DTipoDocumento tipoDocumento = new DTipoDocumento()
                {
                    idTipoDocumento = Convert.ToInt32(cboCiudad.SelectedValue),
                    Descripcion = cboCiudad.Text
                };
                cliente.TipoDocumento = tipoDocumento;
                cliente.FechaNacimiento = dtpFechaNac.Checked == false ? (DateTime?)null : dtpFechaNac.Value;
                cliente.CiudadNro = Convert.ToInt32(cboCiudad.SelectedValue);
                cliente.Direccion = this.txtDireccion.Text.Trim();
                cliente.Telefono = this.txtTelefono.Text.Trim();
                cliente.Email = this.txtEmail.Text.Trim();
                cliente.Estado = this.cboEstado.Text;
                cliente.Observacion = this.txtObservacion.Text.Trim().ToUpper();

                //si se ingresa un nuevo registro
                if (this.IsNuevo)
                {
                    rpta = NCliente.Insertar(cliente);
                    //si se esta editando el registro   
                }
                else
                {
                    rpta = NCliente.Editar(cliente);

                }
                if (rpta.Equals("OK"))
                {
                    if (IsNuevo)
                    {
                        this.MensajeOK("Se ha insertado con exito");
                    }
                    else
                    {
                        this.MensajeOK("Se ha editado con exito");
                    }
                }
                else
                {
                    this.MensajeError(rpta);
                }

                this.IsNuevo = false;
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

        private void FrmVistaCliente_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
