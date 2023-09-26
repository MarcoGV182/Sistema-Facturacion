using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaNegocio
{
   public class NCliente
    {

        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(ECliente clientes)
        {
            DCliente objClientes = new DCliente();
            return objClientes.InsertarCliente(clientes);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(ECliente clientes)
        {
            DCliente objClientes = new DCliente();
            return objClientes.EditarCliente(clientes);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int clientenro)
        {
            DCliente objClientes = new DCliente();
            return objClientes.EliminarCliente(clientenro);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DCliente().MostrarCliente();
        }

        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable MostrarCombo(string textobuscar)
        {
            return new DCliente().MostrarClienteCombo(textobuscar);
        }



        //Metodo para mostrar que llama al metodo mostrar en TexTbox de la capa Datos
        public static DataTable MostrarTextbox(string textobuscar)
        {
            return new DCliente().MostrarClienteTextBox(textobuscar);
        }


        
        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable MostrarDeudaCliente()
        {
            return new DCliente().MostrarDeudaCliente();
        }



        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static DataTable BuscarNombre(string textoBuscar)
        {
            DCliente objClientes = new DCliente();
            return objClientes.BuscarNombre(textoBuscar);
        }


        //Metodo para buscar que llama al metodo buscar por Apellido de la capa Datos
        public static DataTable BuscarApellido(string textoBuscar)
        {
            DCliente objClientes = new DCliente();
            return objClientes.BuscarApellido(textoBuscar);
        }        


        //Metodo para buscar que llama al metodo buscar por documento de la capa Datos
        public static DataTable BuscarDocumento(string textoBuscar)
        {
            DCliente objClientes = new DCliente();
            return objClientes.BuscarDocumento(textoBuscar);
        }

        //Metodo para buscar que llama al metodo buscar por documento de la capa Datos
        public static DataTable BuscarDeudaClienteDocumento(string textoBuscar)
        {
            DCliente objClientes = new DCliente();
            return objClientes.BuscarDeudaClienteDocumento(textoBuscar);
        }

        public static string ImportarExcel(ECliente cliente)
        {
            DCliente objClientes = new DCliente();
           return objClientes.ImportarExcel(cliente);
        }

        public static string ImportarTexto(ECliente cliente)
        {
            DCliente objClientes = new DCliente();
            return objClientes.ImportarTexto(cliente);
        }


    }
}
