using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCiudad
    {
        private int _CiudadNro;
        public int CiudadNro
        {
            get { return _CiudadNro; }
            set { _CiudadNro = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion;}
            set{_Descripcion = value;}
        }


        private string _TextoBuscar;
        public string TextoBuscar
        {
            get{return _TextoBuscar;}
            set{_TextoBuscar = value;}
        }
        
        //Constructor vacio
        public DCiudad()
        {

        }
        //Constructor con parametros
        public DCiudad(int CiudadNro, string descripcion, string textobuscar)
        {
            this.CiudadNro = CiudadNro;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }

        //Metodo insertar
        public string InsertarCiudad(DCiudad Ciudad)
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
                SqlCmd.CommandText = "sp_InsertarCiudad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros Ciudad
                SqlParameter ParCiudadNro = new SqlParameter();
                ParCiudadNro.ParameterName = "@CiudadNro";
                ParCiudadNro.SqlDbType = SqlDbType.Int;
                ParCiudadNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParCiudadNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 200;
                ParDescripcion.Value = Ciudad.Descripcion;
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
        public string EditarCiudad(DCiudad Ciudad)
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
                SqlCmd.CommandText = "sp_EditarCiudad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParCiudadNro = new SqlParameter();
                ParCiudadNro.ParameterName = "@CiudadNro";
                ParCiudadNro.SqlDbType = SqlDbType.Int;
                ParCiudadNro.Value = Ciudad.CiudadNro;
                SqlCmd.Parameters.Add(ParCiudadNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Ciudad.Descripcion;
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
        public string EliminarCiudad(DCiudad Ciudad)
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
                SqlCmd.CommandText = "sp_EliminarCiudad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParCiudadNro = new SqlParameter();
                ParCiudadNro.ParameterName = "@CiudadNro";
                ParCiudadNro.SqlDbType = SqlDbType.Int;
                ParCiudadNro.Value = Ciudad.CiudadNro;
                SqlCmd.Parameters.Add(ParCiudadNro);

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
        public DataTable MostrarCiudad()
        {
            DataTable DtResultado = new DataTable("Ciudad");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarCiudad";
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
        public DataTable BuscarNombre(DCiudad Ciudad)
        {
            DataTable DtResultado = new DataTable("Ciudad");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarCiudad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 100;
                ParTextoBuscar.SqlValue = Ciudad.TextoBuscar;
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

