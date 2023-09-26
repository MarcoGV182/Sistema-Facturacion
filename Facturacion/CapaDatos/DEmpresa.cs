using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaEntidades;

namespace CapaDatos
{
    public class DEmpresa:Conexion
    {
        public DEmpresa() { }
                
        //Metodo Insertar
        public string InsertarEmpresa(EEmpresa Empresa)
        {
            string rpta = "OK";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarEmpresa";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros EmpresaNro
                SqlParameter ParEmpresaNro = new SqlParameter();
                ParEmpresaNro.ParameterName = "@EmpresaNro";
                ParEmpresaNro.SqlDbType = SqlDbType.Int;
                ParEmpresaNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParEmpresaNro);

                //Parametros Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 150;
                ParNombre.Value = Empresa.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Parametros FechaInicio
                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@FechaInicio";
                ParFechaInicio.SqlDbType = SqlDbType.Date;
                ParFechaInicio.Value = Empresa.FechaInicio;
                SqlCmd.Parameters.Add(ParFechaInicio);


                //Parametros RUC
                SqlParameter ParRuc = new SqlParameter();
                ParRuc.ParameterName = "@RUC";
                ParRuc.SqlDbType = SqlDbType.VarChar;
                ParRuc.Size = 15;
                ParRuc.Value = Empresa.Ruc;
                SqlCmd.Parameters.Add(ParRuc);

                //Parametros Eslogan
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Value = Empresa.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Parametros Eslogan
                SqlParameter ParEslogan = new SqlParameter();
                ParEslogan.ParameterName = "@Eslogan";
                ParEslogan.SqlDbType = SqlDbType.VarChar;
                ParEslogan.Size = 250;
                ParEslogan.Value = Empresa.Slogan;
                SqlCmd.Parameters.Add(ParEslogan);

                //Parametros para el logo
                SqlParameter ParLogo = new SqlParameter();
                ParLogo.ParameterName = "@Logo";
                ParLogo.SqlDbType = SqlDbType.Image;
                ParLogo.Value = Empresa.Logo;
                SqlCmd.Parameters.Add(ParLogo);
                

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
        public string EditarEmpresa(EEmpresa Empresa)
        {
            string rpta = "";
            SqlConnection Sqlcon = null;
            try
            {
                //codigo
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EditarEmpresa";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros EmpresaNro
                SqlParameter ParEmpresaNro = new SqlParameter();
                ParEmpresaNro.ParameterName = "@EmpresaNro";
                ParEmpresaNro.SqlDbType = SqlDbType.Int;
                ParEmpresaNro.Value = Empresa.EmpresaNro;
                SqlCmd.Parameters.Add(ParEmpresaNro);

                //Parametros Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 150;
                ParNombre.Value = Empresa.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Parametros FechaInicio
                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@FechaInicio";
                ParFechaInicio.SqlDbType = SqlDbType.Date;
                ParFechaInicio.Value = Empresa.FechaInicio;
                SqlCmd.Parameters.Add(ParFechaInicio);


                //Parametros RUC
                SqlParameter ParRuc = new SqlParameter();
                ParRuc.ParameterName = "@RUC";
                ParRuc.SqlDbType = SqlDbType.VarChar;
                ParRuc.Size = 15;
                ParRuc.Value =Empresa.Ruc;
                SqlCmd.Parameters.Add(ParRuc);

                //Parametros Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Value = Empresa.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Parametros Eslogan
                SqlParameter ParEslogan = new SqlParameter();
                ParEslogan.ParameterName = "@Eslogan";
                ParEslogan.SqlDbType = SqlDbType.VarChar;
                ParEslogan.Size = 250;
                ParEslogan.Value = Empresa.Slogan;
                SqlCmd.Parameters.Add(ParEslogan);

                //Parametros para el logo
                SqlParameter ParLogo = new SqlParameter();
                ParLogo.ParameterName = "@Logo";
                ParLogo.SqlDbType = SqlDbType.Image;
                ParLogo.Value = Empresa.Logo;
                SqlCmd.Parameters.Add(ParLogo);
                

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el registro";

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



        //Metodo Mostrar
        public DataTable MostrarEmpresa()
        {
            DataTable DtResultado = new DataTable("Empresa");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarEmpresa";
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
