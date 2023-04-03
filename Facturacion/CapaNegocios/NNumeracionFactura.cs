using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class NNumeracionFactura
    {
        public static string Insertar(DNumeracionComprobante numeracionComprobante) 
        {
            DNumeracionComprobante obj = new DNumeracionComprobante();            
            return obj.InsertarNumeracion(numeracionComprobante);
        }

        public static string Editar(DNumeracionComprobante numeracionComprobante)
        {
            DNumeracionComprobante obj = new DNumeracionComprobante();           
            return obj.EditarNumeracion(numeracionComprobante);
        }

        public static string Eliminar(int id)
        {
            DNumeracionComprobante obj = new DNumeracionComprobante();
            obj.Id=id;
            return obj.EliminarNumeracion(obj);
        }


        public static DataTable Mostrar() 
        {
            DNumeracionComprobante obj = new DNumeracionComprobante();
            return obj.MostrarNumeracion();
        }

    }
}
