﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using CapaEntidades;

namespace CapaDatos
{
    public class DProveedor:Conexion
    {   
        public DProveedor()
        {

        }

        //Metodo insertar
        public string InsertarProveedor(EProveedor Proveedor)
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
                SqlCmd.CommandText = "sp_InsertarProveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParProveedorNro = new SqlParameter();
                ParProveedorNro.ParameterName = "@PersonaNro";
                ParProveedorNro.SqlDbType = SqlDbType.Int;
                ParProveedorNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParProveedorNro);


                //Parametros RUC
                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@idTipoDocumento";
                ParTipoDocumento.SqlDbType = SqlDbType.Int;
                ParTipoDocumento.Value = Proveedor.TipoDocumento.idTipoDocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);


                //Parametros RUC
                SqlParameter ParRUC = new SqlParameter();
                ParRUC.ParameterName = "@Documento";
                ParRUC.SqlDbType = SqlDbType.VarChar;
                ParRUC.Size = 20;
                ParRUC.Value = Proveedor.Documento;
                SqlCmd.Parameters.Add(ParRUC);

                //Parametros Ciudad
                SqlParameter ParCiudad = new SqlParameter();
                ParCiudad.ParameterName = "@CiudadNro";
                ParCiudad.SqlDbType = SqlDbType.Int;
                ParCiudad.Value = Proveedor.CiudadNro;
                SqlCmd.Parameters.Add(ParCiudad);

                //Parametros Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 250;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Parametros Telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //Parametros Email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);                

                // Parametros Representante
                 SqlParameter ParRazonSocial = new SqlParameter();
                ParRazonSocial.ParameterName = "@RazonSocial";
                ParRazonSocial.SqlDbType = SqlDbType.VarChar;
                ParRazonSocial.Size = 100;
                ParRazonSocial.Value = Proveedor.RazonSocial;
                SqlCmd.Parameters.Add(ParRazonSocial);

                // Parametros Representante
                SqlParameter ParFechaAniversario = new SqlParameter();
                ParFechaAniversario.ParameterName = "@FechaAniversario";
                ParFechaAniversario.SqlDbType = SqlDbType.DateTime;
                ParFechaAniversario.Value = Proveedor.FechaAniversario;
                SqlCmd.Parameters.Add(ParFechaAniversario);

                // Parametros Representante
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Value = Proveedor.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se inserto el registro";

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
        public string EditarProveedor(EProveedor Proveedor)
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
                SqlCmd.CommandText = "sp_EditarProveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParProveedorNro = new SqlParameter();
                ParProveedorNro.ParameterName = "@PersonaNro";
                ParProveedorNro.SqlDbType = SqlDbType.Int;
                ParProveedorNro.Value = Proveedor.PersonaNro;
                SqlCmd.Parameters.Add(ParProveedorNro);

                //Parametros Razon Social
                SqlParameter ParRazonSocial = new SqlParameter();
                ParRazonSocial.ParameterName = "@RazonSocial";
                ParRazonSocial.SqlDbType = SqlDbType.VarChar;
                ParRazonSocial.Size = 100;
                ParRazonSocial.Value = Proveedor.RazonSocial;
                SqlCmd.Parameters.Add(ParRazonSocial);


                //Parametros RUC
                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@idTipoDocumento";
                ParTipoDocumento.SqlDbType = SqlDbType.Int;
                ParTipoDocumento.Value = Proveedor.TipoDocumento.idTipoDocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                //Parametros RUC
                SqlParameter ParRUC = new SqlParameter();
                ParRUC.ParameterName = "@Documento";
                ParRUC.SqlDbType = SqlDbType.VarChar;
                ParRUC.Size = 20;
                ParRUC.Value = Proveedor.Documento;
                SqlCmd.Parameters.Add(ParRUC);

                //Parametros Ciudad
                SqlParameter ParCiudad = new SqlParameter();
                ParCiudad.ParameterName = "@CiudadNro";
                ParCiudad.SqlDbType = SqlDbType.Int;
                ParCiudad.Value = Proveedor.CiudadNro;
                SqlCmd.Parameters.Add(ParCiudad);

                //Parametros Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 250;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Parametros Telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //Parametros Email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                // Parametros Representante
                SqlParameter ParFechaAniversario = new SqlParameter();
                ParFechaAniversario.ParameterName = "@FechaAniversario";
                ParFechaAniversario.SqlDbType = SqlDbType.DateTime;
                ParFechaAniversario.Value = Proveedor.FechaAniversario;
                SqlCmd.Parameters.Add(ParFechaAniversario);

                // Parametros Representante
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Value = Proveedor.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se actualizo el registro";

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

        //Metodo Eliminar
        public string EliminarProveedor(int ProveedorId)
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
                SqlCmd.CommandText = "sp_EliminarProveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParProveedorNro = new SqlParameter();
                ParProveedorNro.ParameterName = "@ProveedorNro";
                ParProveedorNro.SqlDbType = SqlDbType.Int;
                ParProveedorNro.Value = ProveedorId;
                SqlCmd.Parameters.Add(ParProveedorNro);

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
        public DataTable MostrarProveedor()
        {
            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarProveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
                throw ex;
            }
            finally 
            {
                CerrarConexion(Sqlcon);
            }
            return DtResultado;

        }


        public DataTable BuscarProveedor(string tipoBusqueda,string textoBuscar)
        {
            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarProveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@Tipo";
                ParTipo.SqlDbType = SqlDbType.VarChar;
                ParTipo.SqlValue = tipoBusqueda;
                SqlCmd.Parameters.Add(ParTipo);

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.SqlValue = textoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

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
                CerrarConexion(Sqlcon);
            }

            return DtResultado;

        }


        //Metodo Mostrar
        public DataTable MostrarDeudaProveedor()
        {
            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarDeudaProveedor";
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


        public DataTable BuscarDeudaProveedorDocumento(string textoBuscar)
        {
            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarDeudaProveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue = textoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

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
                CerrarConexion(Sqlcon);
            }

            return DtResultado;

        }


        //Metodo Buscar deuda
        public DataTable ObtenerDeudaProveedor(string persona)
        {
            DataTable DtResultado = new DataTable("Deuda");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_ObtenerDeudaProveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@ProveedorNro";
                ParTextoBuscar.SqlDbType = SqlDbType.Int;
                ParTextoBuscar.SqlValue = persona;
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

    }
}
