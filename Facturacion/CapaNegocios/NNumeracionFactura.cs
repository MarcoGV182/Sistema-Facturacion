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
    public class NNumeracionFactura
    {
        public static string Insertar(ENumeracionComprobante numeracionComprobante) 
        {
            DNumeracionComprobante obj = new DNumeracionComprobante();            
            return obj.InsertarNumeracion(numeracionComprobante);
        }

        public static string Insertar(ETimbrado timbrado,List<ENumeracionComprobante> ListaNumeracion)
        {
            DTimbrado obj = new DTimbrado();
            return obj.InsertarNumeracionTimbrado(timbrado, ListaNumeracion);
        }

        public static string Editar(ETimbrado timbrado, List<ENumeracionComprobante> ListaNumeracion)
        {
            DNumeracionComprobante obj = new DNumeracionComprobante();           
            return obj.EditarNumeracion(timbrado, ListaNumeracion);
        }

        public static string Eliminar(int id)
        {          
            return new DNumeracionComprobante().EliminarNumeracion(id);
        }


        public static DataTable Mostrar(int idTimbrado) 
        {
            DNumeracionComprobante obj = new DNumeracionComprobante();
            return obj.MostrarNumeracion(idTimbrado);
        }

    }
}
