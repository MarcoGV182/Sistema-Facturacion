using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCiudad
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(string descripcion)
        {
            DCiudad objCiudad = new DCiudad();
            objCiudad.Descripcion = descripcion;
            return objCiudad.InsertarCiudad(objCiudad);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(int CiudadNro, string descripcion)
        {
            DCiudad objCiudad = new DCiudad();
            objCiudad.CiudadNro = CiudadNro;
            objCiudad.Descripcion = descripcion;
            return objCiudad.EditarCiudad(objCiudad);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int CiudadNro)
        {
            DCiudad objCiudad = new DCiudad();
            objCiudad.CiudadNro = CiudadNro;
            return objCiudad.EliminarCiudad(objCiudad);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DCiudad().MostrarCiudad();
        }

        //Metodo para buscar que llama al metodo buscar de la capa Datos
        public static DataTable BuscarDescripcion(string textoBuscar)
        {
            DCiudad objCiudad = new DCiudad();
            objCiudad.TextoBuscar = textoBuscar;
            return objCiudad.BuscarNombre(objCiudad);
        }
    }
}
