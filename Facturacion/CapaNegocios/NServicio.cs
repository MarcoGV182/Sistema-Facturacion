using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NServicio
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(DServicio servicio)
        {
            DServicio objServicio = new DServicio();
            return objServicio.InsertarServicio(servicio);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(DServicio servicio)
        {
            DServicio objServicio = new DServicio();           
            return objServicio.EditarServicio(servicio);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int servicionro)
        {
            DServicio objServicio = new DServicio();
            objServicio.ServicioNro = servicionro;
            return objServicio.EliminarServicio(objServicio);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DServicio().MostrarServicio();
        }

        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static DataTable BuscarServicio(string textoBuscar)
        {
            DServicio objServicio = new DServicio();
            objServicio.TextoBuscar = textoBuscar;
            return objServicio.BuscarServicio(objServicio);
        }
    }
}
