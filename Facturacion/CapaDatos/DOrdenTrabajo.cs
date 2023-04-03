using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DOrdenTrabajo
    {
        private int _NroOT;
        private DateTime _Fecha;
        private int _ClienteNro;
        private string _Formula;
        private int? _Dias;
        private DateTime? _FechaVisita;
        private string _Observacion;
        private int _UsuarioInsercion;
        private string _NombreUsuario; 

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

        public int ClienteNro
        {
            get
            {
                return _ClienteNro;
            }

            set
            {
                _ClienteNro = value;
            }
        }

        public string Formula
        {
            get
            {
                return _Formula;
            }

            set
            {
                _Formula = value;
            }
        }

        public int? Dias
        {
            get
            {
                return _Dias;
            }

            set
            {
                _Dias = value;
            }
        }

        public DateTime? FechaVisita
        {
            get
            {
                return _FechaVisita;
            }

            set
            {
                _FechaVisita = value;
            }
        }

        public string Observacion
        {
            get
            {
                return _Observacion;
            }

            set
            {
                _Observacion = value;
            }
        }

        public int UsuarioInsercion
        {
            get
            {
                return _UsuarioInsercion;
            }

            set
            {
                _UsuarioInsercion = value;
            }
        }

        public string NombreUsuario
        {
            get
            {
                return _NombreUsuario;
            }

            set
            {
                _NombreUsuario = value;
            }
        }

        public DOrdenTrabajo() { }

        public DOrdenTrabajo(int nroOT,DateTime fecha,int clienteNro,string formula,int? dias,DateTime? fechavisita,string observacion,int usuarioinsercion, string nombreusuario) {
            this.NroOT = nroOT;
            this.Fecha = fecha;
            this.ClienteNro = clienteNro;
            this.Formula = formula;
            this.Dias = dias;
            this.FechaVisita = fechavisita;
            this.Observacion = observacion;
            this.UsuarioInsercion = usuarioinsercion;
            this.NombreUsuario = nombreusuario; 
        }



        //Metodo insertar
        public string InsertarOT(DOrdenTrabajo OT, List<DDetalleOrdenTrabajo> DetalleOT)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer la transaccion
                SqlTransaction Sqltran = Sqlcon.BeginTransaction();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = Sqltran;
                SqlCmd.CommandText = "sp_InsertarOrdenTrabajo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParNroOT = new SqlParameter();
                ParNroOT.ParameterName = "@NroOT";
                ParNroOT.SqlDbType = SqlDbType.Int;
                ParNroOT.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParNroOT);


                //Parametros Fecha OT
                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = OT.Fecha;
                SqlCmd.Parameters.Add(ParFecha);


                //Parametros 
                SqlParameter ParClienteNro= new SqlParameter();
                ParClienteNro.ParameterName = "@ClienteNro";
                ParClienteNro.SqlDbType = SqlDbType.Int;
                ParClienteNro.Value = OT.ClienteNro;
                SqlCmd.Parameters.Add(ParClienteNro);


                //Parametros Formula
                SqlParameter ParFormula = new SqlParameter();
                ParFormula.ParameterName = "@Formula";
                ParFormula.SqlDbType = SqlDbType.VarChar;
                ParFormula.Size = 100;
                ParFormula.Value = OT.Formula;
                SqlCmd.Parameters.Add(ParFormula);

                //Parametros Dias
                SqlParameter ParDias = new SqlParameter();
                ParDias.ParameterName = "@Dias";
                ParDias.SqlDbType = SqlDbType.Int;
                ParDias.Value = OT.Dias;
                SqlCmd.Parameters.Add(ParDias);

                //Parametros FechaVisita
                SqlParameter ParFechaVisita = new SqlParameter();
                ParFechaVisita.ParameterName = "@FechaProximaVisita";
                ParFechaVisita.SqlDbType = SqlDbType.Date;
                ParFechaVisita.Value = OT.FechaVisita;
                SqlCmd.Parameters.Add(ParFechaVisita);
                
                //Parametros Observacion
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 250;
                ParObservacion.Value = OT.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                //Parametros NroUsuario
                SqlParameter ParUsuarioInsercion = new SqlParameter();
                ParUsuarioInsercion.ParameterName = "@NroUsuarioInsercion";
                ParUsuarioInsercion.SqlDbType = SqlDbType.Int;
                ParUsuarioInsercion.Value = OT.UsuarioInsercion;
                SqlCmd.Parameters.Add(ParUsuarioInsercion);

                //Parametro NombreUsuario
                SqlParameter ParNombreUsuario = new SqlParameter();
                ParNombreUsuario.ParameterName = "@NombreUsuario";
                ParNombreUsuario.SqlDbType = SqlDbType.VarChar;
                ParNombreUsuario.Size = 50;
                ParNombreUsuario.Value = OT.NombreUsuario;
                SqlCmd.Parameters.Add(ParNombreUsuario); 
                 


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";

                if (rpta.Equals("OK"))
                {
                    //Obtener el NroCompra
                    this.NroOT = Convert.ToInt32(SqlCmd.Parameters["@NroOT"].Value);

                    foreach (DDetalleOrdenTrabajo det in DetalleOT)
                    {
                        det.NroOT = this.NroOT;
                        
                        //Llamar al metodo insertar
                        rpta = det.InsertarDetalleOT(det, ref Sqlcon, ref Sqltran);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }                        
                    }
                }
                if (rpta.Equals("OK"))
                {
                    Sqltran.Commit();
                }
                else
                {
                    Sqltran.Rollback();
                }

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


        //Metodo Editar
        public string EditarOT(DOrdenTrabajo OT, List<DDetalleOrdenTrabajo> DetalleOT)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer la transaccion
                SqlTransaction Sqltran = Sqlcon.BeginTransaction();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = Sqltran;
                SqlCmd.CommandText = "sp_EditarOrdenTrabajo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParNroOT = new SqlParameter();
                ParNroOT.ParameterName = "@NroOT";
                ParNroOT.SqlDbType = SqlDbType.Int;
                ParNroOT.Value = OT.NroOT;
                SqlCmd.Parameters.Add(ParNroOT);


                //Parametros Fecha OT
                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = OT.Fecha;
                SqlCmd.Parameters.Add(ParFecha);


                //Parametros 
                SqlParameter ParClienteNro = new SqlParameter();
                ParClienteNro.ParameterName = "@ClienteNro";
                ParClienteNro.SqlDbType = SqlDbType.Int;
                ParClienteNro.Value = OT.ClienteNro;
                SqlCmd.Parameters.Add(ParClienteNro);


                //Parametros Formula
                SqlParameter ParFormula = new SqlParameter();
                ParFormula.ParameterName = "@Formula";
                ParFormula.SqlDbType = SqlDbType.VarChar;
                ParFormula.Size = 100;
                ParFormula.Value = OT.Formula;
                SqlCmd.Parameters.Add(ParFormula);

                //Parametros Dias
                SqlParameter ParDias = new SqlParameter();
                ParDias.ParameterName = "@Dias";
                ParDias.SqlDbType = SqlDbType.Int;
                ParDias.Value = OT.Dias;
                SqlCmd.Parameters.Add(ParDias);

                //Parametros FechaVisita
                SqlParameter ParFechaVisita = new SqlParameter();
                ParFechaVisita.ParameterName = "@FechaProximaVisita";
                ParFechaVisita.SqlDbType = SqlDbType.Date;
                ParFechaVisita.Value = OT.FechaVisita;
                SqlCmd.Parameters.Add(ParFechaVisita);

                //Parametros Estado
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 250;
                ParObservacion.Value = OT.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se editó el registro";

                if (rpta.Equals("OK"))
                {
                    //Obtener el NroCompra
                    this.NroOT = Convert.ToInt32(SqlCmd.Parameters["@NroOT"].Value);

                    foreach (DDetalleOrdenTrabajo det in DetalleOT)
                    {
                        det.NroOT = this.NroOT;

                        //Llamar al metodo insertar
                        rpta = det.InsertarDetalleOT(det, ref Sqlcon, ref Sqltran);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
                if (rpta.Equals("OK"))
                {
                    Sqltran.Commit();
                }
                else
                {
                    Sqltran.Rollback();
                }

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





        //Metodo Anular
        public string EliminarOT(DOrdenTrabajo OT)
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
                SqlCmd.CommandText = "sp_EliminarOrdenTrabajo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParNroOT = new SqlParameter();
                ParNroOT.ParameterName = "@NroOT";
                ParNroOT.SqlDbType = SqlDbType.Int;
                ParNroOT.Value = OT.NroOT;
                SqlCmd.Parameters.Add(ParNroOT);



                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se eliminó el registro";

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



        //Metodo Buscar
        public DataTable BuscarOrdenTrabajo(string Textobuscar)
        {
            DataTable DtResultado = new DataTable("OT");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarOT";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue = Textobuscar;
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



        //Metodo Buscar
        public DataTable BuscarOTFecha(string fecha1,string fecha2)
        {
            DataTable DtResultado = new DataTable("OT");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarOTFecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParFecha1 = new SqlParameter();
                ParFecha1.ParameterName = "@fecha1";
                ParFecha1.SqlDbType = SqlDbType.VarChar;
                ParFecha1.Size = 20;
                ParFecha1.SqlValue = fecha1;
                SqlCmd.Parameters.Add(ParFecha1);

                //Parametros
                SqlParameter ParFecha2 = new SqlParameter();
                ParFecha2.ParameterName = "@fecha2";
                ParFecha2.SqlDbType = SqlDbType.VarChar;
                ParFecha2.Size = 20;
                ParFecha2.SqlValue = fecha2;
                SqlCmd.Parameters.Add(ParFecha2);



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



        //Metodo Mostrar
        public DataTable MostrarDetalleOT(int nrooT)
        {
            DataTable DtResultado = new DataTable("DetalleOrdenTrabajo");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarDetalleOrdenTrabajo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

            
                // Parametros
                SqlParameter ParNroOT = new SqlParameter();
                ParNroOT.ParameterName = "@NroOT";
                ParNroOT.SqlDbType = SqlDbType.Int;
                ParNroOT.SqlValue = NroOT;
                SqlCmd.Parameters.Add(ParNroOT);



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


        //Metodo Mostrar
        public DataTable MostrarOT()
        {
            DataTable DtResultado = new DataTable("OrdenTrabajo");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarOrdenTrabajo";
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


        //Metodo Mostrar
        public DataTable MostrarNumeracionOT()
        {
            DataTable DtResultado = new DataTable("OrdenTrabajo");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_CargarNumeracionOT";
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


        //Metodo Mostrar Cabecera de OT en la factura
        public DataTable MostrarCabOTFactura(string numeracion)
        {
            DataTable DtResultado = new DataTable("OrdenTrabajo");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarOrdenTrabajoFactura";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNumeracion = new SqlParameter();
                ParNumeracion.ParameterName = "@Numeracion";
                ParNumeracion.SqlDbType = SqlDbType.VarChar;
                ParNumeracion.Size = 6;
                ParNumeracion.Value = numeracion;
                SqlCmd.Parameters.Add(ParNumeracion);


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





        //Metodo Mostrar detalle de OT en la factura
        public DataTable MostrarOTFactura(string numeracion)
        {
            DataTable DtResultado = new DataTable("OrdenTrabajo");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarDetalleOrdenTrabajoFactura";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNumeracion = new SqlParameter();
                ParNumeracion.ParameterName = "@Numeracion";
                ParNumeracion.SqlDbType = SqlDbType.VarChar;
                ParNumeracion.Size = 6;
                ParNumeracion.Value = numeracion;
                SqlCmd.Parameters.Add(ParNumeracion);


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
