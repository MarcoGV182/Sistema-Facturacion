using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTipoUsuarioRegla : Conexion
    {
        public DRol Rol { get; set; }
        public DOperacion Operacion { get; set; }





        public DTipoUsuarioRegla() { }

        

        //Metodo insertar
        public string InsertarTipoUsuarioRegla(DTipoUsuarioRegla TipoUsuarioRegla, string tieneHabilitado)
        {
            string rpta = "OK";
            SqlConnection Sqlcon = null;
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarTipoUsuarioRegla";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                
                //Parametros IdOperacion
                SqlParameter ParNroRegla = new SqlParameter();
                ParNroRegla.ParameterName = "@IdOperacion";
                ParNroRegla.SqlDbType = SqlDbType.Int;
                ParNroRegla.Value = TipoUsuarioRegla.Operacion.IdOperacion;
                SqlCmd.Parameters.Add(ParNroRegla);

                //Parametros NroTipoUsuario
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@IdRol";
                ParDescripcion.SqlDbType = SqlDbType.Int;
                ParDescripcion.Value = TipoUsuarioRegla.Rol.IdRol;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Parametros NroTipoUsuario
                SqlParameter ParHabilitado = new SqlParameter();
                ParHabilitado.ParameterName = "@Habilitado";
                ParHabilitado.SqlDbType = SqlDbType.VarChar;
                ParHabilitado.Value = tieneHabilitado;
                SqlCmd.Parameters.Add(ParHabilitado);

                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

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
        public DataTable MostrarTipoUsuarioRegla(DTipoUsuarioRegla TUR)
        {
            DataTable DtResultado = new DataTable("TipoUsuarioRegla");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarUsuario_Regla";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parametros NroTipoUsuario
                SqlParameter ParNroTipoUsuario = new SqlParameter();
                ParNroTipoUsuario.ParameterName = "@TipoUsuario";
                ParNroTipoUsuario.SqlDbType = SqlDbType.Int;
                ParNroTipoUsuario.Value = TUR.Rol.IdRol;
                SqlCmd.Parameters.Add(ParNroTipoUsuario);


                SqlParameter ParModulo = new SqlParameter();
                ParModulo.ParameterName = "@Modulo";
                ParModulo.SqlDbType = SqlDbType.Int;
                ParModulo.Value = TUR.Operacion.Modulo.IdModulo;
                SqlCmd.Parameters.Add(ParModulo);


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

        //ELIMINAR ANTES DE INSERTAR
        public string EliminarTipoUserRegla(DTipoUsuarioRegla TUR)
        {
            string rpta = "OK";
            SqlConnection Sqlcon = null;
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EliminarUsuario_Regla";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoUsuarioNro
                SqlParameter ParTipoUsuarioNro = new SqlParameter();
                ParTipoUsuarioNro.ParameterName = "@TipoUsuarioNro";
                ParTipoUsuarioNro.SqlDbType = SqlDbType.Int;
                ParTipoUsuarioNro.Value = TUR.Rol.IdRol;
                SqlCmd.Parameters.Add(ParTipoUsuarioNro);

                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

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






    }
}
