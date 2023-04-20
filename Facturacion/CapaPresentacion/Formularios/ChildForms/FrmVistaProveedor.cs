using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Formularios.Facturacion;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion.Formularios.ChildForms
{
    public partial class FrmVistaProveedor : Form
    {
        bool IsNuevo = false;

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
            this.txtObservacion.Text = string.Empty;
            this.cboCiudad.SelectedIndex = 0;
            this.cboTipoDocumento.SelectedIndex = 0;
            this.dtpFechaAniversario.Checked = false;
            this.dtpFechaAniversario.Value = DateTime.Now;
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
            this.dataListado.Columns[2].Visible = false;
            this.dataListado.Columns[5].Visible = false;
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
                

        private void NuevoRegistro() 
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtRazonSocial.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (!ValidacionProveedor())
                    return;

                //si se ingresa un nuevo registro

                DProveedor proveedor = new DProveedor();
                int codigoProveedor = string.IsNullOrEmpty(txtCodigo.Text) ? 0 : Convert.ToInt32(txtCodigo.Text);
                proveedor.PersonaNro = codigoProveedor;
                proveedor.RazonSocial = this.txtRazonSocial.Text.Trim().ToUpper();
                proveedor.Documento = this.txtRUC.Text.Trim();
                DTipoDocumento tipoDocumento = new DTipoDocumento()
                {
                    idTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue),
                    Descripcion = cboTipoDocumento.Text
                };
                proveedor.TipoDocumento = tipoDocumento;
                proveedor.FechaAniversario = dtpFechaAniversario.Checked == false ? (DateTime?)null : dtpFechaAniversario.Value;
                proveedor.CiudadNro = Convert.ToInt32(cboCiudad.SelectedValue) == 0 ? (int?)null : Convert.ToInt32(cboCiudad.SelectedValue);
                proveedor.Direccion = this.txtDireccion.Text.Trim();
                proveedor.Telefono = this.txtTelefono.Text.Trim();
                proveedor.Email = this.txtEmail.Text.Trim();
                proveedor.Observacion = this.txtObservacion.Text.Trim().ToUpper();

                if (this.IsNuevo)
                {
                    rpta = NProveedor.Insertar(proveedor);

                    if (rpta.Equals("OK"))
                        this.MensajeOK("Se ha insertado con exito");
                    else
                    {
                        this.MensajeError(rpta);
                        return;
                    }
                }
                else
                {
                    rpta = NProveedor.Editar(proveedor);

                    if (rpta.Equals("OK"))
                        this.MensajeOK("Se ha editado con exito");
                    else
                    {
                        this.MensajeError(rpta);
                        return;
                    }
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


        private bool ValidacionProveedor()
        {
            errorIcono.Clear();
            if (this.txtRazonSocial.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtRazonSocial, "Ingrese la Razon Social del Proveedor");
                return false;
            }

            if (Convert.ToInt32(cboTipoDocumento.SelectedValue) == 0)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboTipoDocumento, "Seleccione el tipo de documento");
                return false;
            }

            if (this.txtRUC.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtRUC, "Ingrese el Nro de documento");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !ControlesCompartidos.ValidarDireccionCorreo(txtEmail.Text))
            {
                this.MensajeError("Formato incorrecto");
                errorIcono.SetError(txtEmail, "Favor verifique que el formato del correo sea correcto");
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.Habilitar(false);
        }

        private void FrmVistaProveedor_Load(object sender, EventArgs e)
        {
            //top para ubicar en la parte superior
            this.Top = 0;
            //alineado hacia la izquierda
            this.Left = 0;
            this.Habilitar(false);
            this.Botones();
            this.Mostrar();

            rbRUC.CheckedChanged += RadioButton_CheckedChanged;
            rbRazonSocial.CheckedChanged += RadioButton_CheckedChanged;
        }
        

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmCompra frm = FrmCompra.GetInstancia();
            string codigo,documento ,razonsocial;
            codigo = Convert.ToString(dataListado.CurrentRow.Cells["ProveedorNro"].Value);
            razonsocial = Convert.ToString(dataListado.CurrentRow.Cells["RazonSocial"].Value);
            documento = Convert.ToString(dataListado.CurrentRow.Cells["NroDocumento"].Value);

            frm.ObtenerProveedor(codigo, documento,razonsocial);
            this.Hide();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtBuscar.Text))
            {
                this.Mostrar();
            }

            else if (rbRazonSocial.Checked)
            {
                this.BuscarRazonSocial();
            }
            else if (rbRUC.Checked)
            {
                this.BuscarRUC();
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
