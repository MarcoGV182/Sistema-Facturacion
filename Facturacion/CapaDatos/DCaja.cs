using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

//Hola que tal ojala este ya funcione

namespace CapaDatos
{
    public class DCaja:Conexion
    {
        //Constructor sin parametris
        public DCaja() { }

        //Metodo para insertar
        public string InsertarCaja(ECaja Caja) 
        {
            //declaracion de variables
            string rpta = "OK";
            SqlConnection Sqlcon = null;
            //constrolador de errores
            try
            {
                //establecer conexion
                Sqlcon = AbrirConexion();
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
                ParMonto.Value = Caja.ImporteApertura;
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
                CerrarConexion(Sqlcon);
            }
            return rpta;
        }


        public string EliminarArqueo(int ArqueoId,int usuarioId)
        {
            //declaracion de variables
            string rpta = "OK";
            SqlConnection Sqlcon = new SqlConnection();
            //constrolador de errores
            try
            {
                //establecer conexion
                Sqlcon = AbrirConexion();
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
                ParNroCaja.Value = ArqueoId;
                SqlCmd.Parameters.Add(ParNroCaja);


                //PERSONA NRO
                SqlParameter ParPersonaNro = new SqlParameter();
                ParPersonaNro.ParameterName = "@UsuarioNro";
                ParPersonaNro.SqlDbType = SqlDbType.Int;
                ParPersonaNro.Value = usuarioId;
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
                CerrarConexion(Sqlcon);
            }
            return rpta;
        }


        //Metodo para Cerrar Caja
        public string CerrarCaja (ECaja Caja) 
        {
            //declaracion de variables
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            //constrolador de errores
            try
            {
                //establecer conexion
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_CerrarCaja";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros del comando
                //NROCAJA
                SqlParameter ParNroCaja = new SqlParameter();
                ParNroCaja.ParameterName = "@CajaNro";
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
                CerrarConexion(Sqlcon);
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
                Sqlcon = AbrirConexion();
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
                Sqlcon = AbrirConexion();
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
                Sqlcon = AbrirConexion();
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
                CerrarConexion(Sqlcon);
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
                Sqlcon = AbrirConexion();
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
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();                
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
                CerrarConexion(Sqlcon);
            }
            return DtResultado;
        }


        //FILTRO CAJA POR FECHA -RESUMEN
        public DataTable FiltroCajaResumen(string fechainicio, string fechafin)
        {
            DataTable DtResultado = new DataTable("ResumenCaja");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
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
            finally 
            {
                CerrarConexion(Sqlcon);
            }
            return DtResultado;
        }



    }
}
