using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPresentacion
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(string descripcion)
        {
            DPresentacion objPresentacion = new DPresentacion();
            objPresentacion.Descripcion = descripcion;
            return objPresentacion.InsertarPresentacion(objPresentacion);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(int idPresentacion, string descripcion)
        {
            DPresentacion objPresentacion = new DPresentacion();
            objPresentacion.IdPresentacion = idPresentacion;
            objPresentacion.Descripcion = descripcion;
            return objPresentacion.EditarPresentacion(objPresentacion);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int idPresentacion)
        {
            DPresentacion objPresentacion = new DPresentacion();
            objPresentacion.IdPresentacion = idPresentacion;
            return objPresentacion.EliminarPresentacion(objPresentacion);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {

            return new DPresentacion().MostrarPresentacion();
        }

        //Metodo para buscar que llama al metodo buscar de la capa Datos
        public static DataTable Buscar(string textoBuscar)
        {
            DPresentacion objPresentacion= new DPresentacion();
            objPresentacion.TextoBuscar = textoBuscar;
            return objPresentacion.BuscarPresentacion(objPresentacion);
        }


    }
}
