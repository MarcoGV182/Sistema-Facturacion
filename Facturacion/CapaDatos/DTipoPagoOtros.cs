using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DTipoPagoOtros:Conexion
    {
        public int TipoOtrosNro { get; set; }
        public string Descripcion { get; set; }


        public DTipoPagoOtros()
        {
            
        }


        public DataTable MostrarTipoPagoOtros()
        {
            DataTable DtResultado = new DataTable("TipoOtros");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "select TipoOtrosNro, Descripcion from dbo.TipoPagoOtros";
                SqlCmd.CommandType = CommandType.Text;

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
