using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTipoProducto : Conexion
    {
        private int _TipoProductoNro;
        public int TipoProductoNro
        {
            get { return _TipoProductoNro; }
            set { _TipoProductoNro = value; }

        }
        private string _Descripcion;
        public string Descripcion
        {
            get{return _Descripcion;}
            set{_Descripcion = value;}
        }

        private string _TextoBuscar;
        public string TextoBuscar
        {
            get{return _TextoBuscar;}
            set{_TextoBuscar = value;}
        }


        //Constructor vacio
        public DTipoProducto() {

        }
        //Constructor con parametros
        public DTipoProducto(int tipoProductoNro, string descripcion, string textobuscar) {
            this.TipoProductoNro = tipoProductoNro;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }

        //Metodo insertar
        public string InsertarTipoProducto(DTipoProducto TipoProducto) {
            string rpta = "";
            SqlConnection Sqlcon = null;
            try {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarTipoProducto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParTipoProductoNro = new SqlParameter();
                ParTipoProductoNro.ParameterName = "@TipoProductoNro";
                ParTipoProductoNro.SqlDbType = SqlDbType.Int;
                ParTipoProductoNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParTipoProductoNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = TipoProducto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK": "No se inserto el registro";
                
            }
            catch(Exception ex) {
                rpta = ex.Message;
            }
            finally
            {
                CerrarConexion(Sqlcon);
            }

            return rpta;
           

        }

        //Metodo Editar
        public string EditarTipoProducto(DTipoProducto TipoProducto)
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
                SqlCmd.CommandText = "sp_EditarTipoProducto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParTipoProductoNro = new SqlParameter();
                ParTipoProductoNro.ParameterName = "@TipoProductoNro";
                ParTipoProductoNro.SqlDbType = SqlDbType.Int;
                ParTipoProductoNro.Value = TipoProducto.TipoProductoNro;
                SqlCmd.Parameters.Add(ParTipoProductoNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = TipoProducto.Descripcion;
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
                CerrarConexion(Sqlcon);
            }

            return rpta;


        }

        //Metodo Eliminar
        public string EliminarTipoProducto(DTipoProducto TipoProducto)
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
                SqlCmd.CommandText = "sp_EliminarTipoProducto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParTipoProductoNro = new SqlParameter();
                ParTipoProductoNro.ParameterName = "@TipoProductoNro";
                ParTipoProductoNro.SqlDbType = SqlDbType.Int;
                ParTipoProductoNro.Value = TipoProducto.TipoProductoNro;
                SqlCmd.Parameters.Add(ParTipoProductoNro);
                                
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
        public DataTable MostrarTipoProducto()
        {
            DataTable DtResultado = new DataTable("TipoProducto");
            SqlConnection Sqlcon = null;
            try 
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection=Sqlcon;
                SqlCmd.CommandText = "sp_MostrarTipoProducto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch(Exception) 
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
        public DataTable BuscarNombre(DTipoProducto TipoProducto)
        {
            DataTable DtResultado = new DataTable("TipoProducto");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarTipoProducto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue = TipoProducto.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);
                
                //instanciar un DataAdapter
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


    }
}
