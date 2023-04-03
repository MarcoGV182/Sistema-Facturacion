using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DNumeracionComprobante
    {
        private int _Id;
        public int TipoComprobante { get; set; }
        public int Establecimiento { get; set; }
        public int PuntoExpedicion { get; set; }
        private decimal _Numero;
        private string _Timbrado;
        public DateTime? FechaInicioVigencia { get; set; }
        private DateTime? _FechaVencimiento;
        private char _Estado;

        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }        

        public decimal Numero
        {
            get
            {
                return _Numero;
            }

            set
            {
                _Numero = value;
            }
        }

        public char Estado 
        { 
            get 
            {
                return _Estado;
            }
            set 
            {
                _Estado = value;
            }
        }

        public string Timbrado
        {
            get
            {
                return _Timbrado;
            }

            set
            {
                _Timbrado = value;
            }
        }

        public DateTime? FechaVencimiento
        {
            get
            {
                return _FechaVencimiento;
            }

            set
            {
                _FechaVencimiento = value;
            }
        }

        public DNumeracionComprobante() { }

        public DNumeracionComprobante(int id, int establecimiento, int puntoexpedicion, int tipocomprobante,decimal numero,string timbrado, DateTime fechainiciovigencia, DateTime fechavencimiento ,char estado)
        {
            this.Id = id;
            this.Establecimiento = establecimiento;
            this.PuntoExpedicion = puntoexpedicion;
            this.TipoComprobante = tipocomprobante;
            this.Numero = numero;
            this.Timbrado = timbrado;
            this.FechaInicioVigencia = fechainiciovigencia;
            this.FechaVencimiento = fechavencimiento;
            this.Estado = estado;
        }


        //Metodo Insertar
        public string InsertarNumeracion(DNumeracionComprobante Numeracion)
        {
            //declarar variable respuesta
            string rpta = "";
            //instanciamos la conexion
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarNumeracionComprobante";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que recibe el procedimiento almacenado
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@Id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId);


                //Parametros 
                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@Establecimiento";
                ParSerie.SqlDbType = SqlDbType.Int;
                ParSerie.Value = Numeracion.Establecimiento;
                SqlCmd.Parameters.Add(ParSerie);

                //Parametros 
                SqlParameter ParSucursal = new SqlParameter();
                ParSucursal.ParameterName = "@PuntoExpedicion";
                ParSucursal.SqlDbType = SqlDbType.Int;
                ParSucursal.Value = Numeracion.PuntoExpedicion;
                SqlCmd.Parameters.Add(ParSucursal);

                //Parametros 
                SqlParameter ParUltimoNumero = new SqlParameter();
                ParUltimoNumero.ParameterName = "@Numero";
                ParUltimoNumero.SqlDbType = SqlDbType.Decimal;
                ParUltimoNumero.Value = Numeracion.Numero;
                SqlCmd.Parameters.Add(ParUltimoNumero);

                //Parametros 
                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@TipoComprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 10;
                ParTipoComprobante.Value = Numeracion.TipoComprobante;
                SqlCmd.Parameters.Add(ParTipoComprobante);


                //Parametros 
                SqlParameter ParTimbrado = new SqlParameter();
                ParTimbrado.ParameterName = "@Timbrado";
                ParTimbrado.SqlDbType = SqlDbType.VarChar;
                ParTimbrado.Size = 50;
                ParTimbrado.Value = Numeracion.Timbrado;
                SqlCmd.Parameters.Add(ParTimbrado);

                SqlParameter ParFechaInicioVigencia = new SqlParameter();
                ParFechaInicioVigencia.ParameterName = "@FechaInicioVigencia";
                ParFechaInicioVigencia.SqlDbType = SqlDbType.Date;
                ParFechaInicioVigencia.Value = Numeracion.FechaInicioVigencia;
                SqlCmd.Parameters.Add(ParFechaInicioVigencia);

                SqlParameter ParFechaVencimiento = new SqlParameter();
                ParFechaVencimiento.ParameterName = "@FechaVencimiento";
                ParFechaVencimiento.SqlDbType = SqlDbType.Date;
                ParFechaVencimiento.Value = Numeracion.FechaVencimiento;
                SqlCmd.Parameters.Add(ParFechaVencimiento);


                //Parametro Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Numeracion.Estado;
                SqlCmd.Parameters.Add(ParEstado);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se inserto el registro";
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
        public string EditarNumeracion(DNumeracionComprobante Numeracion)
        {
            //declarar variable respuesta
            string rpta = "";
            //instanciamos la conexion
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EditarNumeracionComprobante";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que recibe el procedimiento almacenado
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@Id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Numeracion.Id;
                SqlCmd.Parameters.Add(ParId);


                //Parametros 
                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@Establecimiento";
                ParSerie.SqlDbType = SqlDbType.Int;
                ParSerie.Value = Numeracion.Establecimiento;
                SqlCmd.Parameters.Add(ParSerie);

                //Parametros 
                SqlParameter ParSucursal = new SqlParameter();
                ParSucursal.ParameterName = "@PuntoExpedicion";
                ParSucursal.SqlDbType = SqlDbType.Int;
                ParSucursal.Value = Numeracion.PuntoExpedicion;
                SqlCmd.Parameters.Add(ParSucursal);

                //Parametros 
                SqlParameter ParUltimoNumero = new SqlParameter();
                ParUltimoNumero.ParameterName = "@Numero";
                ParUltimoNumero.SqlDbType = SqlDbType.Decimal;
                ParUltimoNumero.Value = Numeracion.Numero;
                SqlCmd.Parameters.Add(ParUltimoNumero);

                //Parametros 
                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@TipoComprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.Int;
                ParTipoComprobante.Value = Numeracion.TipoComprobante;
                SqlCmd.Parameters.Add(ParTipoComprobante);


                //Parametros 
                SqlParameter ParTimbrado = new SqlParameter();
                ParTimbrado.ParameterName = "@Timbrado";
                ParTimbrado.SqlDbType = SqlDbType.VarChar;
                ParTimbrado.Size = 50;
                ParTimbrado.Value = Numeracion.Timbrado;
                SqlCmd.Parameters.Add(ParTimbrado);

                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@FechaInicioVigencia";
                ParFechaInicio.SqlDbType = SqlDbType.Date;
                ParFechaInicio.Value = Numeracion.FechaInicioVigencia;
                SqlCmd.Parameters.Add(ParFechaInicio);

                SqlParameter ParFechaVencimiento = new SqlParameter();
                ParFechaVencimiento.ParameterName = "@FechaVencimiento";
                ParFechaVencimiento.SqlDbType = SqlDbType.Date;
                ParFechaVencimiento.Value = Numeracion.FechaVencimiento;
                SqlCmd.Parameters.Add(ParFechaVencimiento);


                //Parametro Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Numeracion.Estado;
                SqlCmd.Parameters.Add(ParEstado);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se modificó el registro";
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

        //Metodo eliminar
        public string EliminarNumeracion(DNumeracionComprobante Numeracion)
        {
            //declarar variable respuesta
            string rpta = "";
            //instanciamos la conexion
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EliminarNumeracionComprobante";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que recibe el procedimiento almacenado
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@Id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Numeracion.Id;
                SqlCmd.Parameters.Add(ParId);
               

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se elimino el registro";
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
        public DataTable MostrarNumeracion()
        {
            DataTable DtResultado = new DataTable("Numeracion");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarNumeracionComprobante";
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

    }
}
