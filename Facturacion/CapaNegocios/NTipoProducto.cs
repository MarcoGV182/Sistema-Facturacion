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
    public class NTipoProducto
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(string descripcion) {
            ETipoProducto objTipoProducto = new ETipoProducto();
            objTipoProducto.Descripcion= descripcion;
            return new DTipoProducto().InsertarTipoProducto(objTipoProducto);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(int tipoProductoNro, string descripcion)
        {
            ETipoProducto objTipoProducto = new ETipoProducto();
            objTipoProducto.TipoProductoNro = tipoProductoNro;
            objTipoProducto.Descripcion= descripcion;
            return new DTipoProducto().EditarTipoProducto(objTipoProducto);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int tipoProductoNro)
        {
            DTipoProducto objTipoProducto = new DTipoProducto();
            return objTipoProducto.EliminarTipoProducto(tipoProductoNro);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            
            return new DTipoProducto().MostrarTipoProducto();
        }

        //Metodo para buscar que llama al metodo buscar de la capa Datos
        public static DataTable BuscarDescripcion(string textoBuscar)
        {
            DTipoProducto objTipoProducto = new DTipoProducto();
            return objTipoProducto.BuscarNombre(textoBuscar);
        }

    }
}
