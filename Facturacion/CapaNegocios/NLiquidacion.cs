using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NLiquidacion
    {
        public static string Insertar(int usuarionro,int procesonro,int descuentonro,int cantidad,decimal monto) 
        {
            DLiquidacion obj = new DLiquidacion();
            obj.UsuarioNro = usuarionro;
            obj.ProcesoNro = procesonro;
            obj.DescuentoNro = descuentonro;
            obj.Cantidad = cantidad;
            obj.Monto = monto;

            return obj.InsertarLiquidacion(obj);
        }

        public static string Generar(int procesonro)
        {
            DLiquidacion obj = new DLiquidacion();
            obj.ProcesoNro = procesonro;

            return obj.GenerarCabLiquidacion(obj);
        }




        public static DataTable Mostrar(int procesonro)
        {
            DLiquidacion obj = new DLiquidacion();
            obj.ProcesoNro = procesonro;
            return obj.Mostrar(obj);
        }


        public static string Eliminar(int procesonro,int usuarionro, int descuentonro)
        {
            DLiquidacion obj = new DLiquidacion();
            obj.ProcesoNro = procesonro;
            obj.UsuarioNro = usuarionro;
            obj.DescuentoNro = descuentonro;
            return obj.EliminarLiquidacion(obj);   
        }
    }
}
