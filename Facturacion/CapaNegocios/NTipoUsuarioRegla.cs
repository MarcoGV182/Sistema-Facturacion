using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Runtime.CompilerServices;

namespace CapaNegocio
{
    public class NTipoUsuarioRegla
    {
        public static string Insertar(int idOperacion,int idRol, string habilitado) 
        {
            DTipoUsuarioRegla obj = new DTipoUsuarioRegla();
            obj.Operacion = new DOperacion() { IdOperacion = idOperacion };
            obj.Rol = new DRol() { IdRol = idRol };
            return obj.InsertarTipoUsuarioRegla(obj, habilitado);
        }


        public static string Eliminar(int idRol)
        {
            DTipoUsuarioRegla obj = new DTipoUsuarioRegla();            
            obj.Rol = new DRol() { IdRol = idRol };
            return obj.EliminarTipoUserRegla(obj);
        }



        public static DataTable Mostrar(int tipousernro,int idModulo) 
        {
            DTipoUsuarioRegla obj = new DTipoUsuarioRegla();
            obj.Rol =  new DRol(){ IdRol = tipousernro };
            obj.Operacion = new DOperacion() 
            { Modulo = new DModulo() 
                { IdModulo = idModulo }
            };
            return obj.MostrarTipoUsuarioRegla(obj);
        }



        

    }
}
