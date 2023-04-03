using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NTipoAjuste
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(string descripcion, string positivonegativo)
        {
            DTipoAjuste objTipoAjuste = new DTipoAjuste();
            objTipoAjuste.Descripcion = descripcion;
            objTipoAjuste.PositivoNegativo = positivonegativo;
            return objTipoAjuste.InsertarTipoAjuste(objTipoAjuste);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(int tipoajustenro ,string descripcion, string positivonegativo)
        {
            DTipoAjuste objTipoAjuste = new DTipoAjuste();
            objTipoAjuste.TipoAjusteNro = tipoajustenro;
            objTipoAjuste.Descripcion= descripcion;
            objTipoAjuste.PositivoNegativo = positivonegativo;            
            return objTipoAjuste.EditarTipoAjuste(objTipoAjuste);
        }


        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Eliminar(int tipoajustenro)
        {
            DTipoAjuste objTipoAjuste = new DTipoAjuste();
            objTipoAjuste.TipoAjusteNro = tipoajustenro;
            return objTipoAjuste.EliminarTipoAjuste(objTipoAjuste);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {           
            DTipoAjuste objTipoAjuste = new DTipoAjuste();            
            return objTipoAjuste.MostrarTipoAjuste();
        }


        //Metodo para buscar que llama al metodo buscar de la capa Datos
        public static DataTable Buscar(string textobuscar)
        {
            DTipoAjuste objTipoAjuste = new DTipoAjuste();
            objTipoAjuste.TextoBuscar = textobuscar;
            return objTipoAjuste.BuscarTipoAjuste(objTipoAjuste);
        }



    }
}
