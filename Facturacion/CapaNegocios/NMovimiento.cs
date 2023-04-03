using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class NMovimiento
    {

        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DMovimiento().MostrarMovimiento();
        }

        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static DataTable BuscarFechaMovimiento(string textoBuscar1, string textoBuscar2)
        {
            DMovimiento objMovimiento = new DMovimiento();

            return objMovimiento.BuscarMovimiento(textoBuscar1, textoBuscar2);
        }


        public static DataTable BuscarFechaMovimientoCaja(string desde, string hasta)
        {
            DMovimiento objMovimiento = new DMovimiento();

            return objMovimiento.BuscarMovimientoCaja(desde, hasta);
        }


    }
}
