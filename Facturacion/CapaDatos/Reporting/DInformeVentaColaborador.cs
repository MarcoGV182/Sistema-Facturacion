using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Reporting
{
    public class DInformeVentaColaborador:Conexion
    {
        public DataTable InformeVentaColaborador(DateTime fechaDesde,DateTime fechaHasta,int VendedorColaboradorId)
        {
            DataTable DtResultado = new DataTable("InformeVentaColaborador");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = @"select f.NroVenta,
                                               f.NroFactura,	   
	                                           f.FechaFactura,
	                                           (p.Nombre + ' ' + p.Apellido) NombreColaborador,
	                                           p.Documento,
	                                           SUM(df.PrecioFinal * df.Cantidad)Total,
	                                           COUNT(df.Cantidad)Cantidad_item
                                        from factura f join DetalleFactura df on f.NroVenta = df.NroVenta
			                                           join Colaborador c on f.Vendedor = c.ColaboradorNro
			                                           join Persona p on c.ColaboradorNro = p.PersonaNro
                                        where f.FechaFactura >= @FechaDesde and f.FechaFactura <= @FechaHasta and f.Vendedor = ISNULL(@Vendedor,f.Vendedor)
                                        group by 
                                             f.NroFactura,
	                                         f.NroVenta,
	                                         f.FechaFactura,
	                                         p.Nombre,
                                             p.Apellido,
	                                         p.Documento,
	                                         f.UsuarioInsercion";

                SqlParameter ParDesde = new SqlParameter();
                ParDesde.ParameterName = "@FechaDesde";
                ParDesde.SqlDbType = SqlDbType.Date;
                ParDesde.Value = fechaDesde;
                SqlCmd.Parameters.Add(ParDesde);

                SqlParameter ParHasta = new SqlParameter();
                ParHasta.ParameterName = "@FechaHasta";
                ParHasta.SqlDbType = SqlDbType.Date;
                ParHasta.Value = fechaHasta;
                SqlCmd.Parameters.Add(ParHasta);

                SqlParameter ParVendedor = new SqlParameter();
                ParVendedor.ParameterName = "@Vendedor";
                ParVendedor.SqlDbType = SqlDbType.Int;
                ParVendedor.Value = VendedorColaboradorId;
                SqlCmd.Parameters.Add(ParVendedor);

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
