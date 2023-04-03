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
    public partial class FrmConsultaCaja : Form
    {

    //DECLARACION DE VARIABLES
        public string id;
        public string usuario;
        public string nombre;
        public string apellido;
        public string acceso;

        private double ingreso = 0;
        private double egreso = 0;

        //ATRIBUTOS CAJA
        private string Usuariocaja ="";
        private string FechaApertura="";
        private string FechaCierre="";
        private decimal ImporteApertura;
        private decimal ImporteEntrega;
        private decimal SaldoFinal;
        private decimal DiferenciaCierre;
        private string Estado="";





        private static FrmConsultaCaja _Instancia;

        public static FrmConsultaCaja GetInstancia() 
        { 
            if(_Instancia==null) 
            {
                _Instancia = new FrmConsultaCaja();
            }
            return _Instancia;
        }


        //MOSTRAR LABEL DE SIN REGISTROS
        private void SinRegistros()
        {
            if (dataResumenCaja.Rows.Count <= 0)
            {
                lblSinRegistros.Visible = true;
            }
            else
            {
                lblSinRegistros.Visible = false;
            }
        }



        public FrmConsultaCaja()
        {
            InitializeComponent();
        }

        //Metodo buscar por fechas
        private void BuscarCajaPorFecha()
        {
            this.dataResumenCaja.DataSource = NCaja.FitroResumenCaja(this.dtpDesde.Value.ToString("dd-MM-yyyy"), dtpHasta.Value.ToString("dd-MM-yyyy"));
            //this.OcultarColumnas();
            this.SinRegistros();

        }

        private void TotalesMovimiento()
        {
            try
            {
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
                    this.txtingreso.Text = ingreso.ToString();
                    this.txtegreso.Text = egreso.ToString();
                }

                this.txtDiferencia.Text = (Convert.ToDouble(txtingreso.Text) - Convert.ToDouble(txtegreso.Text)).ToString("N0");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void MovimientoDePagos()
        {
            //INSTANCIAMOS UN DATABLE
            DataTable mov = new DataTable();

            //SE CARGA EN EL DATABLE EL METODO
            mov = NCaja.BuscarMovimientoPagosCaja(this.dataResumenCaja.CurrentRow.Cells["FechaApertura"].Value.ToString(), this.dataResumenCaja.CurrentRow.Cells["FechaCierre"].Value.ToString());

            //PASA LOS DATOS DEL DATATABLE A LOS TEXTBOX
            txtEfectivo.Text = mov.Rows[0]["PagoEfectivo"] != DBNull.Value ? Convert.ToDouble(mov.Rows[0]["PagoEfectivo"]).ToString("N0") : "0";
            txtCheque.Text = mov.Rows[0]["PagoCheque"] != DBNull.Value ? Convert.ToDouble(mov.Rows[0]["PagoCheque"]).ToString("N0") : "0";
            txtTarjeta.Text = mov.Rows[0]["PagoTarjeta"] != DBNull.Value ? Convert.ToDouble(mov.Rows[0]["PagoTarjeta"]).ToString("N0") : "0";
            //lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            //this.TotalesMovimientoPagos();
        }




        //MOSTRAR MOVIMIENTO POR FECHA/CAJA
        private void BuscarMovimientoFechaCaja()
        {
            this.txtingreso.Text = 0.ToString();
            this.txtegreso.Text = 0.ToString();
            this.dataListado.DataSource = NMovimiento.BuscarFechaMovimientoCaja(this.dataResumenCaja.CurrentRow.Cells["FechaApertura"].Value.ToString(), this.dataResumenCaja.CurrentRow.Cells["FechaCierre"].Value.ToString());
            //lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            this.TotalesMovimiento();
           
        }


        private void ColorOperacionMovimiento()
        {
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {

        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarCajaPorFecha();
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataListado.Columns["Importe"].DefaultCellStyle.Format = "N0";
        }

        private void dataListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            this.ColorOperacionMovimiento();
        }

        private void btnVerMovimientos_Click(object sender, EventArgs e)
        {
            try
            {
                //CargarVariables
                this.Usuariocaja = this.dataResumenCaja.CurrentRow.Cells["Usuario"].Value.ToString();
                this.FechaApertura = this.dataResumenCaja.CurrentRow.Cells["FechaApertura"].Value.ToString();
                this.FechaCierre = this.dataResumenCaja.CurrentRow.Cells["FechaCierre"].Value.ToString();
                this.ImporteApertura = Convert.ToDecimal(this.dataResumenCaja.CurrentRow.Cells["ImporteApert"].Value.ToString());
                this.ImporteEntrega = Convert.ToDecimal(this.dataResumenCaja.CurrentRow.Cells["Entrega"].Value.ToString());
                this.SaldoFinal = Convert.ToDecimal(this.dataResumenCaja.CurrentRow.Cells["Saldo"].Value.ToString());
                this.DiferenciaCierre = Convert.ToDecimal(this.dataResumenCaja.CurrentRow.Cells["Diferencia"].Value.ToString());
                this.Estado = this.dataResumenCaja.CurrentRow.Cells["Estado"].Value.ToString();


                this.BuscarMovimientoFechaCaja();
                this.MovimientoDePagos();
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione un registro", "CAJA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dataListado.DataSource = null;
            }
            
        }

        private void FrmConsultaCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void dataResumenCaja_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataResumenCaja.Columns["ImporteApert"].DefaultCellStyle.Format = "N0";
            this.dataResumenCaja.Columns["Entrega"].DefaultCellStyle.Format = "N0";
            this.dataResumenCaja.Columns["Saldo"].DefaultCellStyle.Format = "N0";
            this.dataResumenCaja.Columns["Diferencia"].DefaultCellStyle.Format = "N0";
        }

        private void FrmConsultaCaja_Load(object sender, EventArgs e)
        {
            //top para ubicar en la parte superior
            this.Top = 0;
            //alineado hacia la izquierda
            this.Left = 0;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataListado.Rows.Count>0)
                {
                    FrmInformeMovimientoCaja frm = new FrmInformeMovimientoCaja();
                    frm.Usuario = Usuariocaja;
                    frm.FechaApertura = FechaApertura;
                    frm.FechaCierre = FechaCierre;
                    frm.ImporteApertura = ImporteApertura;
                    frm.ImporteEntrega = ImporteEntrega;
                    frm.DiferenciaCierre = DiferenciaCierre;
                    frm.SaldoFinal = SaldoFinal;
                    frm.Estado = Estado;
                    frm.Efectivo =Convert.ToDecimal(this.txtEfectivo.Text);
                    frm.tarjeta= Convert.ToDecimal(this.txtTarjeta.Text);
                    frm.Cheque= Convert.ToDecimal(this.txtCheque.Text);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Seleccione un registro", "CAJA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
