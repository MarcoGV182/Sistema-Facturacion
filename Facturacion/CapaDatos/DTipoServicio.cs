using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTipoServicio
    {
        private int _TipoServicioNro;
        public int TipoServicioNro
        {
            get { return _TipoServicioNro; }
            set { _TipoServicioNro = value; }

        }
        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _TextoBuscar;
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        //Constructor vacio
        public DTipoServicio()
        {

        }
        //Constructor con parametros
        public DTipoServicio(int tipoServicioNro, string descripcion, string textobuscar)
        {
            this.TipoServicioNro = tipoServicioNro;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }

        //Metodo insertar
        public string InsertarTipoServicio(DTipoServicio TipoServicio)
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
                SqlCmd.CommandText = "sp_InsertarTipoServicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoParTipoServicioNro
                SqlParameter ParTipoServicioNro = new SqlParameter();
                ParTipoServicioNro.ParameterName = "@TipoServicioNro";
                ParTipoServicioNro.SqlDbType = SqlDbType.Int;
                ParTipoServicioNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParTipoServicioNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = TipoServicio.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";

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

        //Metodo Editar
        public string EditarTipoServicio(DTipoServicio TipoServicio)
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
                SqlCmd.CommandText = "sp_EditarTipoServicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParTipoServicioNro = new SqlParameter();
                ParTipoServicioNro.ParameterName = "@TipoServicioNro";
                ParTipoServicioNro.SqlDbType = SqlDbType.Int;
                ParTipoServicioNro.Value = TipoServicio.TipoServicioNro;
                SqlCmd.Parameters.Add(ParTipoServicioNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = TipoServicio.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el registro";

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

        //Metodo Eliminar
        public string EliminarTipoServicio(DTipoServicio TipoServicio)
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
                SqlCmd.CommandText = "sp_EliminarTipoServicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParTipoServicioNro = new SqlParameter();
                ParTipoServicioNro.ParameterName = "@TipoServicioNro";
                ParTipoServicioNro.SqlDbType = SqlDbType.Int;
                ParTipoServicioNro.Value = TipoServicio.TipoServicioNro;
                SqlCmd.Parameters.Add(ParTipoServicioNro);

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
        public DataTable MostrarTipoServicio()
        {
            DataTable DtResultado = new DataTable("TipoServicio");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarTipoServicio";
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

        //Metodo Buscar
        public DataTable BuscarNombre(DTipoServicio TipoServicio)
        {
            DataTable DtResultado = new DataTable("TipoServicio");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarTipoServicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue = TipoServicio.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

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

    }
}
