﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class DProducto:Conexion
    {
        public DProducto() {

        }


        //Metodo Insertar
        public string InsertarProducto(EProducto Producto) {
            //declarar variable respuesta
            string rpta = "OK";
            //instanciamos la conexion
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarProductos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que recibe el procedimiento almacenado
                SqlParameter ParProductoNro = new SqlParameter();
                ParProductoNro.ParameterName = "@ProductoNro";
                ParProductoNro.SqlDbType = SqlDbType.Int;
                ParProductoNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParProductoNro);

                
                //Parametros 
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Producto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);
                                
                //Parametros 
                SqlParameter ParTipoProductoNro = new SqlParameter();
                ParTipoProductoNro.ParameterName = "@TipoProductoNro";
                ParTipoProductoNro.SqlDbType = SqlDbType.Int;
                ParTipoProductoNro.Value = Producto.TipoProducto.TipoProductoNro;
                SqlCmd.Parameters.Add(ParTipoProductoNro);

                //Parametros 
                SqlParameter ParidPresentacion = new SqlParameter();
                ParidPresentacion.ParameterName = "@idPresentacion";
                ParidPresentacion.SqlDbType = SqlDbType.Int;
                ParidPresentacion.Value = Producto.Presentacion.IdPresentacion;
                SqlCmd.Parameters.Add(ParidPresentacion);

                //Parametros 
                SqlParameter ParUnidadMedidaNro = new SqlParameter();
                ParUnidadMedidaNro.ParameterName = "@UnidadMedidaNro";
                ParUnidadMedidaNro.SqlDbType = SqlDbType.Int;
                ParUnidadMedidaNro.Value = Producto.UnidadMedida.UnidadMedidaNro;
                SqlCmd.Parameters.Add(ParUnidadMedidaNro);

                //Parametros 
                SqlParameter ParMarcaNro = new SqlParameter();
                ParMarcaNro.ParameterName = "@MarcaNro";
                ParMarcaNro.SqlDbType = SqlDbType.Int;
                ParMarcaNro.Value = Producto.Marca.MarcaNro;
                SqlCmd.Parameters.Add(ParMarcaNro);

                //Parametros 
                SqlParameter ParStockMinimo = new SqlParameter();
                ParStockMinimo.ParameterName = "@Stockminimo";
                ParStockMinimo.SqlDbType = SqlDbType.Int;
                ParStockMinimo.Value = Producto.Stockminimo;
                SqlCmd.Parameters.Add(ParStockMinimo);

                //Parametros 
                SqlParameter ParStockActual = new SqlParameter();
                ParStockActual.ParameterName = "@StockActual";
                ParStockActual.SqlDbType = SqlDbType.Int;
                ParStockActual.Value = Producto.StockActual;
                SqlCmd.Parameters.Add(ParStockActual);

                //Parametros 
                SqlParameter ParTipoImpuestoNro = new SqlParameter();
                ParTipoImpuestoNro.ParameterName = "@TipoImpuestoNro";
                ParTipoImpuestoNro.SqlDbType = SqlDbType.SmallInt;
                ParTipoImpuestoNro.Value = Producto.TipoImpuesto.TipoImpuestoNro;
                SqlCmd.Parameters.Add(ParTipoImpuestoNro);

                // Parametros
                SqlParameter ParPrecioCompra = new SqlParameter();
                ParPrecioCompra.ParameterName = "@PrecioCompra";
                ParPrecioCompra.SqlDbType = SqlDbType.Float;
                ParPrecioCompra.Value = Producto.PrecioCompra;
                SqlCmd.Parameters.Add(ParPrecioCompra);


                // Parametros
                SqlParameter ParPrecioMinorista = new SqlParameter();
                ParPrecioMinorista.ParameterName = "@Precio";
                ParPrecioMinorista.SqlDbType = SqlDbType.Float;
                ParPrecioMinorista.Value = Producto.Precio;
                SqlCmd.Parameters.Add(ParPrecioMinorista);

                //Parametros Estado
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 100;
                ParObservacion.Value = Producto.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                //Parametros Estado
                SqlParameter ParCodigoBarra = new SqlParameter();
                ParCodigoBarra.ParameterName = "@CodigoBarra";
                ParCodigoBarra.SqlDbType = SqlDbType.VarChar;
                ParCodigoBarra.Size = 100;
                ParCodigoBarra.Value = Producto.CodigoBarra;
                SqlCmd.Parameters.Add(ParCodigoBarra);

                //Parametros 
                SqlParameter ParFechaVto = new SqlParameter();
                ParFechaVto.ParameterName = "@FechaVto";
                ParFechaVto.SqlDbType = SqlDbType.Date;
                ParFechaVto.Value = Producto.FechaVencimiento;
                SqlCmd.Parameters.Add(ParFechaVto);

                //Parametros Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 8;
                ParEstado.Value = Producto.Estado;
                SqlCmd.Parameters.Add(ParEstado);
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

        //Metodo Editar
        public string EditarProducto(EProducto Producto)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EditarProductos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que recibe el procedimiento almacenado
                SqlParameter ParProductoNro = new SqlParameter();
                ParProductoNro.ParameterName = "@ArticuloNro";
                ParProductoNro.SqlDbType = SqlDbType.Int;
                ParProductoNro.Value = Producto.ArticuloNro;
                SqlCmd.Parameters.Add(ParProductoNro);

                //Parametros 
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Producto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);


                //Parametros 
                SqlParameter ParCodigoBarra = new SqlParameter();
                ParCodigoBarra.ParameterName = "@CodigoBarra";
                ParCodigoBarra.SqlDbType = SqlDbType.VarChar;
                ParCodigoBarra.Size = 100;
                ParCodigoBarra.Value = Producto.CodigoBarra;
                SqlCmd.Parameters.Add(ParCodigoBarra);


                //Parametros 
                SqlParameter ParFechaVto = new SqlParameter();
                ParFechaVto.ParameterName = "@FechaVto";
                ParFechaVto.SqlDbType = SqlDbType.Date;
                ParFechaVto.Value = Producto.FechaVencimiento;
                SqlCmd.Parameters.Add(ParFechaVto);


                //Parametros 
                SqlParameter ParTipoProductoNro = new SqlParameter();
                ParTipoProductoNro.ParameterName = "@TipoProductoNro";
                ParTipoProductoNro.SqlDbType = SqlDbType.Int;
                ParTipoProductoNro.Value = Producto.TipoProducto.TipoProductoNro;
                SqlCmd.Parameters.Add(ParTipoProductoNro);

                //Parametros 
                SqlParameter ParidPresentacion = new SqlParameter();
                ParidPresentacion.ParameterName = "@idPresentacion";
                ParidPresentacion.SqlDbType = SqlDbType.Int;
                ParidPresentacion.Value = Producto.Presentacion.IdPresentacion;
                SqlCmd.Parameters.Add(ParidPresentacion);

                //Parametros 
                SqlParameter ParUnidadMedidaNro = new SqlParameter();
                ParUnidadMedidaNro.ParameterName = "@UnidadMedidaNro";
                ParUnidadMedidaNro.SqlDbType = SqlDbType.Int;
                ParUnidadMedidaNro.Value = Producto.UnidadMedida.UnidadMedidaNro;
                SqlCmd.Parameters.Add(ParUnidadMedidaNro);

                //Parametros 
                SqlParameter ParMarcaNro = new SqlParameter();
                ParMarcaNro.ParameterName = "@MarcaNro";
                ParMarcaNro.SqlDbType = SqlDbType.Int;
                ParMarcaNro.Value = Producto.Marca.MarcaNro;
                SqlCmd.Parameters.Add(ParMarcaNro);

                //Parametros 
                SqlParameter ParStockMinimo = new SqlParameter();
                ParStockMinimo.ParameterName = "@Stockminimo";
                ParStockMinimo.SqlDbType = SqlDbType.Int;
                ParStockMinimo.Value = Producto.Stockminimo;
                SqlCmd.Parameters.Add(ParStockMinimo);

                //Parametros 
                SqlParameter ParStockActual = new SqlParameter();
                ParStockActual.ParameterName = "@StockActual";
                ParStockActual.SqlDbType = SqlDbType.Int;
                ParStockActual.Value = Producto.StockActual;
                SqlCmd.Parameters.Add(ParStockActual);

                // Parametros
                SqlParameter ParPrecioCompra = new SqlParameter();
                ParPrecioCompra.ParameterName = "@PrecioCompra";
                ParPrecioCompra.SqlDbType = SqlDbType.Money;
                ParPrecioCompra.Value = Producto.PrecioCompra;
                SqlCmd.Parameters.Add(ParPrecioCompra);

                //Parametros 
                SqlParameter ParTipoImpuestoNro = new SqlParameter();
                ParTipoImpuestoNro.ParameterName = "@TipoImpuestoNro";
                ParTipoImpuestoNro.SqlDbType = SqlDbType.SmallInt;
                ParTipoImpuestoNro.Value = Producto.TipoImpuesto.TipoImpuestoNro;
                SqlCmd.Parameters.Add(ParTipoImpuestoNro);               

                // Parametros
                SqlParameter ParPrecioMinorista = new SqlParameter();
                ParPrecioMinorista.ParameterName = "@Precio";
                ParPrecioMinorista.SqlDbType = SqlDbType.Float;
                ParPrecioMinorista.Value = Producto.Precio;
                SqlCmd.Parameters.Add(ParPrecioMinorista);

                //Parametros Estado
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 100;
                ParObservacion.Value = Producto.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                //Parametros Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 8;
                ParEstado.Value = Producto.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >=1 ? "OK" : "No se actualizo el registro";

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

        //Metodo Eliminar
        public string EliminarProducto(int ProductoId)
        {
            string rpta = "OK";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EliminarProductos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que recibe el procedimiento almacenado
                SqlParameter ParProductoNro = new SqlParameter();
                ParProductoNro.ParameterName = "@ProductoNro";
                ParProductoNro.SqlDbType = SqlDbType.Int;
                ParProductoNro.Value = ProductoId;
                SqlCmd.Parameters.Add(ParProductoNro);

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

        //Metodo Mostrar
        public DataTable MostrarProducto()
        {
            DataTable DtResultado = new DataTable("Producto");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarProductos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

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


        //Metodo Mostrar
        public DataTable MostrarProductoActivo()
        {
            DataTable DtResultado = new DataTable("Producto");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarProductosActivos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

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

        //Metodo Buscar
        public DataTable BuscarProducto(string productoDescripcion)
        {
            DataTable DtResultado = new DataTable("Producto");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarProductoDescripcion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue = productoDescripcion;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                //instanciar un DataAdapter
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

        //Metodo Buscar
        public DataTable BuscarProductoActivo(string productoDescripcion)
        {
            DataTable DtResultado = new DataTable("Producto");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarProductoActivo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue = productoDescripcion;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                //instanciar un DataAdapter
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
