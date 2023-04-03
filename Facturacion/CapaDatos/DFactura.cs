﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using CapaDatos;
using System.Diagnostics;
using CapaDatos.Interfaces;

namespace CapaDatos
{
    public class DFactura : IDocumento
    {
        public int Id { get; set; }
        public int Establecimiento { get; set; }
        public int PuntoExpedicion { get; set; }
        public int Numero { get; set; }
        public string NroFactura { get; set; }
        public int ClienteNro { get; set; }
        public string NombreCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int CodTipoPago { get; set; }
        public int TipoComprobanteNro { get; set; }
        public string Estado { get; set; }
        public string Timbrado { get; set; }
        public string Observacion { get; set; }
        public string Usuario { get; set; }
        public int? Vendedor { get; set; }
        public int? CantCuota { get; set; }
        public int NroOrden { get; set; }


        public DFactura() { }

        public DFactura(int nroVenta,string nroFactura,int clienteNro,string nombrecliente,int establecimiento,int puntoexpedicion, int numero,string timbrado,DateTime fecha,int codtipopago,int tipoComprobante,string estado,string observacion, string usuario) 
        {
            this.Id = nroVenta;
            this.NroFactura = nroFactura;
            this.ClienteNro = clienteNro;
            this.NombreCliente = nombrecliente;
            this.Establecimiento = establecimiento;
            this.PuntoExpedicion = puntoexpedicion;
            this.Numero = numero;
            this.Timbrado = timbrado;
            this.Fecha = fecha;
            this.CodTipoPago = codtipopago;
            this.TipoComprobanteNro = tipoComprobante;
            this.Estado = estado;
            this.Observacion = observacion;
            this.Usuario = usuario;
        }


        //Metodo insertar
        public string InsertarFactura(DFactura Factura, List<DDetalleFactura> DetalleFactura)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                /*Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();*/
                Sqlcon = Conexion.AbrirConexion(Conexion.CadenaConexion);
                //establecer la transaccion
                SqlTransaction Sqltran = Sqlcon.BeginTransaction();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = Sqltran;
                SqlCmd.CommandText = "sp_InsertarFactura";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParNroVenta = new SqlParameter();
                ParNroVenta.ParameterName = "@NroVenta";
                ParNroVenta.SqlDbType = SqlDbType.Int;
                ParNroVenta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParNroVenta);

                //Parametros Nro de Factura
                SqlParameter ParNroFactura = new SqlParameter();
                ParNroFactura.ParameterName = "@NroFactura";
                ParNroFactura.SqlDbType = SqlDbType.VarChar;
                ParNroFactura.Size = 50;
                ParNroFactura.Value = Factura.NroFactura;
                SqlCmd.Parameters.Add(ParNroFactura);

                //Parametros 
                SqlParameter ParEstablecimiento = new SqlParameter();
                ParEstablecimiento.ParameterName = "@Establecimiento";
                ParEstablecimiento.SqlDbType = SqlDbType.Int;
                ParEstablecimiento.Value = Factura.Establecimiento;
                SqlCmd.Parameters.Add(ParEstablecimiento);

                //Parametros 
                SqlParameter ParPuntoExpedicion = new SqlParameter();
                ParPuntoExpedicion.ParameterName = "@PuntoExpedicion";
                ParPuntoExpedicion.SqlDbType = SqlDbType.Int;
                ParPuntoExpedicion.Value = Factura.PuntoExpedicion;
                SqlCmd.Parameters.Add(ParPuntoExpedicion);

                //Parametros 
                SqlParameter ParNumero = new SqlParameter();
                ParNumero.ParameterName = "@Numero";
                ParNumero.SqlDbType = SqlDbType.Int;
                ParNumero.Value = Factura.Numero;
                SqlCmd.Parameters.Add(ParNumero);

                //Parametros 
                SqlParameter ParClienteNro = new SqlParameter();
                ParClienteNro.ParameterName = "@ClienteNro";
                ParClienteNro.SqlDbType = SqlDbType.Int;
                ParClienteNro.Value = Factura.ClienteNro;
                SqlCmd.Parameters.Add(ParClienteNro);

                //Parametro nombre cliente
                SqlParameter ParNombreCliente = new SqlParameter();
                ParNombreCliente.ParameterName = "@NombreCliente";
                ParNombreCliente.SqlDbType = SqlDbType.VarChar;
                ParNombreCliente.Size = 250;
                ParNombreCliente.Value = Factura.NombreCliente;
                SqlCmd.Parameters.Add(ParNombreCliente);

