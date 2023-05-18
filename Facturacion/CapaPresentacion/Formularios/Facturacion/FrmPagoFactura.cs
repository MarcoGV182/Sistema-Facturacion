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
using System.Data.SqlClient;
using CapaDatos;
using Microsoft.Reporting.WinForms;

namespace CapaPresentacion.Formularios.Facturacion
{
    public partial class FrmPagoFactura : Form
    {
        int IdVenta = 0;
        int Cliente;
        bool EditarPago = false;
        static FrmPagoFactura _Instancia;
        public bool resultado = false; 

        public FrmPagoFactura()
        {
            InitializeComponent();
        }

        public FrmPagoFactura(int idVenta,bool editarPago)
        {
            InitializeComponent();
            IdVenta = idVenta;
            EditarPago = editarPago;
        }

        
        public static FrmPagoFactura GetInstancia() 
        { 
            if(_Instancia==null) 
            {
                _Instancia = new FrmPagoFactura();
            }
            return _Instancia;
        }

        public static FrmPagoFactura GetInstancia(int idVenta,bool editar)
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmPagoFactura(idVenta,editar);
            }
            return _Instancia;
        }


        private void CargaCombo() 
        {
            this.cboBanco.DataSource = NBanco.Mostrar();
            this.cboBanco.ValueMember = "BancoNro";
            this.cboBanco.DisplayMember = "Descripcion";


            this.cboTipoPago.DataSource = NTipoPago.MostrarTipoPagoOtros();
            this.cboTipoPago.ValueMember = "TipoOtrosNro";
            this.cboTipoPago.DisplayMember = "Descripcion";
        }

        public void ObtenerDatosFactura(string nrofactura,int clientenro,double total) 
        {   
            this.txtNroFactura.Text = nrofactura;
            this.Cliente = clientenro;
            this.txtTotalVenta.Text = total.ToString("N0");
            this.txtMontoEfectivo.Text= total.ToString("N0");
        }


        public void LimpiarPagoFactura() 
        {
            txtMontoCheque.Text = "0";
            txtMontoEfectivo.Text = "0";
            txtMontoTarjeta.Text = "0";
            txtMontoOtros.Text = "0";
            txtComprobante.Text = string.Empty;
            txtNroDocumentoOtros.Text = string.Empty;
            cboBanco.SelectedIndex = 0;
            cboTarjeta.SelectedIndex = 0;
            cboTipoPago.SelectedIndex = 0;
            txtNroCheque.Text = string.Empty;
            tabControl1.SelectedIndex = 0;
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
            lblError.Text = mensaje;
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


        private void Calcular() 
        {
            double efectivo = 0, tarjeta = 0, cheque = 0, otros = 0, vuelto=0;
            string total="0";
            efectivo = Convert.ToDouble(txtMontoEfectivo.Text);
            tarjeta = Convert.ToDouble(txtMontoTarjeta.Text);
            cheque = Convert.ToDouble(txtMontoCheque.Text);
            otros = Convert.ToDouble(txtMontoOtros.Text);
            total = (efectivo + tarjeta + cheque + otros).ToString("N0");
            vuelto = efectivo - Convert.ToDouble(txtTotalVenta.Text);

            this.lblEfectivo.Text = efectivo.ToString("N0");
            this.lblTarjeta.Text =tarjeta.ToString("N0");
            this.lblCheque.Text = cheque.ToString("N0");
            this.lblOtros.Text = otros.ToString("N0");
            this.lblTotal.Text = total;
            this.txtVuelto.Text = vuelto.ToString("N0");
        }

        private void FrmPagoFactura_Load(object sender, EventArgs e)
        {
            CargaCombo();
            Calcular();

            txtMontoEfectivo.Focus();
            dtpFechaCheque.Checked = false;
            cboBanco.SelectedIndex = 0;
            cboTarjeta.SelectedIndex = 0;
            
        }

        private void txtValorAbonar_TextChanged(object sender, EventArgs e)
        {
            try
            {                
                Calcular();
            }
            catch (Exception)
            {
                txtMontoEfectivo.Text = "0";
            }
        }

        private void txtMontoTarjeta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception)
            {
                txtMontoTarjeta.Text = "0";
            }
        }

        private void txtMontoCheque_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception)
            {
                txtMontoCheque.Text = "0";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                              
                //string pagoefectivo="", pagotarjeta="", pagocheque = "";
                //EVALUAR
                if (!Validaciones())
                {
                    return;
                }   

                this.lblError.Visible = false;


                DPagoFacturaEfectivo pagoEF = null;
                DPagoFacturaTarjeta pagoTJ = null;
                DPagoFacturaCheque pagoCQ = null;
                DPagoFacturaOtros pagoOT = null;

                //Pago en efectivo
                if (this.txtMontoEfectivo.Text != "0")
                {
                    double vuelto = Convert.ToDouble(this.txtVuelto.Text) < 0 ? 0 : Convert.ToDouble(this.txtVuelto.Text);
                    pagoEF = new DPagoFacturaEfectivo()
                    {
                        NroVenta = IdVenta,
                        Monto = Convert.ToDouble(this.txtMontoEfectivo.Text),
                        Vuelto = vuelto
                    };
                }

                //Pago en Tarjeta
                if (this.txtMontoTarjeta.Text != "0")
                {
                    pagoTJ = new DPagoFacturaTarjeta()
                    {
                        NroVenta = IdVenta,
                        TipoTarjeta = this.cboTarjeta.Text,
                        ComprobanteNro = txtComprobante.Text,
                        Monto = Convert.ToDouble(this.txtMontoTarjeta.Text)
                    };
                }

                //Pago en Cheque
                if (this.txtMontoCheque.Text != "0")
                {
                    DBanco banco = new DBanco()
                    {
                        BancoNro = Convert.ToInt32(cboBanco.SelectedValue)
                    };
                    pagoCQ = new DPagoFacturaCheque()
                    {
                        NroVenta = IdVenta,
                        NroCheque = this.txtNroCheque.Text,
                        Banco = banco,
                        FechaCheque = dtpFechaCheque.Checked == false ? (DateTime?)null : dtpFechaCheque.Value,
                        Monto = Convert.ToDouble(this.txtMontoCheque.Text)
                    };
                }


                if (this.txtMontoOtros.Text != "0")
                {
                    DTipoPagoOtros tpOT = new DTipoPagoOtros()
                    {
                        TipoOtrosNro = Convert.ToInt32(cboTipoPago.SelectedValue),
                        Descripcion = cboTipoPago.Text
                    };

                    pagoOT = new DPagoFacturaOtros()
                    {
                        NroVenta = IdVenta,
                        TipoPagoOtro = tpOT,
                        NroDocumentoPago = txtNroDocumentoOtros.Text,
                        Monto = Convert.ToDouble(this.txtMontoOtros.Text)
                    };
                }

                //Se asigna los objetos
                RegistroPagoFacturacion pg = new RegistroPagoFacturacion()
                {
                    Efectivo = pagoEF,
                    Tarjeta = pagoTJ,
                    Cheque = pagoCQ,
                    Otro = pagoOT
                };



                if (EditarPago)
                {
                   var respuesta = NPagoFactura.ModificarPago(IdVenta, pg);
                    if (respuesta.ToUpper().Equals("OK"))
                    {
                        MensajeOK("Se ha modificado con éxito");
                        resultado = true;
                        this.Close();
                    }
                    else
                    {
                        resultado = false;
                        MensajeError(respuesta);
                    }
                    
                }
                else
                {
                    FrmFacturaVenta frm = FrmFacturaVenta.GetInstancia();
                    string valor = frm.InsertarFactura(pg);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private bool Validaciones() 
        {
            try
            {
                double totalVenta = Convert.ToDouble(this.txtTotalVenta.Text);
                double vueltoEfectivo = Convert.ToDouble(this.txtVuelto.Text) < 0 ? 0 : Convert.ToDouble(this.txtVuelto.Text);
                double importeEfectivo = Convert.ToDouble(this.txtMontoEfectivo.Text) - vueltoEfectivo;
                double importeTarjeta = Convert.ToDouble(this.txtMontoTarjeta.Text);
                double importeCheque = Convert.ToDouble(this.txtMontoCheque.Text);
                double importeOtros = Convert.ToDouble(this.txtMontoOtros.Text);
                double totalPagado = importeEfectivo + importeTarjeta + importeCheque + importeOtros;


                if (totalPagado < totalVenta)
                {
                    this.MensajeError("El monto de pago ingresado es menor al monto total");
                    this.lblError.Visible = true;
                    return false;
                }


                if ((importeTarjeta > totalVenta) ||
                    (importeCheque > totalVenta) ||
                    (importeOtros > totalVenta))
                {
                    this.MensajeError("El monto de pago diferente a Efectivo no puede ser mayor al monto total");
                    this.lblError.Visible = true;
                    return false;
                }

                if (totalPagado > totalVenta)
                {
                    this.MensajeError("El monto de pago es mayor al monto total de la venta. Favor verifiquelo");
                    this.lblError.Visible = true;
                    return false;
                }


                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPagoFactura_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAceptar_Click(null, null);
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtComprobante_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMontoEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SoloNumeros(e);
        }

        private void txtMontoTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SoloNumeros(e);
        }

        private void txtComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SoloNumeros(e);
        }

        private void txtMontoCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SoloNumeros(e);
        }

        private void txtMontoOtros_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception)
            {
                txtMontoOtros.Text = "0";
            }
        }

        private void FrmPagoFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
