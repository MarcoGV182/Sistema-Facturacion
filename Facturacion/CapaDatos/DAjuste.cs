using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DAjuste
    {
        private int _CodAjuste;
        private string _Descripcion;
        private DateTime _FechaHora;
        private string _Estado;
        private string _Observacion;
        private int _TipoAjusteNro;
        private string usuario;

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

        public DateTime FechaHora
        {
            get
            {
                return _FechaHora;
            }

            set
            {
                _FechaHora = value;
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

        public int TipoAjusteNro
        {
            get
            {
                return _TipoAjusteNro;
            }

            set
            {
                _TipoAjusteNro = value;
            }
        }

        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public DAjuste() { }

        public DAjuste(int codajuste,string descripcion,DateTime fechahora,string estado,string observacion,int tipoajusteNro,string usuario) {
            this.CodAjuste = codajuste;
            this.Descripcion = descripcion;
            this.FechaHora = fechahora;
            this.Estado = estado;
            this.Observacion = observacion;
            this.TipoAjusteNro = tipoajusteNro;
            this.usuario = usuario;
         }


        //Metodo insertar
        public string InsertarAjuste(DAjuste Ajuste, List<DDetalleAjuste> DetalleAjuste)
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
                SqlCmd.CommandText = "sp_InsertarAjuste";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParCodAjuste = new SqlParameter();
                ParCodAjuste.ParameterName = "@CodAjuste";
                ParCodAjuste.SqlDbType = SqlDbType.Int;
                ParCodAjuste.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParCodAjuste);


                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 200;
                ParDescripcion.Value = Ajuste.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);                

                
                //Parametros Fecha Compra
                SqlParameter ParFechaAjuste = new SqlParameter();
                ParFechaAjuste.ParameterName = "@FechaHora";
                ParFechaAjuste.SqlDbType = SqlDbType.DateTime;
                ParFechaAjuste.Value = Ajuste.FechaHora;
                SqlCmd.Parameters.Add(ParFechaAjuste);

                //Parametros Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 9;
                ParEstado.Value = Ajuste.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Parametros Estado
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 256;
                ParObservacion.Value = Ajuste.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                //Parametros 
                SqlParameter ParTipoAjuste = new SqlParameter();
                ParTipoAjuste.ParameterName = "@TipoAjusteNro";
                ParTipoAjuste.SqlDbType = SqlDbType.Int;
                ParTipoAjuste.Value = Ajuste.TipoAjusteNro;
                SqlCmd.Parameters.Add(ParTipoAjuste);


                //Parametros usuario
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Ajuste.usuario;
                SqlCmd.Parameters.Add(ParUsuario);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";

                if (rpta.Equals("OK"))
                {
                    //Obtener el NroCompra
                    this.CodAjuste = Convert.ToInt32(SqlCmd.Parameters["@CodAjuste"].Value);

                    foreach (DDetalleAjuste det in DetalleAjuste)
                    {
                        det.CodAjuste= this.CodAjuste;

                        //Llamar al metodo insertar
                        rpta = det.InsertarDetalleAjuste(det, ref Sqlcon, ref Sqltran);
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



        //Metodo Buscar
        public DataTable BuscarFechas(string Textobuscar1, string TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("Ajuste");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarAjusteFechas";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@fecha1";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue = Textobuscar1;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                //Parametros
                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@fecha2";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 50;
                ParTextoBuscar2.SqlValue = TextoBuscar2;
                SqlCmd.Parameters.Add(ParTextoBuscar2);

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
        public DataTable MostrarDetalleAjuste(int CodAjuste)
        {
            DataTable DtResultado = new DataTable("DetalleAjuste");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarDetalleAjuste";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.Int;
                //ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue =CodAjuste;
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


        //Metodo Mostrar
        public DataTable MostrarAjuste()
        {
            DataTable DtResultado = new DataTable("Ajuste");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarAjuste";
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
        public DataTable MostrarNumeracionAjuste()
        {
            DataTable DtResultado = new DataTable("Ajuste");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_CargarNumeracionAjuste";
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


        //Metodo Eliminar
        public string EliminarAjuste(DAjuste ajuste, SqlConnection SqlConExistente = null, SqlTransaction SqlTranExistente = null)
        {
            #region Variables
            string rpta = "";
            SqlConnection Sqlcon = null;
            SqlTransaction SqlTran = null;
            #endregion

            try
            {
                //codigo
                Sqlcon = Conexion.AbrirConexion(Conexion.CadenaConexion, SqlConExistente);
                SqlTran = SqlTranExistente ?? Sqlcon.BeginTransaction();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = SqlTran;
                SqlCmd.CommandText = "sp_EliminarAjuste";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParCodAjuste = new SqlParameter();
                ParCodAjuste.ParameterName = "@AjusteNro";
                ParCodAjuste.SqlDbType = SqlDbType.Int;
                ParCodAjuste.Value = ajuste.CodAjuste;
                SqlCmd.Parameters.Add(ParCodAjuste);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 2 ? "OK" : "No se elimino el registro";

                if (!rpta.Equals("OK"))
                    throw new Exception(rpta);

                if (SqlTranExistente == null)
                    SqlTran.Commit();
               
            }
            catch (Exception ex)
            {
                if (SqlTranExistente == null)
                    SqlTran.Rollback();

                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon,ref SqlConExistente);
            }

            return rpta;

        }



        //Metodo Restaurar Stock
        public string RestaurarStock(DAjuste ajuste,SqlConnection SqlConExistente = null, SqlTransaction SqlTranExistente = null)
        {
            string rpta = "OK";
            SqlConnection Sqlcon = null;
            SqlTransaction SqlTran = null;
            try
            {
                //codigo
                Sqlcon = Conexion.AbrirConexion(Conexion.CadenaConexion, SqlConExistente);
                SqlTran = SqlTranExistente == null ? Sqlcon.BeginTransaction() : SqlTranExistente;
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = SqlTran;
                SqlCmd.CommandText = "sp_RestaurarStockAjuste";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParCodAjuste = new SqlParameter();
                ParCodAjuste.ParameterName = "@CodAjuste";
                ParCodAjuste.SqlDbType = SqlDbType.Int;
                ParCodAjuste.Value = ajuste.CodAjuste;
                SqlCmd.Parameters.Add(ParCodAjuste);

                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

                if (SqlTranExistente == null)
                    SqlTran.Commit();
            }
            catch (Exception ex)
            {
                if (SqlTranExistente == null)
                    SqlTran.Rollback();
                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon, ref SqlConExistente);
            }

            return rpta;

        }


        public string EliminarAjusteRestaurar(DAjuste ajuste) 
        {
            #region Variables
            string rpta = "OK";
            SqlConnection Sqlcon = null;
            SqlTransaction SqlTran = null;
            #endregion

            try
            {
                //codigo
                Sqlcon = Conexion.AbrirConexion(Conexion.CadenaConexion);
                SqlTran = Sqlcon.BeginTransaction();

                //Restaurar Stock
                rpta = RestaurarStock(ajuste, Sqlcon, SqlTran);
                if (rpta != "OK") 
                { throw new Exception(rpta); }

                //Eliminar Ajuste
                rpta = EliminarAjuste(ajuste, Sqlcon, SqlTran);
                if (rpta != "OK")
                { throw new Exception(rpta); }


                SqlTran.Commit();
            }
            catch (Exception ex)
            {   
                SqlTran.Rollback();
                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon);
            }

            return rpta;
        }





    }
}
