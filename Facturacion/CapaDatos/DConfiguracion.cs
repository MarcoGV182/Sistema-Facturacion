using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DConfiguracion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Observacion { get; set; }

        public DConfiguracion()
        {
            
        }


        public DConfiguracion GetConfiguracion(string nombre)
        {
            DataTable DtResultado = new DataTable("Configuracion");
            SqlConnection Sqlcon = new SqlConnection();
            DConfiguracion result = null;
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "Select id,Nombre,valor,Observacion from Configuracion where Nombre = @nombre";
                SqlCmd.CommandType = CommandType.Text;

                SqlCmd.Parameters.AddWithValue("@nombre", nombre);

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);

                foreach (DataRow item in DtResultado.Rows)
                {
                    result = new DConfiguracion();
                    result.Id = Convert.ToInt32(item["Id"]);
                    result.Nombre = item["Nombre"].ToString();
                    result.Valor = item["Valor"].ToString();
                    result.Observacion = item["Observacion"].ToString();
                }
            }
            catch (Exception ex)
            {   
                throw ex;                
            }
            finally 
            {
                Conexion.CerrarConexion(Sqlcon);            
            }

            return result;
        }
    }
}
