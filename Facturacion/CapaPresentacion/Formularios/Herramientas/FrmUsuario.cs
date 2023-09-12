using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion.Formularios.Herramientas
{
    public partial class FrmUsuario : Form
    {
        bool IsNuevoColaborador = false;
        bool IsEditarColaborador = false;
        bool esUsuario = false;
        public string idUsuario;
        public string nombre;
        public string apellido;
        public string usuario;
        public string acceso;

        int? idColaborador = null;

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
            idColaborador = null;
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cboCiudad.Text = string.Empty;
            dtpFechaNac.Text = string.Empty;
            cboEstado.Text = string.Empty;
            txtObservacion.Text = string.Empty;

            dtpFechaNac.Checked = false;
            dtpFechaIngreso.Checked = false;
            dtpFechaEgreso.Checked = false;

            dtpFechaNac.Value = ReiniciarFechas();
            dtpFechaIngreso.Value = ReiniciarFechas();
            dtpFechaEgreso.Value = ReiniciarFechas(); 

            //CONTROLES DE ACCESO DE USUARIO
            txtUsuario.Text = string.Empty;
            txtPass1.Text = string.Empty;
            txtPass2.Text = string.Empty;
            cboAcceso.SelectedIndex = 0;
        }

        private DateTime ReiniciarFechas() 
        {
            return DateTime.Now;
        }

        //Habilitar botones
        private void Habilitar(bool valor)
        {
            #region Tab Colaborador
            txtCodigo.ReadOnly = !valor;
            txtNombre.ReadOnly = !valor;
            txtApellido.ReadOnly = !valor;
            txtDocumento.ReadOnly = !valor;
            txtDireccion.ReadOnly = !valor;
            txtTelefono.ReadOnly = !valor;
            txtObservacion.ReadOnly = !valor;
            txtEmail.ReadOnly = !valor;
            cboCiudad.Enabled = valor;
            dtpFechaNac.Enabled = valor;
            dtpFechaIngreso.Enabled = valor;
            dtpFechaEgreso.Enabled = valor;
            cboEstado.Enabled = valor;
            #endregion

            if (!acceso.ToUpper().Equals("ADMINISTRADOR"))
            {
                //Si el usuario no es ADM entonces se oculta la pestaña de Colaborador
                idColaborador = Convert.ToInt32(idUsuario);
                TabPage pg = tabControl1.TabPages["tabColaborador"];
                if (pg != null) { tabControl1.TabPages.Remove(pg); }

                chkEliminar.Visible = false;
                btnEliminar.Visible = false;
                cboAcceso.Enabled = false;
            }

            LeyendaContraseña();
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevoColaborador || this.IsEditarColaborador)
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
                this.btnCancelar.Enabled = true;
            }
        }

        //ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[5].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[14].Visible = false;
        }

        private void LlenarComboBox()
        {
            cboCiudad.DataSource = ControlesCompartidos.AgregarNuevaFila(NCiudad.Mostrar(), "Descripcion", "CiudadNro");
            cboCiudad.ValueMember = "CiudadNro";
            cboCiudad.DisplayMember = "Descripcion";

            cboAcceso.DataSource = ControlesCompartidos.AgregarNuevaFila(NTipoUsuario.Mostrar(), "Nombre", "IdRol" );
            cboAcceso.ValueMember = "IdRol";
            cboAcceso.DisplayMember = "Nombre";
        }

        //Metodo para mostrar los datos en el datagrid
        private void Mostrar()
        {   
            this.dataListado.DataSource = NColaborador.Mostrar(idColaborador);
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
            this.Botones();
            this.Mostrar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevoColaborador = true;
            this.IsEditarColaborador = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);

            //Inicializar algunos controles
            this.cboEstado.SelectedIndex = 0;
            dtpFechaEgreso.Checked = false;
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


                DColaborador Colaborador = new DColaborador();
                Colaborador.Nombre = this.txtNombre.Text.Trim().ToUpper();
                Colaborador.Apellido = this.txtApellido.Text.Trim().ToUpper();
                Colaborador.Documento = this.txtDocumento.Text.Trim();
                Colaborador.FechaNacimiento = dtpFechaNac.Checked == false ? (DateTime?)null : dtpFechaNac.Value;
                Colaborador.CiudadNro = Convert.ToInt32(cboCiudad.SelectedValue) == 0 ? (int?)null : Convert.ToInt32(cboCiudad.SelectedValue);
                Colaborador.Direccion = this.txtDireccion.Text.Trim();
                Colaborador.Telefono = this.txtTelefono.Text.Trim();
                Colaborador.Email = this.txtEmail.Text.Trim();
                Colaborador.Estado = this.cboEstado.Text == "ACTIVO" ? "A" : "I";
                Colaborador.Observacion = this.txtObservacion.Text.Trim().ToUpper();
                Colaborador.FechaIngreso = dtpFechaIngreso.Value;
                Colaborador.FechaEgreso = dtpFechaEgreso.Checked == false ? (DateTime?)null : dtpFechaEgreso.Value;

                //si se ingresa un nuevo registro
                if (this.IsNuevoColaborador)
                {
                    rpta = NColaborador.Insertar(Colaborador);
                }

                //SI SE EDITAR
                else
                {
                    Colaborador.PersonaNro = idColaborador.Value;
                    rpta = NColaborador.Editar(Colaborador);
                }
                if (rpta.Equals("OK"))
                {
                    if (IsNuevoColaborador)
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

                this.IsNuevoColaborador = false;
                this.IsEditarColaborador = false;
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

            if (dtpFechaIngreso.Checked == false)
            {
                this.MensajeError("Debe de ingresar la fecha de Ingreso del colaborador");
                errorIcono.SetError(dtpFechaIngreso, "Ingrese la fecha de Ingreso del colaborador");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !ControlesCompartidos.ValidarDireccionCorreo(txtEmail.Text))
            {
                this.MensajeError("Formato incorrecto");
                errorIcono.SetError(txtEmail, "Favor verifique que el formato del correo sea correcto");
                return false;
            }

            if (cboEstado.Text == "INACTIVO" && !dtpFechaEgreso.Checked )
            {
                this.MensajeError("El colaborador está inactivo, debe ingresar la fecha de salida");
                errorIcono.SetError(dtpFechaEgreso, "Ingrese la fecha de Salida del colaborador");
                return false;
            }

            return true;
        }

        private bool ValidacionesUsuario()
        {
            errorIcono.Clear();

            if (idColaborador.GetValueOrDefault() == 0)
            {
                MensajeError("Debe registrar primeramente al colaborador");
                return false;
            }

            if (this.cboAcceso.Text == "Supervisor" && acceso != "Supervisor")
            {
                this.MensajeError("Solo el supervisor puede registrar a otro supervisor");
                return false;
            }

            if ((txtPass1.Text != string.Empty && txtPass2.Text == string.Empty) ||
                (txtPass1.Text == string.Empty && txtPass2.Text != string.Empty))
            {
                this.MensajeError("Favor verificar los datos del pass solicitado. Uno de los datos no fue ingresado");
                return false;
            }

            if (!string.IsNullOrEmpty(txtUsuario.Text))
            {
                if (string.IsNullOrEmpty(txtPass1.Text) || string.IsNullOrEmpty(txtPass2.Text))
                {
                    errorIcono.SetError(txtPass1, "Ingrese la contraseña de acceso");
                    errorIcono.SetError(txtPass2, "Repita la contraseña de acceso");
                    this.MensajeError("Para registrar al usuario debe de ingresar las contraseñas de acceso");
                    return false;
                }
            }

            if (!esUsuario)
            {
                if (txtPass1.Text != txtPass2.Text)
                {
                    this.MensajeError("Las contraseñas no coinciden. Favor verifiquelo");
                    return false;
                }
            }

            if (Convert.ToInt32(cboAcceso.SelectedValue) == 0)
            {
                errorIcono.SetError(cboAcceso, "Seleccione el rol del usuario");
                this.MensajeError("Favor seleccione el rol del Usuario");
                return false;
            }


            return true;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtCodigo.Text.Equals(""))
            {
                this.IsEditarColaborador = true;
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
                this.IsEditarColaborador = true;
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
            if (esUsuario)
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
            this.IsNuevoColaborador = false;
            this.IsEditarColaborador = false;
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
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ColaboradorNro"].Value);
            idColaborador = Convert.ToInt32(txtCodigo.Text);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtApellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido"].Value);
            this.txtDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Documento"].Value);
            esUsuario = this.dataListado.CurrentRow.Cells["Es_Usuario"].Value.ToString() == "SI" ? true : false;
            if (Convert.IsDBNull(this.dataListado.CurrentRow.Cells["fechaNacimiento"].Value))
            {
                dtpFechaNac.Checked = false;
                txtEdad.Text = string.Empty;
            }
            else
            {
                this.dtpFechaNac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fechaNacimiento"].Value);
                txtEdad.Text = CalcularEdad(dtpFechaNac.Value).ToString();
            }

            //Fecha de ingreso
            if (Convert.IsDBNull(this.dataListado.CurrentRow.Cells["FechaIngreso"].Value))
            {
                dtpFechaIngreso.Checked = false;
            }
            else
            {
                dtpFechaIngreso.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["FechaIngreso"].Value);
            }

            //Fecha Egreso
            if (Convert.IsDBNull(this.dataListado.CurrentRow.Cells["FechaEgreso"].Value))
            {
                dtpFechaEgreso.Checked = false;
            }
            else
            {
                dtpFechaEgreso.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["FechaEgreso"].Value);
            }

            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Email"].Value);
            this.cboCiudad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Ciudad"].Value);
            this.cboEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value) == "A" ? "ACTIVO" : "INACTIVO";
            this.txtObservacion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Observacion"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Login"].Value);
            this.txtPass2.Text = string.Empty;//Convert.ToString(this.dataListado.CurrentRow.Cells["Password"].Value);
            this.cboAcceso.SelectedValue = Convert.IsDBNull(this.dataListado.CurrentRow.Cells["IdRol"].Value) ? 0 : Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdRol"].Value);
            //mostrar la segunda pestana la de mantenimiento al hacer doble click
            this.tabControl1.SelectedIndex = 1;
            this.txtPass2.PasswordChar = '*';
            this.IsNuevoColaborador = false;
            this.IsEditarColaborador = false;
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

        private void dtpFechaNac_ValueChanged(object sender, EventArgs e)
        {            
            txtEdad.Text = CalcularEdad(dtpFechaNac.Value).ToString();
        }
        

        public int CalcularEdad(DateTime fechaNacimiento)
        {
            // Obtiene la fecha actual:
            DateTime fechaActual = DateTime.Today;

            // Comprueba que la se haya introducido una fecha válida; si 
            // la fecha de nacimiento es mayor a la fecha actual se muestra mensaje 
            // de advertencia:
            if (fechaNacimiento > fechaActual)
            {                
                return 0;
            }
            else
            {
                int edad = fechaActual.Year - fechaNacimiento.Year;

                // Comprueba que el mes de la fecha de nacimiento es mayor 
                // que el mes de la fecha actual:
                if (fechaNacimiento.Month > fechaActual.Month)
                {
                    --edad;
                }

                return edad;
            }
        }

        private void btnGuardarUser_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (!ValidacionesUsuario())
                {
                    return;
                }

                DUsuarios user = new DUsuarios();
                user.PersonaNro = idColaborador.GetValueOrDefault();
                user.PersonaNro = Convert.ToInt32(txtCodigo.Text);
                user.Usuario = this.txtUsuario.Text.Trim().ToUpper();
                user.Pass = this.txtPass1.Text;
                user.passNew = this.txtPass2.Text;
                user.TipoUserNro = Convert.ToInt32(this.cboAcceso.SelectedValue);

                //si se ingresa un nuevo registro
                if (!esUsuario)
                {
                    rpta = NUsuarios.Insertar(user);
                }
                //SI SE EDITAR
                else
                {                    
                    rpta = NUsuarios.Editar(user);
                }

                if (rpta.Equals("OK"))
                {
                    if (!esUsuario)
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

               
                this.Botones();
                this.Limpiar();
                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
