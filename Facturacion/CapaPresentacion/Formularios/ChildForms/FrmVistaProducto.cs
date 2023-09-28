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
using CapaPresentacion.Formularios.Inventario;

namespace CapaPresentacion.Formularios.ChildForms
{
    public partial class FrmVistaProducto : Form
    {
        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmVistaProducto _Instancia;
        public EProducto ProductoSeleccionado;

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
            CrearColumnasDataGridProducto();
        }

        private void StockMenor()
        {
            for (int i = 0; i < dataListado.Rows.Count; i++)
            {
                var ArticuloItem = dataListado.Rows[i].DataBoundItem as EProducto;
                int stockactual = ArticuloItem.StockActual;
                int stockminimo = ArticuloItem.Stockminimo;
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

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            var ListaArticulo = NProducto.Mostrar();
            this.dataListado.DataSource = ListaArticulo;
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void CrearColumnasDataGridProducto()
        {
            dataListado.Columns.Clear();
            dataListado.AutoGenerateColumns = false;

            //Configurar las columnas de Productos
            DataGridViewTextBoxColumn columnaId = new DataGridViewTextBoxColumn();
            columnaId.DataPropertyName = "ArticuloNro";
            columnaId.Name = "ArticuloNro";
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

            DataGridViewTextBoxColumn columnStockMinimo = new DataGridViewTextBoxColumn();
            columnStockMinimo.DataPropertyName = "StockMinimo";
            columnStockMinimo.HeaderText = "Stock Minimo";
            dataListado.Columns.Add(columnStockMinimo);

            DataGridViewTextBoxColumn columnStockActual = new DataGridViewTextBoxColumn();
            columnStockActual.DataPropertyName = "StockActual";
            columnStockActual.HeaderText = "Stock Actual";
            dataListado.Columns.Add(columnStockActual);

            DataGridViewTextBoxColumn columnMarca = new DataGridViewTextBoxColumn();
            columnMarca.HeaderText = "Marca";
            dataListado.Columns.Add(columnMarca);

            DataGridViewTextBoxColumn columnFechaVencimiento = new DataGridViewTextBoxColumn();
            columnFechaVencimiento.DataPropertyName = "FechaVencimiento";
            columnFechaVencimiento.HeaderText = "Vencimiento";
            dataListado.Columns.Add(columnFechaVencimiento);

            DataGridViewTextBoxColumn columnTipoImpuestoDescripcion = new DataGridViewTextBoxColumn();
            columnTipoImpuestoDescripcion.HeaderText = "Tipo Impuesto";
            dataListado.Columns.Add(columnTipoImpuestoDescripcion);
                      

            DataGridViewTextBoxColumn columnPrecioCompra = new DataGridViewTextBoxColumn();
            columnPrecioCompra.DataPropertyName = "PrecioCompra";
            columnPrecioCompra.HeaderText = "Precio Compra";
            dataListado.Columns.Add(columnPrecioCompra);

            DataGridViewTextBoxColumn columnPrecio = new DataGridViewTextBoxColumn();
            columnPrecio.DataPropertyName = "Precio";
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

            #region Formato
            dataListado.CellFormatting += (sender, e) =>
            {                
                if (e.RowIndex >= 0 && e.ColumnIndex == columnTipoImpuestoDescripcion.Index)
                {
                    var fila = dataListado.Rows[e.RowIndex];
                    if (fila.DataBoundItem != null)
                    {
                        var producto = (EProducto)fila.DataBoundItem;
                        e.Value = producto.TipoImpuesto?.Descripcion;
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

                columnPrecioCompra.DefaultCellStyle.Format = "N0";
                columnPrecio.DefaultCellStyle.Format = "N0";
            };
            #endregion

            DataGridDiseno();
        }

        //Metodo buscar por descripcion
        private void Buscar()
        {
            var ListaArticulos = NProducto.BuscarProducto(this.txtBuscar.Text);
            this.dataListado.DataSource = ListaArticulos;
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void FrmVistaProducto_Load(object sender, EventArgs e)
        {   
            //top para ubicar en la parte superior
            Top = 0;
            //alineado hacia la izquierda
            Left = 0;            
            Mostrar();
        }

       

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }    

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            StockMenor();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            /*FrmAjusteStock frm = FrmAjusteStock.GetInstancia();
            string id, descripcion, precio, stock;
            var ArticuloSeleccionado = dataListado.CurrentRow.DataBoundItem as EProducto;
            id = Convert.ToString(ArticuloSeleccionado.ArticuloNro);
            descripcion = Convert.ToString(ArticuloSeleccionado.Descripcion);
            precio = Convert.ToString(ArticuloSeleccionado.PrecioCompra);
            stock = Convert.ToString(ArticuloSeleccionado.StockActual);*/
            ProductoSeleccionado = dataListado.CurrentRow.DataBoundItem as EProducto;

            //frm.ObtenerProducto(id, descripcion, precio, stock);
            this.Close();
        }

        private void FrmVistaProductoAjuste_Load(object sender, EventArgs e)
        {         
            Top = 100;
            Left = 50;
               
            Mostrar();
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dataListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            StockMenor();
        }
    }
}
