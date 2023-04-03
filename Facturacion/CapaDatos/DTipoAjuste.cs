using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTipoAjuste
    {
        private int _TipoAjusteNro;
        private string _Descripcion;
        private string _PositivoNegativo;
        private string _TextoBuscar;

        public int TipoAjusteNro
        {
            get
            {
                return _TipoAjusteNro;
            }

            set
            {
                _TipoAjusteNro = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }

        public string PositivoNegativo
        {
            get
            {
                return _PositivoNegativo;
            }

            set
            {
                _PositivoNegativo = value;
            }
        }

        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }

            set
            {
                _TextoBuscar = value;
            }
        }

        public DTipoAjuste() { }

        public DTipoAjuste(int tipoajustenro,string descripcion,string positivonegativo, string textobuscar) {
            this.TipoAjusteNro = tipoajustenro;
            this.Descripcion = descripcion;
            this.PositivoNegativo = positivonegativo;
            this.TextoBuscar = textobuscar;
        }


        //Metodo insertar
        public string InsertarTipoAjuste(DTipoAjuste TipoAjuste)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //abrimos la conexion
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarTipoAjuste";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoAjuste
                SqlParameter ParTipoAjusteNro = new SqlParameter();
                ParTipoAjusteNro.ParameterName = "@TipoAjusteNro";
                ParTipoAjusteNro.SqlDbType = SqlDbType.Int;
                ParTipoAjusteNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParTipoAjusteNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 255;
                ParDescripcion.Value = TipoAjuste.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);


                //Parametros Descripcion
                SqlParameter ParPositivoNegativo = new SqlParameter();
                ParPositivoNegativo.ParameterName = "@PositivoNegativo";
                ParPositivoNegativo.SqlDbType = SqlDbType.VarChar;
                ParPositivoNegativo.Size = 9;
                ParPositivoNegativo.Value = TipoAjuste.PositivoNegativo;
                SqlCmd.Parameters.Add(ParPositivoNegativo);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";
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

        //Metodo Editar
        public string EditarTipoAjuste(DTipoAjuste TipoAjuste)
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
                SqlCmd.CommandText = "sp_EditarTipoAjuste";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoAjuste
                SqlParameter ParTipoAjusteNro = new SqlParameter();
                ParTipoAjusteNro.ParameterName = "@TipoAjusteNro";
                ParTipoAjusteNro.SqlDbType = SqlDbType.Int;
                ParTipoAjusteNro.Value = TipoAjuste.TipoAjusteNro;
                SqlCmd.Parameters.Add(ParTipoAjusteNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 255;
                ParDescripcion.Value = TipoAjuste.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);


                //Parametros Descripcion
                SqlParameter ParPositivoNegativo = new SqlParameter();
                ParPositivoNegativo.ParameterName = "@PositivoNegativo";
                ParPositivoNegativo.SqlDbType = SqlDbType.VarChar;
                ParPositivoNegativo.Size = 255;
                ParPositivoNegativo.Value = TipoAjuste.PositivoNegativo;
                SqlCmd.Parameters.Add(ParPositivoNegativo);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el registro";
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
        public DataTable MostrarTipoAjuste()
        {
            DataTable DtResultado = new DataTable("TipoAjuste");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarTipoAjuste";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;

        }




        //Metodo Eliminar
        public string EliminarTipoAjuste(DTipoAjuste TipoAjuste)
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
                SqlCmd.CommandText = "sp_EliminarTipoAjuste";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parametros que recibe el procedimiento almacenado
                SqlParameter ParTipoAjusteNro = new SqlParameter();
                ParTipoAjusteNro.ParameterName = "@TipoAjusteNro";
                ParTipoAjusteNro.SqlDbType = SqlDbType.Int;
                ParTipoAjusteNro.Value = TipoAjuste.TipoAjusteNro;
                SqlCmd.Parameters.Add(ParTipoAjusteNro);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";

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
        public DataTable BuscarTipoAjuste(DTipoAjuste Ajuste)
        {
            DataTable DtResultado = new DataTable("TipoAjuste");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarTipoAjuste";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Ajuste.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);



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
