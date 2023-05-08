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
using CapaPresentacion.Formularios.ChildForms;

namespace CapaPresentacion.Formularios.Mantenimiento
{
    public partial class FrmOrdenTrabajo : Form
    {
        private bool IsNuevo;
        private bool IsEditar;
        private int total = 0;


        private DataRow row;
        double ganancia = 0;

        public int id;
        public string usuario;
        public string nombre;
        public string apellido;
        public string acceso;


        private DataTable Dtdetalle;


        private static FrmOrdenTrabajo _Instancia;
        public static FrmOrdenTrabajo GetInstancia() {
            if(_Instancia==null) {
                _Instancia = new FrmOrdenTrabajo();
            }
            return _Instancia;
        }


        public FrmOrdenTrabajo()
        {
            InitializeComponent();
            
            this.ttMensaje.SetToolTip(btnNuevo,"Click para crear una nueva OT");
            this.ttMensaje.SetToolTip(btnGuardar, "Click para guardar la OT");
            this.ttMensaje.SetToolTip(btnCancelar, "Click para cancelar la OT");
            this.ttMensaje.SetToolTip(btnBuscarCliente, "Click para buscar un cliente");
            this.ttMensaje.SetToolTip(btnAgregar, "Click para agregar el item al listado");
            this.ttMensaje.SetToolTip(btnQuitar, "Click para quitar el item");
            this.ttMensaje.SetToolTip(btnBuscarItem, "Click para buscar el item");
            this.ttMensaje.SetToolTip(dtpFecha, "Ingrese la fecha-Hora de la OT");
            this.ttMensaje.SetToolTip(txtObservacion, "Inserte una observacion");

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


        //metodo para el ingreso de solo numeros
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
            dataListado.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dataListado.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataListado.BackgroundColor = Color.White;

            dataListado.EnableHeadersVisualStyles = false;
            dataListado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataListado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataListado.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

       /* private void MedidaColumnas(DataGridView dg) 
        {
            dg.Columns["ServicioNro"].Width = 100;
            dg.Columns["Servicio"].Width = 200;
        }*/

   


        //Obtener los datos del Cliente
        public void ObtenerCliente(string clienteNro, string documento,string nombre, string apellido)
        {
            //this.txtClienteNro.Text = clienteNro;
            this.txtDocumento.Text = documento;
            this.txtCliente.Text = nombre + " " + apellido;
        }


        //Obtener los datos del Servicio desde el formulario VistaServicio
        public void ObtenerServicio(string codigo, string descripcion,string PrecioMinorista,string iva, string divisor, string gravadas,string comision)
        {
            this.txtCodItem.Text = codigo;
            this.txtItem.Text = descripcion;
            this.txtPrecio.Text = PrecioMinorista;
            //this.txtComisionServicio.Text = comision;
              //  this.txtIva.Text = iva;
              //his.txtDivisor.Text = divisor;
               // this.txtGravadas.Text = gravadas;
        }

        public void ObtenerEmpleado(string usuarionro,string nombre) 
        {

            //this.txtUsuarioNro.Text = usuarionro;
            this.txtUsuarioNombre.Text = nombre;
        }


        //Limpiar los controles del formulario
        private void Limpiar()
        {
            //this.txtCodigo.Text = string.Empty;
            this.txtNumeracion.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;
            //this.txtDias.Text = string.Empty;
            //this.txtClienteNro.Text = string.Empty;
            this.txtCliente.Text = string.Empty;            
            this.txtObservacion.Text = string.Empty;            
            //this.txtFormula.Text = string.Empty;
            this.lbltotalgral.Text = 0.ToString();
            //this.dtpFechaVisita.Value = DateTime.Now;
            this.dtpFecha.Value = DateTime.Now;
            this.CrearTabla();
        }

        private void LimpiarDetalle()
        {
            this.txtItem.Text = string.Empty;
            this.txtCodItem.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            //this.txtUsuarioNro.Text = string.Empty;
            this.txtUsuarioNombre.Text = string.Empty;            
            //this.txtIva.Text = string.Empty;
        }

        private void CrearTabla()
        {
            this.Dtdetalle = new DataTable("Detalle");

            this.Dtdetalle.Columns.Add("ItemNro", System.Type.GetType("System.Int32"));
            this.Dtdetalle.Columns.Add("Servicio", System.Type.GetType("System.String"));
            this.Dtdetalle.Columns.Add("UsuarioNro", System.Type.GetType("System.Int32"));
            this.Dtdetalle.Columns.Add("Empleado", System.Type.GetType("System.String"));            
            this.Dtdetalle.Columns.Add("Precio", System.Type.GetType("System.Decimal"));
            this.Dtdetalle.Columns.Add("ComisionServicio", System.Type.GetType("System.Decimal"));
            this.Dtdetalle.Columns.Add("Ganancia", System.Type.GetType("System.Decimal"));
            //relacion con el datagridview
            this.dgvDetalleOT.DataSource = this.Dtdetalle;
        }

        //Habilitar botones
        private void Habilitar(bool valor)
        {
            //this.txtCodigo.ReadOnly = valor;
           // this.txtNumeracion.ReadOnly = !valor;
            this.txtCliente.ReadOnly = !valor;
            this.txtDocumento.ReadOnly = !valor;
            this.dtpFecha.Enabled = valor;
            this.txtObservacion.ReadOnly = !valor;
            //this.txtFormula.ReadOnly = !valor;            
            this.txtItem.ReadOnly = valor;
            this.txtCodItem.ReadOnly = valor;
            this.txtObservacion.ReadOnly = !valor;
            btnBuscarItem.Enabled = valor;
            btnBuscarCliente.Enabled = valor;
            btnAgregar.Enabled = valor;
            btnQuitar.Enabled = valor;
           //dtpFechaVisita.Checked = false;
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        //ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns["NroOT"].Visible = false;
            this.dataListado.Columns["NroUsuarioInsercion"].Visible = false;
        }

        private void OcultarColumnasDetalle()
        {
            this.dgvDetalleOT.Columns["ItemNro"].Visible = false;
            this.dgvDetalleOT.Columns["UsuarioNro"].Visible = false;
        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            this.dataListado.DataSource = NOrdenTrabajo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Metodo buscar por fechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NOrdenTrabajo.BuscarOTFecha(this.dtpFechadesde.Value.ToString("dd/MM/yyyy HH:mm"), dtpfechahasta.Value.ToString("dd/MM/yyyy HH:mm"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        //Metodo buscar por detalle
        private void MostrarDetalle()
        {
            total = 0;
            try
            {
                //this.dgvDetalleOT.DataSource = NOrdenTrabajo.MostrarDetalle(Convert.ToInt32(this.txtCodigo.Text));
                this.dgvDetalleOT.Columns["ServicioNro"].Visible = false;
                foreach (DataGridViewRow datarow in dgvDetalleOT.Rows)
                {
                    row = this.Dtdetalle.NewRow();
                    row["ItemNro"] = Convert.ToInt32(datarow.Cells["ServicioNro"].Value);
                    row["Servicio"] = datarow.Cells["Servicio"].Value;
                    row["UsuarioNro"] = Convert.ToInt32(datarow.Cells["UsuarioNro"].Value);
                    row["Empleado"] = datarow.Cells["Empleado"].Value;
                    row["Precio"] = Convert.ToDouble(datarow.Cells["Precio"].Value);
                    row["ComisionServicio"] = Convert.ToDouble(datarow.Cells["ComisionServicio"].Value);

                    ganancia = Convert.ToDouble(row["Precio"]) * (Convert.ToDouble(row["ComisionServicio"]) / 100);

                    row["Ganancia"] = ganancia.ToString("N0");
                    this.Dtdetalle.Rows.Add(row);
                    total = total + Convert.ToInt32(row["Precio"]);
                    lbltotalgral.Text = total.ToString("N0");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void FrmOrdenTrabajo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void FrmOrdenTrabajo_Load(object sender, EventArgs e)
        {
            DataGridDiseno();
            if (chkEliminar.Checked == false)
            {
                btnEliminar.Enabled = false;
            }
                     
            this.Mostrar();          
            this.Habilitar(false);
            this.Botones();
            this.CrearTabla();
            this.OcultarColumnas();
            this.OcultarColumnasDetalle();           
        }

        private void btnBuscarItem_Click(object sender, EventArgs e)
        {
            FrmVistaServicio frmitem = FrmVistaServicio.GetInstancia();
            frmitem.ShowDialog();
            this.txtPrecio.Focus();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVistaClienteOT frmCliente = FrmVistaClienteOT.GetInstancia();
            frmCliente.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtItem.Text == string.Empty )
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtItem, "Ingrese el item");                    
                    btnBuscar.Focus();

                }
                /*else if (this.txtUsuarioNro.Text==string.Empty)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtUsuarioNombre, "Asigne el servicio a un empleado");
                    btnBuscar.Focus();
                }*/
                else
                {
                    bool registrar = true;
                    errorIcono.Clear();

                    foreach (DataRow row in Dtdetalle.Rows)
                    {
                        /*if (Convert.ToInt32(row["ItemNro"]) == Convert.ToInt32(txtCodItem.Text) && Convert.ToInt32(row["UsuarioNro"]) == Convert.ToInt32(txtUsuarioNro.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se agregó el Item");
                        }*/
                    }
                    if (registrar)
                    {
                        //agregar en el detalle
                        row = this.Dtdetalle.NewRow();
                        row["ItemNro"] = Convert.ToInt32(txtCodItem.Text);
                        row["Servicio"] = txtItem.Text;
                        //row["UsuarioNro"] = txtUsuarioNro.Text;
                        row["Empleado"] = txtUsuarioNombre.Text;
                        row["Precio"] = txtPrecio.Text;
                        //row["ComisionServicio"] = txtComisionServicio.Text;

                        ganancia = Convert.ToDouble(row["Precio"]) * (Convert.ToDouble(row["ComisionServicio"]) / 100);

                        row["Ganancia"] = ganancia.ToString("N0");


                        this.dgvDetalleOT.DataSource =this.Dtdetalle;
                        this.Dtdetalle.Rows.Add(row);
                        this.LimpiarDetalle();

                        //total
                        total = total + Convert.ToInt32(row["Precio"]);
                        lbltotalgral.Text = total.ToString("N0");
                    }
                    
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = dgvDetalleOT.CurrentCell.RowIndex;
                row = Dtdetalle.Rows[indiceFila];

                dgvDetalleOT.DataSource = this.Dtdetalle;

                //total
                total = total - Convert.ToInt32(row["Precio"]);
                lbltotalgral.Text = total.ToString("N0");

                //eliminamos la fila
                this.Dtdetalle.Rows.Remove(row);
            }
            catch (Exception)
            {
                MensajeError("No existe fila para eliminar");
            }
        }

        private void ObtenerNumeracion() 
        {
            try
            {
                //Obtener la siguiente numeracion de la OT de trabajo
                DataTable dt = new DataTable();
                dt = NOrdenTrabajo.MostrarNumeracion();
                this.txtNumeracion.Text = dt.Rows[0]["Correlativo"].ToString();
            }
            catch (Exception ex)
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
            this.txtNumeracion.Focus();
            this.LimpiarDetalle();
            ObtenerNumeracion();
            this.OcultarColumnasDetalle();
            //gbAviso.Visible = true;
            

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int NroOT = 0;
            try
            {
                string rpta = "";
               

                /*if (this.txtClienteNro.Text == string.Empty)
                {
                    this.MensajeError("Falta algunos datos");
                    txtDocumento.Focus();
                    errorIcono.SetError(txtDocumento, "Ingrese el proveedor");
                }*/
                /*else if (txtFormula.Text!=string.Empty && txtDias.Text==string.Empty)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtDias, "Ingrese los dias de la proxima visita");
                }*/
                if (dgvDetalleOT.Rows.Count == 0)
                {
                    this.MensajeError("No existen items");
                }
                else
                {
                    //si se ingresa un nuevo registro
                    if (this.IsNuevo)
                    {
                        //rpta = NOrdenTrabajo.Insertar(this.dtpFecha.Value, Convert.ToInt32(this.txtClienteNro.Text), this.txtFormula.Text.Trim().ToUpper(), this.txtDias.Text == string.Empty? (Int32?)null:Convert.ToInt32(this.txtDias.Text),dtpFechaVisita.Checked==false? (DateTime?)null: dtpFechaVisita.Value,txtObservacion.Text.Trim().ToUpper(),id, usuario, Dtdetalle);
                        //si se esta editando el registro    
                    }
                    else 
                    {
                       // eliminar = NOrdenTrabajo.EliminarOT(Convert.ToInt32(txtCodigo.Text));
                        //rpta = NOrdenTrabajo.Editar(Convert.ToInt32(txtCodigo.Text), this.dtpFecha.Value, Convert.ToInt32(this.txtClienteNro.Text), this.txtFormula.Text.Trim().ToUpper(), this.txtDias.Text == string.Empty ? (Int32?)null : Convert.ToInt32(this.txtDias.Text), dtpFechaVisita.Checked == false ? (DateTime?)null : dtpFechaVisita.Value, txtObservacion.Text.Trim().ToUpper(), Dtdetalle);
                        //si se esta editando el registro     
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (IsNuevo)
                        {
                            this.MensajeOK("La Orden de trabajo se ha insertado con exito");                            

                            DialogResult opcion;
                            opcion = MessageBox.Show("Desea imprimir el comprobante ?", "Sistema de Facturacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (opcion == DialogResult.OK)
                            {
                                FrmInformeOT frm = new FrmInformeOT();
                                NroOT= Convert.ToInt32(this.txtNumeracion.Text);
                                frm.nroot = NroOT;
                                frm.ShowDialog();
                            }
                        }
                        else
                        {
                            this.MensajeOK("La Orden de trabajo se ha editado con exito");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.LimpiarDetalle();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Limpiar();
            this.Habilitar(false);
            this.Botones();
            this.LimpiarDetalle();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            /*if (!this.txtCodigo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
                this.gbAviso.Visible = true;
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a modificar");
            }*/
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            //SI EL CHECKBOX ELIMINAR ESTA ACTIVO ENTONCES SE MUESTRA EN EL DATAGRID
            if (chkEliminar.Checked == true)
            {
                this.btnEliminar.Enabled = true;
                this.dataListado.Columns[0].Visible = true;
            }
            //SINO SE OCULTA
            else
            {
                this.btnEliminar.Enabled = false;
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminarDV = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminarDV.Value = !Convert.ToBoolean(chkEliminarDV.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Desea eliminar la Orden de Trabajo ?", "Sistema de Facturacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {

                    string codigo;
                    //string proveedor;
                    string rpta = "";
                    //recorrer el datagrip para eliminar mas de un registro
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {   
                                codigo = Convert.ToString(row.Cells["NroOT"].Value);
                                rpta = NOrdenTrabajo.EliminarOT(Convert.ToInt32(codigo));
                        }
                    }
                    //mensaje a mostrar
                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOK("Se eliminó correctamente el registro");
                    }
                    this.Mostrar();
                    this.chkEliminar.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.Dtdetalle.Clear();
            try
            {
                //this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CodFactura"].Value);
                this.txtCliente.Text = (this.dataListado.CurrentRow.Cells["Cliente"].Value).ToString();
                //this.txtClienteNro.Text = (this.dataListado.CurrentRow.Cells["PersonaNro"].Value).ToString();
                this.txtDocumento.Text= (this.dataListado.CurrentRow.Cells["Documento"].Value).ToString();
                //this.txtCodigo.Text = (this.dataListado.CurrentRow.Cells["NroOT"].Value).ToString();
                this.txtNumeracion.Text = (this.dataListado.CurrentRow.Cells["Numeracion"].Value).ToString();
                this.dtpFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha"].Value);
                //this.txtFormula.Text = (this.dataListado.CurrentRow.Cells["Formula"].Value).ToString();
                //this.txtDias.Text = (this.dataListado.CurrentRow.Cells["Dias"].Value).ToString();

                /*if(this.dataListado.CurrentRow.Cells["FechaVisita"].Value!=DBNull.Value) 
                {
                    
                    this.dtpFechaVisita.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["FechaVisita"].Value);
                    this.gbAviso.Visible = true;
                }
                else
                {
                    this.gbAviso.Visible = false;
                }*/
                
                
                this.txtObservacion.Text = this.dataListado.CurrentRow.Cells["Observacion"].Value.ToString();
                this.lbltotalgral.Text=Convert.ToDouble(this.dataListado.CurrentRow.Cells["Total"].Value).ToString("N0");

                this.MostrarDetalle();
               // this.MedidaColumnas(dgvDetalleOT);
                this.tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
            if (dataListado.Rows.Count<=0)
            {
                lblSinRegistros.Visible = true;
            }
            else
            {
                lblSinRegistros.Visible = false;
            }
            

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataListado.CurrentRow == null)
                {
                    MensajeError("No ha seleccionado ningún registro");
                    return;
                }
                
                FrmInformeOT frm = new FrmInformeOT();
                int NroOT;
                NroOT = Convert.ToInt32 (this.dataListado.CurrentRow.Cells["Numeracion"].Value);
                frm.nroot = NroOT; 
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FrmOrdenTrabajo_KeyDown(object sender, KeyEventArgs e)
        {
            if(this.btnBuscarItem.Enabled==true && e.KeyCode==Keys.F5) 
            {
                this.btnBuscarItem_Click(null,null);
            }
        }

        private void txtDivisor_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDetalleOT_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dgvDetalleOT.Columns["Precio"].DefaultCellStyle.Format = "N0";
            this.dgvDetalleOT.Columns["Ganancia"].DefaultCellStyle.Format = "N0";
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtDocumento.Text != string.Empty)
                {
                    DataTable tablacliente = NCliente.MostrarTextbox(txtDocumento.Text);
                    //this.txtClienteNro.Text = tablacliente.Rows[0][0].ToString();
                    this.txtCliente.Text = tablacliente.Rows[0][1].ToString();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No existe el Cliente");
                this.txtDocumento.Text = string.Empty;                
            }
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataListado.Columns["Total"].DefaultCellStyle.Format = "N0";            
        }

        private void txtdias_Leave(object sender, EventArgs e)
        {
            
            try
            {
                /*if (Convert.ToInt32(txtDias.Text) <= 0)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtDias, "Los dias no pueden ser menor o igual 0");
                }
                else
                {
                    //SE SUMA EL DIA INGRESADO PARA CALCULAR LA FECHA DE VENCIMIENTO
                    dtpFechaVisita.Visible = true;
                    dtpFechaVisita.Value = dtpFechaVisita.Value.AddDays(int.Parse(txtDias.Text));                    
                }*/

            }
            catch (Exception)
            {
                
            }
        }

        private void FrmOrdenTrabajo_KeyUp(object sender, KeyEventArgs e)
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
                if (btnNuevo.Enabled == true && e.KeyCode == Keys.F1)
                {
                    this.btnNuevo_Click(null, null);
                }
                if (btnBuscarItem.Enabled == true && e.KeyCode == Keys.F5)
                {
                    btnBuscarItem_Click(null, null);
                }
                if (btnGuardar.Enabled == true && e.KeyCode == Keys.F4)
                {
                    btnGuardar_Click(null, null);
                }
                if (btnEditar.Enabled == true && e.KeyCode == Keys.F2)
                {
                    btnEditar_Click(null, null);
                }

            }
        }

        private void dgvDetalleOT_KeyDown(object sender, KeyEventArgs e)
        {
            //AL SELECCIONAR Y PRESIONAR SUPR-DEL SE ELIMINAR UN REGISTRO DEL DATAGRID
            if(btnAgregar.Enabled==true) 
            {
                if (e.KeyCode == Keys.Delete)
                {
                    btnQuitar_Click(null, null);
                }
            }
            
        }
    }
    
}
