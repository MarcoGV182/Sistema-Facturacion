using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DLiquidacion:Conexion
    {
        private int _UsuarioNro;
        private int _ProcesoNro;
        private int _DescuentoNro;
        private int _Cantidad;
        private decimal _Monto;       

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

        public int ProcesoNro
        {
            get
            {
                return _ProcesoNro;
            }

            set
            {
                _ProcesoNro = value;
            }
        }

        public int DescuentoNro
        {
            get
            {
                return _DescuentoNro;
            }

            set
            {
                _DescuentoNro = value;
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


        public DLiquidacion() { }

        public DLiquidacion(int usuarionro, int procesonro, int descuentonro, int cantidad, decimal monto) 
        {
            this.UsuarioNro = usuarionro;
            this.ProcesoNro = procesonro;
            this.DescuentoNro = descuentonro;
            this.Cantidad = cantidad;
            this.Monto = monto;
        }


        //Metodo insertar
        public string InsertarLiquidacion(DLiquidacion Liquidacion)
        {
            string rpta = "";
            SqlConnection Sqlcon = null;
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarDetalleDescuento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros UsuarioNro
                SqlParameter ParUsuarioNro = new SqlParameter();
                ParUsuarioNro.ParameterName = "@UsuarioNro";
                ParUsuarioNro.SqlDbType = SqlDbType.Int;
                ParUsuarioNro.Value = Liquidacion.UsuarioNro;
                SqlCmd.Parameters.Add(ParUsuarioNro);


                //Parametros ProcesoNro
                SqlParameter ParProcesoNro = new SqlParameter();
                ParProcesoNro.ParameterName = "@ProcesoNro";
                ParProcesoNro.SqlDbType = SqlDbType.Int;
                ParProcesoNro.Value = Liquidacion.ProcesoNro;
                SqlCmd.Parameters.Add(ParProcesoNro);


                //Parametros DescuentoNro
                SqlParameter ParDescuentoNro = new SqlParameter();
                ParDescuentoNro.ParameterName = "@DescuentoNro";
                ParDescuentoNro.SqlDbType = SqlDbType.Int;
                ParDescuentoNro.Value = Liquidacion.DescuentoNro;
                SqlCmd.Parameters.Add(ParDescuentoNro);


                //Parametros Cantidad
                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Liquidacion.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);


                //Parametros Monto
                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@Monto";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Value = Liquidacion.Monto;
                SqlCmd.Parameters.Add(ParMonto);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";

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



        //Metodo insertar
        public string GenerarCabLiquidacion(DLiquidacion Liquidacion)
        {
            string rpta = "";
            SqlConnection Sqlcon = null;
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_GenerarLiquidacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                
                //Parametros ProcesoNro
                SqlParameter ParProcesoNro = new SqlParameter();
                ParProcesoNro.ParameterName = "@ProcesoNro";
                ParProcesoNro.SqlDbType = SqlDbType.Int;
                ParProcesoNro.Value = Liquidacion.ProcesoNro;
                SqlCmd.Parameters.Add(ParProcesoNro);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se inserto el registro";

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
        public DataTable Mostrar(DLiquidacion Liquidacion)
        {
            DataTable DtResultado = new DataTable("Liquidacion");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarLiquidacionDescuento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros ProcesoNro
                SqlParameter ParProcesoNro = new SqlParameter();
                ParProcesoNro.ParameterName = "@ProcesoNro";
                ParProcesoNro.SqlDbType = SqlDbType.Int;
                ParProcesoNro.Value = Liquidacion.ProcesoNro;
                SqlCmd.Parameters.Add(ParProcesoNro);


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


        //Metodo insertar
        public string EliminarLiquidacion(DLiquidacion Liquidacion)
        {
            string rpta = "";
            SqlConnection Sqlcon = null;
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EliminarDetalleDescuento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros UsuarioNro
                SqlParameter ParUsuarioNro = new SqlParameter();
                ParUsuarioNro.ParameterName = "@UsuarioNro";
                ParUsuarioNro.SqlDbType = SqlDbType.Int;
                ParUsuarioNro.Value = Liquidacion.UsuarioNro;
                SqlCmd.Parameters.Add(ParUsuarioNro);


                //Parametros ProcesoNro
                SqlParameter ParProcesoNro = new SqlParameter();
                ParProcesoNro.ParameterName = "@ProcesoNro";
                ParProcesoNro.SqlDbType = SqlDbType.Int;
                ParProcesoNro.Value = Liquidacion.ProcesoNro;
                SqlCmd.Parameters.Add(ParProcesoNro);


                //Parametros DescuentoNro
                SqlParameter ParDescuentoNro = new SqlParameter();
                ParDescuentoNro.ParameterName = "@DescuentoNro";
                ParDescuentoNro.SqlDbType = SqlDbType.Int;
                ParDescuentoNro.Value = Liquidacion.DescuentoNro;
                SqlCmd.Parameters.Add(ParDescuentoNro);
                

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó el registro";

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


    }
}
