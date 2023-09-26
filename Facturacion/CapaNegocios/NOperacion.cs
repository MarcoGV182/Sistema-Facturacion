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
    public class NOperacion
    {
        //INSERTAR FILA
        public static string Insertar(EOperacion eOperacion)
        {
            DOperacion obj = new DOperacion();
            return obj.InsertarRegla(eOperacion);
        }
        //EDITAR FILA
        public static string Editar(EOperacion eOperacion)
        {
            DOperacion obj = new DOperacion();           
            return obj.EditarRegla(eOperacion);
        }


        //ELIMINAR FILA
        public static string Eliminar(int nroreglaOperacion)
        {
            DOperacion obj = new DOperacion();
            return obj.EliminarRegla(nroreglaOperacion);
        }

        //MOSTRAR DATOS
        public static DataTable Mostrar()
        {
            DOperacion obj = new DOperacion();
            return obj.MostrarRegla();
        }




    }
}
