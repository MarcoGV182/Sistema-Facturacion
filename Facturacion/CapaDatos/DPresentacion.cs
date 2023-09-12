using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DPresentacion:Conexion
    {
        private int _IdPresentacion;
        private string _Descripcion;
        private string _TextoBuscar;

        public int IdPresentacion
        {
            get{return _IdPresentacion;}
            set{_IdPresentacion = value;}
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

        public DPresentacion() {

        }

        public DPresentacion(int idpresentacion, string descripcion, string textobuscar) {
            this.IdPresentacion = idpresentacion;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }

        //Metodo insertar
        public string InsertarPresentacion(DPresentacion Presentacion)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //abrimos la conexion
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarPresentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idPresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Presentacion.Descripcion;
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
        public string EditarPresentacion(DPresentacion Presentacion)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EditarPresentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros idPresentracion
                SqlParameter ParidPresentracion = new SqlParameter();
                ParidPresentracion.ParameterName = "@MarcaNro";
                ParidPresentracion.SqlDbType = SqlDbType.Int;
                ParidPresentracion.Value = Presentacion.IdPresentacion;
                SqlCmd.Parameters.Add(ParidPresentracion);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Presentacion.Descripcion;
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
        public string EliminarPresentacion(DPresentacion Presentacion)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EliminarPresentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros idPresentacion
                SqlParameter ParidPresentacion = new SqlParameter();
                ParidPresentacion.ParameterName = "@idPresentacion";
                ParidPresentacion.SqlDbType = SqlDbType.Int;
                ParidPresentacion.Value = Presentacion.IdPresentacion;
                SqlCmd.Parameters.Add(ParidPresentacion);

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
        public DataTable MostrarPresentacion()
        {
            DataTable DtResultado = new DataTable("Presentacion");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarPresentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

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
        public DataTable BuscarPresentacion(DPresentacion Presentacion)
        {
            DataTable DtResultado = new DataTable("Presentacion");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarPresentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue = Presentacion.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                //instanciar un DataAdapter para el data table
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
