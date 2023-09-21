using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Reporting
{
    public class DInformeCaja:Conexion
    {

        public DataTable ResumenCajaPorFecha(DateTime FechaInicio, DateTime FechaFin)
        {
            DataTable DtResultado = new DataTable("ResumenCaja");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = @"SELECT CajaNro, 
		                                      u.Login Usuario,
		                                      FechaApertura,
		                                      FechaCierre,
		                                      ImporteApertura,
		                                      ImporteEntrega,
		                                      SaldoFinal,
		                                      DiferenciaCierre, 
		                                      c.Estado 
	                                        FROM 
		                                        Caja c join Persona p on c.UsuarioNro=p.PersonaNro
			                                           join Usuario u on p.PersonaNro=u.UsuarioNro
	                                        WHERE
		                                        FechaApertura >= @FechaInicio AND FechaCierre <= DATEADD(DAY,1,@FechaFin)
                                            ORDER BY FechaApertura asc";

                SqlParameter ParDesde = new SqlParameter();
                ParDesde.ParameterName = "@FechaInicio";
                ParDesde.SqlDbType = SqlDbType.Date;
                ParDesde.Value = FechaInicio;
                SqlCmd.Parameters.Add(ParDesde);

                SqlParameter ParHasta = new SqlParameter();
                ParHasta.ParameterName = "@FechaFin";
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
