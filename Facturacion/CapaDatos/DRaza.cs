﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Interfaces;

namespace CapaDatos
{
    public class DRaza:Conexion,IGeneric<DRaza>
    {   
        public int Id { get; set; }
        public string Descripcion { get; set; }



        public string Insertar(DRaza raza)
        {
            string rpta;
            SqlConnection SqlCon = null;
            try
            {
                SqlCon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Insert into Raza(Descripcion)values(@Descripcion)";
                SqlCmd.CommandType = CommandType.Text;

                SqlCmd.Parameters.AddWithValue("@Descripcion", raza.Descripcion);
                
                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery()> 0 ? "OK": throw new Exception("Ocurrio un error al insertar el registro");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion(SqlCon);
            }
            return rpta;
        }

        //Metodo Editar
        public string Editar(DRaza raza)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "Update Raza set Descripcion = @Descripcion where ID = @id";
                SqlCmd.CommandType = CommandType.Text;
                                
                SqlCmd.Parameters.AddWithValue("@Descripcion", raza.Descripcion);
                SqlCmd.Parameters.AddWithValue("@id", raza.Id);

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
        public string Eliminar(int id)
        {
            string rpta = "";
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "Delete from Raza where id = @id";
                SqlCmd.CommandType = CommandType.Text;

                SqlCmd.Parameters.AddWithValue("@id", id);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";

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
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Raza");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "Select Id,Descripcion from Raza";
                SqlCmd.CommandType = CommandType.Text;

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