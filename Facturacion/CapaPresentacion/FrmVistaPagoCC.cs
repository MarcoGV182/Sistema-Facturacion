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
    public partial class FrmVistaPagoCC : Form
    {
        
        private bool IsNuevo=true;
        private DataTable Dtdetalle;

        //datos usuario
        public int id;
        public string usuario;
        public string nombre;
        public string apellido;


        public FrmVistaPagoCC()
        {
            InitializeComponent();
            LlenarComboBox();
        }



        private void LlenarComboBox()
        {
            cboFormaPago.DataSource = NFormaPago.MostrarFormaPago();
            cboFormaPago.DisplayMember = "Descripcion";
            cboFormaPago.ValueMember = "FormaPagoNro";
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

        private void CrearTabla()
        {
            this.Dtdetalle = new DataTable("Detalle");
            this.Dtdetalle.Columns.Add("NroFactura", System.Type.GetType("System.String"));
            this.Dtdetalle.Columns.Add("ClienteNro", System.Type.GetType("System.Int32"));
            this.Dtdetalle.Columns.Add("Credito", System.Type.GetType("System.Decimal"));
            this.Dtdetalle.Columns.Add("Fecha", System.Type.GetType("System.DateTime"));
            this.Dtdetalle.Columns.Add("Importe", System.Type.GetType("System.Decimal"));
            this.Dtdetalle.Columns.Add("Saldo", System.Type.GetType("System.Decimal"));

           // this.dgvPrueba.DataSource = this.Dtdetalle;
           
        }


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



        public void ObtenerDatos(DateTime fecha,string cuentapagar,string factura, string cliente, string clientenro, string saldo, string valorinicial) {
            this.txtfechafactura.Text = fecha.ToString("dd/MM/yyyy");
            this.txtcuentacobrar.Text = cuentapagar;
            this.txtNroFactura.Text = factura;
            this.txtClienteNro.Text = clientenro;
            this.txtNombre.Text = cliente;
            this.txtSaldo.Text = Convert.ToDouble(saldo).ToString("N0");
            this.txtValorInicial.Text = valorinicial;
        }


        
       private void FrmVistaPago_Load(object sender, EventArgs e)
        {
            CrearTabla();
            Top = 100;
            Left = 70;
            this.txtImportePago.Text=0.ToString();
            this.txtImportePago.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           
            try
           {
                string rpta = "";
                if (this.txtImportePago.Text == string.Empty)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtImportePago, "Ingrese el importe");
                    this.txtImportePago.Focus();
                }
                else if((Convert.ToInt32(this.txtImportePago.Text) > Convert.ToDouble(this.txtSaldo.Text))  || Convert.ToInt32(this.txtImportePago.Text)==0) 
                {
                    this.MensajeError("Verifique el importe");
                    errorIcono.SetError(txtImportePago, "El importe no puede ser mayor al saldo o igual a 0");
                    this.txtImportePago.Focus();
                }
                else { 
            
                    //si se ingresa un nuevo registro
                    if (this.IsNuevo)
                    {
                        rpta = NPagoCuentaPorCobrar.Insertar(Convert.ToInt32(this.txtcuentacobrar.Text),this.dtpFechaPago.Value,Convert.ToInt32(this.cboFormaPago.SelectedValue),Convert.ToDecimal(this.txtImportePago.Text),txtObservacion.Text.Trim().ToUpper(),id);
                       
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (IsNuevo)
                        {
                            this.MensajeOK("El pago se ha insertado con exito");
                        }
                        this.Close();
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    IsNuevo = false;                      
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

            
            
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            //agregar en el detalle
            DataRow row = this.Dtdetalle.NewRow();
            row["NroFactura"] = txtNroFactura.Text;
            row["ClienteNro"] = Convert.ToInt32(txtClienteNro.Text);
            row["Fecha"] = Convert.ToDateTime(dtpFechaPago.Text);
            row["Importe"] = Convert.ToDecimal(txtImportePago.Text);
            row["Credito"] = Convert.ToDecimal(txtValorInicial.Text);
            row["Saldo"] = Convert.ToDecimal(txtSaldo.Text);
            this.Dtdetalle.Rows.Add(row);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtImportePago_KeyPress(object sender, KeyPressEventArgs e)
        {
           this.SoloNumeros(e);
        }

        private void FrmVistaPago_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void FrmVistaPago_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmCuentaPorCobrar frm = FrmCuentaPorCobrar.GetInstancia();
            frm.MostrarFacturas();
            frm.MostrarHistorico();
            frm.DeudaTotal();
        }
    }
}
    
