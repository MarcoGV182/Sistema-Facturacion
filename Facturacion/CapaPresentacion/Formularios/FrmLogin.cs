using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FrmLogin : Form
    {        
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
                    txtPass.Clear();
                    txtPass.Focus();
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
        

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter) {
                this.btnIngresar_Click(null,null);
            }
        }



        #region Eventos de Mouse
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int Iparam);

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion
    }
}
