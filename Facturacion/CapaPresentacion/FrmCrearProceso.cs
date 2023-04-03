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
    public partial class FrmCrearProceso : Form
    {
        //para obtener el id del usuario logueado
        public int id;


        private bool IsNuevo = false;
        private bool IsEditar = false;

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmCrearProceso _Instancia;
        public static FrmCrearProceso GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmCrearProceso();
            }
            return _Instancia;
        }

        public FrmCrearProceso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(txtDescripcion, "Por favor ingrese una descripcion");
            //this.ttMensaje.SetToolTip(txtBuscar, "Teclee para buscar");
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
            this.txtCodigo.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
        }

        //Habilitar botones
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                //this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                //this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                //this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                //this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

       

        private void FrmProceso_Load(object sender, EventArgs e)
        {
            int mes = DateTime.Now.Month;
            this.cboMes.SelectedIndex = mes - 1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtDescripcion.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtDescripcion.Text == string.Empty)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtDescripcion, "Ingrese la Descripcion del Proceso");
                }
                else
                {
                    //si se ingresa un nuevo registro
                   // if (this.IsNuevo)
                    //{
                        rpta = NProceso.Insertar(this.txtDescripcion.Text.Trim().ToUpper(),this.cboMes.Text,this.dtpFechaInicio.Value,this.dtpFechaFin.Value,id);

                    //si se esta editando el registro    
                    //}
                    /*else
                    {
                       rpta = NProceso.Editar(Convert.ToInt32(this.txtCodigo.Text), this.txtDescripcion.Text.Trim().ToUpper(),this.cboMes.Text, this.dtpFechaInicio.Value, this.dtpFechaFin.Value);
                    }*/
                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOK("Operacion exitosa");
                        this.Close();
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    //this.IsEditar = false;
                    //this.Botones();
                    //this.Limpiar();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                            

        private void FrmProceso_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_Instancia = null;            
            FrmProceso frm = FrmProceso.GetInstancia();
            frm.cboEstado_SelectedValueChanged(null, null);            
        }
    }
}
