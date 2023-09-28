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
    public class DAjuste:Conexion
    {
        public DAjuste() { }


        //Metodo insertar
        public string InsertarAjuste(EAjuste Ajuste, List<EDetalleAjuste> DetalleAjuste)
        {
            string rpta = "";
            SqlConnection Sqlcon = null;
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
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
                    Ajuste.CodAjuste = Convert.ToInt32(SqlCmd.Parameters["@CodAjuste"].Value);

                    foreach (EDetalleAjuste det in DetalleAjuste)
                    {
                        DDetalleAjuste dDetalleAjuste  = new DDetalleAjuste();
                        det.CodAjuste= Ajuste.CodAjuste;

                        //Llamar al metodo insertar
                        rpta = dDetalleAjuste.InsertarDetalleAjuste(det, ref Sqlcon, ref Sqltran);
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
        public DataTable BuscarFechas(DateTime Textobuscar1, DateTime TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("Ajuste");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarAjusteFechas";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@fecha1";
                ParTextoBuscar.SqlDbType = SqlDbType.DateTime;
                ParTextoBuscar.SqlValue = Textobuscar1;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                //Parametros
                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@fecha2";
                ParTextoBuscar2.SqlDbType = SqlDbType.DateTime;
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
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
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
                Sqlcon = AbrirConexion();
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
                Sqlcon = AbrirConexion();
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
        public string EliminarAjuste(int AjusteNro, SqlConnection SqlConExistente = null, SqlTransaction SqlTranExistente = null)
        {
            #region Variables
            string rpta = "";
            SqlConnection Sqlcon = null;
            SqlTransaction SqlTran = null;
            #endregion

            try
            {
                //codigo
                Sqlcon = AbrirConexion(SqlConExistente);
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
                ParCodAjuste.Value = AjusteNro;
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
                CerrarConexion(Sqlcon,ref SqlConExistente);
            }

            return rpta;

        }



        //Metodo Restaurar Stock
        public string RestaurarStock(int ajusteId,SqlConnection SqlConExistente = null, SqlTransaction SqlTranExistente = null)
        {
            string rpta = "OK";
            SqlConnection Sqlcon = null;
            SqlTransaction SqlTran = null;
            try
            {
                //codigo
                Sqlcon = AbrirConexion(SqlConExistente);
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
                ParCodAjuste.Value = ajusteId;
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
                CerrarConexion(Sqlcon, ref SqlConExistente);
            }

            return rpta;

        }


        public string EliminarAjusteRestaurar(int AjusteId) 
        {
            #region Variables
            string rpta = "OK";
            SqlConnection Sqlcon = null;
            SqlTransaction SqlTran = null;
            #endregion

            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                SqlTran = Sqlcon.BeginTransaction();

                //Restaurar Stock
                rpta = RestaurarStock(AjusteId, Sqlcon, SqlTran);
                if (rpta != "OK") 
                { throw new Exception(rpta); }

                //Eliminar Ajuste
                rpta = EliminarAjuste(AjusteId, Sqlcon, SqlTran);
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
                CerrarConexion(Sqlcon);
            }

            return rpta;
        }





    }
}
