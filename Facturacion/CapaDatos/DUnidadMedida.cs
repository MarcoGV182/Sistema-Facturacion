using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DUnidadMedida
    {
        private int _UnidadMedidaNro;
        private string _Descripcion;
        private string _TextoBuscar;

        public int UnidadMedidaNro
        {
            get{return _UnidadMedidaNro;}
            set{_UnidadMedidaNro = value;}
        }

        public string Descripcion
        {
            get{return _Descripcion;}
            set{_Descripcion = value;}
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        public DUnidadMedida() {

        }

        public DUnidadMedida(int unidadMedidaNro, string descripcion, string textobuscar) {
            this.UnidadMedidaNro = unidadMedidaNro;
            this.Descripcion = descripcion;
            this._TextoBuscar=textobuscar;
        }


        //Metodo insertar
        public string InsertarUnidadMedida(DUnidadMedida UnidadMedida)
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
                SqlCmd.CommandText = "sp_InsertarUnidadMedida";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros Ciudad
                SqlParameter ParUnidadMedidaNro = new SqlParameter();
                ParUnidadMedidaNro.ParameterName = "@UnidadMedidaNro";
                ParUnidadMedidaNro.SqlDbType = SqlDbType.Int;
                ParUnidadMedidaNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParUnidadMedidaNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = UnidadMedida.Descripcion;
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
        public string EditarUnidadMedida(DUnidadMedida UnidadMedida)
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
                SqlCmd.CommandText = "sp_EditarUnidadMedida";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParUnidadMedidaNro = new SqlParameter();
                ParUnidadMedidaNro.ParameterName = "@UnidadMedidaNro";
                ParUnidadMedidaNro.SqlDbType = SqlDbType.Int;
                ParUnidadMedidaNro.Value = UnidadMedida.UnidadMedidaNro;
                SqlCmd.Parameters.Add(ParUnidadMedidaNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = UnidadMedida.Descripcion;
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
        public string EliminarUnidadMedida(DUnidadMedida UnidadMedida)
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
                SqlCmd.CommandText = "sp_EliminarUnidadMedida";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParUnidadMedidaNro = new SqlParameter();
                ParUnidadMedidaNro.ParameterName = "@UnidadMedidaNro";
                ParUnidadMedidaNro.SqlDbType = SqlDbType.Int;
                ParUnidadMedidaNro.Value = UnidadMedida.UnidadMedidaNro;
                SqlCmd.Parameters.Add(ParUnidadMedidaNro);

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
        public DataTable MostrarUnidadMedida()
        {
            DataTable DtResultado = new DataTable("UnidadMedida");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarUnidadMedida";
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
        public DataTable BuscarNombre(DUnidadMedida UnidadMedida)
        {
            DataTable DtResultado = new DataTable("UnidadMedida");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarUnidadMedida";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 100;
                ParTextoBuscar.SqlValue = UnidadMedida.TextoBuscar;
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
