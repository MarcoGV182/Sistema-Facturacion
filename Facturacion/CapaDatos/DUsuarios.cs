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
    public class DUsuarios : Conexion
    {

        public DUsuarios() 
        {

        }


        //Metodo Insertar
        public string InsertarUsuarios(int PersonaNro,string UsuarioLogin,string Pass,int TipoUserNro,SqlConnection sqlConExistente = null, SqlTransaction SqltranExistente = null)
        {
            //declarar variable respuesta
            string rpta = "OK";
            //instanciamos la conexion
            SqlConnection Sqlcon = null;
            SqlTransaction SqlTran = null;
            try
            {
                //codigo
                Sqlcon = AbrirConexion(sqlConExistente);
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
                ParIdUser.Value = PersonaNro;
                SqlCmd.Parameters.Add(ParIdUser);

                SqlParameter ParUser= new SqlParameter();
                ParUser.ParameterName = "@Usuario";
                ParUser.SqlDbType = SqlDbType.VarChar;
                ParUser.Size = 250;
                ParUser.Value = UsuarioLogin;
                SqlCmd.Parameters.Add(ParUser);

                //Parametros Observacion
                SqlParameter ParPass = new SqlParameter();
                ParPass.ParameterName = "@Pass";
                ParPass.SqlDbType = SqlDbType.VarChar;
                ParPass.Size = 250;
                ParPass.Value = Pass;
                SqlCmd.Parameters.Add(ParPass);

                //Parametros Observacion
                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@TipoUserNro";
                ParAcceso.SqlDbType = SqlDbType.Int;
                ParAcceso.Value = TipoUserNro;
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
                CerrarConexion(Sqlcon,ref sqlConExistente);
            }
            return rpta;
        }



        //Metodo Editar
        public string EditarUsuario(int PersonaNro, string UsuarioLogin, string Pass,string PassNew, int TipoUserNro, SqlConnection sqlConExistente = null, SqlTransaction SqltranExistente = null)
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
                Sqlcon = AbrirConexion(sqlConExistente);
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
                ParPersonaNro.Value = PersonaNro;
                SqlCmd.Parameters.Add(ParPersonaNro);

                //Parametros Observacion
                SqlParameter ParUser = new SqlParameter();
                ParUser.ParameterName = "@Usuario";
                ParUser.SqlDbType = SqlDbType.VarChar;
                ParUser.Size = 250;
                ParUser.Value = UsuarioLogin;
                SqlCmd.Parameters.Add(ParUser);


                //Parametros Contraseña anterior
                SqlParameter ParPassAnterior = new SqlParameter();
                ParPassAnterior.ParameterName = "@OldPass";
                ParPassAnterior.SqlDbType = SqlDbType.VarChar;
                ParPassAnterior.Size = 50;
                ParPassAnterior.Value = Pass;
                SqlCmd.Parameters.Add(ParPassAnterior);

                SqlParameter ParPassNuevo = new SqlParameter();
                ParPassNuevo.ParameterName = "@NewPass";
                ParPassNuevo.SqlDbType = SqlDbType.VarChar;
                ParPassNuevo.Size = 50;
                ParPassNuevo.Value = PassNew;
                SqlCmd.Parameters.Add(ParPassNuevo);

                //Parametros Observacion
                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@TipoUserNro";
                ParAcceso.SqlDbType = SqlDbType.Int;
                ParAcceso.Value = TipoUserNro;
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
                CerrarConexion(Sqlcon);
            }
            return rpta;
        }



        //Metodo Eliminar
        public string EliminarUsuario(int UsuarioNro)
        {
            string rpta = "";
            SqlConnection Sqlcon = null;
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EliminarUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParUsuarioNro = new SqlParameter();
                ParUsuarioNro.ParameterName = "@UsuarioNro";
                ParUsuarioNro.SqlDbType = SqlDbType.Int;
                ParUsuarioNro.Value = UsuarioNro;
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
                CerrarConexion(Sqlcon);
            }

            return rpta;

        }



        //Metodo Mostrar
        public DataTable BuscarUsuario(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Usuario");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            finally 
            {
                CerrarConexion(Sqlcon);
            }

            return DtResultado;

        }

        
        //Metodo Buscar
        public DataTable BuscarLogin(string UsuarioLogin,string Pass)
        {
            DataTable DtResultado = new DataTable("Usuario");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_Login";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParUser = new SqlParameter();
                ParUser.ParameterName = "@Usuario";
                ParUser.SqlDbType = SqlDbType.VarChar;
                ParUser.Size = 50;
                ParUser.SqlValue = UsuarioLogin;
                SqlCmd.Parameters.Add(ParUser);

                //Parametros
                SqlParameter ParPass = new SqlParameter();
                ParPass.ParameterName = "@Pass";
                ParPass.SqlDbType = SqlDbType.VarChar;
                ParPass.Size = 50;
                ParPass.SqlValue = Pass;
                SqlCmd.Parameters.Add(ParPass);

                //instanciar un DataAdapter
                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
                throw ex;
            }
            finally 
            {
                CerrarConexion(Sqlcon);
            }
            return DtResultado;
        }
    }
}