                //Parametros usuario
                SqlParameter ParVendedor = new SqlParameter();
                ParVendedor.ParameterName = "@Vendedor";
                ParVendedor.SqlDbType = SqlDbType.Int;
                ParVendedor.Value = Factura.Vendedor;
                SqlCmd.Parameters.Add(ParVendedor);

                //Parametros TipoPago
                SqlParameter ParCantCuota = new SqlParameter();
                ParCantCuota.ParameterName = "@CantCuota";
                ParCantCuota.SqlDbType = SqlDbType.Int;
                ParCantCuota.Value = Factura.CantCuota;
                SqlCmd.Parameters.Add(ParCantCuota);


                //Parametros Fecha Factura
                SqlParameter ParFechaVenta = new SqlParameter();
                ParFechaVenta.ParameterName = "@FechaFactura";
                ParFechaVenta.SqlDbType = SqlDbType.DateTime;
                ParFechaVenta.Value = Factura.Fecha;
                SqlCmd.Parameters.Add(ParFechaVenta);

                //Parametros TipoPago
                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@CodTipoPago";
                ParFormaPago.SqlDbType = SqlDbType.Int;
                ParFormaPago.Value = Factura.CodTipoPago;
                SqlCmd.Parameters.Add(ParFormaPago);

                //Parametros tipo de comprobante
                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@ComprobanteNro";
                ParTipoComprobante.SqlDbType = SqlDbType.Int;
                ParTipoComprobante.Value = Factura.TipoComprobanteNro;
                SqlCmd.Parameters.Add(ParTipoComprobante);


                //Parametros Estado
                SqlParameter ParNroOrden = new SqlParameter();
                ParNroOrden.ParameterName = "@NroOrden";
                ParNroOrden.SqlDbType = SqlDbType.Int;
                ParNroOrden.Value = Factura.NroOrden;
                SqlCmd.Parameters.Add(ParNroOrden);


                //Parametros Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 9;
                ParEstado.Value = Factura.Estado;
                SqlCmd.Parameters.Add(ParEstado);
               

