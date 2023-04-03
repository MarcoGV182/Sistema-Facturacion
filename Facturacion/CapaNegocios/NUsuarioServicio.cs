using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NUsuarioServicio
    {
        public static string Insertar(int servicionro, int usuarionro)
        {
            DUsuarioServicio obj = new DUsuarioServicio();
            obj.ServicioNro = servicionro;
            obj.UsuarioNro = usuarionro;
            return obj.InsertarUsuarioServicio(obj);
        }


        public static string Eliminar(int usuarionro)
        {
            DUsuarioServicio obj = new DUsuarioServicio();
            obj.UsuarioNro = usuarionro;
            return obj.EliminarUsuarioServicio(obj);
        }



        public static DataTable Mostrar(int UsuarioNro)
        {
            DUsuarioServicio obj = new DUsuarioServicio();
            obj.UsuarioNro = UsuarioNro;
            return obj.MostrarUsuarioServicio(obj);
        }
    }
}
