using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DTipoComprobante:Conexion
    {

        public int ComprobanteNro { get; set; }
        public string Nombre { get; set; }
        public bool AfectaCaja { get; set; }


        public DTipoComprobante() 
        {
        
        }


        public DataTable MostrarTipoComprobante()
        {
            DataTable DtResultado = new DataTable("TipoComprobante");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarTipoComprobante";
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
