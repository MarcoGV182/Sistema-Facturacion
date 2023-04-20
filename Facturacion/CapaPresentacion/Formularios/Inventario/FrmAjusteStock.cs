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
using CapaPresentacion.Formularios.ChildForms;
using CapaPresentacion.Informes.DsReporteTableAdapters;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion.Formularios.Inventario
{
    public partial class FrmAjusteStock : Form
    {
        private bool IsNuevo;
        private DataTable Dtdetalle;
        private int Total = 0;
        int codAjuste = 0;

        public string user;
        public string nombre;
        public string apellido;

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmAjusteStock _Instancia;
        public static FrmAjusteStock GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmAjusteStock();
            }
            return _Instancia;
        }

        //constructor
        public FrmAjusteStock()
        {
            InitializeComponent();
            LlenarCombos();
        }


        public void ObtenerProducto(string id,string descripcion,string precio,string stock) {
            this.txtCodItem.Text = id;
            this.txtItem.Text = descripcion;
            this.txtPrecio.Text = Convert.ToDouble(precio).ToString("N0");
            this.txtExistencia.Text = stock;
        }


        private void ObtenerNumeracion()
        {
            try
            {
                //Obtener la siguiente numeracion de la OT de trabajo
                DataTable dt = new DataTable();
                dt = NAjuste.MostrarNumeracion();
                this.txtNumero.Text = dt.Rows[0]["Correlativo"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void DataGridDiseno(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv.BackgroundColor = Color.White;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void LlenarCombos()
        {
            cboTipoAjuste.DataSource = NTipoAjuste.Mostrar();
            cboTipoAjuste.DisplayMember = "Descripcion";
            cboTipoAjuste.ValueMember = "TipoAjusteNro";
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
            this.txtNumero.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtObservacion.Text = string.Empty;
            this.txtTotalGral.Text = string.Empty;
            LimpiarDetalle();
            this.CrearTabla();
        }

        private void LimpiarDetalle()
        {
            this.txtCodItem.Text = string.Empty;
            this.txtItem.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;            
            this.txtPrecio.Text = string.Empty;
            this.txtExistencia.Text = string.Empty;
        }

        private void CrearTabla()
        {
            this.Dtdetalle = new DataTable("Detalle");

            this.Dtdetalle.Columns.Add("ArticuloNro", System.Type.GetType("System.Int32"));
            this.Dtdetalle.Columns.Add("Producto", System.Type.GetType("System.String"));            
            this.Dtdetalle.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
            this.Dtdetalle.Columns.Add("StockAnterior", System.Type.GetType("System.Int32"));
            this.Dtdetalle.Columns.Add("Precio", System.Type.GetType("System.Decimal"));
            this.Dtdetalle.Columns.Add("SubTotal", System.Type.GetType("System.Int32"));
            //relacion con el datagridview
            this.dgvDetalleAjuste.DataSource = this.Dtdetalle;
        }

        //Habilitar botones
        private void Habilitar(bool valor)
        {
            this.txtNumero.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;            
            this.dtpFecha.Enabled = valor;          
            this.txtItem.ReadOnly = !valor;
            this.txtExistencia.ReadOnly = !valor;
            this.txtCodItem.ReadOnly = !valor;            
            this.txtPrecio.ReadOnly = !valor;
            this.txtCantidad.ReadOnly = !valor;            
            this.txtObservacion.ReadOnly = !valor;           
            this.txtTotalGral.ReadOnly = !valor;            
            this.cboTipoAjuste.Enabled = valor;            
            btnBuscarProducto.Enabled = valor;
            btnAgregar.Enabled = valor;
            btnQuitar.Enabled = valor;          

        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        //ocultar columnas
        private void OcultarColumnas()
        {
        try 
        {
                this.dataListado.Columns[0].Visible = false;
                this.dataListado.Columns[1].Visible = false;
        }
            catch(Exception ex) 
        {
                MessageBox.Show(ex.Message);
        }
           
        }

        private void OcultarColumnasDetalle()
        {
            this.dgvDetalleAjuste.Columns[0].Visible = false;
            // this.dgvDetalleFactura.Columns[6].Visible = false;
            // this.dgvDetalleFactura.Columns[7].Visible = false;
        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            this.dataListado.DataSource = NAjuste.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Metodo buscar por fechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NAjuste.BuscarAjusteFecha(this.dtpFechadesde.Value.ToString("dd-MM-yyyy HH:mm"), dtpfechahasta.Value.ToString("dd-MM-yyyy HH:mm"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        //Metodo buscar por detalle
        private void MostrarDetalle()
        {
            this.dgvDetalleAjuste.DataSource = NAjuste.MostarDetalle(codAjuste);
        }


        private void FrmAjuste_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void FrmAjuste_Load(object sender, EventArgs e)
        {
            LblUsuario.Text = nombre +" " + apellido;
            DataGridDiseno(dataListado);
            DataGridDiseno(dgvDetalleAjuste);
            if (chkEliminar.Checked == false)
            {
                btnAnular.Enabled = false;
            }
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.CrearTabla();
            this.Mostrar();
            this.OcultarColumnasDetalle();
            //this.cboTipoAjuste.SelectedIndex = 0;           
        }

        private void btnBuscarItem_Click(object sender, EventArgs e)
        {
            FrmVistaProductoAjuste frm = new FrmVistaProductoAjuste();
            frm.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtItem.Text == string.Empty)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtItem, "Ingrese el item");
                    this.btnBuscarProducto.Focus();
                }
                else if(this.txtCantidad.Text == string.Empty)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtCantidad, "Ingrese la cantidad");
                    this.txtCantidad.Focus();
                }
                else if(Convert.ToInt32(txtCantidad.Text)<=0) 
                {
                    this.MensajeError("Valor erroneo");
                    errorIcono.SetError(txtCantidad, "La cantidad debe ser mayor a 0");
                    this.txtCantidad.Focus();
                }
                else
                {
                    bool registrar = true;

                    foreach (DataRow row in Dtdetalle.Rows)
                    {
                        if (Convert.ToInt32(row["ArticuloNro"]) == Convert.ToInt32(txtCodItem.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se agregó el Articulo");
                        }
                    }

                    if (registrar)
                    {
                        //agregar en el detalle
                        DataRow row = this.Dtdetalle.NewRow();
                        row["ArticuloNro"] = Convert.ToInt32(txtCodItem.Text);
                        row["Producto"] = txtItem.Text;                       
                        row["Precio"] = Convert.ToDouble(txtPrecio.Text);                       
                        row["Cantidad"] = Convert.ToInt32(txtCantidad.Text);
                        row["StockAnterior"] = Convert.ToInt32(txtExistencia.Text);
                        row["Subtotal"] = Convert.ToInt32(row["Precio"]) * Convert.ToInt32(row["Cantidad"]);
                        //row["SubTotalGravadas"] = Convert.ToInt32(row["SubTotal"]) / Convert.ToDecimal(row["Gravadas"]);
                        //row["SubTotalIva"] = Convert.ToInt32(row["SubTotal"]) / Convert.ToInt32(row["Divisor"]);

                        this.Dtdetalle.Rows.Add(row);
                        this.LimpiarDetalle();

                        //totales
                        Total = Total + Convert.ToInt32(row["SubTotal"]);
                       //SubTotalIva = SubTotalIva + Convert.ToInt32(row["SubTotalIva"]);
                        //SubTotalGravadas = SubTotalGravadas + Convert.ToInt32(row["SubTotalGravadas"]);
                        //Total = (SubTotalIva + SubTotal + SubTotalGravadas);

                       // txtTotaGravadas.Text = SubTotalGravadas.ToString("#0#");
                        //txttotalIva.Text = SubTotalIva.ToString("#0#");
                        txtTotalGral.Text = Total.ToString("N0");

                        //colocar por defecto el texbox descuento en 0
                        //this.txtProDescuento.Text = 0.ToString();
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
                int indiceFila = dgvDetalleAjuste.CurrentCell.RowIndex;
                DataRow row = Dtdetalle.Rows[indiceFila];
                //disminuir total
                Total = Total - Convert.ToInt32(row["SubTotal"]);
                //SubTotalIva = SubTotalIva - Convert.ToInt32(row["SubTotalIva"]);
                //SubTotalGravadas = SubTotalGravadas - Convert.ToInt32(row["SubTotalGravadas"]);
                //Total = (SubTotalIva + SubTotalGravadas);

               // txtTotaGravadas.Text = SubTotalGravadas.ToString("#0#");
                //txttotalIva.Text = SubTotalIva.ToString("#0#");
                txtTotalGral.Text = Total.ToString("#0#");

                //eliminamos la fila
                this.Dtdetalle.Rows.Remove(row);
            }
            catch (Exception)
            {
                MensajeError("No existe fila para eliminar");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (dgvDetalleAjuste.Rows.Count == 0)
                {
                    this.MensajeError("No existen items para registrar");
                    return;
                }

                if (!ControlesCompartidos.MensajeConfirmacion(this,"Desea registrar el ajuste de Stock ?"))
                    return;



                //si se ingresa un nuevo registro
                if (this.IsNuevo)
                {
                    rpta = NAjuste.Insertar(this.txtDescripcion.Text, this.dtpFecha.Value, "EMITIDO", txtObservacion.Text, Convert.ToInt32(this.cboTipoAjuste.SelectedValue), user, Dtdetalle);

                }

                if (rpta.Equals("OK"))
                {
                    if (IsNuevo)
                    {
                        this.MensajeOK("El ajuste se ha insertado con exito");
                    }
                }
                else
                {
                    this.MensajeError(rpta);
                }
                this.IsNuevo = false;
                this.Botones();
                this.Limpiar();
                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try 
            {
                this.IsNuevo = true;
                this.Botones();
                this.Limpiar();
                this.Habilitar(true);
                this.txtDescripcion.Focus();
                this.cboTipoAjuste.SelectedIndex = 0;
                this.ObtenerNumeracion();
            }
            catch(Exception) 
            {
                MessageBox.Show("Primero debe cargar un tipo de ajuste");
            }
            
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.codAjuste = Convert.ToInt32(this.dataListado.CurrentRow.Cells["CodAjuste"].Value);
                this.txtNumero.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NumAjuste"].Value);
                this.txtDescripcion.Text = (this.dataListado.CurrentRow.Cells["Descripcion"].Value).ToString();                
                this.dtpFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["FechaHora"].Value);
                this.cboTipoAjuste.Text = (this.dataListado.CurrentRow.Cells["TipoAjuste"].Value).ToString();                
                this.txtTotalGral.Text = Convert.ToDouble(this.dataListado.CurrentRow.Cells["Total"].Value).ToString("N0");
                this.MostrarDetalle();
                this.tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
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


                DialogResult opcion;
                opcion = MessageBox.Show("Desea eliminar el Ajuste ?", "Sistema de Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.No)
                    return;


                //int contador = 0;
                string codigo;
                string rpta = "";

                //recorrer el datagrip para eliminar mas de un registro
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        codigo = Convert.ToString(row.Cells["CodAjuste"].Value);
                        rpta = NAjuste.Eliminar(Convert.ToInt32(codigo));

                        if (!rpta.Equals("OK"))
                        {
                            MensajeError(rpta);
                            break;
                        }
                    }
                }
                //mensaje a mostrar
                if (rpta.Equals("OK"))
                {
                    this.MensajeOK("Se eliminó correctamente el registro");
                }
                else
                {
                    MensajeError(rpta);
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
            if (chkEliminar.Checked == true)
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
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkAnularDV = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkAnularDV.Value = !Convert.ToBoolean(chkAnularDV.Value);
            }
        }

        private void dgvDetalleAjuste_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           dgvDetalleAjuste.Columns["Precio"].DefaultCellStyle.Format = "N0";
           dgvDetalleAjuste.Columns["Subtotal"].DefaultCellStyle.Format = "N0";
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataListado.Columns["Total"].DefaultCellStyle.Format = "N0";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try 
            {
                if (this.dataListado.CurrentRow == null)
                {
                    MensajeError("No ha seleccionado ningun registro");
                    return;
                }


                int codajuste;
                codajuste = Convert.ToInt32(this.dataListado.CurrentRow.Cells["CodAjuste"].Value);

                FrmInformeAjuste frm = new FrmInformeAjuste();
                frm.codajuste = codajuste;
                frm.Show();
            }
            catch(Exception)             
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
            
        }

        private void btnBuscarItem_Click_1(object sender, EventArgs e)
        {
            FrmVistaProductoAjuste frm = new FrmVistaProductoAjuste();
            frm.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }
    }
}
