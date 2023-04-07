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
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class FrmTipoProducto : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmTipoProducto _Instancia;

        public static FrmTipoProducto GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmTipoProducto();
            }
            return _Instancia;
        }

        public FrmTipoProducto()
        {
           InitializeComponent();
            this.ttMensaje.SetToolTip(txtDescripcion, "Ingrese la descripcion del tipo de Producto");
        }

        //Metodo de mensaje de confirmacion
        private void MensajeOK(string mensaje) {
            MessageBox.Show(mensaje, "Sistema de Facturacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        //Metodo de mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar los controles del formulario
        private void Limpiar() {
            this.txtCodigo.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
        }

        //Habilitar botones
        private void Habilitar(bool valor) {
            this.txtCodigo.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
        }

        //Habilitar Botones
        private void Botones() 
        {
            if(this.IsNuevo || this.IsEditar) {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }else {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }


        //ocultar columnas
        private void OcultarColumnas() {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar() {
            this.dataListado.DataSource = NTipoProducto.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo buscar por descripcion
        private void Buscar()
        {
            if (string.IsNullOrEmpty(txtBuscar.Text))
            {
                Mostrar();
                return;
            }

            this.dataListado.DataSource = NTipoProducto.BuscarDescripcion(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }



        private void FrmTipoProducto_Load(object sender, EventArgs e)
        {
           //si el checkbox eliminar no esta chequeado los otros controles no habilitados
             if (chkEliminar.Checked == false)
            {
                chktodos.Visible = false;
                btnEliminar.Enabled = false;
            }
            //top para ubicar en la parte superior
            this.Top = 0;
            //alineado hacia la izquierda
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtDescripcion.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try 
            {
                string rpta = "";
                if(this.txtDescripcion.Text== string.Empty) 
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtDescripcion, "Ingrese la descripcion");
                }
                else 
                {
                //si se ingresa un nuevo registro
                    if(this.IsNuevo) 
                    {
                        rpta = NTipoProducto.Insertar(this.txtDescripcion.Text.Trim().ToUpper());
                //si se esta editando el registro    
                    }
                    else
                    {
                        rpta = NTipoProducto.Editar(Convert.ToInt32(this.txtCodigo.Text),this.txtDescripcion.Text.Trim().ToUpper());
                    }
                    if(rpta.Equals("OK"))
                    {
                        if(IsNuevo)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["TipoProductoNro"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);
            //mostrar la segunda pestana la de mantenimiento al hacer doble click
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(!this.txtCodigo.Text.Equals(""))
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
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEliminar.Checked) 
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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
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

                if (!ControlesCompartidos.MensajeConfirmacion(this, "Desea eliminar el registro ?"))
                {
                    return;
                }


                string codigo;
                string rpta = "";

                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        codigo = Convert.ToString(row.Cells[1].Value);
                        rpta = NTipoProducto.Eliminar(Convert.ToInt32(codigo));
                    }
                }

                if (rpta.Equals("OK"))
                {
                    this.MensajeOK("Se elimino correctamento el registro");
                }
                else
                {
                    this.MensajeError("El registro ya esta definido en Productos" + Environment.NewLine + "(Productos/Tipo de Producto)");
                }

                this.Mostrar();
                this.chkEliminar.Checked = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FrmTipoProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null; 
        }
    }
}
