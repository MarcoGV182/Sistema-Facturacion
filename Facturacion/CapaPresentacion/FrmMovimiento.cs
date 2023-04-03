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
    public partial class FrmMovimiento : Form
    {

        private double ingreso=0;
        private double egreso=0;

        private static FrmMovimiento _Instancia;


        public static FrmMovimiento GetInstancia() {
            if(_Instancia==null) {
                _Instancia= new FrmMovimiento();
            }
            return _Instancia;
        }



        public FrmMovimiento()
        {
            InitializeComponent();
            
        }

        private void OcultarColumnas()
        {

            //this.dataListado.Columns["MovimientoNro"].Visible= false;
       }

        private void TotalesMovimiento() {
            if (dataListado.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (row.Cells["TipoOperacion"].Value.ToString() == "INGRESO")
                    {
                        ingreso += Convert.ToDouble(row.Cells["Importe"].Value);
                        txtingreso.Text = ingreso.ToString("N0");
                       
                    }
                    else if (row.Cells["TipoOperacion"].Value.ToString() == "EGRESO")
                    {
                        egreso += Convert.ToDouble(row.Cells["Importe"].Value);
                        txtegreso.Text = egreso.ToString("N0");                       
                    }                   
                }
                ingreso = 0;
                egreso = 0;
            }
            else 
            {
                ingreso = 0;
                egreso = 0;
                this.txtingreso.Text= ingreso.ToString();
                this.txtegreso.Text = egreso.ToString();               
            }

            txtdiferencia.Text = (Convert.ToDouble(txtingreso.Text) - Convert.ToDouble(txtegreso.Text)).ToString("N0");
        }



        private void GridDiseno()
        {
            dataListado.BorderStyle = BorderStyle.None;
            dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataListado.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataListado.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataListado.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataListado.BackgroundColor = Color.White;

            dataListado.EnableHeadersVisualStyles = false;
            dataListado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataListado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataListado.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }






        private void Mostrar() {

            this.dataListado.DataSource = NMovimiento.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            this.TotalesMovimiento();
        }

        private void BuscarFechas()
        {
            this.dataListado.DataSource = NMovimiento.BuscarFechaMovimiento(this.dtpDesde.Value.ToString("dd-MM-yyyy HH:mm"), dtpHasta.Value.ToString("dd-MM-yyyy HH:mm"));
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            this.TotalesMovimiento();
        }

        private void FrmMovimiento_Load(object sender, EventArgs e)
        {
            this.GridDiseno();
            this.Mostrar();            
            this.txtegreso.ReadOnly=true;
            this.txtingreso.ReadOnly=true;
            //top para ubicar en la parte superior
            this.Top = 0;
            //alineado hacia la izquierda
            this.Left = 0;

        }

        private void FrmMovimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia=null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.txtingreso.Text = 0.ToString();
            this.txtegreso.Text = 0.ToString();
            this.BuscarFechas();
        }



        private void Movimiento()
        {
            try {
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (row.Cells["TipoOperacion"].Value.ToString() == "INGRESO")
                    {
                        row.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else 
                    {
                        row.DefaultCellStyle.ForeColor = Color.Green;
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
      }
      

        private void dataListado_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            this.Movimiento();
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataListado.Columns["Importe"].DefaultCellStyle.Format = "N0";
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            this.txtingreso.Text = 0.ToString();
            this.txtegreso.Text = 0.ToString();
            this.Mostrar();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                dataListado.CurrentCell = null;
                foreach (DataGridViewRow r in dataListado.Rows)
                {
                    if (r.Cells["TipoOperacion"].Value.ToString() == "INGRESO")
                    {
                        r.Visible = true;
                    }
                    else
                    {
                        r.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnEgreso_Click(object sender, EventArgs e)
        {
            try
            {
                dataListado.CurrentCell = null;
                foreach (DataGridViewRow r in dataListado.Rows)
                {
                    if (r.Cells["TipoOperacion"].Value.ToString()=="EGRESO")
                    {
                        r.Visible = true;
                    }
                    else
                    {
                        r.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
