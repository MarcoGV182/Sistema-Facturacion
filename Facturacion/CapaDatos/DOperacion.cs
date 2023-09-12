using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DOperacion:Conexion
    {
        private int _IdOperacion;
        private string _Nombre;
        private string _Descripcion;
        public DModulo Modulo { get; set; }
        public bool Habilitado { get; set; }

        public int IdOperacion
        {
            get
            {
                return _IdOperacion;
            }

            set
            {
                _IdOperacion = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
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

        public DOperacion() { }

        public DOperacion(int nroregla, string nombre, string descripcion) 
        {
            this.IdOperacion = nroregla;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }


        //Metodo insertar
        public string InsertarRegla(DOperacion Regla)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon = AbrirConexion(Sqlcon);
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarReglaUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros ParRegla
                /*SqlParameter ParReglaNro = new SqlParameter();
                ParReglaNro.ParameterName = "@IdOperacion";
                ParReglaNro.SqlDbType = SqlDbType.Int;
                ParReglaNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParReglaNro);*/

                //Parametros Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Regla.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Regla.Descripcion;
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
        public string EditarRegla(DOperacion Regla)
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
                SqlCmd.CommandText = "sp_EditarReglaUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros IdOperacion
                SqlParameter ParReglaNro = new SqlParameter();
                ParReglaNro.ParameterName = "@IdOperacion";
                ParReglaNro.SqlDbType = SqlDbType.Int;
                ParReglaNro.Value = Regla.IdOperacion;
                SqlCmd.Parameters.Add(ParReglaNro);

                //Parametros Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Regla.Nombre;
                SqlCmd.Parameters.Add(ParNombre);



                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Regla.Descripcion;
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
        public string EliminarRegla(DOperacion Regla)
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
                SqlCmd.CommandText = "sp_EliminarReglaUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParReglaNro = new SqlParameter();
                ParReglaNro.ParameterName = "@IdOperacion";
                ParReglaNro.SqlDbType = SqlDbType.Int;
                ParReglaNro.Value = Regla.IdOperacion;
                SqlCmd.Parameters.Add(ParReglaNro);

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
        public DataTable MostrarRegla()
        {
            DataTable DtResultado = new DataTable("Regla");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarReglaUsuario";
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




    }
}
