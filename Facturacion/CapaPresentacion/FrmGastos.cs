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
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class FrmGastos : Form
    {

        bool IsNuevo = false;
        bool IsEditar = false;

        public string usuario;
        public string id;
        public string nombre;
        public string apellido;



        private static FrmGastos _Instancia;

        public static FrmGastos GetInstancia() 
        {
            if(_Instancia==null) 
            {
                _Instancia = new FrmGastos();
            }
            return _Instancia;
        }
        
        
        public FrmGastos()
        {
            InitializeComponent();
            LlenarComboBox();
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
        

        //Limpiar los controles del formulario
        private void Limpiar()
        {
            this.txtNroDocumento.Text = string.Empty;
            this.txtdescripcion.Text = string.Empty;
            this.dtpFechaOperacion.Text = string.Empty;
            this.txtImporte.Text = string.Empty;
        }

        //Habilitar botones
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = true;
            this.txtNroDocumento.ReadOnly = !valor;
            this.txtdescripcion.ReadOnly = !valor;
            this.txtImporte.ReadOnly = !valor;
            this.dtpFechaOperacion.Enabled = valor;
            cboFormaPago.Enabled = valor;
            cboTipoOperacion.Enabled = valor;
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
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
            if(dataListado.Rows.Count>0) 
            {
                this.dataListado.Columns[0].Visible = false;
                this.dataListado.Columns[1].Visible = false;
            }
            
        }

        private void LlenarComboBox()
        {        
            cboTipoOperacion.DataSource = ControlesCompartidos.AgregarNuevaFila(NTipoOperacion.Mostrar(), "Descripcion", "NroTipoOperacion");
            cboTipoOperacion.ValueMember = "NroTipoOperacion";
            cboTipoOperacion.DisplayMember = "Descripcion";

            cboFormaPago.DataSource = ControlesCompartidos.AgregarNuevaFila(NFormaPago.MostrarFormaPago(), "Descripcion", "FormaPagoNro");
            cboFormaPago.DisplayMember = "Descripcion";
            cboFormaPago.ValueMember = "FormaPagoNro";
        }

        //Metodo buscar nombres por gastos
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NGastos.BuscarNombre(this.txtBuscarDescripcion.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            this.dataListado.DataSource = NGastos.Mostrar();
            //this.dataListado.Columns["Descripcion"].Width = 100;
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

        }


        //Metodo buscar por fechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NGastos.BuscarFecha(dtpFechadesde.Value.ToString("yyyy-MM-dd"), 
                                                              dtpfechahasta.Value.ToString("yyyy-MM-dd"),
                                                              txtBuscarDescripcion.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

     


        private void FrmGastos_Load(object sender, EventArgs e)
        {
            this.DataGridDiseno();
            if (chkEliminar.Checked == false)
            {
                chktodos.Visible = false;
                btnEliminar.Enabled = false;
            }
            this.Mostrar();
            this.Botones();
            this.OcultarColumnas();
            //top para ubicar en la parte superior
            this.Top = 0;
            //alineado hacia la izquierda
            this.Left = 0;
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
               


                string nroDocumento = this.txtNroDocumento.Text;
                DateTime fechaOperacion = dtpFechaOperacion.Value;
                double Importe = Convert.ToDouble(this.txtImporte.Text);
                int CodTipoOperacion = Convert.ToInt32(cboTipoOperacion.SelectedValue);
                int CodFormaPago = Convert.ToInt32(cboFormaPago.SelectedValue);             
                string DescripcionOperacion = this.txtdescripcion.Text.Trim().ToUpper();
                int CodUsuario = Convert.ToInt32(id);


                if (IsNuevo)
                {
                    rpta = NGastos.Insertar(nroDocumento, 
                                            fechaOperacion, 
                                            Importe, 
                                            CodTipoOperacion,
                                            CodFormaPago, 
                                            DescripcionOperacion, 
                                            CodUsuario);

                }
                else
                {
                    rpta = NGastos.Editar(Convert.ToInt32(this.txtCodigo.Text), 
                                                            nroDocumento,
                                                            fechaOperacion,
                                                            Importe,
                                                            CodTipoOperacion,
                                                            CodFormaPago,
                                                            DescripcionOperacion);
                }

                if (rpta.Equals("OK"))
                {
                    if (IsNuevo)
                    {
                        this.MensajeOK("Se ha insertado con exito");
                    }
                    else
                    {
                        this.MensajeOK("Se ha editado con exito");
                    }
                }
                else
                {
                    this.MensajeError(rpta);
                    return;
                }

                this.IsNuevo = false;
                this.IsEditar = false;
                this.Botones();
                this.Limpiar();
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

            if (this.txtImporte.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtImporte, "Ingrese el importe");
                return false;
            }

            if (Convert.ToInt32(cboFormaPago.SelectedValue) == 0)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboFormaPago, "Favor seleccione una forma de Pago de la Operación");
                return false;
            }

            if (Convert.ToInt32(cboTipoOperacion.SelectedValue) == 0)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboTipoOperacion, "Favor seleccione el tipo de Operacionn");
                return false;
            }

            return true;

        }

        private void ObtenerNumeracion()
        {
            try
            {
                //Obtener la siguiente numeracion de la OT de trabajo
                DataTable dt = new DataTable();
                dt = NGastos.MostrarNumeracion();
                this.txtNroDocumento.Text = dt.Rows[0]["Correlativo"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.cboTipoOperacion.SelectedIndex = 0;
            this.txtNroDocumento.Focus();
            //this.ObtenerNumeracion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked == true)
            {
                btnEliminar.Enabled = true;
                chktodos.Visible = true;
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                chktodos.Checked = false;
                btnEliminar.Enabled = false;
                chktodos.Visible = false;
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void chktodos_CheckedChanged(object sender, EventArgs e)
        {

            if (chktodos.Checked == true)
            {
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    row.Cells["Eliminar"].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    row.Cells["Eliminar"].Value = false;
                }
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

        private void FrmGastos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

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
                opcion = MessageBox.Show("Desea eliminar el registro ?", "Sistema de Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                        codigo = Convert.ToString(row.Cells["GastoNro"].Value);
                        rpta = NGastos.Eliminar(Convert.ToInt32(codigo));
                    }

                }

                //mensaje a mostrar
                if (rpta.Equals("OK"))
                {
                    this.MensajeOK("Se elimino correctamento el registro");
                }
                else
                {
                    this.MensajeError(rpta);
                    return;
                }
                this.chkEliminar.Checked = false;
                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteGastos frm = FrmReporteGastos.GetInstancia();
            frm.Show(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BuscarFechas(); 
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataListado.Columns["Importe"].DefaultCellStyle.Format = "N0";


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtCodigo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a modificar");
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["GastoNro"].Value);
            this.txtNroDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Documento"].Value);
            this.dtpFechaOperacion.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha"].Value);
            this.txtdescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);
            this.cboTipoOperacion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo"].Value);
            this.txtImporte.Text = Convert.ToDouble(this.dataListado.CurrentRow.Cells["Importe"].Value).ToString("N0");
            this.cboFormaPago.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["FormaPago"].Value);
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlesCompartidos.SoloNumeros(e);
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            ControlesCompartidos.FormatoNumero(sender);
        }
    }
}
