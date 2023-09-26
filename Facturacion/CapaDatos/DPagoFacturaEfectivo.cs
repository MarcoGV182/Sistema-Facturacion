using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaEntidades;

namespace CapaDatos
{
    public class DPagoFacturaEfectivo: DPagoFactura
    {  
       

        public DPagoFacturaEfectivo() { }
        

        //Metodo insertar
        public string InsertarPagoFacturaEfectivo(EPagoFacturaEfectivo PagoFacturaEfectivo, SqlConnection SqlconExistente = null, SqlTransaction sqltranExistente = null)
        {
            #region Variables
            string rpta = "";
            SqlConnection Sqlcon = null;
            SqlTransaction sqltran = null;
            #endregion

            try
            {
                #region Conexion y transaccion
                Sqlcon = AbrirConexion(SqlconExistente);
                sqltran = sqltranExistente == null ? Sqlcon.BeginTransaction() : sqltranExistente;

                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = sqltran;
                SqlCmd.CommandText = "sp_RegistrarPagoFacturaEfectivo";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                #endregion

                #region Parametros
                //Parametros NroFactura
                SqlParameter ParNroFactura = new SqlParameter();
                ParNroFactura.ParameterName = "@NroVenta";
                ParNroFactura.SqlDbType = SqlDbType.Int;
                ParNroFactura.Value = PagoFacturaEfectivo.NroVenta;
                SqlCmd.Parameters.Add(ParNroFactura);

                // PARAMETRO Monto
                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@Monto";
                ParMonto.SqlDbType = SqlDbType.Float;
                ParMonto.Value = PagoFacturaEfectivo.Monto;
                SqlCmd.Parameters.Add(ParMonto);

                // PARAMETRO Monto
                SqlParameter ParVuelto = new SqlParameter();
                ParVuelto.ParameterName = "@Vuelto";
                ParVuelto.SqlDbType = SqlDbType.Float;
                ParVuelto.Value = PagoFacturaEfectivo.Vuelto;
                SqlCmd.Parameters.Add(ParVuelto);
                #endregion


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() > 1 ? "OK" : "No se inserto el registro";

                if (sqltranExistente == null)
                    sqltran.Commit();

            }
            catch (Exception ex)
            {
                if (sqltranExistente == null)
                    sqltran.Rollback();

                rpta = ex.Message;
            }
            finally
            {
                CerrarConexion(Sqlcon, ref SqlconExistente);               
            }

            return rpta;
        }


    }
}
