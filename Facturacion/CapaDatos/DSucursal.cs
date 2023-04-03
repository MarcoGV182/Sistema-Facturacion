using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DSucursal
    {
        private int _SucursalNro;
        private int _EmpresaNro;
        private string _Descripcion;
        private string _Direccion;

        public int SucursalNro
        {
            get
            {
                return _SucursalNro;
            }

            set
            {
                _SucursalNro = value;
            }
        }

        public int EmpresaNro
        {
            get
            {
                return _EmpresaNro;
            }

            set
            {
                _EmpresaNro = value;
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

        public string Direccion
        {
            get
            {
                return _Direccion;
            }

            set
            {
                _Direccion = value;
            }
        }



        public DSucursal() { }

        public DSucursal(int sucursalNro, int empresaNro, string descripcion, string direccion) 
        {
            this.SucursalNro = sucursalNro;
            this.EmpresaNro = empresaNro;
            this.Descripcion = descripcion;
            this.Direccion = direccion;
        }




        //Metodo insertar
        public string InsertarSucursal(DSucursal Sucursal)
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
                SqlCmd.CommandText = "sp_InsertarSucursal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros SucursalNro
                SqlParameter ParSucursalNro = new SqlParameter();
                ParSucursalNro.ParameterName = "@SucursalNro";
                ParSucursalNro.SqlDbType = SqlDbType.Int;
                ParSucursalNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParSucursalNro);


                //Parametros EmpresaNro
                SqlParameter ParEmpresaNro = new SqlParameter();
                ParEmpresaNro.ParameterName = "@EmpresaNro";
                ParEmpresaNro.SqlDbType = SqlDbType.Int;
                ParEmpresaNro.Value = Sucursal.EmpresaNro;
                SqlCmd.Parameters.Add(ParEmpresaNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 150;
                ParDescripcion.Value = Sucursal.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Parametros Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 150;
                ParDireccion.Value = Sucursal.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);
                

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";

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
        public string EditarSucursal(DSucursal Sucursal)
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
                SqlCmd.CommandText = "sp_EditarSucursal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros SucursalNro
                SqlParameter ParSucursalNro = new SqlParameter();
                ParSucursalNro.ParameterName = "@SucursalNro";
                ParSucursalNro.SqlDbType = SqlDbType.Int;
                ParSucursalNro.Value = Sucursal.SucursalNro;
                SqlCmd.Parameters.Add(ParSucursalNro);


                //Parametros EmpresaNro
                SqlParameter ParEmpresaNro = new SqlParameter();
                ParEmpresaNro.ParameterName = "@EmpresaNro";
                ParEmpresaNro.SqlDbType = SqlDbType.Int;
                ParEmpresaNro.Value = Sucursal.EmpresaNro;
                SqlCmd.Parameters.Add(ParEmpresaNro);

                //Parametros Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 150;
                ParDescripcion.Value = Sucursal.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Parametros Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 150;
                ParDireccion.Value = Sucursal.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

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

        //Metodo Eliminar
        public string EliminarSucursal(DSucursal Sucursal)
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
                SqlCmd.CommandText = "sp_EliminarSucursal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros SucursalNro
                SqlParameter ParSucursalNro = new SqlParameter();
                ParSucursalNro.ParameterName = "@SucursalNro";
                ParSucursalNro.SqlDbType = SqlDbType.Int;
                ParSucursalNro.Value =Sucursal.SucursalNro;
                SqlCmd.Parameters.Add(ParSucursalNro);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";

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
        public DataTable MostrarSucursal()
        {
            DataTable DtResultado = new DataTable("Sucursal");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarSucursal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

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
