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
    public class NUnidadMedida
    {
         public static string Insertar(EUnidadMedida eUnidadMedida) {
            DUnidadMedida objUnidadMedida = new DUnidadMedida();
            return objUnidadMedida.InsertarUnidadMedida(eUnidadMedida);
        }


        public static string Editar(EUnidadMedida eUnidadMedida)
        {
            DUnidadMedida objUnidadMedida = new DUnidadMedida();
            return objUnidadMedida.EditarUnidadMedida(eUnidadMedida);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int UnidadMedidaNro)
        {
            DUnidadMedida objUnidadMedida = new DUnidadMedida();
            return objUnidadMedida.EliminarUnidadMedida(UnidadMedidaNro);
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
            return objUnidadMedida.BuscarNombre(textoBuscar);
        }

    }
}
