using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NRegla
    {
        //INSERTAR FILA
        public static string Insertar(string nombre, string descripcion)
        {
            DOperacion obj = new DOperacion();
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            return obj.InsertarRegla(obj);
        }
        //EDITAR FILA
        public static string Editar(int Reglanro, string nombre, string descripcion)
        {
            DOperacion obj = new DOperacion();
            obj.IdOperacion = Reglanro;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            return obj.EditarRegla(obj);
        }


        //ELIMINAR FILA
        public static string Eliminar(int nroregla)
        {
            DOperacion obj = new DOperacion();
            obj.IdOperacion = nroregla;
            return obj.EliminarRegla(obj);
        }

        //MOSTRAR DATOS
        public static DataTable Mostrar()
        {
            DOperacion obj = new DOperacion();
            return obj.MostrarRegla();
        }




    }
}
