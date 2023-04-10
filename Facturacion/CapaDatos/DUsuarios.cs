using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace CapaDatos
{
    public class DUsuarios
    {
        private int _PersonaNro;
        private string _Nombre;
        private string _Apellido;
        private string _usuario;
        private string _pass;
        public string passNew { get; set; }
        private int _TipoUserNro;
        private string _TextoBuscar;
        private string[] _ReglaUsuario;


        public int PersonaNro
        {
            get{return _PersonaNro;}
            set{_PersonaNro = value;}
        }

        public string Nombre
        {
            get{return _Nombre;}
            set{_Nombre = value;}
        }

        public string Apellido
        {
            get{return _Apellido;}
            set{_Apellido = value;}
        }

        public string Usuario
        {
            get{return _usuario;}
            set{_usuario = value;}
        }

        public string Pass
        {
            get{return _pass;}
            set{_pass = value;}
        }

        public int TipoUserNro
        {
            get{return _TipoUserNro;}
            set{_TipoUserNro = value;}
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
     

        public string[] ReglaUsuario
        {
            get
            {
                return _ReglaUsuario;
            }

            set
            {
                _ReglaUsuario = value;
            }
        }        

        public DUsuarios() {

        }


        //Metodo Insertar
        public string InsertarUsuarios(DUsuarios Usuario, SqlConnection sqlConExistente = null, SqlTransaction SqltranExistente = null)
        {
            //declarar variable respuesta
            string rpta = "OK";
            //instanciamos la conexion
            SqlConnection Sqlcon = null;
            SqlTransaction SqlTran = null;
            try
            {
                //codigo
                Sqlcon = Conexion.AbrirConexion(Conexion.CadenaConexion, sqlConExistente);
                SqlTran = SqltranExistente ?? Sqlcon.BeginTransaction();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = SqlTran;
                SqlCmd.CommandText = "sp_InsertarUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUser = new SqlParameter();
                ParIdUser.ParameterName = "@IdUsuario";
                ParIdUser.SqlDbType = SqlDbType.Int;
                ParIdUser.Value = Usuario.PersonaNro;
                SqlCmd.Parameters.Add(ParIdUser);

                SqlParameter ParUser= new SqlParameter();
                ParUser.ParameterName = "@Usuario";
                ParUser.SqlDbType = SqlDbType.VarChar;
                ParUser.Size = 250;
                ParUser.Value = Usuario.Usuario;
                SqlCmd.Parameters.Add(ParUser);

                //Parametros Observacion
                SqlParameter ParPass = new SqlParameter();
                ParPass.ParameterName = "@Pass";
                ParPass.SqlDbType = SqlDbType.VarChar;
                ParPass.Size = 250;
                ParPass.Value = Usuario.Pass;
                SqlCmd.Parameters.Add(ParPass);

                //Parametros Observacion
                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@TipoUserNro";
                ParAcceso.SqlDbType = SqlDbType.Int;
                ParAcceso.Value = Usuario.TipoUserNro;
                SqlCmd.Parameters.Add(ParAcceso);

            
                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

                if (SqltranExistente == null)
                    SqlTran.Commit();
            }
            catch (Exception ex)
            {
                if (SqltranExistente == null)
                    SqlTran.Rollback();
                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon,ref sqlConExistente);
            }
            return rpta;
        }



        //Metodo Editar
        public string EditarUsuario(DUsuarios Usuario, SqlConnection sqlConExistente = null, SqlTransaction SqltranExistente = null)
        {
            //declarar variable respuesta
            string rpta = "OK";
            //instanciamos la conexion
            SqlConnection Sqlcon = null;
            SqlTransaction SqlTran = null;
            SqlCommand SqlCmd = new SqlCommand();
            try
            {
                //codigo
                Sqlcon = Conexion.AbrirConexion(Conexion.CadenaConexion, sqlConExistente);
                SqlTran = SqltranExistente ?? Sqlcon.BeginTransaction();
                //establecer el comando                
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = SqlTran;
                SqlCmd.CommandText = "sp_EditarUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros 
                SqlParameter ParPersonaNro = new SqlParameter();
                ParPersonaNro.ParameterName = "@PersonaNro";
                ParPersonaNro.SqlDbType = SqlDbType.Int;
                ParPersonaNro.Value = Usuario.PersonaNro;
                SqlCmd.Parameters.Add(ParPersonaNro);

                //Parametros Observacion
                SqlParameter ParUser = new SqlParameter();
                ParUser.ParameterName = "@Usuario";
                ParUser.SqlDbType = SqlDbType.VarChar;
                ParUser.Size = 250;
                ParUser.Value = Usuario.Usuario;
                SqlCmd.Parameters.Add(ParUser);


                //Parametros Contraseña anterior
                SqlParameter ParPassAnterior = new SqlParameter();
                ParPassAnterior.ParameterName = "@OldPass";
                ParPassAnterior.SqlDbType = SqlDbType.VarChar;
                ParPassAnterior.Size = 50;
                ParPassAnterior.Value = Usuario.Pass;
                SqlCmd.Parameters.Add(ParPassAnterior);

                SqlParameter ParPassNuevo = new SqlParameter();
                ParPassNuevo.ParameterName = "@NewPass";
                ParPassNuevo.SqlDbType = SqlDbType.VarChar;
                ParPassNuevo.Size = 50;
                ParPassNuevo.Value = Usuario.passNew;
                SqlCmd.Parameters.Add(ParPassNuevo);

                //Parametros Observacion
                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@TipoUserNro";
                ParAcceso.SqlDbType = SqlDbType.Int;
                ParAcceso.Value = Usuario.TipoUserNro;
                SqlCmd.Parameters.Add(ParAcceso);

                //ejecutar el comando sql                
                 SqlCmd.ExecuteNonQuery();
              

                if (SqltranExistente == null)
                    SqlTran.Commit();

            }
            catch (Exception ex)
            {
                if (SqltranExistente == null)
                    SqlTran.Rollback();
                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon);
            }
            return rpta;
        }



        //Metodo Eliminar
        public string EliminarUsuario(DUsuarios Usuario)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EliminarUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParUsuarioNro = new SqlParameter();
                ParUsuarioNro.ParameterName = "@UsuarioNro";
                ParUsuarioNro.SqlDbType = SqlDbType.Int;
                ParUsuarioNro.Value = Usuario.PersonaNro;
                SqlCmd.Parameters.Add(ParUsuarioNro);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open)
                    Sqlcon.Close();
            }

            return rpta;

        }



        //Metodo Mostrar
        public DataTable MostrarUsuarioCombo()
        {
            DataTable DtResultado = new DataTable("Usuario");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarUsuarioCombo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;

        }



        //Metodo Mostrar
        public DataTable BuscarUsuario(DUsuarios usuario)
        {
            DataTable DtResultado = new DataTable("Usuario");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = usuario.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);



                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;

        }

        
        //Metodo Buscar
        public DataTable BuscarLogin(DUsuarios Usuarios)
        {
            DataTable DtResultado = new DataTable("Usuario");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_Login";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParUser = new SqlParameter();
                ParUser.ParameterName = "@Usuario";
                ParUser.SqlDbType = SqlDbType.VarChar;
                ParUser.Size = 50;
                ParUser.SqlValue = Usuarios.Usuario;
                SqlCmd.Parameters.Add(ParUser);

                //Parametros
                SqlParameter ParPass = new SqlParameter();
                ParPass.ParameterName = "@Pass";
                ParPass.SqlDbType = SqlDbType.VarChar;
                ParPass.Size = 50;
                ParPass.SqlValue = Usuarios.Pass;
                SqlCmd.Parameters.Add(ParPass);

                //instanciar un DataAdapter
                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }


        //Metodo Mostrar
        /*public DataTable Mostrar_UsuarioServicio(DUsuarios usuario)
        {
            DataTable DtResultado = new DataTable("Usuario");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_Mostrar_UsuarioServicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParServicioNro = new SqlParameter();
                ParServicioNro.ParameterName = "@ServicioNro";
                ParServicioNro.SqlDbType = SqlDbType.Int;
                ParServicioNro.Value = usuario.ServicioNro;
                SqlCmd.Parameters.Add(ParServicioNro);

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;

        }*/




        //METODO PARA VERIFICAR LOS PERMISO QUE POSEE EL USUARIO AL LOGUEARSE AL SISTEMA 
        public bool ReglasVerificar(string reglas_Usuario,string[]reglas) 
        {
            ReglaUsuario=reglas;
            string[] aReglas_Usuario_Formulario = reglas_Usuario.Split(',');
            foreach (var r in aReglas_Usuario_Formulario)
            {
                if(r!="" && reglas.Contains(r)) 
                {
                    return true;
                }
            }

            return false;
        }


    }
}
