using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmUsuario : Form
    {
        bool IsNuevo = false;
        bool IsEditar = false;
        public string nombre;
        public string apellido;
        public string usuario;
        public string acceso;

        private static FrmUsuario _Instancia;

        public static FrmUsuario GetInstancia() 
        {
            if(_Instancia==null) 
            {
                _Instancia = new FrmUsuario();
            }
            return _Instancia;
        }


        public FrmUsuario()
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

        //Limpiar los controles del formulario
        private void Limpiar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.cboCiudad.Text = string.Empty;
            this.dtpFechaNac.Text = string.Empty;
            this.cboEstado.Text = string.Empty;

            //CONTROLES DE ACCESO DE USUARIO
            this.txtUsuario.Text = string.Empty;
            this.txtpass2.Text = string.Empty;
            this.cboAcceso.SelectedIndex = 0;
        }

        //Habilitar botones
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.txtDocumento.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtObservacion.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.cboCiudad.Enabled = valor;
            this.dtpFechaNac.Enabled = valor;
            this.cboEstado.Enabled = valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtpass2.ReadOnly = !valor;
            this.cboAcceso.Enabled = valor;
            LeyendaContraseña();
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        //ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[5].Visible = false;
            this.dataListado.Columns[6].Visible = false; 
            this.dataListado.Columns[7].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[13].Visible = false;
        }

        private void LlenarComboBox()
        {
            cboCiudad.DataSource = NCiudad.Mostrar();
            cboCiudad.ValueMember = "CiudadNro";
            cboCiudad.DisplayMember = "Descripcion";

            cboAcceso.DataSource = NTipoUsuario.Mostrar();
            cboAcceso.ValueMember = "IdRol";
            cboAcceso.DisplayMember = "Nombre";
        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {
            //List<DUsuarios> usuario = Conversiones.ConvertDataTable<DUsuarios>(NUsuarios.Mostrar());
            this.dataListado.DataSource = NUsuarios.Mostrar();
            //this.dataListado.Columns["Descripcion"].Width = 100;
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo buscar por descripcion
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NUsuarios.Buscar(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            if(btnver.Text=="Ver") {
                this.txtpass2.PasswordChar= char.Parse("\0");
                btnver.Text = "Ocultar";
            }
            else
            {
                this.txtpass2.PasswordChar = '*' ;
                btnver.Text = "Ver";
            }
        }*/

        private void FrmUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
                      

            if (chkEliminar.Checked == false)
            {
                chktodos.Visible = false;
                btnEliminar.Enabled = false;
            }
            //top para ubicar en la parte superior
            this.Top = 0;
            //alineado hacia la izquierda
            this.Left = 0;
            this.Habilitar(false);
            this.Botones();
            this.Mostrar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.cboEstado.SelectedIndex = 0;
            this.txtNombre.Focus();

            
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


                DUsuarios user = new DUsuarios();
                user.Nombre = this.txtNombre.Text.Trim().ToUpper();
                user.Apellido = this.txtApellido.Text.Trim().ToUpper();
                user.Documento = this.txtDocumento.Text.Trim();
                user.FechaNacimiento = dtpFechaNac.Checked == false ? (DateTime?)null : dtpFechaNac.Value;
                user.CiudadNro = Convert.ToInt32(cboCiudad.SelectedValue);
                user.Direccion = this.txtDireccion.Text.Trim();
                user.Telefono = this.txtTelefono.Text.Trim();
                user.Email = this.txtEmail.Text.Trim();
                user.Estado = this.cboEstado.Text;
                user.Observacion = this.txtObservacion.Text.Trim().ToUpper();
                user.Usuario = this.txtUsuario.Text.Trim().ToUpper();
                user.Pass = this.txtPass1.Text;
                user.passNew = this.txtpass2.Text;
                user.TipoUserNro = Convert.ToInt32(this.cboAcceso.SelectedValue);

                //si se ingresa un nuevo registro
                if (this.IsNuevo)
                {
                    rpta = NUsuarios.Insertar(user);
                }

                //SI SE EDITAR
                else
                {
                    user.PersonaNro = Convert.ToInt32(txtCodigo.Text);
                    rpta = NUsuarios.Editar(user);
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
            if (this.txtNombre.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtNombre, "Ingrese la Nombre");
                return false;
            }
            
            if (this.txtDocumento.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(txtDocumento, "Ingrese el Nro de documento");
                return false;
            }
            
            if (this.cboEstado.Text == string.Empty)
            {
                this.MensajeError("Falta algunos datos");
                errorIcono.SetError(cboEstado, "Ingrese el Estado");
                return false;
            }
            
            if (this.cboAcceso.Text == "Supervisor" && acceso != "Supervisor")
            {
                this.MensajeError("Solo el supervisor puede registrar a otro supervisor");
                return false;
            }

            if ((txtPass1.Text != string.Empty && txtpass2.Text == string.Empty) ||
                (txtPass1.Text == string.Empty && txtpass2.Text != string.Empty))
            {
                this.MensajeError("Favor verificar los datos del pass solicitado");
                return false;
            }

            if (IsNuevo)
            {
                if (txtPass1.Text != txtpass2.Text)
                {
                    this.MensajeError("Las contraseñas no coinciden. Favor verifiquelo");
                    return false;
                }
            }
            

            return true;
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

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (!this.txtCodigo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);

                this.groupBox2.Enabled = true;
                /*this.txtUsuario.Enabled = false;
                this.txtpass.Enabled = false;
                this.cboAcceso.Enabled = false;
                this.btnver.Enabled = false;*/
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a modificar");
            }
        }

        private void LeyendaContraseña() 
        {
            if (IsEditar)
            {
                lblPass1.Text = "Pass Anterior";
                lblPass2.Text = "Pass Nuevo";
            }
            else
            {
                lblPass1.Text = "Password: (*)";
                lblPass2.Text = "Repetir Pass (*)";
            }
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

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["UsuarioNro"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtApellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido"].Value);
            this.txtDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Documento"].Value);
            this.dtpFechaNac.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["fechaNacimiento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Email"].Value);
            this.cboCiudad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Ciudad"].Value);
            this.cboEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value);
            this.txtObservacion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Observacion"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Login"].Value);
            this.txtpass2.Text = string.Empty;//Convert.ToString(this.dataListado.CurrentRow.Cells["Password"].Value);
            this.cboAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Acceso"].Value);
            //mostrar la segunda pestana la de mantenimiento al hacer doble click
            this.tabControl1.SelectedIndex = 1;            
            this.txtpass2.PasswordChar = '*';
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
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
                        codigo = Convert.ToString(row.Cells[1].Value);
                        rpta = NUsuarios.Eliminar(Convert.ToInt32(codigo));

                        if (!rpta.Equals("OK")) 
                        {
                            MensajeError(rpta);
                            break;
                        }
                    }
                }

                if (rpta.Equals("OK") && x == 1)
                {
                    this.MensajeOK("Se elimino correctamento el registro");
                }

                if (rpta.Equals("OK") && x > 1)
                {
                    this.MensajeOK($"Se eliminaron correctamento la cantidad de {x} registros ");
                }

                if (!rpta.Equals("OK"))
                {
                    this.MensajeError($"Ocurrio un error: {rpta}");
                }

                this.Mostrar();
                this.chkEliminar.Checked = false;
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
        

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //this.dataListado.Columns["Salario"].DefaultCellStyle.Format = "N0";
        }

       
    }
}
