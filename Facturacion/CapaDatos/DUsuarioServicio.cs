using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DUsuarioServicio
    {
        private int _UsuarioNro;
        private int _ServicioNro;

        public int UsuarioNro
        {
            get
            {
                return _UsuarioNro;
            }

            set
            {
                _UsuarioNro = value;
            }
        }

        public int ServicioNro
        {
            get
            {
                return _ServicioNro;
            }

            set
            {
                _ServicioNro = value;
            }
        }

        public DUsuarioServicio() { }

        public DUsuarioServicio(int UsuarioNro, int ServicioNro)
        {
            this.UsuarioNro = UsuarioNro;
            this.ServicioNro = ServicioNro;
        }



        //Metodo insertar
        public string InsertarUsuarioServicio(DUsuarioServicio UsuarioServicio)
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
                SqlCmd.CommandText = "sp_InsertarUsuarioServicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros ServicioNro
                SqlParameter ParServicioNro = new SqlParameter();
                ParServicioNro.ParameterName = "@ServicioNro";
                ParServicioNro.SqlDbType = SqlDbType.Int;
                ParServicioNro.Value = UsuarioServicio.ServicioNro;
                SqlCmd.Parameters.Add(ParServicioNro);

                //Parametros NroTipoUsuario
                SqlParameter ParUsuarioNro = new SqlParameter();
                ParUsuarioNro.ParameterName = "@UsuarioNro";
                ParUsuarioNro.SqlDbType = SqlDbType.Int;
                ParUsuarioNro.Value = UsuarioServicio.UsuarioNro;
                SqlCmd.Parameters.Add(ParUsuarioNro);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se inserto el registro";

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
        public DataTable MostrarUsuarioServicio(DUsuarioServicio US)
        {
            DataTable DtResultado = new DataTable("UsuarioServicio");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarUsuario_Servicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parametros NroTipoUsuario
                SqlParameter ParUsuarioNro = new SqlParameter();
                ParUsuarioNro.ParameterName = "@UsuarioNro";
                ParUsuarioNro.SqlDbType = SqlDbType.Int;
                ParUsuarioNro.Value = US.UsuarioNro;
                SqlCmd.Parameters.Add(ParUsuarioNro);


                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;

        }

        //ELIMINAR ANTES DE INSERTAR
        public string EliminarUsuarioServicio(DUsuarioServicio US)
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
                SqlCmd.CommandText = "sp_EliminarUsuario_Servicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros UsuarioNro
                SqlParameter ParUsuarioNro = new SqlParameter();
                ParUsuarioNro.ParameterName = "@UsuarioNro";
                ParUsuarioNro.SqlDbType = SqlDbType.Int;
                ParUsuarioNro.Value = US.UsuarioNro;
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
    }
}
