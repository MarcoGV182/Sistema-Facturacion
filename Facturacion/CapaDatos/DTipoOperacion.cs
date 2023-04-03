using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DTipoOperacion
    {
        private int _NroTipoOperacion;
        private string _Descripcion;
        private string _TextoBuscar;

        public int NroTipoOperacion
        {
            get
            {
                return _NroTipoOperacion;
            }

            set
            {
                _NroTipoOperacion = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }

        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }

            set
            {
                _TextoBuscar = value;
            }
        }


        public DTipoOperacion() {

        }

        public DTipoOperacion(int nrotipooperacion, string descripcion, string textobuscar) {
            this.NroTipoOperacion = nrotipooperacion;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }


        //Metodo insertar
        public string InsertarOperacion(DTipoOperacion Operacion)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //abrimos la conexion
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarTipoOperacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParNroTipoOperacion = new SqlParameter();
                ParNroTipoOperacion.ParameterName = "@NroTipoOperacion";
                ParNroTipoOperacion.SqlDbType = SqlDbType.Int;
                ParNroTipoOperacion.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParNroTipoOperacion);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Operacion.Descripcion;
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
        public string EditarOperacion(DTipoOperacion Operacion)
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
                SqlCmd.CommandText = "sp_EditarTipoOperacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parametros
                SqlParameter ParNroTipoOperacion = new SqlParameter();
                ParNroTipoOperacion.ParameterName = "@NroTipoOperacion";
                ParNroTipoOperacion.SqlDbType = SqlDbType.Int;
                ParNroTipoOperacion.Value = Operacion.NroTipoOperacion;
                SqlCmd.Parameters.Add(ParNroTipoOperacion);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Operacion.Descripcion;
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
        public string EliminarOperacion(DTipoOperacion Operacion)
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
                SqlCmd.CommandText = "sp_EliminarTipoOperacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParNroTipoOperacion = new SqlParameter();
                ParNroTipoOperacion.ParameterName = "@NroTipoOperacion";
                ParNroTipoOperacion.SqlDbType = SqlDbType.Int;
                ParNroTipoOperacion.Value =Operacion.NroTipoOperacion;
                SqlCmd.Parameters.Add(ParNroTipoOperacion);

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
        public DataTable MostrarTipoOperacion()
        {
            DataTable DtResultado = new DataTable("TipoOperacion");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarTipoOperacion";
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

    }
}
