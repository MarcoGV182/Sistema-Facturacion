using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class DRetencion:Conexion
    {
        private int _RetencionNro;
        private string _NroRetencion;
        private DateTime _FechaRetencion;
        private DateTime _FechaFactura;
        private string _NroFactura;
        private int _PersonaNro;
        private int _TipoRetencion;
        private decimal _Importe;

        public int RetencionNro
        {
            get
            {
                return _RetencionNro;
            }

            set
            {
                _RetencionNro = value;
            }
        }

        public DateTime FechaRetencion
        {
            get
            {
                return _FechaRetencion;
            }

            set
            {
                _FechaRetencion = value;
            }
        }

        public DateTime FechaFactura
        {
            get
            {
                return _FechaFactura;
            }

            set
            {
                _FechaFactura = value;
            }
        }

        public string NroFactura
        {
            get
            {
                return _NroFactura;
            }

            set
            {
                _NroFactura = value;
            }
        }

        public int TipoRetencion
        {
            get
            {
                return _TipoRetencion;
            }

            set
            {
                _TipoRetencion = value;
            }
        }

        public decimal Importe
        {
            get
            {
                return _Importe;
            }

            set
            {
                _Importe = value;
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

        public string NroRetencion
        {
            get
            {
                return _NroRetencion;
            }

            set
            {
                _NroRetencion = value;
            }
        }

        public DRetencion() { }

        public DRetencion(int retencionnro,string nroretencion,DateTime fecharetencion, DateTime fechafactura, int personanro, int tiporetencion, string nrofactura, decimal importe) 
        {
            this.RetencionNro = retencionnro;
            this.NroRetencion = nroretencion;
            this.FechaFactura = fechafactura;
            this._FechaRetencion = fecharetencion;
            this.PersonaNro = personanro;
            this.TipoRetencion = tiporetencion;
            this.NroFactura = nrofactura;
            this.Importe = importe;
        }


        //Metodo insertar
        public string InsertarRetencion(DRetencion Retencion)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //abrimos la conexion
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarRetencion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParRetencionNro = new SqlParameter();
                ParRetencionNro.ParameterName = "@RetencionNro";
                ParRetencionNro.SqlDbType = SqlDbType.Int;
                ParRetencionNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParRetencionNro);

                //Parametros NroRetencion
                SqlParameter ParNroRetencion = new SqlParameter();
                ParNroRetencion.ParameterName = "@NroRetencion";
                ParNroRetencion.SqlDbType = SqlDbType.VarChar;
                ParNroRetencion.Size = 50;
                ParNroRetencion.Value = Retencion.NroRetencion;
                SqlCmd.Parameters.Add(ParNroRetencion);

                //Parametros Descripcion
                SqlParameter ParFechaRetencion = new SqlParameter();
                ParFechaRetencion.ParameterName = "@FechaRetencion";
                ParFechaRetencion.SqlDbType = SqlDbType.DateTime;
                ParFechaRetencion.Value = Retencion.FechaRetencion;
                SqlCmd.Parameters.Add(ParFechaRetencion);

                //Parametros Descripcion
                SqlParameter ParFechaFactura = new SqlParameter();
                ParFechaFactura.ParameterName = "@FechaFactura";
                ParFechaFactura.SqlDbType = SqlDbType.DateTime;
                ParFechaFactura.Value = Retencion.FechaFactura;
                SqlCmd.Parameters.Add(ParFechaFactura);

                //Parametros Descripcion
                SqlParameter ParNroFactura = new SqlParameter();
                ParNroFactura.ParameterName = "@NroFactura";
                ParNroFactura.SqlDbType = SqlDbType.VarChar;
                ParNroFactura.Size = 50;
                ParNroFactura.Value = Retencion.NroFactura;
                SqlCmd.Parameters.Add(ParNroFactura);


                //Parametros PersonaNro
                SqlParameter ParPersonaNro = new SqlParameter();
                ParPersonaNro.ParameterName = "@PersonaNro";
                ParPersonaNro.SqlDbType = SqlDbType.Int;
                ParPersonaNro.Value = Retencion.PersonaNro;
                SqlCmd.Parameters.Add(ParPersonaNro);


                //Parametros TipoRetencion
                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@TipoNro";
                ParTipo.SqlDbType = SqlDbType.Int;
                ParTipo.Value = Retencion.TipoRetencion;
                SqlCmd.Parameters.Add(ParTipo);


                //Parametros Importe
                SqlParameter ParImporte = new SqlParameter();
                ParImporte.ParameterName = "@Importe";
                ParImporte.SqlDbType = SqlDbType.Money;
                ParImporte.Value = Retencion.Importe;
                SqlCmd.Parameters.Add(ParImporte);



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


        //Metodo Mostrar
        public DataTable BuscarRetencion(DRetencion Retencion)
        {
            DataTable DtResultado = new DataTable("Retencion");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarRetencion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNroFactura = new SqlParameter();
                ParNroFactura.ParameterName = "@NroFactura";
                ParNroFactura.SqlDbType = SqlDbType.VarChar;
                ParNroFactura.Size = 50;
                ParNroFactura.Value = Retencion.NroFactura;
                SqlCmd.Parameters.Add(ParNroFactura);

                SqlParameter ParPersonanro = new SqlParameter();
                ParPersonanro.ParameterName = "@Personanro";
                ParPersonanro.SqlDbType = SqlDbType.Int;
                ParPersonanro.Value = Retencion.PersonaNro;
                SqlCmd.Parameters.Add(ParPersonanro);

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



        public string Eliminar(DRetencion Retencion) {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EliminarRetencion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParRetencionNro = new SqlParameter();
                ParRetencionNro.ParameterName = "@RetencionNro";
                ParRetencionNro.SqlDbType = SqlDbType.Int;
                ParRetencionNro.Value = Retencion.RetencionNro;
                SqlCmd.Parameters.Add(ParRetencionNro);

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
