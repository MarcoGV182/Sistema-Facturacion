using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NBanco
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(string descripcion)
        {
            DBanco objBanco = new DBanco();
            objBanco.Descripcion = descripcion;
            return objBanco.InsertarBanco(objBanco);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(int BancoNro, string descripcion)
        {
            DBanco objBanco = new DBanco();
            objBanco.BancoNro = BancoNro;
            objBanco.Descripcion = descripcion;
            return objBanco.EditarBanco(objBanco);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int BancoNro)
        {
            DBanco objBanco = new DBanco();
            objBanco.BancoNro = BancoNro;
            return objBanco.EliminarBanco(objBanco);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {

            return new DBanco().MostrarBanco();
        }

        //Metodo para buscar que llama al metodo buscar de la capa Datos
        public static DataTable BuscarDescripcion(string textoBuscar)
        {
            DBanco objBanco = new DBanco();
            objBanco.TextoBuscar = textoBuscar;
            return objBanco.BuscarNombre(objBanco);
        }



    }
}
