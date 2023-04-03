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
    public partial class FrmCuentaPorCobrar : Form
    {
        int SaldoDeuda = 0;
        public string factura;
        public int proveedor;
        double DebitoSeleccionado = 0;


        //datos usuario
        public int id;
        public string usuario;
        public string nombre;
        public string apellido;
        public string acceso;


        private static FrmCuentaPorCobrar _Instancia;

        public static FrmCuentaPorCobrar GetInstancia() {
            if (_Instancia == null) {
                _Instancia = new FrmCuentaPorCobrar();
           }
            return _Instancia;
        }

    
        public FrmCuentaPorCobrar()
        {
            InitializeComponent();            
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


        public void ObtenerDatosCliente(string clienteNro, string Ruc, string nombre, string apellido, string Direccion) 
        {
            this.txtClienteNro.Text = clienteNro;
            this.txtDocumento.Text = Ruc;
            this.txtNombre.Text = nombre;            
            this.txtDireccion.Text = Direccion;
            this.MostrarFacturas();
            this.MostrarHistorico();
            //DeudaTotal();
        }



        private void DataGridDiseno(DataGridView DGV)
        {
            DGV.BorderStyle = BorderStyle.None;
            DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            DGV.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            DGV.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            DGV.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            DGV.BackgroundColor = Color.White;

            DGV.EnableHeadersVisualStyles = false;
            DGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DGV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            DGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }



        private void EstadoCancelado()
        {
            for (int i = 0; i < dataListado.Rows.Count; i++)
            {
                String Estado = (dataListado.Rows[i].Cells["Estado"].Value).ToString();
                if (Estado.Equals("CANCELADO"))
                {
                    dataListado.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }

            }
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        //ocultar columnas
        private void OcultarColumnas()
        {
          try {
                this.dataListado.Columns["CuentaCobrarNro"].Visible = false;
                this.dataListado.Columns["ClienteNro"].Visible = false;
                //this.dataListado.Columns[5].Visible = false;
            }
            catch(Exception ex) {
            MessageBox.Show(ex.Message);
            }


        }

        private void OcultarColumnaHistorico()
        {
            try
            {
                this.dgvHistorico.Columns["PagoNro"].Visible = false;
                this.dgvHistorico.Columns["CuentaCobrarNro"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }    
        }



        //Metodo para mostrar los datos en el datagrid
        public void MostrarFacturas()
        {      
                this.dataListado.DataSource = NCuentaPorCobrar.MostrarFacturas(Convert.ToInt32(txtClienteNro.Text));
                //this.dataListado.Columns["Descripcion"].Width = 100;
                this.OcultarColumnas();
                lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);            
        }

        //Metodo para mostrar los datos de pagos historicos en el datagrid
        public void MostrarHistorico()
        {
            this.dgvHistorico.DataSource = NCuentaPorCobrar.MostrarHistorico(Convert.ToInt32(txtClienteNro.Text));
            //this.dataListado.Columns["Descripcion"].Width = 100;
            this.OcultarColumnaHistorico();
            lblHistorico.Text = "Total de registros: " + Convert.ToString(dgvHistorico.Rows.Count);
        }



        public void DeudaTotal() {
          try 
          {
                if (dataListado.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {

                        SaldoDeuda += Convert.ToInt32(row.Cells["Debito"].Value);
                        txtDeuda.Text = (SaldoDeuda).ToString("N0");
                    }
                    SaldoDeuda = 0;

                }
                else
                {
                    SaldoDeuda = 0;
                    this.txtDeuda.Text = 0.ToString();
                }
                
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void FrmCuentaPorCobrar_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.txtDeuda.ReadOnly = true;
            
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            
            FrmVistaClienteDeuda Frm = FrmVistaClienteDeuda.GetInstancia();
            Frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void FrmCuentaPorCobrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DebitoSeleccionado = Convert.ToDouble(this.dataListado.CurrentRow.Cells["Debito"].Value);
            txtSeleccion.Text = DebitoSeleccionado.ToString("N0");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                FrmVistaPagoCC frmpago = new FrmVistaPagoCC();
                
                DateTime fecha;
                string factura,cuentapagar ,cliente, clientenro, saldo, valorinicial;
                fecha = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha"].Value);
                cuentapagar = (this.dataListado.CurrentRow.Cells["CuentaCobrarNro"].Value).ToString();
                factura = (this.dataListado.CurrentRow.Cells["NroFactura"].Value).ToString();
                cliente = this.txtNombre.Text;
                clientenro = (this.dataListado.CurrentRow.Cells["ClienteNro"].Value).ToString();
                saldo = (this.dataListado.CurrentRow.Cells["Debito"].Value).ToString();
                valorinicial = (this.dataListado.CurrentRow.Cells["Credito"].Value).ToString();
                frmpago.ObtenerDatos(fecha,cuentapagar, factura, cliente, clientenro,saldo, valorinicial);

                frmpago.id = id;
                frmpago.ShowDialog();
               
            }
            catch (Exception)
            {
                MensajeError("Debe seleccionar una fila");
            }
        }

        private void dataListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridDiseno(dataListado);
            EstadoCancelado();
        }

        private void dataListado_CurrentCellChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvHistorico_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridDiseno(dgvHistorico);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dgvHistorico_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dgvHistorico.Columns["Importe"].DefaultCellStyle.Format = "N0";
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataListado.Columns["Credito"].DefaultCellStyle.Format = "N0";
            this.dataListado.Columns["Debito"].DefaultCellStyle.Format = "N0";
        }

        private void FrmCuentaPorCobrar_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F2) 
            {
                this.btnBuscarProveedor_Click(null,null);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            int cuentacobrar, pago;
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Desea eliminar el registro ?", "Sistema de Facturacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    cuentacobrar = Convert.ToInt32(dgvHistorico.CurrentRow.Cells["CuentaCobrarNro"].Value);
                    pago = Convert.ToInt32(dgvHistorico.CurrentRow.Cells["PagoNro"].Value);

                    rpta = NPagoCuentaPorCobrar.Eliminar(cuentacobrar, pago);

                     if(rpta.Equals("OK"))
                     {
                         MensajeOK("Se eliminó correctamente el pago");
                        this.MostrarFacturas();
                        this.MostrarHistorico();
                        this.DeudaTotal();
                    }
                     else
                     {
                          MensajeError("No se eliminó");
                      }
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataListado.Rows.Count > 0)
                {
                    FrmInformePagosCliente frm = new FrmInformePagosCliente();
                    frm.cuentacobrarnro = Convert.ToInt32(dataListado.CurrentRow.Cells["CuentaCobrarNro"].Value);
                    frm.ShowDialog();
                }
                else
                {
                    MensajeError("Debe seleccionar una fila");
                }
            }
            catch (Exception)
            {
                MensajeError("Debe seleccionar una fila");
            }
            
        }
    }
}

