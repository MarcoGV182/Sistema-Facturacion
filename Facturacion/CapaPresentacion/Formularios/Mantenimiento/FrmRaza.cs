using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
using CapaPresentacion;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion.Formularios.Mantenimiento
{
    public partial class FrmRaza : Form
    {
        public int idUsuario;
        public string Acceso;

        private bool IsNuevo = false;
        private bool IsEditar = false;
        List<NRaza> listaRaza = new List<NRaza>();

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmRaza _Instancia;

        public static FrmRaza GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmRaza();
            }
            return _Instancia;
        }
        public FrmRaza()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(txtDescripcion, "Ingrese la descripcion de la Marca");
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
            try
            {
                
                if (dataListado.Rows.Count > 0) 
                {
                    this.dataListado.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            listaRaza = NRaza.MostrarListaRaza();
            this.dataListado.DataSource = listaRaza;

            this.OcultarColumnas();
            lblTotal.Text = "Total de registros " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo buscar por descripcion
        private void Buscar()
        {
            var filtro = listaRaza.Where(c => c.Descripcion.ToUpper().Contains(txtBuscar.Text.ToUpper())).ToList();
            this.dataListado.DataSource = filtro;
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmMarca_Load(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
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
                        rpta = NRaza.Eliminar(Convert.ToInt32(codigo));

                        if (!rpta.Equals("OK"))
                        {
                            MensajeError(rpta);
                            return;
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
                this.chkEliminar.Checked = false;


               
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
                chktodos.Visible = true;
                btnEliminar.Enabled = true;
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                chktodos.Checked = false;
                chktodos.Visible = false;
                btnEliminar.Enabled = false;
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
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
                    return;
                }

                //si se ingresa un nuevo registro
                if (this.IsNuevo)
                {
                    rpta = NRaza.Insertar(this.txtDescripcion.Text.Trim());
                    //si se esta editando el registro    
                }
                else
                {
                    DRaza marca = new DRaza();
                    marca.Id = Convert.ToInt32(this.txtCodigo.Text);
                    marca.Descripcion = this.txtDescripcion.Text.Trim();
                    rpta = NRaza.Editar(marca);
                }


                if (rpta.Equals("OK"))
                {
                    if (IsNuevo)
                    {
                        this.MensajeOK("El registro se ha insertado con éxito");
                    }
                    else
                    {
                        this.MensajeOK("El registro se ha editado con éxito");
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
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if (dataListado.CurrentRow == null)
            {
                return;
            }
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);
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

        private void FrmMarca_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
