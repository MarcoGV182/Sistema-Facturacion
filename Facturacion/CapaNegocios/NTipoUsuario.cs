using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class NTipoUsuario
    {
        //INSERTAR FILA
        public static string Insertar(ERol rol) {
            DRol obj = new DRol();
            return obj.InsertarTipoUsuario(rol);
        }
        //EDITAR FILA
        public static string Editar(ERol rol)
        {
            DRol obj = new DRol();
            return obj.EditarTipoUsuario(rol);
        }


        //ELIMINAR FILA
        public static string Eliminar(int tipousuarionro)
        {
            DRol obj = new DRol();
            return obj.EliminarTipoUsuario(tipousuarionro);
        }

        //MOSTRAR DATOS
        public static DataTable Mostrar() 
        {
            DRol obj = new DRol();
            return obj.MostrarTipoUsuario();
        }



    }
}
