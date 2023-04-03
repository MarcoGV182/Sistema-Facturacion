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
    public partial class FrmTipoAjuste : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmTipoAjuste _Instancia;
        public static FrmTipoAjuste GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmTipoAjuste();
            }
            return _Instancia;
        }


        public FrmTipoAjuste()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(txtDescripcion, "Por favor ingrese la descripcion del servicio");
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
            this.dataListado.DataSource = NTipoAjuste.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo buscar por descripcion
        private void Buscar()
        {
            this.dataListado.DataSource = NTipoAjuste.Buscar(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmTipoAjuste_Load(object sender, EventArgs e)
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
            this.cbotipo.SelectedIndex = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult opcion;
                opcion = MessageBox.Show("Desea eliminar el registro ?", "Sistema de Facturacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    string codigo;
                    string rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = NTipoAjuste.Eliminar(Convert.ToInt32(codigo));
                            this.MensajeError(rpta);
                        }
                    }

                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOK("Se elimino correctamento el registro");
                    }
                    else
                    {
                        this.MensajeError("El registro ya esta definido en Ajuste");
                    }

                    this.Mostrar();
                    this.chkEliminar.Checked = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {

            if (chkEliminar.Checked)
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
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["TipoAjusteNro"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);
            this.cbotipo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["PositivoNegativo"].Value);
            //mostrar la segunda pestana la de mantenimiento al hacer doble click
            this.tabControl1.SelectedIndex = 1;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
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
                        rpta = NTipoAjuste.Insertar(this.txtDescripcion.Text.Trim().ToUpper(),this.cbotipo.Text);
                        //si se esta editando el registro    
                    }
                    else
                    {
                        rpta = NTipoAjuste.Editar(Convert.ToInt32(this.txtCodigo.Text), this.txtDescripcion.Text.Trim().ToUpper(),this.cbotipo.Text);
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
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
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

        private void FrmTipoAjuste_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