                //Parametros Estado
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 256;
                ParObservacion.Value = Factura.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                //Parametros usuario
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 50;
                ParUsuario.Value = Factura.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);               

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se inserto el registro";

                if (rpta.Equals("OK"))
                {
                    //Obtener el NroCompra
                    this.Id = Convert.ToInt32(SqlCmd.Parameters["@NroVenta"].Value);                    
                    foreach (DDetalleFactura det in DetalleFactura)
                    {
                        det.NroVenta = this.Id;

                        //Llamar al metodo insertar
                        rpta = det.InsertarDetalleFactura(det, ref Sqlcon, ref Sqltran);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                        else 
                        {
                        //descontar stock
                            this.DisminuirStock(det.ArticuloNro, det.Cantidad, Sqlcon, Sqltran);
                        }
                    }
                }
                if (rpta.Equals("OK"))
                {
                    rpta = $"{this.Id};OK";
                    Sqltran.Commit();
                }
                else
                {
                    Sqltran.Rollback();
                }

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon);
                /*if (Sqlcon.State == ConnectionState.Open)
                    Sqlcon.Close();*/
            }
            return rpta;
        }



        //Metodo insertar
        public string RegistrarFacturacion(DFactura Factura, 
                                          List<DDetalleFactura> DetalleFactura,
                                          RegistroPagoFacturacion pagos)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            SqlTransaction Sqltran = null;
            try
            {
                //codigo
                /*Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();*/
                Sqlcon = Conexion.AbrirConexion(Conexion.CadenaConexion);
                //establecer la transaccion
                Sqltran = Sqlcon.BeginTransaction();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = Sqltran;
                SqlCmd.CommandText = "sp_InsertarFactura";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParNroVenta = new SqlParameter();
                ParNroVenta.ParameterName = "@NroVenta";
                ParNroVenta.SqlDbType = SqlDbType.Int;
                ParNroVenta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParNroVenta);

                //Parametros Nro de Factura
                SqlParameter ParNroFactura = new SqlParameter();
                ParNroFactura.ParameterName = "@NroFactura";
                ParNroFactura.SqlDbType = SqlDbType.VarChar;
                ParNroFactura.Size = 50;
                ParNroFactura.Value = Factura.NroFactura;
                SqlCmd.Parameters.Add(ParNroFactura);

                //Parametros 
                SqlParameter ParEstablecimiento = new SqlParameter();
                ParEstablecimiento.ParameterName = "@Establecimiento";
                ParEstablecimiento.SqlDbType = SqlDbType.Int;
                ParEstablecimiento.Value = Factura.Establecimiento;
                SqlCmd.Parameters.Add(ParEstablecimiento);

                //Parametros 
                SqlParameter ParPuntoExpedicion = new SqlParameter();
                ParPuntoExpedicion.ParameterName = "@PuntoExpedicion";
                ParPuntoExpedicion.SqlDbType = SqlDbType.Int;
                ParPuntoExpedicion.Value = Factura.PuntoExpedicion;
                SqlCmd.Parameters.Add(ParPuntoExpedicion);

                //Parametros 
                SqlParameter ParNumero = new SqlParameter();
                ParNumero.ParameterName = "@Numero";
                ParNumero.SqlDbType = SqlDbType.Int;
                ParNumero.Value = Factura.Numero;
                SqlCmd.Parameters.Add(ParNumero);

                //Parametros 
                SqlParameter ParTimbrado = new SqlParameter();
                ParTimbrado.ParameterName = "@Timbrado";
                ParTimbrado.SqlDbType = SqlDbType.VarChar;
                ParTimbrado.Size = 50;
                ParTimbrado.Value = Factura.Timbrado;
                SqlCmd.Parameters.Add(ParTimbrado);

                //Parametros 
                SqlParameter ParClienteNro = new SqlParameter();
                ParClienteNro.ParameterName = "@ClienteNro";
                ParClienteNro.SqlDbType = SqlDbType.Int;
                ParClienteNro.Value = Factura.ClienteNro;
                SqlCmd.Parameters.Add(ParClienteNro);

                //Parametro nombre cliente
                SqlParameter ParNombreCliente = new SqlParameter();
                ParNombreCliente.ParameterName = "@NombreCliente";
                ParNombreCliente.SqlDbType = SqlDbType.VarChar;
                ParNombreCliente.Size = 250;
                ParNombreCliente.Value = Factura.NombreCliente;
                SqlCmd.Parameters.Add(ParNombreCliente);

                //Parametros usuario
                SqlParameter ParVendedor = new SqlParameter();
                ParVendedor.ParameterName = "@Vendedor";
                ParVendedor.SqlDbType = SqlDbType.Int;
                ParVendedor.Value = Factura.Vendedor;
                SqlCmd.Parameters.Add(ParVendedor);

                //Parametros TipoPago
                SqlParameter ParCantCuota = new SqlParameter();
                ParCantCuota.ParameterName = "@CantCuota";
                ParCantCuota.SqlDbType = SqlDbType.Int;
                ParCantCuota.Value = Factura.CantCuota;
                SqlCmd.Parameters.Add(ParCantCuota);


                //Parametros Fecha Factura
                SqlParameter ParFechaVenta = new SqlParameter();
                ParFechaVenta.ParameterName = "@FechaFactura";
                ParFechaVenta.SqlDbType = SqlDbType.DateTime;
                ParFechaVenta.Value = Factura.Fecha;
                SqlCmd.Parameters.Add(ParFechaVenta);

                //Parametros TipoPago
                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@CodTipoPago";
                ParFormaPago.SqlDbType = SqlDbType.Int;
                ParFormaPago.Value = Factura.CodTipoPago;
                SqlCmd.Parameters.Add(ParFormaPago);

                //Parametros tipo de comprobante
                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@ComprobanteNro";
                ParTipoComprobante.SqlDbType = SqlDbType.Int;
                ParTipoComprobante.Value = Factura.TipoComprobanteNro;
                SqlCmd.Parameters.Add(ParTipoComprobante);

                //Parametros Estado
                SqlParameter ParNroOrden = new SqlParameter();
                ParNroOrden.ParameterName = "@NroOrden";
                ParNroOrden.SqlDbType = SqlDbType.Int;
                ParNroOrden.Value = Factura.NroOrden;
                SqlCmd.Parameters.Add(ParNroOrden);


                //Parametros Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 9;
                ParEstado.Value = Factura.Estado;
                SqlCmd.Parameters.Add(ParEstado);


                //Parametros Estado
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 256;
                ParObservacion.Value = Factura.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                //Parametros usuario
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 50;
                ParUsuario.Value = Factura.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se inserto el registro";

                if (rpta.Equals("OK"))
                {
                    #region Registrar DetalleFactura
                    //Obtener el NroVenta
                    this.Id = Convert.ToInt32(SqlCmd.Parameters["@NroVenta"].Value);
                    foreach (DDetalleFactura det in DetalleFactura)
                    {
                        det.NroVenta = this.Id;

                        //Llamar al metodo insertar
                        rpta = det.InsertarDetalleFactura(det, ref Sqlcon, ref Sqltran);
                        if (!rpta.Equals("OK"))
                            break;
                        else
                            //descontar stock
                            this.DisminuirStock(det.ArticuloNro, det.Cantidad);
                    }
                    #endregion

                    #region Registrar Pagos
                    if (pagos != null)
                    {
                        if (pagos.Efectivo != null)
                        {
                            DPagoFacturaEfectivo ef = new DPagoFacturaEfectivo();
                            pagos.Efectivo.NroVenta = this.Id;
                            rpta = ef.InsertarPagoFacturaEfectivo(pagos.Efectivo, Sqlcon, Sqltran);
                            if (!rpta.Equals("OK"))
                                throw new Exception(rpta);
                        }


                        if (pagos.Tarjeta != null)
                        {
                            DPagoFacturaTarjeta tj = new DPagoFacturaTarjeta();
                            pagos.Tarjeta.NroVenta = this.Id;
                            rpta = tj.InsertarPagoFacturaTarjeta(pagos.Tarjeta, Sqlcon, Sqltran);
                            if (!rpta.Equals("OK"))
                                throw new Exception(rpta);
                        }

                        if (pagos.Cheque != null)
                        {
                            DPagoFacturaCheque cq = new DPagoFacturaCheque();
                            pagos.Cheque.NroVenta = this.Id;
                            rpta = cq.InsertarPagoFacturaCheque(pagos.Cheque, Sqlcon, Sqltran);
                            if (!rpta.Equals("OK"))
                                throw new Exception(rpta);
                        }
                    }
                    #endregion
                }
                if (rpta.Equals("OK"))
                {
                    rpta = $"{this.Id};OK";
                    Sqltran.Commit();
                }
                else
                {
                    Sqltran.Rollback();
                }

            }
            catch (Exception ex)
            {
                Sqltran.Rollback();
                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon);
                /*if (Sqlcon.State == ConnectionState.Open)
                    Sqlcon.Close();*/
            }
            return rpta;
        }



        //Metodo Eliminar
        public string Anular(int id,string usuario)
        {
            string rpta = "OK";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_AnularFacturaVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParNroVenta = new SqlParameter();
                ParNroVenta.ParameterName = "@NroVenta";
                ParNroVenta.SqlDbType = SqlDbType.Int;
                ParNroVenta.Value = id;
                SqlCmd.Parameters.Add(ParNroVenta);

                //Parametros 
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

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

        //Metodo Disminuir el Stock
        public string DisminuirStock(int Articulonro, int cantidad, SqlConnection SqlconExistente = null, SqlTransaction sqltranExistente = null)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            SqlTransaction sqltran = null;
            try
            {
                //codigo
                Sqlcon = Conexion.AbrirConexion(Conexion.CadenaConexion, SqlconExistente);
                sqltran = sqltranExistente == null ? Sqlcon.BeginTransaction() : sqltranExistente;
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = sqltran;
                SqlCmd.CommandText = "sp_DescontarStock";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParArticuloNro = new SqlParameter();
                ParArticuloNro.ParameterName = "@ArticuloNro";
                ParArticuloNro.SqlDbType = SqlDbType.Int;
                ParArticuloNro.Value = Articulonro;
                SqlCmd.Parameters.Add(ParArticuloNro);

                //Parametros 
                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

                if (sqltranExistente == null)
                    sqltran.Commit();
            }
            catch (Exception ex)
            {
                if (sqltranExistente == null)
                    sqltran.Rollback();
                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon, ref SqlconExistente);
            }

            return rpta;

        }



        //Actualizar estado de CUENTAPORCOBRAR 
        public string CuentaACobrar(DFactura Factura)
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
                SqlCmd.CommandText = "sp_InsertarCuentaPorCobrarVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros
                SqlParameter ParNroFactura = new SqlParameter();
                ParNroFactura.ParameterName = "@NroFactura";
                ParNroFactura.SqlDbType = SqlDbType.VarChar;
                ParNroFactura.Size = 20;
                ParNroFactura.Value = Factura.NroFactura;
                SqlCmd.Parameters.Add(ParNroFactura);

                //Parametros
                SqlParameter ParClienteNro = new SqlParameter();
                ParClienteNro.ParameterName = "@ClienteNro";
                ParClienteNro.SqlDbType = SqlDbType.Int;
                ParClienteNro.Value =Factura.ClienteNro;
                SqlCmd.Parameters.Add(ParClienteNro);



                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo la Venta";
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
        public DataTable BuscarFechas(string fechaInicio, string FechaFin)
        {
            DataTable DtResultado = new DataTable("Factura");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarFacturaFechas";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@FechaInicio";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 10;
                ParTextoBuscar.SqlValue = fechaInicio;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                //Parametros
                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@FechaFin";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 10;
                ParTextoBuscar2.SqlValue = FechaFin;
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                //instanciar un DataAdapter
                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
                throw new Exception(ex.Message);
            }
            finally 
            {
                Conexion.CerrarConexion(Sqlcon);
            }
            return DtResultado;
        }

        //Metodo Mostrar
        public DataTable MostrarDetalleFactura(string NroFactura, int clienteNro)
        {
            DataTable DtResultado = new DataTable("DetalleFactura");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarDetalleFactura";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parametros
                SqlParameter ParTextoBuscar1 = new SqlParameter();
                ParTextoBuscar1.ParameterName = "@TextoBuscar1";
                ParTextoBuscar1.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar1.Size = 50;
                ParTextoBuscar1.SqlValue = NroFactura;
                SqlCmd.Parameters.Add(ParTextoBuscar1);

                // Parametros
                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@TextoBuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.Int;
                ParTextoBuscar2.SqlValue = clienteNro;
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


        public string ConfInsercion(int NroVenta)
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
                SqlCmd.CommandText = "sp_ConfInsercionFactura";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros
                SqlParameter ParNroVenta = new SqlParameter();
                ParNroVenta.ParameterName = "@NroVenta";
                ParNroVenta.SqlDbType = SqlDbType.Int;
                ParNroVenta.Value = NroVenta;
                SqlCmd.Parameters.Add(ParNroVenta);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo la Factura";
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
        public DataTable MostrarFactura()
        {
            DataTable DtResultado = new DataTable("Factura");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarFactura";
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



        //Metodo Mostrar
        public DataTable MostrarFacturaAnulada()
        {
            DataTable DtResultado = new DataTable("Factura");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarFacturaAnulada";
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

        //Metodo Numeracion de Factura
        public DataTable MostrarNumeracionFactura(string comprobante)
        {
            DataTable DtResultado = new DataTable("Factura");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarNumeracionFactura";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParComprobante = new SqlParameter();
                ParComprobante.ParameterName = "@TipoComprobante";
                ParComprobante.SqlDbType = SqlDbType.VarChar;
                ParComprobante.Size = 10;
                ParComprobante.Value = comprobante;
                SqlCmd.Parameters.Add(ParComprobante);



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



        //Metodo Numeracion de Factura
        public DataTable MostrarPagosFactura(DFactura Factura)
        {
            DataTable DtResultado = new DataTable("PagosFactura");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarPagosFactura";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParComprobante = new SqlParameter();
                ParComprobante.ParameterName = "@NroVenta";
                ParComprobante.SqlDbType = SqlDbType.Int;
                ParComprobante.Value = Factura.Id;
                SqlCmd.Parameters.Add(ParComprobante);



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


        public double DesglosarIVA(double importeIVAIncluido,int TipoImpuesto,int cantidadDecimales,string valorARetornar) 
        {
            double ImporteRetorno = 0;
            SqlConnection Sqlcon = new SqlConnection();
            try
            {                
                Sqlcon = Conexion.AbrirConexion(Conexion.CadenaConexion);             
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;               
                SqlCmd.CommandText = "Select dbo.Fn_Desglosar_IVA(@ImporteIVAIncluido,@idTipoImpuesto,@CantDecimales,@Retorno)";
                SqlCmd.CommandType = CommandType.Text;

                SqlCmd.Parameters.AddWithValue("@ImporteIVAIncluido", importeIVAIncluido);
                SqlCmd.Parameters.AddWithValue("@idTipoImpuesto", TipoImpuesto);
                SqlCmd.Parameters.AddWithValue("@CantDecimales", cantidadDecimales);
                SqlCmd.Parameters.AddWithValue("@Retorno", valorARetornar);


                //ejecutar el comando sql
                ImporteRetorno = Convert.ToInt64(SqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                ImporteRetorno = 0;
                throw ex;                
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon);
               
            }
            return ImporteRetorno;

        }


    }
}