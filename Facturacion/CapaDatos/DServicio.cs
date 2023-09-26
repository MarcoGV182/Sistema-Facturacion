using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
   public class DServicio:Conexion
    {        

        public DServicio() {

        }
        

        //Metodo Insertar
        public string InsertarServicio(EServicio Servicio)
        {
            //declarar variable respuesta
            string rpta = "";
            //instanciamos la conexion
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarServicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que recibe el procedimiento almacenado
                SqlParameter ParServicioNro = new SqlParameter();
                ParServicioNro.ParameterName = "@ArticuloNro";
                ParServicioNro.SqlDbType = SqlDbType.Int;
                ParServicioNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParServicioNro);

                //Parametros 
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Servicio.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Parametros 
                SqlParameter ParTipoServicioNro = new SqlParameter();
                ParTipoServicioNro.ParameterName = "@TipoServicioNro";
                ParTipoServicioNro.SqlDbType = SqlDbType.Int;
                ParTipoServicioNro.Value = Servicio.TipoServicioNro;
                SqlCmd.Parameters.Add(ParTipoServicioNro);

                //Parametros 
                SqlParameter ParTipoImpuestoNro = new SqlParameter();
                ParTipoImpuestoNro.ParameterName = "@TipoImpuestoNro";
                ParTipoImpuestoNro.SqlDbType = SqlDbType.Int;
                ParTipoImpuestoNro.Value = Servicio.TipoImpuestoNro;
                SqlCmd.Parameters.Add(ParTipoImpuestoNro);

                //Parametros 
                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@Precio";
                ParPrecio.SqlDbType = SqlDbType.Float;
                ParPrecio.Value = Servicio.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                //Parametros Observacion
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 100;
                ParObservacion.Value = Servicio.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                //Parametros Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 8;
                ParEstado.Value = Servicio.Estado;
                SqlCmd.Parameters.Add(ParEstado);
                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se inserto el registro";
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
        public string EditarServicio(EServicio Servicio)
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
                SqlCmd.CommandText = "sp_EditarServicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que recibe el procedimiento almacenado
                SqlParameter ParServicioNro = new SqlParameter();
                ParServicioNro.ParameterName = "@ServicioNro";
                ParServicioNro.SqlDbType = SqlDbType.Int;
                ParServicioNro.Value = Servicio.ArticuloNro;
                SqlCmd.Parameters.Add(ParServicioNro);

                //Parametros 
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Servicio.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Parametros 
                SqlParameter ParTipoServicioNro = new SqlParameter();
                ParTipoServicioNro.ParameterName = "@TipoServicioNro";
                ParTipoServicioNro.SqlDbType = SqlDbType.Int;
                ParTipoServicioNro.Value = Servicio.TipoServicioNro;
                SqlCmd.Parameters.Add(ParTipoServicioNro);

                //Parametros 
                SqlParameter ParTipoImpuestoNro = new SqlParameter();
                ParTipoImpuestoNro.ParameterName = "@TipoImpuestoNro";
                ParTipoImpuestoNro.SqlDbType = SqlDbType.Int;
                ParTipoImpuestoNro.Value = Servicio.TipoImpuestoNro;
                SqlCmd.Parameters.Add(ParTipoImpuestoNro);

                //Parametros 
                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@Precio";
                ParPrecio.SqlDbType = SqlDbType.Float;
                ParPrecio.Value = Servicio.Precio;
                SqlCmd.Parameters.Add(ParPrecio);


                //Parametros Observacion
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 100;
                ParObservacion.Value = Servicio.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                //Parametros Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 8;
                ParEstado.Value = Servicio.Estado;
                SqlCmd.Parameters.Add(ParEstado);               

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se actualizo el registro";

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
        public string EliminarServicio(int servicioId)
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
                SqlCmd.CommandText = "sp_EliminarServicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parametros que recibe el procedimiento almacenado
                SqlParameter ParServicioNro = new SqlParameter();
                ParServicioNro.ParameterName = "@ServicioNro";
                ParServicioNro.SqlDbType = SqlDbType.Int;
                ParServicioNro.Value = servicioId;
                SqlCmd.Parameters.Add(ParServicioNro);

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
        public DataTable MostrarServicio()
        {
            DataTable DtResultado = new DataTable("Servicio");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarServicio";
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
        public DataTable BuscarServicio(string servicioDescripcion)
        {
            DataTable DtResultado = new DataTable("Servicio");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarServicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue = servicioDescripcion;
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
