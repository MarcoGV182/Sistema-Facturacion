using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;


namespace CapaNegocio
{
    public class NTipoServicio
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(string descripcion)
        {
            DTipoServicio objTipoServicio = new DTipoServicio();
            objTipoServicio.Descripcion = descripcion;
            return objTipoServicio.InsertarTipoServicio(objTipoServicio);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(int tipoServicioNro, string descripcion)
        {
            DTipoServicio objTipoServicio= new DTipoServicio();
            objTipoServicio.TipoServicioNro = tipoServicioNro;
            objTipoServicio.Descripcion = descripcion;
            return objTipoServicio.EditarTipoServicio(objTipoServicio);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int tipoServicioNro)
        {
            DTipoServicio objTipoServicio = new DTipoServicio();
            objTipoServicio.TipoServicioNro = tipoServicioNro;
            return objTipoServicio.EliminarTipoServicio(objTipoServicio);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {

            return new DTipoServicio().MostrarTipoServicio();
        }

        //Metodo para buscar que llama al metodo buscar de la capa Datos
        public static DataTable BuscarDescripcion(string textoBuscar)
        {
            DTipoServicio objTipoServicio = new DTipoServicio();
            objTipoServicio.TextoBuscar = textoBuscar;
            return objTipoServicio.BuscarNombre(objTipoServicio);
        }
    }
}
