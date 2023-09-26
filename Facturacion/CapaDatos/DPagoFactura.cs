using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DPagoFactura:Conexion
    {
        public string EliminarPagos(int nroVenta,SqlConnection sqlConexionExistente,SqlTransaction sqltranExistente) 
        {
            string rpta = "OK";
            SqlConnection Sqlcon = new SqlConnection();
            SqlTransaction Sqltran = null;
            try
            {
                //codigo            
                Sqlcon = AbrirConexion(sqlConexionExistente);
                //establecer la transaccion
                Sqltran = sqltranExistente ?? Sqlcon.BeginTransaction();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = Sqltran;
                SqlCmd.CommandText = "sp_EliminarPagoFactura";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParNroVenta = new SqlParameter();
                ParNroVenta.ParameterName = "@NroVenta";
                ParNroVenta.SqlDbType = SqlDbType.Int;
                ParNroVenta.Value = nroVenta;
                SqlCmd.Parameters.Add(ParNroVenta);

                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

                if (sqltranExistente == null)
                    Sqltran.Commit();

            }
            catch (Exception ex)
            {
                if (sqltranExistente == null)
                    Sqltran.Rollback();

                rpta = ex.Message;
            }
            finally
            {
                CerrarConexion(Sqlcon,ref sqlConexionExistente);
            }
            return rpta;

        }
    }
}
