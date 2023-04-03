using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NMarca
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(string descripcion)
        {
            DMarca objMarca = new DMarca();
            objMarca.Descripcion = descripcion;
            return objMarca.InsertarMarca(objMarca);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(DMarca marca)
        {
            DMarca objMarca = new DMarca();
            return objMarca.EditarMarca(marca);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int MarcaNro)
        {
            DMarca objMarca = new DMarca();
            objMarca.MarcaNro = MarcaNro;
            return objMarca.EliminarMarca(objMarca);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {   
            return new DMarca().MostrarMarca();
        }

        //Metodo para buscar que llama al metodo buscar de la capa Datos
        public static DataTable BuscarDescripcion(string textoBuscar)
        {
            DMarca objMarca = new DMarca();
            objMarca.TextoBuscar = textoBuscar;
            return objMarca.BuscarNombre(objMarca);
        }




    }
}
