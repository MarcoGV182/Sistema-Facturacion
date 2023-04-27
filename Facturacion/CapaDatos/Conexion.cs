using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net.Http.Headers;

namespace CapaDatos
{
    public abstract class Conexion
    {
        private readonly string CadenaConexion;

        public Conexion()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["CapaPresentacion.Properties.Settings.Cn"].ConnectionString;
        }

        #region Acceso a Datos

        protected SqlConnection AbrirConexion(SqlConnection sqlConnection = null) 
        {
            if (sqlConnection == null)
            {
                SqlConnection sqlcon = new SqlConnection(CadenaConexion);
                sqlcon.Open();

                return sqlcon;
            }
            else
            {
                return sqlConnection;
            }
        }

        protected void CerrarConexion(SqlConnection sqlConnection)
        {
            if (sqlConnection == null)
                return;

            if (sqlConnection.State == ConnectionState.Open) 
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
                
        }

        protected void CerrarConexion(SqlConnection sqlConnection, ref SqlConnection sqlConnectionExistente)
        {
            if (sqlConnectionExistente == null) 
            {
                if (sqlConnection.State == ConnectionState.Open) 
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                    
            }
            
        }
        #endregion
    }
}

