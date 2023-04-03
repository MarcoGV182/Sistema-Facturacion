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

        //Limpiar los controles del formulario
        private void Limpiar()
        {
            this.txtNroDocumento.Text = string.Empty;
            this.txtdescripcion.Text = string.Empty;
            this.dtpFechaNac.Text = string.Empty;
            this.txtImporte.Text = string.Empty;
        }

        //Habilitar botones
        private void Habilitar(bool valor)
        {
            this.txtNroDocumento.ReadOnly = !valor;
            this.txtdescripcion.ReadOnly = !valor;
            this.txtImporte.ReadOnly = !valor;
            this.dtpFechaNac.Enabled = valor;
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
        
            cboTipoOperacion.DataSource = NTipoOperacion.Mostrar();
            cboTipoOperacion.ValueMember = "NroTipoOperacion";
            cboTipoOperacion.DisplayMember = "Descripcion";

            //llenar combo Impuesto
            cboImpuesto.DataSource = NTipoImpuesto.Mostrar();
            cboImpuesto.DisplayMember = "Descripcion";
            cboImpuesto.ValueMember = "TipoImpuestoNro";

            cboFormaPago.DataSource = NFormaPago.MostrarFormaPago();
            cboFormaPago.DisplayMember = "Descripcion";
            cboFormaPago.ValueMember = "FormaPagoNro";


        }

        //Metodo buscar nombres por gastos
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NGastos.BuscarNombre(this.txtBuscar.Text);
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
            this.dataListado.DataSource = NGastos.BuscarFecha(this.dtpFechadesde.Value.ToString("dd-MM-yyyy"), dtpfechahasta.Value.ToString("dd-MM-yyyy"));
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
                if (this.txtImporte.Text == string.Empty)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtImporte, "Ingrese el importe");
                }                
                else
                {   
                    if(IsNuevo) {                 
                    rpta = NGastos.Insertar(this.txtNroDocumento.Text,dtpFechaNac.Value,Convert.ToDecimal(this.txtImporte.Text),Convert.ToInt32(cboTipoOperacion.SelectedValue),Convert.ToInt32(this.cboImpuesto.SelectedValue),Convert.ToInt32(cboFormaPago.SelectedValue) ,this.txtdescripcion.Text.Trim().ToUpper(),Convert.ToInt32(id));  

                    }
                    else
                    {
                       rpta = NGastos.Editar(Convert.ToInt32(this.txtCodigo.Text), this.txtNroDocumento.Text, dtpFechaNac.Value, Convert.ToDecimal(this.txtImporte.Text), Convert.ToInt32(cboTipoOperacion.SelectedValue), Convert.ToInt32(this.cboImpuesto.SelectedValue), Convert.ToInt32(cboFormaPago.SelectedValue), this.txtdescripcion.Text.Trim().ToUpper());
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
                        }

                        this.IsNuevo = false;
                        this.IsEditar = false;
                        this.Botones();
                        this.Limpiar();
                        this.Mostrar();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
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
                DialogResult opcion;
                opcion = MessageBox.Show("Desea eliminar el registro ?", "Sistema de Facturacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre(); 

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
            this.dtpFechaNac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha"].Value);
            this.txtdescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);
            this.cboTipoOperacion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo"].Value);
            this.txtImporte.Text = Convert.ToDouble(this.dataListado.CurrentRow.Cells["Importe"].Value).ToString("N0");
            this.cboFormaPago.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["FormaPago"].Value);
            this.cboImpuesto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Impuesto"].Value); 
            //mostrar la segunda pestana la de mantenimiento al hacer doble click
            this.tabControl1.SelectedIndex = 1;
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
    }
}
