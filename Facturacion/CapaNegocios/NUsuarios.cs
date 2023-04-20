using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NUsuarios
    {
        public static string Insertar(DUsuarios usuario)
        {
            DUsuarios objUsuario = new DUsuarios();            
            return objUsuario.InsertarUsuarios(usuario);
        }



        public static string Editar(DUsuarios usuario)
        {
            DUsuarios objUsuario = new DUsuarios();           
            return objUsuario.EditarUsuario(usuario);
        }



        public static string Eliminar(int usuarionro) 
        {
            DUsuarios objUsuario = new DUsuarios();
            objUsuario.PersonaNro = usuarionro;
            return objUsuario.EliminarUsuario(objUsuario);
        }


        public static DataTable Buscar(string Usuario)
        {
            DUsuarios objUsuarios = new DUsuarios();
            objUsuarios.Usuario = Usuario;
            return objUsuarios.BuscarUsuario(objUsuarios);
        }



        //Metodo para buscar que llama al metodo buscar de la capa Datos
        public static DataTable BuscarLogin(string user, string pass)
        {
            DUsuarios objUsuarios = new DUsuarios();
            objUsuarios.Usuario = user;
            objUsuarios.Pass = pass;
            return objUsuarios.BuscarLogin(objUsuarios);
        }



        //METODO PARA VERIFICAR LOS PERMISO QUE POSEE EL USUARIO AL LOGUEARSE AL SISTEMA 
        public static bool VerificarPermisos(string permisos, string[]reglas) 
        {
            DUsuarios objUsuarios = new DUsuarios();
            //reglas=objUsuarios.ReglaUsuario;
            return objUsuarios.ReglasVerificar(permisos,reglas);
        }



    }
}
