﻿using System;
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

        public static string Insertar(DTimbrado timbrado,List<DNumeracionComprobante> ListaNumeracion)
        {
            DTimbrado obj = new DTimbrado();
            return obj.InsertarNumeracionTimbrado(timbrado, ListaNumeracion);
        }

        public static string Editar(DTimbrado timbrado, List<DNumeracionComprobante> ListaNumeracion)
        {
            DNumeracionComprobante obj = new DNumeracionComprobante();           
            return obj.EditarNumeracion(timbrado, ListaNumeracion);
        }

        public static string Eliminar(int id)
        {
            DNumeracionComprobante obj = new DNumeracionComprobante();
            obj.Id=id;
            return obj.EliminarNumeracion(obj);
        }


        public static DataTable Mostrar(int idTimbrado) 
        {
            DNumeracionComprobante obj = new DNumeracionComprobante();
            return obj.MostrarNumeracion(idTimbrado);
        }

    }
}
