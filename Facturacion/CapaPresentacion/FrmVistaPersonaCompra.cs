using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmVistaPersonaCompra : Form
    {
        bool IsNuevo = false;
        bool IsEditar = false;

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmVistaPersonaCompra _Instancia;

        public static FrmVistaPersonaCompra GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmVistaPersonaCompra();
            }
            return _Instancia;
        }


        public FrmVistaPersonaCompra()
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
            this.dtpFechaAniversario.Text = string.Empty;
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
            this.dtpFechaAniversario.Enabled = valor;
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
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


            cboTipoDocumento.DataSource = NTipoDocumento.Mostrar();
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

        //Metodo buscar por descripcion
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCliente.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarDocumento()
        {
            this.dataListado.DataSource = NCliente.BuscarDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmVistaPersonaCompra_Load(object sender, EventArgs e)
        {
            //inicializar combo de busqueda
            rbRUC.Checked = true;
            rbRazonSocial.Checked = false;

            //top para ubicar en la parte superior
            this.Top = 100;
            //alineado hacia la izquierda
            this.Left = 50;
            this.Habilitar(false);
            this.Botones();
            this.Mostrar();

            rbRUC.CheckedChanged += RadioButton_CheckedChanged;
            rbRazonSocial.CheckedChanged += RadioButton_CheckedChanged;
        }

       

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
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

            if (this.txtDocumento.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtDocumento, "Ingrese el Nro de documento");
                return false;
            }

            return true;

        }


        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Checked)
            {
                // Desmarca los otros RadioButton
                foreach (RadioButton otherRadioButton in groupBox1.Controls.OfType<RadioButton>().Where(rb => rb != radioButton))
                {
                    otherRadioButton.Checked = false;
                }
            }
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
                cliente.FechaNacimiento = dtpFechaAniversario.Checked == false ? (DateTime?)null : dtpFechaAniversario.Value;
                cliente.CiudadNro = Convert.ToInt32(cboCiudad.SelectedValue);
                cliente.Direccion = this.txtDireccion.Text.Trim();
                cliente.Telefono = this.txtTelefono.Text.Trim();
                cliente.Email = this.txtEmail.Text.Trim();
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
                this.IsEditar = false;
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
                this.IsEditar = true;
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
            this.Limpiar();
            this.Habilitar(false);
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try 
            {
                FrmCompra frm = FrmCompra.GetInstancia();
                string codigo, razonsocial,documento;
                codigo = Convert.ToString(dataListado.CurrentRow.Cells["PersonaNro"].Value);
                razonsocial = Convert.ToString(dataListado.CurrentRow.Cells["Nombre"].Value);
                documento = Convert.ToString(dataListado.CurrentRow.Cells["Documento"].Value);
                frm.ObtenerProveedor(codigo,documento,razonsocial);
                this.Hide();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtBuscar.Text))
            {
                this.Mostrar();
            }

            else if (rbRazonSocial.Checked)
            {
                this.BuscarNombre();
            }
            else if (rbRUC.Checked)
            {
                this.BuscarDocumento();
            }
        }
    }
}
