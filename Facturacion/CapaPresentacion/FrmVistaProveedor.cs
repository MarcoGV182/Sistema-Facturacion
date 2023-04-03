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
    public partial class FrmVistaProveedor : Form
    {
        bool IsNuevo = false;
        bool IsEditar = false;

        public FrmVistaProveedor()
        {
            InitializeComponent();
            LlenarComboBox();
            
        }

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmVistaProveedor _Instancia;
        public static FrmVistaProveedor GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmVistaProveedor();
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

        //Limpiar los controles del formulario
        private void Limpiar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtRazonSocial.Text = string.Empty;
            this.txtRUC.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.cboCiudad.Text = string.Empty;
            this.cboEstado.Text = string.Empty;
        }

        //Habilitar botones
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtRazonSocial.ReadOnly = !valor;
            this.txtRUC.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.cboCiudad.Enabled = valor;
            this.cboEstado.Enabled = valor;
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

        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            this.dataListado.DataSource = NProveedor.Mostrar();
            //this.dataListado.Columns["Descripcion"].Width = 100;
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Metodo buscar por descripcion
        private void BuscarRazonSocial()
        {
            this.dataListado.DataSource = NProveedor.BuscarProveedor("RS",this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarRUC()
        {
            this.dataListado.DataSource = NProveedor.BuscarProveedor("R",this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.cboEstado.SelectedIndex = 0;
            this.txtRazonSocial.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtRazonSocial.Text == string.Empty)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtRazonSocial, "Ingrese la RazonSocial");
                }
                else if (this.txtRUC.Text == string.Empty)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtRUC, "Ingrese el Nro de RUC del Proveedor");
                }
                else if (this.cboEstado.Text == string.Empty)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(cboEstado, "Ingrese el Estado del Proveedor");
                }
                else
                {
                    //si se ingresa un nuevo registro
                    if (this.IsNuevo)
                    {
                        //rpta = NProveedor.Insertar(this.txtRazonSocial.Text.Trim().ToUpper(), this.txtRUC.Text.Trim(), Convert.ToInt32(cboCiudad.SelectedValue), this.txtDireccion.Text.Trim(), this.txtTelefono.Text.Trim(), this.txtEmail.Text.Trim(), this.cboEstado.Text, this.txtRepresentante.Text);
                        //si se esta editando el registro    
                    }
                    else
                    {
                        //rpta = NProveedor.Editar(Convert.ToInt32(this.txtCodigo.Text), this.txtRazonSocial.Text.Trim().ToUpper(), this.txtRUC.Text.Trim(), Convert.ToInt32(cboCiudad.SelectedValue), this.txtDireccion.Text.Trim(), this.txtTelefono.Text.Trim(), this.txtEmail.Text.Trim(), this.cboEstado.Text, this.txtRepresentante.Text);
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

        private void FrmVistaProveedor_Load(object sender, EventArgs e)
        {
            //inicializar combo de busqueda
            cboBuscar.SelectedIndex = 0;
            //top para ubicar en la parte superior
            this.Top = 0;
            //alineado hacia la izquierda
            this.Left = 0;
            this.Habilitar(false);
            this.Botones();
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cboBuscar.SelectedItem.Equals("Razon Social"))
            {
                this.BuscarRazonSocial();
            }
            else
            {
                this.BuscarRUC();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmCompra frm = FrmCompra.GetInstancia();
            string codigo,documento ,razonsocial;
            codigo = Convert.ToString(dataListado.CurrentRow.Cells["ProveedorNro"].Value);
            razonsocial = Convert.ToString(dataListado.CurrentRow.Cells["RazonSocial"].Value);
            documento = Convert.ToString(dataListado.CurrentRow.Cells["Documento"].Value);

            frm.ObtenerProveedor(codigo, documento,razonsocial);
            this.Hide();
        }
    }
}
