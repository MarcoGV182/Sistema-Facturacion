using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DModulo:Conexion
    {

        public DModulo()
        {
            
        }


        public /*List<DModulo>*/DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Modulo");
            SqlConnection Sqlcon = null;
            //List<DModulo> modulo = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "select * from Modulo";
                SqlCmd.CommandType = CommandType.Text;

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);

                /*modulo = (from row in DtResultado.AsEnumerable()
                          select new DModulo()
                          {
                              IdModulo = int.Parse(row["IdModulo"].ToString()),
                              Descripcion = row["Descripcion"].ToString()
                          }).ToList();*/
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
