using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion.Formularios.Mantenimiento
{
    public partial class FrmEmpresa : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmEmpresa _Instancia;

        public static FrmEmpresa GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmEmpresa();
            }
            return _Instancia;
        }



        public FrmEmpresa()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(txtNombre, "Ingrese la descripcion de la Empresa");
            
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
            this.txtNombre.Text = string.Empty;
        }

        //Habilitar botones
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
        }
        

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NEmpresa.Mostrar();

                this.txtCodigo.Text = datos.Rows[0]["EmpresaNro"].ToString();
                this.txtNombre.Text = datos.Rows[0]["Nombre"].ToString();
                this.txtRuc.Text = datos.Rows[0]["RUC"].ToString();
                this.dtpFechaInicio.Value = Convert.ToDateTime(datos.Rows[0]["FechaInicio"].ToString());
                this.txtEslogan.Text = datos.Rows[0]["Eslogan"].ToString();
                this.txtDireccion.Text = datos.Rows[0]["Direccion"].ToString();
                //PARA MOSTRAR LA IMAGEN
                byte[] imagenBuffer = (byte[])datos.Rows[0]["Logo"];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
                this.pxLogo.Image = Image.FromStream(ms);
                this.pxLogo.SizeMode = PictureBoxSizeMode.StretchImage;

                var valorFondo = ControlesCompartidos.ObtenerValorAppSettings();
                if (valorFondo.Equals("N"))
                {
                    chkFondoPantalla.Checked = false;
                }
                else if(valorFondo.Equals("S"))
                {
                    chkFondoPantalla.Checked = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void FrmEmpresa_Load(object sender, EventArgs e)
        {   
            //top para ubicar en la parte superior
            this.Top = 0;
            //alineado hacia la izquierda
            this.Left = 0;
            this.Mostrar();
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(txtNombre, "Ingrese la descripcion");
                    return;
                }

                 if(this.pxLogo.Image==null)
                {
                    this.MensajeError("Falta algunos datos");
                    errorIcono.SetError(pxLogo, "Seleccione una imagen. Esta imagen irá en la factura");
                    return;
                }


                errorIcono.Clear();
                //GUARDAMOS LA IMAGEN EL EL BUFFER
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                this.pxLogo.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                //DECLARAMOS UNA VARIABLE DE TIPO BYTE PARA OBTENER LA IMAGEN GUARDADA EN EL BUFFER
                byte[] logo;
                logo = ms.GetBuffer();

                DateTime? fecha;
                if (dtpFechaInicio.Checked == true)
                {
                    fecha = dtpFechaInicio.Value;
                }
                else
                {
                    fecha = null;
                }

                DEmpresa empresa = new DEmpresa()
                {
                    Nombre = this.txtNombre.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    FechaInicio = fecha,
                    Ruc = this.txtRuc.Text,
                    Slogan = this.txtEslogan.Text,
                    Logo = logo
                };

                //si se ingresa un nuevo registro
                if (txtCodigo.Text == string.Empty)
                {
                    IsNuevo = true;
                    IsEditar = false;

                    rpta = NEmpresa.Insertar(empresa);
                    //si se esta editando el registro    
                }
                else
                {
                    empresa.EmpresaNro = Convert.ToInt32(this.txtCodigo.Text);
                    IsNuevo = false;
                    IsEditar = true;
                    rpta = NEmpresa.Editar(empresa);
                }

                if (chkFondoPantalla.Checked) 
                {
                    ActualizarConfiguracion("S");
                }
                else
                {
                    ActualizarConfiguracion("N");
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
                this.Limpiar();
                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ActualizarConfiguracion(string valor) 
        {
            // Modificar el valor de la clave especificada
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Ind_logoFondoPantalla"].Value = valor;
            config.Save(ConfigurationSaveMode.Modified);

            // Recargar la sección de configuración para que los cambios surtan efecto
            ConfigurationManager.RefreshSection("appSettings");
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Limpiar();
            this.Habilitar(false);
        }
        

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (!this.txtCodigo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a modificar");
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {

            this.IsNuevo = false;
            this.IsEditar = false;
            this.Limpiar();
            this.Habilitar(false);
        }
        

        private void FrmEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null; 
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult resultado = dialog.ShowDialog();

            if (resultado==DialogResult.OK)
            {
                this.pxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxLogo.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxLogo.Image = global::CapaPresentacion.Properties.Resources.FacEasy; 
        }
    }
    
}
