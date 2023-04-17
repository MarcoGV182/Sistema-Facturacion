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
    public partial class FrmConsultaCompra : Form
    {
        public FrmConsultaCompra()
        {
            InitializeComponent();
        }

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmConsultaCompra _Instancia;
        public static FrmConsultaCompra GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmConsultaCompra();
            }
            return _Instancia;
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


        public void CompraAnulada()
        {
            for (int i = 0; i < dataListado.Rows.Count; i++)
            {
                String estado = Convert.ToString(dataListado.Rows[i].Cells["Estado"].Value);
                if (estado.Equals("ANULADO"))
                {
                    dataListado.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }


        //ocultar columnas
        private void OcultarColumnas()
        {
            if (dataListado.Rows.Count == 0)
                return;

            try
            {
                this.dataListado.Columns[0].Visible = false;
                this.dataListado.Columns[1].Visible = false;
                this.dataListado.Columns[3].Visible = false;
                this.dataListado.Columns[9].Visible = false;
            }
            catch (Exception)
            {
            }
        }


        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            this.dataListado.DataSource = NCompra.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

        }


        //Metodo para mostrar los datos en el datagrid
        private void MostrarCompraAnulada()
        {
            this.dataListado.DataSource = NCompra.MostrarAnulada();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Metodo buscar por fechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NCompra.BuscarCompraFecha(this.dtpFechadesde.Value.ToString("yyyy-MM-dd"), dtpfechahasta.Value.ToString("yyyy-MM-dd"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void FrmConsultaCompra_Load(object sender, EventArgs e)
        {
            DataGridDiseno();
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
        }
        
        private void dataListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            this.CompraAnulada();
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataListado.Columns["Gravada"].DefaultCellStyle.Format = "N0";
            this.dataListado.Columns["Iva"].DefaultCellStyle.Format = "N0";
            this.dataListado.Columns["Total"].DefaultCellStyle.Format = "N0";
        }

        private void FrmConsultaCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmImpresionCompras frm = new FrmImpresionCompras();
            frm.ShowDialog();
        }

        private void btnCredito_Click(object sender, EventArgs e)
        {
            try
            {
                dataListado.CurrentCell = null;
                foreach (DataGridViewRow r in dataListado.Rows)
                {
                    if (r.Cells["TipoPago"].Value.ToString() == "CREDITO")
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

        private void btnContado_Click(object sender, EventArgs e)
        {
            try
            {
                dataListado.CurrentCell = null;
                foreach (DataGridViewRow r in dataListado.Rows)
                {
                    if (r.Cells["TipoPago"].Value.ToString() == "CONTADO")
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

        private void btnCancelado_Click(object sender, EventArgs e)
        {
            try
            {
                dataListado.CurrentCell = null;
                foreach (DataGridViewRow r in dataListado.Rows)
                {
                    if (r.Cells["Estado"].Value.ToString() == "ANULADO")
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

        private void btnEmitido_Click(object sender, EventArgs e)
        {
            try
            {
                dataListado.CurrentCell = null;
                foreach (DataGridViewRow r in dataListado.Rows)
                {
                    if (r.Cells["Estado"].Value.ToString() == "EMITIDO")
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
