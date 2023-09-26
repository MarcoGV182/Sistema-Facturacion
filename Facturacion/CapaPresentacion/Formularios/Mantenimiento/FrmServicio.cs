using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaPresentacion
{
    public partial class FrmServicio : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;
        private List<EServicio> listServicio = new List<EServicio>();

        private static FrmServicio _Instancia;
        public static FrmServicio _GetInstancia() {
            if (_Instancia == null) 
            {
                _Instancia = new FrmServicio();
            }
            return _Instancia;
        }

        public FrmServicio()
        {
            InitializeComponent();
            LlenarCombos();
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
            this.txtPrecio.Text = string.Empty;            
            this.txtObservacion.Text = string.Empty;
        }

        private void CrearColumnasDataGrid() 
        {
            dataListado.AutoGenerateColumns = false;

            //Configurar las columnas de servicios
            DataGridViewTextBoxColumn columnaId = new DataGridViewTextBoxColumn();
            columnaId.DataPropertyName = "ServicioNro";
            columnaId.HeaderText = "Codigo";
            dataListado.Columns.Add(columnaId);

            DataGridViewTextBoxColumn columnDescripcion = new DataGridViewTextBoxColumn();
            columnDescripcion.DataPropertyName = "Descripcion";
            columnDescripcion.HeaderText = "Servicio";
            dataListado.Columns.Add(columnDescripcion);

            DataGridViewTextBoxColumn TipoServicioId = new DataGridViewTextBoxColumn();
            TipoServicioId.DataPropertyName = "TipoServicio.TipoServicioNro";
            TipoServicioId.HeaderText = "TipoServicioNro";
            dataListado.Columns.Add(TipoServicioId);


            DataGridViewTextBoxColumn TipoServicioDescripcion = new DataGridViewTextBoxColumn();
            TipoServicioDescripcion.DataPropertyName = "TipoServicio.Descripcion";
            TipoServicioDescripcion.HeaderText = "TipoServicio";
            dataListado.Columns.Add(TipoServicioDescripcion);

            DataGridViewTextBoxColumn TipoImpuestoId = new DataGridViewTextBoxColumn();
            TipoImpuestoId.DataPropertyName = "TipoImpuesto.TipoImpuestoNro";
            TipoImpuestoId.HeaderText = "TipoImpuestoNro";
            dataListado.Columns.Add(TipoImpuestoId);

            DataGridViewTextBoxColumn TipoImpuestoDescripcion = new DataGridViewTextBoxColumn();
            TipoImpuestoDescripcion.DataPropertyName = "TipoImpuesto.Descripcion";
            TipoImpuestoDescripcion.HeaderText = "Impuesto";
            dataListado.Columns.Add(TipoImpuestoDescripcion);

            DataGridViewTextBoxColumn Precio = new DataGridViewTextBoxColumn();
            Precio.DataPropertyName = "Precio";
            Precio.HeaderText = "Precio";
            dataListado.Columns.Add(Precio);

            DataGridViewTextBoxColumn Estado = new DataGridViewTextBoxColumn();
            Estado.DataPropertyName = "Estado";
            Estado.HeaderText = "Estado";
            dataListado.Columns.Add(Estado);

            DataGridViewTextBoxColumn Observacion = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Observacion",
                HeaderText = "Observacion"
            };
            dataListado.Columns.Add(Observacion);

            DataGridViewTextBoxColumn FechaRegistro = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FechaRegistro",
                HeaderText = "FechaRegistro"
            };
            dataListado.Columns.Add(FechaRegistro);

            #region Formato
            dataListado.CellFormatting += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == TipoServicioId.Index)
                {
                    var fila = dataListado.Rows[e.RowIndex];
                    if (fila.DataBoundItem != null)
                    {
                        var servicio = (EServicio)fila.DataBoundItem;
                        e.Value = servicio.TipoServicio?.TipoServicioNro;
                    }
                }
                if (e.RowIndex >= 0 && e.ColumnIndex == TipoServicioDescripcion.Index)
                {
                    var fila = dataListado.Rows[e.RowIndex];
                    if (fila.DataBoundItem != null)
                    {
                        var servicio = (EServicio)fila.DataBoundItem;
                        e.Value = servicio.TipoServicio?.Descripcion;
                    }
                }
                if (e.RowIndex >= 0 && e.ColumnIndex == TipoImpuestoId.Index)
                {
                    var fila = dataListado.Rows[e.RowIndex];
                    if (fila.DataBoundItem != null)
                    {
                        var servicio = (EServicio)fila.DataBoundItem;
                        e.Value = servicio.TipoImpuesto?.TipoImpuestoNro;
                    }
                }
                if (e.RowIndex >= 0 && e.ColumnIndex == TipoImpuestoDescripcion.Index)
                {
                    var fila = dataListado.Rows[e.RowIndex];
                    if (fila.DataBoundItem != null)
                    {
                        var servicio = (EServicio)fila.DataBoundItem;
                        e.Value = servicio.TipoImpuesto?.Descripcion;
                    }
                }
                if (e.RowIndex >= 0 && e.ColumnIndex == Precio.Index)
                {
                    e.CellStyle.Format = "N0";
                };
            };
            #endregion
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
            //dg.Columns["Servicio"].Width = 180;
           
        }





        private void LlenarCombos()
        {

            cboTipoServicio.DataSource = ControlesCompartidos.AgregarNuevaFila(NTipoServicio.Mostrar(),"Descripcion", "TipoServicioNro");
            cboTipoServicio.DisplayMember = "Descripcion";
            cboTipoServicio.ValueMember = "TipoServicioNro";

            //llenar combo Impuesto
            cboImpuesto.DataSource = ControlesCompartidos.AgregarNuevaFila(NTipoImpuesto.Mostrar(), "Descripcion", "TipoImpuestoNro");
            cboImpuesto.DisplayMember = "Descripcion";
            cboImpuesto.ValueMember = "TipoImpuestoNro";

        }

       

        //Habilitar botones
        private void Habilitar(bool valor)
        {  
            this.txtCodigo.ReadOnly = true;
            this.txtDescripcion.ReadOnly = !valor;            
            this.txtPrecio.ReadOnly = !valor;
            this.cboEstado.Enabled = valor;
            this.cboImpuesto.Enabled = valor;
            this.cboTipoServicio.Enabled = valor;
            this.txtObservacion.ReadOnly = !valor;
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
            this.dataListado.Columns[3].Visible = false;
            this.dataListado.Columns[5].Visible = false;
        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            listServicio = NServicio.Mostrar();
            dataListado.DataSource = listServicio;
            OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);            
        }

        //Metodo buscar por descripcion
        private void Buscar()
        {
            if (string.IsNullOrEmpty(txtBuscar.Text))
            {
                this.Mostrar();
                return;
            }
            listServicio = NServicio.BuscarServicio(this.txtBuscar.Text);
            dataListado.DataSource = listServicio;
            OcultarColumnas();
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
            this.cboImpuesto.SelectedIndex = 0;
            this.txtDescripcion.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (!Validaciones())
                    return;

                if (!ControlesCompartidos.MensajeConfirmacion(this, "¿Desea guardar el registro?"))
                    return;


                EServicio servicio = new EServicio()
                {                    
                    Descripcion = this.txtDescripcion.Text.Trim().ToUpper(),
                    TipoServicioNro = Convert.ToInt32(cboTipoServicio.SelectedValue),
                    TipoImpuestoNro = Convert.ToInt32(cboImpuesto.SelectedValue),
                    Precio = Convert.ToDouble(this.txtPrecio.Text),
                    Estado = this.cboEstado.Text,                    
                    Observacion = this.txtObservacion.Text
                };

                //si se ingresa un nuevo registro
                if (this.IsNuevo)
                {
                    rpta = NServicio.Insertar(servicio);
                    //si se esta editando el registro    
                }
                else
                {
                    servicio.ArticuloNro = Convert.ToInt32(this.txtCodigo.Text);
                    rpta = NServicio.Editar(servicio);
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


        private bool Validaciones() 
        {
            errorIcono.Clear();
            if (this.txtDescripcion.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtDescripcion, "Ingrese la Descripcion");
                return false;
            }

            if (this.cboEstado.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboEstado, "Seleccione el Estado del Servicio");
                return false;
            }

            if (this.cboTipoServicio.Text == string.Empty || Convert.ToInt32(cboTipoServicio.SelectedValue) == 0)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboTipoServicio, "Seleccione el Tipo del Servicio");
                return false;
            }


            if (this.cboImpuesto.Text == string.Empty || Convert.ToInt32(cboImpuesto.SelectedValue) == 0)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboImpuesto, "Seleccione el Tipo de IVA del Servicio");
                return false;
            }

            if (this.txtPrecio.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtPrecio, "Ingrese el precio");
                return false;
            }

            errorIcono.Clear();
            return true;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ControlesCompartidos.MensajeConfirmacion(this,"¿Desea editar el registro?"))
            {
                return;
            }

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
            tabControl1.SelectedIndex = 0;
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
            try
            {
                var servicio = dataListado.CurrentRow.DataBoundItem as EServicio;


                this.txtCodigo.Text = servicio.ArticuloNro.ToString();
                this.txtDescripcion.Text = servicio.Descripcion.ToString();
                this.txtObservacion.Text = servicio.Observacion.ToString();
                this.txtPrecio.Text = servicio.Precio.ToString("N0");
                this.cboImpuesto.SelectedValue = servicio.TipoImpuesto.TipoImpuestoNro;
                this.cboTipoServicio.SelectedValue = servicio.TipoServicio.TipoServicioNro;
                this.cboEstado.Text = servicio.Estado;
                this.Botones();

                //mostrar la segunda pestana la de mantenimiento al hacer doble click
                this.tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                throw ex;
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
                        codigo = Convert.ToString(row.Cells[1].Value);
                        rpta = NServicio.Eliminar(Convert.ToInt32(codigo));

                        if (!rpta.Equals("OK"))
                            MensajeError(rpta);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        
        private void FrmServicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null; 
        }

        private void FrmServicio_Load(object sender, EventArgs e)
        {
            CrearColumnasDataGrid();
            DataGridDiseno();
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
            this.MedidaColumna(dataListado);
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //this.dataListado.Columns["Precio"].DefaultCellStyle.Format = "N0";
        }
    }
}
