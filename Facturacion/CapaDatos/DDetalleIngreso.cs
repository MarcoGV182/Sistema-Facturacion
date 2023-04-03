using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DDetalleIngreso
    {
        public int idCompra { get; set; }
        private int _DetalleCompraNro;
        public int NroItem { get; set; }
        public DTipoImpuesto TipoImpuesto { get; set; }
        private int _ProductoNro;
        private int _Cantidad;
        private decimal _PrecioUnitario;
        //private int _TextoBuscar;

        public int DetalleCompraNro
        {
            get{return _DetalleCompraNro;}
            set{_DetalleCompraNro = value;}
        }

        
        public int ProductoNro
        {
            get{return _ProductoNro;}
            set{_ProductoNro = value;}
        }

        public int Cantidad
        {
            get{return _Cantidad;}
            set{ _Cantidad = value;}
        }
       

        public decimal PrecioUnitario
        {
            get{return _PrecioUnitario;}
            set{_PrecioUnitario = value;}
        }
        

        public DDetalleIngreso() {

        }


        public DDetalleIngreso(int detallecompraNro,string nrofacturacompra,int proveedornro,int productonro,int cantidad,decimal precioCompra) {
            this.DetalleCompraNro = detallecompraNro;
            this.ProductoNro = proveedornro;         
            this.ProductoNro = productonro;
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioCompra;           
        }

        //Metodo insertar
        public string InsertarDetalleCompra(DDetalleIngreso DetalleCompra, ref SqlConnection Sqlcon, ref SqlTransaction sqltran)
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
