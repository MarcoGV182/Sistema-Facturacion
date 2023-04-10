using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
using CapaPresentacion.DsReporteTableAdapters;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class FrmProveedor : Form
    {

        bool IsNuevo = false;
        bool IsEditar = false;


        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmProveedor _Instancia;
        public static FrmProveedor GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmProveedor();
            }
            return _Instancia;
        }
        public FrmProveedor()
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
            this.txtRazonSocial.Text = string.Empty;
            this.txtRUC.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtObservacion.Text = string.Empty;
            this.cboCiudad.SelectedIndex = 0;
            this.cboEstado.SelectedIndex = 0;
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
            this.txtObservacion.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.cboTipoDocumento.Enabled = valor;
            this.cboCiudad.Enabled = valor;
            this.cboEstado.Enabled = valor;
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
            this.dataListado.Columns[3].Visible = false;
            this.dataListado.Columns[6].Visible = false;
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
            this.dataListado.DataSource = NProveedor.BuscarProveedor("RS", this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarRUC()
        {
            this.dataListado.DataSource = NProveedor.BuscarProveedor("R",this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            //inicializar combo de busqueda
            rbRUC.Checked = true;
            rbRazonSocial.Checked = false;

            if (chkEliminar.Checked == false)
            {
                chktodos.Visible = false;
                btnEliminar.Enabled = false;
            }
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
                proveedor.Estado = this.cboEstado.Text;
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

            string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, emailRegex))
            {
                this.MensajeError("Formato incorrecto");
                errorIcono.SetError(txtEmail, "Favor verifique que el formato del correo sea correcto");
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validar que se haya selecciona al menos un registro
                int x = dataListado.Rows.Cast<DataGridViewRow>()
                              .Where(r => Convert.ToBoolean(r.Cells[0].Value))
                              .Count();
                if (x == 0)
                {
                    MensajeError("No ha seleccionado ningun item");
                    return;
                }

                DialogResult opcion;
                opcion = MessageBox.Show("Desea eliminar el registro ?", "Sistema de Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.No)
                    return;

                string codigo;
                string rpta = "";
                //recorrer el datagrip para eliminar mas de un registro
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        codigo = Convert.ToString(row.Cells["ProveedorNro"].Value);
                        rpta = NProveedor.Eliminar(Convert.ToInt32(codigo));

                        if (!rpta.Equals("OK"))
                        {                          
                            break;
                        }
                    }
                }

                //mensaje a mostrar
                if (rpta.Equals("OK") && x == 1)
                {
                    this.MensajeOK("Se elimino correctamento el registro");
                }

                if (rpta.Equals("OK") && x > 1)
                {
                    this.MensajeOK($"Se eliminaron correctamento la cantidad de {x} registros ");
                }

                if (!rpta.Equals("OK"))
                {
                    this.MensajeError($"Ocurrio un error: {rpta}");
                }


                this.Mostrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked == true)
            {
                btnEliminar.Enabled = true;
                chktodos.Visible = true;
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                chktodos.Checked = false;
                btnEliminar.Enabled = false;
                chktodos.Visible = false;
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void chktodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chktodos.Checked == true)
            {
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    row.Cells["Eliminar"].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    row.Cells["Eliminar"].Value = false;
                }
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminarDV = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];

                chkEliminarDV.Value = !Convert.ToBoolean(chkEliminarDV.Value);

            }
        }       

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProveedorNro"].Value);
            this.txtRazonSocial.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["RazonSocial"].Value);
            this.txtRUC.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NroDocumento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Email"].Value);
            this.cboTipoDocumento.SelectedValue = Convert.ToInt32(this.dataListado.CurrentRow.Cells["idTipoDocumento"].Value);
            this.cboCiudad.SelectedValue = Convert.ToInt32(this.dataListado.CurrentRow.Cells["CiudadNro"].Value);
            if (!Convert.IsDBNull(this.dataListado.CurrentRow.Cells["FechaAniversario"].Value))
            {
                this.dtpFechaAniversario.Checked = true;
                this.dtpFechaAniversario.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["FechaAniversario"].Value);
            }
            else
            {
                this.dtpFechaAniversario.Checked = false;
            }
            this.cboEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value);
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
    }
}
