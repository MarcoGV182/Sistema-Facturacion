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
    public partial class FrmUnidadMedida : Form
    {
        bool IsNuevo = false;
        bool IsEditar = false;

        private static FrmUnidadMedida _Instancia;

        public static FrmUnidadMedida GetInstancia() {
            if(_Instancia==null) {
                _Instancia = new FrmUnidadMedida();
            }
            return _Instancia;
        }


        public FrmUnidadMedida()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(txtDescripcion, "Ingrese la Unidad de Medida");
            this.ttMensaje.SetToolTip(txtBuscar, "Teclee para buscar");
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
            this.txtDescripcion.Text = string.Empty;
        }

        //Habilitar botones
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
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

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            this.dataListado.DataSource = NUnidadMedida.Mostrar();
            this.dataListado.Columns["Descripcion"].Width = 100;
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo buscar por descripcion
        private void Buscar()
        {
            this.dataListado.DataSource = NUnidadMedida.BuscarDescripcion(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }



        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void FrmUnidadMedida_Load(object sender, EventArgs e)
        {
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

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked==true)
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
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["UnidadMedidaNro"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);
            //mostrar la segunda pestana la de mantenimiento al hacer doble click
            this.tabControl1.SelectedIndex = 1;
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
                if (this.txtDescripcion.Text == string.Empty)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtDescripcion, "Ingrese la descripcion");
                }
                else
                {
                    //si se ingresa un nuevo registro
                    if (this.IsNuevo)
                    {
                        rpta = NUnidadMedida.Insertar(this.txtDescripcion.Text.Trim().ToUpper());
                        //si se esta editando el registro    
                    }
                    else
                    {
                        rpta = NUnidadMedida.Editar(Convert.ToInt32(this.txtCodigo.Text), this.txtDescripcion.Text.Trim().ToUpper());
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        
           try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Desea eliminar el registro ?", "Sistema de Facturacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    //int contador = 0;
                    string codigo;
                    string rpta = "";
                    //recorrer el datagrip para eliminar mas de un registro
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = NUnidadMedida.Eliminar(Convert.ToInt32(codigo));
                        }

                       /* if (row.Cells[0].Value.Equals(true))//Columna de checks
                        {
                            contador++;
                        }*/
                    }

                    //mensaje a mostrar
                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOK("Se elimino correctamento el registro");
                    }
                    else
                    {
                        this.MensajeError("El registro ya esta definido en Productos" + Environment.NewLine + "(Productos/Unidad de Medida)");
                    }
                    this.Mostrar();
                    chkEliminar.Checked = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void FrmUnidadMedida_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
