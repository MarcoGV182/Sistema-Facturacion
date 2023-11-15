using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Runtime.CompilerServices;
using CapaEntidades;

namespace CapaNegocio
{
    public class NTipoUsuarioRegla
    {
        public static string Insertar(int idOperacion,int IdRol, string habilitado) 
        {

            ETipoUsuarioRegla eTipoUsuarioRegla = new ETipoUsuarioRegla();
            eTipoUsuarioRegla.Operacion = new EOperacion()
            {
                IdOperacion = idOperacion
            };
            eTipoUsuarioRegla.Rol = new ERol()
            {
                IdRol = IdRol
            };

            DTipoUsuarioRegla obj = new DTipoUsuarioRegla();
            return obj.InsertarTipoUsuarioRegla(eTipoUsuarioRegla, habilitado);
        }


        public static string Eliminar(int idRol)
        {
            DTipoUsuarioRegla obj = new DTipoUsuarioRegla();
            return obj.EliminarTipoUserRegla(idRol);
        }



        public static DataTable Mostrar(int Rol, int Modulo) 
        {
            ETipoUsuarioRegla eTipoUsuarioRegla = new ETipoUsuarioRegla();
            eTipoUsuarioRegla.Operacion = new EOperacion()
            {
                IdModulo = Modulo
            };
            eTipoUsuarioRegla.Rol = new ERol()
            {
                IdRol = Rol
            };


            DTipoUsuarioRegla obj = new DTipoUsuarioRegla();
            return obj.MostrarTipoUsuarioRegla(eTipoUsuarioRegla);
        }



        

    }
}
