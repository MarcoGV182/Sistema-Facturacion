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
using CapaEntidades.Interfaces;
using CapaNegocio;
using CapaPresentacion.Formularios.Facturacion;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace CapaPresentacion.Formularios.ChildForms
{
    public partial class FrmVistaItem : Form
    {

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmVistaItem _Instancia;


        #region Variables de TipoDataGridColumn
        //Articulos
        DataGridViewTextBoxColumn columnTipoProducto;
        DataGridViewTextBoxColumn columnPresentacion;
        DataGridViewTextBoxColumn columnMarca;
        DataGridViewTextBoxColumn columnUnidadMedida;
        DataGridViewTextBoxColumn columnPrecioCompra;

        //Servicio
        DataGridViewTextBoxColumn columnTipoServicioId = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn columnTipoServicioDescripcion= new DataGridViewTextBoxColumn();

        DataGridViewTextBoxColumn columnaId;
        DataGridViewTextBoxColumn columnTipoImpuestoDescripcion;
        DataGridViewTextBoxColumn columnPrecio;

        #endregion

        public static FrmVistaItem GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmVistaItem();
            }

            return _Instancia;
        }

        public FrmVistaItem()
        {
            //ttMensaje.SetToolTip(txtBuscar, "Teclee el item a buscar");
            InitializeComponent();
        }

        private void OcultarColumnasProducto()
        {
            try
            {
                this.dataListado.Columns["ArticuloNro"].Visible = false;
                this.dataListado.Columns["PorcentajeIVA"].Visible = false;
                //this.dataListado.Columns["Divisor"].Visible = false;
                //this.dataListado.Columns["Gravadas"].Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        private void OcultarColumnasServicio()
        {
            /*this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns["Codigo"].Visible = false;
            this.dataListado.Columns["PorcentajeIVA"].Visible = false;
            this.dataListado.Columns["CodImpuesto"].Visible = false;
            this.dataListado.Columns["BaseImponible"].Visible = false;
            this.dataListado.Columns["Estado"].Visible = false;*/
        }






        //PINTAR LAS CELDAS SEGUN EL VALOR DEL STOCK 
        private void StockMenor()
        {
            if(rbProductos.Checked) 
            {
                for (int i = 0; i < dataListado.Rows.Count; i++)
                {
                    int stockactual = Convert.ToInt32(dataListado.Rows[i].Cells["StockActual"].Value);
                    int stockminimo = Convert.ToInt32(dataListado.Rows[i].Cells["stockMinimo"].Value);
                    if (stockactual <= stockminimo)
                    {
                        dataListado.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }
        

        private void DataGridDiseno()
        {
            dataListado.BorderStyle = BorderStyle.None;
            dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataListado.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataListado.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dataListado.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataListado.BackgroundColor = Color.White;

            dataListado.EnableHeadersVisualStyles = false;
            dataListado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataListado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataListado.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {            
            if (rbProductos.Checked) 
            {
                var lstProducto = NProducto.MostrarActivo();
                CrearColumnasDataGridProducto();
                dataListado.DataSource = lstProducto;                
                //OcultarColumnasProducto();
                lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            }else if(rbServicios.Checked)
            {       
                var lstServicio = NServicio.Mostrar();
                CrearColumnasDataGridServicio();
                dataListado.DataSource = lstServicio;              
                OcultarColumnasServicio();
                lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            }
        }

        private void CrearColumnasDataGridProducto()
        {
            dataListado.Columns.Clear();
            dataListado.AutoGenerateColumns = false;

            //Configurar las columnas de Productos
            columnaId = new DataGridViewTextBoxColumn();
            columnaId.DataPropertyName = "ArticuloNro";
            columnaId.HeaderText = "Codigo";
            dataListado.Columns.Add(columnaId);

            DataGridViewTextBoxColumn columnCodBarra = new DataGridViewTextBoxColumn();
            columnCodBarra.DataPropertyName = "CodigoBarra";
            columnCodBarra.HeaderText = "Codigo Barra";
            dataListado.Columns.Add(columnCodBarra);

            DataGridViewTextBoxColumn columnProductoDesc = new DataGridViewTextBoxColumn();
            columnProductoDesc.DataPropertyName = "Descripcion";
            columnProductoDesc.HeaderText = "Producto";
            dataListado.Columns.Add(columnProductoDesc);


            columnTipoProducto = new DataGridViewTextBoxColumn();
            columnTipoProducto.HeaderText = "Tipo Producto";
            dataListado.Columns.Add(columnTipoProducto);

            columnPresentacion = new DataGridViewTextBoxColumn();
            columnPresentacion.HeaderText = "Presentacion";
            dataListado.Columns.Add(columnPresentacion);

            columnUnidadMedida = new DataGridViewTextBoxColumn();
            columnUnidadMedida.HeaderText = "Unidad Medida";
            dataListado.Columns.Add(columnUnidadMedida);

            columnMarca = new DataGridViewTextBoxColumn();
            columnMarca.HeaderText = "Marca";
            dataListado.Columns.Add(columnMarca);

            DataGridViewTextBoxColumn columnFechaVencimiento = new DataGridViewTextBoxColumn();
            columnFechaVencimiento.DataPropertyName = "FechaVencimiento";
            columnFechaVencimiento.HeaderText = "Vencimiento";
            dataListado.Columns.Add(columnFechaVencimiento);

            columnTipoImpuestoDescripcion = new DataGridViewTextBoxColumn();
            columnTipoImpuestoDescripcion.HeaderText = "Tipo Impuesto";
            dataListado.Columns.Add(columnTipoImpuestoDescripcion);

            DataGridViewTextBoxColumn columnStockMinimo = new DataGridViewTextBoxColumn();
            columnStockMinimo.DataPropertyName = "StockMinimo";
            columnStockMinimo.HeaderText = "Stock Minimo";
            dataListado.Columns.Add(columnStockMinimo);

            DataGridViewTextBoxColumn columnStockActual = new DataGridViewTextBoxColumn();
            columnStockActual.DataPropertyName = "StockActual";
            columnStockActual.HeaderText = "Stock Actual";
            dataListado.Columns.Add(columnStockActual);

            columnPrecioCompra = new DataGridViewTextBoxColumn();
            columnPrecioCompra.DataPropertyName = "PrecioCompra";
            columnPrecioCompra.HeaderText = "Precio Compra";
            dataListado.Columns.Add(columnPrecioCompra);

            columnPrecio = new DataGridViewTextBoxColumn();
            columnPrecio.DataPropertyName = "PrecioVenta";
            columnPrecio.HeaderText = "Precio Venta";
            dataListado.Columns.Add(columnPrecio);

            DataGridViewTextBoxColumn columnEstado = new DataGridViewTextBoxColumn();
            columnEstado.DataPropertyName = "Estado";
            columnEstado.HeaderText = "Estado";
            dataListado.Columns.Add(columnEstado);

            DataGridViewTextBoxColumn columnObs = new DataGridViewTextBoxColumn();
            columnObs.DataPropertyName = "Observacion";
            columnObs.HeaderText = "Observacion";
            dataListado.Columns.Add(columnObs);
        }

        private void CrearColumnasDataGridServicio()
        {
            dataListado.Columns.Clear();
            dataListado.AutoGenerateColumns = false;

            //Configurar las columnas de servicios
            columnaId = new DataGridViewTextBoxColumn();
            columnaId.DataPropertyName = "ArticuloNro";
            columnaId.HeaderText = "Codigo";
            dataListado.Columns.Add(columnaId);

            DataGridViewTextBoxColumn columnDescripcion = new DataGridViewTextBoxColumn();
            columnDescripcion.DataPropertyName = "Descripcion";
            columnDescripcion.HeaderText = "Servicio";
            dataListado.Columns.Add(columnDescripcion);


            columnTipoServicioDescripcion = new DataGridViewTextBoxColumn();
            columnTipoServicioDescripcion.HeaderText = "TipoServicio";
            dataListado.Columns.Add(columnTipoServicioDescripcion);
            

            columnTipoImpuestoDescripcion = new DataGridViewTextBoxColumn();
            columnTipoImpuestoDescripcion.HeaderText = "Impuesto";
            dataListado.Columns.Add(columnTipoImpuestoDescripcion);

            columnPrecio = new DataGridViewTextBoxColumn();
            columnPrecio.DataPropertyName = "Precio";
            columnPrecio.HeaderText = "Precio";
            dataListado.Columns.Add(columnPrecio);

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
        }
        private void BuscarProducto()
        {
           this.dataListado.DataSource = NProducto.BuscarProductoActivo(this.txtBuscar.Text);
           this.OcultarColumnasProducto();
           lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);  
       }

        private void BuscarServicio() {
            this.dataListado.DataSource = NServicio.BuscarServicio(this.txtBuscar.Text);
            this.OcultarColumnasServicio();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }
                
        
        private void FrmVistaItem_FormClosing(object sender, FormClosingEventArgs e)
        {
        //al cerrar el formulario se inicializa la instancia en null
            _Instancia = null;
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //Al hacer doble Click sobre un producto o servicio se cargan en el formulario Ventas los siguiente datos
                FrmFacturaVenta frm = FrmFacturaVenta.GetInstancia();
                DataTable dtdescuento = new DataTable();
                string des = string.Empty;

                string codigo, descripcion, unidadmedida, tipoImpuesto;
                int stock,codImpuesto;
                double precio,preciocompra;
                decimal porcentajeIVA, baseImponible, comision;
                if (rbProductos.Checked)
                {
                    codigo = Convert.ToString(dataListado.CurrentRow.Cells["ArticuloNro"].Value);
                    descripcion = Convert.ToString(dataListado.CurrentRow.Cells["Producto"].Value);
                    unidadmedida = Convert.ToString(dataListado.CurrentRow.Cells["UnidadMedida"].Value);
                    precio = Convert.ToInt64(dataListado.CurrentRow.Cells["Precio"].Value);
                    codImpuesto = Convert.ToInt32(dataListado.CurrentRow.Cells["CodImpuesto"].Value);
                    tipoImpuesto = Convert.ToString(dataListado.CurrentRow.Cells["tipoImpuesto"].Value);
                    porcentajeIVA = Convert.ToDecimal(dataListado.CurrentRow.Cells["PorcentajeIva"].Value);
                    baseImponible = Convert.ToDecimal(dataListado.CurrentRow.Cells["baseImponible"].Value);

                    stock = Convert.ToInt32(dataListado.CurrentRow.Cells["StockActual"].Value);
                    preciocompra = Convert.ToInt64(dataListado.CurrentRow.Cells["precioCompra"].Value);

                    frm.ObtenerProducto(codigo, descripcion, precio, preciocompra, codImpuesto, tipoImpuesto,stock);
                    this.Hide();
                }
                else
                {
                    codigo = Convert.ToString(dataListado.CurrentRow.Cells["Codigo"].Value);
                    descripcion = Convert.ToString(dataListado.CurrentRow.Cells["Servicio"].Value);
                    precio = Convert.ToDouble(dataListado.CurrentRow.Cells["Precio"].Value);
                    codImpuesto = Convert.ToInt32(dataListado.CurrentRow.Cells["CodImpuesto"].Value);
                    tipoImpuesto = Convert.ToString(dataListado.CurrentRow.Cells["tipoImpuesto"].Value);
                    porcentajeIVA = Convert.ToDecimal(dataListado.CurrentRow.Cells["PorcentajeIva"].Value);
                    baseImponible = Convert.ToDecimal(dataListado.CurrentRow.Cells["baseImponible"].Value);
                    //comision = Convert.ToDecimal(dataListado.CurrentRow.Cells["PorcentajeComision"].Value);
                    comision = 0;
                    frm.ObtenerServicio(codigo, descripcion, precio, codImpuesto, tipoImpuesto, comision);                    
                    this.Hide();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

       
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Mostrar();
            this.StockMenor();
          
        }
                

        private void FrmVistaItem_Load(object sender, EventArgs e)
        {            
            //llamar al metodo para cambiar el estilo del datagridview
            this.DataGridDiseno();
            Top = 100;
            Left = 50;
            //valor por defecto del comboitem
            this.lblTotal.Text = "Total de registros: 0";

            //Inicializar radioButtons
            rbProductos.Checked = true;
            rbServicios.Checked = false;

            Mostrar();

            rbProductos.CheckedChanged += RadioButton_CheckedChanged;
            rbServicios.CheckedChanged += RadioButton_CheckedChanged;


        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        { 
        try {
                if (rbProductos.Checked)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex == columnTipoProducto.Index)
                    {
                        var fila = dataListado.Rows[e.RowIndex];
                        if (fila.DataBoundItem != null)
                        {
                            var producto = (EProducto)fila.DataBoundItem;
                            e.Value = producto.TipoProducto?.Descripcion;
                        }
                    }
                    if (e.RowIndex >= 0 && e.ColumnIndex == columnPresentacion.Index)
                    {
                        var fila = dataListado.Rows[e.RowIndex];
                        if (fila.DataBoundItem != null)
                        {
                            var producto = (EProducto)fila.DataBoundItem;
                            e.Value = producto.Presentacion?.Descripcion;
                        }
                    }                   
                    if (e.RowIndex >= 0 && e.ColumnIndex == columnMarca.Index)
                    {
                        var fila = dataListado.Rows[e.RowIndex];
                        if (fila.DataBoundItem != null)
                        {
                            var producto = (EProducto)fila.DataBoundItem;
                            e.Value = producto.Marca?.Descripcion;
                        }
                    }
                    if (e.RowIndex >= 0 && e.ColumnIndex == columnUnidadMedida.Index)
                    {
                        var fila = dataListado.Rows[e.RowIndex];
                        if (fila.DataBoundItem != null)
                        {
                            var producto = (EProducto)fila.DataBoundItem;
                            e.Value = producto.UnidadMedida?.Descripcion;
                        }
                    }

                    columnPrecioCompra.DefaultCellStyle.Format = "N0";
                }
                else
                {
                    
                    if (e.RowIndex >= 0 && e.ColumnIndex == columnTipoServicioDescripcion.Index)
                    {
                        var fila = dataListado.Rows[e.RowIndex];
                        if (fila.DataBoundItem != null)
                        {
                            var servicio = (EServicio)fila.DataBoundItem;
                            e.Value = servicio.TipoServicio?.Descripcion;
                        }
                    }                    
                }

                
                if (e.RowIndex >= 0 && e.ColumnIndex == columnTipoImpuestoDescripcion.Index)
                {
                    var fila = dataListado.Rows[e.RowIndex];
                    if (fila.DataBoundItem != null)
                    {
                        var servicio = (IArticulo)fila.DataBoundItem;
                        e.Value = servicio.TipoImpuesto?.Descripcion;
                    }
                }
                if (e.RowIndex >= 0 && e.ColumnIndex == columnPrecio.Index)
                {
                    e.CellStyle.Format = "N0";
                };
            } catch(Exception)
            {
                //MessageBox.Show(ex.Message); 
            }
        
        }

        private void dataListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
               
        }

        private void cboItem_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataListado.CurrentCell = null;
            this.Mostrar();
            this.StockMenor();
        }

        private void dataListado_Leave(object sender, EventArgs e)
        {
            this.dataListado.ClearSelection();
        }

        private void dataListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                dataListado_DoubleClick(null, null);
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (rbProductos.Checked)
            {
                this.BuscarProducto();
            }
            else
            {
                this.BuscarServicio();
            }
        }


        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton radioButton = sender as System.Windows.Forms.RadioButton;
            if (radioButton.Checked)
            {
                Mostrar();
                // Desmarca los otros RadioButton
                foreach (System.Windows.Forms.RadioButton otherRadioButton in groupBox1.Controls.OfType<System.Windows.Forms.RadioButton>().Where(rb => rb != radioButton))
                {
                    otherRadioButton.Checked = false;
                }
            }
        }
    }
}
