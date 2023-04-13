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
    public partial class FrmVistaProductoAjuste : Form
    {
        

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmVistaProductoAjuste _Instancia;

        public static FrmVistaProductoAjuste GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmVistaProductoAjuste();
            }

            return _Instancia;
        }
        public FrmVistaProductoAjuste()
        {
            InitializeComponent();
           
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

       
       

        //ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns["ArticuloNro"].Visible = false;
            this.dataListado.Columns["PorcentajeIVA"].Visible = false;
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
            this.dataListado.DataSource = NProducto.BuscarProducto(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void FrmVistaProducto_Load(object sender, EventArgs e)
        {
            DataGridDiseno();
            //top para ubicar en la parte superior
            this.Top = 0;
            //alineado hacia la izquierda
            this.Left = 0;            
            this.Mostrar();
        }

       


       

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }        

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            StockMenor();
        }

        private void dataListado_DoubleClick_1(object sender, EventArgs e)
        {
            FrmAjusteStock frm = FrmAjusteStock.GetInstancia();
            string id, descripcion, precio, stock;
            id = Convert.ToString(dataListado.CurrentRow.Cells["ArticuloNro"].Value);
            descripcion = Convert.ToString(dataListado.CurrentRow.Cells["Producto"].Value);
            precio = Convert.ToString(dataListado.CurrentRow.Cells["PrecioCompra"].Value);
            stock = Convert.ToString(dataListado.CurrentRow.Cells["StockActual"].Value);

            frm.ObtenerProducto(id, descripcion, precio, stock);
            this.Hide();
        }

        private void FrmVistaProductoAjuste_Load(object sender, EventArgs e)
        {
            DataGridDiseno();
            Top = 100;
            Left = 50;
               
            this.Mostrar();
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void dataListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            StockMenor();
        }

        private void dataListado_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dataListado.Columns["Precio"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception)
            {
                throw;
            }
            
            
        }

      
    }
}
