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

namespace CapaPresentacion.Formularios.RRHH
{
    public partial class FrmMantenimiento_Proceso : Form
    {
        //atributos de proceso
        public int procesonro;
        public string descripcion;
        public DateTime fechainicio;
        public DateTime fechafin;
        public char estado;

        private DataTable table;
        

        private static FrmMantenimiento_Proceso _Instancia;
        public static FrmMantenimiento_Proceso GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmMantenimiento_Proceso();
            }
            return _Instancia;
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


        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            this.dataProceso.DataSource = NLiquidacion.Mostrar(Convert.ToInt32(this.lblProcesoNro.Text));           
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataProceso.Rows.Count);
            this.TotalesListado();            
        }

        private void MostrarDetalleProceso()
        {
            try
            {
                this.dataDetalle.DataSource = NProceso.MostrarUsuarioServicio(Convert.ToInt32(this.lblProcesoNro.Text));
                this.TotalGanancia(); 
            }
            catch (Exception)
            {

            }
        }


        private void BuscarDetalleProceso()
        {
            try
            {
                this.dataDetalle.DataSource = NProceso.BuscarUsuarioServicio(Convert.ToInt32(this.lblProcesoNro.Text),Convert.ToInt32(cboUsuarioFiltro.SelectedValue));
            }
            catch (Exception)
            {

            }
        }





        private void TotalesMantenimiento()
        {
            double total = 0;
            if (dataListado.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                   
                        total += Convert.ToDouble(row.Cells["Total"].Value);
                        txtTotalDescuento.Text = total.ToString("N0");                   
                }
                total = 0;
                
            }
            else
            {
                total = 0;
                this.txtTotalDescuento.Text = total.ToString();
            }           
        }


        private void TotalesListado()
        {
            double total = 0;
            if (dataProceso.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataProceso.Rows)
                {

                    total += Convert.ToDouble(row.Cells["Total"].Value);
                    txtTotalListado.Text = total.ToString("N0");
                }
                total = 0;

            }
            else
            {
                total = 0;
                this.txtTotalDescuento.Text = total.ToString();
            }
        }

        //Calculo de la ganancia total 
        private void TotalGanancia() 
        {
            double totalganancia = 0;
            double totalprecio = 0;
            if (dataDetalle.Rows.Count > 0) 
            {
                foreach (DataGridViewRow fila in dataDetalle.Rows)
                {
                    totalganancia += Convert.ToDouble(fila.Cells["Ganancia"].Value);
                    txtTotalGanancia.Text = totalganancia.ToString("N0");

                    totalprecio += Convert.ToDouble(fila.Cells["Precio"].Value);
                    txtTotalPrecio.Text = totalprecio.ToString("N0");
                }
            }
            else
            {
                totalganancia = 0;
                totalprecio = 0;
                txtTotalGanancia.Text = totalganancia.ToString();
                txtTotalPrecio.Text = totalprecio.ToString();
            } 
        }



        public FrmMantenimiento_Proceso()
        {
            InitializeComponent();
            this.CargarCombobox();
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

        private void OcultarColumnas() 
        {
            this.dataProceso.Columns[0].Visible = false;
            this.dataProceso.Columns[1].Visible = false;
            this.dataProceso.Columns[2].Visible = false;
            this.dataProceso.Columns[4].Visible = false;

        }



        private void Limpiar() 
        {
            this.txtCantidad.Text = string.Empty;
            this.txtMonto.Text = string.Empty;

            //LIMPIAR EL DATAGRID
            dataListado.Rows.Clear();
         }


        private void CargarCombobox()
        {
            cboEmpleados.DataSource = NColaborador.MostrarColaboradorActivo();
            cboEmpleados.DisplayMember = "NombreApellido";
            cboEmpleados.ValueMember = "ColaboradorNro";

            cboDescuento.DataSource = NDescuento.Mostrar();
            cboDescuento.DisplayMember = "Descripcion";
            cboDescuento.ValueMember = "DescuentoNro";

            cboUsuarioFiltro.DataSource = NColaborador.MostrarColaboradorActivo();
            cboUsuarioFiltro.DisplayMember = "NombreApellido";
            cboUsuarioFiltro.ValueMember = "ColaboradorNro";
        }


        public void ObtenerValores(int procesonro,string descripcion,DateTime fechainicio,DateTime fechafin, char estado) 
        {
            this.lblProcesoNro.Text =Convert.ToString(procesonro);
            this.lblDescripcion.Text = descripcion;
            this.lblFechaInicio.Text = fechainicio.ToString("dd/MM/yyyy");
            this.lblFechaFin.Text = fechafin.ToString("dd/MM/yyyy");
            if(estado=='A') 
            {
                this.lblEstado.Text = "ABIERTO";
                this.lblEstado.ForeColor = Color.Blue;
            }
            else
            {
                this.lblEstado.Text = "CERRADO";
                this.lblEstado.ForeColor = Color.Red;
            }
            
        }


        private void Botones(bool valor) 
        {
            btnAgregar.Enabled = valor;
            btnQuitar.Enabled = valor;
            btnGuardar.Enabled = valor;
            btnCerrarProceso.Enabled = valor;
            btnEliminar.Enabled = valor;
            chkEliminar.Enabled = valor;
            btnAbrirProceso.Visible = !valor;
            btnLiquidacion.Visible = !valor;   
        }


       

        private void FrmMantenimiento_Proceso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
            FrmProceso frm = FrmProceso.GetInstancia();
            frm.cboEstado_SelectedValueChanged(null,null);

        }

        private void FrmMantenimiento_Proceso_Load(object sender, EventArgs e)
        {
            if(lblEstado.Text=="ABIERTO") 
            {
                this.Botones(true);
            }
            else
            {
                this.Botones(false);
            }

            if (chkEliminar.Checked == false)
            {
                chktodos.Visible = false;
                btnEliminar.Enabled = false;
            }
            
            this.Mostrar();
            this.MostrarDetalleProceso();
            this.OcultarColumnas();
        }

        private void cboEmpleados_SelectedValueChanged(object sender, EventArgs e)
        {
            table = NColaborador.Mostrar(null);
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCantidad.Text == string.Empty)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtCantidad, "Ingrese la cantidad");
                }
                else if (this.txtMonto.Text == string.Empty)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtCantidad, "Ingrese el monto");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        //EVALUAMOS SI EN EL DATAGRID NO SE INSERTO AL EMPLEADO CON UN MISMO DESCUENTO
                        if (Convert.ToInt32(row.Cells["UsuarioNro"].Value) == Convert.ToInt32(this.cboEmpleados.SelectedValue) && Convert.ToInt32(row.Cells["DescuentoNro"].Value) == Convert.ToInt32(this.cboDescuento.SelectedValue))
                        {
                            registrar = false;
                            this.MensajeError("El empleado ya fue registrado con ese tipo de Descuento");
                            
                        }
                    }

                    if (registrar)
                    {
                        this.dataListado.Rows.Add(this.cboEmpleados.Text, Convert.ToInt32(cboEmpleados.SelectedValue), Convert.ToInt32(cboDescuento.SelectedValue), this.cboDescuento.Text, this.txtCantidad.Text, Convert.ToDouble(this.txtMonto.Text), Convert.ToDouble(this.txtCantidad.Text) * Convert.ToDouble(this.txtMonto.Text));
                        this.TotalesMantenimiento();
                    }
                }
                                
            }
            catch (Exception)
            {
                MensajeError("Por favor ingrese los datos a ser insertados");
            }

            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Desea guardar los descuentos correspondientes?", "Sistema de Facturacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        rpta = NLiquidacion.Insertar(Convert.ToInt32(row.Cells["UsuarioNro"].Value), Convert.ToInt32(this.lblProcesoNro.Text), Convert.ToInt32(row.Cells["DescuentoNro"].Value), Convert.ToInt32(row.Cells["Cantidad"].Value), Convert.ToDecimal(row.Cells["Monto"].Value));
                    }
                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOK("Se ha insertado con exito ");
                        this.Limpiar();
                        this.Mostrar();
                    }
                    else
                    {
                        this.MensajeError("No se insertaron uno o varios registros. Por favor verificar \nEl registro que desea insertar ya existe");
                    }
                }  
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataListado.Columns["Monto"].DefaultCellStyle.Format = "N0";
            this.dataListado.Columns["Total"].DefaultCellStyle.Format = "N0";
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SoloNumeros(e);
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SoloNumeros(e);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            
            try
            {
                int indiceFila = dataListado.CurrentCell.RowIndex;
                this.dataListado.Rows.RemoveAt(indiceFila);
                this.TotalesMantenimiento();
            }
            catch (Exception)
            {

                MensajeError("Seleccione una fila");
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked == true)
            {
                btnEliminar.Enabled = true;
                chktodos.Visible = true;
                this.dataProceso.Columns[0].Visible = true;
            }
            else
            {
                chktodos.Checked = false;
                btnEliminar.Enabled = false;
                chktodos.Visible = false;
                this.dataProceso.Columns[0].Visible = false;
            }
        }

        private void chktodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chktodos.Checked == true)
            {
                foreach (DataGridViewRow row in dataProceso.Rows)
                {
                    row.Cells["Eliminar"].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataProceso.Rows)
                {
                    row.Cells["Eliminar"].Value = false;
                }
            }
        }

        private void dataProceso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataProceso.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminarDV = (DataGridViewCheckBoxCell)dataProceso.Rows[e.RowIndex].Cells["Eliminar"];

                chkEliminarDV.Value = !Convert.ToBoolean(chkEliminarDV.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Desea eliminar el registro ?", "Sistema de Facturacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    //int contador = 0;
                    //ATRIBUTOS PARA LOS PARAMETROS DEL METODO ELIMINAR
                    string proceso;
                    string usuario;
                    string descuento;
                    string rpta = "";
                    //recorrer el datagrip para eliminar mas de un registro
                    foreach (DataGridViewRow row in dataProceso.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            proceso = Convert.ToString(row.Cells["ProcesoNro"].Value);
                            usuario = Convert.ToString(row.Cells["UsuarioNro"].Value);
                            descuento = Convert.ToString(row.Cells["DescuentoNro"].Value);
                            rpta = NLiquidacion.Eliminar(Convert.ToInt32(proceso), Convert.ToInt32(usuario), Convert.ToInt32(descuento));
                        }

                        /* if (row.Cells[0].Value.Equals(true))//Columna de checks
                         {
                             contador++;
                         }*/
                    }

                    //mensaje a mostrar
                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOK("Se elimino correctamento el registro");
                    }
                    else
                    {
                        this.MensajeError("Seleccione una fila");
                    }
                    this.chkEliminar.Checked = false;
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrarProceso_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Desea cerrar el proceso de Descuentos? \n Se Generaran las comisiones correspondientes.", "Sistema de Facturacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    string rpta = "";
                    string generar = ""; 
                    rpta = NProceso.CerrarProceso(Convert.ToInt32(this.lblProcesoNro.Text));
                    generar = NLiquidacion.Generar(Convert.ToInt32(this.lblProcesoNro.Text));
                    


                     if (rpta.Equals("OK"))
                    {
                        MensajeOK("El proceso " + this.lblProcesoNro.Text + " se ha cerrado con exito");
                        this.Close();
                        if(generar.Equals("OK")) 
                        {
                            this.MensajeOK("OPERACION EXITOSA");
                        }
                    }
                    else
                    {
                        MensajeError("ERROR AL CERRAR EL PROCESO");
                    }                   
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);                
            }
            
        }

        private void dataProceso_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataProceso.Columns["Monto"].DefaultCellStyle.Format = "N0";
            this.dataProceso.Columns["Total"].DefaultCellStyle.Format = "N0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Desea abrir el proceso de Descuentos ?", "Sistema de Facturacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    string rpta = "";
                    rpta = NProceso.AbrirProceso(Convert.ToInt32(this.lblProcesoNro.Text));

                    if (rpta.Equals("OK"))
                    {
                        MensajeOK("El proceso " + this.lblProcesoNro.Text + " se ha abierto con exito");
                        this.Close();
                    }
                    else
                    {
                        MensajeError("ERROR");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.BuscarDetalleProceso();
            this.TotalGanancia();
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            this.MostrarDetalleProceso();
        }

        private void dataDetalle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataDetalle.Columns["Precio"].DefaultCellStyle.Format = "N0";
            this.dataDetalle.Columns["Ganancia"].DefaultCellStyle.Format = "N0";
        }
        
        private void btnLiquidacion_Click(object sender, EventArgs e)
        {
            FrmInformeLiquidacion frm = new FrmInformeLiquidacion();
            frm.obtenerProceso(Convert.ToInt32(lblProcesoNro.Text));
            frm.ShowDialog();
        }
    }
}
