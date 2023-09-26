using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Formularios;
using CapaPresentacion.Formularios.Facturacion;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion.Formularios.ChildForms
{
    public partial class FrmVistaProducto : Form
    {

        private bool IsNuevo = false;


        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmVistaProducto _Instancia;

        public static FrmVistaProducto GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmVistaProducto();
            }

            return _Instancia;
        }
        public FrmVistaProducto()
        {
            InitializeComponent();
            LlenarCombos();
        }

        private void StockMenor()
        {
            for (int i = 0; i < dataListado.Rows.Count; i++)
            {
                int stockactual = Convert.ToInt32(dataListado.Rows[i].Cells["StockActual"].Value);
                int stockminimo = Convert.ToInt32(dataListado.Rows[i].Cells["stockMinimo"].Value);
                if (stockactual <= stockminimo)
                {
                    dataListado.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }

            }
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
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtStockMinimo.Value = 0;
            this.txtStockActual.Text = string.Empty;
        }

        private void LlenarCombos()
        {
            //llenar combo Marca    
            cboMarca.DataSource = NMarca.Mostrar();
            cboMarca.DisplayMember = "Descripcion";
            cboMarca.ValueMember = "MarcaNro";
            //llenar combo Tipo de Producto    
            cboTipoProducto.DataSource = NTipoProducto.Mostrar();
            cboTipoProducto.DisplayMember = "Descripcion";
            cboTipoProducto.ValueMember = "TipoProductoNro";
            //llenar combo Unidad de Medida  
            cboUnidadMedida.DataSource = NUnidadMedida.Mostrar();
            cboUnidadMedida.DisplayMember = "Descripcion";
            cboUnidadMedida.ValueMember = "UnidadMedidaNro";
            //llenar combo Presentacion 
            cboPresentacion.DataSource = NPresentacion.Mostrar();
            cboPresentacion.DisplayMember = "Descripcion";
            cboPresentacion.ValueMember = "idPresentacion";
            //llenar combo Impuesto
            cboImpuesto.DataSource = NTipoImpuesto.Mostrar();
            cboImpuesto.DisplayMember = "Descripcion";
            cboImpuesto.ValueMember = "TipoImpuestoNro";

        }

        //Habilitar botones
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
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
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[9].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[11].Visible = false;
            this.dataListado.Columns["PorcentajeIVA"].Visible = false;
        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            this.dataListado.DataSource = NProducto.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            this.txtCodigo.Visible = false;
        }

        //Metodo buscar por descripcion
        private void Buscar()
        {
            if (string.IsNullOrEmpty(txtBuscar.Text) || string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                this.Mostrar();
                return;
            }

            this.dataListado.DataSource = NProducto.BuscarProducto(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void FrmVistaProducto_Load(object sender, EventArgs e)
        {
            DataGridDiseno();
            //top para ubicar en la parte superior
            this.Top = 100;
            //alineado hacia la izquierda
            this.Left = 50;
            this.Habilitar(false);
            this.Botones();
            this.Mostrar();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NuevoRegistro();
        }

        private void NuevoRegistro() 
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.cboEstado.SelectedIndex = 0;
            this.txtDescripcion.Focus();
            this.txtCodigo.Visible = false;

        }

        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (!ControlesCompartidos.MensajeConfirmacion(this, "¿Desea guardar el registro?"))
                    return;

                if (!Validaciones())
                {
                    return;
                }


                //si se ingresa un nuevo registro
                EProducto producto = new EProducto();

                producto.Descripcion = this.txtDescripcion.Text.Trim().ToUpper();
                producto.TipoProducto = new ETipoProducto() 
                { 
                    TipoProductoNro = Convert.ToInt32(cboTipoProducto.SelectedValue)
                };
                producto.CodigoBarra = txtCodigoBarra.Text;
                producto.UnidadMedida = new EUnidadMedida()
                {
                    UnidadMedidaNro = Convert.ToInt32(cboUnidadMedida.SelectedValue),
                    Descripcion = cboUnidadMedida.Text.Trim()
                };
                producto.FechaVencimiento = dtpFechaVto.Checked ? dtpFechaVto.Value : (DateTime?)null;
                producto.Presentacion = new EPresentacionProducto() 
                { 
                    IdPresentacion = Convert.ToInt32(cboPresentacion.SelectedValue)
                };
                producto.Marca = new EMarca() 
                { 
                    MarcaNro = Convert.ToInt32(cboMarca.SelectedValue)
                };
                producto.StockActual = 0;//Convert.ToInt32(this.txtStockActual.Text);
                producto.Stockminimo = Convert.ToInt32(this.txtStockMinimo.Value);
                producto.PrecioCompra = Convert.ToDouble(this.txtPrecioCompra.Text);
                producto.Precio = Convert.ToDouble(this.txtPrecioVenta.Text);
                producto.TipoImpuesto = new ETipoImpuesto()
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


                if (rpta.Equals("OK"))
                {
                    if (IsNuevo)
                    {
                        this.MensajeOK("Se ha insertado con exito");
                        this.errorIcono.Clear();
                    }                    
                }
                else
                {
                    this.MensajeError(rpta);
                    return;
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


        private bool Validaciones()
        {
            if (this.txtDescripcion.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtDescripcion, "Ingrese la descripcion");
                return false;
            }

            if (this.txtStockActual.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtStockActual, "Ingrese el Stock del producto");
                return false;
            }

            if (this.cboEstado.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboEstado, "Seleccione el Estado del Producto");
                return false;
            }

            if (this.txtPrecioVenta.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtPrecioVenta, "Ingrese el Precio Minorista del Producto");
                return false;
            }

            if (this.cboMarca.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboMarca, "Seleccione la Marca del Producto");
                return false;
            }

            if (this.cboPresentacion.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboPresentacion, "Seleccione la Presentacion del Producto");
                return false;
            }

            if (this.cboTipoProducto.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboTipoProducto, "Seleccione el Tipo de Producto");
                return false;
            }

            if (this.cboUnidadMedida.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboUnidadMedida, "Seleccione la Unidad de Medida del Producto");
                return false;
            }


            return true;
        }
        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.Habilitar(false);            
        }
        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataListado.CurrentRow == null)
                    return;

                FrmCompra frm = FrmCompra.GetInstancia();
                EProducto producto = new EProducto()
                {
                    ArticuloNro = Convert.ToInt32(dataListado.CurrentRow.Cells["ArticuloNro"].Value),
                    Descripcion = Convert.ToString(dataListado.CurrentRow.Cells["Producto"].Value),
                    UnidadMedida = new EUnidadMedida()
                    {
                        UnidadMedidaNro = Convert.ToInt32(dataListado.CurrentRow.Cells["UnidadMedidaNro"].Value),
                        Descripcion = dataListado.CurrentRow.Cells["UnidadMedida"].Value.ToString()
                    },
                    PrecioCompra = Convert.ToInt64(dataListado.CurrentRow.Cells["precioCompra"].Value),
                    Precio = Convert.ToDouble(dataListado.CurrentRow.Cells["Precio"].Value),
                    TipoImpuesto = new ETipoImpuesto()
                    {
                        TipoImpuestoNro = Convert.ToInt32(dataListado.CurrentRow.Cells["CodImpuesto"].Value),
                        Descripcion = Convert.ToString(dataListado.CurrentRow.Cells["tipoImpuesto"].Value),
                        PorcentajeIva = Convert.ToDecimal(dataListado.CurrentRow.Cells["PorcentajeIva"].Value),
                        BaseImponible = Convert.ToDecimal(dataListado.CurrentRow.Cells["baseImponible"].Value)
                    },
                    StockActual = Convert.ToInt32(dataListado.CurrentRow.Cells["StockActual"].Value)

                };

                frm.ObtenerProducto(producto);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  
                
            }           
        }

        private void dataListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            StockMenor();
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            LlenarCombos();
        }
    }
}
