using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DPagoCuentaPorCobrar
    {
        private int _PagoNro;
        private int _CuentaporCobrarNro;
        private DateTime _Fecha;
        private int _FormaPagoNro;
        private decimal _Importe;
        private string _Observacion;
        private int _UsuarioNro;

        public int PagoNro
        {
            get
            {
                return _PagoNro;
            }

            set
            {
                _PagoNro = value;
            }
        }

        public int CuentaporCobrarNro
        {
            get
            {
                return _CuentaporCobrarNro;
            }

            set
            {
                _CuentaporCobrarNro = value;
            }
        }

      
        public decimal Importe
        {
            get
            {
                return _Importe;
            }

            set
            {
                _Importe = value;
            }
        }

        public string Observacion
        {
            get
            {
                return _Observacion;
            }

            set
            {
                _Observacion = value;
            }
        }

        public int UsuarioNro
        {
            get
            {
                return _UsuarioNro;
            }

            set
            {
                _UsuarioNro = value;
            }
        }
        

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
            }
        }

        public int FormaPagoNro
        {
            get
            {
                return _FormaPagoNro;
            }

            set
            {
                _FormaPagoNro = value;
            }
        }

        public DPagoCuentaPorCobrar() { }

        public DPagoCuentaPorCobrar(int pagonro,int cuentaporcobrarnro, DateTime fecha,int formapagonro,decimal importe,string observacion,int usuario) 
        {
            this.PagoNro = pagonro;
            this.CuentaporCobrarNro = cuentaporcobrarnro;
            this.Fecha = fecha;
            this.FormaPagoNro = formapagonro;
            this.Importe = importe;
            this.Observacion = observacion;
            this.UsuarioNro = UsuarioNro;
        }


        //Metodo insertar
        public string InsertarPagoCuentaPorCobrar(DPagoCuentaPorCobrar Cobro)
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
                SqlCmd.CommandText = "sp_InsertarPagoCuentaPorCobrar";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros 
                SqlParameter ParCuentaCobrarnro = new SqlParameter();
                ParCuentaCobrarnro.ParameterName = "@CuentaCobrarNro";
                ParCuentaCobrarnro.SqlDbType = SqlDbType.Int;
                ParCuentaCobrarnro.Value = Cobro.CuentaporCobrarNro;
                SqlCmd.Parameters.Add(ParCuentaCobrarnro);
                                

                //Parametros fecha
                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@FechaPago";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Cobro.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                //Parametro forma de pago
                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "FormaPagoNro";
                ParFormaPago.SqlDbType = SqlDbType.Int;
                ParFormaPago.Value = Cobro.FormaPagoNro;
                SqlCmd.Parameters.Add(ParFormaPago);

                //Parametros importe
                SqlParameter ParImporte = new SqlParameter();
                ParImporte.ParameterName = "@Importe";
                ParImporte.SqlDbType = SqlDbType.Decimal;
                ParImporte.Value = Cobro.Importe;
                SqlCmd.Parameters.Add(ParImporte);
                

                //Parametros observacion
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 150;
                ParObservacion.Value = Cobro.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);


                //Parametros usuario
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@UsuarioNro";
                ParUsuario.SqlDbType = SqlDbType.Int;                
                ParUsuario.Value =Cobro.UsuarioNro;
                SqlCmd.Parameters.Add(ParUsuario);


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



        //MOSTRAR CLIENTE
        public DataTable MostrarCliente(int textobuscar)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_ObtenerDeudaCliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@ClienteNro";
                ParTextoBuscar.SqlDbType = SqlDbType.Int;
                //ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = textobuscar;

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

        
        //MOSTRAR Cuotas por facturas
        public DataTable MostrarCuotasFactura(int textobuscar)
        {
            DataTable DtResultado = new DataTable("Detalle");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarCuotaFactura";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@CuentacobrarNro";
                ParTextoBuscar.SqlDbType = SqlDbType.Int;
                //ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = textobuscar;

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



        public DataTable MostrarHistorico(int textobuscar)
        {
            DataTable DtResultado = new DataTable("Pagos");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarHistoricoPagoCC";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@ClienteNro";
                ParTextoBuscar.SqlDbType = SqlDbType.Int;
                //ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = textobuscar;

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


        public string EliminarPagoCuentaPorCobrar(DPagoCuentaPorCobrar Cobro)
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
                SqlCmd.CommandText = "sp_EliminarPagoCuentaPorCobrar";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros 
                SqlParameter ParCuentaCobrarnro = new SqlParameter();
                ParCuentaCobrarnro.ParameterName = "@CuentaCobrarNro";
                ParCuentaCobrarnro.SqlDbType = SqlDbType.Int;
                ParCuentaCobrarnro.Value = Cobro.CuentaporCobrarNro;
                SqlCmd.Parameters.Add(ParCuentaCobrarnro);
                
                //Parametros pagonro
                SqlParameter ParPagoNro = new SqlParameter();
                ParPagoNro.ParameterName = "@PagoNro";
                ParPagoNro.SqlDbType = SqlDbType.Int;
                ParPagoNro.Value = Cobro.PagoNro;
                SqlCmd.Parameters.Add(ParPagoNro);


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





    }
}
