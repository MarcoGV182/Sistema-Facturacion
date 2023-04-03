using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NTipoUsuario
    {
        //INSERTAR FILA
        public static string Insertar(DRol rol) {
            DRol obj = new DRol();
            return obj.InsertarTipoUsuario(rol);
        }
        //EDITAR FILA
        public static string Editar(DRol rol)
        {
            DRol obj = new DRol();
            return obj.EditarTipoUsuario(rol);
        }


        //ELIMINAR FILA
        public static string Eliminar(int tipousuarionro)
        {
            DRol obj = new DRol();
            obj.IdRol = tipousuarionro;
            return obj.EliminarTipoUsuario(obj);
        }

        //MOSTRAR DATOS
        public static DataTable Mostrar() 
        {
            DRol obj = new DRol();
            return obj.MostrarTipoUsuario();
        }



    }
}
