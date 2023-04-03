using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace CapaDatos
{
    public class DUsuarios
    {
        private int _PersonaNro;
        private string _Nombre;
        private string _Apellido;
        private string _usuario;
        private string _pass;
        public string passNew { get; set; }
        private int _TipoUserNro;
        private string _TextoBuscar;
        private string _Documento;
        private int _CiudadNro;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Estado;
        private string _Observacion;
        private DateTime? _FechaNacimiento;
        //private decimal? _Sueldo;
        //private int _ServicioNro;
        private string[] _ReglaUsuario;


        public int PersonaNro
        {
            get{return _PersonaNro;}
            set{_PersonaNro = value;}
        }

        public string Nombre
        {
            get{return _Nombre;}
            set{_Nombre = value;}
        }

        public string Apellido
        {
            get{return _Apellido;}
            set{_Apellido = value;}
        }

        public string Usuario
        {
            get{return _usuario;}
            set{_usuario = value;}
        }

        public string Pass
        {
            get{return _pass;}
            set{_pass = value;}
        }

        public int TipoUserNro
        {
            get{return _TipoUserNro;}
            set{_TipoUserNro = value;}
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        public string Documento
        {
            get
            {
                return _Documento;
            }

            set
            {
                _Documento = value;
            }
        }

        public int CiudadNro
        {
            get
            {
                return _CiudadNro;
            }

            set
            {
                _CiudadNro = value;
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

        public string Telefono
        {
            get
            {
                return _Telefono;
            }

            set
            {
                _Telefono = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }

        public string Estado
        {
            get
            {
                return _Estado;
            }

            set
            {
                _Estado = value;
            }
        }

        public DateTime? FechaNacimiento
        {
            get
            {
                return _FechaNacimiento;
            }

            set
            {
                _FechaNacimiento = value;
            }
        }

        public string Observacion
        {
            get
            {
                return _Observacion;
            }

            set
            {
                _Observacion = value;
            }
        }

        public string[] ReglaUsuario
        {
            get
            {
                return _ReglaUsuario;
            }

            set
            {
                _ReglaUsuario = value;
            }
        }        

        public DUsuarios() {

        }

        public DUsuarios(int personanro ,string nombre,string apellido, string usuario, string pass, int tipoUserNro,string textobuscar,string documento,int ciudadNro,string direccion,string telefono,string email,string estado,DateTime? fechaNacimiento ,string observacion,decimal? sueldo,decimal? porcentajecomision, string[] reglausuario) {
            this.PersonaNro = personanro;
            this.Nombre = nombre;
            this.Apellido = apellido;          
            this.Documento = documento;
            this.CiudadNro = ciudadNro;
            this.Direccion = direccion;
            this.Telefono=telefono;
            this.Email = email;
            this.Estado = estado;
            this.FechaNacimiento = fechaNacimiento;
            this.Observacion = observacion;
            this.Usuario = usuario;
            this.Pass = pass;
            this.TipoUserNro = tipoUserNro;
            this.TextoBuscar = textobuscar;            
            this.ReglaUsuario = reglausuario;
        }


        //Metodo Insertar
        public string InsertarUsuarios(DUsuarios Usuario)
        {
            //declarar variable respuesta
            string rpta = "OK";
            //instanciamos la conexion
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_InsertarUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Usuario.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Parametros Apellido
                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@Apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 100;
                ParApellido.Value = Usuario.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                //Parametros Documento
                SqlParameter ParDocumento = new SqlParameter();
                ParDocumento.ParameterName = "@documento";
                ParDocumento.SqlDbType = SqlDbType.VarChar;
                ParDocumento.Size = 10;
                ParDocumento.Value =Usuario.Documento;
                SqlCmd.Parameters.Add(ParDocumento);

                //Parametros Fecha Nacimiento
                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@fechaNacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Value = Usuario.FechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                //Parametros Ciudad
                SqlParameter ParCiudad = new SqlParameter();
                ParCiudad.ParameterName = "@CiudadNro";
                ParCiudad.SqlDbType = SqlDbType.Int;
                ParCiudad.Value = Usuario.CiudadNro;
                SqlCmd.Parameters.Add(ParCiudad);

                //Parametros Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 250;
                ParDireccion.Value = Usuario.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Parametros Telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = Usuario.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //Parametros Email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Usuario.Email;
                SqlCmd.Parameters.Add(ParEmail);

                //Parametros Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 8;
                ParEstado.Value = Usuario.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Parametros Observacion
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 250;
                ParObservacion.Value = Usuario.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                //Parametros Observacion
                SqlParameter ParUser= new SqlParameter();
                ParUser.ParameterName = "@Usuario";
                ParUser.SqlDbType = SqlDbType.VarChar;
                ParUser.Size = 250;
                ParUser.Value = Usuario.Usuario;
                SqlCmd.Parameters.Add(ParUser);

                //Parametros Observacion
                SqlParameter ParPass = new SqlParameter();
                ParPass.ParameterName = "@Pass";
                ParPass.SqlDbType = SqlDbType.VarChar;
                ParPass.Size = 250;
                ParPass.Value = Usuario.Pass;
                SqlCmd.Parameters.Add(ParPass);

                //Parametros Observacion
                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@TipoUserNro";
                ParAcceso.SqlDbType = SqlDbType.Int;
                ParAcceso.Value = Usuario.TipoUserNro;
                SqlCmd.Parameters.Add(ParAcceso);

                /*//Parametro de Salario
                SqlParameter ParSalario = new SqlParameter();
                ParSalario.ParameterName = "@Salario";
                ParSalario.SqlDbType = SqlDbType.Decimal;
                ParSalario.Value = Usuario.Sueldo;
                SqlCmd.Parameters.Add(ParSalario);*/


                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();
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
        public string EditarUsuario(DUsuarios Usuario)
        {
            //declarar variable respuesta
            string rpta = "";
            //instanciamos la conexion
            SqlConnection Sqlcon = new SqlConnection();
            SqlCommand SqlCmd = new SqlCommand();
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer el comando                
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EditarUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros 
                SqlParameter ParPersonaNro = new SqlParameter();
                ParPersonaNro.ParameterName = "@PersonaNro";
                ParPersonaNro.SqlDbType = SqlDbType.Int;
                ParPersonaNro.Value = Usuario.PersonaNro;
                SqlCmd.Parameters.Add(ParPersonaNro);

                //Parametros Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Usuario.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Parametros Apellido
                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@Apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 100;
                ParApellido.Value = Usuario.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                //Parametros Documento
                SqlParameter ParDocumento = new SqlParameter();
                ParDocumento.ParameterName = "@documento";
                ParDocumento.SqlDbType = SqlDbType.VarChar;
                ParDocumento.Size = 10;
                ParDocumento.Value = Usuario.Documento;
                SqlCmd.Parameters.Add(ParDocumento);

                //Parametros Fecha Nacimiento
                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@fechaNacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Value = Usuario.FechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                //Parametros Ciudad
                SqlParameter ParCiudad = new SqlParameter();
                ParCiudad.ParameterName = "@CiudadNro";
                ParCiudad.SqlDbType = SqlDbType.Int;
                ParCiudad.Value = Usuario.CiudadNro;
                SqlCmd.Parameters.Add(ParCiudad);

                //Parametros Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 250;
                ParDireccion.Value = Usuario.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Parametros Telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = Usuario.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //Parametros Email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Usuario.Email;
                SqlCmd.Parameters.Add(ParEmail);

                //Parametros Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 8;
                ParEstado.Value = Usuario.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Parametros Observacion
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 250;
                ParObservacion.Value = Usuario.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                //Parametros Observacion
                SqlParameter ParUser = new SqlParameter();
                ParUser.ParameterName = "@Usuario";
                ParUser.SqlDbType = SqlDbType.VarChar;
                ParUser.Size = 250;
                ParUser.Value = Usuario.Usuario;
                SqlCmd.Parameters.Add(ParUser);


                //Parametros Contraseña anterior
                SqlParameter ParPassAnterior = new SqlParameter();
                ParPassAnterior.ParameterName = "@OldPass";
                ParPassAnterior.SqlDbType = SqlDbType.VarChar;
                ParPassAnterior.Size = 50;
                ParPassAnterior.Value = Usuario.Pass;
                SqlCmd.Parameters.Add(ParPassAnterior);

                SqlParameter ParPassNuevo = new SqlParameter();
                ParPassNuevo.ParameterName = "@NewPass";
                ParPassNuevo.SqlDbType = SqlDbType.VarChar;
                ParPassNuevo.Size = 50;
                ParPassNuevo.Value = Usuario.passNew;
                SqlCmd.Parameters.Add(ParPassNuevo);

                //Parametros Observacion
                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@TipoUserNro";
                ParAcceso.SqlDbType = SqlDbType.Int;
                ParAcceso.Value = Usuario.TipoUserNro;
                SqlCmd.Parameters.Add(ParAcceso);

                /*//Parametro de Salario
                SqlParameter ParSalario = new SqlParameter();
                ParSalario.ParameterName = "@Salario";
                ParSalario.SqlDbType = SqlDbType.Decimal;
                ParSalario.Value = Usuario.Sueldo;
                SqlCmd.Parameters.Add(ParSalario);*/


                //ejecutar el comando sql                
                var i = SqlCmd.ExecuteNonQuery();
                if (i>0)
                    rpta = "OK";

            }
            catch (Exception ex)
            {   
                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon);
            }
            return rpta;
        }



        //Metodo Eliminar
        public string EliminarUsuario(DUsuarios Usuario)
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
                SqlCmd.CommandText = "sp_EliminarUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros TipoProductoNro
                SqlParameter ParUsuarioNro = new SqlParameter();
                ParUsuarioNro.ParameterName = "@UsuarioNro";
                ParUsuarioNro.SqlDbType = SqlDbType.Int;
                ParUsuarioNro.Value = Usuario.PersonaNro;
                SqlCmd.Parameters.Add(ParUsuarioNro);

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
        public DataTable MostrarUsuario()
        {
            DataTable DtResultado = new DataTable("Usuario");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarUsuario";
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
                Conexion.CerrarConexion(Sqlcon);
            }

            return DtResultado;
        }


        //Metodo Mostrar
        public DataTable MostrarUsuarioCombo()
        {
            DataTable DtResultado = new DataTable("Usuario");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarUsuarioCombo";
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



        //Metodo Mostrar
        public DataTable BuscarUsuario(DUsuarios usuario)
        {
            DataTable DtResultado = new DataTable("Usuario");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = usuario.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);



                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;

        }

        
        //Metodo Buscar
        public DataTable BuscarLogin(DUsuarios Usuarios)
        {
            DataTable DtResultado = new DataTable("Usuario");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_Login";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParUser = new SqlParameter();
                ParUser.ParameterName = "@Usuario";
                ParUser.SqlDbType = SqlDbType.VarChar;
                ParUser.Size = 50;
                ParUser.SqlValue = Usuarios.Usuario;
                SqlCmd.Parameters.Add(ParUser);

                //Parametros
                SqlParameter ParPass = new SqlParameter();
                ParPass.ParameterName = "@Pass";
                ParPass.SqlDbType = SqlDbType.VarChar;
                ParPass.Size = 50;
                ParPass.SqlValue = Usuarios.Pass;
                SqlCmd.Parameters.Add(ParPass);

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


        //Metodo Mostrar
        /*public DataTable Mostrar_UsuarioServicio(DUsuarios usuario)
        {
            DataTable DtResultado = new DataTable("Usuario");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_Mostrar_UsuarioServicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParServicioNro = new SqlParameter();
                ParServicioNro.ParameterName = "@ServicioNro";
                ParServicioNro.SqlDbType = SqlDbType.Int;
                ParServicioNro.Value = usuario.ServicioNro;
                SqlCmd.Parameters.Add(ParServicioNro);

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;

        }*/




        //METODO PARA VERIFICAR LOS PERMISO QUE POSEE EL USUARIO AL LOGUEARSE AL SISTEMA 
        public bool ReglasVerificar(string reglas_Usuario,string[]reglas) 
        {
            ReglaUsuario=reglas;
            string[] aReglas_Usuario_Formulario = reglas_Usuario.Split(',');
            foreach (var r in aReglas_Usuario_Formulario)
            {
                if(r!="" && reglas.Contains(r)) 
                {
                    return true;
                }
            }

            return false;
        }


    }
}
