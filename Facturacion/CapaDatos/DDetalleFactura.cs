using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaEntidades;

namespace CapaDatos
{
    public class DDetalleFactura:Conexion
    {

        //Metodo insertar
        public string InsertarDetalleFactura(EDetalleFactura DetalleFactura, ref SqlConnection Sqlcon, ref SqlTransaction sqltran)
        {
            string rpta = "";
            try
            {
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                //establecer transaccion
                SqlCmd.Transaction = sqltran;
                SqlCmd.CommandText = "sp_InsertarDetalleFactura";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParDetalleFactura = new SqlParameter();
                ParDetalleFactura.ParameterName = "@CodDetalle";
                ParDetalleFactura.SqlDbType = SqlDbType.Int;
                ParDetalleFactura.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParDetalleFactura);

                //Parametros NroItem
                SqlParameter ParNroItem = new SqlParameter();
                ParNroItem.ParameterName = "@NroItem";
                ParNroItem.SqlDbType = SqlDbType.Int;
                ParNroItem.Value = DetalleFactura.NroItem;
                SqlCmd.Parameters.Add(ParNroItem);

                //Parametros NroFactura
                SqlParameter ParNroVenta = new SqlParameter();
                ParNroVenta.ParameterName = "@NroVenta";
                ParNroVenta.SqlDbType = SqlDbType.Int;
                ParNroVenta.Value = DetalleFactura.NroVenta;
                SqlCmd.Parameters.Add(ParNroVenta);


                //Parametros Producto
                SqlParameter ParProductoNro = new SqlParameter();
                ParProductoNro.ParameterName = "@ArticuloNro";
                ParProductoNro.SqlDbType = SqlDbType.Int;
                ParProductoNro.Value = DetalleFactura.Articulo;
                SqlCmd.Parameters.Add(ParProductoNro);


                //Parametros Cantidad
                SqlParameter ParIdImpuesto = new SqlParameter();
                ParIdImpuesto.ParameterName = "@IdTipoImpuesto";
                ParIdImpuesto.SqlDbType = SqlDbType.Int;
                ParIdImpuesto.Value = DetalleFactura.TipoImpuesto.TipoImpuestoNro;
                SqlCmd.Parameters.Add(ParIdImpuesto);


                //Parametros Cantidad
                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleFactura.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                //Parametros Precio
                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@Precio";
                ParPrecio.SqlDbType = SqlDbType.Decimal;
                ParPrecio.Value = DetalleFactura.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                //Parametros PrecioFinal
                SqlParameter ParPrecioFinal = new SqlParameter();
                ParPrecioFinal.ParameterName = "@PrecioFinal";
                ParPrecioFinal.SqlDbType = SqlDbType.Decimal;
                ParPrecioFinal.Value = DetalleFactura.PrecioFinal;
                SqlCmd.Parameters.Add(ParPrecioFinal);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
    }
}
