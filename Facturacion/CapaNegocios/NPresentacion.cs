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
    public class NPresentacion
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(EPresentacionProducto presentacionProducto)
        {
            DPresentacion objPresentacion = new DPresentacion();
            return objPresentacion.InsertarPresentacion(presentacionProducto);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(EPresentacionProducto presentacionProducto)
        {
            DPresentacion objPresentacion = new DPresentacion();
            return objPresentacion.EditarPresentacion(presentacionProducto);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int idPresentacion)
        {
            DPresentacion objPresentacion = new DPresentacion();
            return objPresentacion.EliminarPresentacion(idPresentacion);
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
            return objPresentacion.BuscarPresentacion(textoBuscar);
        }


    }
}
