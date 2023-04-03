using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CapaDatos
{
    public class DBackup
    {
        private string _Ruta;
        private string _Alias;
        private string _BD;

        public string Ruta
        {
            get
            {
                return _Ruta;
            }

            set
            {
                _Ruta = value;
            }
        }

        public string Alias
        {
            get
            {
                return _Alias;
            }

            set
            {
                _Alias = value;
            }
        }

        public string BD
        {
            get
            {
                return _BD;
            }

            set
            {
                _BD = value;
            }
        }


        public DBackup() { }


        public DBackup(string ruta, string alias, string bd) {
            this.Ruta = ruta;
            this.Alias = alias;
            this.BD = bd;
        }




        public string Backup(DBackup bd)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_Backup";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParRuta = new SqlParameter();
                ParRuta.ParameterName = "@ruta";
                ParRuta.SqlDbType = SqlDbType.VarChar;
                ParRuta.Size = 100;
                ParRuta.Value = bd.Ruta;
                SqlCmd.Parameters.Add(ParRuta);

                //Parametros 
                SqlParameter ParAlias = new SqlParameter();
                ParAlias.ParameterName = "@alias";
                ParAlias.SqlDbType = SqlDbType.VarChar;
                ParAlias.Size = 100;
                ParAlias.Value = bd.Alias;
                SqlCmd.Parameters.Add(ParAlias);

                //Parametros 
                SqlParameter ParBD = new SqlParameter();
                ParBD.ParameterName = "@BD";
                ParBD.SqlDbType = SqlDbType.VarChar;
                ParBD.Size = 100;
                ParBD.Value = bd.BD;
                SqlCmd.Parameters.Add(ParBD);
                

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se relizó el Backup";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open)
                    Sqlcon.Close();
            }

            return rpta;
        }


        //Metodo Mostrar
        public DataTable MostrarRecordatorio(string rango)
        {
            DataTable DtResultado = new DataTable("Recordatorio");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_Recordatorios";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParRango = new SqlParameter();
                ParRango.ParameterName = "@Rango";
                ParRango.SqlDbType = SqlDbType.VarChar;
                ParRango.Size = 20;
                ParRango.Value = rango;
                SqlCmd.Parameters.Add(ParRango);



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
