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
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using CapaDatos;
using CapaPresentacion.Informes.DsReporteTableAdapters;
using System.Runtime.InteropServices;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using CapaPresentacion.Formularios.ChildForms;

namespace CapaPresentacion.Formularios.Facturacion
{
    public partial class FrmFacturaVenta : Form
    {
        private bool IsNuevo;
        private bool esProducto = true;
        private DataTable Dtdetalle;
        private double Total = 0;        
        //private double SubTotal = 0;
        private double SubtotalIVA = 0;
        private double SubTotalGravadas = 0;
        private double ganancia = 0;
        //variables descuento
        private double precioCompra = 0;
        private int CodTipoImpuesto = 0;
        private int? codigoCliente = 0;
        private int cantidadItem = 0;
        private decimal porcentajeComision = 0;
        private string codigoEmpleado = string.Empty;
        private double precioInicial = 0;

        //Numeracion
        DNumeracionComprobante numeracion = null;
        
        private DataRow row;       
        public int idVenta = 0;
        public int idUsuario = 0;
        public string usuario = string.Empty;
        public string nombre = string.Empty;
        public string apellido = string.Empty;
        public string acceso = string.Empty;

        FrmPagoFactura frmPagoFactura = null;

        string Ind_Autoimprenta = "S";
        int establecimientoAux = 0;
        int puntoExpedicionAux = 0;
        int numeroAux = 0;
        bool FormatoCorrectoFactura = true;
        bool isInitializing = true;


        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmFacturaVenta _Instancia;
        public static FrmFacturaVenta GetInstancia() {
            if(_Instancia==null) {
                _Instancia = new FrmFacturaVenta();
            }
            return _Instancia;
        }

        public FrmFacturaVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(txtCliente, "Seleccione el Cliente");
            this.ttMensaje.SetToolTip(txtNroFactura, "Ingrese el numero de factura");
            this.ttMensaje.SetToolTip(dtpFecha, "Ingrese la fecha de Venta");
            this.ttMensaje.SetToolTip(cboTipoPago, "Seleccione el tipo de pago");
            this.ttMensaje.SetToolTip(txtItem, "Seleccione el Item");
            this.ttMensaje.SetToolTip(btnBuscarItem, "Click para buscar item");
            this.ttMensaje.SetToolTip(btnBuscarCliente, "Click para buscar al Cliente");
            this.ttMensaje.SetToolTip(btnAgregar, "Click para agregar el item al carrito");
            this.ttMensaje.SetToolTip(btnQuitar, "Click para quitar el item del carrito");
            this.ttMensaje.SetToolTip(btnGuardar, "Click para guardar la Venta");
            this.ttMensaje.SetToolTip(btnNuevo, "Cick para iniciar una nueva Factura");
            this.ttMensaje.SetToolTip(btnCancelar, "Click para cancelar la Factura");
            codigoCliente = 0;
            this.txtCodItem.ReadOnly = true;
            this.txtItem.ReadOnly = true;
            this.txtCliente.ReadOnly = true;
            this.txtIva.ReadOnly = true;
            LlenarCombos();
            isInitializing = true;
            dtpFecha.Value = DateTime.Today;
        }

        private void FrmFacturaVenta_Load(object sender, EventArgs e)
        {
            DataGridDiseno(dataListado);
            //DataGridDiseno(dgvDetalleFactura);
            if (chkAnular.Checked == false)
                btnAnular.Enabled = false;

            this.Top = 50;
            this.Left = 30;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.CrearTabla();
            this.OcultarColumnasDetalle();
            this.cboComprobante.SelectedIndex = 0;
            this.cboTipoPago.SelectedIndex = 0;
            this.MedidaColumna(dgvDetalleFactura);
            this.btnImprimir2.Visible = false;

            //Evento de los radioButtons
            rbAutoimprenta.CheckedChanged += RadioButton_CheckedChanged;
            rbManual.CheckedChanged += RadioButton_CheckedChanged;


            this.dtpFechadesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        }

        private void DataGridDiseno(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv.BackgroundColor = Color.White;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }


