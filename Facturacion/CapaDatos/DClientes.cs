using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CapaDatos.Interfaces;

namespace CapaDatos
{
   public class DClientes : Conexion, IPersona
    {     
        public string TextoBuscar { get; set; }
        public int PersonaNro { get; set ; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public DTipoDocumento TipoDocumento { get; set; }       
        public int? CiudadNro { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Observacion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Edad { get => CalcularEdad(); }

        public DClientes() {

        }

        public DClientes(int clienteNro,string nombre,string apellido,string documento,DateTime? fechaNacimiento,int ciudadNro,string direccion,string telefono,string email,string observacion ,string textobuscar) {
            this.PersonaNro = clienteNro;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Documento = documento;
            this.FechaNacimiento = fechaNacimiento;
            this.CiudadNro = ciudadNro;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Observacion = observacion;
            this.TextoBuscar = textobuscar;
        }


        public string InsertarCliente(DClientes Cliente)
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
                SqlCmd.CommandText = "sp_InsertarClientes";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParClienteNro = new SqlParameter();
                ParClienteNro.ParameterName = "@PersonaNro";
                ParClienteNro.SqlDbType = SqlDbType.Int;
                ParClienteNro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParClienteNro);

                //Parametros Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Cliente.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Parametros Apellido
                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@Apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 100;
                ParApellido.Value = Cliente.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                //Parametros Documento
                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@idTipoDocumento";
                ParTipoDocumento.SqlDbType = SqlDbType.Int;
                ParTipoDocumento.Value = Cliente.TipoDocumento.idTipoDocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                //Parametros Documento
                SqlParameter ParDocumento = new SqlParameter();
                ParDocumento.ParameterName = "@documento";
                ParDocumento.SqlDbType = SqlDbType.VarChar;
                ParDocumento.Size = 10;
                ParDocumento.Value = Cliente.Documento;
                SqlCmd.Parameters.Add(ParDocumento);

                //Parametros Fecha Nacimiento
                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@fechaNacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Value = Cliente.FechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                //Parametros Ciudad
                SqlParameter ParCiudad = new SqlParameter();
                ParCiudad.ParameterName = "@CiudadNro";
                ParCiudad.SqlDbType = SqlDbType.Int;
                ParCiudad.Value = Cliente.CiudadNro;
                SqlCmd.Parameters.Add(ParCiudad);

                //Parametros Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 250;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Parametros Telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //Parametros Email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParEmail);
                

                //Parametros Observacion
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 250;
                ParObservacion.Value = Cliente.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";
               
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


        public string EditarCliente(DClientes Cliente)
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
                SqlCmd.CommandText = "sp_EditarClientes";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParClienteNro = new SqlParameter();
                ParClienteNro.ParameterName = "@PersonaNro";
                ParClienteNro.SqlDbType = SqlDbType.Int;
                ParClienteNro.Value = Cliente.PersonaNro;
                SqlCmd.Parameters.Add(ParClienteNro);

                //Parametros Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Cliente.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Parametros Apellido
                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@Apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 100;
                ParApellido.Value = Cliente.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                //Parametros Documento
                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@idTipoDocumento";
                ParTipoDocumento.SqlDbType = SqlDbType.Int;
                ParTipoDocumento.Value = Cliente.TipoDocumento.idTipoDocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                //Parametros Documento
                SqlParameter ParDocumento = new SqlParameter();
                ParDocumento.ParameterName = "@documento";
                ParDocumento.SqlDbType = SqlDbType.VarChar;
                ParDocumento.Size = 10;
                ParDocumento.Value = Cliente.Documento;
                SqlCmd.Parameters.Add(ParDocumento);

                //Parametros Fecha Nacimiento
                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@fechaNacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Value = Cliente.FechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                //Parametros Ciudad
                SqlParameter ParCiudad = new SqlParameter();
                ParCiudad.ParameterName = "@CiudadNro";
                ParCiudad.SqlDbType = SqlDbType.Int;
                ParCiudad.Value = Cliente.CiudadNro;
                SqlCmd.Parameters.Add(ParCiudad);

                //Parametros Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 250;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Parametros Telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //Parametros Email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParEmail);

                //Parametros Observacion
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 250;
                ParObservacion.Value = Cliente.Observacion;
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
                CerrarConexion(Sqlcon);
            }

