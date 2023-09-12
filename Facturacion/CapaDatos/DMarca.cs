using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DMarca:Conexion
    {
        private int _MarcaNro;
        private string _Descripcion;
        private string _TextoBuscar;

        public int MarcaNro
        {
            get{return _MarcaNro;}
            set{_MarcaNro = value;}
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

        //Constructor Vacio
        public DMarca() {

        }
        //Constructor con parametros
        public DMarca(int marcaNro, string descripcion,string textobuscar) {
            this.MarcaNro = marcaNro;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }


        //Metodo insertar
        public string InsertarMarca(DMarca Marca)
        {
            string rpta = "";
            SqlConnection Sqlcon = null;
            try
            {
                //abrimos la conexion
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarMarca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros Ciudad
                SqlParameter ParMarcaNro = new SqlParameter();
                ParMarcaNro.ParameterName = "@MarcaNro";
                ParMarcaNro.SqlDbType = SqlDbType.Int;
                ParMarcaNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParMarcaNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 200;
                ParDescripcion.Value = Marca.Descripcion;
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
                CerrarConexion(Sqlcon);
            }

            return rpta;


        }

        //Metodo Editar
        public string EditarMarca(DMarca Marca)
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
                SqlCmd.CommandText = "sp_EditarMarca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParMarcaNro = new SqlParameter();
                ParMarcaNro.ParameterName = "@MarcaNro";
                ParMarcaNro.SqlDbType = SqlDbType.Int;
                ParMarcaNro.Value = Marca.MarcaNro;
                SqlCmd.Parameters.Add(ParMarcaNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Marca.Descripcion;
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
        public string EliminarMarca(DMarca Marca)
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
                SqlCmd.CommandText = "sp_EliminarMarca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParMarcaNro = new SqlParameter();
                ParMarcaNro.ParameterName = "@MarcaNro";
                ParMarcaNro.SqlDbType = SqlDbType.Int;
                ParMarcaNro.Value = Marca.MarcaNro;
                SqlCmd.Parameters.Add(ParMarcaNro);

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
        public DataTable MostrarMarca()
        {
            DataTable DtResultado = new DataTable("Marca");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarMarca";
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
        public DataTable BuscarNombre(DMarca Marca)
        {
            DataTable DtResultado = new DataTable("Marca");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarMarca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 100;
                ParTextoBuscar.SqlValue = Marca.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                //instanciar un DataAdapter para el data table
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
