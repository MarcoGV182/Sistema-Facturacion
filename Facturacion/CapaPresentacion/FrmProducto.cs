using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class FrmProducto : Form
    {
        FrmCargandoForm frmCargando = new FrmCargandoForm();

        public string[] reglas;
        public string usuario;
            
        private bool IsNuevo = false;
        private bool IsEditar = false;
        //int id = 0;


        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmProducto _Instancia;

        public static FrmProducto GetInstancia() 
        {
            if(_Instancia==null) 
            {
                _Instancia = new FrmProducto();
            }
           
            return _Instancia;
        }

        
        public FrmProducto()
        {
            InitializeComponent();
            LlenarCombos();
        }
        //Solo numero en los textbox
        public void SoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }            
            else
            {
                e.Handled = true;
            }
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

        private void StockMenor() {
            for(int i=0; i < dataListado.Rows.Count; i++) {
                int stockactual = Convert.ToInt32(dataListado.Rows[i].Cells["StockActual"].Value);
                int stockminimo= Convert.ToInt32(dataListado.Rows[i].Cells["stockMinimo"].Value);
                if (stockactual <= stockminimo) {
                    dataListado.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                 }
            
            }
        }


        //Limpiar los controles del formulario
        private void Limpiar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtCodigoBarra.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtStockMinimo.Value = 0;
            this.txtStockActual.Text = string.Empty;
            this.txtObservacion.Text = string.Empty;


            //Iniciliar los combobox
            cboEstado.SelectedIndex = 0;
            cboImpuesto.SelectedIndex = 0;
            cboMarca.SelectedIndex = 0;
            cboPresentacion.SelectedIndex = 0;
            cboTipoProducto.SelectedIndex = 0;
            cboUnidadMedida.SelectedIndex = 0;
              
        }

        private void LlenarCombos() {
            //llenar combo Marca    
            cboMarca.DataSource = ControlesCompartidos.AgregarNuevaFila(NMarca.Mostrar(), "Descripcion", "MarcaNro");
            cboMarca.DisplayMember = "Descripcion";
            cboMarca.ValueMember = "MarcaNro";
            //llenar combo Tipo de Producto    
            cboTipoProducto.DataSource = ControlesCompartidos.AgregarNuevaFila(NTipoProducto.Mostrar(), "Descripcion", "TipoProductoNro");
            cboTipoProducto.DisplayMember = "Descripcion";
            cboTipoProducto.ValueMember = "TipoProductoNro";
            //llenar combo Unidad de Medida  
            cboUnidadMedida.DataSource = ControlesCompartidos.AgregarNuevaFila(NUnidadMedida.Mostrar(), "Descripcion", "UnidadMedidaNro");
            cboUnidadMedida.DisplayMember = "Descripcion";
            cboUnidadMedida.ValueMember = "UnidadMedidaNro";
            //llenar combo Presentacion 
            cboPresentacion.DataSource = ControlesCompartidos.AgregarNuevaFila(NPresentacion.Mostrar(), "Descripcion", "idPresentacion");
            cboPresentacion.DisplayMember = "Descripcion";
            cboPresentacion.ValueMember = "idPresentacion";
            //llenar combo Impuesto
            cboImpuesto.DataSource = ControlesCompartidos.AgregarNuevaFila(NTipoImpuesto.Mostrar(), "Descripcion", "TipoImpuestoNro");
            cboImpuesto.DisplayMember = "Descripcion";
            cboImpuesto.ValueMember = "TipoImpuestoNro";

        }

        //Habilitar botones
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtCodigoBarra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.txtStockMinimo.Enabled = valor;
            this.txtStockActual.ReadOnly = !valor;
            this.cboEstado.Enabled = valor;
            this.cboMarca.Enabled = valor;
            this.cboTipoProducto.Enabled = valor;
            this.cboUnidadMedida.Enabled = valor;
            this.cboPresentacion.Enabled = valor;
            this.cboImpuesto.Enabled = valor;
            this.txtObservacion.ReadOnly = !valor;
            this.dtpFechaVto.Enabled = valor;
            this.txtPrecioCompra.ReadOnly = true;

            //Solo en el alta del producto se deja cargar el primer precio de compra
            if (IsEditar)
                this.txtPrecioCompra.ReadOnly = true;
            else if (IsNuevo)
            {
                this.txtPrecioCompra.ReadOnly = false;
            }
                

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
                this.btnCancelar.Enabled = true;
            }
        }

        //ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[6].Visible = false;//UnidadMedidaNro
            this.dataListado.Columns[11].Visible = false;//CodImpuesto
            this.dataListado.Columns[12].Visible = false;//PorcentajeIVA
            this.dataListado.Columns[13].Visible = false;//BaseImponible
        }


        private void MedidaColumna(DataGridView dg) 
        {
            dg.Columns["ArticuloNro"].Width = 60;
            dg.Columns["Producto"].Width = 180;
            dg.Columns["Presentacion"].Width = 100;
            dg.Columns["UnidadMedida"].Width = 100;
            dg.Columns["Marca"].Width = 100;
            dg.Columns["TipoImpuesto"].Width = 80;
            dg.Columns["Estado"].Width = 50;
            dg.Columns["Observacion"].Width = 200;
            //CENTRAR TEXTO EN LA COLUMNA
            dg.Columns["ArticuloNro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns["StockActual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns["StockMinimo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;            
            dg.Columns["PrecioCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
        }



        //Metodo para mostrar los datos en el datagrid
        private async void Mostrar()
        {            
            this.dataListado.DataSource = await NProducto.Mostrar();
            this.OcultarColumnas();
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


            this.dataListado.DataSource = NProducto.BuscarProducto(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void DataGridDiseno() {
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
       

        private async void FrmProducto_Load(object sender, EventArgs e)
        {
            CargasIniciales();

        }

        private void CargasIniciales() 
        {
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

        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.cboEstado.SelectedIndex = 0;
            this.txtCodigoBarra.Focus();
            this.txtCodigo.Visible = true;
            this.txtStockActual.Enabled = true;             
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (!ControlesCompartidos.MensajeConfirmacion(this,"¿Desea guardar el registro?"))
                    return;

                if (!Validaciones())
                {
                    return;
                }


                //si se ingresa un nuevo registro
                DProducto producto = new DProducto();
                
                producto.Descripcion = this.txtDescripcion.Text.Trim().ToUpper();
                producto.TipoProductoNro = Convert.ToInt32(cboTipoProducto.SelectedValue);
                producto.CodigoBarra = txtCodigoBarra.Text;
                producto.UnidadMedida = new DUnidadMedida()
                {
                    UnidadMedidaNro = Convert.ToInt32(cboUnidadMedida.SelectedValue),
                    Descripcion = cboUnidadMedida.Text.Trim()
                };
                producto.FechaVencimiento = dtpFechaVto.Checked ? dtpFechaVto.Value : (DateTime?)null;
                producto.IdPresentacion = Convert.ToInt32(cboPresentacion.SelectedValue);
                producto.MarcaNro = Convert.ToInt32(cboMarca.SelectedValue);
                producto.StockActual = 0;//Convert.ToInt32(this.txtStockActual.Text);
                producto.Stockminimo = Convert.ToInt32(this.txtStockMinimo.Value);
                producto.PrecioCompra = Convert.ToDecimal(this.txtPrecioCompra.Text);
                producto.Precio = Convert.ToDecimal(this.txtPrecioVenta.Text);
                producto.TipoImpuesto = new DTipoImpuesto()
                {
                    TipoImpuestoNro = Convert.ToInt32(this.cboImpuesto.SelectedValue),
                    Descripcion = this.cboImpuesto.Text
                };
                producto.Observacion = this.txtObservacion.Text;
                producto.Estado = this.cboEstado.Text;



                if (this.IsNuevo)
                {
                    rpta = NProducto.Insertar(producto);
                }
                else
                {
                    producto.ProductoNro = Convert.ToInt32(this.txtCodigo.Text);
                    rpta = NProducto.Editar(producto);
                }


                if (rpta.Equals("OK"))
                {
                    if (IsNuevo)
                    {
                        this.MensajeOK("Se ha insertado con exito");
                        this.errorIcono.Clear();
                    }
                    else
                    {
                        this.MensajeOK("Se ha editado con exito");
                        this.errorIcono.Clear();
                    }
                }
                else
                {
                    this.MensajeError(rpta);
                    return;
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
                errorIcono.SetError(txtDescripcion, "Ingrese la descripcion");
                return false;
            }
        

            if (this.cboTipoProducto.Text == string.Empty || Convert.ToInt32(cboTipoProducto.SelectedValue) == 0)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboTipoProducto, "Seleccione el Tipo de Producto");
                return false;
            }

            if (this.cboPresentacion.Text == string.Empty || Convert.ToInt32(cboPresentacion.SelectedValue) == 0)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboPresentacion, "Seleccione la Presentacion del Producto");
                return false;
            }

            if (this.cboUnidadMedida.Text == string.Empty || Convert.ToInt32(cboUnidadMedida.SelectedValue) == 0)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboUnidadMedida, "Seleccione la Unidad de Medida del Producto");
                return false;
            }

            if (this.cboMarca.Text == string.Empty || Convert.ToInt32(cboMarca.SelectedValue) == 0)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboMarca, "Seleccione la Marca del Producto");
                return false;
            }


            if (this.cboEstado.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboEstado, "Seleccione el Estado del Producto");
                return false;
            }

            if (this.cboImpuesto.Text == string.Empty || Convert.ToInt32(cboImpuesto.SelectedValue) == 0)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboImpuesto, "Seleccione el Tipo de Impuesto del Producto");
                return false;
            }

            if (this.txtPrecioVenta.Text == string.Empty || Convert.ToInt32(txtPrecioVenta.Text) <=0)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtPrecioVenta, "Ingrese el Precio de Venta del Producto");
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
                this.txtStockActual.Enabled = false;
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
            this.txtStockActual.Enabled = true;
            tabProducto.SelectedIndex=0;
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
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ArticuloNro"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Producto"].Value);
            this.txtCodigoBarra.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CodigoBarra"].Value);
            this.txtPrecioCompra.Text = Convert.ToDouble(this.dataListado.CurrentRow.Cells["PrecioCompra"].Value).ToString("N0");           
            this.txtPrecioVenta.Text = Convert.ToDouble(this.dataListado.CurrentRow.Cells["Precio"].Value).ToString("N0");
            this.txtStockActual.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["StockActual"].Value);
            this.txtStockMinimo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["StockMinimo"].Value);
            this.txtObservacion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Observacion"].Value);
            this.cboMarca.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Marca"].Value);
            this.cboPresentacion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Presentacion"].Value);
            this.cboTipoProducto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["TipoProducto"].Value);
            this.cboUnidadMedida.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["UnidadMedida"].Value);
            this.cboEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value);
            this.cboImpuesto.SelectedValue = Convert.ToInt32(this.dataListado.CurrentRow.Cells["CodImpuesto"].Value);
            if (string.IsNullOrEmpty(this.dataListado.CurrentRow.Cells["FechaVencimiento"].Value.ToString())) 
            {
                dtpFechaVto.Checked = false;
            }   
            else
            {
                this.dtpFechaVto.Value =  Convert.ToDateTime(this.dataListado.CurrentRow.Cells["FechaVencimiento"].Value);
            }
            
            this.lblCodigo.Visible = true;
            this.txtCodigo.Visible = true;
            this.Botones();

            //mostrar la segunda pestana la de mantenimiento al hacer doble click
            this.tabProducto.SelectedIndex = 1;
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
                        rpta = NProducto.Eliminar(Convert.ToInt32(codigo));

                        if (!rpta.Equals("OK"))
                        {
                            MensajeError(rpta);
                            break;
                        }
                    }
                }

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

                this.chkEliminar.Checked = false;
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {            
            this.Buscar();
        }

        private void FrmProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        
        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataListado.Columns["PrecioCompra"].DefaultCellStyle.Format = "N0";
            this.dataListado.Columns["Precio"].DefaultCellStyle.Format = "N0";
        }

        private void dataListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            StockMenor();
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtPrecioMinorista_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtPrecioMayorista_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtStockActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmInformeProducto frm = new FrmInformeProducto();
            frm.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecioCompra_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioCompra.Text == string.Empty) 
            {
                txtPrecioCompra.Text = "0" ; 

            }
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtPrecioMinorista_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioVenta.Text == string.Empty)
            {
                txtPrecioVenta.Text = "0";

            }

        }
    }
 }
    
