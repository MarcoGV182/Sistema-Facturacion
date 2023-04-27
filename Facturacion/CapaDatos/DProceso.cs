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
    public class DProceso:Conexion
    {
        private int _ProcesoNro;
        private string _Descripcion;
        private string _Mes;
        private DateTime _FechaInicio;
        private DateTime _FechaFin;
        private int _UsuarioNro;
        private char _Estado;

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

        public string Mes
        {
            get
            {
                return _Mes;
            }

            set
            {
                _Mes = value;
            }
        }

        public DateTime FechaInicio
        {
            get
            {
                return _FechaInicio;
            }

            set
            {
                _FechaInicio = value;
            }
        }

        public DateTime FechaFin
        {
            get
            {
                return _FechaFin;
            }

            set
            {
                _FechaFin = value;
            }
        }

        public char Estado
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

        public DProceso() { }
        public DProceso(int procesonro, string descripcion, string mes,DateTime fechainicio,DateTime fechafin, char estado, int usuarionro) 
        {
            this.ProcesoNro = procesonro;
            this.Descripcion = descripcion;
            this.Mes = mes;
            this.FechaInicio = fechainicio;
            this.FechaFin = fechafin;
            this.Estado = estado;
            this.UsuarioNro = usuarionro;
        }



        //Metodo insertar
        public string InsertarProceso(DProceso Proceso)
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
                SqlCmd.CommandText = "sp_InsertarProceso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size =100;
                ParDescripcion.Value = Proceso.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);


                //Parametros Mes
                SqlParameter ParMes = new SqlParameter();
                ParMes.ParameterName = "@Mes";
                ParMes.SqlDbType = SqlDbType.VarChar;
                ParMes.Size = 9;
                ParMes.Value = Proceso.Mes;
                SqlCmd.Parameters.Add(ParMes);


                //Parametro fecha Inicio
                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@FechaInicio";
                ParFechaInicio.SqlDbType = SqlDbType.DateTime;
                ParFechaInicio.Value = Proceso.FechaInicio;
                SqlCmd.Parameters.Add(ParFechaInicio);


                //Parametro fecha Fin
                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@FechaFin";
                ParFechaFin.SqlDbType = SqlDbType.DateTime;
                ParFechaFin.Value = Proceso.FechaFin;
                SqlCmd.Parameters.Add(ParFechaFin);

                //Parametro UsuarioNro
                SqlParameter ParUsuarioNro = new SqlParameter();
                ParUsuarioNro.ParameterName = "@UsuarioInsercion";
                ParUsuarioNro.SqlDbType = SqlDbType.Int;
                ParUsuarioNro.Value = Proceso.UsuarioNro;
                SqlCmd.Parameters.Add(ParUsuarioNro);


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

        //Metodo Editar
        public string EditarProceso(DProceso Proceso)
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
                SqlCmd.CommandText = "sp_EditarProceso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros NroProceso
                SqlParameter ParProcesoNro = new SqlParameter();
                ParProcesoNro.ParameterName = "@ProcesoNro";
                ParProcesoNro.SqlDbType = SqlDbType.Int;
                ParProcesoNro.Value = Proceso.ProcesoNro;
                SqlCmd.Parameters.Add(ParProcesoNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Proceso.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);


                //Parametros Mes
                SqlParameter ParMes = new SqlParameter();
                ParMes.ParameterName = "@Mes";
                ParMes.SqlDbType = SqlDbType.VarChar;
                ParMes.Size = 9;
                ParMes.Value = Proceso.Mes;
                SqlCmd.Parameters.Add(ParMes);


                //Parametro fecha Inicio
                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@FechaInicio";
                ParFechaInicio.SqlDbType = SqlDbType.DateTime;
                ParFechaInicio.Value = Proceso.FechaInicio;
                SqlCmd.Parameters.Add(ParFechaInicio);


                //Parametro fecha Fin
                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@FechaFin";
                ParFechaFin.SqlDbType = SqlDbType.DateTime;
                ParFechaFin.Value = Proceso.FechaFin;
                SqlCmd.Parameters.Add(ParFechaFin);

                //Parametro Estado
                /*SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Proceso.Estado;
                SqlCmd.Parameters.Add(ParEstado);*/

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el registro";

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
        public string EliminarProceso(DProceso Proceso)
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
                SqlCmd.CommandText = "sp_EliminarProceso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParProcesoNro = new SqlParameter();
                ParProcesoNro.ParameterName = "@ProcesoNro";
                ParProcesoNro.SqlDbType = SqlDbType.Int;
                ParProcesoNro.Value = Proceso.ProcesoNro;
                SqlCmd.Parameters.Add(ParProcesoNro);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se elimino el registro";

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
        public DataTable MostrarProceso(DProceso Proceso)
        {
            DataTable DtResultado = new DataTable("Proceso");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarProcesoEstado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //PARAMETRO ESTADO
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Proceso.Estado;
                SqlCmd.Parameters.Add(ParEstado);



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
        public DataTable MostrarServicioUsuario(DProceso Proceso)
        {
            DataTable DtResultado = new DataTable("Proceso");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarServiciosRealizadosUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros NroProceso
                SqlParameter ParProcesoNro = new SqlParameter();
                ParProcesoNro.ParameterName = "@ProcesoNro";
                ParProcesoNro.SqlDbType = SqlDbType.Int;
                ParProcesoNro.Value = Proceso.ProcesoNro;
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


        //Metodo Mostrar
        public DataTable BuscarServicioUsuario(DProceso Proceso)
        {
            DataTable DtResultado = new DataTable("Proceso");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarServiciosRealizadosUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros NroProceso
                SqlParameter ParProcesoNro = new SqlParameter();
                ParProcesoNro.ParameterName = "@ProcesoNro";
                ParProcesoNro.SqlDbType = SqlDbType.Int;
                ParProcesoNro.Value = Proceso.ProcesoNro;
                SqlCmd.Parameters.Add(ParProcesoNro);


                //Parametro UsuarioNro
                SqlParameter ParUsuarioNro = new SqlParameter();
                ParUsuarioNro.ParameterName = "@UsuarioNro";
                ParUsuarioNro.SqlDbType = SqlDbType.Int;
                ParUsuarioNro.Value = Proceso.UsuarioNro;
                SqlCmd.Parameters.Add(ParUsuarioNro);


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





        //Metodo Cerrar
        public string CerrarProceso(DProceso Proceso)
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
                SqlCmd.CommandText = "sp_CerrarProceso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParProcesoNro = new SqlParameter();
                ParProcesoNro.ParameterName = "@ProcesoNro";
                ParProcesoNro.SqlDbType = SqlDbType.Int;
                ParProcesoNro.Value = Proceso.ProcesoNro;
                SqlCmd.Parameters.Add(ParProcesoNro);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se cerró el proceso";

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

        //Metodo Abrir
        public string AbrirProceso(DProceso Proceso)
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
                SqlCmd.CommandText = "sp_AbrirProceso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParProcesoNro = new SqlParameter();
                ParProcesoNro.ParameterName = "@ProcesoNro";
                ParProcesoNro.SqlDbType = SqlDbType.Int;
                ParProcesoNro.Value = Proceso.ProcesoNro;
                SqlCmd.Parameters.Add(ParProcesoNro);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se abrió el proceso";

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
