using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DGastos
    {
        private int _GastoNro;
        private string _NroDocumento;
        private DateTime _Fecha;
        private double _Importe;
        private int _NroTipoOperacion;
        private string _Descripcion;
        private int _Usuario;
        private int _FormaPagoNro;
        private string _Estado;
        private string _TextoBuscar; 

        public int GastoNro
        {
            get
            {
                return _GastoNro;
            }

            set
            {
                _GastoNro = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
            }
        }

        public double Importe
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

        public int NroTipoOperacion
        {
            get
            {
                return _NroTipoOperacion;
            }

            set
            {
                _NroTipoOperacion = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }

        public int Usuario
        {
            get
            {
                return _Usuario;
            }

            set
            {
                _Usuario = value;
            }
        }

        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }

            set
            {
                _TextoBuscar = value;
            }
        }

        public int FormaPagoNro
        {
            get
            {
                return _FormaPagoNro;
            }

            set
            {
                _FormaPagoNro = value;
            }
        }
       

        public string Estado
        {
            get
            {
                return _Estado;
            }

            set
            {
                _Estado = value;
            }
        }

        public string NroDocumento
        {
            get
            {
                return _NroDocumento;
            }

            set
            {
                _NroDocumento = value;
            }
        }

        public DGastos(){
        }


        public DGastos(int gastonro,string nrodocumento ,DateTime fecha, double importe, int nrotipooperacion,int formaPagonro,string estado , string descripcion, int usuario, string textobuscar) {
            this.GastoNro = gastonro;
            this.NroDocumento = nrodocumento;
            this.Fecha = fecha;
            this.Importe = importe;
            this.NroTipoOperacion = nrotipooperacion;
            this.FormaPagoNro = formaPagonro;
            this.Estado = estado;
            this.Descripcion = descripcion;
            this.Usuario = usuario;
            this.TextoBuscar = textobuscar; 
        }



        //Metodo insertar
        public string InsertarGasto(DGastos Gastos)
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
                SqlCmd.CommandText = "sp_InsertarGastos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParGastoNro = new SqlParameter();
                ParGastoNro.ParameterName = "@GastoNro";
                ParGastoNro.SqlDbType = SqlDbType.Int;
                ParGastoNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParGastoNro);

                //Parametros NroDocumento
                SqlParameter ParNroDocumento = new SqlParameter();
                ParNroDocumento.ParameterName = "@NroGasto";
                ParNroDocumento.SqlDbType = SqlDbType.VarChar;
                ParNroDocumento.Size = 20;
                ParNroDocumento.Value = Gastos.NroDocumento;
                SqlCmd.Parameters.Add(ParNroDocumento);

                //Parametros fecha
                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Gastos.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                //Parametros importe
                SqlParameter ParImporte = new SqlParameter();
                ParImporte.ParameterName = "@Importe";
                ParImporte.SqlDbType = SqlDbType.Money;
                ParImporte.Value = Gastos.Importe;
                SqlCmd.Parameters.Add(ParImporte);

                //Parametros CodTipo Gasto
                SqlParameter ParCodGasto = new SqlParameter();
                ParCodGasto.ParameterName = "@NroTipoOperacion";
                ParCodGasto.SqlDbType = SqlDbType.Int;
                ParCodGasto.Value = Gastos.NroTipoOperacion;
                SqlCmd.Parameters.Add(ParCodGasto);

                //Parametros FormaPago
                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@FormaPagoNro";
                ParFormaPago.SqlDbType = SqlDbType.Int;
                ParFormaPago.Value = Gastos.FormaPagoNro;
                SqlCmd.Parameters.Add(ParFormaPago);


                //Parametros Observacion
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Descripcion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 150;
                ParObservacion.Value = Gastos.Descripcion;
                SqlCmd.Parameters.Add(ParObservacion);


                //Parametros Usuario
                SqlParameter ParUsuario= new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.Int;
                ParUsuario.Value = Gastos.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);



                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se inserto el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon);
            }

            return rpta;


        }


        public string EditarGasto(DGastos Gastos)
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
                SqlCmd.CommandText = "sp_EditarGastos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParGastoNro = new SqlParameter();
                ParGastoNro.ParameterName = "@GastoNro";
                ParGastoNro.SqlDbType = SqlDbType.Int;
                ParGastoNro.Value = Gastos.GastoNro; 
                SqlCmd.Parameters.Add(ParGastoNro);

                //Parametros NroDocumento
                SqlParameter ParNroDocumento = new SqlParameter();
                ParNroDocumento.ParameterName = "@NroGasto";
                ParNroDocumento.SqlDbType = SqlDbType.VarChar;
                ParNroDocumento.Size = 20;
                ParNroDocumento.Value = Gastos.NroDocumento;
                SqlCmd.Parameters.Add(ParNroDocumento);

                //Parametros fecha
                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Gastos.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                //Parametros importe
                SqlParameter ParImporte = new SqlParameter();
                ParImporte.ParameterName = "@Importe";
                ParImporte.SqlDbType = SqlDbType.Money;
                ParImporte.Value = Gastos.Importe;
                SqlCmd.Parameters.Add(ParImporte);

                //Parametros CodTipo Gasto
                SqlParameter ParCodGasto = new SqlParameter();
                ParCodGasto.ParameterName = "@NroTipoOperacion";
                ParCodGasto.SqlDbType = SqlDbType.Int;
                ParCodGasto.Value = Gastos.NroTipoOperacion;
                SqlCmd.Parameters.Add(ParCodGasto);

                //Parametros FormaPago
                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@FormaPagoNro";
                ParFormaPago.SqlDbType = SqlDbType.Int;
                ParFormaPago.Value = Gastos.FormaPagoNro;
                SqlCmd.Parameters.Add(ParFormaPago);

                //Parametros Observacion
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Descripcion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 150;
                ParObservacion.Value = Gastos.Descripcion;
                SqlCmd.Parameters.Add(ParObservacion);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se edito el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon);
            }

            return rpta;


        }

        //Metodo Eliminar
        public string EliminarGasto(DGastos Gastos)
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
                SqlCmd.CommandText = "sp_EliminarGasto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParGastoNro = new SqlParameter();
                ParGastoNro.ParameterName = "@GastoNro";
                ParGastoNro.SqlDbType = SqlDbType.Int;
                ParGastoNro.Value = Gastos.GastoNro;
                SqlCmd.Parameters.Add(ParGastoNro);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";

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
        public DataTable MostrarGasto()
        {
            DataTable DtResultado = new DataTable("Gastos");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarGastos";
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


        //Metodo Buscar
        public DataTable BuscarNombre(DGastos Gastos)
        {
            DataTable DtResultado = new DataTable("Gastos");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarGastoNombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue = Gastos.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

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



        public DataTable BuscarGastoFecha(string FechaDesde, string FechaHasta, string Descripcion)
        {
            DataTable DtResultado = new DataTable("Gastos");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarGastoFiltro";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros1
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@FechaDesde";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.SqlValue = FechaDesde;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                //Parametro2
                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@FechaHasta";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 20;
                ParTextoBuscar2.SqlValue = FechaHasta;
                SqlCmd.Parameters.Add(ParTextoBuscar2);


                //Parametro2
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 150;
                ParDescripcion.SqlValue = Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);


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
                Conexion.CerrarConexion(Sqlcon);
            }

            return DtResultado;

        }


        //Metodo Mostrar
        public DataTable MostrarNumeracionGastos()
        {
            DataTable DtResultado = new DataTable("Gastos");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_CargarNumeracionGastos";
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
    }
}
