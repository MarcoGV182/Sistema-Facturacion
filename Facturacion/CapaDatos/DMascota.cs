using CapaDatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DMascota:Conexion, IGeneric<DMascota>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DRaza Raza { get; set; }
        public DTipoMascota TipoMascota { get; set; }
        public DClientes Propietario { get; set; }
        public DSexoMascota sexo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Observacion { get; set; }


        public DMascota() { }

        public string Insertar(DMascota clase)
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
                SqlCmd.CommandText = @"Insert into Mascota(Nombre,idRaza,idTipoMascota,idPropietario,idSexo,FechaNacimiento,Observacion)
                                       values(@Nombre,@idRaza,@idTipoMascota,@idPropietario,@idSexo,@FechaNacimiento,@Observacion)";
                SqlCmd.CommandType = CommandType.Text;


                SqlCmd.Parameters.AddWithValue("@Nombre", clase.Nombre);
                SqlCmd.Parameters.AddWithValue("@idRaza", clase.Raza.Id);
                SqlCmd.Parameters.AddWithValue("@idTipoMascota", clase.TipoMascota.Id);
                SqlCmd.Parameters.AddWithValue("@idPropietario", clase.Propietario.PersonaNro);
                SqlCmd.Parameters.AddWithValue("@idSexo", clase.sexo.Id);
                SqlCmd.Parameters.AddWithValue("@FechaNacimiento", clase.FechaNacimiento.Value);
                SqlCmd.Parameters.AddWithValue("@Observacion", clase.Observacion);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() > 0 ? "OK" : "No se inserto el registro";

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

        public string Editar(DMascota clase)
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
                SqlCmd.CommandText = @"Update Mascota set Nombre = @Nombre,idRaza = @idRaza,idTipoMascota = @idTipoMascota, idPropietario = @idPropietario,idSexo = @idSexo,
                                       FechaNacimiento = @FechaNacimiento, Observacion = @Observacion where id = @id";
                SqlCmd.CommandType = CommandType.Text;

                SqlCmd.Parameters.AddWithValue("@id", clase.Id);
                SqlCmd.Parameters.AddWithValue("@Nombre", clase.Nombre);
                SqlCmd.Parameters.AddWithValue("@idRaza", clase.Raza.Id);
                SqlCmd.Parameters.AddWithValue("@idTipoMascota", clase.TipoMascota.Id);
                SqlCmd.Parameters.AddWithValue("@idPropietario", clase.Propietario.PersonaNro);
                SqlCmd.Parameters.AddWithValue("@idSexo", clase.sexo.Id);
                SqlCmd.Parameters.AddWithValue("@FechaNacimiento", clase.FechaNacimiento.Value);
                SqlCmd.Parameters.AddWithValue("@Observacion", clase.Observacion);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() > 0 ? "OK" : "No se inserto el registro";

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

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "Select m.id,m.Nombre,r.id idRaza,r.Descripcion Raza,p.PersonaNro idPropietario,Concat(p.Nombre,IIF(p.Apellido IS NOT NULL,','+p.Apellido,NULL)) NombreApellido,\r\n      s.id idSexo,s.Descripcion Sexo,tm.id idTipoMascota, tm.Descripcion TipoPropietario,m.FechaNacimiento,m.Observacion\r\nfrom Mascota m join TipoMascota tm on m.idTipoMascota = tm.id\r\n\t\t\t   join Persona p on m.idPropietario = p.PersonaNro\r\n\t\t       join Raza r on m.idRaza = r.id\r\n\t\t\t   join SexoMascota s on m.idSexo = s.id";
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

        public string Eliminar(int id)
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
                SqlCmd.CommandText = @"Delete from Mascota where id= @id";
                SqlCmd.CommandType = CommandType.Text;


                SqlCmd.Parameters.AddWithValue("@id", id);
                

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() > 0 ? "OK" : "No se eliminó el registro";

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
    }
}
