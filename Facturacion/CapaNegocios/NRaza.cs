using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NRaza
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static int Insertar(string descripcion)
        {
            DRaza objRaza = new DRaza();
            objRaza.Descripcion = descripcion;
            return objRaza.Insertar(objRaza);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(DRaza marca)
        {
            DRaza objMarca = new DRaza();
            return objMarca.Editar(marca);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int MarcaNro)
        {
            DRaza objMarca = new DRaza();
            objMarca.Id = MarcaNro;
            return objMarca.Eliminar(objMarca);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DRaza().Mostrar();
        }
    }
}
