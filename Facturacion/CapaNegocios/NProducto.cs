using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaNegocio
{
   public class NProducto
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(DProducto producto)
        {
            DProducto objProducto = new DProducto();            
            return objProducto.InsertarProducto(producto);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(DProducto producto)
        {
            DProducto objProducto = new DProducto();            
            return objProducto.EditarProducto(producto);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int productonro)
        {
            DProducto objProducto = new DProducto();
            objProducto.ProductoNro = productonro;
            return objProducto.EliminarProducto(objProducto);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public async static Task<DataTable> Mostrar()
        {
            return await new DProducto().MostrarProducto();
        }

        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable MostrarActivo()
        {
            return new DProducto().MostrarProductoActivo();
        }

        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static DataTable BuscarProducto(string textoBuscar)
        {
            DProducto objProducto = new DProducto();
            objProducto.TextoBuscar = textoBuscar;
            return objProducto.BuscarProducto(objProducto);
        }


        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static DataTable BuscarProductoActivo(string textoBuscar)
        {
            DProducto objProducto = new DProducto();
            objProducto.TextoBuscar = textoBuscar;
            return objProducto.BuscarProductoActivo(objProducto);
        }
    }
}
