using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.Facturacion
{
    public partial class FrmCambiarPago : Form
    {
        int nroVenta = 0;
        string nroFactura = string.Empty;
        int cliente = 0;
        double importeFactura = 0;
        const string nombreParametroModificarPago = "Cant_Dias_Modificar_Pago";
        NConfiguracion DatosConfiguracion = null;

        //Usuario
        public int idUsuario = 0;
        public string acceso = string.Empty;

        static FrmCambiarPago _Instancia;

        public FrmCambiarPago()
        {
            InitializeComponent();
            Load += FrmCambiarPago_Load;
        }

        private void FrmCambiarPago_Load(object sender, EventArgs e)
        {
            ObtenerDatosConfiguracion();
            Limpiar();
        }

        private void ObtenerDatosConfiguracion() 
        {
            DatosConfiguracion = NConfiguracion.ObtenerConfiguracion(nombreParametroModificarPago);
        }

        private void Limpiar() 
        {
            nroVenta = 0;
            cliente = 0;
            importeFactura = 0;
            txtCliente.Clear();
            txtImporte.Clear();
            txtNroFactura.Clear();
            txtNroVenta.Clear();
            txtFechaFactura.Clear();
            txtTotalPagado.Text = "0";
            dataDetalle.DataSource = null;            
        }

        public static FrmCambiarPago GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmCambiarPago();
            }
            return _Instancia;
        }

        private void btnModificarPago_Click(object sender, EventArgs e)
        {
            if (!ControlesCompartidos.MensajeConfirmacion(this,$"Desea ingresar al panel para modificar el Registro de Pago de la Factura: {nroFactura}?"))
                return;

            if (!acceso.ToUpper().Equals("ADMINISTRADOR"))
            {
                DateTime fechaFactura = Convert.ToDateTime(txtFechaFactura.Text);
                DateTime fechaLimite = fechaFactura.AddDays(Convert.ToInt32(DatosConfiguracion.Valor));
                if (DateTime.Now > fechaLimite)
                {
                    MensajeError($"Ya se ha superado el límite para poder modificar el Pago registrado \nFecha Limite: {fechaLimite.ToShortDateString()}.\nSolo un usuario con cargo: ADMINISTADOR puede modificar el pago");
                    return;
                }
            }

            FrmPagoFactura frmPago = FrmPagoFactura.GetInstancia(nroVenta,true);
            frmPago.ObtenerDatosFactura(nroFactura, cliente, importeFactura);
            frmPago.ShowDialog();
            var resultado = frmPago.resultado;
            if (resultado)
            {
                ConsultarVenta();
            }
            
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarVenta();
        }

        private void ConsultarVenta() 
        {
            if (!Int32.TryParse(txtNroVenta.Text, out nroVenta))
            {
                MensajeError("El caracter ingresado no es válido. Favor ingrese un número");
                return;
            }

            var ds = NFactura.MostrarPagoFactura(nroVenta);

            if (ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("No existen los registros para el Nro. de Venta ingresado", "Sistema Facturación", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Limpiar();
                return;
            }


            DataTable dtDatosFactura = ds.Tables[0];
            DataTable dtDatosPagos = ds.Tables[1];


            CargarDatosFactura(dtDatosFactura);
            this.dataDetalle.DataSource = dtDatosPagos;
            TotalPagado();
            this.OcultarColumnaPagos();

        }

        private void TotalPagado() 
        {
            double importe = 0;
            if (dataDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataDetalle.Rows)
                {
                    if (Convert.ToDouble(row.Cells["ImportePagado"].Value) > 0)
                    {
                        importe += Convert.ToDouble(row.Cells["ImportePagado"].Value);                        
                    }                    
                }
            }
            else
            {
                importe = 0;
            }

            txtTotalPagado.Text = importe.ToString("N0");
        }


        private void CargarDatosFactura(DataTable factura)
        {
            nroVenta = Convert.ToInt32(factura.Rows[0]["NroVenta"]);
            nroFactura = factura.Rows[0]["NroFactura"].ToString();
            cliente = Convert.ToInt32(factura.Rows[0]["ClienteNro"]);
            string NombreCliente = factura.Rows[0]["Cliente"].ToString();
            DateTime fechaFactura = Convert.ToDateTime(factura.Rows[0]["Fecha"]);
            importeFactura = Convert.ToInt64(factura.Rows[0]["Total"]);

            txtNroFactura.Text = nroFactura;
            txtCliente.Text = NombreCliente;
            txtImporte.Text = importeFactura.ToString("N0");
            txtFechaFactura.Text = fechaFactura.ToShortDateString();
        }
        


        private void OcultarColumnaPagos()
        {
            this.dataDetalle.Columns[0].Visible = false;
            this.dataDetalle.Columns[1].Visible = false;
            this.dataDetalle.Columns[4].Visible = false;
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

        private void dataDetalle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dataDetalle.Columns["MontoAbonado"].DefaultCellStyle.Format = "N0";
                this.dataDetalle.Columns["ImportePagado"].DefaultCellStyle.Format = "N0";
                this.dataDetalle.Columns["Vuelto"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception)
            {

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
