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

namespace CapaPresentacion.Formularios.ChildForms
{
    public partial class FrmVistaRetencion : Form
    {

        private static FrmVistaRetencion _Instancia;

        public static FrmVistaRetencion GetInstancia() {
            if(_Instancia==null) {
                _Instancia = new FrmVistaRetencion();
            }
            return _Instancia;
        }


        public FrmVistaRetencion()
        {
            InitializeComponent();
        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            this.dataListado.DataSource = NRetencion.Buscar(this.txtNroFactura.Text,Convert.ToInt32(this.txtnrocliente.Text));
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


        public void ObtenerDatos(DateTime fecha, string factura, string cliente, string nrocliente,string monto)
        {
            this.txtFecha.Text = fecha.ToString("dd/MM/yyyy");
            this.txtNroFactura.Text = factura;
            this.txtCliente.Text = cliente;
            this.txtnrocliente.Text = nrocliente;
            this.txtmonto.Text = Convert.ToDouble(monto).ToString();
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void FrmRetencion_Load(object sender, EventArgs e)
        {
            
            Mostrar();
            this.txtImporte.Text = 0.ToString();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int codigo = 0;
            try
            {
                string rpta = "";
                if (dataListado.Rows.Count == 0) 
                {
                    if (this.txtImporte.Text == string.Empty)
                    {
                        this.MensajeError("Falta algunos datos");
                        errorIcono.SetError(txtImporte, "Ingrese el importe");
                    }
                    else if(Convert.ToDecimal(this.txtImporte.Text)==0 ) 
                    {
                       
                        errorIcono.SetError(txtImporte, "El importe no puede ser mayor al Total de la factura o igual a 0");
                    }

                    else
                    {

                        {
                            rpta = NRetencion.Insertar(dtpFechaRetencion.Value, Convert.ToDateTime(txtFecha.Text), Convert.ToInt32(txtnrocliente.Text), txtNroFactura.Text, 2, Convert.ToDecimal(txtImporte.Text));
                             
                        }
                        if (rpta.Equals("OK"))
                        {

                            {
                                this.MensajeOK("Se ha insertado con exito");
                                this.Close();
                            }

                        }
                        else
                        {
                            this.MensajeError(rpta);
                        }
                    }
                }
                else 
                {
                    DialogResult opcion;
                    opcion = MessageBox.Show("La factura ya poseen una retencion."+ Environment.NewLine +"Desea eliminar el registro ?", "Sistema de Facturacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (opcion == DialogResult.OK)
                    { 
                        foreach (DataGridViewRow row in dataListado.Rows)
                        {
                            
                                codigo = Convert.ToInt32(row.Cells["RetencionNro"].Value);
                                rpta = NRetencion.Eliminar(codigo);

                                if (rpta.Equals("OK"))
                                {
                                    this.MensajeOK("Se elimino correctamente el registro");
                                }
                                else
                                {
                                    this.MensajeError(rpta);
                                }
                        }
                        this.Mostrar();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
