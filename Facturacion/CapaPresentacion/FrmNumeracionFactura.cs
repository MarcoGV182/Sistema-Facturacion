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
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FrmNumeracionFactura : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private int IdNumeracion = 0;
        private int IdTimbrado = 0;
        List<DNumeracionComprobante> ListaNumeracion = null;

        public FrmNumeracionFactura()
        {
            InitializeComponent();
        }

        private static FrmNumeracionFactura _Instancia;
        public static FrmNumeracionFactura GetInstancia() 
        { 
            if(_Instancia==null) 
            {
                _Instancia = new FrmNumeracionFactura();
            }
            return _Instancia;
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
            this.IdTimbrado = 0;
            this.IdNumeracion = 0;
            this.txtEstablecimiento.Text = string.Empty;
            this.txtPuntoExpedicion.Text = string.Empty;
            this.txtNumeroDesde.Text = string.Empty;
            this.txtNroTimbrado.Text = string.Empty;
            this.dtpFechaInicioVigencia.Checked = false;
            this.dtpFechaVencimiento.Checked = false;
            this.dtpFechaInicioVigencia.Value = DateTime.Now;
            this.dtpFechaVencimiento.Value = DateTime.Now;
            this.chkEstadoTimbrado.Checked = false;
            this.cboComprobante.SelectedIndex = 0;
        }




        private void Mostrar()
        {
            this.dataListado.DataSource = NNumeracionFactura.Mostrar();
            LlenarCombos();
            this.OcultarColumnas();
        }

        private void LlenarCombos()
        {
            try
            {               
                cboComprobante.DataSource = NTipoComprobante.MostrarTipoComprobante();
                cboComprobante.DisplayMember = "Nombre";
                cboComprobante.ValueMember = "ComprobanteNro";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void OcultarColumnas() 
        {
            this.dataListado.Columns["ComprobanteNro"].Visible = false;
        }


        private void FrmNumeracionFactura_Load(object sender, EventArgs e)
        {
            IsNuevo=true;
            this.Mostrar();
        }

        private void FrmNumeracionFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                string estado;
                DateTime? fecha, fechaInicio;
                

                //EVALUAR CHECK ESTADO
                estado = chkEstadoTimbrado.Checked == true ? "A" : "I";

                //EVALUAR FECHA VENCIMIENTO
                if (dtpFechaVencimiento.Checked==false)
                    fecha = null;
                else
                    fecha = this.dtpFechaVencimiento.Value;

                //EVALUAR FECHA INICIO VIGENCIA
                if (dtpFechaInicioVigencia.Checked == false)
                    fechaInicio = null;
                else
                    fechaInicio = this.dtpFechaInicioVigencia.Value;


                if (!Validaciones())
                {
                    return;
                }

                DTimbrado t = new DTimbrado()
                {
                    IdTimbrado = IdTimbrado,
                    NroTimbrado = txtNroTimbrado.Text,
                    FechaInicioVigencia = this.dtpFechaInicioVigencia.Value.ToString("dd-MM-yyyy"),
                    FechaFinVigencia = dtpFechaVencimiento.Value.ToString("dd-MM-yyyy"),
                    Estado = estado
                };

                ListaNumeracion = new List<DNumeracionComprobante>();
                foreach (DataGridViewRow item in dataListado.Rows)
                {
                    DNumeracionComprobante dNumeracion = new DNumeracionComprobante();
                    dNumeracion.Establecimiento = Convert.ToInt32(item.Cells["Establecimiento"]);
                    dNumeracion.PuntoExpedicion = Convert.ToInt32(item.Cells["PuntoExpedicion"]);
                    dNumeracion.NumeroDesde = Convert.ToInt32(item.Cells["NumeroDesde"]);
                    dNumeracion.NumeroHasta = Convert.ToInt32(item.Cells["NumeroHasta"]);
                    dNumeracion.TipoComprobante = Convert.ToInt32(item.Cells["ComprobanteNro"]);
                    DTimbrado timbrado = new DTimbrado() { IdTimbrado = Convert.ToInt32(item.Cells["IdTimbrado"]) };
                    dNumeracion.Timbrado = timbrado;
                    ListaNumeracion.Add(dNumeracion);
                }


                if (IdTimbrado == 0)
                {
                    IsNuevo = true;
                    IsEditar = false;                    

                    rpta = NNumeracionFactura.Insertar(t, ListaNumeracion);
                    //si se esta editando el registro
                }
                else
                {
                    IsNuevo = false;
                    IsEditar = true;
                    
                    //rpta = NNumeracionFactura.Editar(dNumeracion);
                }



                if (rpta.Equals("OK"))
                {
                    if (IsNuevo)
                    {
                        this.MensajeOK("Se ha insertado con exito");
                    }
                    else
                    {
                        this.MensajeOK("Se ha modificado con exito");
                    }

                }
                else
                {
                    this.MensajeError(rpta + "\nUN REGISTRO PARA EL MISMO COMPROBANTE SE ENCUENTRA ACTIVO");
                }

                this.IsNuevo = true;
                this.IsEditar = false;
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
            if (this.txtEstablecimiento.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtEstablecimiento, "Ingrese la Serie");
                return false;
            }

            if (this.txtPuntoExpedicion.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtPuntoExpedicion, "Ingrese el número de Sucursal");
                return false;

            }

            if (this.txtNumeroDesde.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtNumeroDesde, "Ingrese los últimos dígitos");
                return false;
            }

            if (dtpFechaInicioVigencia.Checked == true)
            {
                if (this.dtpFechaInicioVigencia.Value > this.dtpFechaVencimiento.Value)
                {
                    this.MensajeError("La fecha de inicio de vigencia del timbrado no puede ser mayor a la fecha de vencimiento");
                    errorIcono.SetError(dtpFechaInicioVigencia, "Ingrese una fecha válida");
                    return false;
                }

                if (this.dtpFechaVencimiento.Value < this.dtpFechaInicioVigencia.Value)
                {
                    this.MensajeError("La fecha de vencimiento del timbrado no puede ser menor a la fecha de inicio de vigencia");
                    errorIcono.SetError(dtpFechaVencimiento, "Ingrese una fecha válida");
                    return false;
                }
            }

            

            return true;
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                IsEditar = true;

                this.txtEstablecimiento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Establecimiento"].Value);
                this.txtPuntoExpedicion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["PuntoExpedicion"].Value);
                this.IdNumeracion = Convert.ToInt32(this.dataListado.CurrentRow.Cells["Id"].Value);
                this.txtNumeroDesde.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Numero"].Value);
                this.cboComprobante.SelectedValue = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ComprobanteNro"].Value);
                this.txtNroTimbrado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Timbrado"].Value);
                if (this.dataListado.CurrentRow.Cells["FechaInicioVigencia"].Value.ToString() == "")
                {
                    dtpFechaInicioVigencia.Checked = false;                   
                }
                else
                {
                    this.dtpFechaInicioVigencia.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["FechaInicioVigencia"].Value);

                }

                this.dtpFechaVencimiento.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["FechaVencimiento"].Value);

                if (Convert.ToChar(this.dataListado.CurrentRow.Cells["Estado"].Value) == 'A')
                {
                    chkEstadoTimbrado.Checked = true;

                }
                else
                {
                    chkEstadoTimbrado.Checked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           



        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
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
                    string codigo;
                    string rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells["Id"].Value);
                            rpta = NNumeracionFactura.Eliminar(Convert.ToInt32(codigo));

                            if (rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se elimino correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(rpta);
                            }
                        }
                    }

                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtTimbrado_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtEstablecimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtPuntoExpedicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            Limpiar();
        }
    }
}
