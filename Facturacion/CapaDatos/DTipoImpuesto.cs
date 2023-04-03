using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
   public class DTipoImpuesto
    {
        private int _TipoImpuestoNro;
        private string _Descripcion;
        private decimal _PorcentajeIva;
        private decimal _BaseImponible;        
        private string _TextoBuscar;

        public int TipoImpuestoNro
        {
            get
            {
                return _TipoImpuestoNro;
            }

            set
            {
                _TipoImpuestoNro = value;
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

        public decimal PorcentajeIva
        {
            get
            {
                return _PorcentajeIva;
            }

            set
            {
                _PorcentajeIva = value;
            }
        }

        public decimal BaseImponible
        {
            get
            {
                return _BaseImponible;
            }

            set
            {
                _BaseImponible = value;
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
        

        public DTipoImpuesto() {

        }

        public DTipoImpuesto(int tipoimpuestonro, string descripcion, decimal porcentajeiva, decimal baseImponible, string textobuscar) {
            this.TipoImpuestoNro = tipoimpuestonro;
            this.Descripcion = descripcion;
            this.PorcentajeIva = porcentajeiva;
            this.BaseImponible = baseImponible;
            this.TextoBuscar = textobuscar;
        }

        //Metodo insertar
        public string InsertarImpuesto(DTipoImpuesto Impuesto)
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
                SqlCmd.CommandText = "sp_InsertarTipoImpuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTipoImpuestoNro = new SqlParameter();
                ParTipoImpuestoNro.ParameterName = "@TipoImpuestoNro";
                ParTipoImpuestoNro.SqlDbType = SqlDbType.Int;
                ParTipoImpuestoNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParTipoImpuestoNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Impuesto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Parametros Porcentaje
                SqlParameter ParPorcentaje = new SqlParameter();
                ParPorcentaje.ParameterName = "@PorcentajeIva";
                ParPorcentaje.SqlDbType = SqlDbType.Decimal;
                ParPorcentaje.Value = Impuesto.PorcentajeIva;
                SqlCmd.Parameters.Add(ParPorcentaje);

                //Parametros Divisor
                SqlParameter ParDivisor = new SqlParameter();
                ParDivisor.ParameterName = "@baseImponible";
                ParDivisor.SqlDbType = SqlDbType.Decimal;
                ParDivisor.Value = Impuesto.BaseImponible;
                SqlCmd.Parameters.Add(ParDivisor);

                
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
        public string EditarImpuesto(DTipoImpuesto Impuesto)
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
                SqlCmd.CommandText = "sp_EditarTipoImpuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTipoImpuestoNro = new SqlParameter();
                ParTipoImpuestoNro.ParameterName = "@TipoImpuestoNro";
                ParTipoImpuestoNro.SqlDbType = SqlDbType.Int;
                ParTipoImpuestoNro.Value = Impuesto.TipoImpuestoNro;
                SqlCmd.Parameters.Add(ParTipoImpuestoNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Impuesto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Parametros Porcentaje
                SqlParameter ParPorcentaje = new SqlParameter();
                ParPorcentaje.ParameterName = "@PorcentajeIva";
                ParPorcentaje.SqlDbType = SqlDbType.Int;
                ParPorcentaje.Value = Impuesto.PorcentajeIva;
                SqlCmd.Parameters.Add(ParPorcentaje);

                //Parametros Divisor
                SqlParameter ParDivisor = new SqlParameter();
                ParDivisor.ParameterName = "@baseImponible";
                ParDivisor.SqlDbType = SqlDbType.Decimal;
                ParDivisor.Value = Impuesto.BaseImponible;
                SqlCmd.Parameters.Add(ParDivisor);

              
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

        //Metodo Eliminar
        public string EliminarImpuesto(DTipoImpuesto Impuesto)
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
                SqlCmd.CommandText = "sp_EliminarTipoImpuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTipoImpuestoNro = new SqlParameter();
                ParTipoImpuestoNro.ParameterName = "@TipoImpuestoNro";
                ParTipoImpuestoNro.SqlDbType = SqlDbType.Int;
                ParTipoImpuestoNro.Value = Impuesto.TipoImpuestoNro;
                SqlCmd.Parameters.Add(ParTipoImpuestoNro);

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
        public DataTable MostrarImpuesto()
        {
            DataTable DtResultado = new DataTable("TipoImpuesto");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarTipoImpuesto";
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

        //Metodo Buscar
        public DataTable BuscarImpuesto(DTipoImpuesto Impuesto)
        {
            DataTable DtResultado = new DataTable("TipoImpuesto");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarTipoImpuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 100;
                ParTextoBuscar.SqlValue = Impuesto.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                //instanciar un DataAdapter para el data table
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
