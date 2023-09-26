using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using CapaEntidades;

namespace CapaNegocio
{
    public class NUsuarios
    {
        public static string Insertar(EUsuario usuario)
        {
            DUsuarios objUsuario = new DUsuarios();   
            
            return objUsuario.InsertarUsuarios(usuario.PersonaNro,usuario.Login,usuario.Pass,usuario.TipoUserNro);
        }

        public static string Editar(EUsuario usuario)
        {
            DUsuarios objUsuario = new DUsuarios();           
            return objUsuario.EditarUsuario(usuario.PersonaNro, usuario.Login, usuario.Pass, usuario.passNew, usuario.TipoUserNro);
        }


        public static string Eliminar(int usuarionro) 
        {
            DUsuarios objUsuario = new DUsuarios();
            return objUsuario.EliminarUsuario(usuarionro);
        }


        public static DataTable Buscar(string Usuario)
        {
            DUsuarios objUsuarios = new DUsuarios();
            return objUsuarios.BuscarUsuario(Usuario);
        }



        //Metodo para buscar que llama al metodo buscar de la capa Datos
        public static DataTable BuscarLogin(string user, string pass)
        {
            DUsuarios objUsuarios = new DUsuarios();
            return objUsuarios.BuscarLogin(user, pass);
        }


        //METODO PARA VERIFICAR LOS PERMISO QUE POSEE EL USUARIO AL LOGUEARSE AL SISTEMA 
        public bool VerificarPermisos(string reglas_Usuario, string[] reglas)
        {
            string[] aReglas_Usuario_Formulario = reglas_Usuario.Split(',');
            foreach (var r in aReglas_Usuario_Formulario)
            {
                if (r != "" && reglas.Contains(r))
                {
                    return true;
                }
            }

            return false;
        }



    }
}
