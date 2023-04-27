using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DDetalleAjuste:Conexion
    {
        private int _CodDetalleAjuste;
        private int _CodAjuste;
        private int _ArticuloNro;
        private int _Cantidad;
        private double _Costo;
        private int _StockAnterior;

        public int CodDetalleAjuste
        {
            get
            {
                return _CodDetalleAjuste;
            }

            set
            {
                _CodDetalleAjuste = value;
            }
        }

        public int CodAjuste
        {
            get
            {
                return _CodAjuste;
            }

            set
            {
                _CodAjuste = value;
            }
        }

        public int ArticuloNro
        {
            get
            {
                return _ArticuloNro;
            }

            set
            {
                _ArticuloNro = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
            }
        }

        public double Costo
        {
            get
            {
                return _Costo;
            }

            set
            {
                _Costo = value;
            }
        }

        public int StockAnterior
        {
            get
            {
                return _StockAnterior;
            }

            set
            {
                _StockAnterior = value;
            }
        }

        public DDetalleAjuste() {

        }

        public DDetalleAjuste(int coddetalleajuste, int codajuste, int articulonro, int cantidad, double costo,int stockanterior) {
            this.CodDetalleAjuste = coddetalleajuste;
            this.CodAjuste = codajuste;
            this.Cantidad = cantidad;
            this.ArticuloNro = articulonro;
            this.Costo = costo;
            this.StockAnterior = stockanterior;
        }

        //Metodo insertar
        public string InsertarDetalleAjuste(DDetalleAjuste DetalleAjuste, ref SqlConnection Sqlcon, ref SqlTransaction sqltran)
        {
            string rpta = "";
            try
            {
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                //establecer transaccion
                SqlCmd.Transaction = sqltran;
                SqlCmd.CommandText = "sp_InsertarDetalleAjuste";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParDetalleAjuste = new SqlParameter();
                ParDetalleAjuste.ParameterName = "@CodDetalleAjuste";
                ParDetalleAjuste.SqlDbType = SqlDbType.Int;
                ParDetalleAjuste.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParDetalleAjuste);

                //Parametros CodAjuste
                SqlParameter ParCodAjuste = new SqlParameter();
                ParCodAjuste.ParameterName = "@CodAjuste";
                ParCodAjuste.SqlDbType = SqlDbType.Int;
                ParCodAjuste.Value = DetalleAjuste.CodAjuste;
                SqlCmd.Parameters.Add(ParCodAjuste);


                //Parametros Producto
                SqlParameter ParProductoNro = new SqlParameter();
                ParProductoNro.ParameterName = "@ArticuloNro";
                ParProductoNro.SqlDbType = SqlDbType.Int;
                ParProductoNro.Value = DetalleAjuste.ArticuloNro;
                SqlCmd.Parameters.Add(ParProductoNro);


                //Parametros Cantidad
                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleAjuste.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                //Parametros Precio
                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@Costo";
                ParPrecio.SqlDbType = SqlDbType.Decimal;
                ParPrecio.Value = DetalleAjuste.Costo;
                SqlCmd.Parameters.Add(ParPrecio);

                //Parametros StockAnterior
                SqlParameter ParStockAnterior = new SqlParameter();
                ParStockAnterior.ParameterName = "@StockAnterior";
                ParStockAnterior.SqlDbType = SqlDbType.Int;
                ParStockAnterior.Value = DetalleAjuste.StockAnterior;
                SqlCmd.Parameters.Add(ParStockAnterior);

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
