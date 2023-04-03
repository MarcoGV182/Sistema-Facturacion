using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DModulo
    {
        public int IdModulo { get; set; }
        public string Descripcion { get; set; }


        public DModulo()
        {
            
        }


        public /*List<DModulo>*/DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Modulo");
            SqlConnection Sqlcon = new SqlConnection();
            //List<DModulo> modulo = null;
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
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

            return DtResultado;

        }

    }
}