            return rpta;
        }

        //Metodo Eliminar
        public string EliminarCliente(DClientes Cliente)
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
                SqlCmd.CommandText = "sp_EliminarClientes";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParClienteNro = new SqlParameter();
                ParClienteNro.ParameterName = "@PersonaNro";
                ParClienteNro.SqlDbType = SqlDbType.Int;
                ParClienteNro.Value = Cliente.PersonaNro;
                SqlCmd.Parameters.Add(ParClienteNro);

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
        public DataTable MostrarCliente()
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarClientes";
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

        

        //Metodo Mostrar en Combo box
        public DataTable MostrarClienteCombo(string textobuscar)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarClientesCombo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = textobuscar;

                SqlCmd.Parameters.Add(ParTextoBuscar);

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


        //MOSTRAR CLIENTE EN TEXTBOX SEGUN NUMERO DE DOCUMENTO
        public DataTable MostrarClienteTextBox(string textobuscar)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection Sqlcon =  null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarClientesTextBox";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = textobuscar;

                SqlCmd.Parameters.Add(ParTextoBuscar);



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


        //Metodo Mostrar los Clientes con factura a credito
        public DataTable MostrarDeudaCliente()
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarDeudaCliente";
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


        //Metodo Buscar
        public DataTable BuscarNombre(DClientes Cliente)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarClientesNombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue = Cliente.TextoBuscar;
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



        //Metodo Buscar por apellido
        public DataTable BuscarApellido(DClientes Cliente)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarClientesApellido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue = Cliente.TextoBuscar;
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
        

        public DataTable BuscarDocumento(DClientes Cliente)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarClientesDocumento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue = Cliente.TextoBuscar;
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


        public DataTable BuscarDeudaClienteDocumento(DClientes Cliente)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection Sqlcon = null;
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarDeudaCliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.SqlValue = Cliente.TextoBuscar;
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


        public string ImportarExcel(DClientes Cliente)
        {
            string rpta = "";
            SqlConnection Sqlcon = null;
            try
            {
                //abrimos la conexion
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "if not exists(Select * from Persona where Documento=@DOCUMENTO) INSERT INTO PERSONA(NOMBRE,APELLIDO,DOCUMENTO) VALUES(@NOMBRE,@APELLIDO,@DOCUMENTO)";
                SqlCmd.CommandType = CommandType.Text;

                SqlCmd.Parameters.AddWithValue("@DOCUMENTO", Cliente.Documento);
                SqlCmd.Parameters.AddWithValue("@NOMBRE", Cliente.Nombre);
                SqlCmd.Parameters.AddWithValue("@APELLIDO", Cliente.Apellido);
               

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";
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


        public string ImportarTexto(DClientes Cliente)
        {
            string rpta = "";
            SqlConnection Sqlcon = null;
            try
            {
                //abrimos la conexion
                Sqlcon = AbrirConexion();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "if not exists(Select * from Persona where Documento=@DOCUMENTO) INSERT INTO PERSONA(NOMBRE,APELLIDO,DOCUMENTO) VALUES(@NOMBRE,@APELLIDO,@DOCUMENTO)";
                SqlCmd.CommandType = CommandType.Text;

                SqlCmd.Parameters.AddWithValue("@DOCUMENTO", Cliente.Documento);
                SqlCmd.Parameters.AddWithValue("@NOMBRE", Cliente.Nombre);
                SqlCmd.Parameters.AddWithValue("@APELLIDO", Cliente.Apellido);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";
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


        public int CalcularEdad()
        {
            // Obtiene la fecha actual:
            DateTime fechaActual = DateTime.Today;

            
            if (FechaNacimiento.Value == null)
            {
                return 0;
            }

            // Comprueba que la se haya introducido una fecha válida; si 
            // la fecha de nacimiento es mayor a la fecha actual se muestra mensaje 
            // de advertencia:
            if (FechaNacimiento.Value > fechaActual)
            {
                return 0;
            }
            else
            {
                int edad = fechaActual.Year - FechaNacimiento.Value.Year;

                // Comprueba que el mes de la fecha de nacimiento es mayor 
                // que el mes de la fecha actual:
                if (FechaNacimiento.Value.Month > fechaActual.Month)
                {
                    --edad;
                }

                return edad;
            }
        }
    }
}
