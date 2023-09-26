using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class NBanco
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(string descripcion)
        {
            EBanco objBanco = new EBanco();
            objBanco.Descripcion = descripcion;
            return new DBanco().InsertarBanco(objBanco);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(int BancoNro, string descripcion)
        {
            EBanco objBanco = new EBanco();
            objBanco.BancoNro = BancoNro;
            objBanco.Descripcion = descripcion;
            return new DBanco().EditarBanco(objBanco);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int BancoNro)
        {
            DBanco objBanco = new DBanco();
            return objBanco.EliminarBanco(BancoNro);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DBanco().MostrarBanco();
        }
    }
}
