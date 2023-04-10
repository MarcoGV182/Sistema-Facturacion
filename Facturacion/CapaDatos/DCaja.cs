using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

//Hola que tal ojala este ya funcione

namespace CapaDatos
{
    public class DCaja
    {
        private int _NroCaja;
        private DateTime _FechaApertura;
        private DateTime? _FechaCierre;
        private int _PersonaNro;
        private decimal _Monto;        
        private char _Estado;
        private string _Observacion;
        private decimal _ImporteEntrega;
        private decimal _Diferencia;
        private decimal _SaldoFinal;

        public int NroCaja
        {
            get
            {
                return _NroCaja;
            }

            set
            {
                _NroCaja = value;
            }
        }

        public DateTime FechaApertura
        {
            get
            {
                return _FechaApertura;
            }

            set
            {
                _FechaApertura = value;
            }
        }

        public DateTime? FechaCierre
        {
            get
            {
                return _FechaCierre;
            }

            set
            {
                _FechaCierre = value;
            }
        }

        public int PersonaNro
        {
            get
            {
                return _PersonaNro;
            }

            set
            {
                _PersonaNro = value;
            }
        }

        public decimal Monto
        {
            get
            {
                return _Monto;
            }

            set
            {
                _Monto = value;
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

        public decimal ImporteEntrega
        {
            get
            {
                return _ImporteEntrega;
            }

            set
            {
                _ImporteEntrega = value;
            }
        }

        public decimal Diferencia
        {
            get
            {
                return _Diferencia;
            }

            set
            {
                _Diferencia = value;
            }
        }

        public decimal SaldoFinal
        {
            get
            {
                return _SaldoFinal;
            }

            set
            {
                _SaldoFinal = value;
            }
        }

        //Constructor sin parametris
        public DCaja() { }
        //constructor con parametros
        public DCaja(int nroCaja,DateTime fechaApertura, DateTime? fechaCierre,int personaNro,char estado,decimal monto,decimal importeentrega,decimal saldofinal,decimal diferencia ,string observacion)
        {
            this.NroCaja = NroCaja;
            this.FechaApertura = fechaApertura;
            this.FechaCierre = fechaCierre;
            this.PersonaNro = personaNro;
            this.Estado = estado;
            this.Monto = monto;
            this.ImporteEntrega = importeentrega;
            this.SaldoFinal = saldofinal;
            this.Diferencia = diferencia;
            this.Observacion = observacion;
        }

        //Metodo para insertar
        public string InsertarCaja(DCaja Caja) 
        {
            //declaracion de variables
            string rpta = "OK";
            SqlConnection Sqlcon = new SqlConnection();
            //constrolador de errores
            try
            {
                //establecer conexion
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                //abrir la conexion
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarArqueoCaja";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros del comando
                //NROCAJA
                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@NroCaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParNroCaja);

                //FECHA DE APERTURA
                SqlParameter ParFechaApertura = new SqlParameter();
                ParFechaApertura.ParameterName = "@FechaApertura";
                ParFechaApertura.SqlDbType = SqlDbType.DateTime;
                ParFechaApertura.Value = Caja.FechaApertura;
                SqlCmd.Parameters.Add(ParFechaApertura);

               
                //PERSONA NRO
                SqlParameter ParPersonaNro = new SqlParameter();
                ParPersonaNro.ParameterName = "@UsuarioNro";
                ParPersonaNro.SqlDbType = SqlDbType.Int;
                ParPersonaNro.Value = Caja.PersonaNro;
                SqlCmd.Parameters.Add(ParPersonaNro);

                

                //MONTO
                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@Monto";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Value = Caja.Monto;
                SqlCmd.Parameters.Add(ParMonto);

                //Observacion
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 150;
                ParObservacion.Value = Caja.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);


                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon);
            }
            return rpta;
        }



