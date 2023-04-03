﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DTimbrado
    {
        public int IdTimbrado { get; set; }
        public string NroTimbrado { get; set; }
        public string FechaInicioVigencia { get; set; }
        public string FechaFinVigencia { get; set; }
        public string Estado { get; set; }




        //Metodo Insertar
        public string InsertarTimbrado(DTimbrado timbrado, SqlConnection sqlExistente = null, SqlTransaction sqltranExistente = null)
        {
            #region Variables
            string rpta = "OK";
            SqlConnection Sqlcon = null;
            SqlTransaction sqltran = null;
            #endregion

            try
            {
                //codigo
                Sqlcon = Conexion.AbrirConexion(Conexion.CadenaConexion, sqlExistente);
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


                //Parametro Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Value = timbrado.Estado;
                SqlCmd.Parameters.Add(ParEstado);


                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

                if (sqltranExistente == null)
                    sqltran.Commit();
            }
            catch (Exception ex)
            {
                if (sqltranExistente == null)
                    sqltran.Rollback();
                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon, ref sqlExistente);
            }
            return rpta;
        }


        public string InsertarNumeracionTimbrado(DTimbrado timbrado,List<DNumeracionComprobante> Listanumeracion) 
        {
            #region Variables
            string rpta = "OK";
            SqlConnection Sqlcon = null;
            SqlTransaction sqltran = null;
            #endregion

            try
            {
                //codigo
                Sqlcon = Conexion.AbrirConexion(Conexion.CadenaConexion, null);
                sqltran = Sqlcon.BeginTransaction() ;
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = sqltran;


                rpta = InsertarTimbrado(timbrado, Sqlcon, sqltran);

                if (!rpta.Equals("OK"))
                    throw new Exception(rpta);


                foreach (var item in Listanumeracion)
                {
                    DNumeracionComprobante num = new DNumeracionComprobante();
                    num.InsertarNumeracion(item, Sqlcon, sqltran);
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
                Conexion.CerrarConexion(Sqlcon);
            }
            return rpta;


        }
    }
}
