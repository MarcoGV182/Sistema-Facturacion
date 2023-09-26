using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaDatos
{
    public class DColaborador : Conexion
    {

        public DColaborador()
        {
            
        }


        //Metodo Insertar
        public string InsertarColaborador(EColaborador colaborador)
        {
            //declarar variable respuesta
            string rpta = "OK";
            //instanciamos la conexion
            SqlConnection Sqlcon = null;
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarColaborador";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = colaborador.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Parametros Apellido
                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@Apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 100;
                ParApellido.Value = colaborador.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                //Parametros Documento
                SqlParameter ParDocumento = new SqlParameter();
                ParDocumento.ParameterName = "@documento";
                ParDocumento.SqlDbType = SqlDbType.VarChar;
                ParDocumento.Size = 10;
                ParDocumento.Value = colaborador.Documento;
                SqlCmd.Parameters.Add(ParDocumento);

                //Parametros Fecha Nacimiento
                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@fechaNacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.Date;
                ParFechaNacimiento.Value = colaborador.FechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                //Parametros Ciudad
                SqlParameter ParCiudad = new SqlParameter();
                ParCiudad.ParameterName = "@CiudadNro";
                ParCiudad.SqlDbType = SqlDbType.Int;
                ParCiudad.Value = colaborador.CiudadNro;
                SqlCmd.Parameters.Add(ParCiudad);

                //Parametros Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 250;
                ParDireccion.Value = colaborador.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Parametros Telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = colaborador.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //Parametros Email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = colaborador.Email;
                SqlCmd.Parameters.Add(ParEmail);

                //Parametros Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 8;
                ParEstado.Value = colaborador.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Parametros Observacion
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 250;
                ParObservacion.Value = colaborador.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                SqlParameter ParFechaIngreso = new SqlParameter();
                ParFechaIngreso.ParameterName = "@FechaIngreso";
                ParFechaIngreso.SqlDbType = SqlDbType.Date;
                ParFechaIngreso.Value = colaborador.FechaIngreso;
                SqlCmd.Parameters.Add(ParFechaIngreso);

                
                SqlParameter ParFechaEgreso = new SqlParameter();
                ParFechaEgreso.ParameterName = "@FechaEgreso";
                ParFechaEgreso.SqlDbType = SqlDbType.Date;
                ParFechaEgreso.Value = colaborador.FechaEgreso;
                SqlCmd.Parameters.Add(ParFechaEgreso);

                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();
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
        public string EditarColaborador(EColaborador colaborador)
        {
            //declarar variable respuesta
            string rpta = "OK";
            //instanciamos la conexion
            SqlConnection Sqlcon = null;
            SqlCommand SqlCmd = new SqlCommand();
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando                
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = Sqlcon.BeginTransaction();
                SqlCmd.CommandText = "sp_EditarColaborador";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros 
                SqlParameter ParPersonaNro = new SqlParameter();
                ParPersonaNro.ParameterName = "@PersonaNro";
                ParPersonaNro.SqlDbType = SqlDbType.Int;
                ParPersonaNro.Value = colaborador.PersonaNro;
                SqlCmd.Parameters.Add(ParPersonaNro);

                //Parametros Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = colaborador.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Parametros Apellido
                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@Apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 100;
                ParApellido.Value = colaborador.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                //Parametros Documento
                SqlParameter ParDocumento = new SqlParameter();
                ParDocumento.ParameterName = "@documento";
                ParDocumento.SqlDbType = SqlDbType.VarChar;
                ParDocumento.Size = 10;
                ParDocumento.Value = colaborador.Documento;
                SqlCmd.Parameters.Add(ParDocumento);

                //Parametros Fecha Nacimiento
                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@fechaNacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Value = colaborador.FechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                //Parametros Ciudad
                SqlParameter ParCiudad = new SqlParameter();
                ParCiudad.ParameterName = "@CiudadNro";
                ParCiudad.SqlDbType = SqlDbType.Int;
                ParCiudad.Value = colaborador.CiudadNro;
                SqlCmd.Parameters.Add(ParCiudad);

                //Parametros Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 250;
                ParDireccion.Value = colaborador.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Parametros Telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = colaborador.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //Parametros Email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = colaborador.Email;
                SqlCmd.Parameters.Add(ParEmail);

                //Parametros Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 1;
                ParEstado.Value = colaborador.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Parametros Observacion
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 250;
                ParObservacion.Value = colaborador.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                SqlParameter ParFechaIngreso = new SqlParameter();
                ParFechaIngreso.ParameterName = "@FechaIngreso";
                ParFechaIngreso.SqlDbType = SqlDbType.Date;
                ParFechaIngreso.Value = colaborador.FechaIngreso;
                SqlCmd.Parameters.Add(ParFechaIngreso);


                SqlParameter ParFechaEgreso = new SqlParameter();
                ParFechaEgreso.ParameterName = "@FechaEgreso";
                ParFechaEgreso.SqlDbType = SqlDbType.Date;
                ParFechaEgreso.Value = colaborador.FechaEgreso;
                SqlCmd.Parameters.Add(ParFechaEgreso);


                //ejecutar el comando sql                
                SqlCmd.ExecuteNonQuery();
                SqlCmd.Transaction.Commit();

            }
            catch (Exception ex)
            {
                SqlCmd.Transaction.Rollback();
                rpta = ex.Message;
            }
            finally
            {
                CerrarConexion(Sqlcon);
            }
            return rpta;
        }


        //Metodo Mostrar
        public DataTable MostrarColaborador(int? idUsuario)
        {
            DataTable DtResultado = new DataTable("Usuario");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.AddWithValue("@UsuarioNro", idUsuario);

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


        public DataTable MostrarListaColaboradorActivo()
        {
            DataTable DtResultado = new DataTable("Colaborador");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarListaColaboradorActivo";
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
    }




}
