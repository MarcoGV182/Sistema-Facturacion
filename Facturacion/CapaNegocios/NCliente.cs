using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;
using System.Data.SqlClient;

namespace CapaNegocio
{
   public class NCliente
    {

        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(DClientes clientes)
        {
            DClientes objClientes = new DClientes();
            return objClientes.InsertarCliente(clientes);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(DClientes clientes)
        {
            DClientes objClientes = new DClientes();
            return objClientes.EditarCliente(clientes);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int clientenro)
        {
            DClientes objClientes = new DClientes();
            objClientes.PersonaNro = clientenro;
            return objClientes.EliminarCliente(objClientes);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DClientes().MostrarCliente();
        }

        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable MostrarCombo(string textobuscar)
        {
            return new DClientes().MostrarClienteCombo(textobuscar);
        }



        //Metodo para mostrar que llama al metodo mostrar en TexTbox de la capa Datos
        public static DataTable MostrarTextbox(string textobuscar)
        {
            return new DClientes().MostrarClienteTextBox(textobuscar);
        }


        
        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable MostrarDeudaCliente()
        {
            return new DClientes().MostrarDeudaCliente();
        }



        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static DataTable BuscarNombre(string textoBuscar)
        {
            DClientes objClientes = new DClientes();
            objClientes.TextoBuscar = textoBuscar;
            return objClientes.BuscarNombre(objClientes);
        }


        //Metodo para buscar que llama al metodo buscar por Apellido de la capa Datos
        public static DataTable BuscarApellido(string textoBuscar)
        {
            DClientes objClientes = new DClientes();
            objClientes.TextoBuscar = textoBuscar;
            return objClientes.BuscarApellido(objClientes);
        }


        
        


        //Metodo para buscar que llama al metodo buscar por documento de la capa Datos
        public static DataTable BuscarDocumento(string textoBuscar)
        {
            DClientes objClientes = new DClientes();
            objClientes.TextoBuscar = textoBuscar;
            return objClientes.BuscarDocumento(objClientes);
        }

        //Metodo para buscar que llama al metodo buscar por documento de la capa Datos
        public static DataTable BuscarDeudaClienteDocumento(string textoBuscar)
        {
            DClientes objClientes = new DClientes();
            objClientes.TextoBuscar = textoBuscar;
            return objClientes.BuscarDeudaClienteDocumento(objClientes);
        }


       



        public static string ImportarExcel(string nombre, string apellido, string documento)
        {
            DClientes objClientes = new DClientes();
            objClientes.Nombre = nombre;
            objClientes.Apellido = apellido;
            objClientes.Documento = documento;
           return objClientes.ImportarExcel(objClientes);
        }

        public static string ImportarTexto(string nombre, string apellido, string documento)
        {
            DClientes objClientes = new DClientes();
            objClientes.Nombre = nombre;
            objClientes.Apellido = apellido;
            objClientes.Documento = documento;
            return objClientes.ImportarTexto(objClientes);
        }



    }
}
