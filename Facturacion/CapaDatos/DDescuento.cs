using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDescuento:Conexion
    {
        private int _DescuentoNro;
        private string _Descripcion;

        public int DescuentoNro
        {
            get
            {
                return _DescuentoNro;
            }

            set
            {
                _DescuentoNro = value;
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

        public DDescuento() { }
        
        public DDescuento(int descuentonro,string descripcion) 
        {
            this.DescuentoNro = descuentonro;
            this.Descripcion = descripcion;
        }


        //Metodo insertar
        public string InsertarDescuento(DDescuento Descuento)
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
                SqlCmd.CommandText = "sp_InsertarDescuento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros ParDescuento
                /*SqlParameter ParDescuentoNro = new SqlParameter();
                ParDescuentoNro.ParameterName = "@NroDescuento";
                ParDescuentoNro.SqlDbType = SqlDbType.Int;
                ParDescuentoNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParDescuentoNro);*/

               
                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Descuento.Descripcion;
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
        public string EditarDescuento(DDescuento Descuento)
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
                SqlCmd.CommandText = "sp_EditarDescuento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros NroDescuento
                SqlParameter ParDescuentoNro = new SqlParameter();
                ParDescuentoNro.ParameterName = "@DescuentoNro";
                ParDescuentoNro.SqlDbType = SqlDbType.Int;
                ParDescuentoNro.Value = Descuento.DescuentoNro;
                SqlCmd.Parameters.Add(ParDescuentoNro);

             
                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Descuento.Descripcion;
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
        public string EliminarDescuento(DDescuento Descuento)
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
                SqlCmd.CommandText = "sp_EliminarDescuento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParDescuentoNro = new SqlParameter();
                ParDescuentoNro.ParameterName = "@DescuentoNro";
                ParDescuentoNro.SqlDbType = SqlDbType.Int;
                ParDescuentoNro.Value = Descuento.DescuentoNro;
                SqlCmd.Parameters.Add(ParDescuentoNro);

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
        public DataTable MostrarDescuento()
        {
            DataTable DtResultado = new DataTable("Descuento");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarDescuento";
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
