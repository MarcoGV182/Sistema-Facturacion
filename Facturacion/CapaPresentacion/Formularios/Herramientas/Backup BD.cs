using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Data.SqlClient;
using CapaNegocio;

namespace CapaPresentacion.Formularios.Herramientas
{
    public partial class Backup_BD : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader Reader;
        string conexion="";
        string sql = "";



        //INSTANCIA PARA LLAMAR SOLO UNA VEZ AL FORMULARIO
        private static Backup_BD _Instancia;

        public static Backup_BD GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new Backup_BD();
            }
            return _Instancia;
        }




        public Backup_BD()
        {
            InitializeComponent();
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

        private void Backup_BD_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try 
            {
                conexion = "Data Source=" + txtdatasource.Text + "; User Id=" + txtusuario.Text + ";Password="+ txtpass.Text + "";
                conn = new SqlConnection(conexion);
                conn.Open();
                //sql = "Exec sp_Databases";
                sql = "Select * from sys.databases d where d.database_id>4";
                cmd = new SqlCommand(sql,conn);
                Reader = cmd.ExecuteReader();
                cboBD.Items.Clear();
                while(Reader.Read()) {
                    cboBD.Items.Add(Reader[0].ToString());
                }
                txtdatasource.Enabled = false;
                txtpass.Enabled = false;
                txtusuario.Enabled = false;
                btnConectar.Enabled = false;
                btnDesconectar.Enabled = true;
                btnBackup.Enabled = true;
                btnrestaurar.Enabled = true;


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            txtdatasource.Enabled = true;
            txtpass.Enabled = true;
            txtusuario.Enabled = true;
            cboBD.Enabled = false;
            btnConectar.Enabled = true;
            btnDesconectar.Enabled = false;
            btnBackup.Enabled = false;
            btnrestaurar.Enabled = false;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try 
            {
                if(cboBD.Text.CompareTo("")==0) {
                    MessageBox.Show("Por favor primero elija una base de datos");
                    return;
                }
                conn = new SqlConnection(conexion);
                conn.Open();
                sql= "BACKUP DATABASE " + cboBD.Text+" TO DISK= '"+ txtubicacion.Text +"\\"+cboBD.Text+"-"+DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") +".bak'";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                MessageBox.Show("Se ha realizado con exito");

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog()== DialogResult.OK) {
                txtubicacion.Text = fbd.SelectedPath;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Backup File(*.bak)|*.bak|All Files(*.*)|*.*";
            open.FilterIndex = 0;
            if(open.ShowDialog()== DialogResult.OK) 
            {
                txtarchivo.Text = open.FileName;            
            }

        }

        private void btnrestaurar_Click(object sender, EventArgs e)
        {
            
            if (cboBD.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("Por favor primero elija una base de datos");
                    return;
                }
                else 
                {

                    btnrestaurar.Enabled = false;
                    btnrestaurar.Text = "Restaurando...";
                    btnrestaurar.Refresh();


                conn = new SqlConnection(conexion);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                try
                {
                    string sqlcmd2 = string.Format("ALTER DATABASE [" + this.cboBD.Text + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand bu2 = new SqlCommand(sqlcmd2, conn);
                    bu2.ExecuteNonQuery();

                    string sqlcmd3 = "USE MASTER RESTORE DATABASE [" + this.cboBD.Text + "] FROM DISK='" + this.txtarchivo.Text + "'WITH REPLACE;";
                    SqlCommand bu3 = new SqlCommand(sqlcmd3, conn);
                    bu3.ExecuteNonQuery();

                    string sqlcmd4 = string.Format("ALTER DATABASE [" + this.cboBD.Text + "] SET MULTI_USER");
                    SqlCommand bu4 = new SqlCommand(sqlcmd4, conn);
                    bu4.ExecuteNonQuery();

                    MessageBox.Show("La Base de Datos se ha restaurado con exito");
                    conn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
              
            this.btnrestaurar.Text = "Restaurar";
            this.btnrestaurar.Enabled = true;
            this.btnrestaurar.Refresh();
        }
      }
    
}       
