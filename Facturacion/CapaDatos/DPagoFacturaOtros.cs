using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DPagoFacturaOtros : DPagoFactura
    {
        public DTipoPagoOtros TipoPagoOtro { get; set; }
        public string NroDocumentoPago { get; set; }


        public DPagoFacturaOtros()
        {
            
        }


        //Metodo insertar
        public string InsertarPagoFacturaOtros(DPagoFacturaOtros PagoFacturaOtros, SqlConnection SqlconExistente = null, SqlTransaction sqltranExistente = null)
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

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = sqltran;
                SqlCmd.CommandText = "sp_RegistrarPagoOtros";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                #endregion


                //Parametros             
                SqlCmd.Parameters.AddWithValue("@NroVenta", PagoFacturaOtros.NroVenta);
                SqlCmd.Parameters.AddWithValue("@TipoOtrosNro", PagoFacturaOtros.TipoPagoOtro.TipoOtrosNro);
                SqlCmd.Parameters.AddWithValue("@NroDocumento", PagoFacturaOtros.NroDocumentoPago);
                SqlCmd.Parameters.AddWithValue("@Monto", PagoFacturaOtros.Monto);


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
