using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class DDetalleCompra:Conexion
    {

        public DDetalleCompra() 
        {

        }        

        //Metodo insertar
        public string InsertarDetalleCompra(EDetalleCompra DetalleCompra, ref SqlConnection Sqlcon, ref SqlTransaction sqltran)
        {
            string rpta = "";
            try
            {
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                //establecer transaccion
                SqlCmd.Transaction = sqltran;
                SqlCmd.CommandText = "sp_InsertarDetalleCompra";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros 
                SqlParameter ParNroCompra = new SqlParameter();
                ParNroCompra.ParameterName = "@NroCompra";
                ParNroCompra.SqlDbType = SqlDbType.Int;
                ParNroCompra.Value = DetalleCompra.idCompra;
                SqlCmd.Parameters.Add(ParNroCompra);

                //Parametros 
                SqlParameter ParNroItem = new SqlParameter();
                ParNroItem.ParameterName = "@NroItem";
                ParNroItem.SqlDbType = SqlDbType.Int;
                ParNroItem.Value = DetalleCompra.NroItem;
                SqlCmd.Parameters.Add(ParNroItem);
                

                //Parametros Producto
                SqlParameter ParProductoNro = new SqlParameter();
                ParProductoNro.ParameterName = "@ProductoNro";
                ParProductoNro.SqlDbType = SqlDbType.Int;
                ParProductoNro.Value = DetalleCompra.ProductoNro;
                SqlCmd.Parameters.Add(ParProductoNro);



                //Parametros Producto
                SqlParameter ParIdImpuesto = new SqlParameter();
                ParIdImpuesto.ParameterName = "@idTipoImpuesto";
                ParIdImpuesto.SqlDbType = SqlDbType.Int;
                ParIdImpuesto.Value = DetalleCompra.TipoImpuesto.TipoImpuestoNro;
                SqlCmd.Parameters.Add(ParIdImpuesto);

                //Parametros Cantidad
                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleCompra.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);
                                               
                //Parametros Precio
                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@Precio";
                ParPrecio.SqlDbType = SqlDbType.Decimal;
                ParPrecio.Value = DetalleCompra.PrecioUnitario;
                SqlCmd.Parameters.Add(ParPrecio);

               //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se inserto el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }            
            return rpta;            
        }

    }
}
