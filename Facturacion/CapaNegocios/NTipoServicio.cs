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
    public class NTipoServicio
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(string descripcion)
        {
            ETipoServicio objTipoServicio = new ETipoServicio();
            objTipoServicio.Descripcion = descripcion;
            return new DTipoServicio().InsertarTipoServicio(objTipoServicio);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(int tipoServicioNro, string descripcion)
        {
            ETipoServicio objTipoServicio = new ETipoServicio();
            objTipoServicio.TipoServicioNro = tipoServicioNro;
            objTipoServicio.Descripcion = descripcion;
            return new DTipoServicio().EditarTipoServicio(objTipoServicio);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int tipoServicioNro)
        {
            DTipoServicio objTipoServicio = new DTipoServicio();
            return objTipoServicio.EliminarTipoServicio(tipoServicioNro);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static List<ETipoServicio> Mostrar()
        {
            List<ETipoServicio> ListaTipoServicio = new List<ETipoServicio>();
            try
            {
                var servicioDT = new DTipoServicio().MostrarTipoServicio();
                foreach (DataRow row in servicioDT.Rows)
                {
                    ETipoServicio eServicio = new ETipoServicio();
                    eServicio.TipoServicioNro = Convert.ToInt32(row[0]);
                    eServicio.Descripcion = row[1].ToString();

                    ListaTipoServicio.Add(eServicio);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaTipoServicio;
        }
    }
}
