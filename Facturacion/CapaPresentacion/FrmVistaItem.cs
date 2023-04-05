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
    public partial class FrmVistaItem : Form
    {

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmVistaItem _Instancia;

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
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns["Codigo"].Visible = false;
            this.dataListado.Columns["PorcentajeIVA"].Visible = false;
            this.dataListado.Columns["CodImpuesto"].Visible = false;
            this.dataListado.Columns["BaseImponible"].Visible = false;
            this.dataListado.Columns["Estado"].Visible = false;
        }






        //PINTAR LAS CELDAS SEGUN EL VALOR DEL STOCK 
        private void StockMenor()
        {
            if(this.cboItem.Text=="Producto") 
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
            if (cboItem.Text=="Producto") 
            {
                dataListado.DataSource = NProducto.MostrarActivo();
                this.OcultarColumnasProducto();
                lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            }else if(cboItem.Text == "Servicio")
            {                
                this.dataListado.DataSource = NServicio.Mostrar();
                this.OcultarColumnasServicio();
                lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            }
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
                if (cboItem.Text == "Producto")
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
            this.cboItem.SelectedIndex = 0;
           
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        { 
        try {
                if (cboItem.Text=="Producto")
                {
                    this.dataListado.Columns["Precio"].DefaultCellStyle.Format = "N0";                    
                    this.dataListado.Columns["PrecioCompra"].DefaultCellStyle.Format = "N0";
                }
                else
                {
                    this.dataListado.Columns["Precio"].DefaultCellStyle.Format = "N0";
                }
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
            if (cboItem.Text == "Producto")
            {
                this.BuscarProducto();
            }
            else
            {
                this.BuscarServicio();
            }
        }
    }
}
