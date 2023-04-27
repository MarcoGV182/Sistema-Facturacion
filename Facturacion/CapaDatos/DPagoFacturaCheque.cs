using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPagoFacturaCheque: DPagoFactura
    {
        public string NroCheque { get; set; }
        public DBanco Banco { get; set; }
        public DateTime? FechaCheque { get; set; }


        public DPagoFacturaCheque() { }
        

        //Metodo insertar
        public string InsertarPagoFacturaCheque(DPagoFacturaCheque PagoFacturaCheque, SqlConnection SqlconExistente = null, SqlTransaction sqltranExistente = null)
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
                SqlCmd.CommandText = "sp_RegistrarPagoFacturaCheque";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                #endregion


                //Parametros             
                SqlCmd.Parameters.AddWithValue("@NroVenta", PagoFacturaCheque.NroVenta);
                SqlCmd.Parameters.AddWithValue("@NroCheque", PagoFacturaCheque.NroCheque);
                SqlCmd.Parameters.AddWithValue("@FechaCheque", PagoFacturaCheque.FechaCheque);
                SqlCmd.Parameters.AddWithValue("@BancoNro", PagoFacturaCheque.Banco.BancoNro);
                SqlCmd.Parameters.AddWithValue("@Monto", PagoFacturaCheque.Monto);


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
