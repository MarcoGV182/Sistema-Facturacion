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
    public class NEmpresa
    {
        public static string Insertar(EEmpresa empresa)
        {
            DEmpresa obj = new DEmpresa();            
            return obj.InsertarEmpresa(empresa);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(EEmpresa empresa)
        {
            DEmpresa obj = new DEmpresa();           
            return obj.EditarEmpresa(empresa);
        }


        public static DataTable Mostrar() 
        {
            DEmpresa obj = new DEmpresa();
            return obj.MostrarEmpresa();
        
        }


    }
}
