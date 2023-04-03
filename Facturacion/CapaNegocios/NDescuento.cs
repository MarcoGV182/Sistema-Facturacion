using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NDescuento
    {

        //INSERTAR FILA
        public static string Insertar(string descripcion)
        {
            DDescuento obj = new DDescuento();
            obj.Descripcion = descripcion;
            return obj.InsertarDescuento(obj);
        }
        //EDITAR FILA
        public static string Editar(int Descuentonro, string descripcion)
        {
            DDescuento obj = new DDescuento();
            obj.DescuentoNro = Descuentonro;
            obj.Descripcion = descripcion;
            return obj.EditarDescuento(obj);
        }


        //ELIMINAR FILA
        public static string Eliminar(int descuentonro)
        {
            DDescuento obj = new DDescuento();
            obj.DescuentoNro = descuentonro;
            return obj.EliminarDescuento(obj);
        }

        //MOSTRAR DATOS
        public static DataTable Mostrar()
        {
            DDescuento obj = new DDescuento();
            return obj.MostrarDescuento();
        }
    }
}
