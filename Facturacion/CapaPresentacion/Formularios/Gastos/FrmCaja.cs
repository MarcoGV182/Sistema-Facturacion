﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class FrmCaja : Form
    {
        //atributos para obtener al usuario
        public string id;
        public string usuario;
        public string nombre;
        public string apellido;
        public string acceso;

        private Point mouseOffset;
        private bool isDragging = false;


        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmCaja _Instancia;

        public static FrmCaja GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmCaja();
            }
            return _Instancia;
        }



        public FrmCaja()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(txtMonto, "Ingrese el importe de apertura de la caja");
            this.ttMensaje.SetToolTip(txtObservacion, "Ingrese una Observacion");
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
            this.txtMonto.Text = string.Empty;
            this.txtObservacion.Text = string.Empty;
        }

        private void FrmCaja_Load(object sender, EventArgs e)
        {                      
            this.lbUsuario.Text = usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                #region Validacion Previa
                if (this.txtMonto.Text == string.Empty)
                {
                    MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtMonto, "Ingrese el importe de la caja");
                    return;
                }
                #endregion

                ECaja eCaja = new ECaja();
                eCaja.FechaApertura = this.dtpFechaApertura.Value;
                eCaja.PersonaNro = Convert.ToInt32(this.id);
                eCaja.ImporteApertura = Convert.ToDouble(this.txtMonto.Text);
                eCaja.Observacion = this.txtObservacion.Text;

                rpta = NCaja.InsertarCaja(eCaja);
                //si se esta editando el registro    

                if (rpta.Equals("OK"))
                {
                    MensajeOK("La Caja se ha abierto con exito");
                    Close();
                }
                else
                {
                    MensajeError(rpta);
                    return;
                }

                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.Close();
        }

        private void FrmCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlesCompartidos.SoloNumeros(e);
        }
               

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            ControlesCompartidos.FormatoNumero(sender);
        }


        #region Eventos de Mouse
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOffset = new Point(-e.X, -e.Y);
                isDragging = true;
            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && e.Button == MouseButtons.Left)
            {
                var activo = this.Focused;
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePos;
            }
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;

            }
        }

        #endregion
    }
}