        public string EliminarArqueo(DCaja Caja)
        {
            //declaracion de variables
            string rpta = "OK";
            SqlConnection Sqlcon = new SqlConnection();
            //constrolador de errores
            try
            {
                //establecer conexion
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                //abrir la conexion
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EliminarArqueoCaja";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros del comando
                //NROCAJA
                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@CajaNro";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Caja.NroCaja;
                SqlCmd.Parameters.Add(ParNroCaja);


                //PERSONA NRO
                SqlParameter ParPersonaNro = new SqlParameter();
                ParPersonaNro.ParameterName = "@UsuarioNro";
                ParPersonaNro.SqlDbType = SqlDbType.Int;
                ParPersonaNro.Value = Caja.PersonaNro;
                SqlCmd.Parameters.Add(ParPersonaNro);

                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon);
            }
            return rpta;
        }


        //Metodo para Cerrar Caja
        public string CerrarCaja (DCaja Caja) 
        {
            //declaracion de variables
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            //constrolador de errores
            try
            {
                //establecer conexion
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                //abrir la conexion
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_CerrarCaja";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros del comando
                //NROCAJA
                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@NroCaja";
                ParNroCaja.SqlDbType = SqlDbType.Int;
                ParNroCaja.Value = Caja.NroCaja;
                SqlCmd.Parameters.Add(ParNroCaja);

                //FECHA DE CIERRE
                SqlParameter ParFechaCierre = new SqlParameter();
                ParFechaCierre.ParameterName = "@FechaCierre";
                ParFechaCierre.SqlDbType = SqlDbType.DateTime;
                ParFechaCierre.Value = Caja.FechaCierre;
                SqlCmd.Parameters.Add(ParFechaCierre);

                //IMPORTE ENTREGA
                SqlParameter ParImporteEntrega = new SqlParameter();
                ParImporteEntrega.ParameterName = "@ImporteEntrega";
                ParImporteEntrega.SqlDbType = SqlDbType.Decimal;
                ParImporteEntrega.Value = Caja.ImporteEntrega;
                SqlCmd.Parameters.Add(ParImporteEntrega);

                //DIFERENCIA DE CAJA
                SqlParameter ParDiferencia = new SqlParameter();
                ParDiferencia.ParameterName = "@Diferencia";
                ParDiferencia.SqlDbType = SqlDbType.Decimal;
                ParDiferencia.Value = Caja.Diferencia;
                SqlCmd.Parameters.Add(ParDiferencia);


                //SALDO FINAL
                SqlParameter ParSaldo = new SqlParameter();
                ParSaldo.ParameterName = "@SaldoFinal";
                ParSaldo.SqlDbType = SqlDbType.Decimal;
                ParSaldo.Value = Caja.SaldoFinal;
                SqlCmd.Parameters.Add(ParSaldo);
                

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "La caja no se pudo cerrar";

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
        public DataTable MostrarSaldoCaja()
        {
            DataTable DtResultado = new DataTable("Saldo");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarSaldoCaja";
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


        //Metodo Mostrar
        public DataTable MostrarCajaAbierta(int usuario)
        {
            DataTable DtResultado = new DataTable("CajaAbierta");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarCajaAbierta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //USUARIO
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@UsuarioNro";
                ParUsuario.SqlDbType = SqlDbType.Int;
                ParUsuario.Value = usuario;
                SqlCmd.Parameters.Add(ParUsuario);


                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }



        public DataTable MostrarListaArqueos(string fechadesde,string fechahasta)
        {
            DataTable DtResultado = new DataTable("ListaArqueos");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarListaArqueos";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlCmd.Parameters.AddWithValue("@fechaDesde", fechadesde);
                SqlCmd.Parameters.AddWithValue("@fechaHasta", fechahasta);

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
                throw ex;                
            }
            finally 
            {
                Conexion.CerrarConexion(Sqlcon);
            }
            return DtResultado;
        }


        //Metodo Mostrar movimiento de pagos en la caja
        public DataTable MostrarMovimientoPagos(string fechainicio,string fechafin)
        {
            DataTable DtResultado = new DataTable("MovimientoPagosFactura");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarMovimientoCajaPagosFactura";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //FechaInicio RANGO
                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@FechaInicio";
                ParFechaInicio.SqlDbType = SqlDbType.VarChar;
                ParFechaInicio.Size = 50;
                ParFechaInicio.Value = fechainicio;
                SqlCmd.Parameters.Add(ParFechaInicio);

                //FechaFin RANGO
                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@FechaFin";
                ParFechaFin.SqlDbType = SqlDbType.VarChar;
                ParFechaFin.Size = 50;
                ParFechaFin.Value = fechafin;
                SqlCmd.Parameters.Add(ParFechaFin);


                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }



        public DataTable BuscarMovimientoPagos(string fechainicio, string fechafin)
        {
            DataTable DtResultado = new DataTable("MovimientoPagosFactura");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = Conexion.AbrirConexion(Conexion.CadenaConexion,null);                
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarMovimientoPagosCaja";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //FechaInicio RANGO
                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@FechaInicio";
                ParFechaInicio.SqlDbType = SqlDbType.VarChar;
                ParFechaInicio.Size = 50;
                ParFechaInicio.Value = fechainicio;
                SqlCmd.Parameters.Add(ParFechaInicio);

                //FechaFin RANGO
                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@FechaFin";
                ParFechaFin.SqlDbType = SqlDbType.VarChar;
                ParFechaFin.Size = 50;
                ParFechaFin.Value = fechafin;
                SqlCmd.Parameters.Add(ParFechaFin);


                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            finally 
            {
                Conexion.CerrarConexion(Sqlcon);
            }
            return DtResultado;
        }



        //FILTRO CAJA POR FECHA -RESUMEN
        public DataTable FiltroCajaResumen(string fechainicio, string fechafin)
        {
            DataTable DtResultado = new DataTable("ResumenCaja");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarResumenCajaFecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //FechaInicio RANGO
                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@FechaInicio";
                ParFechaInicio.SqlDbType = SqlDbType.VarChar;
                ParFechaInicio.Size = 20;
                ParFechaInicio.Value = fechainicio;
                SqlCmd.Parameters.Add(ParFechaInicio);

                //FechaFin RANGO
                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@FechaFin";
                ParFechaFin.SqlDbType = SqlDbType.VarChar;
                ParFechaFin.Size = 20;
                ParFechaFin.Value = fechafin;
                SqlCmd.Parameters.Add(ParFechaFin);


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
