using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmCierreCaja : Form
    {

        //atributos para obtener al usuario
        public string id;
        public string usuario;
        public string nombre;
        public string apellido;
        public string acceso;

        private double ingreso = 0;
        private double egreso = 0;

        double montoApertura = 0;
        int nroArqueo = 0;

        private static FrmCierreCaja _Instancia;
        public static FrmCierreCaja GetInstancia() 
        { 
            if(_Instancia==null) 
            {
                _Instancia = new FrmCierreCaja();
            }
            return _Instancia;
        }
        

        public FrmCierreCaja()
        {
            InitializeComponent();
            this.txtImporteEntrega.Focus();
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


        private void CalcularDiferenciaCaja() 
        {
            try
            {
                this.txtDiferenciaSaldo.Text = (Convert.ToDouble(txtImporteEntrega.Text) - Convert.ToDouble(txtSaldoActual.Text)).ToString("N0");
            }
            catch (Exception)
            {
                this.txtImporteEntrega.Text = "0";
            }
        }

        public void ObtenerDatosCaja(int codigo) 
        {
            //string monto ="";
            try 
            {  
                DataTable dt = NCaja.MostrarCajaAbierta(Convert.ToInt32(codigo));
                if(dt.Rows.Count==0) 
                {
                    MensajeError($"No existe Arqueo de Caja abierta para el usuario: {usuario}");
                    this.txtSaldoActual.Text = 0.ToString();
                    this.btnCerrar.Enabled = false;
                    return;
                }
                else 
                {
                    this.txtfechaApertura.Text =Convert.ToDateTime(dt.Rows[0]["FechaApertura"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    montoApertura = Convert.ToDouble(dt.Rows[0]["ImporteApertura"]);
                    this.txtMontoInicial.Text = montoApertura.ToString("N0");
                    nroArqueo = Convert.ToInt32(dt.Rows[0]["CajaNro"]);
                    this.lblnrocaja.Text = nroArqueo.ToString();
                    this.btnCerrar.Enabled = true;
                }
                
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
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
                    this.txtSaldoActual.Text = 0.ToString();
                }

                this.txtDiferencia.Text = (Convert.ToDouble(txtingreso.Text) - Convert.ToDouble(txtegreso.Text)).ToString("N0");               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }        


        private void Mostrar()
        {

            this.dataListado.DataSource = NMovimiento.Mostrar();
           // this.OcultarColumnas();
            //lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            this.TotalesMovimiento();
        }

        private void BuscarFechas()
        {
            this.txtingreso.Text = 0.ToString();
            this.txtegreso.Text = 0.ToString();

            //SI LA FECHA DE APERTURA ES NULA ENTONCES NO SE MUESTRAN LOS MOVIMIENTOS
            if (this.txtfechaApertura.Text==string.Empty)
            {
                this.dataListado.DataSource = null;
            }
            else
            {
                this.dataListado.DataSource = NMovimiento.BuscarFechaMovimientoCaja(this.txtfechaApertura.Text, dtpFechaCierre.Value.ToString("dd/MM/yyyy HH:mm"));
                //lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

                this.TotalesMovimiento();
            }
            
        }

        private void MovimientoDePagos()
        {          
            //INSTANCIAMOS UN DATABLE
            DataTable mov = new DataTable();
            if (this.txtfechaApertura.Text==string.Empty)
            {
                txtEfectivo.Text = "0";
                txtCheque.Text ="0";
                txtTarjeta.Text = "0";
                txtOtros.Text = "0";
            }
            else
            {
                //SE CARGA EN EL DATABLE EL METODO
                mov = NCaja.BuscarMovimientoPagosCaja(this.txtfechaApertura.Text, dtpFechaCierre.Value.ToString("dd/MM/yyyy HH:mm"));

                double efectivo = 0;
                double cheque = 0;
                double tarjeta = 0;
                double otros = 0;

                txtEfectivo.Text = efectivo.ToString("N0");
                txtCheque.Text = cheque.ToString("N0");
                txtTarjeta.Text = tarjeta.ToString("N0");
                txtOtros.Text = otros.ToString("N0");

                if (mov == null)
                    return;

                //PASA LOS DATOS DEL DATATABLE A LOS TEXTBOX
                efectivo = mov.Rows[0]["PagoEfectivo"] != DBNull.Value ? Convert.ToDouble(mov.Rows[0]["PagoEfectivo"]) : 0;
                cheque = mov.Rows[0]["PagoCheque"] != DBNull.Value ? Convert.ToDouble(mov.Rows[0]["PagoCheque"]) : 0;
                tarjeta = mov.Rows[0]["PagoTarjeta"] != DBNull.Value ? Convert.ToDouble(mov.Rows[0]["PagoTarjeta"]) : 0;
                otros = mov.Rows[0]["PagoOtros"] != DBNull.Value ? Convert.ToDouble(mov.Rows[0]["PagoOtros"]) : 0;

                txtEfectivo.Text = efectivo.ToString("N0");
                txtCheque.Text = cheque.ToString("N0");
                txtTarjeta.Text = tarjeta.ToString("N0");
                txtOtros.Text = otros.ToString("N0");
                //this.TotalesMovimientoPagos();
            }
            if (txtMontoInicial.Text != string.Empty)
            {
                this.txtSaldoActual.Text = (Convert.ToDouble(txtMontoInicial.Text) + Convert.ToDouble(txtEfectivo.Text)).ToString("N0");
            }
        }



        private void FrmCierreCaja_Load(object sender, EventArgs e)
        {
            //top para ubicar en la parte superior
            this.Top = 0;
            //alineado hacia la izquierda
            this.Left = 0;
            this.lblUsuario.Text = usuario;
            this.ObtenerDatosCaja(Convert.ToInt32(id));
            

            //DATAGRID
            //this.Mostrar();            
            this.BuscarFechas();
            this.MovimientoDePagos();

            this.txtegreso.ReadOnly = true;
            this.txtingreso.ReadOnly = true;
            //setear valores

            CalcularDiferenciaCaja();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "";
                if (!string.IsNullOrEmpty(txtImporteEntrega.Text) && Convert.ToDouble(txtImporteEntrega.Text) == 0)
                {
                    mensaje = "El importe de Entrega es 0 \nEsta seguro que desea cerrar la caja?";
                }
                else
                {
                    mensaje = "Esta seguro que desea cerrar la caja?";
                }


                DialogResult opcion;
                opcion = MessageBox.Show(mensaje, "Sistema de Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.No)
                {
                    return;
                }



                DateTime fechaCierre = this.dtpFechaCierre.Value;
                double ImporteEntrega = Convert.ToDouble(txtImporteEntrega.Text);
                double Saldo = Convert.ToDouble(txtSaldoActual.Text);
                double Diferencia = Convert.ToDouble(txtDiferenciaSaldo.Text);


                string rpta = "";
                rpta = NCaja.CerrarCaja(nroArqueo, fechaCierre, ImporteEntrega, Saldo, Diferencia);
                //si se esta editando el registro    

                if (rpta.Equals("OK"))
                {
                    this.MensajeOK("La Caja se ha cerrado con exito");
                    this.Close();
                }
                else
                {
                    this.MensajeError(rpta);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Movimiento()
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



        private void FrmCierreCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void dataListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            this.Movimiento();
        }

        private void txtImporteEntrega_TextChanged(object sender, EventArgs e)
        {
            this.CalcularDiferenciaCaja();
           
        }

        private void dtpFechaCierre_ValueChanged(object sender, EventArgs e)
        {
            this.BuscarFechas();
            this.MovimientoDePagos();
            this.CalcularDiferenciaCaja();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataListado.Columns["Importe"].DefaultCellStyle.Format = "N0";
        }
    }
}
