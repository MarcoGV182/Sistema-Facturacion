using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaDatos
{
    public class DConfiguracion:Conexion
    {
        public DConfiguracion()
        {
            
        }


        public EConfiguracion GetConfiguracion(string nombre)
        {
            DataTable DtResultado = new DataTable("Configuracion");
            SqlConnection Sqlcon = new SqlConnection();
            EConfiguracion result = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "Select id,Nombre,valor,Observacion from Configuracion where Nombre = @nombre";
                SqlCmd.CommandType = CommandType.Text;

                SqlCmd.Parameters.AddWithValue("@nombre", nombre);

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);

                foreach (DataRow item in DtResultado.Rows)
                {
                    result = new EConfiguracion();
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
                CerrarConexion(Sqlcon);            
            }

            return result;
        }
    }
}
