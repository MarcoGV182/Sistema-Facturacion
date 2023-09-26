using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using CapaEntidades;

namespace CapaDatos
{
    public class DNumeracionComprobante:Conexion
    {

        //Metodo Insertar
        public string InsertarNumeracion(ENumeracionComprobante numeracionComprobante, SqlConnection sqlExistente=null, SqlTransaction sqltranExistente=null)
        {
            //declarar variable respuesta
            string rpta = "OK";
            //instanciamos la conexion
            SqlConnection Sqlcon = null;
            SqlTransaction sqltran = null;
            try
            {
                //codigo
                Sqlcon = AbrirConexion(sqlExistente);
                sqltran = sqltranExistente == null ? Sqlcon.BeginTransaction() : sqltranExistente;
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = sqltran;
                SqlCmd.CommandText = "sp_InsertarNumeracionComprobante";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                #region Parametros
                //Parametros que recibe el procedimiento almacenado
                SqlParameter ParIdOut = new SqlParameter();
                ParIdOut.ParameterName = "@Id";
                ParIdOut.SqlDbType = SqlDbType.Int;
                ParIdOut.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdOut);
                             

                //Parametros que recibe el procedimiento almacenado
                SqlParameter ParIdNumeracion = new SqlParameter();
                ParIdNumeracion.ParameterName = "@IdNumeracion";
                ParIdNumeracion.SqlDbType = SqlDbType.Int;
                ParIdNumeracion.Value = numeracionComprobante.Id;
                SqlCmd.Parameters.Add(ParIdNumeracion);

                //Parametros 
                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@Establecimiento";
                ParSerie.SqlDbType = SqlDbType.Int;
                ParSerie.Value = numeracionComprobante.Establecimiento;
                SqlCmd.Parameters.Add(ParSerie);

                //Parametros 
                SqlParameter ParSucursal = new SqlParameter();
                ParSucursal.ParameterName = "@PuntoExpedicion";
                ParSucursal.SqlDbType = SqlDbType.Int;
                ParSucursal.Value = numeracionComprobante.PuntoExpedicion;
                SqlCmd.Parameters.Add(ParSucursal);

                //Parametros 
                SqlParameter ParNumeroDesde = new SqlParameter();
                ParNumeroDesde.ParameterName = "@NumeroDesde";
                ParNumeroDesde.SqlDbType = SqlDbType.Int;
                ParNumeroDesde.Value = numeracionComprobante.NumeroDesde;
                SqlCmd.Parameters.Add(ParNumeroDesde);

                SqlParameter ParNumeroHasta = new SqlParameter();
                ParNumeroHasta.ParameterName = "@NumeroHasta";
                ParNumeroHasta.SqlDbType = SqlDbType.Int;
                ParNumeroHasta.Value = numeracionComprobante.NumeroHasta;
                SqlCmd.Parameters.Add(ParNumeroHasta);

                //Parametros 
                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@TipoComprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 10;
                ParTipoComprobante.Value = numeracionComprobante.TipoComprobante;
                SqlCmd.Parameters.Add(ParTipoComprobante);


                //Parametros 
                SqlParameter ParTimbrado = new SqlParameter();
                ParTimbrado.ParameterName = "@Timbrado";
                ParTimbrado.SqlDbType = SqlDbType.Int;
                ParTimbrado.Value = numeracionComprobante.Timbrado.IdTimbrado;
                SqlCmd.Parameters.Add(ParTimbrado);


                //Parametros 
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Value = numeracionComprobante.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                #endregion

                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

                if (sqltranExistente == null)
                    sqltran.Commit();
            }
            catch (SqlException ex)
            {
                if (sqltranExistente == null)
                    sqltran.Rollback();
                rpta = ex.Message;
            }
            finally
            {
                CerrarConexion(Sqlcon, ref sqlExistente);
            }
            return rpta;
        }


