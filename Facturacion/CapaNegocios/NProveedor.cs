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
    public class NProveedor
    {

        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(EProveedor proveedor)
        {
            DProveedor objProveedor = new DProveedor();
            return objProveedor.InsertarProveedor(proveedor);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(EProveedor proveedor)
        {
            DProveedor objProveedor = new DProveedor();           
            return objProveedor.EditarProveedor(proveedor);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int proveedornro)
        {
            DProveedor objProveedor = new DProveedor();
            return objProveedor.EliminarProveedor(proveedornro);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DProveedor().MostrarProveedor();
        }

        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable MostrarDeudaProveedor()
        {
            return new DProveedor().MostrarDeudaProveedor();
        }

        public static DataTable ObtenerDeudaProveedor(string textoBuscar)
        {        
            return new DProveedor().ObtenerDeudaProveedor(textoBuscar);
        }

        //Metodo para buscar que llama al metodo buscar por documento de la capa Datos
        public static DataTable BuscarDeudaProveedorDocumento(string textoBuscar)
        {
            DProveedor objProveeedor = new DProveedor();
            return objProveeedor.BuscarDeudaProveedorDocumento(textoBuscar);
        }


        //Metodo para buscar que llama al metodo buscar por documento de la capa Datos
        public static DataTable BuscarProveedor(string tipo,string textoBuscar)
        {
            DProveedor objProveedor = new DProveedor();  
            return objProveedor.BuscarProveedor(tipo, textoBuscar);
        }
    }
}
