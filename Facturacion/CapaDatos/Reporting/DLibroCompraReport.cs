using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Reporting
{
    public class DLibroCompraReport: Conexion
    {
        public DataTable ObtenerLibroVenta(DateTime FechaInicio, DateTime FechaFin)
        {
            DataTable DtResultado = new DataTable("LibroVenta");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = @"select NroVenta,
                                              Fecha,
                                              NroFactura,
                                              Comprobante,
                                              Cliente,
                                              TipoDocumento,
                                              Documento,
                                              Imp_Gravado,
                                              Imp_IVA,
                                              Imp_Exento, 
                                              Total
                                        from v_LibroVenta v
                                        where v.Fecha >= @Desde and v.Fecha <= @Hasta";

                SqlParameter ParDesde = new SqlParameter();
                ParDesde.ParameterName = "@Desde";
                ParDesde.SqlDbType = SqlDbType.Date;
                ParDesde.Value = FechaInicio;
                SqlCmd.Parameters.Add(ParDesde);

                SqlParameter ParHasta = new SqlParameter();
                ParHasta.ParameterName = "@Hasta";
                ParHasta.SqlDbType = SqlDbType.Date;
                ParHasta.Value = FechaFin;
                SqlCmd.Parameters.Add(ParHasta);

                SqlCmd.CommandType = CommandType.Text;


                //instanciar un DataAdapter
                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
