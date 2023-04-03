using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;


namespace CapaNegocio
{
    public class NUnidadMedida
    {
         public static string Insertar(string descripcion) {
            DUnidadMedida objUnidadMedida = new DUnidadMedida();
            objUnidadMedida.Descripcion = descripcion;
            return objUnidadMedida.InsertarUnidadMedida(objUnidadMedida);
        }


        public static string Editar(int UnidadMedidaNro,string descripcion) {
            DUnidadMedida objUnidadMedida = new DUnidadMedida();
            objUnidadMedida.UnidadMedidaNro = UnidadMedidaNro;
            objUnidadMedida.Descripcion = descripcion;
            return objUnidadMedida.EditarUnidadMedida(objUnidadMedida);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int UnidadMedidaNro)
        {
            DUnidadMedida objUnidadMedida = new DUnidadMedida();
            objUnidadMedida.UnidadMedidaNro = UnidadMedidaNro;
            return objUnidadMedida.EliminarUnidadMedida(objUnidadMedida);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            DUnidadMedida objUnidadMedida = new DUnidadMedida();
            return objUnidadMedida.MostrarUnidadMedida();
        }

        //Metodo para buscar que llama al metodo buscar de la capa Datos
        public static DataTable BuscarDescripcion(string textoBuscar)
        {
            DUnidadMedida objUnidadMedida = new DUnidadMedida();
            objUnidadMedida.TextoBuscar = textoBuscar;
            return objUnidadMedida.BuscarNombre(objUnidadMedida);
        }

    }
}
