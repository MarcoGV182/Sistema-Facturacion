using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DTimbrado:Conexion
    {

        public DTimbrado()
        {
            
        }


        //Metodo Insertar
        public int InsertarTimbrado(ETimbrado timbrado, 
                                   SqlConnection sqlExistente = null, 
                                   SqlTransaction sqltranExistente = null)
        {
            #region Variables
            int rpta = 0;
            SqlConnection Sqlcon = null;
            SqlTransaction sqltran = null;
            #endregion

            try
            {
                //codigo
                Sqlcon = AbrirConexion(sqlExistente);
                sqltran = sqltranExistente == null ? Sqlcon.BeginTransaction() : sqltranExistente;
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = sqltran;
                SqlCmd.CommandText = "sp_InsertarTimbrado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros que recibe el procedimiento almacenado
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@Id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Direction = ParameterDirection.Output;
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

                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();


                rpta = Convert.ToInt32(SqlCmd.Parameters["@Id"].Value);

                if (sqltranExistente == null)
                    sqltran.Commit();
            }
            catch (Exception ex)
            {
                if (sqltranExistente == null)
                    sqltran.Rollback();
                throw ex;
            }
            finally
            {
                CerrarConexion(Sqlcon, ref sqlExistente);
            }
            return rpta;
        }


        public string InsertarNumeracionTimbrado(ETimbrado timbrado, List<ENumeracionComprobante> Listanumeracion) 
        {
            #region Variables
            string rpta = "OK";
            SqlConnection Sqlcon = null;
            SqlTransaction sqltran = null;
            #endregion

            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                sqltran = Sqlcon.BeginTransaction() ;
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = sqltran;


                var idTimbrado = InsertarTimbrado(timbrado, Sqlcon, sqltran);

                if (idTimbrado == 0)
                    throw new Exception("El timbrado no fue");


                foreach (var item in Listanumeracion)
                {
                    DNumeracionComprobante num = new DNumeracionComprobante();                    
                    item.Timbrado.IdTimbrado = idTimbrado;
                    rpta = num.InsertarNumeracion(item, Sqlcon, sqltran);

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }

                sqltran.Commit();
            }
            catch (Exception ex)
            {                
                sqltran.Rollback();
                rpta = ex.Message;
            }
            finally
            {
                CerrarConexion(Sqlcon);
            }
            return rpta;


        }

        public DataTable ObtenerTimbrado()
        {
            DataTable DtResultado = new DataTable("Timbrado");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarTimbrado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

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