        //Metodo Editar
        public string EditarNumeracion(ETimbrado timbrado, List<ENumeracionComprobante> Listanumeracion)
        {
            //declarar variable respuesta
            string rpta = "";
            //instanciamos la conexion
            SqlConnection Sqlcon = null;
            SqlTransaction Sqltran = null;
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                Sqltran = Sqlcon.BeginTransaction();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = Sqltran;
                SqlCmd.CommandText = "sp_EditarTimbrado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                #region Parametros
                //Parametros que recibe el procedimiento almacenado               
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@Id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = timbrado.IdTimbrado;
                SqlCmd.Parameters.Add(ParId);


                //Parametros 
                SqlParameter ParNroTimbrado = new SqlParameter();
                ParNroTimbrado.ParameterName = "@NroTimbrado";
                ParNroTimbrado.SqlDbType = SqlDbType.VarChar;
                ParNroTimbrado.Value = timbrado.NroTimbrado;
                SqlCmd.Parameters.Add(ParNroTimbrado);

                SqlParameter ParFechaInicioVigencia = new SqlParameter();
                ParFechaInicioVigencia.ParameterName = "@FechaInicioVigencia";
                ParFechaInicioVigencia.SqlDbType = SqlDbType.Date;
                ParFechaInicioVigencia.Value = timbrado.FechaInicioVigencia;
                SqlCmd.Parameters.Add(ParFechaInicioVigencia);

                SqlParameter ParFechaVencimiento = new SqlParameter();
                ParFechaVencimiento.ParameterName = "@FechaFinVigencia";
                ParFechaVencimiento.SqlDbType = SqlDbType.Date;
                ParFechaVencimiento.Value = timbrado.FechaFinVigencia;
                SqlCmd.Parameters.Add(ParFechaVencimiento);

                SqlParameter ParAutoimprenta = new SqlParameter();
                ParAutoimprenta.ParameterName = "@Ind_Autoimprenta";
                ParAutoimprenta.SqlDbType = SqlDbType.VarChar;
                ParAutoimprenta.Value = timbrado.Ind_Autoimprenta;
                SqlCmd.Parameters.Add(ParAutoimprenta);


                //Parametro Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Value = timbrado.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                #endregion

                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

                //Eliminar timbrados
                EliminarNumeracion(timbrado.IdTimbrado, Sqlcon, Sqltran);

                foreach (var item in Listanumeracion)
                {
                    DNumeracionComprobante num = new DNumeracionComprobante();
                    item.Timbrado.IdTimbrado = timbrado.IdTimbrado;
                    rpta = num.InsertarNumeracion(item, Sqlcon, Sqltran);

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }

                Sqltran.Commit();


            }
            catch (Exception ex)
            {
                Sqltran.Rollback();
                rpta = ex.Message;
            }
            finally
            {
                CerrarConexion(Sqlcon);
            }
            return rpta;
        }

        //Metodo eliminar
        public string EliminarNumeracion(int idNumeracionComprobante)
        {
            //declarar variable respuesta
            string rpta = "";
            //instanciamos la conexion
            SqlConnection Sqlcon = null;
            try
            {
                //codigo
                Sqlcon = AbrirConexion(Sqlcon);
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EliminarNumeracionComprobante";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que recibe el procedimiento almacenado
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@Id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = idNumeracionComprobante;
                SqlCmd.Parameters.Add(ParId);
               

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

        public string EliminarNumeracion(int idTimbrado, SqlConnection sqlExistente = null, SqlTransaction sqltranExistente = null)
        {
            //declarar variable respuesta
            string rpta = "OK";
            //instanciamos la conexion
            SqlConnection Sqlcon = null;
            SqlTransaction SqlTran = null;
            try
            {
                //codigo
                Sqlcon = AbrirConexion(sqlExistente);
                SqlTran = sqltranExistente == null ? Sqlcon.BeginTransaction() : sqltranExistente;
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = SqlTran;
                SqlCmd.CommandText = $"Delete from NumeracionComprobante where Timbrado = {idTimbrado}";
                SqlCmd.CommandType = CommandType.Text;

                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

                if (sqltranExistente == null)
                    SqlTran.Commit();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                if (sqltranExistente == null)
                    SqlTran.Rollback();

            }
            finally
            {
                CerrarConexion(Sqlcon, ref sqlExistente);
            }
            return rpta;
        }


        //Metodo Mostrar
        public DataTable MostrarNumeracion(int IdTimbrado)
        {
            DataTable DtResultado = new DataTable("Numeracion");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarNumeracionComprobante";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.CreateParameter();
                SqlCmd.Parameters.AddWithValue("@IdTimbrado", IdTimbrado);

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

    }
}
