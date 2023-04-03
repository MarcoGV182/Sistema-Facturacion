using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class NRetencion
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(DateTime fecharetencion, DateTime fechafactura, int personanro, string nrofactura, int tiporetencion, decimal importe)
        {
            DRetencion objRetencion = new DRetencion();
            objRetencion.FechaRetencion = fecharetencion;
            objRetencion.FechaFactura = fechafactura;
            objRetencion.PersonaNro = personanro;
            objRetencion.NroFactura = nrofactura;
            objRetencion.TipoRetencion = tiporetencion;
            objRetencion.Importe = importe;
            return objRetencion.InsertarRetencion(objRetencion);
        }


        public static DataTable Buscar(string nrofactura, int personanro) 
        {
            DRetencion obj = new DRetencion();
            obj.NroFactura = nrofactura;
            obj.PersonaNro = personanro;
            return obj.BuscarRetencion(obj);        
        }


        public static string Eliminar(int retencionnro) 
        {
            DRetencion obj = new DRetencion();
            obj.RetencionNro = retencionnro;
            return obj.Eliminar(obj);
        }



    }
}
