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
    public class DPagoFacturaTarjeta : DPagoFactura
    {  

        public DPagoFacturaTarjeta() { }

        //Metodo insertar
        public string InsertarPagoFacturaTarjeta(EPagoFacturaTarjeta PagoFacturaTarjeta, SqlConnection SqlconExistente = null, SqlTransaction sqltranExistente = null)
        {
            #region Variables
            string rpta = "";
            SqlConnection Sqlcon = null;
            SqlTransaction sqltran = null;
            #endregion

            try
            {
                Sqlcon = AbrirConexion(SqlconExistente);
                sqltran = sqltranExistente == null ? Sqlcon.BeginTransaction() : sqltranExistente;
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = sqltran;
                SqlCmd.CommandText = "sp_RegistrarPagoFacturaTarjeta";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros NroFactura
                SqlParameter ParNroVenta = new SqlParameter();
                ParNroVenta.ParameterName = "@NroVenta";
                ParNroVenta.SqlDbType = SqlDbType.Int;
                ParNroVenta.Value = PagoFacturaTarjeta.NroVenta;
                SqlCmd.Parameters.Add(ParNroVenta);
                

                //PARAMETRO COMPROBANTE
                SqlParameter ParComprobante = new SqlParameter();
                ParComprobante.ParameterName = "@Comprobante";
                ParComprobante.SqlDbType = SqlDbType.VarChar;
                ParComprobante.Value = PagoFacturaTarjeta.ComprobanteNro;
                SqlCmd.Parameters.Add(ParComprobante);

                //PARAMETRO TIPO DE TARJETA
                SqlParameter ParTipoTarjeta = new SqlParameter();
                ParTipoTarjeta.ParameterName = "@TipoTarjeta";
                ParTipoTarjeta.SqlDbType = SqlDbType.VarChar;
                ParTipoTarjeta.Size = 8;
                ParTipoTarjeta.Value = PagoFacturaTarjeta.TipoTarjeta;
                SqlCmd.Parameters.Add(ParTipoTarjeta);


                // PARAMETRO Monto
                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@Monto";
                ParMonto.SqlDbType = SqlDbType.Float;
                ParMonto.Value = PagoFacturaTarjeta.Monto;
                SqlCmd.Parameters.Add(ParMonto);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 2 ? "OK" : "No se inserto el registro";
                if (sqltranExistente == null)
                    sqltran.Commit();

            }
            catch (Exception ex)
            {
                if (sqltranExistente == null)
                    sqltran.Rollback();
                rpta = ex.Message + ex.StackTrace;
            }
            finally
            {
                if (SqlconExistente == null)
                {
                    if (Sqlcon.State == ConnectionState.Open)
                        Sqlcon.Close();
                }
            }
            return rpta;
        }

    }
}