        private void MedidaColumna(DataGridView dg)
        {
            //Medida
            dg.Columns["Nro"].Width = 35;
            dg.Columns["Item"].Width = 240;
            dg.Columns["Precio"].Width = 70;
            dg.Columns["Cantidad"].Width = 55;
            dg.Columns["IVA"].Width = 70;
            dg.Columns["SubtotalIVA"].Width = 70;
            dg.Columns["SubtotalNeto"].Width = 70;
            dg.Columns["Subtotal"].Width = 70;

            //Etiqueta titulo
            dg.Columns["IVA"].HeaderText = "Impuesto";
            dg.Columns["SubtotalIVA"].HeaderText = "IVA";
            dg.Columns["SubtotalNeto"].HeaderText = "Neto";
            dg.Columns["Subtotal"].HeaderText = "Total";

            //CENTRAR TEXTO EN LAS CELDAS
            dg.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns["IVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns["PrecioInicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns["SubtotalIVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns["SubtotalNeto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            //CENTRAR TEXTO EN LAS COLUMNAS
            dg.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns["IVA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns["Precio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns["PrecioInicial"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns["SubtotalIVA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns["SubtotalNeto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns["SubTotal"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void ObtenerEmpleadoFactura(string usuarionro, string nombre)
        {
            codigoEmpleado = usuarionro;
            //this.txtEmpleado.Text = nombre;
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

        private void LlenarCombos()
        {
            try
            {
                cboTipoPago.DataSource = NTipoPago.Mostrar();
                cboTipoPago.DisplayMember = "Descripcion";
                cboTipoPago.ValueMember = "CodTipoPago";

                cboComprobante.DataSource = NTipoComprobante.MostrarTipoComprobante();
                cboComprobante.DisplayMember = "Nombre";
                cboComprobante.ValueMember = "ComprobanteNro";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //Obtener los datos del Cliente
        public void ObtenerCliente(int clienteNro,string documento ,string nombre, string apellido)
        {
            codigoCliente = clienteNro;
            this.txtDocumento.Text = documento;
            this.txtCliente.Text = nombre + " " + apellido;
        }

        //Obtener los datos del producto
        public void ObtenerProducto(string codigo, string descripcion, double precio,double preciocompra,int codTipoImpuesto,string descripcionImpuesto,int stock)
        {
            this.txtCodItem.Text = codigo;
            this.txtItem.Text = descripcion;
            this.txtIva.Text = descripcionImpuesto;
            this.CodTipoImpuesto = codTipoImpuesto;
            this.txtExistencia.Text = stock.ToString();
            this.precioCompra = preciocompra;
            precioInicial = precio;
            this.txtPrecio.Text = precioInicial.ToString();

            //PONER POR DEFECTO LA SELECCION DEL CAMPO CANTIDAD            
            txtCantidad.Text = "1";
            txtCantidad.SelectAll();
            esProducto = true;
        }


        public void FacturaAnulada()
        {
            for (int i = 0; i < dataListado.Rows.Count; i++)
            {
                string estado = Convert.ToString(dataListado.Rows[i].Cells["Estado"].Value);
                if (estado.Equals("ANULADO"))
                {
                    dataListado.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }



        //Obtener los datos del Servicio
        public void ObtenerServicio(string codigo, string descripcion, double precio,int codTipoImpuesto, string descripcionImpuesto, decimal comision)
        {
            this.txtCodItem.Text = codigo;
            this.txtItem.Text = descripcion;
            precioInicial = precio;
            this.txtPrecio.Text = precio.ToString();
            this.txtIva.Text = descripcionImpuesto;
            CodTipoImpuesto = codTipoImpuesto;
            porcentajeComision = comision;

            //PONER POR DEFECTO LA SELECCION DEL CAMPO CANTIDAD
            cantidadItem = 1;            
            txtCantidad.Text = cantidadItem.ToString();
            txtCantidad.SelectAll();
            esProducto = false;
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

        //Limpiar los controles del formulario
        private void Limpiar()
        {
            Total = 0;
            SubtotalIVA = 0;
            SubTotalGravadas = 0;
            //this.txtNroFactura.Text = string.Empty;
            codigoCliente = 0;
            this.txtCliente.Text = "XXXXXX";
            this.txtDocumento.Text= "00000";
           // this.txtDias.Text = string.Empty;
            this.txtObservacion.Text = string.Empty;
            this.txtTotalGravadas.Text = string.Empty;
            this.txttotalIva.Text = string.Empty;
            this.txtTotalGral.Text = string.Empty;
            this.dtpFecha.Value = DateTime.Now;

            establecimientoAux = 0;
            puntoExpedicionAux = 0;
            numeroAux = 0;

            this.CrearTabla();
        }

        private void LimpiarDetalle()
        {
            this.txtItem.Text = string.Empty;
            this.txtCodItem.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtExistencia.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtIva.Text = string.Empty;
            //CAMPOS OT
            //this.txtEmpleado.Text = string.Empty;
            codigoEmpleado = string.Empty;
            porcentajeComision = 0;
            //Restablecer el color del control
            this.txtExistencia.BackColor = Color.WhiteSmoke;
        }

        private void CrearTabla()
        {
            this.Dtdetalle = new DataTable("Detalle");
            this.Dtdetalle.Columns.Add("Nro", System.Type.GetType("System.Int32"));
            this.Dtdetalle.Columns.Add("ItemNro", System.Type.GetType("System.Int32"));
            this.Dtdetalle.Columns.Add("Item", System.Type.GetType("System.String"));
            this.Dtdetalle.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
            this.Dtdetalle.Columns.Add("Precio", System.Type.GetType("System.Double"));
            this.Dtdetalle.Columns.Add("PrecioInicial", System.Type.GetType("System.Double"));
            this.Dtdetalle.Columns.Add("CodTipoImpuesto", System.Type.GetType("System.Int32"));
            this.Dtdetalle.Columns.Add("IVA", System.Type.GetType("System.String"));  
            this.Dtdetalle.Columns.Add("NroVenta", System.Type.GetType("System.Int32"));

            this.Dtdetalle.Columns.Add("SubtotalIVA", System.Type.GetType("System.Double"));
            this.Dtdetalle.Columns.Add("SubTotalNeto", System.Type.GetType("System.Double"));
            this.Dtdetalle.Columns.Add("SubTotal", System.Type.GetType("System.Double"));

            //COLUMNAS OT
            this.Dtdetalle.Columns.Add("UsuarioNro", System.Type.GetType("System.Double"));
            this.Dtdetalle.Columns.Add("Empleado", System.Type.GetType("System.String"));
            this.Dtdetalle.Columns.Add("ComisionServicio", System.Type.GetType("System.Decimal"));
            this.Dtdetalle.Columns.Add("Ganancia", System.Type.GetType("System.Double"));

            //relacion con el datagridview
            this.dgvDetalleFactura.DataSource = this.Dtdetalle;

            dgvDetalleFactura.Columns["IVA"].HeaderText = "Impuesto";
            dgvDetalleFactura.Columns["SubtotalIVA"].HeaderText = "IVA";
            dgvDetalleFactura.Columns["SubTotalNeto"].HeaderText = "Neto";
            dgvDetalleFactura.Columns["SubTotal"].HeaderText = "Total";

        }


        //Habilitar botones
        private void Habilitar(bool valor)
        {
            this.txtNumeracionOT.ReadOnly = !valor;           
            this.txtDocumento.ReadOnly = !valor;
            this.txtCliente.ReadOnly = valor;
            this.dtpFecha.Enabled = valor;
            this.txtObservacion.ReadOnly = !valor;
            this.txtItem.ReadOnly = !valor;
            this.txtCodItem.ReadOnly = valor;
            this.txtExistencia.ReadOnly = !valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtPrecio.ReadOnly = !valor;
            this.txtIva.ReadOnly = !valor;
            this.cboTipoPago.Enabled = valor;
            this.txtObservacion.ReadOnly = !valor;
            this.txtTotalGravadas.ReadOnly = !valor;
            this.txttotalIva.ReadOnly = !valor;
            this.txtTotalGral.ReadOnly = !valor;
            this.cboTipoPago.Enabled = valor;
            this.cboComprobante.Enabled = valor;
            this.btnBuscarItem.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
            this.txtCliente.ReadOnly = !valor;
            this.txtItem.ReadOnly = !valor;
            rbAutoimprenta.Enabled = valor;
            rbManual.Enabled = valor;

            //Inicializar la fecha desde del filtro al primer día del mes
            this.dtpFechadesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            if (rbAutoimprenta.Checked)
                txtNroFactura.ReadOnly = true;
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
               // this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
               // this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
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
                this.dataListado.Columns["PersonaNro"].Visible = false;
                this.dataListado.Columns["TipoComprobante"].Visible = false;
                this.dataListado.Columns["CodTipoPago"].Visible = false;
                this.dataListado.Columns["Colaborador"].Visible = false;
                this.dataListado.Columns["ColaboradorNro"].Visible = false;
            }
            catch (Exception)
            {

            }
            
        }

        private void OcultarColumnasDetalle()
        {
            try
            {
                this.dgvDetalleFactura.Columns["Nro"].Visible = true;
                this.dgvDetalleFactura.Columns["ItemNro"].Visible = false;
                this.dgvDetalleFactura.Columns["Precio"].Visible = true;
                this.dgvDetalleFactura.Columns["PrecioInicial"].Visible = false;
                this.dgvDetalleFactura.Columns["IVA"].Visible = true; 
                this.dgvDetalleFactura.Columns["CodTipoImpuesto"].Visible = false;
                this.dgvDetalleFactura.Columns["NroVenta"].Visible = false;

                //Ocultar columnas de OT
                if (dgvDetalleFactura.Columns.Contains("UsuarioNro"))
                    this.dgvDetalleFactura.Columns["UsuarioNro"].Visible = false;

                if (dgvDetalleFactura.Columns.Contains("Empleado"))
                    this.dgvDetalleFactura.Columns["Empleado"].Visible = false;

                if (dgvDetalleFactura.Columns.Contains("ComisionServicio"))
                    this.dgvDetalleFactura.Columns["ComisionServicio"].Visible = false;

                if (dgvDetalleFactura.Columns.Contains("Ganancia"))
                    this.dgvDetalleFactura.Columns["Ganancia"].Visible = false;


            }
            catch (Exception)
            {
                throw;
            }
            
        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            this.dataListado.DataSource = NFactura.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo buscar por fechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NFactura.BuscarFacturaFecha(this.dtpFechadesde.Value.ToString("yyyy-MM-dd"), dtpfechahasta.Value.ToString("yyyy-MM-dd"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        //Metodo buscar por detalle
        private void MostrarDetalle()
        {
            this.dgvDetalleFactura.DataSource = NFactura.MostrarDetalle(idVenta);
            OcultarColumnasDetalle();
        }

        private void FrmFacturaVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVistaCliente frmCliente = FrmVistaCliente.GetInstancia();
            frmCliente.ShowDialog();
        }

        private void btnBuscarItem_Click(object sender, EventArgs e)
        {
            FrmVistaItem frmitem = FrmVistaItem.GetInstancia();
            frmitem.ShowDialog();
            this.txtCantidad.Focus();
        }

        private void ObtenerNumeracionComprobante()
        {
            try
            {
                DataTable Num = new DataTable();
                Num = NFactura.MostrarNumeracion(cboComprobante.SelectedValue.ToString(),Ind_Autoimprenta);
                if (Num != null)
                {
                    numeracion = new DNumeracionComprobante();
                    numeracion.Establecimiento = Convert.ToInt32(Num.Rows[0][0]);
                    numeracion.PuntoExpedicion = Convert.ToInt32(Num.Rows[0][1]);
                    numeracion.NumeroDesde = Convert.ToInt32(Num.Rows[0][2]);
                    numeracion.NumeroHasta = Convert.ToInt32(Num.Rows[0][3]);
                    numeracion.NumeroActual = Convert.ToInt32(Num.Rows[0][4]);
                    numeracion.Timbrado = new DTimbrado() { IdTimbrado = Convert.ToInt32(Num.Rows[0][5]),NroTimbrado = Num.Rows[0][6].ToString()};

                    if (Ind_Autoimprenta == "S")
                        txtNroFactura.Text = Num.Rows[0]["NroDocumento"].ToString();
                    else
                        txtNroFactura.Text = string.Empty;
                }
                
            }
            catch (Exception)
            {
                MensajeError("No existe numeración creada. Favor configure primero el Timbrado y las numeraciones");
                btnGuardar.Enabled = false;
                txtNroFactura.Text = string.Empty;
            }
            
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNroFactura.Focus();
            this.LimpiarDetalle();
            this.OcultarColumnasDetalle();
            this.cboComprobante.SelectedIndex = 0;
            this.btnGuardar.Visible = true;
            this.btnImprimir2.Visible = false;
            //this.btnRetencion.Visible = false;
            this.txtNroFactura.Focus();

            //prueba de numeracion
            ObtenerNumeracionComprobante();

        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Checked)
            {
                //Si está seleccionado Autoimprenta se bloquea el numero de factura
                if (radioButton.Name == rbAutoimprenta.Name) 
                {
                    txtNroFactura.ReadOnly = true;
                    Ind_Autoimprenta = "S";
                }                     
                //Si está selccionado Manual se habilita el campo del numero de factura
                else if (radioButton.Name == rbManual.Name) 
                {
                    txtNroFactura.ReadOnly = false;
                    Ind_Autoimprenta = "N";
                }
                    
                // Desmarca los otros RadioButton
                foreach (RadioButton otherRadioButton in gbTipo.Controls.OfType<RadioButton>().Where(rb => rb != radioButton))
                {
                    otherRadioButton.Checked = false;
                }


                ObtenerNumeracionComprobante();
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                //Validar que se haya selecciona al menos un registro
                int x = dataListado.Rows.Cast<DataGridViewRow>()
                              .Where(r => Convert.ToBoolean(r.Cells[0].Value))
                              .Count();
                if (x == 0)
                {
                    MensajeError("No ha seleccionado ningun item");
                    return;
                }
                else if (x > 1)
                {
                    MensajeError("Solo se puede anular una factura a la vez");
                    return;
                }


                DialogResult opcion;
                opcion = MessageBox.Show("Desea anular la Factura ?", "Sistema de Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.No)
                    return;

                //int contador = 0;
                int codigo;
                string rpta = "";
                //recorrer el datagrip para eliminar mas de un registro
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        if (row.Cells["Estado"].Value.Equals("ANULADO"))
                        {
                            this.MensajeError("La factura ya se encuentra anulada");
                            return;
                        }

                        codigo = Convert.ToInt32(row.Cells["NroVenta"].Value);
                        rpta = NFactura.AnularFactura(codigo, idUsuario);
                    }
                }
                //mensaje a mostrar
                if (rpta.Equals("OK"))
                {
                    this.MensajeOK("Se Anuló correctamente el registro");
                    this.chkAnular.Checked = false;
                }
                else
                {
                    this.MensajeError(rpta);
                    this.chkAnular.Checked = false;
                }

                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkAnular_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnular.Checked == true)
            {
                btnAnular.Enabled = true;
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                btnAnular.Enabled = false;
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try 
            {
                if (e.ColumnIndex == dataListado.Columns["Anular"].Index)
                {
                    DataGridViewCheckBoxCell chkAnularDV = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Anular"];
                    chkAnularDV.Value = !Convert.ToBoolean(chkAnularDV.Value);
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataListado.Rows.Count == 0)
                    return;

                idVenta = Convert.ToInt32(this.dataListado.CurrentRow.Cells["NroVenta"].Value);
                this.txtCliente.Text = (this.dataListado.CurrentRow.Cells["Cliente"].Value).ToString();
                this.codigoCliente = Convert.ToInt32(this.dataListado.CurrentRow.Cells["PersonaNro"].Value);
                this.txtDocumento.Text = (this.dataListado.CurrentRow.Cells["Documento"].Value).ToString();
                this.txtNroFactura.Text = (this.dataListado.CurrentRow.Cells["NroFactura"].Value).ToString();
                this.cboComprobante.Text = (this.dataListado.CurrentRow.Cells["TipoComprobante"].Value).ToString();
                this.dtpFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha"].Value);
                this.cboTipoPago.Text = (this.dataListado.CurrentRow.Cells["TipoPago"].Value).ToString();

                //Evaluar si el documento fue registrados como AUTOIMPRENTA o MANUAL
                if (dataListado.CurrentRow.Cells["Ind_Autoimprenta"].Value.ToString() == "S")
                    rbAutoimprenta.Checked = true;
                else if (dataListado.CurrentRow.Cells["Ind_Autoimprenta"].Value.ToString() == "N")
                    rbManual.Checked = true;

                this.txtTotalGravadas.Text =Convert.ToDouble(this.dataListado.CurrentRow.Cells["Gravada"].Value).ToString("N0");
                this.txttotalIva.Text = Convert.ToDouble(this.dataListado.CurrentRow.Cells["Iva"].Value).ToString("N0");
                this.txtTotalGral.Text = Convert.ToDouble(this.dataListado.CurrentRow.Cells["Total"].Value).ToString("N0");                
                this.MostrarDetalle();
                this.tabControl1.SelectedIndex = 1;
                /*this.btnRetencion.Visible = true;
                this.btnRetencion.Enabled = true;*/
                this.btnGuardar.Enabled = false;
                this.btnImprimir2.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string InsertarFactura(RegistroPagoFacturacion pagos = null) 
        {
            try
            {
                string rpta = "";
                DFactura factura = new DFactura();
                factura.NroFactura = this.txtNroFactura.Text;
                factura.ClienteNro = codigoCliente.Value;
                factura.NombreCliente = this.txtCliente.Text;
                factura.CodTipoPago = Convert.ToInt32(this.cboTipoPago.SelectedValue);
                factura.Fecha = this.dtpFecha.Value;
                factura.TipoComprobanteNro = Convert.ToInt32(this.cboComprobante.SelectedValue);
                factura.CantCuota = null;
                factura.Vendedor = null;
                factura.Usuario = this.idUsuario.ToString();//codigo de usuario
                factura.Ind_Autoimprenta = Ind_Autoimprenta;
                if (numeracion.Establecimiento.HasValue)
                    factura.Establecimiento = numeracion.Establecimiento.Value;
                if (numeracion.PuntoExpedicion.HasValue)
                    factura.PuntoExpedicion = numeracion.PuntoExpedicion.Value;
                //Si es un documento manual se toma la numeración ingresada
                factura.Numero = Ind_Autoimprenta == "S" ? numeracion.NumeroActual : numeroAux;
                factura.Timbrado = numeracion.Timbrado;
                factura.Estado = "EMITIDO";
                factura.Observacion = txtObservacion.Text;

                rpta = NFactura.Insertar(factura,Dtdetalle, pagos);
                if (rpta.Contains("OK"))
                {
                    idVenta = Convert.ToInt32(rpta.Split(';')[0]);

                    //Confirmacion de que la factura se haya insertado
                    NFactura.ConfirmacionInsercion(idVenta);
                
                    this.MensajeOK("La venta se ha realizado con exito");
                    if (Ind_Autoimprenta=="S")
                    {
                        DialogResult opcion;
                        opcion = MessageBox.Show("Desea imprimir el comprobante ?", "Sistema de Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (opcion == DialogResult.Yes)
                        {
                            FrmComprobanteVenta frm = new FrmComprobanteVenta();
                            frm.nroVenta = idVenta;
                            frm.ShowDialog();
                        }

                        if (frmPagoFactura != null)
                        {
                            frmPagoFactura.LimpiarPagoFactura();
                            frmPagoFactura.Close();
                        }
                    }                      
                 }
                 else
                 {
                    this.MensajeError(rpta);
                    return rpta;
                 }
                this.IsNuevo =false;
                this.Botones();
                this.Limpiar();
                this.LimpiarDetalle();
                this.Mostrar();
                
                return rpta;                  
            }
            catch (Exception ex)
            {   
                MessageBox.Show(ex.Message + ex.StackTrace);
                return "";
            }
            finally 
            {
              Mostrar();
            }
        }


        private void InsertarOT() 
        {
            string OT = "";
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Desea registar la OT ?", "Sistema de Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    //OT = NOrdenTrabajo.Insertar(this.dtpFecha.Value, codigoCliente.Value, this.txtFormula.Text.Trim().ToUpper(), this.txtDias.Text == string.Empty ? (Int32?)null : Convert.ToInt32(this.txtDias.Text), dtpFechaVisita.Checked == false ? (DateTime?)null : dtpFechaVisita.Value, txtObservacion.Text.Trim().ToUpper(), id, usuario, Dtdetalle);
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }




        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validaciones())
                    return;

                errorIcono.Clear();
                DialogResult opcion;

                if (Ind_Autoimprenta.ToUpper().Equals("S"))
                {
                    if (cboTipoPago.SelectedIndex == 1)
                    {   
                        opcion = MessageBox.Show("Desea registrar la Factura a Crédito ?", "Sistema de Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (opcion == DialogResult.Yes)
                        {
                            InsertarFactura();
                            //InsertarOT();
                        }
                    }
                    else
                    {
                        errorIcono.Clear();

                        frmPagoFactura = FrmPagoFactura.GetInstancia();
                        string nrofactura, cliente, total;
                        nrofactura = txtNroFactura.Text;
                        cliente = codigoCliente.ToString();
                        total = txtTotalGral.Text;
                        frmPagoFactura.ObtenerDatosFactura(nrofactura, Convert.ToInt32(cliente), Convert.ToDouble(total));
                        //InsertarOT();
                        frmPagoFactura.ShowDialog();
                    }
                }
                else
                {                   
                    opcion = MessageBox.Show("Desea registrar la Factura Manual ?", "Sistema de Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (opcion == DialogResult.Yes)
                    {
                        InsertarFactura();
                    }

                }
                

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
            
        }


        private bool Validaciones() 
        {
            errorIcono.Clear();
            if (this.txtNroFactura.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtNroFactura, "Favor verifique la configuración de la numeración del tipo de comprobante");
                return false;
            }

            if (!ValidacionesTimbrado())
            {
                return false;
            }

            if (codigoCliente == null || this.txtDocumento.Text == "00000")
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtDocumento, "Ingrese el Cliente");
                this.txtDocumento.Focus();
                return false;
            }

            if (dgvDetalleFactura.Rows.Count == 0)
            {
                this.MensajeError("No existen items");
                return false;
            }

            if (codigoCliente == null || this.txtDocumento.Text == "00000")
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtDocumento, "Ingrese el Cliente");
                this.txtDocumento.Focus();
                return false;
            }

            if (dgvDetalleFactura.Rows.Count == 0)
            {
                this.MensajeError("No existen items para registrar la venta");
                return false;
            }

            return true;
        }


        private bool ValidacionesTimbrado() 
        {            
            if (Ind_Autoimprenta.Equals("N"))
            {
                if (!FormatoCorrectoFactura)
                {
                    this.MensajeError("Formato incorrecto");
                    errorIcono.SetError(txtNroFactura, "Favor ingrese la numeración de la factura con el formato correcto. 000-000-0000000");
                    return false;
                }

                //Obtener la numeración de la factura por separado
                string[] chars = txtNroFactura.Text.Split('-', ' ');
                if (chars.Count() != 3)
                {
                    this.MensajeError("Formato de Nro. de Factura incorrecto");
                    errorIcono.SetError(txtNroFactura, "Favor corrija el formato del Nro. de Factura");
                    return false;
                }

                int.TryParse(chars[0], out establecimientoAux);
                int.TryParse(chars[1], out puntoExpedicionAux);
                int.TryParse(chars[2], out numeroAux);

                if (establecimientoAux != numeracion.Establecimiento)
                {
                    this.MensajeError($"El establecimiento: {establecimientoAux} del Nro. de Factura no coincide con lo registrado como documento Manual en Numeraciones");
                    errorIcono.SetError(txtNroFactura, "Favor corrija el Nro. de Factura");
                    return false;
                }

                if (puntoExpedicionAux != numeracion.PuntoExpedicion)
                {
                    this.MensajeError($"El Punto de Expedición: {puntoExpedicionAux} del Nro. de Factura no coincide con lo registrado como documento Manual en Numeraciones");
                    errorIcono.SetError(txtNroFactura, "Favor corrija el Nro. de Factura");
                    return false;
                }

                if (numeroAux < numeracion.NumeroDesde || numeroAux > numeracion.NumeroHasta)
                {
                    this.MensajeError($"El Numero : {numeroAux} del Nro. de Factura no coincide con lo registrado como documento Manual en Numeraciones");
                    errorIcono.SetError(txtNroFactura, "Favor corrija el Nro. de Factura");
                    return false;
                }
            }

            return true;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                double iva = 0;
                double gravada = 0;
                double exento = 0;
                double SubTotal = 0;

                if (!ValidacionItems())
                {
                    return;
                }

                //limpiar todas las notificaciones de errores
                errorIcono.Clear();
                bool registrar = true;

                //VERIFICAR SI EL PRODUCTO/SERVICIO YA EXISTE EN EL DATAGRID
                foreach (DataRow fila in Dtdetalle.Rows)
                {
                    if (Convert.ToInt32(fila["ItemNro"]) == Convert.ToInt32(txtCodItem.Text))
                    {
                        //ASIGNAMOS LOS NUEVOS VALORES
                        registrar = false;
                        MensajeError("El item ya esta insertado");
                    }
                }

                //agregar en el detalle
                row = this.Dtdetalle.NewRow();
                row["ItemNro"] = Convert.ToInt32(txtCodItem.Text);
                row["Item"] = txtItem.Text;
                row["PrecioInicial"] = precioInicial;
                row["IVA"] = txtIva.Text;
                row["Cantidad"] = Convert.ToInt32(txtCantidad.Text);

                if (esProducto) 
                {
                    if (registrar && Convert.ToInt32(this.txtCantidad.Text) > Convert.ToInt32(this.txtExistencia.Text)) 
                    {
                        if (MessageBox.Show("No existe stock suficiente del Articulo seleccionado. \nDesea continuar ?", "Sistema de Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;          
                    } 
                }
                    



                if (registrar && this.txtExistencia.Text == string.Empty)
                {
                    if (this.txtCantidad.Text == string.Empty)
                        row["Cantidad"] = 1;
                    else
                        row["Cantidad"] = Convert.ToInt32(txtCantidad.Text);
                }

                row["CodTipoImpuesto"] = CodTipoImpuesto;
                double precioFinal = Convert.ToDouble(txtPrecio.Text);
                row["Precio"] = precioFinal.ToString("N0");
                SubTotal = Convert.ToDouble(row["Precio"]) * Convert.ToInt32(row["Cantidad"]);
                row["Subtotal"] = SubTotal;
                gravada = NFactura.DesglosarImportesIVA(SubTotal, CodTipoImpuesto, 0, "GRAV");
                exento = NFactura.DesglosarImportesIVA(SubTotal, CodTipoImpuesto, 0, "EXEN");
                iva = NFactura.DesglosarImportesIVA(SubTotal, CodTipoImpuesto, 0, "IVA");
                row["SubTotalNeto"] = gravada + exento;
                row["SubtotalIVA"] = iva;

                //AGREGAR DATOS DE OT
                //SI NO ESTA ASIGNADO A NINGUN EMPLEADO IGUAL INSERTAR EL REGISTRO
                /*if (codigoEmpleado == string.Empty && txtEmpleado.Text == string.Empty)
                {
                    row["UsuarioNro"] = DBNull.Value;
                    row["Empleado"] = DBNull.Value;
                    row["ComisionServicio"] = DBNull.Value;
                    row["Ganancia"] = DBNull.Value;
                }
                else
                {
                    row["UsuarioNro"] = codigoEmpleado;
                    row["Empleado"] = txtEmpleado.Text;
                    row["ComisionServicio"] = porcentajeComision;

                    ganancia = Convert.ToDouble(row["Subtotal"]) * (Convert.ToDouble(row["ComisionServicio"]) / 100);

                    row["Ganancia"] = ganancia.ToString("N0");
                }*/

                this.dgvDetalleFactura.DataSource = this.Dtdetalle;               
                this.Dtdetalle.Rows.Add(row);
                ReenumerarItems();
                this.LimpiarDetalle();

                //totales                    
                Total = Total + Convert.ToInt32(row["SubTotal"]);
                SubtotalIVA = SubtotalIVA + Convert.ToInt32(row["SubtotalIVA"]);
                SubTotalGravadas = SubTotalGravadas + Convert.ToInt32(row["SubTotalNeto"]);

                //Total = (SubtotalIVA + SubTotal + SubTotalGravadas);                
                txtTotalGravadas.Text = SubTotalGravadas.ToString("N0");
                txttotalIva.Text = SubtotalIVA.ToString("N0");
                txtTotalGral.Text = Total.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private bool ValidacionItems() 
        {
            if (this.txtItem.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtItem, "Ingrese el item");
                this.btnBuscarItem.Focus();
                return false;

            }

            if (this.txtExistencia.Text != string.Empty && this.txtCantidad.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtCantidad, "Ingrese la cantidad");
                this.txtCantidad.Focus();
                return false;
            }

            if (this.txtExistencia.Text != string.Empty && Convert.ToInt32(this.txtCantidad.Text) <= 0)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtCantidad, "La cantidad debe ser mayor a 0");
                this.txtCantidad.Focus();
                return false;
            }
            return true;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarItem();
            }
            catch (Exception ex)
            {
                MensajeError($"Error: {ex.Message}");
            }
        }

        private void EliminarItem() 
        {
            if (dgvDetalleFactura.CurrentCell == null)
            {
                MensajeError("No existe item para eliminar");
                return;
            }

            int indiceFila = dgvDetalleFactura.CurrentCell.RowIndex;
            row = Dtdetalle.Rows[indiceFila];
            
            //disminuir total                
            Total = Total - Convert.ToInt32(row["SubTotal"]);
            SubtotalIVA = SubtotalIVA - Convert.ToInt32(row["SubtotalIVA"]);
            SubTotalGravadas = SubTotalGravadas - Convert.ToInt32(row["SubTotalNeto"]);

            txtTotalGravadas.Text = SubTotalGravadas.ToString("N0");
            txttotalIva.Text = SubtotalIVA.ToString("N0");
            txtTotalGral.Text = Total.ToString("N0");

            //eliminamos la fila
            this.Dtdetalle.Rows.Remove(row);
            this.dgvDetalleFactura.DataSource = this.Dtdetalle;
            ReenumerarItems();
        }


        private void ReenumerarItems() 
        {
            for (int i = 0; i < Dtdetalle.Rows.Count; i++)
            {
                Dtdetalle.Rows[i]["Nro"] = i + 1;
            }
        
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
            if (dataListado.Rows.Count <= 0)
            {
                lblSinRegistros.Visible = true;
            }
            else
            {
                lblSinRegistros.Visible = false;
            }
        }

        private void dataListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            this.FacturaAnulada();
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtPrecio.Text) < precioCompra)
                {
                    this.MensajeError("Atención. El precio de Venta no puede ser menor a la de Costo");
                    errorIcono.SetError(txtPrecio, "Ingrese el precio");
                    return;
                }

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Limpiar();
            this.Habilitar(false);
            this.Botones();
            this.LimpiarDetalle();
            this.btnImprimir2.Visible = false;
        }

        private void dgvDetalleFactura_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvDetalleFactura.Columns["Precio"].DefaultCellStyle.Format = "N0";
                this.dgvDetalleFactura.Columns["PrecioInicial"].DefaultCellStyle.Format = "N0";
                this.dgvDetalleFactura.Columns["SubTotalNeto"].DefaultCellStyle.Format = "N0";
                this.dgvDetalleFactura.Columns["SubtotalIVA"].DefaultCellStyle.Format = "N0";
                this.dgvDetalleFactura.Columns["SubTotal"].DefaultCellStyle.Format = "N0";              
            }
            catch (Exception)
            {
                
            }
            
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dataListado.Columns["GRAVADA"].DefaultCellStyle.Format = "N0";
                this.dataListado.Columns["IVA"].DefaultCellStyle.Format = "N0";
                this.dataListado.Columns["EXENTO"].DefaultCellStyle.Format = "N0";
                this.dataListado.Columns["Total"].DefaultCellStyle.Format = "N0";
                //this.dataListado.Columns["TotalDescuento"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception)
            {
                  
            }
            
        }

        private void btnRetencion_Click(object sender, EventArgs e)
        {
            try
            {
                FrmVistaRetencion frm = new FrmVistaRetencion();
                DateTime fecha;
                string factura, cliente, nrocliente,monto;
                
                fecha = dtpFecha.Value;
                cliente = txtCliente.Text;
                monto = txtTotalGral.Text;
                factura = txtNroFactura.Text;
                nrocliente = codigoCliente.ToString();

                frm.ObtenerDatos(fecha, factura, cliente, nrocliente,monto);

                frm.ShowDialog();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones Reimpresion
                if (dataListado.CurrentRow == null)
                {
                    MensajeError("Debe de seleccionar un registro");
                    return;
                }

                //Si el usuario no tiene el acceso de ADM solo puede reimprimir documentos del día
                if (!acceso.ToUpper().Equals("ADMINISTRADOR"))
                {
                    if (this.dataListado.CurrentRow.Cells["Fecha"].Value.ToString() != DateTime.Now.ToShortDateString())
                    {
                        MensajeError("Solo puede reimprimir Facturas del día.\nSolo el ADMINISTRADOR puede reimprimir de cualquier día");
                        return;
                    }
                }

                if (this.dataListado.CurrentRow.Cells["Comprobante"].Value.ToString() != "FACTURA")
                {
                    MensajeError("El registro seleccionado no es un Factura");
                    return;
                }
                #endregion

                //Mensaje de carga de reporte
                btnImprimir.Text = "Cargando reporte...";
                btnImprimir.Enabled = false;
                this.Refresh();

                FrmComprobanteVenta frm = new FrmComprobanteVenta();
                int nroVenta;
                nroVenta = Convert.ToInt32(this.dataListado.CurrentRow.Cells["NroVenta"].Value);
                frm.nroVenta = nroVenta;
                frm.ShowDialog();

                //Mensaje de carga de reporte
                btnImprimir.Text = "&Re-Imprimir";
                btnImprimir.Enabled = true;
                this.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SoloNumeros(e);
            //AL PRESIONAR ENTER SOBRE EL CAMPO CANTIDAD SE AGREGA UN REGISTRO
            if (e.KeyChar==(char)13)
            {
                btnAgregar_Click(null, null);
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SoloNumeros(e);
        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            try
            {
                //Mensaje de carga de reporte
                btnImprimir2.Text = "Cargando...";
                btnImprimir2.Enabled = false;
                this.Refresh();

                FrmComprobanteVenta frm = new FrmComprobanteVenta();  
                frm.nroVenta = idVenta;
                frm.ShowDialog();


                //Mensaje de carga de reporte
                btnImprimir2.Text = "&Imprimir";
                btnImprimir2.Enabled = true;
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void FrmFacturaVenta_KeyUp(object sender, KeyEventArgs e)
        {
            //SI LA EL TABPAG FACTURA SE ENCUENTRA ACTIVO SE REALIZAN LAS OPERACIONES
            if (tabControl1.SelectedIndex == 1) 
            {
                if (btnBuscarCliente.Enabled == true && e.KeyCode == Keys.F2)
                {
                    this.btnBuscarCliente_Click(null, null);
                }
                if (btnCancelar.Enabled == true && e.KeyCode == Keys.Escape)
                {
                    this.btnCancelar_Click(null, null);
                }
                if (btnNuevo.Enabled==true && e.KeyCode==Keys.F1)
                {
                    this.btnNuevo_Click(null, null);
                }
                if (btnBuscarItem.Enabled==true && e.KeyCode==Keys.F5)
                {
                    btnBuscarItem_Click(null, null);
                }
                if (btnGuardar.Enabled == true && e.KeyCode == Keys.F4)
                {
                    btnGuardar_Click(null, null);
                }

            } 
            
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            try 
            {
                if(txtDocumento.Text!=string.Empty && txtDocumento.Text !="00000") 
                {
                    DataTable tablacliente = NCliente.MostrarTextbox(txtDocumento.Text);
                    if (tablacliente == null)
                    {
                        MensajeError("Cliente con el numero de documento ingresado no existe");
                        return;
                    }
                    codigoCliente = Convert.ToInt32(tablacliente.Rows[0][0]);
                    this.txtCliente.Text = tablacliente.Rows[0][1].ToString();
                }
                
            }
            catch(Exception) 
            {
                MessageBox.Show("No existe el Cliente");
                this.txtDocumento.Text = string.Empty;
            }
            
        }

        private void txtNumeracionOT_Leave(object sender, EventArgs e)
        {
            Total = 0;
            SubTotalGravadas = 0;
            SubtotalIVA = 0;
            //timer1.Enabled = false;

            Dtdetalle.Clear();
            

            try
            {
                //CABECERA DE ORDEN DE TRABAJO EN TEXTBOX
                DataTable dt = NOrdenTrabajo.MostrarCabOTFactura(this.txtNumeracionOT.Text);
                this.txtDocumento.Text = dt.Rows[0]["Documento"].ToString();
                codigoCliente = Convert.ToInt32(dt.Rows[0]["PersonaNro"]);
                this.txtCliente.Text = dt.Rows[0]["Cliente"].ToString();
                this.dtpFecha.Value = Convert.ToDateTime(dt.Rows[0]["Fecha"]);
                this.txttotalIva.Text = dt.Rows[0]["TotalIva"].ToString();
                this.txtTotalGravadas.Text = dt.Rows[0]["TotalGravadas"].ToString();
                this.txtTotalGral.Text = dt.Rows[0]["Total"].ToString();



                //DETALLE DE ORDEN DE TRABAJO EN DATAGRIDVIEW
                this.dgvDetalleFactura.DataSource = NOrdenTrabajo.MostrarDetOTFactura(this.txtNumeracionOT.Text.TrimStart('0'));

                //Agregar valores del Datagridview detalleFactura al DataTable DETALLE
                foreach (DataGridViewRow Datarow in dgvDetalleFactura.Rows)
                {
                    row = this.Dtdetalle.NewRow();
                    row["ItemNro"] = Convert.ToInt32(Datarow.Cells[0].Value);
                    row["Item"] = Datarow.Cells[1].Value;
                    row["PrecioInicial"] = Convert.ToDecimal(Datarow.Cells[3].Value);
                    row["IVA"] = Convert.ToInt32(Datarow.Cells[4].Value);
                    row["Cantidad"] = Convert.ToInt32(Datarow.Cells[2].Value);
                    row["PorcentajeIVA"] = Convert.ToInt32(Datarow.Cells[5].Value);
                    row["BaseImponible"] = Convert.ToDecimal(Datarow.Cells[6].Value);
                    row["Subtotal"] = Convert.ToInt32(row["Precio"]) * Convert.ToInt32(row["Cantidad"]);

                    row["SubTotalNeto"] = Math.Round(Convert.ToDouble(row["Subtotal"]) / Convert.ToDouble(row["BaseImponible"]));
                    row["SubtotalIVA"] = Convert.ToInt32(row["Subtotal"]) / Convert.ToInt32(row["PorcentajeIVA"]);

                    //totales
                    Total = Total + Convert.ToInt32(row["SubTotal"]);
                    SubtotalIVA = SubtotalIVA + Convert.ToInt32(row["SubtotalIVA"]);
                    SubTotalGravadas = SubTotalGravadas + Convert.ToInt32(row["SubTotalNeto"]);

                    //Total = (SubtotalIVA + SubTotal + SubTotalGravadas);

                    txtTotalGravadas.Text = SubTotalGravadas.ToString("N0");
                    txttotalIva.Text = SubtotalIVA.ToString("N0");
                    txtTotalGral.Text = Total.ToString("N0");

                    Dtdetalle.Rows.Add(row);
                    
                }

            }
            catch (Exception)
            {
                MessageBox.Show("El Nro. de la Orden de Trabajo no existe", "Sistema de Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.dtpFecha.Value = DateTime.Now;
        }

        private void cboComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInitializing)
            {
                // El evento SelectedIndexChanged fue ejecutado por el usuario
                // Realizar la acción deseada aquí
                ObtenerNumeracionComprobante();
            }
            
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtExistencia.Text != string.Empty)
                {
                    if (Convert.ToInt32(txtCantidad.Text) > Convert.ToInt32(this.txtExistencia.Text))
                    {
                        this.txtExistencia.BackColor = Color.Red;
                    }
                    else
                    {
                        this.txtExistencia.BackColor = Color.WhiteSmoke;
                    }
                }
            }
            catch (Exception)
            {

            }
           
            
        }

        private void txtDocumento_Click(object sender, EventArgs e)
        {
            if (txtDocumento.Text=="00000")
            {
                txtDocumento.Text = string.Empty;
            }
            
        }

        private void txtDocumento_MouseLeave(object sender, EventArgs e)
        {
            if (txtDocumento.Text == string.Empty)
            {
                txtDocumento.Text = "00000";
            }
        }

        private void dgvDetalleFactura_KeyDown(object sender, KeyEventArgs e)
        {
            //AL SELECCIONAR Y PRESIONAR SUPR-DEL SE ELIMINAR UN REGISTRO DEL DATAGRID
            if (e.KeyCode==Keys.Delete)
            {
                try
                {
                    EliminarItem();
                }
                catch (Exception ex)
                {
                    MensajeError($"Error: {ex.Message}");
                }
            }
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void dgvDetalleFactura_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*try
            {
                for (int i = 0; i < dgvDetalleFactura.Rows.Count; i++)
                {
                    this.dgvDetalleFactura["Item", i].ReadOnly = true;
                    this.dgvDetalleFactura["ItemNro", i].ReadOnly = true;
                    this.dgvDetalleFactura["Precio", i].ReadOnly = true;
                    this.dgvDetalleFactura["PrecioFinal", i].ReadOnly = true;
                    this.dgvDetalleFactura["IVA", i].ReadOnly = true;
                    this.dgvDetalleFactura["PorcentajeIVA", i].ReadOnly = true;
                    this.dgvDetalleFactura["BaseImponible", i].ReadOnly = true;
                    this.dgvDetalleFactura["SubTotalDescuento", i].ReadOnly = true;
                    this.dgvDetalleFactura["SubtotalIVA", i].ReadOnly = true;
                    this.dgvDetalleFactura["SubTotalGravadas", i].ReadOnly = true;
                    this.dgvDetalleFactura["SubTotal", i].ReadOnly = true;
                    this.dgvDetalleFactura["UsuarioNro", i].ReadOnly = true;
                    this.dgvDetalleFactura["Empleado", i].ReadOnly = true;
                    this.dgvDetalleFactura["ComisionServicio", i].ReadOnly = true;
                    this.dgvDetalleFactura["Ganancia", i].ReadOnly = true;
                    this.dgvDetalleFactura["Cantidad", i].ReadOnly = true;
                    this.dgvDetalleFactura["Descuento", i].ReadOnly = true;
                }
            }
            catch (Exception)
            {

                throw;
            }*/
           
        }

        private void txtNroFactura_Validating(object sender, CancelEventArgs e)
        {
            errorIcono.Clear();
            string pattern = @"^\d{13}$";
            string input = txtNroFactura.Text.Replace("-", ""); // Ignorar los guiones durante la validación
            if (Ind_Autoimprenta =="N")
            {
                if (!Regex.IsMatch(input, pattern))
                {
                    MessageBox.Show("El valor ingresado no cumple con el formato requerido.");
                    errorIcono.SetError(txtNroFactura, "Ingrese el numero de factura debe de tener 13 números (XXX-XXX-XXXXXXX)");
                    FormatoCorrectoFactura = false;
                    e.Cancel = true; // Cancelar la validación para mantener el foco en el TextBox
                }
                else
                {
                    // Formatear el número de seguro social
                    txtNroFactura.Text = input.Substring(0, 3) + "-" + input.Substring(3, 3) + "-" + input.Substring(6, 7);
                    FormatoCorrectoFactura = true;
                }
            }
        }
    }
}
