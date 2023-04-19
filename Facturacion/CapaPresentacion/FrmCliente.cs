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
using CapaPresentacion.DsReporteTableAdapters;
using CapaPresentacion.Utilidades;
using System.Data.SqlTypes;
using System.Windows;

namespace CapaPresentacion
{
    public partial class FrmCliente : Form
    {

        bool IsNuevo = false;
        bool IsEditar = false;

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmCliente _Instancia;

        public static FrmCliente GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmCliente();
            }
            return _Instancia;
        }


        public FrmCliente()
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


        private void MedidaColumna(DataGridView dg)
        {
            dg.Columns["Nombre"].Width = 150;
            dg.Columns["Apellido"].Width = 150;
            dg.Columns["Direccion"].Width = 100;
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
            this.txtObservacion.Text = string.Empty;

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
            this.txtObservacion.ReadOnly = !valor;
            this.cboCiudad.Enabled = valor;
            this.dtpFechaNac.Enabled = valor;
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
            try
            {
                if (dataListado.ColumnCount > 0)
                {
                    this.dataListado.Columns[0].Visible = false;
                    this.dataListado.Columns[1].Visible = false;
                }
            }
            catch (Exception)
            {

            }
            
               

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
        public void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();            
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


        //Metodo buscar por Apellidoo
        private void BuscarApellido()
        {
            this.dataListado.DataSource = NCliente.BuscarApellido(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        //METODO PARA BUSCAR POR DOCUMENTO
        private void BuscarDocumento()
        {
            this.dataListado.DataSource = NCliente.BuscarDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }
       

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            DataGridDiseno();
            //inicializar combo de busqueda
            cboBuscar.SelectedIndex = 0;
           
            if (chkEliminar.Checked == false)
            {
                chktodos.Visible = false;
                btnEliminar.Enabled = false;
            }

            dtpFechaNac.Checked = false;

            //top para ubicar en la parte superior
            this.Top = 0;
            //alineado hacia la izquierda
            this.Left = 0;
            //this.Habilitar(false);
            this.Botones();
            this.Mostrar();
            this.MedidaColumna(dataListado);
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


            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !ControlesCompartidos.ValidarDireccionCorreo(txtEmail.Text))
            {
                this.MensajeError("Formato incorrecto");
                errorIcono.SetError(txtEmail, "Favor verifique que el formato del correo sea correcto");
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

                if (this.IsNuevo)
                {
                    rpta = NCliente.Insertar(cliente);

                    if (rpta.Equals("OK"))
                        this.MensajeOK("Se ha insertado con exito");
                    else
                        this.MensajeError(rpta);
                }
                else
                {                    
                    rpta = NCliente.Editar(cliente);

                    if (rpta.Equals("OK"))
                        this.MensajeOK("Se ha editado con exito");
                    else
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

                //int contador = 0;
                string codigo;
                string rpta = "";
                //recorrer el datagrip para eliminar mas de un registro
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        codigo = Convert.ToString(row.Cells["PersonaNro"].Value);
                        rpta = NCliente.Eliminar(Convert.ToInt32(codigo));

                        if (!rpta.Equals("OK"))
                        {
                            MensajeError(rpta);
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

                if (!rpta.Equals("OK") )
                {
                    this.MensajeError($"Ocurrio un error: {rpta}" );                    
                }


                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            

            this.chkEliminar.Checked = false;
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
          try {
                this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["PersonaNro"].Value);
                this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
                this.txtApellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido"].Value);
                this.txtDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Documento"].Value);
                this.dtpFechaNac.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["fechaNacimiento"].Value);
                this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);
                this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);
                this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Email"].Value);
                this.cboCiudad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Ciudad"].Value);
                this.txtObservacion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Observacion"].Value);
             } 
             catch(Exception ex) {
                MessageBox.Show(ex.Message);
             }
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if(this.txtBuscar.Text==string.Empty) 
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void FrmCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
