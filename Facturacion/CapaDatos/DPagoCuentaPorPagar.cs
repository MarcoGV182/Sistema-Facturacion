using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPagoCuentaPorPagar
    {
        private int _PagoNro;
        private int _CuentaPagarNro;
        private DateTime _Vencimiento;
        private DateTime _Fecha;
        private int _FormaPagoNro;
        private decimal _Importe;
        private string _Observacion;
        private int _Usuario;

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

        public int CuentaPagarNro
        {
            get
            {
                return _CuentaPagarNro;
            }

            set
            {
                _CuentaPagarNro = value;
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

        public DateTime Vencimiento
        {
            get
            {
                return _Vencimiento;
            }

            set
            {
                _Vencimiento = value;
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

        public int Usuario
        {
            get
            {
                return _Usuario;
            }

            set
            {
                _Usuario = value;
            }
        }

        public DPagoCuentaPorPagar() { }

        public DPagoCuentaPorPagar(int pagonro, int cuentapagar, DateTime vencimiento,DateTime fecha,int formapagonro ,decimal importe,string observacion,int usuario) {
            this.PagoNro = pagonro;
            this.CuentaPagarNro = cuentapagar;
            this.Vencimiento = vencimiento;
            this.Fecha = fecha;
            this.FormaPagoNro = formapagonro;
            this.Importe = importe;
            this.Observacion = observacion;
            this.Usuario = usuario;
        
         }

        //Metodo insertar
        public string InsertarCuentaxPagar(DPagoCuentaPorPagar Deuda)
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
                SqlCmd.CommandText = "sp_InsertarPagoCuentaPorPagar";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros 
                SqlParameter ParPagoNro = new SqlParameter();
                ParPagoNro.ParameterName = "@PagoNro";
                ParPagoNro.SqlDbType = SqlDbType.Int;
                ParPagoNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParPagoNro);

                //Parametros 
                SqlParameter ParCuentaPagarnro = new SqlParameter();
                ParCuentaPagarnro.ParameterName = "@CuentaPagarNro";
                ParCuentaPagarnro.SqlDbType = SqlDbType.Int;
                ParCuentaPagarnro.Value = Deuda.CuentaPagarNro;
                SqlCmd.Parameters.Add(ParCuentaPagarnro);
                               
                //Parametros fecha
                SqlParameter ParFecha= new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Deuda.Fecha;
                SqlCmd.Parameters.Add(ParFecha);


                //Parametro Forma de pago
                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@FormaPagoNro";
                ParFormaPago.SqlDbType = SqlDbType.Int;
                ParFormaPago.Value = Deuda.FormaPagoNro;
                SqlCmd.Parameters.Add(ParFormaPago);


                //Parametros importe
                SqlParameter ParImporte = new SqlParameter();
                ParImporte.ParameterName = "@Importe";
                ParImporte.SqlDbType = SqlDbType.Decimal;
                ParImporte.Value = Deuda.Importe;
                SqlCmd.Parameters.Add(ParImporte);

                //Parametros observacion
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 150;
                ParObservacion.Value = Deuda.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);


                //Parametros usuario
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@UsuarioNro";
                ParUsuario.SqlDbType = SqlDbType.Int;
                ParUsuario.Value = Deuda.Usuario;
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


        //Metodo Buscar
        public DataTable BuscarFechas(string Textobuscar1, string TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("Deuda");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarCuentaxPagarFechas";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar1";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue = Textobuscar1;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                //Parametros
                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@TextoBuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 50;
                ParTextoBuscar2.SqlValue = TextoBuscar2;
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                //instanciar un DataAdapter
                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Metodo Mostrar
        public DataTable MostrarDetalleDeuda(string nroFactura, int proveedornro)
        {
            DataTable DtResultado = new DataTable("DetalleDeuda");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarFacturaDeuda";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@NroFacturaCompra";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue =nroFactura;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                // Parametros
                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@ProveedorNro";
                ParTextoBuscar2.SqlDbType = SqlDbType.Int;
                ParTextoBuscar2.SqlValue = proveedornro;
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                //instanciar un DataAdapter
                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }


        //Metodo Mostrar
        public DataTable MostrarDeuda()
        {
            DataTable DtResultado = new DataTable("Deuda");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarCuentaxPagar";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //instanciar un DataAdapter
                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }


        /*Metodo actualizar saldo
        public string ActualizarSaldo(int cuentapagarnro, decimal importe)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.Conn;
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_ActualizarSaldoDeuda";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParNroFactura = new SqlParameter();
                ParNroFactura.ParameterName = "@CuentaPagarNro";
                ParNroFactura.SqlDbType = SqlDbType.VarChar;
                ParNroFactura.Size = 50;
                ParNroFactura.Value = cuentapagarnro;
                SqlCmd.Parameters.Add(ParNroFactura);
                
                // Parametros
                SqlParameter ParImporte = new SqlParameter();
                ParImporte.ParameterName = "@Importe";
                ParImporte.SqlDbType = SqlDbType.Decimal;
                ParImporte.Value = importe;
                SqlCmd.Parameters.Add(ParImporte);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el saldo";
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
        }*/



        //Metodo Mostrar
        public DataTable MostrarHistoricoPago(int proveedor)
        {
            DataTable DtResultado = new DataTable("Pago");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarHistoricoPagoCP";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCuentaPagar = new SqlParameter();
                ParCuentaPagar.ParameterName = "@ProveedorNro";
                ParCuentaPagar.SqlDbType = SqlDbType.Int;
                ParCuentaPagar.Value = proveedor;
                SqlCmd.Parameters.Add(ParCuentaPagar);



                //instanciar un DataAdapter
                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public string EliminarPagoCuentaPorPagar(DPagoCuentaPorPagar Cobro)
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
                SqlCmd.CommandText = "sp_EliminarPagoCuentaPorPagar";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros 
                SqlParameter ParCuentaPagarnro = new SqlParameter();
                ParCuentaPagarnro.ParameterName = "@CuentaPagarNro";
                ParCuentaPagarnro.SqlDbType = SqlDbType.Int;
                ParCuentaPagarnro.Value = Cobro.CuentaPagarNro;
                SqlCmd.Parameters.Add(ParCuentaPagarnro);

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
