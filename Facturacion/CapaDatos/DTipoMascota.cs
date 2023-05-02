using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Interfaces;

namespace CapaDatos
{
    public class DTipoMascota:Conexion,IGeneric<DTipoMascota>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }


        public string Insertar(DTipoMascota TipoMascota)
        {
            string rpta;
            SqlConnection SqlCon = null;
            try
            {
                SqlCon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Insert into TipoMascota(Descripcion)values(@Descripcion)";
                SqlCmd.CommandType = CommandType.Text;

                SqlCmd.Parameters.AddWithValue("@Descripcion", TipoMascota.Descripcion);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery()> 0 ? "Ok": throw new Exception("Ocurrio un error al insertar el registro");
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
        public string Editar(DTipoMascota TipoMascota)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "Update TipoMascota set Descripcion = @Descripcion where ID = @id";
                SqlCmd.CommandType = CommandType.Text;

                SqlCmd.Parameters.AddWithValue("@Descripcion", TipoMascota.Descripcion);
                SqlCmd.Parameters.AddWithValue("@id", TipoMascota.Id);

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
                SqlCmd.CommandText = "Delete from TipoMascota where id = @id";
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
            DataTable DtResultado = new DataTable("TipoMascota");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "Select Id,Descripcion from TipoMascota";
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
