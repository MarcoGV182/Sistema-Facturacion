using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleOrdenTrabajo
    {
        private int _NroOT;
        private int _ServicioNro;
        private int _UsuarioNro;
        private decimal _Precio;
        private decimal _Comision;
        private decimal _ganancia;

        public int NroOT
        {
            get
            {
                return _NroOT;
            }

            set
            {
                _NroOT = value;
            }
        }

        public int ServicioNro
        {
            get
            {
                return _ServicioNro;
            }

            set
            {
                _ServicioNro = value;
            }
        }

        public decimal Precio
        {
            get
            {
                return _Precio;
            }

            set
            {
                _Precio = value;
            }
        }

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

        public decimal Comision
        {
            get
            {
                return _Comision;
            }

            set
            {
                _Comision = value;
            }
        }

        public decimal Ganancia
        {
            get
            {
                return _ganancia;
            }

            set
            {
                _ganancia = value;
            }
        }

        public DDetalleOrdenTrabajo() { }

        public DDetalleOrdenTrabajo(int nroot, int servicionro, int usuarionro) 
        {
            this.NroOT = nroot;
            this.ServicioNro = servicionro;
            this.UsuarioNro = usuarionro;
        }


        //Metodo insertar
        public string InsertarDetalleOT(DDetalleOrdenTrabajo DetalleOT, ref SqlConnection Sqlcon, ref SqlTransaction sqltran)
        {
            string rpta = "";
            try
            {
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                //establecer transaccion
                SqlCmd.Transaction = sqltran;
                SqlCmd.CommandText = "sp_InsertarDetalleOrdenTrabajo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

               
                //Parametros NroOT
                SqlParameter ParNroOT = new SqlParameter();
                ParNroOT.ParameterName = "@NroOT";
                ParNroOT.SqlDbType = SqlDbType.Int;
                ParNroOT.Value = DetalleOT.NroOT;
                SqlCmd.Parameters.Add(ParNroOT);

                //Parametros ServicioNro
                SqlParameter ParServicioNro = new SqlParameter();
                ParServicioNro.ParameterName = "@ServicioNro";
                ParServicioNro.SqlDbType = SqlDbType.Int;
                ParServicioNro.Value = DetalleOT.ServicioNro;
                SqlCmd.Parameters.Add(ParServicioNro);


                //Parametro Comision del Servicio
                SqlParameter ParComision = new SqlParameter();
                ParComision.ParameterName = "@Comision";
                ParComision.SqlDbType = SqlDbType.Decimal;
                ParComision.Value = DetalleOT.Comision;
                SqlCmd.Parameters.Add(ParComision);

                //Parametro Ganancia
                SqlParameter ParGanancia = new SqlParameter();
                ParGanancia.ParameterName = "@Ganancia";
                ParGanancia.SqlDbType = SqlDbType.Decimal;
                ParGanancia.Value = DetalleOT.Ganancia;
                SqlCmd.Parameters.Add(ParGanancia);

                //Parametro UsuarioNro
                SqlParameter ParUsuarioNro = new SqlParameter();
                ParUsuarioNro.ParameterName = "@UsuarioNro";
                ParUsuarioNro.SqlDbType = SqlDbType.Int;
                ParUsuarioNro.Value = DetalleOT.UsuarioNro;
                SqlCmd.Parameters.Add(ParUsuarioNro);


                //Parametros de Precio
                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@Precio";
                ParPrecio.SqlDbType = SqlDbType.Decimal;
                ParPrecio.Value = DetalleOT.Precio;
                SqlCmd.Parameters.Add(ParPrecio);
                

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se insertó el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
    



    //Metodo Editar
    public string EditarDetalleOT(DDetalleOrdenTrabajo DetalleOT, ref SqlConnection Sqlcon, ref SqlTransaction sqltran)
    {
        string rpta = "";
        try
        {
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                //establecer transaccion
                SqlCmd.Transaction = sqltran;
                SqlCmd.CommandText = "sp_EditarDetalleOrdenTrabajo";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros NroOT
                SqlParameter ParNroOT = new SqlParameter();
                ParNroOT.ParameterName = "@NroOT";
                ParNroOT.SqlDbType = SqlDbType.Int;
                ParNroOT.Value = DetalleOT.NroOT;
                SqlCmd.Parameters.Add(ParNroOT);

                //Parametros ServicioNro
                SqlParameter ParServicioNro = new SqlParameter();
                ParServicioNro.ParameterName = "@ServicioNro";
                ParServicioNro.SqlDbType = SqlDbType.Int;
                ParServicioNro.Value = DetalleOT.ServicioNro;
                SqlCmd.Parameters.Add(ParServicioNro);

                //Parametro Comision del Servicio
                SqlParameter ParComision = new SqlParameter();
                ParComision.ParameterName = "@Comision";
                ParComision.SqlDbType = SqlDbType.Decimal;
                ParComision.Value = DetalleOT.Comision;
                SqlCmd.Parameters.Add(ParComision);

                //Parametro Ganancia
                SqlParameter ParGanancia = new SqlParameter();
                ParGanancia.ParameterName = "@Ganancia";
                ParGanancia.SqlDbType = SqlDbType.Decimal;
                ParGanancia.Value = DetalleOT.Ganancia;
                SqlCmd.Parameters.Add(ParGanancia);


                //Parametro UsuarioNro
                SqlParameter ParUsuarioNro = new SqlParameter();
                ParUsuarioNro.ParameterName = "@UsuarioNro";
                ParUsuarioNro.SqlDbType = SqlDbType.Int;
                ParUsuarioNro.Value = DetalleOT.UsuarioNro;
                SqlCmd.Parameters.Add(ParUsuarioNro);

                //Parametros de Precio
                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@Precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = DetalleOT.Precio;
                SqlCmd.Parameters.Add(ParPrecio);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se editó el registro";
        }
        catch (Exception ex)
        {
            rpta = ex.Message;
        }
        return rpta;
    }

  }

}
