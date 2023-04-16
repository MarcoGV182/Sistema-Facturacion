using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmMantenimientoTimbrado : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private int IdNumeracion = 0;
        private int IdTimbrado = 0;
        List<DNumeracionComprobante> ListaNumeracion = null;
        DataTable dtNumeracion = null;

        public FrmMantenimientoTimbrado()
        {
            InitializeComponent();
        }

        private static FrmMantenimientoTimbrado _Instancia;
        public static FrmMantenimientoTimbrado GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmMantenimientoTimbrado();
            }
            return _Instancia;
        }


        private void FrmNumeracionFactura_Load(object sender, EventArgs e)
        {
            Habilitar(false);
            Botones(false);
            MostrarTimbrado();

            //Evento de los radioButtons
            rbAutoimprenta.CheckedChanged += RadioButton_CheckedChanged;
            rbManual.CheckedChanged += RadioButton_CheckedChanged;
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
            this.txtNumeroHasta.Text = string.Empty;
            this.txtNroTimbrado.Text = string.Empty;
            this.dtpFechaInicioVigencia.Checked = false;
            this.dtpFechaVencimiento.Checked = false;
            this.dtpFechaInicioVigencia.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dtpFechaVencimiento.Value = DateTime.Now;
            this.chkEstadoTimbrado.Checked = false;
            this.chkEstadoNumeracion.Checked = false;
            this.cboComprobante.SelectedIndex = 0;
        }

        private void MostrarTimbrado()
        {
            this.dgTimbrados.DataSource = NTimbrado.Mostrar();
            OcultarColumnasTimbrado();
        }

        private void OcultarColumnasTimbrado()
        {
            this.dgTimbrados.Columns["IdTimbrado"].Visible = false;
        }

        private void Mostrar(int idTimbrado)
        {
            this.dataListado.DataSource = NNumeracionFactura.Mostrar(idTimbrado);
            LlenarCombos();
            this.OcultarColumnasNumeracion();
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

        private void OcultarColumnasNumeracion()
        {
            this.dataListado.Columns["Id"].Visible = false;
            this.dataListado.Columns["ComprobanteNro"].Visible = false;
            this.dataListado.Columns["IdTimbrado"].Visible = false;
            this.dataListado.Columns["NroTimbrado"].Visible = false;
        }


        private void Habilitar(bool valor)
        {
            this.txtNroTimbrado.ReadOnly = !valor;
            this.dtpFechaInicioVigencia.Enabled = valor;
            this.dtpFechaVencimiento.Enabled = valor;
            this.chkEstadoTimbrado.Enabled = valor;
            this.txtEstablecimiento.Enabled = valor;
            this.txtPuntoExpedicion.Enabled = valor;
            this.txtNumeroDesde.Enabled = valor;
            this.txtNumeroHasta.Enabled = valor;
            this.cboComprobante.Enabled = valor;
            this.chkEstadoNumeracion.Enabled = valor;


            //Inicializar la fecha desde del filtro al primer día del mes
            this.dtpFechaInicioVigencia.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }


        private void Botones(bool habilitado)
        {
            btnAgregar.Enabled = habilitado;
            btnQuitar.Enabled = habilitado;
            btnCancelar.Enabled = habilitado;
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
                if (dtpFechaVencimiento.Checked == false)
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
                    Ind_Autoimprenta = rbAutoimprenta.Checked ? "S" : "N",
                    Estado = estado
                };

                ListaNumeracion = new List<DNumeracionComprobante>();
                foreach (DataGridViewRow item in dataListado.Rows)
                {
                    DNumeracionComprobante dNumeracion = new DNumeracionComprobante();
                    dNumeracion.Id = Convert.ToInt32(item.Cells["Id"].Value);
                    dNumeracion.Establecimiento = Convert.ToInt32(item.Cells["Establecimiento"].Value);
                    dNumeracion.PuntoExpedicion = Convert.ToInt32(item.Cells["PuntoExpedicion"].Value);
                    dNumeracion.NumeroDesde = Convert.ToInt32(item.Cells["NumeroDesde"].Value);
                    dNumeracion.NumeroHasta = Convert.ToInt32(item.Cells["NumeroHasta"].Value);
                    dNumeracion.TipoComprobante = Convert.ToInt32(item.Cells["ComprobanteNro"].Value);
                    dNumeracion.Estado = item.Cells["Estado"].Value.ToString();
                    DTimbrado timbrado = new DTimbrado() { IdTimbrado = Convert.ToInt32(item.Cells["IdTimbrado"].Value) };
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

                    rpta = NNumeracionFactura.Editar(t, ListaNumeracion);
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
                    this.MensajeError(rpta);
                    return;
                }

                this.IsNuevo = true;
                this.IsEditar = false;
                this.Limpiar();
                this.MostrarTimbrado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private bool Validaciones()
        {
            if (this.txtNroTimbrado.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtNroTimbrado, "Ingrese el nro. de Timbrado");
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
                Habilitar(false);
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
                if (dgTimbrados.CurrentCell == null)
                {
                    MensajeError("No ha seleccionado ningun registro");
                    return;
                }

                if (!ControlesCompartidos.MensajeConfirmacion(this, "Desea eliminar el registro?"))
                    return;


                string codigo;
                string rpta = "";
                try
                {
                    int indiceFila = dgTimbrados.CurrentCell.RowIndex;
                    DataTable dtTimbrado = (DataTable)dgTimbrados.DataSource;
                    DataRow row = dtTimbrado.Rows[indiceFila];

                    codigo = Convert.ToString(row["IdTimbrado"]);
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
                catch (Exception ex)
                {
                    throw ex;
                }

                this.Limpiar();
                this.MostrarTimbrado();
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            Limpiar();
            Habilitar(true);
            Botones(true);
            Mostrar(IdTimbrado);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string estadoNum = chkEstadoNumeracion.Checked ? "A" : "I";
            int tipoComprobante = Convert.ToInt32(cboComprobante.SelectedValue);
            foreach (DataGridViewRow item in dataListado.Rows)
            {
                if (item.Cells["Estado"].ToString() == estadoNum &&
                   Convert.ToInt32(item.Cells["ComprobanteNro"]) == tipoComprobante)
                {
                    MensajeError("Ya existe una numeración con estado ACTIVO para el mismo tipo de comprobante.");
                }
            }

            dtNumeracion = (DataTable)dataListado.DataSource;
            var newRow = dtNumeracion.NewRow();
            newRow["id"] = 0;
            newRow["Establecimiento"] = txtEstablecimiento.Text;
            newRow["PuntoExpedicion"] = txtPuntoExpedicion.Text;
            newRow["NumeroDesde"] = txtNumeroDesde.Text;
            newRow["NumeroHasta"] = txtNumeroHasta.Text;
            newRow["NroTimbrado"] = txtNroTimbrado.Text;
            newRow["ComprobanteNro"] = tipoComprobante;
            newRow["TipoComprobante"] = cboComprobante.Text;
            newRow["IdTimbrado"] = IdTimbrado;
            newRow["Estado"] = estadoNum;
            dtNumeracion.Rows.InsertAt(newRow, 0);
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = dataListado.CurrentCell.RowIndex;
                dtNumeracion = (DataTable)dataListado.DataSource;
                DataRow row = dtNumeracion.Rows[indiceFila];

                this.dtNumeracion.Rows.Remove(row);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgTimbrados_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgTimbrados.Rows.Count == 0)
                    return;
                //Cargar datos del timbrado
                txtNroTimbrado.Text = dgTimbrados.CurrentRow.Cells["NroTimbrado"].Value.ToString();
                chkEstadoTimbrado.Checked = dgTimbrados.CurrentRow.Cells["Estado"].Value.Equals("A");
                dtpFechaInicioVigencia.Value = Convert.ToDateTime(dgTimbrados.CurrentRow.Cells["FechaInicioVigencia"].Value);
                dtpFechaVencimiento.Value = Convert.ToDateTime(dgTimbrados.CurrentRow.Cells["FechaFinVigencia"].Value);
                if (dgTimbrados.CurrentRow.Cells["Ind_Autoimprenta"].Value.ToString().Equals("S"))
                    rbAutoimprenta.Checked = true;
                else
                    rbManual.Checked = true;

                //Mostrar Numeraciones ligadas al timbrado
                IdTimbrado = Convert.ToInt32(dgTimbrados.CurrentRow.Cells["IdTimbrado"].Value);
                Mostrar(IdTimbrado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnEditarTimbrado_Click(object sender, EventArgs e)
        {
            IsEditar = true;
            IsNuevo = false;
            Habilitar(true);
            Botones(true);
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Checked)
            {
                // Desmarca los otros RadioButton
                foreach (RadioButton otherRadioButton in grbNumeracion.Controls.OfType<RadioButton>().Where(rb => rb != radioButton))
                {
                    otherRadioButton.Checked = false;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
