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
    public partial class FrmCuentaPorPagar : Form
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


        private static FrmCuentaPorPagar _Instancia;

        public static FrmCuentaPorPagar GetInstancia() {
            if (_Instancia == null) {
                _Instancia = new FrmCuentaPorPagar();
           }
            return _Instancia;
        }

    
        public FrmCuentaPorPagar()
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


        public void ObtenerProveedor(string ProveedorNro, string Ruc, string nombre, string apellido, string Direccion) 
        {
            this.txtProveedorNro.Text = ProveedorNro;
            this.txtDocumento.Text = Ruc;
            this.txtNombre.Text = nombre;            
            this.txtDireccion.Text = Direccion;
            this.MostrarFacturas();
            this.MostrarHistorico();
            DeudaTotal();
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
                this.dataListado.Columns["CuentaPagarNro"].Visible = false;
                this.dataListado.Columns["ProveedorNro"].Visible = false;
                //this.dataListado.Columns[5].Visible = false;
            }
            catch(Exception ex) {
            MessageBox.Show(ex.Message);
            }


        }

        private void OcultarColumnaHistorico()
        {
            
            this.dgvHistorico.Columns["PagoNro"].Visible = false;
            this.dgvHistorico.Columns["CuentaPagarNro"].Visible = false;
        }



        //Metodo para mostrar los datos en el datagrid
        public void MostrarFacturas()
        {      
                this.dataListado.DataSource = NCliente.ObtenerDeudaProveedor(txtProveedorNro.Text);
                //this.dataListado.Columns["Descripcion"].Width = 100;
                this.OcultarColumnas();
                lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);            
        }

        //Metodo para mostrar los datos de pagos historicos en el datagrid
        public void MostrarHistorico()
        {
            this.dgvHistorico.DataSource = NPagoCuentaPorPagar.MostrarHistorico(Convert.ToInt32(txtProveedorNro.Text));
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



        private void FrmCuentaxPagar_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.txtDeuda.ReadOnly = true;
            
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            
            FrmVistaCompraDeuda Frm = FrmVistaCompraDeuda.GetInstancia();
            Frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void FrmCuentaxPagar_FormClosing(object sender, FormClosingEventArgs e)
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
                FrmVistaPagoCP frmpago = new FrmVistaPagoCP();
                
                DateTime fecha;
                string factura,cuentapagar ,proveedor, nroproveedor, saldo, valorinicial;
                fecha = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha"].Value);
                cuentapagar = (this.dataListado.CurrentRow.Cells["CuentaPagarNro"].Value).ToString();
                factura = (this.dataListado.CurrentRow.Cells["NroFactura"].Value).ToString();
                proveedor = this.txtNombre.Text;
                nroproveedor = (this.dataListado.CurrentRow.Cells["ProveedorNro"].Value).ToString();
                saldo = (this.dataListado.CurrentRow.Cells["Debito"].Value).ToString();
                valorinicial = (this.dataListado.CurrentRow.Cells["Credito"].Value).ToString();
                frmpago.ObtenerDatos(fecha,cuentapagar, factura, proveedor, nroproveedor,saldo, valorinicial);


                frmpago.id = id;
                frmpago.ShowDialog();
               
            }
            catch (Exception)
            {
                MessageBox.Show("Debe seleccionar una Factura");
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

        private void FrmCuentaxPagar_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F2) 
            {
                this.btnBuscarProveedor_Click(null,null);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            int cuentapagar, pago;
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Desea eliminar el registro ?", "Sistema de Facturacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    cuentapagar = Convert.ToInt32(dgvHistorico.CurrentRow.Cells["CuentaPagarNro"].Value);
                    pago = Convert.ToInt32(dgvHistorico.CurrentRow.Cells["PagoNro"].Value);

                    rpta = NPagoCuentaPorPagar.Eliminar(cuentapagar, pago);

                    if (rpta.Equals("OK"))
                    {
                        MensajeOK("Se eliminó correctamente el pago");
                        this.MostrarFacturas();
                        this.MostrarHistorico();
                        this.DeudaTotal();
                    }
                    else
                    {
                        MensajeError("No se eliminó el pago");
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
                    FrmInformePagosProveedor frm = new FrmInformePagosProveedor();
                    frm.cuentapagarnro = Convert.ToInt32(dataListado.CurrentRow.Cells["CuentaPagarNro"].Value);
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

