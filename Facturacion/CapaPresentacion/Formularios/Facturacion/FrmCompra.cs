using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Formularios.ChildForms;
using CapaPresentacion.Informes.DsReporteTableAdapters;
using CapaPresentacion.Utilidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace CapaPresentacion.Formularios.Facturacion
{
    public partial class FrmCompra : Form
    {
        private bool IsNuevo;
        private DataTable Dtdetalle;
        private DataRow row;
        private double Total = 0;
        private double SubTotal = 0;
        private double SubtotalIVA = 0;
        private double SubTotalGravadas = 0;
        private int dias = 0;
        private int IdCompra = 0;
        private int CodProveedor = 0;
        private int CodTipoImpuesto = 0;
        
        int establecimiento = 0;
        int puntoExpedicion = 0;
        int numero = 0;
        int codTipoPago = 0;


        //atributos para obtener al usuario
        public string id;
        public string usuario;
        public string nombre;
        public string apellido;
        public string acceso; 
        

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmCompra _Instancia;

        public static FrmCompra GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmCompra();
            }
            return _Instancia;
        }

        public FrmCompra()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(txtProveedor, "Seleccione el proveedor");
            this.ttMensaje.SetToolTip(txtNroFactura, "Ingrese el numero de factura");
            this.ttMensaje.SetToolTip(dtpFecha, "Ingrese la fecha de Compra");
            this.ttMensaje.SetToolTip(cboTipoPago, "Seleccione el tipo de pago");
            this.ttMensaje.SetToolTip(txtProducto, "Seleccione el articulo");
            this.ttMensaje.SetToolTip(btnBuscarProducto, "Click para buscar el producto");
            this.ttMensaje.SetToolTip(btnBuscarProveedor, "Click para buscar al proveedor");
            this.ttMensaje.SetToolTip(btnAgregar, "Click para agregar el producto al carrito");
            this.ttMensaje.SetToolTip(btnQuitar, "Click para quitar el producto del carrito");
            this.ttMensaje.SetToolTip(btnGuardar, "Click para guardar la Venta");
            this.ttMensaje.SetToolTip(btnNuevo, "Cick para iniciar una nueva Factura");
            this.ttMensaje.SetToolTip(btnCancelar,"Click para cancelar la Factura");            
            this.txtCodProducto.ReadOnly = true;
            this.txtProducto.ReadOnly = true;
            this.txtProveedor.ReadOnly = true;
            this.txtUnidadMedida.ReadOnly = true;
            this.txtPrecioCompra.ReadOnly = true;
            this.txtCantidad.ReadOnly = true;
            this.txtIva.ReadOnly = true;            
            LlenarCombos();
        }

        private void MedidaColumna(DataGridView dg)
        {
            dg.Columns["Nro"].Width = 35;
            dg.Columns["Producto"].Width = 240;
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

            //CENTRAR TEXTO EN LA COLUMNA
            dg.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns["IVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;            
            dg.Columns["SubtotalIVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns["SubtotalNeto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

        }


        //identificar con rojo las Compras anuladas
        public void CompraAnulada() {
            for (int i = 0; i< dataListado.Rows.Count; i++) {
                String estado = Convert.ToString(dataListado.Rows[i].Cells["Estado"].Value);
                if(estado.Equals("ANULADO")) {
                    dataListado.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }


        public void SoloNumeros(KeyPressEventArgs e) {
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

        private void DataGridDiseno()
        {
            dataListado.BorderStyle = BorderStyle.None;
            dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataListado.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataListado.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dataListado.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataListado.BackgroundColor = Color.White;

            dataListado.EnableHeadersVisualStyles = false;
            dataListado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataListado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataListado.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            
        }




        //Obtener los datos del proveedor
        public void ObtenerProveedor(string personaNro,string documento,string nombre) {
            this.CodProveedor = Convert.ToInt32(personaNro);
            this.txtProveedor.Text = nombre;
            this.txtDocumento.Text = documento;
        }

        //Obtener los datos del producto
        public void ObtenerProducto(DProducto producto) {
            this.txtCodProducto.Text = producto.ProductoNro.ToString();
            this.txtProducto.Text = producto.Descripcion;
            this.txtUnidadMedida.Text = producto.UnidadMedida.Descripcion;
            this.txtPrecioCompra.Text = producto.PrecioCompra.ToString("N0");
            this.txtIva.Text = producto.TipoImpuesto.Descripcion;
            this.CodTipoImpuesto = producto.TipoImpuesto.TipoImpuestoNro;
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
            
            this.txtNroFactura.Text = string.Empty;
            this.CodProveedor = 0;
            this.txtNroTimbrado.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;
            this.txtDias.Text = string.Empty;                     
            this.txtObservacion.Text = string.Empty;
            this.txtTotalGravadas.Text = string.Empty;           
            this.txttotalIva.Text = string.Empty;
            this.txtTotalGral.Text = string.Empty;            
            this.CrearTabla();
        }

        private void LimpiarDetalle()
        {
            this.txtProducto.Text = string.Empty;
            this.txtCodProducto.Text = string.Empty;
            this.txtUnidadMedida.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtIva.Text = string.Empty;
        }

        private void LlenarCombos()
        {               
            cboTipoPago.DataSource = NTipoPago.Mostrar();
            cboTipoPago.DisplayMember = "Descripcion";
            cboTipoPago.ValueMember = "CodTipoPago";

            cboComprobante.DataSource = NTipoComprobante.MostrarTipoComprobante();
            cboComprobante.DisplayMember = "Nombre";
            cboComprobante.ValueMember = "ComprobanteNro";
        }


        private void CrearTabla() {
            this.Dtdetalle = new DataTable("Detalle");
            this.Dtdetalle.Columns.Add("Nro", System.Type.GetType("System.Int32"));
            this.Dtdetalle.Columns.Add("ProductoNro", System.Type.GetType("System.Int32"));
            this.Dtdetalle.Columns.Add("Producto", System.Type.GetType("System.String"));
            this.Dtdetalle.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
            this.Dtdetalle.Columns.Add("Precio", System.Type.GetType("System.Double"));
            this.Dtdetalle.Columns.Add("CodTipoImpuesto", System.Type.GetType("System.Int32"));
            this.Dtdetalle.Columns.Add("IVA", System.Type.GetType("System.String"));
            this.Dtdetalle.Columns.Add("PorcentajeIVA", System.Type.GetType("System.Int32"));
            this.Dtdetalle.Columns.Add("BaseImponible", System.Type.GetType("System.Double"));

            this.Dtdetalle.Columns.Add("SubtotalIVA", System.Type.GetType("System.Double"));
            this.Dtdetalle.Columns.Add("SubTotalNeto", System.Type.GetType("System.Double"));
            this.Dtdetalle.Columns.Add("SubTotal", System.Type.GetType("System.Double"));

            this.Dtdetalle.Columns.Add("NroCompra", System.Type.GetType("System.Int32"));

            //relacion con el datagridview
            this.dgvDetalleCompra.DataSource = this.Dtdetalle;
            OrdenarColumnas();
        }


        private void OrdenarColumnas() 
        {
            dgvDetalleCompra.Columns["Nro"].DisplayIndex = 0;
            dgvDetalleCompra.Columns["ProductoNro"].DisplayIndex = 1;
            dgvDetalleCompra.Columns["Producto"].DisplayIndex = 2;
            dgvDetalleCompra.Columns["Cantidad"].DisplayIndex = 3;
            dgvDetalleCompra.Columns["Precio"].DisplayIndex = 4;
            dgvDetalleCompra.Columns["CodTipoImpuesto"].DisplayIndex = 5;
            dgvDetalleCompra.Columns["IVA"].DisplayIndex = 6;
            dgvDetalleCompra.Columns["PorcentajeIVA"].DisplayIndex = 7;
            dgvDetalleCompra.Columns["BaseImponible"].DisplayIndex = 8;
            dgvDetalleCompra.Columns["SubtotalIVA"].DisplayIndex = 9;
            dgvDetalleCompra.Columns["SubTotalNeto"].DisplayIndex = 10;
            dgvDetalleCompra.Columns["SubTotal"].DisplayIndex = 11;
            dgvDetalleCompra.Columns["NroCompra"].DisplayIndex = 11;

        }
        
        //Habilitar botones
        private void Habilitar(bool valor)
        {
           
            this.txtNroFactura.ReadOnly = !valor;            
            this.txtProveedor.ReadOnly = !valor;
            this.txtDocumento.ReadOnly = !valor;
            this.txtNroTimbrado.ReadOnly = !valor;
            this.dtpFecha.Enabled = valor;            
            this.txtObservacion.ReadOnly = !valor;
            this.txtProducto.ReadOnly= !valor;
            this.txtCodProducto.ReadOnly = !valor;
            this.txtUnidadMedida.ReadOnly = valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtIva.ReadOnly = !valor;
            this.cboTipoPago.Enabled = valor;
            this.txtObservacion.ReadOnly = !valor;            
            this.txtDias.ReadOnly = !valor;
            this.dtpFechaVenc.Enabled = valor;
            this.cboTipoPago.Enabled = valor;
            this.cboComprobante.Enabled = valor;
            this.btnBuscarProducto.Enabled = valor;
            this.btnBuscarProveedor.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
            this.txtDias.Visible = !valor;
            this.dtpFechaVenc.Visible = !valor;
            this.lblVencimiento.Visible = !valor;
            this.lbldias.Visible = !valor;
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                //this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                //this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        

        //ocultar columnas
        private void OcultarColumnas()
        {
            if (dataListado.Rows.Count ==0)
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

        private void OcultarColumnasDetalle()
        {
            try
            {
                this.dgvDetalleCompra.Columns["NroCompra"].Visible = false;
                this.dgvDetalleCompra.Columns["ProductoNro"].Visible = false;
                this.dgvDetalleCompra.Columns["BaseImponible"].Visible = false;
                this.dgvDetalleCompra.Columns["CodTipoImpuesto"].Visible = false;
                this.dgvDetalleCompra.Columns["PorcentajeIVA"].Visible = false;


            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            this.dataListado.DataSource = NCompra.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            
        }

        //Metodo buscar por fechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NCompra.BuscarCompraFecha(this.dtpFechadesde.Value.ToString("yyyy-MM-dd"),dtpfechahasta.Value.ToString("yyyy-MM-dd"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        //Metodo buscar por detalle
        private void MostrarDetalle()
        {
            try
            {
                this.dgvDetalleCompra.DataSource = NCompra.MostarDetalle(IdCompra);
                OrdenarColumnas();
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
            
        }


        private void FrmCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {
        try 
        {      
                this.Top = 0;
                this.Left = 0;
                this.Mostrar();
                this.Habilitar(false);
                this.Botones();
                this.CrearTabla();
                this.OcultarColumnasDetalle();
                this.cboComprobante.SelectedIndex = 0;
                this.cboTipoPago.SelectedIndex = 0;

                this.dtpFechadesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                this.MedidaColumna(dgvDetalleCompra);
            }
            catch(Exception ex) 
        {
                MessageBox.Show(ex.Message); 
        }   

        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            FrmVistaProveedor frmproveedor = new FrmVistaProveedor();
            frmproveedor.ShowDialog();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmVistaProducto frmvista = new FrmVistaProducto();
            frmvista.ShowDialog();
            this.txtCantidad.Focus();
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



        //ANULAR COMPRA
        private void btnEliminar_Click(object sender, EventArgs e)
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


                DialogResult opcion;
                opcion = MessageBox.Show("Desea eliminar la Compra ?" + Environment.NewLine + " El Stock volverá a restaurarse!", "Sistema de Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.No)
                    return;

                int codigo;
                string rpta = "";
                //recorrer el datagrip para eliminar mas de un registro
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {                        
                        codigo = Convert.ToInt32(row.Cells["NroCompra"].Value);
                        //Eliminar Compra
                        rpta = NCompra.EliminarCompra(codigo);
                    }
                }
                //mensaje a mostrar
                if (rpta.Equals("OK"))
                {
                    this.MensajeOK("Se eliminó correctamente el registro");
                }
                else
                {
                    this.MensajeError($"Ocurrio un error: {rpta}");
                    return;
                }
                this.Mostrar();
                this.chkEliminar.Checked = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkAnular_CheckedChanged(object sender, EventArgs e)
        {
        //SI EL CHECKBOX ANULAR ESTA ACTIVO ENTONCES SE MUESTRA EN EL DATAGRID
            if (chkEliminar.Checked == true)
            {
                btnEliminar.Enabled = true;                
                this.dataListado.Columns[0].Visible = true;
            }
        //SINO ,SE OCULTA
            else
            {                
                btnEliminar.Enabled = false;                
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
                {
                    DataGridViewCheckBoxCell chkAnularDV = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                    chkAnularDV.Value = !Convert.ToBoolean(chkAnularDV.Value);
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
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
            this.txtDias.Text = dias.ToString();
            this.OcultarColumnasDetalle();
            this.txtNroFactura.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Limpiar();
            this.Habilitar(false);
            this.Botones();
            this.LimpiarDetalle();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (!Validaciones())
                {
                    return;
                }


                //Obtener la numeración de la factura por separado
                string[] chars = txtNroFactura.Text.Split('-', ' ');
                if (chars.Count() == 3)
                {
                    int.TryParse(chars[0], out establecimiento);
                    int.TryParse(chars[1], out puntoExpedicion);
                    int.TryParse(chars[2], out numero);
                }

                codTipoPago = Convert.ToInt32(this.cboTipoPago.SelectedValue);

                DCompra compra = new DCompra()
                {
                    Id = IdCompra,
                    Proveedor = new DProveedor()
                    {
                        PersonaNro = CodProveedor,
                        RazonSocial = this.txtProveedor.Text,
                    },
                    Fecha = this.dtpFecha.Value,
                    TipoPago = new DTipoPago()
                    {
                        FormaPago = Convert.ToInt32(this.cboTipoPago.SelectedValue),
                        Descripcion = this.cboTipoPago.Text
                    },
                    CantCuotas = codTipoPago == 2 ? Convert.ToInt32(this.txtDias.Text) : (int?)null,
                    FechaVencimiento = dtpFechaVenc.Visible ? dtpFechaVenc.Value : (DateTime?)null,
                    TipoComprobate = new DTipoComprobante()
                    {
                        ComprobanteNro = Convert.ToInt32(cboComprobante.SelectedValue),
                        Nombre = cboComprobante.Text
                    },
                    Establecimiento = establecimiento,
                    PuntoExpedicion = puntoExpedicion,
                    Numero = numero,
                    NroTimbrado = txtNroTimbrado.Text,
                    NroFacturaCompra = txtNroFactura.Text,
                    Estado = "EMITIDO",
                    Observacion = txtObservacion.Text,
                    Usuario = id
                };


                rpta = NCompra.Insertar(compra, Dtdetalle);
                if (!rpta.Contains("OK"))
                {
                    this.MensajeError(rpta);
                    return;
                }

                IdCompra = Convert.ToInt32(rpta.Split(';')[0]);
                NCompra.CuentaAPagar(IdCompra);

                this.MensajeOK("La operación ha finalizado con éxito");

                this.IsNuevo = false;
                this.Botones();
                this.Limpiar();
                this.LimpiarDetalle();
                this.Mostrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private bool Validaciones() 
        {
            errorIcono.Clear();

            #region Validaciones
            if (!this.txtNroFactura.MaskCompleted)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtNroFactura, "Ingrese el Numero de factura según el formato");
                return false;
            }

            if (string.IsNullOrEmpty(txtNroTimbrado.Text))
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtNroFactura, "Favor ingrese el nro. de Timbrado de la Factura");
                return false;
            }

            if (this.CodProveedor == 0)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtProveedor, "Ingrese el proveedor");
                return false;
            }

            if (dgvDetalleCompra.Rows.Count == 0)
            {
                this.MensajeError("No existen registros en el detalle");
                return false;
            }

            if (codTipoPago == 2)
            {
                if (string.IsNullOrEmpty(txtDias.Text))
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtDias, "La Operación es a Crédito, favor ingrese el día a pagar");
                    return false;
                }
            }


            #endregion

            return true;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            double iva = 0;
            double gravada = 0;
            double exento = 0;
            double SubTotal = 0;

            try
            {
                if (!ValidacionesItems())
                {
                    return;
                }
                bool registrar = true;

                foreach (DataRow row in Dtdetalle.Rows)
                {
                    if (Convert.ToInt32(row["ProductoNro"]) == Convert.ToInt32(txtCodProducto.Text))
                    {
                        registrar = false;
                        this.MensajeError("Ya se agregó el Producto");
                    }
                }

                if (registrar == true)
                {
                    //agregar en el detalle
                    DataRow row = this.Dtdetalle.NewRow();
                    row["ProductoNro"] = Convert.ToInt32(txtCodProducto.Text);
                    row["Producto"] = txtProducto.Text;                    
                    row["IVA"] = txtIva.Text;
                    row["Cantidad"] = Convert.ToInt32(txtCantidad.Text);


                    row["CodTipoImpuesto"] = CodTipoImpuesto;
                    row["Precio"] = txtPrecioCompra.Text;
                    SubTotal = Convert.ToDouble(row["Precio"]) * Convert.ToInt32(row["Cantidad"]);
                    row["Subtotal"] = SubTotal;
                    gravada = NFactura.DesglosarImportesIVA(SubTotal, CodTipoImpuesto, 0, "GRAV");
                    exento = NFactura.DesglosarImportesIVA(SubTotal, CodTipoImpuesto, 0, "EXEN");
                    iva = NFactura.DesglosarImportesIVA(SubTotal, CodTipoImpuesto, 0, "IVA");
                    row["SubTotalNeto"] = gravada + exento;
                    row["SubtotalIVA"] = iva;

                    
                    this.dgvDetalleCompra.DataSource = this.Dtdetalle;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ReenumerarItems()
        {
            for (int i = 0; i < Dtdetalle.Rows.Count; i++)
            {
                Dtdetalle.Rows[i]["Nro"] = i + 1;
            }

        }


        private bool ValidacionesItems() 
        {
            errorIcono.Clear();
            if (this.txtProducto.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtProducto, "No existe ningún producto para agregar.");
                this.btnBuscarProducto.Focus();
                return false;
            }

            if (this.txtPrecioCompra.Text == string.Empty || Convert.ToInt64(this.txtPrecioCompra.Text.Replace(".","")) == 0 )
            {
                if (!ControlesCompartidos.MensajeConfirmacion(this,"El precio ingresado es nulo o Cero. Desea continuar ?"))
                {                    
                    errorIcono.SetError(txtPrecioCompra, "Precio: 0");
                    txtPrecioCompra.Text = "0";
                    this.txtPrecioCompra.Focus();
                    return false;
                }
            }

            if (this.txtCantidad.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtCantidad, "Ingrese la cantidad");
                this.txtCantidad.Focus();
                return false;
            }

            if (Convert.ToInt32(this.txtCantidad.Text) <= 0)
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
                if (dgvDetalleCompra.CurrentCell == null)
                {
                    MensajeError("No existe item para eliminar");
                    return;
                }

                int indiceFila = dgvDetalleCompra.CurrentCell.RowIndex;
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
                this.dgvDetalleCompra.DataSource = this.Dtdetalle;
                ReenumerarItems();

            }
            catch(Exception)
            {
                MensajeError("No existe fila para eliminar");
            }
        }

        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(cboTipoPago.SelectedIndex==1) {
                this.txtDias.Visible = true;
                this.lbldias.Visible = true;
                this.lblVencimiento.Visible = true;
                this.dtpFechaVenc.Visible = true;
            }
            else
            {
                this.txtDias.Visible = false;
                this.lbldias.Visible = false;
                this.lblVencimiento.Visible = false;
                this.dtpFechaVenc.Visible = false;
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataListado.Rows.Count == 0)
                    return;

                IdCompra = Convert.ToInt32(this.dataListado.CurrentRow.Cells["NroCompra"].Value);
                this.CodProveedor = Convert.ToInt32(this.dataListado.CurrentRow.Cells["PersonaNro"].Value);
                this.txtDocumento.Text = (this.dataListado.CurrentRow.Cells["Documento"].Value).ToString();
                this.txtProveedor.Text = (this.dataListado.CurrentRow.Cells["Proveedor"].Value).ToString();
                this.txtNroFactura.Text = (this.dataListado.CurrentRow.Cells["NroFacturaCompra"].Value).ToString();
                this.cboComprobante.Text = (this.dataListado.CurrentRow.Cells["TipoComprobante"].Value).ToString();
                this.txtNroTimbrado.Text = (this.dataListado.CurrentRow.Cells["NroTimbrado"].Value).ToString();
                this.dtpFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha"].Value);
                this.cboTipoPago.Text = (this.dataListado.CurrentRow.Cells["TipoPago"].Value).ToString();
                this.txtDias.Text = (this.dataListado.CurrentRow.Cells["CantCuotas"].Value).ToString();
                //this.txtTotal.Text = (this.dataListado.CurrentRow.Cells["total"].Value).ToString();
                this.txttotalIva.Text = Convert.ToDouble(this.dataListado.CurrentRow.Cells["IVA"].Value).ToString("N0");
                this.txtTotalGravadas.Text = Convert.ToDouble(this.dataListado.CurrentRow.Cells["GRAVADA"].Value).ToString("N0");
                this.txtTotalGral.Text = Convert.ToDouble(this.dataListado.CurrentRow.Cells["Total"].Value).ToString("N0");
                this.MostrarDetalle();
                this.tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDias_Leave(object sender, EventArgs e)
        {
            //SE VERIFICA QUE LOS DIAS SEAN MAYOR A CERO PARA COMPRAS A CREDITO
           try {
                if (Convert.ToInt32(txtDias.Text) <= 0)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtDias, "Los dias no pueden ser menor o igual 0");
                }
                else
                {
                //SE SUMA EL DIA INGRESADO PARA CALCULAR LA FECHA DE VENCIMIENTO
                    dtpFechaVenc.Value = dtpFecha.Value.AddDays(int.Parse(txtDias.Text));
                }

            }catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
             
        }

        private void dataListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            this.CompraAnulada();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataListado.Columns["Total"].DefaultCellStyle.Format = "N0";
            this.dataListado.Columns["IVA"].DefaultCellStyle.Format = "N0";
            this.dataListado.Columns["Gravada"].DefaultCellStyle.Format = "N0";
            this.dataListado.Columns["Exento"].DefaultCellStyle.Format = "N0";
        }

        private void dgvDetalleCompra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvDetalleCompra.Columns["Precio"].DefaultCellStyle.Format = "N0";     
                this.dgvDetalleCompra.Columns["SubTotalNeto"].DefaultCellStyle.Format = "N0";
                this.dgvDetalleCompra.Columns["SubtotalIVA"].DefaultCellStyle.Format = "N0";
                this.dgvDetalleCompra.Columns["SubTotal"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception)
            {
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void FrmCompra_KeyUp(object sender, KeyEventArgs e)
        {
            if(this.btnBuscarProveedor.Enabled==true && e.KeyCode==Keys.F2) 
            {
                this.btnBuscarProveedor_Click(null, null);
            }
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtDocumento.Text != string.Empty)
                {
                    DataTable tablaProveedor = NProveedor.BuscarProveedor("R",txtDocumento.Text);

                   
                    if (tablaProveedor.Rows.Count == 0)
                    {
                        if (!ControlesCompartidos.MensajeConfirmacion(this, "No existe el Proveedor registrado en la Base de Datos"))
                            return;

                        //FrmConsultaRUC consultaRuc = new FrmConsultaRUC(txtDocumento.Text, this);
                        //FrmConsultaRUC consultaRuc = new FrmConsultaRUC();
                        //consultaRuc.ShowDialog();
                    }

                    this.txtProveedor.Text = tablaProveedor.Rows[0]["RazonSocial"].ToString();
                    this.CodProveedor = Convert.ToInt32(tablaProveedor.Rows[0]["ProveedorNro"]);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No existe el Proveedor");
                this.txtDocumento.Text = string.Empty;
            }
        }


        public void AsignarDatos(params object[] datos)
        {
            var registro = (DRuc)datos[0];

            txtDocumento.Text = registro.Ruc;
            txtProveedor.Text = registro.RazonSocial;
            // Asigna aquí los valores de los controles correspondientes
        }

        private void txtDias_TextChanged(object sender, EventArgs e)
        {
            int dias = 0;
            if (string.IsNullOrEmpty(txtDias.Text) && !int.TryParse(txtDias.Text, out dias))
            {
                MensajeError("Favor ingrese la cantidad de días");
            }

            var fechaVencimiento = DateTime.Now.AddDays(dias);
            dtpFechaVenc.Value = fechaVencimiento;
        }
    }
}
