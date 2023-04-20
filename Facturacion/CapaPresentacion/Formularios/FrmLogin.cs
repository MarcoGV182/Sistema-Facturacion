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

namespace CapaPresentacion.Formularios
{
    public partial class FrmLogin : Form
    {
        private Point mouseOffset;
        private bool isDragging = false;
        /*string id;
        string nombre;
        string usuario;
        string password;
        string acceso;
        string[] reglas;*/
        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static FrmLogin _Instancia;

        public static FrmLogin GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmLogin();
            }

            return _Instancia;
        }
        public FrmLogin()
        {
            InitializeComponent();
            lblhora.Text = DateTime.Now.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void Limpiar()
        {
            this.txtUsuario.Text = string.Empty;
            this.txtPass.Text = string.Empty;
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
          try 
          {

                DataTable DtLogin = NUsuarios.BuscarLogin(txtUsuario.Text.Trim(), txtPass.Text.Trim());
                //validar usuario
                if (DtLogin.Rows.Count == 0)
                {
                    MessageBox.Show("Usuario o Contraseña Incorrecta.\nFavor verifique", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                    txtUsuario.Focus();
                }
                else
                {
                    string estado = DtLogin.Rows[0]["Estado"].ToString();

                    if (estado.Equals("I"))
                    {
                        MessageBox.Show("El usuario/Colaborador se encuentra inactivo","Sistema de Facturación",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    FormPrincipal frm = new FormPrincipal();
                    frm.id = DtLogin.Rows[0]["UsuarioNro"].ToString();
                    frm.usuario = DtLogin.Rows[0]["Login"].ToString();
                    frm.nombre = DtLogin.Rows[0][1].ToString();
                    frm.apellido = DtLogin.Rows[0][2].ToString();
                    frm.acceso = DtLogin.Rows[0]["Rol"].ToString();
                    frm.estado = estado;
                    frm.reglas = Convert.IsDBNull(DtLogin.Rows[0]["Reglas"]) ? null: DtLogin.Rows[0]["Reglas"].ToString().Split(',');
                    this.Limpiar();
                    frm.Show();
                    this.Hide();
                }
            }
            catch(Exception ex) 
          {
                MessageBox.Show(ex.Message);
          }
           
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {   
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter) {
                this.btnIngresar_Click(null,null);
            }
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
