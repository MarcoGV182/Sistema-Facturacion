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
   public class DTipoImpuesto:Conexion
    {        

        //Metodo insertar
        public string InsertarImpuesto(ETipoImpuesto Impuesto)
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
                SqlCmd.CommandText = "sp_InsertarTipoImpuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTipoImpuestoNro = new SqlParameter();
                ParTipoImpuestoNro.ParameterName = "@TipoImpuestoNro";
                ParTipoImpuestoNro.SqlDbType = SqlDbType.Int;
                ParTipoImpuestoNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParTipoImpuestoNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Impuesto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Parametros Porcentaje
                SqlParameter ParPorcentaje = new SqlParameter();
                ParPorcentaje.ParameterName = "@PorcentajeIva";
                ParPorcentaje.SqlDbType = SqlDbType.Decimal;
                ParPorcentaje.Value = Impuesto.PorcentajeIva;
                SqlCmd.Parameters.Add(ParPorcentaje);

                //Parametros Divisor
                SqlParameter ParDivisor = new SqlParameter();
                ParDivisor.ParameterName = "@baseImponible";
                ParDivisor.SqlDbType = SqlDbType.Decimal;
                ParDivisor.Value = Impuesto.BaseImponible;
                SqlCmd.Parameters.Add(ParDivisor);

                
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
        public string EditarImpuesto(ETipoImpuesto Impuesto)
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
                SqlCmd.CommandText = "sp_EditarTipoImpuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTipoImpuestoNro = new SqlParameter();
                ParTipoImpuestoNro.ParameterName = "@TipoImpuestoNro";
                ParTipoImpuestoNro.SqlDbType = SqlDbType.Int;
                ParTipoImpuestoNro.Value = Impuesto.TipoImpuestoNro;
                SqlCmd.Parameters.Add(ParTipoImpuestoNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Impuesto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Parametros Porcentaje
                SqlParameter ParPorcentaje = new SqlParameter();
                ParPorcentaje.ParameterName = "@PorcentajeIva";
                ParPorcentaje.SqlDbType = SqlDbType.Int;
                ParPorcentaje.Value = Impuesto.PorcentajeIva;
                SqlCmd.Parameters.Add(ParPorcentaje);

                //Parametros Divisor
                SqlParameter ParDivisor = new SqlParameter();
                ParDivisor.ParameterName = "@baseImponible";
                ParDivisor.SqlDbType = SqlDbType.Decimal;
                ParDivisor.Value = Impuesto.BaseImponible;
                SqlCmd.Parameters.Add(ParDivisor);

              
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
        public string EliminarImpuesto(int ImpuestoId)
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
                SqlCmd.CommandText = "sp_EliminarTipoImpuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTipoImpuestoNro = new SqlParameter();
                ParTipoImpuestoNro.ParameterName = "@TipoImpuestoNro";
                ParTipoImpuestoNro.SqlDbType = SqlDbType.Int;
                ParTipoImpuestoNro.Value = ImpuestoId;
                SqlCmd.Parameters.Add(ParTipoImpuestoNro);

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
        public DataTable MostrarImpuesto()
        {
            DataTable DtResultado = new DataTable("TipoImpuesto");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarTipoImpuesto";
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
