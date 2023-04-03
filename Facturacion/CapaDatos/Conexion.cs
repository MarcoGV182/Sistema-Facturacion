using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CapaDatos
{
    class Conexion
    {
        public static string CadenaConexion = ConfigurationManager.ConnectionStrings["CapaPresentacion.Properties.Settings.Cn"].ConnectionString;



        #region Acceso a Datos
        public static SqlConnection AbrirConexion(string connectionString, SqlConnection sqlConnection = null) 
        {
            if (sqlConnection == null)
            {
                SqlConnection Sqlcon = new SqlConnection();
                Sqlcon.ConnectionString = connectionString;
                Sqlcon.Open();

                return Sqlcon;
            }
            else
            {
                return sqlConnection;
            }
        }

        public static void CerrarConexion(SqlConnection sqlConnection)
        {
            if (sqlConnection.State == ConnectionState.Open)
                sqlConnection.Close();
        }

        public static void CerrarConexion(SqlConnection sqlConnection, ref SqlConnection sqlConnectionExistente)
        {
            if (sqlConnectionExistente == null) 
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
            
        }
        #endregion
    }
}

