using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NTipoImpuesto
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos

        public NTipoImpuesto(string descripcion, decimal porcentajeiva, decimal baseImponible)
        {
            DTipoImpuesto objTipoImpuesto = new DTipoImpuesto();
            objTipoImpuesto.Descripcion = descripcion;
            objTipoImpuesto.PorcentajeIva = porcentajeiva;
            objTipoImpuesto.BaseImponible = baseImponible;
        }
        public static string Insertar(string descripcion, decimal porcentajeiva, decimal baseImponible)
        {
            DTipoImpuesto objTipoImpuesto = new DTipoImpuesto();
            objTipoImpuesto.Descripcion = descripcion;
            objTipoImpuesto.PorcentajeIva = porcentajeiva;
            objTipoImpuesto.BaseImponible = baseImponible;
            return objTipoImpuesto.InsertarImpuesto(objTipoImpuesto);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(int tipoimpuestonro,string descripcion, decimal porcentajeiva, decimal baseImponible)
        {
            DTipoImpuesto objTipoImpuesto = new DTipoImpuesto();
            objTipoImpuesto.TipoImpuestoNro = tipoimpuestonro;
            objTipoImpuesto.Descripcion = descripcion;
            objTipoImpuesto.PorcentajeIva = porcentajeiva;
            objTipoImpuesto.BaseImponible = baseImponible;
            return objTipoImpuesto.EditarImpuesto(objTipoImpuesto);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int tipoimpuestonro)
        {
            DTipoImpuesto objTipoImpuesto = new DTipoImpuesto();
            objTipoImpuesto.TipoImpuestoNro = tipoimpuestonro;
            return objTipoImpuesto.EliminarImpuesto(objTipoImpuesto);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DTipoImpuesto().MostrarImpuesto();
        }

        //Metodo para buscar que llama al metodo buscar de la capa Datos
        public static DataTable Buscar(string textoBuscar)
        {
            DTipoImpuesto objTipoImpuesto = new DTipoImpuesto();
            objTipoImpuesto.TextoBuscar = textoBuscar;
            return objTipoImpuesto.BuscarImpuesto(objTipoImpuesto);
        }

    }
}
